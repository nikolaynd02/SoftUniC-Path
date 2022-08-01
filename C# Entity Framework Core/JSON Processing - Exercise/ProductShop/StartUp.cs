
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using ProductShop.DTOs;
using ProductShop.DTOs.Categories;
using ProductShop.DTOs.CategoriesProducts;
using ProductShop.DTOs.Products;
using ProductShop.DTOs.Users;
using ProductShop.Models;

namespace ProductShop
{

    using System;
    using AutoMapper;
    using ProductShop.Data;
    using System.IO;
    using System.Linq;



    public class StartUp
    {
        private static string filePath;

        public static void Main(string[] args)
        {
            ProductShopContext dbContext = new ProductShopContext();

            //Static because of Judge
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));

            //InitializeOutputFilePath("users-and-products.json");

            //string inputJsonU = File.ReadAllText($"../../../Datasets/users.json");
            //string inputJsonP = File.ReadAllText($"../../../Datasets/products.json");
            //string inputJsonC = File.ReadAllText($"../../../Datasets/categories.json");
            //string inputJsonCP = File.ReadAllText($"../../../Datasets/categories-products.json");

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //Console.WriteLine($"Database copy was created!");

            //Console.WriteLine(ImportUsers(dbContext, inputJsonU));
            //Console.WriteLine(ImportProducts(dbContext, inputJsonP));
            //Console.WriteLine(ImportCategories(dbContext, inputJsonC));
            //Console.WriteLine(ImportCategoryProducts(dbContext, inputJsonCP));

            // Difference between db and examples in exercise exports possible because of no data validation in all import exercises
            filePath =
                Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/", "categories-by-products.json");

            File.WriteAllText(filePath,GetCategoriesByProductsCount(dbContext));
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }



        //Problem.01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ImportUserDto[] usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            User[] users = Mapper.Map<User[]>(usersDto);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        //Problem.02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ImportProductDto[] productsDto = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            Product[] products = Mapper.Map<Product[]>(productsDto);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //Problem.03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ImportCategoryDto[] categoriesDto = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> categories = new List<Category>();

            foreach (ImportCategoryDto categoryDto in categoriesDto)
            {
                if (!IsValid(categoryDto))
                {
                    continue;
                }

                Category category = Mapper.Map<Category>(categoryDto);
                categories.Add(category);
            }

            context.Categories.AddRange((categories));
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Problem.04 
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ImportCategoryProductDto[] categoryProductDtos =
                JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (ImportCategoryProductDto cPDto in categoryProductDtos)
            {
                CategoryProduct categoryProduct = Mapper.Map<CategoryProduct>(cPDto);
                categoryProducts.Add(categoryProduct);

            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Problem.05
        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductInRangeDto[] products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ExportProductInRangeDto>()
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        //Problem.06
        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportUserWithSoldProductDto[] usersWithProductsSold = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<ExportUserWithSoldProductDto>()
                .ToArray();

            return JsonConvert.SerializeObject(usersWithProductsSold, Formatting.Indented);
        }

        //Problem.07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ProjectTo<ExportCategoriesDto>()
                .ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }
    }
}
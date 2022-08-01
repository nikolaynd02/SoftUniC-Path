using System;
using System.Linq;
using ProductShop.DTOs;
using ProductShop.DTOs.Categories;
using ProductShop.DTOs.CategoriesProducts;
using ProductShop.DTOs.Products;
using ProductShop.DTOs.Users;
using ProductShop.Models;

namespace ProductShop
{
    using AutoMapper;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Imports
            CreateMap<ImportUserDto, User>();
            CreateMap<ImportProductDto, Product>();
            CreateMap<ImportCategoryDto, Category>();
            CreateMap<ImportCategoryProductDto, CategoryProduct>();
            
            //Exports
            CreateMap<Product, ExportProductInRangeDto>()
                .ForMember(d => d.SellerFulName, mo => mo.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            CreateMap<Product, ExportSoldProductDto>()
                .ForMember(d => d.BuyerFirstName, mo => mo.MapFrom(s => s.Buyer.FirstName))
                .ForMember(d => d.BuyerLastName, mo => mo.MapFrom(s => s.Buyer.LastName));

            CreateMap<User, ExportUserWithSoldProductDto>()
                .ForMember(d => d.SoldProducts, mo => mo.MapFrom(s => s.ProductsSold.Where(p => p.BuyerId.HasValue)));

            CreateMap<Category, ExportCategoriesDto>()
                .ForMember(d => d.ProductsCount, mo => mo.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(d => d.AveragePrice, mo => mo.MapFrom(s => $"{s.CategoryProducts.Average(c => c.Product.Price):f2}"))
                .ForMember(d => d.TotalRevenue, mo => mo.MapFrom(s => $"{s.CategoryProducts.Sum(c => c.Product.Price):f2}"));
        }
    }
}

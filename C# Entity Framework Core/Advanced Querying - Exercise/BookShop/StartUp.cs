namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            DbInitializer.ResetDatabase(dbContext);

            //string input = Console.ReadLine();           

            //Console.WriteLine(RemoveBooks(dbContext));

        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            string[] bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .AsNoTracking()
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);

        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .AsNoTracking()
                .ToArray();

            return string.Join(Environment.NewLine, goldenBooks);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new { b.Title, b.Price })
                .OrderByDescending(b => b.Price)
                .ToArray();

            StringBuilder output = new StringBuilder();

            foreach(var book in books)
            {
                output.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return output.ToString().Trim();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] books = context.BooksCategories
                .Where(bc => categories.Any(c => c == bc.Category.Name.ToLower()))
                .Select(bc => bc.Book.Title)
                .OrderBy(b => b)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder output = new StringBuilder();

            DateTime time = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < time)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price,
                    ReleaseDate = b.ReleaseDate.Value
                })
                .OrderByDescending(b => b.ReleaseDate)
                .ToArray();

            foreach(var book in books)
            {
                output.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return output.ToString().Trim();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNames = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToArray();

            StringBuilder output = new StringBuilder();

            foreach(var author in authorNames)
            {
                output.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return output.ToString().Trim();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string[] bookTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    x.Title,
                    AuthorFirstName = x.Author.FirstName,
                    AuthorLastName = x.Author.LastName
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");
            }

            return sb.ToString().Trim();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int bookCount = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .AsNoTracking()
                .ToArray()
                .Length;

            return bookCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsBookCopies = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    TotalBooks = x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.TotalBooks)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authorsBookCopies)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.TotalBooks}");
            }

            return sb.ToString().Trim();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Profit = x.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name)
                .ToArray();

            return string.Join(Environment.NewLine, categories.Select(x => $"{x.Name} ${x.Profit:f2}"));
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var booksPerCategory = context.Categories
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    CategoryName = x.Name,
                    CategoryBooks = x.CategoryBooks
                        .Select(x => new
                        {
                            x.Book.Title,
                            x.Book.ReleaseDate
                        })
                        .OrderByDescending(x => x.ReleaseDate)
                        .Take(3)
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var category in booksPerCategory)
            {
                sb.AppendLine($"--{category.CategoryName}");
                foreach (var book in category.CategoryBooks)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            int yearLessThan = 2010;

            IQueryable<Book> booksToUpdate = context.Books
                .Where(x => x.ReleaseDate.Value.Year < yearLessThan);

            int priceToIncrease = 5;
            foreach (Book book in booksToUpdate)
            {
                book.Price += priceToIncrease;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {            

            IQueryable<Book> books = context.Books
                .Where(b => b.Copies < 4200);
            int deletedBooks = books.Count();

            context.Books.RemoveRange(books);
            context.SaveChanges();
            return deletedBooks;
        }
    }

}

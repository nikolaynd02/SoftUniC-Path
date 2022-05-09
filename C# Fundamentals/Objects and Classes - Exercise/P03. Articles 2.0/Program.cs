using System;
using System.Collections.Generic;
using System.Linq;

namespace P03._Articles_2._0
{
    class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int numOfArticles = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < numOfArticles; i++)
            {

                string[] articleInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                Article article = new Article()
                {
                    Title = articleInfo[0],
                    Content = articleInfo[1],
                    Author = articleInfo[2]
                };

                articles.Add(article);
            }

            string sortParameter = Console.ReadLine();

            List<Article> reorderedArticles = new List<Article>();

            if (sortParameter == "title")
            {
                reorderedArticles = articles.OrderBy(x => x.Title).ToList();
            }
            else if(sortParameter == "content")
            {
                reorderedArticles = articles.OrderBy(x => x.Content).ToList();
            }
            else if(sortParameter == "author")
            {
                reorderedArticles = articles.OrderBy(x => x.Author).ToList();
            }

            foreach(Article currArticle in reorderedArticles)
            {
                Console.WriteLine(currArticle.ToString());
            }
        }
    }
}

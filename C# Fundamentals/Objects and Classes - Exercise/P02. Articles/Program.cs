using System;

namespace P02._Articles
{
    class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newName)
        {
            this.Title = newName;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
       
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleInfo = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);

            Article article = new Article()
            {
                Title = articleInfo[0],
                Content = articleInfo[1],
                Author = articleInfo[2]
            };

            int numOfCmd = int.Parse(Console.ReadLine());

            for(int i = 0; i < numOfCmd; i++)
            {
                string[] currCmd = Console.ReadLine().Split(": ");

                if (currCmd[0] == "Edit")
                {
                    article.Edit(currCmd[1]);
                }
                else if(currCmd[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(currCmd[1]);
                }
                else if(currCmd[0] == "Rename")
                {
                    article.Rename(currCmd[1]);
                }
            }

            Console.WriteLine(article.ToString());

        }
    }
}

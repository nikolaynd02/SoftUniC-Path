using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name,decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<Product> BagOfProducts
        {
            get { return bagOfProducts; }
        }

        public void Buy(Product product)
        {
            if(this.money < product.Cost)
            {
                Console.WriteLine($"{this.name} can't afford {product.Name}");
            }
            else
            {
                this.money -= product.Cost;
                this.bagOfProducts.Add(product);
                Console.WriteLine($"{this.name} bought {product.Name}");
            }
        }

        public override string ToString()
        {
            if (bagOfProducts.Count == 0)
            {
                return $"{this.name} - Nothing bought";
            }
            else
            {
                List<string> productsName = new List<string>();
                foreach(var product in bagOfProducts)
                {
                    productsName.Add(product.Name);
                }

                return $"{this.name} - {string.Join(", ", productsName)}";
            }
        }
    }
}

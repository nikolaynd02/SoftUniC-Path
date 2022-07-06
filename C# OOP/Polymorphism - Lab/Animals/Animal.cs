using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        public Animal(string name,string favFood)
        {
            this.Name = name;
            this.FavouriteFood = favFood;
        }

        public string Name { get; set; }
        public string FavouriteFood { get; set; }

        public abstract string ExplainSelf();
       
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private double weight;
        private double calories;

        private Dictionary<string, double> toppings = new Dictionary<string, double>()
        {
            ["meat"] = 1.2,
            ["veggies"] = 0.8,
            ["cheese"] = 1.1,
            ["sauce"] = 0.9
        };

        public Topping(string name, double weight)
        {
            ToppingType = name;
            Weight = weight;
            Calories = 2 * weight * toppings[name.ToLower()];
        }


        public string ToppingType
        {
            get { return toppingType; }
            private set
            {
                if (!toppings.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            private set
            {
                if(value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.toppingType} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double Calories
        {
            get { return calories; }
            private set
            {
                this.calories = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough pizzasDough;
        private List<Topping> toppings;
        private double calories;
        private const int maxToppings = 10;       

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();

        }


        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value.Length <= 1 || value.Length >= 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough PizzasDough
        {
            get { return this.pizzasDough; }
            set
            {
                calories += value.Calories;
                this.pizzasDough = value;
            }
                
        }

        public List<Topping> Toppings
        {
            get { return this.toppings; }
            private set
            {
                this.toppings = value;
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

        public void AddTopping(Topping toppingToAdd)
        {            
            toppings.Add(toppingToAdd);
            if (toppings.Count > maxToppings)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            calories += toppingToAdd.Calories;
        }
    }
}

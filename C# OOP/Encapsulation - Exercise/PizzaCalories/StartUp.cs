using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


            try
            {
                if (pizzaInfo.Length == 1)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                Pizza pizza = new Pizza(pizzaInfo[1]);

                string[] doughInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));

                pizza.PizzasDough = dough;

                string cmd = string.Empty;
                while ((cmd = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string toppingType = toppingInfo[1];
                    double weight = double.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingType, weight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");

            }
            catch(ArgumentException arg)
            {
                Console.WriteLine(arg.Message);
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favFood) : base(name, favFood)
        {

        }

        public override string ExplainSelf()
        {
            return $"I am {this.Name} and my favourite food is {this.FavouriteFood}\nDJAAF";
        }
    }
}

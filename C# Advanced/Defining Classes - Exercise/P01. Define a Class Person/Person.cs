using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Person
    {
        //fields
        private string name;
        private int age;

        //constructor by default
        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age)
        {
            Name = "No name";
            Age = age;
        }

        //constructor with parameters
        public Person(string name,int age)
        {
            Name = name;
            Age = age;
        }


        //methods
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
}

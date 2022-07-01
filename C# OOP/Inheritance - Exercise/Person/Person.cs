using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private int age;
        private string name;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public virtual int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new Exception();
                }

                age = value;
            }
        }


        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(string.Format($"Name: {this.Name}, Age: {this.Age}"));

            return strBuilder.ToString();
        }
    }
}

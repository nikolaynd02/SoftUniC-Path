using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        public List<Person> family = new List<Person>();

        public void AddMember(Person newPerson)
        {
            family.Add(newPerson);
        }

        public Person GetOldestMember()
        {
            return family.OrderBy(x => x.Age).ToList()[family.Count - 1];
        }
    }
}

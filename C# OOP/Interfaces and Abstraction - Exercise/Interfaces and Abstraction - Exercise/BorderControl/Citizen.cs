﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentifiable
    {

        public Citizen(string name, string age, string id) 
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Id { get; set; }

        public bool IsIdValid(string nums)
        {
            if (this.Id.EndsWith(nums))
            {
                return false;
            }

            return true;
        }
    }
}

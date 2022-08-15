﻿using System;
using System.Collections.Generic;
using System.Text;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destructionLevel;

        protected Weapon(int destructionLevel, double price)
        {
            DestructionLevel = destructionLevel;
            Price = price;
        }

        public double Price
        {
            get
            {
                return this.price;
            }

            private set
            {
               this.price = value;
            }
        }

        public int DestructionLevel
        {
            get
            {
                return this.destructionLevel;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }

                if (value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }

                this.destructionLevel = value;
            }
        }
    }
}

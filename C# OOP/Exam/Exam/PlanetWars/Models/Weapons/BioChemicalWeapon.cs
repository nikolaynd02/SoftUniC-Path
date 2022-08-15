using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        //private double price = 3_200_000_000;

        public BioChemicalWeapon(int destructionLevel) : base(destructionLevel, 3)
        {

        }
    }
}

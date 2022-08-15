using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            [TestCase("Earth")]
            [TestCase("Venus")]
            public void Name_Property_Should_Set_Value_Correctly(string name)
            {
                Planet planet = new Planet(name, 100);

                Assert.AreEqual(name, planet.Name);
            }

            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void Name_Property_Should_Thrown_Argument_Exception(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, 100);
                }, "Invalid planet Name");
            }

            [Test]
            [TestCase(1)]
            [TestCase(10)]
            [TestCase(600)]
            public void Budget_Property_Should_Set_Value_Correctly(double budget)
            {
                Planet planet = new Planet("Earth", budget);

                Assert.AreEqual(budget, planet.Budget);
            }
            [Test]
            [TestCase(-1)]
            [TestCase(-10)]
            [TestCase(-999)]
            public void Budget_Property_Should_Thrown_Argument_Exception(double budget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("Earth", budget);
                }, "Budget cannot drop below Zero!");
            }

            [Test]
            public void Add_Weapon_Method_Should_Work()
            {
                Planet planet = new Planet("Earth", 100);
                Weapon weapon = new Weapon("AK", 75, 5);

                planet.AddWeapon(weapon);
                int expectedCount = 1;
                int actualCount = planet.Weapons.Count;

                Assert.AreEqual(expectedCount, actualCount);
            }

            [Test]
            public void Add_Weapon_Method_Should_Thrown_Invalid_Operation_Exception()
            {
                Planet planet = new Planet("Earth", 100);
                Weapon weapon1 = new Weapon("AK", 75, 5);
                Weapon weapon2 = new Weapon("Mk", 2, 3);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon2);
                }, $"There is already a {weapon2.Name} weapon.");
            }

            [Test]
            public void Military_Power_Ratio_Property_Should_Work()
            {
                Planet planet = new Planet("Earth", 100);
                Weapon weapon1 = new Weapon("AK", 75, 5);
                Weapon weapon2 = new Weapon("Mk", 2, 3);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                double actualMilitaryPowerRatio = planet.MilitaryPowerRatio;
                double expectedMilitaryPowerRatio = 8;

                Assert.AreEqual(expectedMilitaryPowerRatio, actualMilitaryPowerRatio);
            }

            [Test]
            [TestCase(100)]
            [TestCase(2)]
            public void Profit_Method_Should_Work(double amount)
            {
                Planet planet = new Planet("Earth", 100);

                planet.Profit(amount);

                double expected = 100 + amount;
                double actual = planet.Budget;

                Assert.AreEqual(expected, actual);
            }
            
            [Test]
            [TestCase(99)]
            [TestCase(2)]
            public void Spend_Funds_Method_Should_Work(double amount)
            {
                Planet planet = new Planet("Earth", 100);

                planet.SpendFunds(amount);

                double expected = 100 - amount;
                double actual = planet.Budget;

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void Spend_Funds_Method_Should_Thrown_Invalid_Operation_Exception()
            {
                Planet planet = new Planet("Earth", 100);
                double amount = 110;

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(amount);
                }, $"Not enough funds to finalize the deal."
                );
            }


            [Test]
            public void Remove_Weapon_Should_Work()
            {
                Planet planet = new Planet("Earth", 100); 
                Weapon weapon1 = new Weapon("AK", 75, 5);
                Weapon weapon2 = new Weapon("Mk", 2, 3);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.RemoveWeapon(weapon1.Name);

                int actualCount = planet.Weapons.Count;
                int expectedCount = 1;
                Assert.AreEqual(expectedCount, actualCount);

            }


            [Test]
            [TestCase("AK")]
            public void Upgrade_Weapon_Should_Work(string weaponName)
            {
                Planet planet = new Planet("Earth", 100);
                Weapon weapon1 = new Weapon("AK", 75, 5);
                Weapon weapon2 = new Weapon("Mk", 2, 3);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.UpgradeWeapon(weaponName);

                int actual = weapon1.DestructionLevel++;
                int expected = 6;

                Assert.AreEqual(expected, actual);
            }

            [Test]
            [TestCase("Name")]
            [TestCase("Weapon")]
            public void Upgrade_Weapon_Should_Thrown_Invalid_Operation_Exception(string weaponName)
            {
                Planet planet = new Planet("Earth", 100);
                Weapon weapon1 = new Weapon("AK", 75, 5);
                Weapon weapon2 = new Weapon("Mk", 2, 3);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon(weaponName);
                }, 
                $"{weaponName} does not exist in the weapon repository of {planet}"
                );
            }

            [Test]
            public void Destruct_Opponent_Should_Work()
            {
                Planet planet1 = new Planet("Earth", 100);
                Planet planet2 = new Planet("Venus", 200);

                Weapon weapon1 = new Weapon("AK", 75, 5);
                Weapon weapon2 = new Weapon("Mk", 2, 3);

                planet1.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);

                string expected = $"{planet2.Name} is destructed!";
                string actual = planet1.DestructOpponent(planet2);

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void Destruct_Opponent_Should_Thrown_Invalid_Operation_Exception()
            {
                Planet planet1 = new Planet("Earth", 100);
                Planet planet2 = new Planet("Venus", 200);

                Weapon weapon1 = new Weapon("AK", 75, 5);
                Weapon weapon2 = new Weapon("Mk", 2, 10);

                planet1.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet1.DestructOpponent(planet2);
                },
                $"{planet2.Name} is too strong to declare war to!"
                );
            }
        }
    }
}

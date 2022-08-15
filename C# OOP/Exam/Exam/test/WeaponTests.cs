using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class WeaponTests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void Name_Property_Should_Set_Value()
            {
                Weapon weapon = new Weapon("Ak", 10, 5);
                string expectedName = "Ak";

                Assert.AreEqual(expectedName, weapon.Name);
            }

            [Test]
            [TestCase(1)]
            [TestCase(999)]
            public void Price_Property_Should_Work_Correctly(double price)
            {
                Weapon weapon = new Weapon("Ak", price, 3);

                Assert.AreEqual(weapon.Price, price);
            }

            [Test]
            [TestCase(-1)]
            [TestCase(-999)]
            public void Price_Property_Should_Thrown_Argument_Exception(double price)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("Mk", price, 11);
                },
                "Price cannot be negative."
                );
            }

            [Test]
            public void Destruction_Level_Property_Should_Set_Value()
            {
                Weapon weapon = new Weapon("WeaponName", 20, 5);
                int expectedDestructionLevel = 5;

                Assert.AreEqual(expectedDestructionLevel, weapon.DestructionLevel);
            }

            [Test]
            public void Increase_Destruction_Level_Method_Should_Add_1_To_Destruction_Level()
            {
                Weapon weapon = new Weapon("WeaponName", 20, 5);
                weapon.IncreaseDestructionLevel();
                int expectedDestructionLevel = 6;

                Assert.AreEqual(expectedDestructionLevel, weapon.DestructionLevel);
            }

            [Test]
            public void IsNuclear_Property_Should_Be_True()
            {
                Weapon weapon = new Weapon("weapon", 50, 12);

                bool isNuclear = weapon.IsNuclear;

                Assert.IsTrue(isNuclear);
            }

            [Test]
            public void IsNuclear_Property_Should_Be_False()
            {
                Weapon weapon = new Weapon("weapon", 45, 2);

                bool isNuclear = weapon.IsNuclear;

                Assert.IsFalse(isNuclear);
            }
        }
    }
}

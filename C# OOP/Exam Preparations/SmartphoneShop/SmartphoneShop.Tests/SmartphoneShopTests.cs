using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
       [Test]
       public void Test_Constructor_Shop_Invalid_Should_Throw_Argument_Exception()
       {
            Assert.Throws<ArgumentException>(() => new Shop(-2), "Constructor should throw with invalid capacity");
       }

        [Test]
        public void Test_Constructor_Should_Initialize_Properly()
        {
            Shop shop = new Shop(20);

            Assert.AreEqual(20, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Test_Method_Add_Smartphone_When_Phone_Already_Exists()
        {
            Shop shop = new Shop(2);

            shop.Add(new Smartphone("s51", 100));

            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("s51", 100)));
        }

        [Test]
        public void Test_Method_Add_When_Capacity_Is_Reached()
        {
            Shop shop = new Shop(1);

            shop.Add(new Smartphone("s51", 100));

            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("l99", 120)));
        }

        [Test]
        public void Test_Add_Should_Work_Correctly()
        {
            Shop shop = new Shop(1);
            Smartphone phone = new Smartphone("A52", 100);

            shop.Add(phone);

            Assert.AreEqual(1, shop.Count, "Add does not work properly - mismatch count.");
        }

        [Test]
        public void Test_Method_Remove_When_Phone_Is_Invalid()
        {
            Shop shop = new Shop(10);

            shop.Add(new Smartphone("s51", 100));

            Assert.Throws<InvalidOperationException>(() => shop.Remove(""));
        }

        [Test]
        public void Test_Method_Remove_When_Phone_Is_Valid()
        {
            Shop shop = new Shop(10);

            shop.Add(new Smartphone("s51", 100));
            shop.Add(new Smartphone("bl1", 100));

            shop.Remove("s51");

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void Test_Test_Phone_Not_Exist_Should_Throw_Invalid_Operation_Exception()
        {
            Shop shop = new Shop(1);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("A52", 100),
                "Method should throw when phone model does not exist.");
        }

        [Test]
        public void Test_Test_Phone_Low_Battery_Should_Throw_Invalid_Operation_Exception()
        {
            Shop shop = new Shop(1);
            Smartphone phone = new Smartphone("A52", 50);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("A52", 51),
                "Method should throw when phone battery is lower than the given battery.");
        }

        [Test]
        public void Test_Test_Phone_Should_Work_Correctly()
        {
            Shop shop = new Shop(1);
            Smartphone phone = new Smartphone("A52", 100);

            shop.Add(phone);

            shop.TestPhone("A52", 52);

            Assert.AreEqual(48, phone.CurrentBateryCharge, "Phones battery does not get reduced correctly.");
        }

        [Test]
        public void Test_Charge_Phone_Invalid_Should_Throw_Invalid_Operation_Exception()
        {
            Shop shop = new Shop(1);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("A52"),
                "Method should throw when phone model does not exist.");
        }

        [Test]
        public void Test_Charge_Phone_Should_Work_Correctly()
        {
            Shop shop = new Shop(1);
            Smartphone phone = new Smartphone("A52", 100);

            phone.CurrentBateryCharge = 10;
            shop.Add(phone);
            shop.ChargePhone("A52");

            Assert.AreEqual(100, phone.CurrentBateryCharge, "Phones battery does not get filled properly.");
        }

    }
}
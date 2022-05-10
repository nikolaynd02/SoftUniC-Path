using System;
using System.Collections.Generic;
using System.Linq;

namespace P06._Store_Boxes
{
    class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int ItemQuantity { get; set; }

        public decimal BoxPrice
        {
            get
            {
                return this.ItemQuantity * this.Item.Price;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<Box> boxes = new List<Box>();

            while (info[0] != "end")
            {
                string serialNumber = info[0];
                string name = info[1];
                int quantity = int.Parse(info[2]);
                decimal price = decimal.Parse(info[3]);

                Box box = new Box()
                {
                    SerialNumber = serialNumber,
                    Item = new Item()
                    {
                        Name = name,
                        Price = price
                    },
                    ItemQuantity = quantity
                };

                boxes.Add(box);

                info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            List<Box> orderedBoxes = boxes
                .OrderByDescending(b => b.BoxPrice)
                .ToList();

            foreach(Box box in orderedBoxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.BoxPrice:f2}");
            }
        }
    }
}

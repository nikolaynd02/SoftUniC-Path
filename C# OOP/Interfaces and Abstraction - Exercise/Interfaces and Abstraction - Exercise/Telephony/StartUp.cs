using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartphone = new Smartphone();
            Stationaryphone stationaryphone = new Stationaryphone();

            foreach(string phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 10)
                {
                    Console.WriteLine(smartphone.Calling(phoneNumber));
                }
                else
                {
                    Console.WriteLine(stationaryphone.Calling(phoneNumber));
                }
            }

            foreach(string website in websites)
            {
                Console.WriteLine(smartphone.Browsing(website));
            }
        }
    }
}

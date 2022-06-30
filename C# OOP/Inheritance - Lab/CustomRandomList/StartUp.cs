using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();

            randomList.Add("asaf");
            randomList.Add("fafgsrgsa");
            randomList.Add("fffddggggggfafgdfgdsgsrgsa");

            randomList.Add("hfghf");

            randomList.Add("hhhh");

            Console.WriteLine(randomList.RandomString());

        }
    }
}

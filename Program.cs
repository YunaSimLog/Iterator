using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var collection = new WordsCollection();
            collection.AddItem("첫번째");
            collection.AddItem("두번째");
            collection.AddItem("세번째");

            Console.WriteLine("순방향 순회:");

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n역방향 순회:");

            collection.ReverseDirection();

            foreach(var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}

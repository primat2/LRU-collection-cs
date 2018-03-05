using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeastRecentlyUsedCollection
{
    class Program
    {
        public static void MyListRemoveTesting()
        {
            Console.WriteLine("======= Remove operations testing =======");
            ListLRU<int> list = new ListLRU<int>();
            var head = list.Add(100, 1);
            var second = list.Add(200, 2);
            var third = list.Add(300, 3);
            var tail = list.Add(400, 4);

            Console.WriteLine(list);
            list.Remove(second);

            Console.WriteLine(list);
            list.Remove(head);
            Console.WriteLine(list);

            list.Remove(tail);
            Console.WriteLine(list);

            list.Remove(third);
            Console.WriteLine(list);
        }

        public static void MyListLastUsedTesting()
        {
            Console.WriteLine("======= Remove LastUsed testing =======");
            ListLRU<int> list = new ListLRU<int>();
            var head = list.Add(100, 1);
            var second = list.Add(200, 2);
            list.Add(300, 3);
            var tail = list.Add(400, 4);

            Console.WriteLine(list);
            list.RemoveLastUsed();
            Console.WriteLine(list);
        }

        public static void MyListGetTesting()
        {
            Console.WriteLine("======= Get operations testing =======");
            ListLRU<int> list = new ListLRU<int>();
            var head = list.Add(100, 1);
            var second = list.Add(200, 2);
            var third = list.Add(300, 3);
            var tail = list.Add(400, 4);

            Console.WriteLine(list.Get(head));
            Console.WriteLine(list);

            list.RemoveLastUsed();
            Console.WriteLine(list);
        }

        static void Main(string[] args)
        {
            MyListRemoveTesting();
            MyListLastUsedTesting();
            MyListGetTesting();

            LRU<int> muLRU = new LRU<int>();

            Console.ReadLine();
        }
    }
}

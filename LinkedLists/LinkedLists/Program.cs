using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    internal class Program
    {
        static LinkedList<int> items = new LinkedList<int>();
        static void Main(string[] args)
        {
            Random rng = new Random();

            while(items.Count < 25)
            {
                int temp = rng.Next(50);

                if (items.Count == 0 || temp < items.First.Value)
                    items.AddFirst(temp);
                else if (temp > items.Last.Value)
                    items.AddLast(temp);
                else
                {
                    LinkedListNode<int> scanner = items.First;

                    while (scanner.Next != null && scanner.Next.Value < temp)
                        scanner = scanner.Next;

                    items.AddAfter(scanner, temp);
                }
            }

            foreach (int i in items)
                Console.Write(i + " ");
            Console.WriteLine();

            for (int i = 0; i < 10; ++i)
            {
                int valueToBeRemoved = rng.Next(50);

                bool found = items.Remove(valueToBeRemoved);

                if (found)
                    Console.WriteLine($"The first {valueToBeRemoved} has been removed from the LinkedList");
                else
                    Console.WriteLine($"{valueToBeRemoved} was not found in the LinkedList");
            }
            
            foreach (int i in items)
                Console.Write(i + " ");
            Console.WriteLine();

            Console.ReadKey();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            List<string> firsts = new List<string>() { "John", "Harry", "Jessica", "Rachael", "Harvey" };
            List<string> lasts = new List<string>() { "Spector", "Ross", "Pearson", "Smith", "Litt" };
            List<Person> people = new List<Person>();

            for (int i = 0; i < 10; ++i)
            {
                people.Add(new Person(firsts[rng.Next(firsts.Count)],
                                        lasts[rng.Next(lasts.Count)], rng.Next(10)));
            }

            Console.WriteLine("Putput after initial load");
            foreach (Person p in people)
                Console.WriteLine(p);
            Console.WriteLine();

            Console.WriteLine("IndexOf()");
            Person person = new Person("John", "Pearson", 5);
            int location = people.IndexOf(person);
            Console.WriteLine($"{person} found at index {location}");

            Person found = people.Find(delegate(Person buddy) 
                                        {
                                            Random gen = new Random();
                                            
                                            return buddy.Age.Equals(person.Age); 
                                        });
            Console.WriteLine($"Found {found} in the Collection");

            people.Sort((left, right) => left.First.CompareTo(right.First));
            foreach (Person p in people)
                Console.WriteLine(p);
            Console.WriteLine();





            //string[] ordinals = ["First", "Second", "Third", "Fourth", "Fifth",
            //               "Sixth", "Seventh", "Eighth", "Ninth", "Tenth"];
            //string[] copiedOrdinals = new string[ordinals.Length];
            //Action<string[], string[], int, int> copyOperation = 
            //            (s1, s2, pos, num) => CopyStrings(s1, s2, pos, num);
            //copyOperation(ordinals, copiedOrdinals, 3, 5);

            //Console.WriteLine();
            //foreach (string ordinal in copiedOrdinals)
            //    Console.WriteLine(string.IsNullOrEmpty(ordinal) ? "<None>" : ordinal);







            Console.ReadKey();
        }

        //private static void CopyStrings(string[] source, string[] target,
        //                           int startPos, int number)
        //{
        //    if (source.Length != target.Length)
        //        throw new IndexOutOfRangeException("The source and target arrays must have the same number of elements.");

        //    for (int ctr = startPos; ctr <= startPos + number - 1; ctr++)
        //        target[ctr] = source[ctr];
        //}
    }

    class Person :IComparable
    {
        string _first;
        string _last;
        int _age;

        public int Age
        {
            get { return _age; }
        }

        public string First
        {
            get { return _first; }
        }

        public Person(string first, string last, int age)
        {
            _first = first;
            _last = last;
            _age = age;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Person person)) return false;

            return _age.Equals(person._age);
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Person person)) 
                throw new Exception("The wrong type was provide for comparison!");

            return _age.CompareTo(person._age);
        }

        public static int DescendingAge (Person left, Person right)
        {
            if (left == null && right == null) return 0;
            if (left == null) return 1;
            if (right == null) return -1;

            return right._age.CompareTo(left._age);
            // right.CompareTo(left);
        }

        public override string ToString()
        {
            return _first + " " + _last + " : " + _age;
        }
    }
}

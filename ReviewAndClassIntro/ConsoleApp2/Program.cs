using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    struct Person
    {
        public string first;
        public string last;
        public int age;

        public Person (string f, string l, int a)
        {
            first = f;
            last = l;
            age = a;
        }

        public override string ToString()
        {
            return last + ", " + first + " : " + age;
        }
    }

    class Human
    {
        private string first = "Hello";
        private string last;
        private int age;

        public Human(string f, string l, int a)
        {
            SetFirst(f);
            SetLast(l);
            SetAge(a);
        }

        public Human() : this("Default", "meh", 125) { }
     

        public void SetFirst (string f)
        {
            first = f.ToLower();
        }

        public void SetLast(string l)
        {
            last = l.ToUpper();
        }

        public void SetAge(int a)
        {
            if (a < 0)
                throw new Exception("A person;s age must be greater than 0");

            age = a;
        }

        public string GetFirst()
        {
            return first;
        }

        public string GetLast()
        {
            return last;
        }

        public int GetAge()
        {
            return age;
        }
    }

    enum DayOfWeek
    {
        Sunday = 1, Monday, Tuesday, Wednesday = 50,
        Thursday = 48, Friday, Saturday
    }

    internal class Program
    {        
        static void Main(string[] args)
        {
            int value = 50;
            DayOfWeek day = (DayOfWeek)value;
            Console.WriteLine(sizeof(DayOfWeek));
            Console.WriteLine(day);
            

            bool yesNo = true;

            switch(value)
            {
                case 0:
                case 1:
                case 10:
                case 20:

                    break;

                case 2:
                    break;
            }

            object thing = new object();
            
            int[] numbers = new int[20];
            int[,] values = new int[5, 3];
            int[][] myStuff = new int[9][];

            Human me = new Human();// = new Person("Shane", "Kelemen", 50);
            //me.SetFirst("Shane");
            //me.SetLast("Kelemen");
            //me.SetAge(50);
            Console.WriteLine(me.GetFirst() + ", " + me.GetLast() + " : " + me.GetAge());
            Console.WriteLine(me);

            Random gen = new Random(10);
            for (int i = 0; i < 20; ++i)
                Console.Write(gen.Next(100) + ", ");
            Console.WriteLine();

            List<int> myNums = new List<int>();
            Console.WriteLine("List capacity : " + myNums.Capacity);
            Console.WriteLine("List spots used : " + myNums.Count);
            myNums.Add(6);
            myNums.Add(8);
            myNums.Add(2);
            myNums.Add(1);
            myNums.Add(6);
            myNums.Add(8);
            myNums.Add(2);
            myNums.Add(1);
            myNums.Add(6);
            Console.WriteLine("List capacity : " + myNums.Capacity);
            Console.WriteLine("List spots used : " + myNums.Count);
           

            Console.ReadKey();
        }
    }
}

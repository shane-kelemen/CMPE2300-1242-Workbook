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
        // The following are data members that are the actual storage for the information in the class.
        // Best practice has us keep these private to the class, meaning that they are not accible
        // outside the class.  This follows a priciple called encapsulation.
        // NOTE:  All data members should be commented, even if trivial
        private string first = "Hello";     // Stores the first name of the Human 
        private string last;                // Stores the last name of the Human
        private int age;                    // Stores the age of the Human

        // The following are manual properties, meaning they have been backed by the private data members
        // that were defined above.  These are essentially special methods that replace the accessors and mutators,
        // and should be commented as such.
        /// <summary>
        /// string First
        /// get - returns the value of the first name of the Human
        /// set - accepts a string that will be lower cased and then assigned to be the first name of the Human
        /// </summary>
        public string First
        {
            set { first = value.ToLower(); }
            get { return first; }
        }

        /// <summary>
        /// string Last
        /// get - returns the value of the last name of the Human
        /// set - accepts a string that will be upper cased and then assigned to be the first name of the Human
        /// </summary>
        public string Last
        {
            // The private on the set is optional.  Using private causes the thing it is applied to to be
            // inaccessible outside the class, but still usable within.
            private set { last = value.ToUpper(); }
            get { return last; }
        }

        /// <summary>
        /// int Age
        /// get - returns the value of the age of the Human
        /// set - accepts an int that will be check to be greater than 0 and then assigned to be the age of the Human
        /// Exception thrown if an age of less than zero is supplied
        /// </summary>
        public int Age
        {
            set
            {
                if (value < 0)
                    throw new ArgumentException("A person's age must be greater than 0!");

                age = value;
            }

            get { return age; }
        }

        // The next few lines are a private data member and manual property with get and set defined that
        // are equivalent to the automatic property that follows.
        // 
        //ConsoleColor colour;
        //public ConsoleColor Colour
        //{
        //    set { colour = value; }
        //    get { return colour; }
        //}

        // The following is an automatic property that is equivalent to the above.
        // An automatic property looks like it is violating encapsulation because it is allowing direct access
        // to a data member, but in reality, the runtime create a private data member with which the automatic
        // property interacts.
        // NOTE: The private on the set is optional.  using private on the get or the set allows that part of
        //       the property to be usable inside the class but inacceible outside the class.
        public ConsoleColor Colour { get; private set; }

        // The following is a "calculated" or "computed" property, meaning it is not directly tied to a single
        // class data member.  Most often a computed property is only providing a get, but both are permitted
        // if they make sense.  Don't forget to leverage!
        public string FullName
        {
            get
            {
                // Note the individual properties are being leveraged.
                return Last + ", " + First;
            }


            set
            {
                string[] parts = null;
                if (value.Split(' ').Length != 2)
                    throw new ArgumentException("You must provide a first and last name separated by a space character!");

                // Again notice that the individual properties are leveraged
                First = parts[0];
                Last = parts[1];
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <param name="l"></param>
        /// <param name="a"></param>
        public Human(string f, string l, int a)
        {
            First = f;
            Last = l;
            Age = a;

            Colour = ConsoleColor.Green;
        }

        public Human() : this("Default", "meh", 125) { }
     

        //public void SetFirst (string f)
        //{
        //    first = f.ToLower();
        //}

        //public void SetLast(string l)
        //{
        //    last = l.ToUpper();
        //}

        //public void SetAge(int a)
        //{
        //    if (a < 0)
        //        throw new Exception("A person's age must be greater than 0!");

        //    age = a;
        //}

        //public string GetFirst()
        //{
        //    return first;
        //}

        //public string GetLast()
        //{
        //    return last;
        //}

        //public int GetAge()
        //{
        //    return age;
        //}
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
            me.First = "Shane";
            //me.SetLast("Kelemen");
            //me.SetAge(50);
            Console.WriteLine(me.First + ", " + me.Last + " : " + me.Age);
            Console.WriteLine(me);
            Console.WriteLine(me.FullName);

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

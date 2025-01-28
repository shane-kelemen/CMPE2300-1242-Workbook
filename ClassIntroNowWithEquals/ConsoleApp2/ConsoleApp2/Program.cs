using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    // This struct exists just to allow us to experiment with the differences 
    // between structs and classes
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
        // Note that static (shared) items are generally placed before instance specific items
        // Other than that, they are commented the same way
        private static List<string> survivability;   // Things humans need to survive

        // The following are data members that are the actual storage for the information in the class.
        // Best practice has us keep these private to the class, meaning that they are not accible
        // outside the class.  This follows a priciple called encapsulation.
        // NOTE:  All data members should be commented, even if trivial
        private string first = "Hello";     // Stores the first name of the Human 
        private string last;                // Stores the last name of the Human
        private int age;                    // Stores the age of the Human

        
        // Try experimenting with what you can and cannot access from within this property.
        // You should find that you may only access static data members, properties and methods.
        /// <summary>
        /// List<string> Survivability
        /// get - returns the static data List<string>
        /// set - if the passed in List<string> contains at least one string, assign it to the
        ///       private static data member, otherwise throw an exception.
        /// </summary>
        public static List<string> Survivability
        {
            get { return survivability; }
            set 
            {
                if (!(value.Count > 0))
                    throw new Exception("You must have some traits of suvivability to exist!");
                    
                survivability = value; 
            }
        }

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


        // A static constructor may not be called directly, and its sole purpose is to 
        // intiialize the static data members.  The compiler promises to call the static
        // constructor before any static member, property, or method of the class is used,
        // but we cannot count on this happenning right at the beginning of the application.
        static Human()
        {
            survivability = new List<string>();
            survivability.Add("Air");
            survivability.Add("Water");
        }


        /// <summary>
        /// Instance specific constructor.  This one is an explicit constructor, meaning it is 
        /// accepting / assigning to all instance specific data members
        /// </summary>
        /// <param name="f">Human's first name</param>
        /// <param name="l">Human's last name</param>
        /// <param name="a">Human's age</param>
        /// Note how the properties are used to assign the passed in values.  This properly
        /// leverages the data validation code we have built into the properties so we do 
        /// not need to duplicate our efforts.
        public Human(string f, string l, int a = 30)
        {
            First = f;
            Last = l;
            Age = a;

            Colour = ConsoleColor.Green;
        }

        /// <summary>
        /// Once a constructor is created for a class, the default constructor that we get 
        /// for free is hidden, meaning not available to the users of our class.  However,
        /// we can choose to define our own default constructor.
        /// Note that it is best practice to leverage off of the explicit constructor above 
        /// to again avoid repetition of code / effort.  However, once the leveraging is 
        /// complete, the body of this constructor will still execute if it is not empty, 
        /// so you may choose to override or add to the operations of the leveraged constructor.
        /// </summary>
        public Human() : this("Default", "meh", 125) 
        {
            Colour = ConsoleColor.Red;
        }


        // This list is only being created to demonstrate the difference between shallow
        // and deep copy.
        List<int> listForDeepCopyDemo = new List<int>();
        
        // This constructor would be considered a copy constructor.  When included, great 
        // care should be taken to ensure that a deep copy is being implemented.
        // Note that you may still leverage off other other constructors, but generally
        // only for value types.
        public Human(Human input) : this(input.First, input.Last, input.Age)
        {
            // A value type not included in another constructor list, so may still be
            // initialized in the body.
            Colour = input.Colour;

            // Shallow copy of a reference type.  Only the references are copied over,
            // thus the two Human instances would be using the same list.  Dangerous if not 
            // specifically intended...
            listForDeepCopyDemo = input.listForDeepCopyDemo;

            // Deep copy of a reference type. Using the constructor of the List<>, a completely
            // new List<> is created and then all of the data contained in the original List<>
            // is copied to the new List<>
            listForDeepCopyDemo = new List<int>(input.listForDeepCopyDemo);
        }


        // The default way that two instances of the same data type are compared is called
        // "identity (or reference) semantics".  This means that the only way that two instances
        // will be declared Equal is if they are indeed the same object.
        // We often want to compare two instances by their internal property values.  One or more 
        // internal values may be of interest and so compound comparisons may still be used.
        // This is called comparing by "value semantics"

        // Equals is automatically used by the framework for some common operations like Find, 
        // Contains, Remove, etc.  Anything where you might need to compare two class instances.
        public override bool Equals(object obj)
        {
            // First check that the two instances are the same type.  If not, immediately
            // return false.  After all, a cat and a dog should not be considered equal, as
            // extension methods that want to use the built in Equals method are expecting
            // to operate on a single data type.
            if (!(obj is Human human))
                return false;

            // These next two sections are options if you wish to exclude an object being
            // compared to itself from triggering a method looking for equality between two
            // instances
            //if (base.Equals(obj))
            //    return false;

            //if (this == obj)
            //    return false;

            // Instead of using the shortcut way of unboxing used in the RTTI check above,
            // you may explicitly unbox the input data once the type checking is complete.
            //Human human = (Human)obj;
            //Human human = obj as Human; 

            // Prepatory calculations may be included before the comparison that follows.

            // Once the above is complete, we may return a comaprison of whatever data we wish,
            // but obviously we are probably comparing data from within the two instances.
            return Age.Equals(human.Age);
        }


        // Override GetHashCode just as shown here to eliminate compiler warning.  This is used
        // by some extension methods, such as Intersect(), for them to function properly.  It is
        // also used with a more extensive algorithm when a HashTable is used as the collection.
        public override int GetHashCode()
        {
            return 1;
        }

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

            Random rng = new Random();
            Human testSubject = new Human();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Human.Survivability[rng.Next(Human.Survivability.Count)]);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();

            List<Human> humans = new List<Human>();
            humans.Add(testSubject);
            //humans.Add(new Human());
            humans.Add(new Human("Harvey", "Spector", 30));
            humans.Add(new Human("Jane", "Smith", 25));
            humans.Add(new Human("Mike", "Ross", 30));
            humans.Add(new Human("Harriette", "Spector", 28));
            humans.Add(new Human("Harry", "Smith", 22));

            Human newHuman = new Human("alksjdghalkjsgh", "lakjsghsg", 30);

            // Test Equality by same reference
            Console.WriteLine("Is a similar human contained in the list, but not the actual human? " 
                + humans.Contains(testSubject));
            Console.WriteLine("Is a similar human aged 30 contained in the list, but not the actual human? "
                + humans.Contains(newHuman));


            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVIPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BaseClass> stuff = new List<BaseClass>();

            for(int i = 0; i < 10; ++i)
            {
                stuff.Add(new Doubler());
                stuff.Add(new Tripler());
                stuff.Add(new Quadder());
            }

            foreach (BaseClass thing in stuff)
                Console.Write(thing);
            Console.WriteLine();

            foreach (BaseClass thing in stuff)
                thing.ChangeValue();

            foreach (BaseClass thing in stuff)
                Console.Write(thing);
            Console.WriteLine();

            Console.ReadKey();
        }
    }


    abstract class BaseClass
    {
        static Random rng = new Random();
        protected int value;

        public BaseClass()
        {
            value = rng.Next(100);
        }
           
        // A regular public method through which the user must access the 
        // desired polymorphic behaviour of the hierarchy.
        public void ChangeValue()
        {
            VChangeValue();     // Engage the hidden polymorphic hierarchy behaviour
            value *= -1;        // Add additional functionality that will apply
                                // to all instances in the hierarchy, even in newly
                                // derived classes.
        }

        // A polymorphic enabled method hidden from the user's direct access so
        // they are forced to use the public base class method.  This provides us the
        // ability to "gatekeep" access to the polymorphic behaviour and add on
        // additional functionality in the base class method the user must use if we
        // want to do so.
        // 
        // Making the method abstract also forces the user to implement the polymorhic 
        // method for any further dervied classes.
        protected abstract void VChangeValue();

        public override string ToString()
        {
            return value + ", ";
        }
    }


    class Doubler : BaseClass
    {
        // Override the polymorphic abstract method from the base class and add
        // functionality in the spirit of the hierarchy.
        protected override void VChangeValue()
        {
            value *= 2;
        }
    }

    class Tripler : BaseClass
    {
        protected override void VChangeValue()
        {
            value *= 3;
        }
    }

    class Quadder : BaseClass
    {
        protected override void VChangeValue()
        {
            value *= 4;
        }
    }
}

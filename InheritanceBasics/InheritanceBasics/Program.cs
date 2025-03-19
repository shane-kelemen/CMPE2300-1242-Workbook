using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SomeLibrary;

namespace InheritanceBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object thing = new object();
            Shape myShape = new Shape(new Point(5,5), Color.Green);
            Console.WriteLine(myShape);
            myShape.Move();
            Console.WriteLine(myShape);

            thing = myShape;
            Circle myCircle = new Circle(25.0, new Point(20, 20));
            Console.WriteLine(myCircle);
            myCircle.Move();
            Console.WriteLine(myCircle);

            myShape = myCircle;
            //Square mySquare;

            //if (myShape is Square)
            //     mySquare = (Square)myShape;

            if (myShape is Circle)
            {
                myCircle = myShape as Circle;
                Console.WriteLine("Found a Circle");
            }
            Console.ReadKey();
        }
    }

 

    

    //class Rect : Shape
    //{
    //    double length;
    //    double Width;

    //    double CalcArea()
    //    {
    //        return length * Width;
    //    }

    //    void Move()
    //    {

    //    }
    //}

    //class Square : Rect
    //{
        
    //}
}

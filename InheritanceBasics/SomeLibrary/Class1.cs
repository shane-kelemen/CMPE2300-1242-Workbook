using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SomeLibrary
{
    public class Shape
    {
        private protected Point _location;
        private protected double _area;
        private protected Color _colour;

        public Shape(Point location, Color colour)
        {
            Console.WriteLine("Shape Constructor");
            _location = location;
            _colour = colour;
        }

        public void Move()
        {
            _location = new Point(_location.X + 100, _location.Y + 100);
        }

        public override string ToString()
        {
            return _location.ToString();
        }
    }

    public class Circle : Shape, IComparable
    {
        double _radius;

        public Circle(double radius, Point location) : base(location, Color.Red)
        {
            Console.WriteLine("Circle Constructor");
            _radius = radius;

            Random rng = new Random();
            _colour = Color.FromArgb(rng.Next(256), rng.Next(256), rng.Next(256));
        }


        double CalcArea()
        {
            return Math.PI * _radius * _radius;
        }

        public new void Move()
        {
            base.Move();
            _location = new Point(_location.X + 500, _location.Y + 500);
        }

        public int CompareTo(object obj)
        {
            return 1;
        }
    }
}

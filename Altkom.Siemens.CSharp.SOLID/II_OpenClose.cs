using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.SOLID
{
    abstract class Shape
    {
        public abstract int Area();
    }

    class Square : Shape
    {
        public int A { get; set; }

        public override int Area()
        {
            return A * A;
        }
    }

    class Rectangle : Shape
    {
        public int A { get; set; }
        public int B { get; set; }

        public override int Area()
        {
            return A * B;
        }
    }

    class ShapeCalculator
    {
        int Area(Shape shape)
        {
            return shape.Area();
        }
    }
}

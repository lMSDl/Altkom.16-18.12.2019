using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.SOLID
{
    abstract class Shape
    {
    }

    class Square : Shape
    {
        public int A { get; set; }
    }

    class Rectangle : Shape
    {
        public int A { get; set; }
        public int B { get; set; }
    }

    class ShapeCalculator
    {
        int Area(Shape shape)
        {
            switch (shape)
            {
                case Square square:
                    return square.A * square.A;
                case Rectangle rectangle:
                    return rectangle.A * rectangle.B;
                default:
                    return 0;
            }
        }
    }
}

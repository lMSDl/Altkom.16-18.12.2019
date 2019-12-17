using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.SOLID
{
    abstract class Vehicle
    {
        public string Name { get; set; }
        public abstract void Fly();
    }

    class Car : Vehicle
    {
        public override void Fly()
        {
            throw new NotImplementedException();
        }
    }

    class Airplane : Vehicle
    {
        public override void Fly()
        {
            Console.WriteLine("I am flying!");
        }
    }
}

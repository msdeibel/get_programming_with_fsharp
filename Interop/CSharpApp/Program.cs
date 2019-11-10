using System;
using Model;

namespace CSharpApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car(6, "GMC", Tuple.Create(1.5, 3.5));

            var wheels = car.Wheels;

            var width = car.Dimensions.Item1;

            var v1000 = Vehicle.NewMotorbike("Versys", 1000.0);

            var name = (v1000 as Vehicle.Motorbike).Name;
        }
    }
}

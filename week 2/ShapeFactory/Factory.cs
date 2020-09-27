using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shapes;

namespace ShapeFactory
{
    enum shapename
    {
        rectangle=0,
        square,
        triangle
    }
    class Factory
    {
        Random random = new Random();

        public shape produce(shapename a)
        {
            switch (a)
            {
                case shapename.rectangle:
                    return new Rectangle((random.Next(100)+1)*0.1, (random.Next(100) + 1) * 0.1);
                case shapename.square:
                    return new Square((random.Next(100) + 1) * 0.1);
                case shapename.triangle:
                    Triangle triangle = new Triangle((random.Next(100) + 1) * 0.1, (random.Next(100) + 1) * 0.1, (random.Next(100) + 1) * 0.1);
                    while (!triangle.legal())
                    {
                        Console.WriteLine("but the triangle above is illegal!\n");
                        triangle = new Triangle((random.Next(100) + 1) * 0.1, (random.Next(100) + 1) * 0.1, (random.Next(100) + 1) * 0.1);
                    }
                    return triangle;
                default:
                    throw new Exception();
            }
        }
    }
}

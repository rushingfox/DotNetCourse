using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* question introduction
第二次作业：
1. 编写面向对象程序实现长方形、正方形、三角形等形状的类。每个形状类都能计算面积、判断形状是否合法。 请尝试合理使用接口/抽象类、属性来实现。
2. 随机创建10个形状对象，计算这些对象的面积之和。 尝试使用简单工厂设计模式来创建对象。 参考资料：设计模式教程（Java版）https://gof.quanke.name/
3. 为本讲示例中的泛型链表类添加ForEach(Action<T> action)方法。类似于List<T> 类的ForEach方法，通过调用这个方法打印链表元素，求最大值、最小值和求和（使用lambda表达式实现）。
4. 使用事件机制，模拟实现一个闹钟功能。闹钟可以有嘀嗒（Tick）事件和响铃（Alarm）两个事件。在闹钟走时时或者响铃时，在控制台显示提示信息。
*/
namespace shapes
{
    public interface shape
    {
        string shapename { get; }
        bool legal();
        double area_calculating();
    }
    class Rectangle : shape
    {
        public double length
        {
            set;
            get;
        }
        public double width
        {
            set;
            get;
        }
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
        public string shapename
        {
            get { return "rectangle"; }
        }

        public double area_calculating()
        {
            return length * width;
        }

        public bool legal()
        {
            if (this.length > 0 && this.width > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Square : shape
    {
        public double side_length
        {
            get;
            set;
        }
        public Square(double side_length)
        {
            this.side_length = side_length;
        }
        public string shapename
        {
            get
            {
                return "square";
            }
        }

        public double area_calculating()
        {
            return side_length * side_length;
        }

        public bool legal()
        {
            if (side_length>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Triangle : shape
    {
        public double[] sides  //property can be array, but it need to be initialized in main function or constructor function
        {
            get;
            set;
        }
        public Triangle(double side0,double side1,double side2)
        {
            sides = new double[3];
            sides[0] = side0;
            sides[1] = side1;
            sides[2] = side2;
        }
        public string shapename
        {
            get
            {
                return "triangle";
            }
        }

        public double area_calculating()
        {
            return 0.25*Math.Sqrt((sides[0] + sides[1] + sides[2])*(sides[0] + sides[1] - sides[2])*(sides[0] + sides[2] - sides[1])*(sides[1] + sides[2] - sides[0]));
        }

        public bool legal()
        {
            if ((sides[0]+sides[1]>sides[2])&& (sides[1] + sides[2] > sides[0])&& (sides[0] + sides[2] > sides[1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
L1:         Console.WriteLine("choose the number:1 for rectangle, 2 for square and 3 for triangle");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("enter the length and width in order:");
                    Rectangle shape1 = new Rectangle(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
                    if (shape1.legal())
                    {
                        Console.WriteLine("legal"+"\n and the area is "+shape1.area_calculating());
                    }
                    else
                    {
                        Console.WriteLine("illegal"+"\n therefore, the area can not be calculated");
                    }
                    break;
                case 2:
                    Console.WriteLine("enter the side_length:");
                    Square shape2 = new Square(Convert.ToDouble(Console.ReadLine()));
                    if (shape2.legal())
                    {
                        Console.WriteLine("legal" + "\n and the area is " + shape2.area_calculating());
                    }
                    else
                    {
                        Console.WriteLine("illegal" + "\n therefore, the area can not be calculated");
                    }
                    break;
                case 3:
                    Console.WriteLine("enter the three sides in order:");
                    Triangle shape3 = new Triangle(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
                    if (shape3.legal())
                    {
                        Console.WriteLine("legal" + "\n and the area is " + shape3.area_calculating());
                    }
                    else
                    {
                        Console.WriteLine("illegal" + "\n therefore, the area can not be calculated");
                    }
                    break;
                default:
                    goto L1;
            }

            Console.ReadKey();
        }
    }
}

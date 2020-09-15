using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToeplitzMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            if (judge(enter()))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            Console.ReadKey();
        }
        static Double[,] enter()
        {
            Console.WriteLine("please enter the number of rows:");
            int r = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter the number of columns:");
            int c = Convert.ToInt32(Console.ReadLine());
            double[,] matrix = new double[r,c];
            for (int i = 0; i < r; i++)
            {
                Console.WriteLine($"please enter the row {i+1}");
                for (int j = 0; j < c; j++)
                {

                    matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
            return matrix;
        }
        static bool judge(double[,] m)
        {
            int row = m.GetLength(0);
            int column = m.GetLength(1);
            for (int i = 0; i < column-1; i++)
            {
                for (int j = 1; (i+j<column)&&(j<row) ; j++)
                {
                    if (m[0,i]!=m[j,i+j])
                    {
                        return false;
                    }
                }
            }
            for (int i = 1; i < row -1; i++)
            {
                for (int j = 1; (i+j<row)&&(j<column) ; j++)
                {
                    if (m[i,0]!=m[i+j,j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

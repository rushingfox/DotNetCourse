using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            int choice = 0;
            while (choice!=6)
            {
L:              Console.WriteLine("please enter:\n1.add order \n2.delete order \n3.change order \n4.search order \n5.show all the orders \n6.quit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        int ordernum, price;
                        string p_name, c_name;
                        Console.WriteLine("please enter the ordernum, product_name, client_name and total price:");
                        ordernum = Convert.ToInt32(Console.ReadLine());
                        p_name = Convert.ToString(Console.ReadLine());
                        c_name = Convert.ToString(Console.ReadLine());
                        price = Convert.ToInt32(Console.ReadLine());
                        orderService.AddOrder(ordernum, p_name, c_name, price);
                        break;
                    case 2:
                        Console.WriteLine("please enter the number of the order you wanna delete");
                        int d_num=Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            orderService.DeleteOrder(d_num);
                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine("throw ArgumentNullException: the number you enter is invalid!"+e);
                        }
                        break;
                    case 3:
                        try
                        {
                            Console.WriteLine("please enter the number of the order you wanna change:");
                            int choice3_num = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("which property do you want to change:\n 1:the ordernum 2:product_name 3:client_name 4:total price");
                            int choice3_p = Convert.ToInt32(Console.ReadLine());
                            int one_four = 0;
                            string two_three = "";
                            if (choice3_p == 2 || choice3_p == 3)
                            {
                                two_three = Convert.ToString(Console.ReadLine());
                            }
                            else
                            {
                                one_four = Convert.ToInt32(Console.ReadLine());
                            }
                            orderService.ChangeOrder(choice3_p, choice3_num, one_four: one_four, two_three: two_three);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("change the order unsuccessfully!"+e);
                        }
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine("which property do you wanna search by?\n 1:the ordernum 2:product_name 3:client_name 4:total price");
                            int choice4 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("what do you wanna search?");
                            string four = Console.ReadLine();
                            Console.WriteLine("the result is below:\n");
                            var result = orderService.SearchOrder(choice4, four);
                            foreach (var order in result)
                            {
                                Console.WriteLine(order);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("search error!"+e);
                        }
                        break;
                    case 5:
                        Console.WriteLine("the total list is below:\n");
                        using (var db = new dbcontext())
                        {
                            var query = db.dbOrders.Where(b => true);
                            foreach (var order in query)
                            {
                                Console.WriteLine(order);
                            }
                        }
                        break;
                    case 6:
                        Console.WriteLine("quit successfully!");
                        break;
                    default:
                        Console.WriteLine("you enter the invalid number!");
                        goto L;
                }
            }
            Console.ReadKey();
        }
    }
}
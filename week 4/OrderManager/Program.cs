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
            while (choice!=9)
            {
L:              Console.WriteLine("please enter:\n1.add order \n2.delete order \n3.change order \n4.search order \n5.import \n6.export \n7.order(default:by the order number) \n8.show all the orders \n9.quit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("do you want to add the order with the ordernumber you decided? 1Y 2N");
                        int choice1 = Convert.ToInt32(Console.ReadLine());
                        int ordernum, price;
                        string p_name, c_name;
                        if (choice1==1)
                        {
                            Console.WriteLine("please enter the ordernum, product_name, client_name and total price:");
                            ordernum = Convert.ToInt32(Console.ReadLine());
                            p_name = Convert.ToString(Console.ReadLine());
                            c_name = Convert.ToString(Console.ReadLine());
                            price = Convert.ToInt32(Console.ReadLine());
                            orderService.AddOrder(ordernum, p_name, c_name, price);
                        }
                        else if (choice1==2)
                        {
                            Console.WriteLine("please enter the product_name, client_name and total price:");
                            if (orderService.orders.Count!=0)
                            {
                                ordernum = orderService.orders[0].OrderNumber+1;
                                for (int i = 0; i < orderService.orders.Count; i++)
                                {
                                    ordernum = (orderService.orders[i].OrderNumber+1) > ordernum ? (orderService.orders[i].OrderNumber+1) : ordernum;
                                }
                            }
                            else
                            {
                                ordernum = 1;
                            }
                            p_name = Convert.ToString(Console.ReadLine());
                            c_name = Convert.ToString(Console.ReadLine());
                            price = Convert.ToInt32(Console.ReadLine());
                            orderService.AddOrder(ordernum, p_name, c_name, price);
                        }
                        else
                        {
                            Console.WriteLine("the choice you enter is invalid!");
                        }
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
                        orderService.Import();
                        break;
                    case 6:
                        orderService.Export();
                        break;
                    case 7:
                        Console.WriteLine("which do you want to order the orders by? \n 1:the ordernum  2:product_name 3:client_name 4:total price");
                        int choice7 = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            orderService.OrderTheOrders(choice7);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(""+e);
                        }
                        break;
                    case 8:
                        Console.WriteLine("the total list is below:\n");
                        foreach (var order in orderService.orders)
                        {
                            Console.WriteLine(order);
                        }
                        break;
                    case 9:
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
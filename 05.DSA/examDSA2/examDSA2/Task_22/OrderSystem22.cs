﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Task_2
{
    class OrderSystem
    {
        public static Dictionary<string, OrderedBag<Order>> ordersByConsumer = new Dictionary<string, OrderedBag<Order>>();
        //public static OrderedDictionary<decimal, OrderedBag<Order>> ordersByPrice = new OrderedDictionary<decimal, OrderedBag<Order>>();
        public static HashSet<Order> ordersByPrice = new HashSet<Order>();
        public static StringBuilder resultBuilder = new StringBuilder();

        static void Main()
        {
            try
            {

           
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string[] commandParams = command.Split();
                int lengthCommand = commandParams[0].Length;
                string[] restParams = command.Substring(lengthCommand).Split(new char[] { ';' });
                switch (commandParams[0])
                {
                    case "AddOrder":
                        AddOrder(restParams);
                        break;
                    case "DeleteOrders":
                        DeleteOrders(restParams);
                        break;
                    case "FindOrdersByPriceRange":
                        FindOrdersByPriceRange(restParams);
                        break;
                    case "FindOrdersByConsumer":
                        FindOrdersByConsumer(restParams);
                        break;
                }
            }

            Console.WriteLine(resultBuilder.ToString());
        }
             
            catch (Exception x)
            {

                Console.WriteLine(x.Message);
            }

}

        private static void AddOrder(string[] restParams)
        {
            Order order = new Order(restParams[0].Substring(1), decimal.Parse(restParams[1]), restParams[2]);
            string consumer = order.Consumer;
            decimal price = order.Price;

            if (!ordersByConsumer.ContainsKey(consumer))
            {
                ordersByConsumer.Add(consumer, new OrderedBag<Order>());
            }
            ordersByConsumer[consumer].Add(order);

            ordersByPrice.Add(order);
            resultBuilder.AppendLine("Order added");
        }

        private static void DeleteOrders(string[] restParams)
        {
            string consumer = restParams[0].Substring(1);
            if (ordersByConsumer.ContainsKey(consumer))
            {
                int numOfOrders = ordersByConsumer[consumer].Count;
                ordersByConsumer.Remove(consumer);
                ordersByPrice.RemoveWhere(x => x.Consumer == consumer);
                //ordersByPrice.RemoveAll(x => x.Consumer == consumer);
                resultBuilder.AppendLine(string.Format("{0} orders deleted", numOfOrders));
            }
            else
            {
                resultBuilder.AppendLine(string.Format("No orders found"));
            }
        }

        private static void FindOrdersByPriceRange(string[] restParams)
        {
            int start = int.Parse(restParams[0].Substring(1));
            int end = int.Parse(restParams[1]);
            var output = ordersByPrice
                .Where(order => order.Price >= start && order.Price <= end)
                .OrderBy(order => order.Name)
                .Select(order => order)
                .ToList();
            if (output.Count != 0)
            {
                foreach (var order in output)
                {
                    string result = string.Format("{0}", order);
                    resultBuilder.AppendLine(result);
                }
            }
            else
            {
                resultBuilder.AppendLine(string.Format("No orders found"));
            }
        }

        private static void FindOrdersByConsumer(string[] restParams)
        {
            string consumer = restParams[0].Substring(1);
            if (ordersByConsumer.ContainsKey(consumer))
            {
                foreach (var order in ordersByConsumer[consumer])
                {
                    resultBuilder.AppendLine(string.Format("{0}", order));
                }
                //var output = ordersByConsumer[consumer]
                //.OrderBy(order => order.Name)
                //.Select(order => order)
                //.ToList();

                //    foreach (var order in output)
                //    {
                //        string result = string.Format("{0}", order);
                //        resultBuilder.AppendLine(result);
                //    }
            }
            else
            {
                resultBuilder.AppendLine(string.Format("No orders found"));
            }
        }

    }

    public class Order : IComparable<Order>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Consumer { get; set; }

        public Order(string name, decimal price, string consumer)
        {
            this.Name = name;
            this.Price = price;
            this.Consumer = consumer;
        }

        public int CompareTo(Order other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Price.CompareTo(other.Price);
                if (result == 0)
                {
                    result = this.Consumer.CompareTo(other.Consumer);
                }
            }
            return result;
        }

        public override string ToString()
        {
            return "{" + string.Format("{0};{1};{2:0.00}", this.Name, this.Consumer, this.Price) + "}";
        }
    }
}
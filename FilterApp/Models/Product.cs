using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterApp.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string TypeName { get; set; }

        public void Print()
        {
            Console.WriteLine("------------------");
            Console.WriteLine($"Name: { Name }");
            Console.WriteLine($"Price: { Price }");
            Console.WriteLine($"Type Name: {TypeName}");
            Console.WriteLine("------------------");
        }
    }

}

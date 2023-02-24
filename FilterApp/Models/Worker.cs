using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterApp.Models
{
    [Serializable]
    public class Worker
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int Experience { get; set; }

        public void Print()
        {
            Console.WriteLine("---------------");
            Console.WriteLine($"Name: { Name }" );
            Console.WriteLine($"Salary: { Salary }");
            Console.WriteLine($"Experience: { Experience }");
            Console.WriteLine("---------------");
        }
    }

}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterApp.Models
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public List<int> Grades { get; set; }
        public double AvarageGrade()
        {
            int sum = 0;
            foreach (var grade in Grades)
                sum += grade;
            return sum / Grades.Count;
        }
        public void Print()
        {
            Console.WriteLine("------------------");
            Console.WriteLine($"Name: { Name }");
            if(Grades.Count > 0)
                Console.Write(Grades[0].ToString());
            foreach (var grade in Grades)
                Console.Write(", " + grade.ToString());
            Console.WriteLine();
            Console.WriteLine("------------------");
        }
    }
}

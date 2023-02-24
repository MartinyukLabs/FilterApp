using FilterApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FilterApp
{
    internal class Program
    {
        static string studentPath = "students.json";
        public delegate void FilterStudents(List<Student> students);
        static string workersPath = "workers.json";
        public delegate void SortWorkers(List<Worker> workers);
        static string productsPath = "products.json";
        public delegate void GroupProduct(List<Product> products);
        public delegate int GetStringLength(string s);
        public static void Main()
        {
            Fourth();
        }
        public static void First()
        {
            FillStudent();
            Console.WriteLine("1 - filter by name, 2 - filter by avarage grade");
            Console.Write("Choose mode: ");
            string mode = Console.ReadLine();
            FilterStudents filter = mode == "1" ?
                (students) =>
                {
                    Console.Write("Input name: ");
                    string name = Console.ReadLine();
                    List<Student> results = new List<Student>();
                    foreach (Student student in students)
                        if (student.Name.Contains(name))
                            results.Add(student);
                    if (results.Count > 0)
                        foreach (Student student in results)
                            student.Print();
                    else
                        Console.WriteLine("No results :(");
                }
            :
                (students) =>
                {
                    Console.Write("Input min avarage grade: ");
                    double avGrade = Convert.ToDouble(Console.ReadLine());
                    List<Student> results = new List<Student>();
                    foreach (Student student in students)
                        if (student.AvarageGrade() >= avGrade)
                            results.Add(student);
                    if (results.Count > 0)
                        foreach (Student student in results)
                            student.Print();
                    else
                        Console.WriteLine("No results :(");
                };
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(studentPath));
            filter(students);
        }
        static void FillStudent()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { Name = "Alex Klar", Grades = new List<int>() { 5, 4, 3, 5 } });
            students.Add(new Student() { Name = "Mary Co", Grades = new List<int>() { 3, 3, 3, 5 } });
            students.Add(new Student() { Name = "Tom Mayer", Grades = new List<int>() { 4, 2, 2, 2 } });
            File.WriteAllText(studentPath, JsonConvert.SerializeObject(students));
        }
        public static void Second()
        {
            FillWorkers();
            Console.WriteLine("1 - sort by salary, 2 - sort by experience");
            Console.Write("Choose mode: ");
            string mode = Console.ReadLine();
            SortWorkers sort = mode == "1" ?
                (workers) =>
                {
                    workers = workers.OrderBy(x => x.Salary).ToList();
                    foreach (Worker worker in workers)
                        worker.Print();
                }
            :
                (workers) =>
                {
                    workers = workers.OrderBy(x => x.Experience).ToList();
                    foreach (Worker worker in workers)
                        worker.Print();
                };
            List<Worker> workers = JsonConvert.DeserializeObject<List<Worker>>(File.ReadAllText(workersPath));
            sort(workers);
        }
        static void FillWorkers()
        {
            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker() { Name = "Alex Klar", Salary = 20000, Experience = 10 });
            workers.Add(new Worker() { Name = "Tom Mayer", Salary = 5000000, Experience = 0 });
            workers.Add(new Worker() { Name = "Mary Co", Salary = 2000, Experience = 1 });
            File.WriteAllText(workersPath, JsonConvert.SerializeObject(workers));
        }
        public static void Third()
        {
            FillProducts();
            Console.WriteLine("1 - sort by type, 2 - sort by price");
            Console.Write("Choose mode: ");
            string mode = Console.ReadLine();
            GroupProduct group = mode == "1" ?
                (products) =>
                {
                    var groups = products.GroupBy(p => p.TypeName);
                    foreach(var group in groups)
                    {
                        global::System.Console.WriteLine("=====================");
                        Console.WriteLine($"Product type: { group.Key }");
                        global::System.Console.WriteLine("=====================");
                        foreach (Product product in group)
                            product.Print();
                    }
                }
            :
                (products) =>
                {
                    var groups = products.GroupBy(p => p.Price);
                    foreach (var group in groups)
                    {
                        global::System.Console.WriteLine("=====================");
                        Console.WriteLine($"Product price: {group.Key}");
                        global::System.Console.WriteLine("=====================");
                        foreach (Product product in group)
                            product.Print();
                    }
                };
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(productsPath));
            group(products);
        }
        static void FillProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product() { Name = "Potato", Price = 100, TypeName = "Vegetables" });
            products.Add(new Product() { Name = "Coca-Cola", Price = 150, TypeName = "Drinks" });
            products.Add(new Product() { Name = "Cucumber", Price = 120, TypeName = "Vegetables" });
            File.WriteAllText(productsPath, JsonConvert.SerializeObject(products));
        }
        public static void Fourth()
        {
            List<string> fruits = new List<string>() { "Apple", "Banana", "Cherry", "Orange" };
            GetStringLength getLength = new GetStringLength(s => s.Length);
            foreach (string fruit in fruits)
                Console.WriteLine($"Length of word \"{ fruit }\" is { getLength(fruit) }");
        }
    }
}

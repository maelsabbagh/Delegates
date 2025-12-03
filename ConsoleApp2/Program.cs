using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;

namespace ConsoleApp2
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public double TotalSales { get; set; }

        public void printEmp()
        {
            Console.WriteLine($"Employee with id={Id},Name={Name},Gender={Gender},total sales={TotalSales}");
        }
    }

    class Report
    {
        public delegate bool IsPass (Employee emp);
        public void processEmployee(Employee[] employees,string title, IsPass isPass)
        {
            Console.WriteLine($"{title}:\n");
            

            foreach (var emp in employees)
            {
                if(isPass(emp))
                {
                    emp.printEmp();
                }
            }

            Console.WriteLine("****************************");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var emps = new Employee[]
            {
                new Employee{Id=1,Name="Mohamed",Gender="M",TotalSales=60000},
                new Employee{Id=2,Name="Ahmed",Gender="M",TotalSales=70000},
                new Employee{Id=3,Name="Mahmoud",Gender="M",TotalSales=20000},
                new Employee{Id=4,Name="Aya",Gender="F",TotalSales=80000},
                new Employee{Id=5,Name="Yomna",Gender="F",TotalSales=90000},
                new Employee{Id=6,Name="Nouran",Gender="F",TotalSales=100000},
                new Employee{Id=7,Name="Karim",Gender="M",TotalSales=5000},

            };

            Report report = new Report();
            report.processEmployee(emps, "employees with total sales greater than or equal 60,000", (e) => e.TotalSales >= 60000);
            report.processEmployee(emps, "employees with total sales less than than 60,000", (e) => e.TotalSales < 60000);
            report.processEmployee(emps, "employees with total sales greater than 90,000", (e) => e.TotalSales > 90000);

        }
    }
}

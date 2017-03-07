using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class Employee
    {
        public string Name;
        public int Salary;

        public Employee(string name,int salary)
        {
            Name = name;
            Salary = salary;
        }
    }
    class EmployeeComparer:IComparer<Employee>
    {
        public int Compare(Employee x,Employee y)
        {
            if (x.Salary > y.Salary)
                return 1;
            if (x.Salary == y.Salary)
                return 0;
            else
                return -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>(10);
            empList.Add(new Employee("Jone Doe", 50000));
            empList.Add(new Employee("Jane Smith", 60000));
            empList.Add(new Employee("Nick Slick", 55000));
            empList.Add(new Employee("Milderd Mintz", 70000));

            Console.WriteLine("Employee capacity is {0}", empList.Capacity);
            Console.WriteLine("Employee count is {0}", empList.Count);

            if(empList.Exists(HighPay))
            {
                Console.WriteLine("\nHighly Paid Employee Found\n");
            }
            Employee e = empList.Find(x => x.Name.StartsWith("J"));
            if(e!=null)
            {
                Console.WriteLine("Found employee whose name starts with j: {0}", e.Name);
            }

            empList.ForEach(TotalSalaries);
            Console.WriteLine("Total payroll is {0}\n", Total);

            EmployeeComparer ec = new EmployeeComparer();
            empList.Sort(ec);
            foreach (Employee emp in empList)
            {
                Console.WriteLine("Salary for {0} is {1}", emp.Name, emp.Salary);
            }

            Console.WriteLine("\nPress Enter to continue");
            Console.ReadLine();
        }
        static int Total = 0;
        static void TotalSalaries(Employee e)
        {
            Total += e.Salary;
        }
        static Boolean HighPay(Employee emp)
        {
            return emp.Salary >= 65000;
        }
    }
}

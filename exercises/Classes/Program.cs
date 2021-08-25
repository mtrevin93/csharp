using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of a company. Name it whatever you like.
            Company SeeSharper = new Company("SeeSharper", DateTime.Parse("5/1/2008"));
            // Create three employees
            Employee JaneDoe = new Employee("Jane","Doe","HR Manager",DateTime.Parse("5/30/2008"));
            Employee HowardSchultz = new Employee("Howard","Schultz","Barista",DateTime.Parse("1/1/2009"));
            Employee SteveJobs = new Employee("Steve","Jobs","Lead Turtleneck-Wearer,",DateTime.Parse("3/1/2015"));
            // Assign the employees to the company
            SeeSharper.Employees.Add(JaneDoe);
            SeeSharper.Employees.Add(HowardSchultz);
            SeeSharper.Employees.Add(SteveJobs);
            /*
                Iterate the company's employee list and generate the
                simple report shown above
            */
            SeeSharper.ListEmployees();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Classes
{
    public class Company
    {
        // Some readonly properties (let's talk about gets, baby)
        public string Name { get; }
        public DateTime CreatedOn { get; }

        // Create a public property for holding a list of current employees
        public List<Employee> Employees = new List<Employee>();
        public Company(string name, DateTime createdOn){
            Name = name;
            CreatedOn = createdOn;
        }
        /*
            Create a constructor method that accepts two arguments:
                1. The name of the company
                2. The date it was created

            The constructor will set the value of the public properties

        */
        public void ListEmployees(){
            foreach (Employee employee in this.Employees){
                Console.WriteLine($"{employee.FirstName} {employee.LastName} works for {this.Name} as {employee.Title} since {employee.StartDate}");
            }
        }
    }
};

using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace DataGridExample {
    public enum AccessLevel {
        Admin,
        User
    }

    public class Employee {
        string name;
        string resourceName;

        public string Name {
            get { return name; }
            set {
                name = value;
                if (Photo == null) {
                    resourceName = "DataGridExample.Images." + value.Replace(" ", "_") + ".jpg";
                    if (!String.IsNullOrEmpty(resourceName))
                        Photo = ImageSource.FromResource(resourceName);
                }
            }
        }

        public Employee(string name) {
            this.Name = name;
        }

        public ImageSource Photo { get; set; }
        public DateTime HireDate { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public AccessLevel Access { get; set; }
    }

    public class EmployeeData {
        void GenerateEmployees() {
            ObservableCollection<Employee> result = new ObservableCollection<Employee>();
            result.Add(
                new Employee("Nancy Davolio") {
                    HireDate = new DateTime(2005, 5, 1),
                    Position = "Sales Representative",
                    Access = AccessLevel.User
                }
            );
            result.Add(
                new Employee("Andrew Fuller") {
                    HireDate = new DateTime(1992, 8, 14),
                    Position = "Vice President, Sales",
                    Access = AccessLevel.Admin
                }
            );
            result.Add(
                new Employee("Janet Leverling") {
                    HireDate = new DateTime(2002, 4, 1),
                    Position = "Sales Representative",
                    Access = AccessLevel.User
                }
            );
            result.Add(
                new Employee("Margaret Peacock") {
                    HireDate = new DateTime(1993, 5, 3),
                    Position = "Sales Representative",
                    Access = AccessLevel.User
                }
            );
            result.Add(
                new Employee("Steven Buchanan") {
                    HireDate = new DateTime(1993, 10, 17),
                    Position = "Sales Manager",
                    Access = AccessLevel.User
                }
            );
            result.Add(
                new Employee("Michael Suyama") {
                    HireDate = new DateTime(1999, 10, 17),
                    Position = "Sales Representative",
                    Access = AccessLevel.User
                }
            );
            result.Add(
                new Employee("Robert King") {
                    HireDate = new DateTime(1994, 1, 2),
                    Position = "Sales Representative",
                    Access = AccessLevel.User
                }
            );
            result.Add(
                new Employee("Laura Callahan") {
                    HireDate = new DateTime(2004, 3, 5),
                    Position = "Inside Sales Coordinator",
                    Access = AccessLevel.User
                }
            );
            result.Add(
                new Employee("Anne Dodsworth") {
                    HireDate = new DateTime(2004, 11, 15),
                    Position = "Sales Representative",
                    Access = AccessLevel.User
                }
            );
            Employees = result;
        }

        public ObservableCollection<Employee> Employees { get; private set; }

        public EmployeeData() {
            GenerateEmployees();
        }
    }
}

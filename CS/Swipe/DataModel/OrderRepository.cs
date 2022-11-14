using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Swipe {
    public abstract class OrderRepository {
        readonly BindingList<Order> orders;
        public OrderRepository() {
            this.orders = new BindingList<Order>();
        }
        public BindingList<Order> Orders {
            get { return orders; }
        }
    }

    public class TestOrderRepository : OrderRepository {
        const int orderCount = 100;
        readonly List<Product> products;
        readonly List<Customer> customers;
        readonly Random random;

        public TestOrderRepository() : base() {
            this.random = new Random((int)DateTime.Now.Ticks);
            this.products = new List<Product>();
            this.customers = new List<Customer>();

            GenerateProducts();
            GenerateCustomers();

            for (int i = 0; i < orderCount; i++)
                Orders.Add(GenerateOrder(i));
        }

        Order GenerateOrder(int number) {
            Order order = new Order(new DateTime(2019, 1, 1).AddDays(random.Next(0, 60)),
                number % 3 == 0, RandomItem<Product>(products), random.Next(1, 100), RandomItem<Customer>(customers));
            return order;
        }

        T RandomItem<T>(IList<T> list) {
            int index = (int)(random.NextDouble() * 0.99 * (list.Count));
            return list[index];
        }

        void GenerateProducts() {
            products.Add(new Product("Tofu", 50));
            products.Add(new Product("Chocolade", 34));
            products.Add(new Product("Ikura", 70));
            products.Add(new Product("Chai", 3));
            products.Add(new Product("Boston Crab Meat", 36));
            products.Add(new Product("Ravioli Angelo", 18));
            products.Add(new Product("Ipon Coffee", 10));
            products.Add(new Product("Questo Cabrales", 25));
        }

        void GenerateCustomers() {
            customers.Add(
                new Customer("Nancy Davolio") {
                    BirthDate = new DateTime(1978, 12, 8),
                    Address = "98122, 507 - 20th Ave. E. Apt. 2A, Seattle WA, USA",
                    Phone = "(206) 555-9857",
                }
            );
            customers.Add(
                new Customer("Andrew Fuller") {
                    BirthDate = new DateTime(1965, 2, 19),
                    Address = "98401, 908 W. Capital Way, Tacoma WA, USA",
                    Phone = "(206) 555-9482",                    
                }
            );
            customers.Add(
                new Customer("Janet Leverling") {
                    BirthDate = new DateTime(1985, 8, 30),
                    Address = "98033, 722 Moss Bay Blvd., Kirkland WA, USA",
                    Phone = "(206) 555-3412",
                }
            );
            customers.Add(
                new Customer("Margaret Peacock") {
                    BirthDate = new DateTime(1973, 9, 19),
                    Address = "98052, 4110 Old Redmond Rd., Redmond WA, USA",
                    Phone = "(206) 555-8122",
                }
            );
            customers.Add(
                new Customer("Steven Buchanan") {
                    BirthDate = new DateTime(1955, 3, 4),
                    Address = "SW1 8JR, 14 Garrett Hill, London, UK",
                    Phone = "(71) 555-4848",
                }
            );
            customers.Add(
                new Customer("Michael Suyama") {
                    BirthDate = new DateTime(1981, 7, 2),
                    Address = "EC2 7JR, Coventry House Miner Rd., London, UK",
                    Phone = "(71) 555-7773",
                }
            );
            customers.Add(
                new Customer("Robert King") {
                    BirthDate = new DateTime(1960, 5, 29),
                    Address = "RG1 9SP, Edgeham Hollow Winchester Way, London, UK",
                    Phone = "(71) 555-5598",
                }
            );
            customers.Add(
                new Customer("Laura Callahan") {
                    BirthDate = new DateTime(1985, 1, 9),
                    Address = "98105, 4726 - 11th Ave. N.E., Seattle WA, USA",
                    Phone = "(206) 555-1189",
                }
            );
            customers.Add(
                new Customer("Anne Dodsworth") {
                    BirthDate = new DateTime(1980, 1, 27),
                    Address = "WG2 7LT, 7 Houndstooth Rd., London, UK",
                    Phone = "(71) 555-4444",
                }
            );
        }
    }
}

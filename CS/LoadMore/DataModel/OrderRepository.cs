using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LoadMore {

    public class OrderData {
        readonly List<Product> products;
        const int orderCount = 50;
        readonly Random random;
        public ObservableCollection<Order> Orders { get; set; }

        public OrderData() {
            random = new Random((int)DateTime.Now.Ticks);
            products = new List<Product>();
            GenerateProducts();
            Orders = new ObservableCollection<Order>();
            for (int i = 0; i < orderCount; i++)
                Orders.Add(GenerateOrder());
        }

        public void LoadMoreOrders() {
            for (int i = 0; i < 10; i++)
                Orders.Add(GenerateOrder());
        }

        Order GenerateOrder() {
            Order order = new Order(new DateTime(2020, 1, 1).AddDays(random.Next(0, 60)), 
                            RandomItem<Product>(products), random.Next(1, 100));
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
    }
}

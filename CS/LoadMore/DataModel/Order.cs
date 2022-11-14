using System;

namespace LoadMore {
    public class Order {
        DateTime date;
        Product product;
        int quantity;

        public Order() {
            this.date = DateTime.Today;
            this.product = new Product("", 0);
            this.Quantity = 0;
        }

        public Order(DateTime date, Product product, int quantity) {
            this.date = date;
            this.product = product;
            this.quantity = quantity;
        }

        public DateTime Date {
            get { return date; }
            set { date = value; }
        }

        public Product Product {
            get { return product; }
            set { product = value; }
        }

        public int Quantity {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}

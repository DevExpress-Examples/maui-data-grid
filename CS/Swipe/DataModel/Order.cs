using System;

namespace Swipe {
    public class Order : ModelObject {
        DateTime date;
        bool shipped;
        Product product;
        int quantity;
        Customer customer;

        public Order() {
            this.date = DateTime.Today;
            this.shipped = false;
            this.product = new Product("", 0);
            this.Quantity = 0;
            this.customer = new Customer("");
        }

        public Order(DateTime date, bool shipped, Product product, int quantity, Customer customer) {
            this.date = date;
            this.shipped = shipped;
            this.product = product;
            this.quantity = quantity;
            this.customer = customer;
        }

        public DateTime Date {
            get { return date; }
            set {
                if (date != value) {
                    date = value;
                    RaisePropertyChanged("Date");
                }
            }
        }

        public bool Shipped {
            get { return shipped; }
            set {
                if (shipped != value) {
                    shipped = value;
                    RaisePropertyChanged("Shipped");
                }
            }
        }

        public Product Product {
            get { return product; }
            set {
                if (product != value) {
                    product = value;
                    RaisePropertyChanged("Product");
                }
            }
        }

        public int Quantity {
            get { return quantity; }
            set {
                if (quantity != value) {
                    quantity = value;
                    RaisePropertyChanged("Quantity");
                }
            }
        }

        public Customer Customer {
            get { return customer; }
            set {
                if (customer != value) {
                    customer = value;
                    RaisePropertyChanged("Customer");
                }
            }
        }
    }
}

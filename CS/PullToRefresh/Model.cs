using System.Collections.ObjectModel;

namespace PullToRefresh {
    public class Product {
        string name;
        string resourceName;

        public string Name {
            get { return name; }
            set {
                name = value;
                if (Photo == null) {
                    resourceName = value.ToLower() + ".png";
                    if (!String.IsNullOrEmpty(resourceName))
                        Photo = ImageSource.FromResource(resourceName);
                }
            }
        }
        public Product(string name) {
            this.Name = name;
        }
        public ImageSource Photo { get; set; }
        public string Description { get; set; }
    }

    public class ProductData {
        readonly List<Product> products;
        public ObservableCollection<Product> Products { get; set; }

        public ProductData() : base() {
            this.products = new List<Product>();

            GenerateAllProducts();

            int index = new Random().Next(0, 5);
            Products = GenerateAvailableProducts(index);
        }
        ObservableCollection<Product> GenerateAvailableProducts(int number) {
            ObservableCollection<Product> availableProducts = new ObservableCollection<Product>();
            for (int i = 0; i < 4; i++)
                availableProducts.Add(products[number + i]);
            return availableProducts;
        }

        public void RefreshProducts() {
            int index = new Random().Next(0, 5);
            Products = GenerateAvailableProducts(index);
        }

        void GenerateAllProducts() {
            products.Add(new Product("Beverages") { Description = "Soft drinks, coffees, teas, beers, and ales" });
            products.Add(new Product("Condiments") { Description = "Sweet and savory sauces, relishes, spreads, and seasonings" });
            products.Add(new Product("Confections") { Description = "Desserts, candies, and sweet breads" });
            products.Add(new Product("DairyProducts") { Description = "Cheeses" });
            products.Add(new Product("Grains") { Description = "Breads, crackers, pasta, and cereal" });
            products.Add(new Product("MeatPoultry") { Description = "Prepared meats" });
            products.Add(new Product("Produce") { Description = "Dried fruit and bean curd" });
            products.Add(new Product("Seafood") { Description = "Seaweed and fish" });
        }
    }
}

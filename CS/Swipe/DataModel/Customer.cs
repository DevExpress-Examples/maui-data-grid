
namespace Swipe {
    public class Customer : ModelObject {
        string name;
        string resourceName;

        public string Name {
            get { return name; }
            set {
                name = value;
                if (Photo == null) {
                    resourceName = value.Replace(" ", "_").ToLower() + ".jpg";
                    if (!String.IsNullOrEmpty(resourceName))
                        Photo = ImageSource.FromFile(resourceName);
                }
            }
        }

        public Customer(string name) {
            this.Name = name;
        }

        public ImageSource Photo { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}

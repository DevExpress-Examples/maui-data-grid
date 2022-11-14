
namespace Swipe {
    public class Customer : ModelObject {
        string name;

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public Customer(string name) {
            this.Name = name;
        }
                                              
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}

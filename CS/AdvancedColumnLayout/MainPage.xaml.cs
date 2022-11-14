
namespace AdvancedColumnLayout {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            BindingContext = new EmployeesRepository();
        }
    }
}
using DevExpress.Maui.DataGrid;

namespace Swipe {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private void Swipe_ShowCustomerInfo(object sender, SwipeItemTapEventArgs e) {
            var customer = (e.Item as Order).Customer;
            string customerName = customer.Name;
            string customerPhone = customer.Phone;
            DisplayAlert("Customer", "Name: " + customerName + "\n" + "Phone: " + customerPhone, "OK");
        }
        private void Swipe_Delete(object sender, SwipeItemTapEventArgs e) {
            grid.DeleteRow(e.RowHandle);
        }
    }
}
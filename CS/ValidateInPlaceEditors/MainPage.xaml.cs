using DevExpress.Maui.DataGrid;

namespace ValidateInPlaceEditors {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private void Grid_ValidateCell(object sender, ValidateCellEventArgs e) {
            if (e.FieldName == "Quantity" && (int)e.NewValue <= 0)
                e.ErrorContent = "The value must be positive.";
        }

        private void Grid_ValidationError(object sender, ValidationErrorEventArgs e) {
            DisplayAlert("Input Error", e.ErrorContent, "OK");
        }
    }
}
using DevExpress.Maui.DataGrid;

namespace ValidateFormEvent {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private void Grid_Tap(object sender, DataGridGestureEventArgs e) {
            if (e.Item != null) {
                var editForm = new EditFormPage(grid, grid.GetItem(e.RowHandle));
                editForm.ValidateForm += EditForm_ValidateForm;
                Navigation.PushAsync(editForm);
            }
        }

        private void EditForm_ValidateForm(object sender, EditFormValidationEventArgs e) {
            if ((decimal)e.Values["Quantity"] <= 0) {
                e.Errors.Add("Quantity", "The value must be positive.");
            }
            if ((DateTime)e.Values["Date"] > DateTime.Now.Date)
                e.Errors.Add("Date", "The date value cannot be in the future.");
        }
    }
}
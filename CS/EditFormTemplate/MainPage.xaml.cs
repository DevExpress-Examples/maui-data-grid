using DevExpress.Maui.DataGrid;

namespace EditFormTemplate {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private void DataGridView_DoubleTap(object sender, DataGridGestureEventArgs e) {
            if (e.Item != null) {
                var editForm = new EditFormPage(grid, grid.GetItem(e.RowHandle),
                                (DataTemplate)Resources["CustomEditFormContent"]);
                Navigation.PushAsync(editForm);
            }
        }
    }
}
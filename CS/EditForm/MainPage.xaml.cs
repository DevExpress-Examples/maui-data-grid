using DevExpress.Maui.DataGrid;

namespace EditForm {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private void Grid_Tap(object sender, DataGridGestureEventArgs e) {
            if (e.Item != null) {
                var editForm = new EditFormPage(grid, grid.GetItem(e.RowHandle));
                Navigation.PushAsync(editForm);
            }
        }
    }
}
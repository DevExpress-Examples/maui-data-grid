namespace ColumnChooserExample {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private void ShowColumnChooserClick(object sender, EventArgs e) {
            columnChooserPopup.IsOpen = true;
        }
    }
}
using GridExport.Models;

namespace GridExport {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        public void ExportButton_Clicked(object sender, EventArgs e) {
            this.bottomSheet.Show();
        }
    }
}
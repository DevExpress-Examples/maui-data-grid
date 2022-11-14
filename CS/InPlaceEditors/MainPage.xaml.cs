namespace InPlaceEditors {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        async void OnOpenWebButtonClicked(System.Object sender, System.EventArgs e) {
            await Browser.OpenAsync("https://www.devexpress.com/maui/");
        }
    }
}
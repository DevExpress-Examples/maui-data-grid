using DevExpress.Maui.Controls;
using DevExpress.Maui.DataGrid;
using DevExpress.Maui.Editors;
using DataGridSearchBar.ViewModels;
using System.Globalization;
using static DataGridSearchBar.App;

namespace DataGridSearchBar;

public partial class MainPage : ContentPage {
    public MainPage() {
        InitializeComponent();
    }

    private void SearchTextChanged(object sender, EventArgs e) {
        string searchText = ((TextEdit)sender).Text;
        dataGrid.FilterString = $"Contains([FirstName], '{searchText}') or Contains([LastName], '{searchText}')";
    }
}
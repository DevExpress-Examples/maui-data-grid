using GridDatafromSQLite.Model;
using SQLite;

namespace GridDatafromSQLite;

public partial class MainPage : ContentPage {
    public MainPage() {
        InitializeComponent();
        LoadData();
    }
    void LoadData() {
        var app = Application.Current as GridDatafromSQLite.App;
        var conn = new SQLiteConnection(app.targetFile, SQLite.SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.ProtectionNone | SQLite.SQLiteOpenFlags.SharedCache);
        conn.CreateTable<Customers>();
        dataGrid.ItemsSource = conn.Table<Customers>().ToList();
    }
}
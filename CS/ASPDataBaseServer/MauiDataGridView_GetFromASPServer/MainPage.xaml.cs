using System.Text.Json;
using MauiDataGridView_GetFromASPServer.Model;

namespace MauiDataGridView_GetFromASPServer;

public partial class MainPage : ContentPage
{
    public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7208" : "https://localhost:7208";
    public MainPage()
    {
        InitializeComponent();
        LoadDataAsync();
    }

    async void LoadDataAsync() {
        datagrid.ItemsSource = await GetCustomers();
    }
    async Task<List<Customer>> GetCustomers()
    {
        HttpClientHandler insecureHandler = GetInsecureHandler();
        HttpClient httpClient = new HttpClient(insecureHandler);
        var result = await httpClient.GetAsync($"{BaseAddress}/customers");
        var json = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Customer>>(json);
    }
    HttpClientHandler GetInsecureHandler()
    {
        HttpClientHandler handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
        {
            if (cert.Issuer.Equals("CN=localhost"))
                return true;
            return errors == System.Net.Security.SslPolicyErrors.None;
        };
        return handler;
    }
}

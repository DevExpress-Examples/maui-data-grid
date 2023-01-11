using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using ASPDataBaseServer.Model;
using ASPDataBaseServer.Data;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace ASPDataBaseServer.Model;
public class CustomerData
{
    public CustomerData()
    {
        GenerateEmployees();
    }
    public ObservableCollection<Customer> CustomerList { get; private set; }
    public static void GenerateEmployees()
    {
        var context = new CustomersContext();
        List<Customer> result = new List<Customer>();

        string fileName = "Data/customers.json";
        string jsonString = File.ReadAllText(fileName);
        result = JsonSerializer.Deserialize<List<Customer>>(jsonString);
        context.Customers.AddRange(result);
        context.SaveChanges();
    }
}
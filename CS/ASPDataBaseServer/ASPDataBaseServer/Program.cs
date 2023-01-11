using System;
using System.Text.Json;
using ASPDataBaseServer;
using ASPDataBaseServer.Data;
using ASPDataBaseServer.Model;
using Microsoft.EntityFrameworkCore;

static void GenerateEmployees() {
    var context = new CustomersContext();
    List<Customer> result = new List<Customer>();

    string fileName = "Data/customers.json";
    string jsonString = File.ReadAllText(fileName);
    result = JsonSerializer.Deserialize<List<Customer>>(jsonString);
    context.Customers.AddRange(result);
    context.SaveChanges();
}

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CustomersContext>(opt => opt.UseInMemoryDatabase("Customers"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

CustomersContext _Context;
_Context = new CustomersContext();
var app = builder.Build();
GenerateEmployees();

app.MapGet("/customers", async (CustomersContext db) => {
    return await _Context.Customers.ToListAsync();
});

app.Run();
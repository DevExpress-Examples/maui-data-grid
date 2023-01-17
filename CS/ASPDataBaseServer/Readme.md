# DevExpress .NET MAUI Data Grid - Bind to a Custom WebAPI Server

This example shows how to receive data from the ASP.NET Core server and display it in the DevExpress .NET MAUI Data Grid

<img src="img/datagrid-aspnetserver-data.png" width="660px"/>

The example contains the following projects:

* [ASPDataBaseServer](./ASPDataBaseServer/) - the ASP.NET Core server that stores data in a .json file.
* [MauiDataGridView_GetFromASPServer](./MauiDataGridView_GetFromASPServer/) - .NET MAUI application that contains the DevExpress .NET MAUI DataGrid. The DataGrid retrieves data from the ASP.NET Core server and displays them in the application.


<!-- default file list -->
## Files to Review

* [ASPDataBaseServer/Program.cs](./ASPDataBaseServer/Program.cs)
* [ASPDataBaseServer/CustomerData.cs](./ASPDataBaseServer/CustomerData.cs)
* [MauiDataGridView_GetFromASPServer/Model/Customer.cs](./MauiDataGridView_GetFromASPServer/Model/Customer.cs)
* [MauiDataGridView_GetFromASPServer/MainPage.xaml](./MauiDataGridView_GetFromASPServer/MainPage.xaml)
* [MauiDataGridView_GetFromASPServer/MainPage.xaml.cs](./MauiDataGridView_GetFromASPServer/MainPage.xaml.cs)

<!-- default file list end -->

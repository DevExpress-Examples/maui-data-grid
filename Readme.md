<!-- default file list -->
*Files to look at*:

* [Startup.cs](./CS/DataGridExample/Startup.cs)
* [MainPage.xaml](./CS/DataGridExample/MainPage.xaml)
* [Model.cs](./CS/DataGridExample/Model.cs)
* [ViewModel.cs](./CS/DataGridExample/ViewModel.cs)
<!-- default file list end -->

# DevExpress Data Grid for .NET MAUI

The DevExpress Data Grid for .NET MAUI Preview 6 is a data-aware control designed to present and manage data in a tabular format.

This example allows you to get started with the DataGridView component - bind it to a data source and configure its columns.

1. Install a [.NET MAUI development](https://docs.microsoft.com/en-gb/dotnet/maui/get-started/installation) environment and open the solution in Visual Studio 22 Preview.
2. Register the following NuGet feed in Visual Studio: https://nuget.devexpress.com/free/api.  
	If you are an active DevExpress [Universal](https://www.devexpress.com/subscriptions/universal.xml) customer or have registered our [free Xamarin UI controls](https://www.devexpress.com/xamarin/), this MAUI preview will be available in your personal NuGet feed automatically.
3. Restore NuGet packages.  
4. Run the application on an Android device or emulator.  

<img src="./img/devexpress-maui-data-grid.png"/>

The following step-by-step instructions describe how to create the same application.

## Create a New MAUI Application and Add a Data Grid

Create a new .NET MAUI solution in Visual Studio 22 Preview.   
Refer to the following Microsoft documentation for more information on how to get started with .NET MAUI: [.NET Multi-platform App UI](https://docs.microsoft.com/en-gb/dotnet/maui/).

Register https://nuget.devexpress.com/free/api as a package source in Visual Studio, if you are not an active DevExpress [Universal](https://www.devexpress.com/subscriptions/universal.xml) customer or have not yet registered our [free Xamarin UI controls](https://www.devexpress.com/xamarin/).

Install the **DevExpress.Maui.DataGrid** package from your NuGet feed.

In the *Startup.cs* file, register a handler for the DevExpress DataGridView:

```cs
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using DevExpress.Maui.DataGrid;

namespace DataGridExample {
	public class Startup : IStartup {
		public void Configure(IAppHostBuilder appBuilder) {
			appBuilder
				.ConfigureMauiHandlers((_, handlers) => 
                                        handlers.AddHandler<DataGridView, DataGridViewHandler>())
				.UseMauiApp<App>()
				.ConfigureFonts(fonts => {
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});
		}
	}
}
```

In the *MainPage.xaml* file, use the *dxg* prefix to declare the **DevExpress.Maui.DataGrid** namespace and add a [DataGridView](http://docs.devexpress.devx/MAUI/DevExpress.Maui.DataGrid.DataGridView) object to the ContentPage:

```xaml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="DataGridExample.MainPage"
             xmlns:dxg="clr-namespace:DevExpress.Maui.DataGrid;assembly=DevExpress.Maui.DataGrid">
    <dxg:DataGridView>
    </dxg:DataGridView>
</ContentPage>
```

## Create a Data Source
In this example, the grid is bound to a collection of *Employee* objects - *EmployeeData*. Create a *Model.cs* file with the following classes:

```cs
public enum AccessLevel {
    Admin,
    User
}

public class Employee {
    string name;
    string resourceName;

    public string Name {
        get { return name; }
        set {
            name = value;
            if (Photo == null) {
                resourceName = "DataGridExample.Images." + value.Replace(" ", "_") + ".jpg";
                if (!String.IsNullOrEmpty(resourceName))
                    Photo = ImageSource.FromResource(resourceName);
            }
        }
    }

    public Employee(string name) {
        this.Name = name;
    }

    public ImageSource Photo { get; set; }
    public DateTime HireDate { get; set; }
    public string Position { get; set; }
    public string Phone { get; set; }
    public AccessLevel Access { get; set; }
}

public class EmployeeData {
    void GenerateEmployees() {
        ObservableCollection<Employee> result = new ObservableCollection<Employee>();
        result.Add(
            new Employee("Nancy Davolio") {
                HireDate = new DateTime(2005, 5, 1),
                Position = "Sales Representative",
                Access = AccessLevel.User
            }
        );
        result.Add(
            new Employee("Andrew Fuller") {
                HireDate = new DateTime(1992, 8, 14),
                Position = "Vice President, Sales",
                Access = AccessLevel.Admin
            }
        );
        result.Add(
            new Employee("Janet Leverling") {
                HireDate = new DateTime(2002, 4, 1),
                Position = "Sales Representative",
                Access = AccessLevel.User
            }
        );
        result.Add(
            new Employee("Margaret Peacock") {
                HireDate = new DateTime(1993, 5, 3),
                Position = "Sales Representative",
                Access = AccessLevel.User
            }
        );
        result.Add(
            new Employee("Steven Buchanan") {
                HireDate = new DateTime(1993, 10, 17),
                Position = "Sales Manager",
                Access = AccessLevel.User
            }
        );
        result.Add(
            new Employee("Michael Suyama") {
                HireDate = new DateTime(1999, 10, 17),
                Position = "Sales Representative",
                Access = AccessLevel.User
            }
        );
        result.Add(
            new Employee("Robert King") {
                HireDate = new DateTime(1994, 1, 2),
                Position = "Sales Representative",
                Access = AccessLevel.User
            }
        );
        result.Add(
            new Employee("Laura Callahan") {
                HireDate = new DateTime(2004, 3, 5),
                Position = "Inside Sales Coordinator",
                Access = AccessLevel.User
            }
        );
        result.Add(
            new Employee("Anne Dodsworth") {
                HireDate = new DateTime(2004, 11, 15),
                Position = "Sales Representative",
                Access = AccessLevel.User
            }
        );
        Employees = result;
    }

    public ObservableCollection<Employee> Employees { get; private set; }

    public EmployeeData() {
        GenerateEmployees();
    }
}
```

Create a *ViewModel.cs* file and add a view model class: 

```cs
using System.Collections.Generic;
using System.ComponentModel;

namespace DataGridExample {
    public class EmployeeDataViewModel : INotifyPropertyChanged {
        readonly EmployeeData data;

        public event PropertyChangedEventHandler PropertyChanged;
        public IReadOnlyList<Employee> Employees { get => data.Employees; }

        public EmployeeDataViewModel() {
            data = new EmployeeData();
        }

        protected void RaisePropertyChanged(string name) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
```

## Bind the Grid to Data
In the *MainPage.xaml* file:
1. Assign an **EmployeeDataViewModel** object to the **ContentPage.BindingContext** property.
2. Bind the [DataGridView.ItemsSource](http://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.DataGridView.ItemsSource) property to the employee collection object that the **EmployeeDataViewModel.Employees** property returns.

```xaml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="DataGridExample.MainPage"
             xmlns:dxg="clr-namespace:DevExpress.Maui.DataGrid;assembly=DevExpress.Maui.DataGrid"
             xmlns:local="clr-namespace:DataGridExample">
    <ContentPage.BindingContext>
        <local:EmployeeDataViewModel/>
    </ContentPage.BindingContext>
    <dxg:DataGridView ItemsSource="{Binding Employees}">
    </dxg:DataGridView>
</ContentPage>
```

## Specify Grid Columns

Do the following to specify a collection of grid columns:
1. Create column objects and use the [FieldName](http://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.GridColumn.FieldName) property to bind each column to a data source field.
2. Add columns to the [DataGridView.Columns](http://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.DataGridView.Columns) collection in the order you want them to be displayed in the grid.

In this example, the grid contains the following columns:

- **Photo** ([ImageColumn](http://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.ImageColumn)) - displays photos of employees. Add images to a project as embedded resources.

- **Employee** ([TemplateColumn](http://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.TemplateColumn)) - displays names, positions, and hire dates of employees. 

    Assign a template to the **TemplateColumn.DisplayTemplate** property to define the appearance of column cells. Each cell contains a *Microsoft.Maui.Controls.Grid* with three *Microsoft.Maui.Controls.Label* elements bound to the *Name*, *Position*, and *HireDate* properties of the *Employee* class.
    
    The **CellData** object specifies a binding context for a cell template. Its **CellData.Value** property returns a value of a data field assigned to the column’s **FieldName** property. In this example, a column cell displays not only this field value but also the values of two more fields. Use the **CellData.Item** property to access the whole data row object (*Employee*) and bind its properties to properties of labels defined in the template.

- **Access Level** ([TemplateColumn](http://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.TemplateColumn)) - displays employee access level.  

    Set the **TemplateColumn.DisplayTemplate** property to a data template with a *Microsoft.Maui.Controls.Label*. Use the **Value** property of the template's binding context to bind the label to the *Employee.Access* property assigned to the column's **FieldName**.
    
```xaml
<dxg:DataGridView ItemsSource="{Binding Employees}">

    <dxg:DataGridView.Columns>
        <dxg:ImageColumn FieldName="Photo"
                            Width="100"/>
        <dxg:TemplateColumn FieldName="Name" Caption="Employee" MinWidth="200">
            <dxg:TemplateColumn.DisplayTemplate>
                <DataTemplate>
                    <Grid VerticalOptions="Center" Padding="15, 0, 0, 0" RowDefinitions="Auto, Auto, Auto">
                        <Label Text="{Binding Item.Name}" FontSize="18" FontAttributes="Bold"
                               TextColor="{DynamicResource GridCellFontColor}" Grid.Row="0" />
                        <Label Text="{Binding Item.Position, StringFormat = 'Job Title: {0}'}"
                               FontSize="Small" TextColor="{DynamicResource GridCellFontColor}" 
                               Grid.Row="1"/>
                        <Label Text="{Binding Item.HireDate, StringFormat = 'Hire Date: {0:d}'}"
                               FontSize="Small" TextColor="{DynamicResource GridCellFontColor}" 
                               Grid.Row="2" />
                    </Grid>
                </DataTemplate>
            </dxg:TemplateColumn.DisplayTemplate>
        </dxg:TemplateColumn>

        <dxg:TemplateColumn FieldName="Access" Caption="Access Level" Width="90">
            <dxg:TemplateColumn.DisplayTemplate>
                <DataTemplate>
                    <Label Text="{Binding Value}" TextColor="{DynamicResource GridCellFontColor}"
                            Grid.Row="0" Padding="14, 21, 14, 21" VerticalOptions="Center"/>
                </DataTemplate>
            </dxg:TemplateColumn.DisplayTemplate>
        </dxg:TemplateColumn>
    </dxg:DataGridView.Columns>
</dxg:DataGridView>
```

## Enable Drag-and-Drop
The DataGridView supports drag-and-drop operations and allows users to reorder rows. Users should touch and hold a data row and then drag and drop the row to another position.

To enable drag-and-drop operations, set the [AllowDragDropRows](http://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.DataGridView.AllowDragDropRows) property to **True**.
```xaml
<dxg:DataGridView ItemsSource="{Binding Employees}" AllowDragDropRows="True"/>
```

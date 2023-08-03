# DevExpress .NET MAUI Data Grid - Validate Values on Edit Form Closing 

This example implements a custom cell edit form and validates values once a user entered in that form.

<img src="./img/edit-form-validation.png"/>

This example uses the DataFormView control to implement the edit form and handles the DataFormView's ValidateForm event to validate input values once a user saves changes in the edit form. 

Specify the [DetailEditFormTemplate](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.DataGridView.DetailEditFormTemplate) property to define the custom edit form content. To invoke the edit form on a row tap, bind the [RowDoubleTapCommand](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.DataGridView.RowDoubleTapCommand) property to the [ShowDetailEditForm](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.DataGridViewCommands.ShowDetailEditForm) command.

## Files to Review

* [MainPage.xaml](MainPage.xaml)

## Documentation

* [DataGridView - CRUD Operations](https://docs.devexpress.com/MAUI/404420/data-grid/crud/crud-overview)

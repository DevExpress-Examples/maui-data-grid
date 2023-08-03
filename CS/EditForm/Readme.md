# DevExpress .NET MAUI Data Grid - Display the Edit Form and Validate Input Values

This example shows how to set up the grid to display the edit form when a user taps a cell.

<img src="./img/edit-form.png"/>

The example uses the [DataFormView](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormView) component to implement the edit form. To assign this form to the grid, specify the [DetailEditFormTemplate](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.DataGridView.DetailEditFormTemplate) property. To invoke the edit form on a row tap, bind the [RowTapCommand](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.DataGridView.RowTapCommand) property to the [ShowDetailEditForm](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.DataGridViewCommands.ShowDetailEditForm) command.

Set the [DataFormView.ValidationMode](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormView.ValidationMode) property to `LostFocus` and handle the [DataFormView.ValidateProperty](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataForm.DataFormView.ValidateProperty) event to validate input values once they are entered in the edit form.

## Files to Review

* [MainPage.xaml](MainPage.xaml)
* [OrderEditForm.xaml](OrderEditForm.xaml)
* [OrderEditForm.xaml.cs](OrderEditForm.xaml.cs)

## Documentation

* [DataGridView - CRUD Operations](https://docs.devexpress.com/MAUI/404420/data-grid/crud/crud-overview)

## More Examples

* [Configure Edit Form](/CS/EditFormTemplate/)
* [Validate Values on Edit Form Close](/CS/ValidateFormEvent/)
* [Define the In-Place Editor's Template](/CS/InPlaceEditors/)

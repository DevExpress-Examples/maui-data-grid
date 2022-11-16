<!-- default file list -->
*Files to look at*:

* [Order.cs](./DataGridView_LoadMore/DataModel/Order.cs)
* [Product.cs](./DataGridView_LoadMore/DataModel/Product.cs)
* [OrderRepository.cs](./DataGridView_LoadMore/DataModel/OrderRepository.cs)
* [ViewModel.cs](./DataGridView_LoadMore/DataModel/ViewModel.cs)
* [MainPage.xaml](./DataGridView_LoadMore/MainPage.xaml)
<!-- default file list end -->
# Implement Load-More

This example shows how to implement the grid's load-more functionality - when a user scrolls to the bottom of the grid, a set of new data items is added to the end of the grid. Data items for each next load (ten new orders) are generated randomly in code. The maximum number of loads a user is allowed to perform is 3. The total summary displays the count of data items currently loaded to the grid (it is automatically updated after each load).

1. Set the [DataGridView.IsLoadMoreEnabled](https://docs.devexpress.com/MobileControls/DevExpress.XamarinForms.DataGrid.DataGridView.IsLoadMoreEnabled) property to **true** to enable the grid's load-more functionality.  
2. Create a command to be executed when a user scrolls to the bottom of the grid. Set the [DataGridView.IsRefreshing](https://docs.devexpress.com/MobileControls/DevExpress.XamarinForms.DataGrid.DataGridView.IsRefreshing) property to **false** after data is loaded to hide the loading indicator in the grid.  
3. Bind the [DataGridView.LoadMoreCommand](https://docs.devexpress.com/MobileControls/DevExpress.XamarinForms.DataGrid.DataGridView.LoadMoreCommand) property to the created command.  

<img src="./img/grid-load-more-example.png"/>

To run the application:
1. [Obtain your NuGet feed URL](http://docs.devexpress.com/GeneralInformation/116042/installation/install-devexpress-controls-using-nuget-packages/obtain-your-nuget-feed-url).
2. Register the DevExpress NuGet feed as a package source.
3. Restore all NuGet packages for the solution.

<!-- default file list -->
*Files to look at*:

* [Model.cs](./DataGridView_PullToRefresh/Model.cs)
* [ViewModel.cs](./DataGridView_PullToRefresh/ViewModel.cs)
* [MainPage.xaml](./DataGridView_PullToRefresh/MainPage.xaml)
<!-- default file list end -->
# Implement Pull-to-Refresh

This example shows how to set up the grid so that it allows users to request a content update with the pull-down gesture. To do this, follow the steps below.

1. Set the [DataGridView.IsPullToRefreshEnabled](https://docs.devexpress.com/MobileControls/DevExpress.XamarinForms.DataGrid.DataGridView.IsPullToRefreshEnabled) property to **true** to enable the grid's pull-to-refresh functionality.  
2. Create a command to be executed when a user pulls the grid down. Set the [DataGridView.IsRefreshing](https://docs.devexpress.com/MobileControls/DevExpress.XamarinForms.DataGrid.DataGridView.IsRefreshing) property to **false** after data is refreshed to hide the refresh indicator in the grid.  
3. Bind the [DataGridView.PullToRefreshCommand](https://docs.devexpress.com/MobileControls/DevExpress.XamarinForms.DataGrid.DataGridView.PullToRefreshCommand) property to the created command.  

<img src="./img/grid-pull-to-refresh.png"/>

To run the application:
1. [Obtain your NuGet feed URL](http://docs.devexpress.com/GeneralInformation/116042/installation/install-devexpress-controls-using-nuget-packages/obtain-your-nuget-feed-url).
2. Register the DevExpress NuGet feed as a package source.
3. Restore all NuGet packages for the solution.

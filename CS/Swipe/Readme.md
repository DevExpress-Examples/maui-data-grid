# Define Swipe Actions for Data Rows

This example shows how to extend the grid’s UI with additional elements (buttons) that appear when a user swipes a data row (from left to right or from right to left) and perform custom actions on tap. It defines two swipe actions for rows of the grid bound to the collection of orders:  
- Display information on a customer - When a user swipes a data row from left to right, the **Customer** button appears on the left side of the row.  
  <img src="./img/grid-swipe-start.png"/>
- Remove an order - When a user swipes a data row from right to left, the **Delete** button appears on the right side of the row.  
  <img src="./img/grid-swipe-end.png"/>

For a complete description, refer to the following help topic: [Swipe Actions in .NET MAUI Data Grid](https://docs.devexpress.com/MAUI/403275/data-grid/swiping).

<!-- default file list -->
## Files to Review

* [Customer.cs](./DataGridView_Swipe/DataModel/Customer.cs)
* [Product.cs](./DataGridView_Swipe/DataModel/Product.cs)
* [Order.cs](./DataGridView_Swipe/DataModel/Order.cs)
* [OrderRepository.cs](./DataGridView_Swipe/DataModel/OrderRepository.cs)
* [MainPage.xaml](./DataGridView_Swipe/MainPage.xaml)
<!-- default file list end -->
# DataGrid for .NET MAUI - Implement a Column Chooser

This example demonstrates how to implement a [Data Grid](https://docs.devexpress.com/MAUI/403255/data-grid/data-grid) column chooser.

<img src="https://user-images.githubusercontent.com/12169834/228222481-197a4064-f461-4f13-8877-412c81263fd2.png" width="30%"/>

Included controls and their properties:

* [DataGridView](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.DataGridView): [AutoGenerateColumnsModeDataGrid](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.DataGridView.AutoGenerateColumnsModeDataGrid), [TemplateColumn](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.TemplateColumn)
* [DXPopup](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup): [IsOpen](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup.IsOpen)
* [DXCollectionView](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView): [ItemsSource](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.ItemsSource), [ItemTemplate](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.ItemTemplate), [ReduceSizeToContent](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.ReduceSizeToContent)
* [CheckEdit](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.CheckEdit): [IsChecked](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.CheckEdit.IsChecked), [Label](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.CheckEdit.Label), [CheckBoxPosition](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.CheckEdit.CheckBoxPosition)


## Implementation Details

* A [Data Grid](https://docs.devexpress.com/MAUI/403255/data-grid/data-grid) column chooser is displayed in the [DXPopup](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup) control. [DXPopup](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup) contains the [DXCollectionView](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView) bound to the [DataGridView.Column](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.DataGridView.Columns) collection:

    ```xaml
    <dxco:DXPopup x:Name="columnChooserPopup" ...>
        <dxcv:DXCollectionView ItemsSource="{Binding Source={Reference dataGrid}, Path=Columns}" ...>
            <dxcv:DXCollectionView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Border ...>
                            <dxe:CheckEdit IsChecked="{Binding IsVisible}" .../>
                        </Border>
                    </Grid>
                </DataTemplate>
            </dxcv:DXCollectionView.ItemTemplate>
        </dxcv:DXCollectionView>
    </dxco:DXPopup>
    ```

    File to Look At: [MainPage.xaml](CS/MainPage.xaml)

* Set the [DXCollectionView.ReduceSizeToContent](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView.ReduceSizeToContent) property to `true` to resize the [DXCollectionView](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView) to fit its content:

    ```xaml
    <dxcv:DXCollectionView ReduceSizeToContent="True" ...>
        <!-- ... -->
    </dxcv:DXCollectionView>
    ```

    File to Look At: [MainPage.xaml](CS/MainPage.xaml)

* To align the [CheckEdit](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.CheckEdit) component's checkboxes to the right, set the [CheckEdit.CheckBoxPosition](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.CheckEdit.CheckBoxPosition) property to [CheckBoxPosition.End](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.CheckBoxPosition.End):

    ```xaml
    <dxcv:DXCollectionView ...>
        <dxcv:DXCollectionView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Border ...>
                        <dxe:CheckEdit CheckBoxPosition="End" .../>
                    </Border>
                </Grid>
            </DataTemplate>
        </dxcv:DXCollectionView.ItemTemplate>
    </dxcv:DXCollectionView>
    ```

    File to Look At: [MainPage.xaml](CS/MainPage.xaml)

* You can bind [CheckEdit](https://docs.devexpress.com/MAUI/DevExpress.Maui.Editors.CheckEdit) to the [GridColumn.ActualCaption](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.GridColumn.ActualCaption) property to display the [Data Grid](https://docs.devexpress.com/MAUI/403255/data-grid/data-grid)'s column caption:

    ```xaml
    <dxcv:DXCollectionView ...>
        <dxcv:DXCollectionView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Border ...>
                        <dxe:CheckEdit Label="{Binding ActualCaption}" .../>
                    </Border>
                </Grid>
            </DataTemplate>
        </dxcv:DXCollectionView.ItemTemplate>
    </dxcv:DXCollectionView>
    ```

    File to Look At: [MainPage.xaml](CS/MainPage.xaml)

* Specify the [GridColumn.MinWidth](https://docs.devexpress.com/MAUI/DevExpress.Maui.DataGrid.GridColumn.MinWidth) property to a hide horizontal scroll bar when the total width of visible [Data Grid](https://docs.devexpress.com/MAUI/403255/data-grid/data-grid) columns is less than the width of the device's viewport:

    ```xaml
    <dxg:DataGridView ...>
        <dxg:TemplateColumn FieldName="Country" MinWidth="150">
            <dxg:TemplateColumn.DisplayTemplate>
                <!-- ... -->
            </dxg:TemplateColumn.DisplayTemplate>
        </dxg:TemplateColumn>
        <dxg:TextColumn FieldName="CameFrom" MinWidth="120" .../>
        <dxg:TextColumn FieldName="TimeOnSite" MinWidth="120" .../>
        <dxg:TextColumn FieldName="LastPage" MinWidth="130" .../>
        <dxg:TextColumn FieldName="IsReturningUser" MinWidth="130" .../>
    </dxg:DataGridView>
    ```

    File to Look At: [MainPage.xaml](CS/MainPage.xaml)

## Files to Look At

<!-- default file list -->
* [MainPage.xaml](CS/MainPage.xaml)
* [MainPage.xaml.cs](CS/MainPage.xaml.cs)
* [App.xaml](CS/App.xaml)
<!-- default file list end -->

## Documentation

* [Featured Scenario: Column Chooser](https://docs.devexpress.com/MAUI/404343)
* [Featured Scenarios](https://docs.devexpress.com/MAUI/404291)
* [CollectionView](https://docs.devexpress.com/MAUI/DevExpress.Maui.CollectionView.DXCollectionView)
* [DataGrid](https://docs.devexpress.com/MAUI/403255/data-grid/data-grid)
* [DXPopup](https://docs.devexpress.com/MAUI/DevExpress.Maui.Controls.DXPopup)

## More Examples

* [DevExpress Mobile UI for .NET MAUI](https://github.com/DevExpress-Examples/maui-demo-app/)

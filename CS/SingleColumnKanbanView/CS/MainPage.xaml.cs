using DevExpress.Maui.DataGrid;
using System.Runtime.CompilerServices;

namespace DataGridDragDrop {
    public partial class MainPage : ContentPage {
        MainViewModel viewModel;
        TaskToDo draggedItem;
        string draggedTaskOriginalStage;

        public MainPage() {
            InitializeComponent();
            BindingContext = viewModel = new MainViewModel();
        }

        private void DataGridView_CustomSort(object sender, DevExpress.Maui.DataGrid.CustomSortEventArgs e) {
            if (e.Column.FieldName == "Stage")
                e.Result = Comparer<int>.Default.Compare(viewModel.StageOrder[(string)e.Value1], viewModel.StageOrder[(string)e.Value2]);
        }
        private void DataGridView_CustomGroup(object sender, DevExpress.Maui.DataGrid.CustomGroupEventArgs e) {
            if (e.Column.FieldName == "Stage")
                e.GroupsEqual = (string)e.Value1 == (string)e.Value2;
        }
        private void DataGridView_CompleteRowDragDrop(object sender, DevExpress.Maui.DataGrid.CompleteRowDragDropEventArgs e) {
            AddPlaceholderTaskToSourceGroup();
            RemovePlaceholderTaskFromTargetGroup();
        }
        private void DataGridView_DragRow(object sender, DevExpress.Maui.DataGrid.DragRowEventArgs e) {
            draggedItem = (TaskToDo)e.DragItem;
            e.Cancel = draggedItem.IsPlaceholder;
            draggedTaskOriginalStage = draggedItem.Stage;
        }
        void AddPlaceholderTaskToSourceGroup() {
            if (!viewModel.Tasks.Any(t => t.Stage == draggedTaskOriginalStage)) {
                viewModel.Tasks.Add(new TaskToDo() { IsPlaceholder = true, Stage = draggedTaskOriginalStage });
            }
        }
        void RemovePlaceholderTaskFromTargetGroup() {
            string newDraggedTaskStage = draggedItem.Stage;
            TaskToDo stabTask = viewModel.Tasks.FirstOrDefault(t => t.Stage == newDraggedTaskStage && t.IsPlaceholder);
            if (stabTask != null) {
                viewModel.Tasks.Remove(stabTask);
            }
        }

        private async void SimpleButton_Clicked(object sender, EventArgs e) {
            await DisplayAlert("Tip", "Tap and hold a row to drag it", "OK");
        }
    }
}
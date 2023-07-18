using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridDragDrop {
    public class MainViewModel {
        public Dictionary<string, int> StageOrder = new Dictionary<string, int>() { { "Planned", 0 }, { "Doing", 1 }, { "Testing", 2 }, { "Done", 3 } };
        public ObservableCollection<TaskToDo> Tasks { get; set; }
        public MainViewModel() {
            Tasks = DataStorage.CreateTasks();
        }
    }
    public class TaskToDo {

        public TaskToDo() { }
        public TaskToDo(string title, DateTime dueDate, string stage, TaskToDoPriority priority, string assigneePhotoPath) {
            Title = title;
            DueDate = dueDate;
            Stage = stage;
            Priority = priority;
            AssigneePhotoPath= assigneePhotoPath;
        }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public string Stage { get; set; }
        public TaskToDoPriority Priority { get; set; }
        public string AssigneePhotoPath { get; set; }
        public bool IsPlaceholder { get; set; }
    }
    public enum TaskToDoPriority {
        High,
        Medium,
        Low,
    }
    public static class DataStorage {
        public static ObservableCollection<TaskToDo> CreateTasks() {
            return new ObservableCollection<TaskToDo>() {
                new TaskToDo("Single Vertical Scrollbar for Multiple Views", DateTime.Now.AddDays(18), "Testing", TaskToDoPriority.Low, "albertmenendez.jpg"),
                new TaskToDo("App UI Manager - FreeLayout for WidgetView", DateTime.Now.AddDays(20), "Done", TaskToDoPriority.Low, "alexjames.jpg"),
                new TaskToDo("Office Inspired Animations", DateTime.Now.AddDays(20), "Done", TaskToDoPriority.Low, "alfrednewman.jpg"),
                new TaskToDo("Scheduler Control - Agenda View", DateTime.Now.AddDays(1), "Planned", TaskToDoPriority.High, "frankfrankson.jpg"),
                new TaskToDo("Mail Demo Redesign", DateTime.Now.AddDays(1), "Planned", TaskToDoPriority.Low, "benjaminjohonson.jpg"),
                new TaskToDo("New Splash Screen Design", DateTime.Now.AddDays(2), "Planned", TaskToDoPriority.Medium, "albertmenendez.jpg"),
                new TaskToDo("New TreeMap Control", DateTime.Now.AddDays(5), "Testing", TaskToDoPriority.High, "bobbievalentine.jpg"),
                new TaskToDo("PictureEdit - Trim Image by Mask/Shape", DateTime.Now.AddDays(6), "Doing", TaskToDoPriority.Medium, "frankfrankson.jpg"),
                new TaskToDo("NavBar and Office Navigation Bar", DateTime.Now.AddDays(10), "Doing", TaskToDoPriority.High, "jennievalintine.jpg"),
                new TaskToDo("SVG Icons", DateTime.Now.AddDays(11), "Doing", TaskToDoPriority.High, "frankfrankson.jpg"),
                new TaskToDo("New TreeMap Control", DateTime.Now.AddDays(15), "Testing", TaskToDoPriority.High, "karenholmes.jpg"),
                new TaskToDo("Data Form and Editor AutoFocus", DateTime.Now.AddDays(17), "Testing", TaskToDoPriority.Medium, "jennievalintine.jpg"),
            };
        }
    }
}

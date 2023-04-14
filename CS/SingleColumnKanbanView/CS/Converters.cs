using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridDragDrop {
    public class ImportanceToColorConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null)
                return null;
            TaskToDoPriority taskPriority = (TaskToDoPriority)value;
            switch (taskPriority) {
                case TaskToDoPriority.Low:
                    return Color.FromArgb("#8fa3ad");
                case TaskToDoPriority.Medium:
                    return Color.FromArgb("#3BB540");
                case TaskToDoPriority.High:
                    return Color.FromArgb("#e57373");
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}

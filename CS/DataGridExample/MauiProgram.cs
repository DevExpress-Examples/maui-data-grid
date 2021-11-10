using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using DevExpress.Maui.DataGrid;
using DevExpress.Maui.Editors;
using DevExpress.Maui.CollectionView;

namespace DataGridExample {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .ConfigureMauiHandlers((handlers) => {
                    handlers.AddHandler<DataGridView, DataGridViewHandler>();
                    handlers.AddHandler<TextEdit, TextEditHandler>();
                    handlers.AddHandler<MultilineEdit, MultilineEditHandler>();
                    handlers.AddHandler<DateEdit, DateEditHandler>();
                    handlers.AddHandler<ComboBoxEdit, ComboBoxEditHandler>();
                    handlers.AddHandler<CheckEdit, CheckEditHandler>();
                    handlers.AddHandler<DXCollectionView, DXCollectionViewHandler>();
                })
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            return builder.Build();
        }
    }
}
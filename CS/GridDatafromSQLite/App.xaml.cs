namespace GridDatafromSQLite;

public partial class App : Application {
    public string targetFile = Path.Combine(FileSystem.CacheDirectory,"contacts.db");
    public App(){
		InitializeComponent();
        InitCache();
        MainPage = new AppShell();
    }

    private void InitCache() {

        if (!File.Exists(targetFile)) {
        #if IOS
            File.Copy("database/contacts.db", targetFile);
        #else
            var file = File.Create(targetFile);
            var task = FileSystem.Current.OpenAppPackageFileAsync("Resources/database/contacts.db");
            task.Wait();
            var fileStream = task.Result;
            fileStream.CopyTo(file);
            fileStream.Close();
            file.Close();
        #endif
        }
    }
}
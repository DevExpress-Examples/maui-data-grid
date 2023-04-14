using SQLite;

namespace DataGridSearchBar;

public partial class App : Application {
    public App(){
		InitializeComponent();
        DBContactService.Instance = new DBContactService(Path.Combine(FileSystem.CacheDirectory, "contacts.db"));
        DBContactService.Instance.InitCache();
        MainPage = new AppShell();
    }



    public class DBContactService 
    {
        public static DBContactService Instance {
            get;
            set;
        }

        string DBPath;
        public DBContactService(string dbPath) {
            DBPath = dbPath;
        }
        public IEnumerable<Model.Contact> GetItems() {
            var conn = new SQLiteConnection(DBPath, SQLite.SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.ProtectionNone | SQLite.SQLiteOpenFlags.SharedCache | SQLiteOpenFlags.FullMutex);
            return conn.Table<Model.Contact>().ToList();
        }
        public void InsertRecord(object item) {
            CreateConnection().Insert(item);
        }
        public void UpdateRecord(object item) {
            CreateConnection().Update(item);
        }
        public void DeleteRecord(object item) {
            CreateConnection().Delete(item);
        }
        SQLiteConnection CreateConnection() {
            return new SQLiteConnection(DBPath, SQLite.SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.ProtectionNone | SQLite.SQLiteOpenFlags.SharedCache | SQLiteOpenFlags.FullMutex);
        }

        public void InitCache() {

            if (!File.Exists(DBPath)) {
#if IOS
            File.Copy("database/contacts.db", DBPath);
#else
                var file = File.Create(DBPath);
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

}
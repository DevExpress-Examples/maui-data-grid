using GridDatafromFireBase.Model;
using Firebase.Database;
using Firebase.Auth;
using System.Reactive.Linq;

namespace GridDatafromFireBase;

public partial class MainPage : ContentPage {
    public MainPage() {
		InitializeComponent();
        LoadDataAsync();

    }
    async void LoadDataAsync() {
        var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAKApodIrO_mQScynAqPZknFnrJUB1IdF8"));
        var auth = await authProvider.SignInWithEmailAndPasswordAsync("test@example.com", "12345678");
        var firebaseClient = new FirebaseClient("https://maui-data-grid-source-default-rtdb.firebaseio.com",
            new FirebaseOptions {
                AuthTokenAsyncFactory = () => Task.FromResult(auth.FirebaseToken)
            });
        datagrid.ItemsSource = firebaseClient
            .Child("DataSet/Employees")
            .AsObservable<Employee>()
            .ObserveOn(System.Threading.SynchronizationContext.Current)
            .AsObservableCollection();
    }
}
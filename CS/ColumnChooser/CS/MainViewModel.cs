using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColumnChooserExample {
    public class MainViewModel {
        public ObservableCollection<SiteUser> ActiveUsers {
            get;
            set;
        }
        public MainViewModel() {
            ActiveUsers = Data.CreateSiteUsers();
        }
    }

    public class SiteUser {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string LastPage { get; set; }
        public string CameFrom { get; set; }
        public int Pageviews { get; set; }
        public TimeSpan TimeOnSite { get; set; }
        public bool IsReturningUser { get; set; }
        string imagePath;
        public string ImagePath { get {
                if (imagePath == null && Country != null)
                    imagePath = Country.ToLower().Replace(" ","");;
                return imagePath;
            } }
    }

    public static class Data {
        public static ObservableCollection<SiteUser> CreateSiteUsers() {
            ObservableCollection<SiteUser> siteUsers = new ObservableCollection<SiteUser> {
                new SiteUser { Id = 0, Country = "Brazil", City = "Sao Paulo", CameFrom = "google", LastPage = "Home", Pageviews = 1, TimeOnSite = new TimeSpan(0, 0, 46), IsReturningUser = false },
                new SiteUser { Id = 1, Country = "USA", City = "New York", CameFrom = "facebook", LastPage = "Buy", Pageviews = 10, TimeOnSite = new TimeSpan(0, 10, 12), IsReturningUser = true },
                new SiteUser { Id = 2, Country = "France", City = "Marseille", CameFrom = "twitter", LastPage = "About Us", Pageviews = 2, TimeOnSite = new TimeSpan(0, 3, 2), IsReturningUser = true },
                new SiteUser { Id = 3, Country = "Germany", City = "Berlin", CameFrom = "google", LastPage = ".NET MAUI Components", Pageviews = 4, TimeOnSite = new TimeSpan(0, 5, 55), IsReturningUser = false },
                new SiteUser { Id = 4, Country = "India", City = "Chennai", CameFrom = "bing", LastPage = "Home", Pageviews = 4, TimeOnSite = new TimeSpan(0, 8, 9), IsReturningUser = true },
                new SiteUser { Id = 5, Country = "Canada", City = "Ottawa", CameFrom = "google", LastPage = ".NET MAUI Documentation", Pageviews = 5, TimeOnSite = new TimeSpan(0, 9, 11), IsReturningUser = true },
                new SiteUser { Id = 6, Country = "Sweden", City = "Stockholm", CameFrom = "github", LastPage = "Universal", Pageviews = 12, TimeOnSite = new TimeSpan(0, 20, 12), IsReturningUser = false },
                new SiteUser { Id = 7, Country = "Poland", City = "Krakow", CameFrom = "google", LastPage = "Renew", Pageviews = 4, TimeOnSite = new TimeSpan(0, 2, 2), IsReturningUser = true },
                new SiteUser { Id = 8, Country = "USA", City = "Los Angeles", CameFrom = "github", LastPage = "Blogs", Pageviews = 7, TimeOnSite = new TimeSpan(0, 9, 44), IsReturningUser = true },
                new SiteUser { Id = 9, Country = "Germany", City = "Frankfurt", CameFrom = "twitter", LastPage = "Technical Support", Pageviews = 4, TimeOnSite = new TimeSpan(0, 8, 40), IsReturningUser = true },
                new SiteUser { Id = 10, Country = "Argentina", City = "Salta", CameFrom = "google", LastPage = "Demos", Pageviews = 9, TimeOnSite = new TimeSpan(0, 30, 20), IsReturningUser = false },
                new SiteUser { Id = 11, Country = "France", City = "Paris", CameFrom = "bing", LastPage = "Buy", Pageviews = 20, TimeOnSite = new TimeSpan(0, 22, 20), IsReturningUser = true },
                new SiteUser { Id = 12, Country = "Japan", City = "Osaka", CameFrom = "github", LastPage = ".NET MAUI Components", Pageviews = 2, TimeOnSite = new TimeSpan(0, 1, 16), IsReturningUser = true },
                new SiteUser { Id = 13, Country = "Belgium", City = "Brussels", CameFrom = "google", LastPage = "Support", Pageviews = 3, TimeOnSite = new TimeSpan(0, 4, 11), IsReturningUser = true },
                new SiteUser { Id = 14, Country = "India", City = "New Delhi", CameFrom = "google", LastPage = "Examples", Pageviews = 5, TimeOnSite = new TimeSpan(0, 8, 1), IsReturningUser = true }
            };
            return siteUsers;
        }
    }
}

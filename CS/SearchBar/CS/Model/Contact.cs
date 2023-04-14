using System;
using System.ComponentModel.DataAnnotations;
using DataGridSearchBar.ViewModels;
using SQLite;

namespace DataGridSearchBar.Model {
    [Table("Customers")]
    public class Contact : BindableBase {
        int? id;
        string firstName;
        string lastName;
        string company;
        string address;
        string city;
        string state;
        string email;
        int zipcode;
        string homephone;
        byte[] photo;
        ImageSource photoImageSource;


        [PrimaryKey, AutoIncrement, NotNull, Column("ID")]
        public int? ID {
            get {
                return id;
            }
            set {
                id = value;
                RaisePropertyChanged();
            }
        }

        [Required(ErrorMessage = "First Name cannot be empty")]
        public string FirstName {
            get {
                return firstName;
            }
            set {
                firstName = value;
                RaisePropertyChanged();
            }
        }
        [Required(ErrorMessage = "Last Name cannot be empty")]
        public string LastName {
            get {
                return lastName;
            }
            set {
                lastName = value;
                RaisePropertyChanged();
            }
        }
        public string Company {
            get {
                return company;
            }
            set {
                company = value;
                RaisePropertyChanged();
            }
        }
        public string Address {
            get {
                return address;
            }
            set {
                address = value;
                RaisePropertyChanged();
            }
        }
        public string City {
            get {
                return city;
            }
            set {
                city = value;
                RaisePropertyChanged();
            }
        }
        public string State {
            get {
                return state;
            }
            set {
                state = value;
                RaisePropertyChanged();
            }
        }
        public int ZipCode {
            get {
                return zipcode;
            }
            set {
                zipcode = value;
                RaisePropertyChanged();
            }
        }
        public string HomePhone {
            get {
                return homephone;
            }
            set {
                homephone = value;
                RaisePropertyChanged();
            }
        }

        public string Email {
            get {
                return email;
            }
            set {
                email = value;
                RaisePropertyChanged();
            }
        }

        public byte[] Photo {
            get {
                return photo;
            }
            set {
                photo = value;
                RaisePropertyChanged();
                UpdatePhotoImageSource();
            }
        }

        [Ignore]
        public ImageSource PhotoImageSource {
            get {
                if (photoImageSource == null)
                    photoImageSource = ImageSource.FromFile("noavatar.svg");
                return photoImageSource;
            }
            set {
                photoImageSource = value;
                RaisePropertyChanged();
            }
        }
        void UpdatePhotoImageSource() {
            PhotoImageSource = ImageSource.FromStream(() => new MemoryStream(Photo));
        }
    }
}
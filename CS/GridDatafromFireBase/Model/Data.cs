using System;
using System.Text.Json.Serialization;

namespace GridDatafromFireBase.Model
{
    public class DataSet
    {
        [JsonPropertyName("DataSet")] public Employees Employees { get; set; }
    }
    public class Employees
    {
        [JsonPropertyName("Employees")] public Employee Employee { get; set; }
    }

    public class Employee
    {
        public string City { get; set; }
        public string CountryRegionName { get; set; }
        public string JobTitle { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public string Phone { get; set; }
        public string LastName { get; set; }
        public string GroupName { get; set; }
        public string Photo { get; set; }

        public ImageSource Image
        {
            get
            {
                byte[] bytes = Convert.FromBase64String(Photo);
                MemoryStream ms = new MemoryStream(bytes);
                return ImageSource.FromStream(() => ms);
            }
        }
    }
}

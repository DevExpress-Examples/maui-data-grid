using System;
using SQLite;

namespace GridDatafromSQLite.Model
{
    [Table("Customers")]
    public class Customers
    {
        [PrimaryKey, AutoIncrement, NotNull, Column("ID")]
        public int? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string HomePhone { get; set; }
    }
}
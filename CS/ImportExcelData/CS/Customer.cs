using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportExcelData;

public class Customer {
    public string Company { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

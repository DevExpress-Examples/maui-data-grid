using DevExpress.Maui.Core;
using DevExpress.Spreadsheet;

namespace ImportFromExcel;

public class ViewModel : BindableBase {
    private bool useDefaultFile;
    public bool UseDefaultFile {
        get => useDefaultFile;
        set => SetValue(ref useDefaultFile, value);
    }

    private IEnumerable<Customer> customers;
    public IEnumerable<Customer> Customers {
        get => customers;
        set {
            SetValue(ref customers, value);
        }
    }
    public Command UploadCommand { get; }
    public ViewModel() {
        UploadCommand = new Command(UploadFile);
    }
    
    private async void UploadFile() {
        string filePath = UseDefaultFile ? await GetDefaultFile() : await SelectFile();
        if (string.IsNullOrEmpty(filePath))
            return;
        await LoadDataFromExcel(filePath);
    }

    private async Task<string> SelectFile() {
        var openResult = await FilePicker.Default.PickAsync(new PickOptions { PickerTitle = "Select an Excel file" });
        return openResult?.FullPath;
    }

    private async Task<string> GetDefaultFile() {
        return await FileHelper.EnsureAssetInAppDataAsync("sample_customers_sheet.xlsx"); 
    }

    private async Task LoadDataFromExcel(string filePath) {
        using Workbook newCustomersWorkbook = new Workbook();
        bool excelOpenResult = await newCustomersWorkbook.LoadDocumentAsync(filePath);
        if (!excelOpenResult) {
            await Shell.Current.DisplayAlert("Error", "Couldn't open the file", "OK");
            return;
        }

        Worksheet firstWorkSheet = newCustomersWorkbook.Worksheets[0];
        CellRange valuesRange = firstWorkSheet.GetDataRange();
        int topRowIndex = valuesRange.TopRowIndex;
        int leftColumnIndex = valuesRange.LeftColumnIndex;
        if (!IsValidDataStructure(firstWorkSheet, topRowIndex, leftColumnIndex)) {
            await Shell.Current.DisplayAlert("Error", "Data structure in the selected file is invalid", "OK");
            return;
        }
        List<Customer> newCustomers = new List<Customer>();
        for (int rowIndex = topRowIndex + 1; rowIndex < valuesRange.RowCount + topRowIndex; rowIndex++) {
            Customer newCustomer = new Customer() {
                FirstName = firstWorkSheet.Rows[rowIndex][leftColumnIndex].Value.TextValue,
                LastName = firstWorkSheet.Rows[rowIndex][leftColumnIndex + 1].Value.TextValue,
                Company = firstWorkSheet.Rows[rowIndex][leftColumnIndex + 2].Value.TextValue
            };
            newCustomers.Add(newCustomer);
        }

        Customers = newCustomers;
    }
    private bool IsValidDataStructure(Worksheet workSheet, int topRowIndex, int leftColumnIndex) {
        return workSheet.Rows[topRowIndex][leftColumnIndex].Value.TextValue == "First Name" &&
            workSheet.Rows[topRowIndex][leftColumnIndex + 1].Value.TextValue == "Last Name" &&
            workSheet.Rows[topRowIndex][leftColumnIndex + 2].Value.TextValue == "Company";
    }
}

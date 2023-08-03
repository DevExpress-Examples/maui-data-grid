using DevExpress.Maui.Core;

namespace EditForm;

public partial class OrderEditForm : ContentPage
{
    DetailEditFormViewModel ViewModel => (DetailEditFormViewModel)BindingContext;
    public OrderEditForm()
	{
		InitializeComponent();
	}

    private void ToolbarItem_Clicked(object sender, EventArgs e) {
        if (!this.dataFormView.Validate())
            return;
        this.dataFormView.Commit();
        ViewModel.Save();
    }

    private void dataFormView_ValidateProperty(object sender, DevExpress.Maui.DataForm.DataFormPropertyValidationEventArgs e) {
        if (e.PropertyName == "Quantity" && (decimal)e.NewValue <= 0) {
            e.ErrorText = "The value must be positive.";
            e.HasError = true;
        }
        else if (e.PropertyName == "Date" && (DateTime)e.NewValue > DateTime.Now.Date) {
            e.ErrorText = "The date value cannot be in the future.";
            e.HasError = true;
        }
       
    }
}
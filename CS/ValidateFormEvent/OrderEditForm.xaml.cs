using DevExpress.Maui.Core;

namespace ValidateFormEvent;

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

    private void dataFormView_ValidateForm(object sender, DevExpress.Maui.DataForm.DataFormValidationEventArgs e) {
        if ((decimal)e.NewValues["Quantity"] <= 0) {
            e.Errors.Add("Quantity", "The value must be positive.");
            e.HasErrors = true;
        }
        if ((DateTime)e.NewValues["Date"] > DateTime.Now.Date) {
            e.Errors.Add("Date", "The date value cannot be in the future.");
            e.HasErrors = true;
        }
    }
}
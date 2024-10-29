using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ShopClient.Pages
{
    public partial class MessageDialog: ComponentBase
    {
        private string AlertType { get; set; } = string.Empty;
        private string Message { get; set; } = string.Empty ;

        public void SetDialogValues(string alertType, string message)
        {
            AlertType = alertType;
            Message = message;
            StateHasChanged();
        }
        public async Task ShowMessage() => await js.InvokeVoidAsync("ShowDialog");
    }
}

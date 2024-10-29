using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using PhoneShopSharedLibrary.Models;
using ShopClient.Pages; // Adjust the namespace as needed


namespace ShopClient.Pages
{
    public partial class AddOrUpdateProductComponent : ComponentBase
    {

        Product myProduct = new();
        string ImageUploadMessage = "";
        async Task HandleSaveProduct()
        {
            ShowSaveButton = false;
            ShowBusyButton = !ShowSaveButton;
            if (String.IsNullOrEmpty(myProduct.Base64Img))
            {
                messageDialog!.SetDialogValues("warning", "You need to choose image");
                SetMessageDialog();
                return;
            }
        }

        async Task UploadImage(InputFileChangeEventArgs e)
        {
            if (e.File.Name.ToLower().Contains(".png"))
            {
                var format = "image/png";
                var resizeImage = await e.File.RequestImageFileAsync(format, 300, 300);
                var buffer = new byte[resizeImage.Size];
                await resizeImage.OpenReadStream().ReadAsync(buffer);
                var imageData = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
                ImageUploadMessage = "";
                myProduct.Base64Img = imageData;
                imageData = "";
                return;
            }
            ImageUploadMessage = "PNG File needed.";
            return;
        }
        MessageDialog? messageDialog;
        public bool ShowBusyButton { get; set; }
        public bool ShowSaveButton { get; set; } = true;


        private async void SetMessageDialog()
        {
            await messageDialog!.ShowMessage();
            ShowBusyButton = false;
            ShowSaveButton = !ShowBusyButton;
            StateHasChanged();
        }
    }
}

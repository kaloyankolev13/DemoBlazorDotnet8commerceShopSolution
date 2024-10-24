using PhoneShopSharedLibrary.Models;
using PhoneShopSharedLibrary.Responses;


namespace PhoneShopSharedLibrary.Contract
{ 
    public interface IProduct
    {
        Task<ServiceResponse> AddProduct(Product model);
    }
}

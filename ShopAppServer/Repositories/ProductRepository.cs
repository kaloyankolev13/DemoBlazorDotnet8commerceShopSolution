using PhoneShopSharedLibrary.Contract;
using PhoneShopSharedLibrary.Models;
using PhoneShopSharedLibrary.Responses;
using ShopAppServer.Data;
using Microsoft.EntityFrameworkCore;

namespace ShopAppServer.Repositories

{
    public class ProductRepository : IProduct
    {
        private readonly AppDbContext appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> AddProduct(Product model)
        {
            if (model == null) return new ServiceResponse(false, "Model is null");
            throw new NotImplementedException();
        }

        private async Task<ServiceResponse> CheckName(string name)
        {
            var product = await appDbContext.Product.FirstOrDefaultAsync(x=> x.Name!.ToLower()!.Equals(name));
            return product is null ? new ServiceResponse(true, null!) : new ServiceResponse(false, "Product already exists");
        }
    }
}

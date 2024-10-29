using PhoneShopSharedLibrary.Contract;
using PhoneShopSharedLibrary.Models;
using PhoneShopSharedLibrary.Responses;
using ShopAppServer.Data;
using Microsoft.EntityFrameworkCore;

namespace ShopAppServer.Repositories

{
    public class ProductRepository : IProduct
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> AddProduct(Product model)
        {
            if (model == null) return new ServiceResponse(false, "Model is null");
            var (flag, message) = await CheckName(model.Name!);
            if (flag)
            {
                _appDbContext.Products.Add(model);
                await Commit();
                return new ServiceResponse(true, "Product Saved");
            }
            return new ServiceResponse(false,message);
        }

        public async Task<List<Product>> GetAllProducts(bool featuredProduct)
        {
            if (featuredProduct)
                return await _appDbContext.Products.Where(p => p.Featured).ToListAsync();
            else
                return await _appDbContext.Products.ToListAsync();
        }

        private async Task<ServiceResponse> CheckName(string name)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(x=> x.Name!.ToLower()!.Equals(name));
            return product is null ? new ServiceResponse(true, null!) : new ServiceResponse(false, "Product already exists");
        }

        private async Task Commit() => await _appDbContext.SaveChangesAsync();
    }
}

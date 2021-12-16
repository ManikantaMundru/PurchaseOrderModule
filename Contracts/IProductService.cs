using PurchaseOrderModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrderModule.Contracts
{
    public interface IProductService
    {
        Task<int> AddNewProduct(AddProductsModel modal);
        Task<IList<GetProductModel>> GetProducts();

        Task<IList<GetProductModel>> GetProductsBySupplierId(GetProductsBySupplierIdModel modal);
    }
}

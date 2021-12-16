using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PurchaseOrderModule.Models;

namespace PurchaseOrderModule.Contracts
{
    public interface IPurchaseOrderService
    {
        Task<int> AddNewPurchaseOrder(AddPurchaseOrderModel modal);
        Task<int> AddProductsForPurchaseOrder(AddPurchaseProductsModel modal);
        Task<IList<GetPurchaseOrderModel>> GetPurchaseOrders();
        Task<IList<GetPurchaseOrderProductsModel>> GetPurchaseOrderProducts(RequestProductsOfPurchaseOrderModel modal);
    }
}

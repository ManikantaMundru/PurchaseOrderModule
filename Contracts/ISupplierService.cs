using PurchaseOrderModule.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseOrderModule.Contracts
{
    public interface ISupplierService
    {
        Task<int> AddNewSupplier(AddSupplierModel model);
        Task<IList<GetSupplierModel>> GetSuppliers();

    }
}

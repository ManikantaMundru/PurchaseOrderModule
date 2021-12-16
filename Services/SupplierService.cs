using PurchaseOrderModule.Contracts;
using PurchaseOrderModule.Models;
using PurchaseOrderModule.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PurchaseOrderModule.Utilities;

namespace PurchaseOrderModule.Services
{
    public class SupplierService: RepositoryBase, ISupplierService
    {
        public SupplierService(IDapperRepository dapperRepository): base(dapperRepository)
        {

        }

        public async Task<int> AddNewSupplier(AddSupplierModel model)
        {
            try
            {
                _connection.StoredProcedure = Constants.AddSupplierStoredProcedure;
                _connection.Parameters = model;
                return await _dapperRepository.Execute(_connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<GetSupplierModel>> GetSuppliers()
        {
            try
            {
                _connection.StoredProcedure = Constants.GetSuppliersStoredProcedures;
                _connection.Parameters = null;
                return await _dapperRepository.QueryList<GetSupplierModel>(_connection);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

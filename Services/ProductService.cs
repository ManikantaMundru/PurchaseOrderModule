using PurchaseOrderModule.Contracts;
using PurchaseOrderModule.Models;
using PurchaseOrderModule.Repository.Contracts;
using PurchaseOrderModule.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrderModule.Services
{
    public class ProductService : RepositoryBase, IProductService
    {

        public ProductService(IDapperRepository dapperRepository) : base(dapperRepository)
        {

        }

        public async Task<int> AddNewProduct(AddProductsModel modal)
        {
            try
            {
                _connection.StoredProcedure = Constants.AddProductStoredProcedure;
                _connection.Parameters = modal;
                return await _dapperRepository.Execute(_connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<GetProductModel>> GetProducts()
        {
            try
            {
                _connection.StoredProcedure = Constants.GetProductsStoredProcedure;
                _connection.Parameters = null;
                return await _dapperRepository.QueryList<GetProductModel>(_connection);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IList<GetProductModel>> GetProductsBySupplierId(GetProductsBySupplierIdModel modal)
        {
            try
            {
                _connection.StoredProcedure = Constants.GetProductsBySupplierId;
                _connection.Parameters = modal;
                return await _dapperRepository.QueryList<GetProductModel>(_connection);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

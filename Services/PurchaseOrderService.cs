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
    public class PurchaseOrderService : RepositoryBase, IPurchaseOrderService
    {

        public PurchaseOrderService(IDapperRepository dapperRepository) : base(dapperRepository)
        {

        }
        public async Task<int> AddNewPurchaseOrder(AddPurchaseOrderModel model)
        {
            try
            {
                _connection.StoredProcedure = Constants.AddPurchaseOrderStoredProcedure;
                _connection.Parameters = model;
                return await _dapperRepository.Execute(_connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddProductsForPurchaseOrder(AddPurchaseProductsModel model)
        {
            try
            {
                _connection.StoredProcedure = Constants.AddProductOrders;
                _connection.Parameters = model;
                return await _dapperRepository.Execute(_connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<GetPurchaseOrderProductsModel>> GetPurchaseOrderProducts(RequestProductsOfPurchaseOrderModel modal)
        {
            try
            {
                _connection.StoredProcedure = Constants.GetProductsForPurchaseOrderStoredProcedure;
                _connection.Parameters = modal;
                return await _dapperRepository.QueryList<GetPurchaseOrderProductsModel>(_connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<GetPurchaseOrderModel>> GetPurchaseOrders()
        {
            try
            {
                _connection.StoredProcedure = Constants.GetPurchaseOrdersStoredProcedure;
                _connection.Parameters = null;
                return await _dapperRepository.QueryList<GetPurchaseOrderModel>(_connection);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

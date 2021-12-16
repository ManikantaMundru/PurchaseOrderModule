using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrderModule.Utilities
{
    public class Constants
    {

        //Stored procedures
        public const string AddSupplierStoredProcedure = "spAddSupplier";
        public const string AddProductStoredProcedure = "spAddProduct";
        public const string AddPurchaseOrderStoredProcedure = "spAddPurchaseOrder";
        public const string AddProductOrders = "spAddProductOrders";
        public const string GetSuppliersStoredProcedures = "spGetSuppliers";
        public const string GetProductsStoredProcedure = "spGetProducts";
        public const string GetProductsBySupplierId = "spGetProductsBySupplierId";
        public const string GetPurchaseOrdersStoredProcedure = "spGetPurchaseOrders";
        public const string GetProductsForPurchaseOrderStoredProcedure = "spGetPurchaseOrderProducts";
    }
}

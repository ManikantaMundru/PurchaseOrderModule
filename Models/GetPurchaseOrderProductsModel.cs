using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrderModule.Models
{
    public class GetPurchaseOrderProductsModel
    {
        public string OrderCode { get; set; }
        public string OrderDescription { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public string SupplierName { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

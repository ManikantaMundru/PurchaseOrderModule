using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrderModule.Models
{
    public class GetPurchaseOrderModel
    {

        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string OrderCode { get; set; }
        public string OrderDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}

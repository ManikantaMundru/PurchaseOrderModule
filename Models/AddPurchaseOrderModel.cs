
using System.Collections.Generic;

namespace PurchaseOrderModule.Models
{
    public class AddPurchaseOrderModel
    {
        public int SupplierId { get; set; }
        public string OrderCode { get; set; }
        public string OrderDescription { get; set; }
        public int TotalPrice { get; set; }
        //public List<AddPurchaseProductsModel> Products { get; set; }
    }
}

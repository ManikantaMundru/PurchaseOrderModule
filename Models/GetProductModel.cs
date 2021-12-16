using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrderModule.Models
{
    public class GetProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}


namespace PurchaseOrderModule.Models
{
    public class AddPurchaseProductsModel
    {
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

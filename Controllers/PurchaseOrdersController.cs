using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PurchaseOrderModule.Models;
using PurchaseOrderModule.Contracts;

namespace PurchaseOrderModule.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        private readonly IPurchaseOrderService _perchaseOrderService;
        public PurchaseOrdersController(IPurchaseOrderService purchaseOrderService)
        {
            _perchaseOrderService = purchaseOrderService;
        }
        public IActionResult PurchaseOrders()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddPurchaseOrder([FromBody]AddPurchaseOrderModel model)
        {
            var purchaseOrderCreation = await _perchaseOrderService.AddNewPurchaseOrder(model);    
            return Json(new { success = true, response = purchaseOrderCreation });
        }


        [HttpPost]
        public async Task<ActionResult> AddPurchaseOrderProducts([FromBody]AddPurchaseProductsModel model)
        {
            var purchaseOrderCreation = await _perchaseOrderService.AddProductsForPurchaseOrder(model);
            return Json(new { success = true, response = purchaseOrderCreation });
        }


        [HttpGet]
        public async Task<ActionResult> GetAllPurchaseOrders()
        {
            IList<GetPurchaseOrderModel> result = await _perchaseOrderService.GetPurchaseOrders();
            return Json(new { success = true, response = result });
        }

        [HttpPost]
        public async Task<ActionResult> GetProductsForPurchaseOrder([FromBody]RequestProductsOfPurchaseOrderModel modal)
        {
            IList<GetPurchaseOrderProductsModel> result = await _perchaseOrderService.GetPurchaseOrderProducts(modal);
            return Json(new { success = true, response = result });
        }
    }
}
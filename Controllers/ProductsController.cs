using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PurchaseOrderModule.Contracts;
using PurchaseOrderModule.Models;

namespace PurchaseOrderModule.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Products()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody]AddProductsModel model)
        {
            var result = await _productService.AddNewProduct(model);
            return Json(new { success = true, response = result });
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            IList<GetProductModel> result = await _productService.GetProducts();
            return Json(new { success = true, response = result });
        }

        [HttpPost]
        public async Task<ActionResult> GetAllProductsBySupplierId([FromBody]GetProductsBySupplierIdModel modal)
        {
            IList<GetProductModel> result = await _productService.GetProductsBySupplierId(modal);
            return Json(new { success = true, response = result });
        }
    }
}
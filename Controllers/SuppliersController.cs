using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PurchaseOrderModule.Contracts;
using PurchaseOrderModule.Models;
using PurchaseOrderModule.Utilities;

namespace PurchaseOrderModule.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;
        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        public IActionResult Suppliers()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddSupplier([FromBody]AddSupplierModel model)
        {
            var result = await _supplierService.AddNewSupplier(model);
            return Json(new { success=true,response=result});
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSuppliers()
        {
            IList<GetSupplierModel> result = await _supplierService.GetSuppliers();
            return Json(new { success = true, response = result });
        }


    }
}
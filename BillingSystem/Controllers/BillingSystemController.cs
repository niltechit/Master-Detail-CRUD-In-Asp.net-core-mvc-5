using BillingSystem.MODEL;
using BillingSystem.SERVICE.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystem.Controllers
{
    public class BillingSystemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ICustomerService _customerService;
        private readonly IBillService _billService;
        public BillingSystemController(IItemService itemService, ICustomerService customerService, IBillService billService)
        {
            _itemService = itemService;
            _customerService = customerService;
            _billService = billService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task< IActionResult> Create()
        {
            EntryViewModel model = new EntryViewModel();

            model.Items = new List<ITEMTABLE>();

            IEnumerable<CUSTOMER> customers= await _customerService.GetAll();
            IEnumerable<ITEMTABLE> itemList= await _itemService.GetAll();
            ViewData["CustomerList"] = new SelectList(customers, "CUSTID", "CUSTNAME");
            ViewData["ProductList"] = new SelectList(itemList, "ITEMID", "ITEMNAME");

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EntryViewModel entry)
        {
            EntryViewModel model = new EntryViewModel();
            model.CUSTOMER = await _customerService.GetAll();
            model.ITEMTABLE = await _itemService.GetAll();

            await _billService.Insert(entry);

            return View();
        }
    }
}

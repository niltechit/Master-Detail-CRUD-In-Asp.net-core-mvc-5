using BillingSystem.MODEL;
using BillingSystem.SERVICE.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystem.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        public async Task<IActionResult> Index()
        {
            List<ITEMTABLE> MODEL = new List<ITEMTABLE>();
            MODEL = await _itemService.GetAll();
            return View(MODEL);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ITEMTABLE item)
        {
            ITEMTABLE model = new ITEMTABLE();
            model.ITEMID = item.ITEMID;
            model.ITEMCODE = item.ITEMCODE;
            model.ITEMNAME = item.ITEMNAME;
            model.RATE = item.RATE;
            model.MOU = item.MOU;
            model.STOCKQTY = item.STOCKQTY;
            await _itemService.Insert(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var item = await _itemService.GetById(Id);
            ITEMTABLE model = new ITEMTABLE();
            model.ITEMID = item.ITEMID;
            model.ITEMCODE = item.ITEMCODE;
            model.ITEMNAME = item.ITEMNAME;
            model.RATE = item.RATE;
            model.MOU = item.MOU;
            model.STOCKQTY = item.STOCKQTY;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ITEMTABLE item)
        {
            ITEMTABLE model = new ITEMTABLE();
            model.ITEMID = item.ITEMID;
            model.ITEMCODE = item.ITEMCODE;
            model.ITEMNAME = item.ITEMNAME;
            model.RATE = item.RATE;
            model.MOU = item.MOU;
            model.STOCKQTY = item.STOCKQTY;
            await _itemService.Update(model);
            return RedirectToAction("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ITEMTABLE item)
        {
            var ITEMID = item.ITEMID;
            await _itemService.Delete(ITEMID);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _itemService.GetById(id);
            ITEMTABLE model = new ITEMTABLE();
            model.ITEMID = item.ITEMID;
            model.ITEMCODE = item.ITEMCODE;
            model.ITEMNAME = item.ITEMNAME;
            model.RATE = item.RATE;
            model.MOU = item.MOU;
            model.STOCKQTY = item.STOCKQTY;
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _itemService.GetById(id);
            ITEMTABLE model = new ITEMTABLE();
            model.ITEMID = item.ITEMID;
            model.ITEMCODE = item.ITEMCODE;
            model.ITEMNAME = item.ITEMNAME;
            model.RATE = item.RATE;
            model.MOU = item.MOU;
            model.STOCKQTY = item.STOCKQTY;

            return View(model);
        }

        public async Task<JsonResult> GetItemById(int Id)
        {
            var result = await _itemService.GetById(Id);
            return Json(result);
        }
    }
}

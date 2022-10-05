using BillingSystem.MODEL;
using BillingSystem.SERVICE.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
            List<CUSTOMER> MODEL = new List<CUSTOMER>();
            MODEL = await _customerService.GetAll();
            return View(MODEL);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CUSTOMER customer)
        {
            CUSTOMER model = new CUSTOMER();
            model.CUSTID = customer.CUSTID;
            model.CUSTNAME = customer.CUSTNAME;
            await _customerService.Insert(model);
            return View();
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var result = await _customerService.GetById(Id);
            CUSTOMER model = new CUSTOMER();
            model.CUSTID = result.CUSTID;
            model.CUSTNAME = result.CUSTNAME;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CUSTOMER customer)
        {
            CUSTOMER model = new CUSTOMER();
            model.CUSTID = customer.CUSTID;
            model.CUSTNAME = customer.CUSTNAME;
            await _customerService.Update(model);
            return RedirectToAction("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CUSTOMER customer)
        {
            var CUSTID = customer.CUSTID;
            await _customerService.Delete(CUSTID);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customerService.GetById(id);
            CUSTOMER model = new CUSTOMER();
            model.CUSTID = result.CUSTID;
            model.CUSTNAME = result.CUSTNAME;
            return View(model);
        }

        public IActionResult Details(CUSTOMER customer)
        {
            CUSTOMER model = new CUSTOMER();
            model.CUSTID = customer.CUSTID;
            model.CUSTNAME = customer.CUSTNAME;
            return RedirectToAction("Index", model);
        }
    }
}

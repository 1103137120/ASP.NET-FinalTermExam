using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class CustomersController : Controller
    {
        private CustomersService cusService = new CustomersService();
        
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增客戶頁面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
        //    var CusDropListItem = cusService.GetCusDropListItem();            
        //    List<SelectListItem> CustId = new List<SelectListItem>();            
        //    foreach (var item in CusDropListItem)
        //    {
        //        CustId.Add(new SelectListItem() { Text = item.CompanyName, Value = item.CustId.ToString() });
        //    }
           
        //    ViewData["CustId"] = CustId;
            
            return View();
        }

        /// <summary>
        /// 新增客戶Action
        /// </summary>
        /// <param name="o">整份表單</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Customers c)
        {
            if (ModelState.IsValid)
            {
                cusService.InsertCustomers(c);
            }
            return RedirectToAction("Index");
        }
    }
}
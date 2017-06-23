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

        /// <summary>
        /// 搜尋客戶頁面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Search()
        {
              
            return View();
        }

        /// <summary>
        /// 搜尋客戶Action
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Search(Customers c)
        {
            if (c == null) {
                return View("SearchResult", cusService.GetCustomers());
            }else { return View("SearchResult", cusService.SearchCustomers(c)); }
           
        }




        [HttpGet]
        public ActionResult Delete(int? CustomerID, FormCollection col)
        {
           // cusService.GetOrderById(orderId);
            if (cusService != null)
                cusService.DeleteCustomers(CustomerID);
            return RedirectToAction("Index");
        }

    }

}

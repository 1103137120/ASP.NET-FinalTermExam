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

        /// <summary>
        /// 搜尋客戶頁面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Search()
        {
            //var CusDropListItem = cusService.GetCusDropListItem();           
            //List<SelectListItem> CustId = new List<SelectListItem>();            
            //foreach (var item in CusDropListItem)
            //{
            //    CustId.Add(new SelectListItem() { Text = item.CompanyName, Value = item.CustId.ToString() });
            //}            
            //ViewData["CustId"] = CustId;           
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
            return View("SearchResult", cusService.SearchCustomers(c));
        }


        //[HttpGet]
        //public ActionResult Edit(int? orderId)
        //{
        //    foreach (var item in CusDropListItem)
        //    {
        //        CustId.Add(new SelectListItem() { Text = item.CompanyName, Value = item.CustId.ToString() });
        //    }

        //    ViewData["CustIdItem"] = CustId;

        //    return View(cusService.GetOrderById(orderId));
        //}

        ///// <summary>
        ///// 編輯訂單Action
        ///// </summary>
        ///// <param name="orderId">訂單編號</param>
        ///// <param name="form">表單</param>
        ///// <returns></returns>
        //[HttpPost]
        //public ActionResult Edit(int? orderId, FormCollection form)
        //{
        //    var data = orderService.GetOrderById(orderId);
        //    if (TryUpdateModel(data, "", form.AllKeys, new string[] { }))
        //    {
        //        orderService.UpdateOrder(data);
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("UpdateError", "更新失敗!");
        //        return View(orderService);
        //    }
        //    return RedirectToAction("Index");
        //}





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

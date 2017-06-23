using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace mvc.Models
{
    public class Customers
    {

        /// <summary>
        /// 客戶編號
        /// </summary>
        [DisplayName("客戶編號")]
        public int CustomerID { get; set; }        

        /// <summary>
        /// 客戶名稱
        /// </summary>
        [DisplayName("客戶名稱")]
        public string CompanyName { get; set; }

        /// <summary>
        /// 聯絡人姓名
        /// </summary>
        [DisplayName("聯絡人姓名")]
        public string ContactName { get; set; }

        /// <summary>
        /// 聯絡人職稱
        /// </summary>
        [DisplayName("聯絡人職稱")]
        public string ContactTitle { get; set; }

       
        /// <summary>
        /// 建立日期
        /// </summary>
        [DisplayName("建立日期")]
        public string CreationDate { get; set; }

        
        /// <summary>
        /// 地址
        /// </summary>
        [DisplayName("地址")]
        public string Address { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [DisplayName("城市")]
        public string City { get; set; }

        /// <summary>
        /// 地區
        /// </summary>
        [DisplayName("地區")]
        public string Region { get; set; }

        /// <summary>
        /// 郵遞區號
        /// </summary>
        [DisplayName("郵遞區號")]
        public string PostalCode { get; set; }

        /// <summary>
        /// 國家
        /// </summary>
        [DisplayName("國家")]
        public string Country { get; set; }

        /// <summary>
        /// 電話
        /// </summary>
        [DisplayName("電話")]
        public string Phone { get; set; }

        /// <summary>
        /// 傳真
        /// </summary>
        [DisplayName("傳真")]
        public string Fax { get; set; }

    }
}
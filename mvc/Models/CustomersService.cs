using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace mvc.Models
{
    public class CustomersService
    {

        
            /// <summary>
            /// 連線
            /// </summary>
            /// <returns></returns>
            private string GetDBConnectionString()
            {
                return
                    System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
            }
            /// <summary>
            /// 新增客戶
            /// </summary>
            /// <param name="cus"></param>
            public void InsertCustomers(Models.Customers cus)
            {
                Models.Customers result = new Customers();
                DataTable dt = new DataTable();
                String sql = @"
                    INSERT INTO [Sales].[Customers]([CompanyName],[ContactName],[ContactTitle],[CreationDate],[Address],[City],[Region],[PostalCode],[Country],[Phone],[Fax])
                    VALUES (@CompanyName,@ContactName,@ContactTitle,@CreationDate,@Country,@City,@Region,@PostalCode,@Address,@Phone,@Fax)";

                using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);                    
                    cmd.Parameters.Add(new SqlParameter("@CompanyName", cus.CompanyName));
                    cmd.Parameters.Add(new SqlParameter("@ContactName", cus.ContactName));
                    cmd.Parameters.Add(new SqlParameter("@ContactTitle", cus.ContactTitle));
                    cmd.Parameters.Add(new SqlParameter("@CreationDate", cus.CreationDate));
                    cmd.Parameters.Add(new SqlParameter("@Country", cus.Country));
                    cmd.Parameters.Add(new SqlParameter("@City", cus.City));
                    cmd.Parameters.Add(new SqlParameter("@Region", cus.Region));
                    cmd.Parameters.Add(new SqlParameter("@PostalCode", cus.PostalCode));
                    cmd.Parameters.Add(new SqlParameter("@Address", cus.Address));
                    cmd.Parameters.Add(new SqlParameter("@Phone", cus.Phone));
                    cmd.Parameters.Add(new SqlParameter("@Fax", cus.Fax));
                    
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                    sqlAdapter.Fill(dt);
                    conn.Close();
                }
        }

        //   /// <summary>
        //   /// 取得聯絡人下拉式選單資料
        //   /// </summary>
        //   /// <returns></returns>
        //   public List<Customers> GetCusDropListItem()
        //{
        //    List<Models.Customers> MapResult = new List<Customers>();
        //    DataTable dt = new DataTable();
        //    String sql = @"SELECT [CodeType],[CodeId],[CodeVal]
        //                  FROM [dbo].[CodeTable]";

        //    using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
        //        sqlAdapter.Fill(dt);
        //        conn.Close();
        //    }

        //    foreach (DataRow Row in dt.Rows)
        //    {
        //        MapResult.Add(new Customers()
        //        {
        //            CustId = (int)Row["CustomerID"],
        //            CompanyName = Row["CompanyName"].ToString()
        //        }
        //        );
        //    }

        //    return MapResult;
        //}


        public List<Customers> SearchCustomers(Models.Customers cus)
        {
            List<Customers> result = new List<Customers>();
            DataTable dt = new DataTable();
            String sqlwhere = "1=1";
            if (cus.CustomerID != 0)
            {
                sqlwhere = sqlwhere + "AND CustomerID=@CustomerID";
            }
            if (cus.CompanyName != null)
            {
                sqlwhere = sqlwhere + "AND CompanyName=@CompanyName";
            }
            if (cus.ContactName != null)
            {
                sqlwhere = sqlwhere + " AND ContactName=@ContactName";
            }
            if (cus.ContactTitle != null)
            {
                sqlwhere = sqlwhere + " AND ContactTitle=@ContactTitle";
            }
            
            String sql = @"SELECT CustomerID,CompanyName,ContactName,ContactTitle
                          FROM [Sales].[Customers] 
                          WHERE " + sqlwhere;

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (cus.CustomerID != 0) { cmd.Parameters.Add(new SqlParameter("@CustomerID", cus.CustomerID)); }
                if (cus.CompanyName != null) { cmd.Parameters.Add(new SqlParameter("@CompanyName", cus.CompanyName)); }
                if (cus.ContactName != null) { cmd.Parameters.Add(new SqlParameter("@ContactName", cus.ContactName)); }
                if (cus.ContactTitle != null) { cmd.Parameters.Add(new SqlParameter("@ContactTitle", cus.ContactTitle)); }

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }

            result = (from i in dt.AsEnumerable()
                      select new Customers()
                      {
                          CustomerID = i.Field<int>("CustomerID"),
                          CompanyName = i.Field<string>("CompanyName"),
                          ContactName = i.Field<string>("ContactName"),
                          ContactTitle = i.Field<string>("ContactTitle"),                         
                      }).ToList<Customers>();

            return result;
        }

        /// <summary>
        /// 刪除客戶
        /// </summary>
        public void DeleteCustomers(int? CustomerID)
        {
            DataTable dt = new DataTable();
            String sql = @"DELETE FROM [Sales].[Customers]
                          WHERE [CustomerID]=@CustomerID";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@CustomerID", CustomerID));
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
        }


      

      

        /// <summary>
        /// 取得客戶列表
        /// </summary>
        /// <returns></returns>
        public List<Customers> GetCustomers()
        {
            List<Customers> result = new List<Customers>();
            DataTable dt = new DataTable();
            String sql = @"SELECT CustomerID,CompanyName,ContactName,ContactTitle
                          FROM [Sales].[Customers] ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }

            result = (from i in dt.AsEnumerable()
                      select new Customers()
                      {
                          CustomerID = i.Field<int>("CustomerID"),
                          CompanyName = i.Field<string>("CompanyName"),
                          ContactName = i.Field<string>("ContactName"),
                          ContactTitle = i.Field<string>("ContactTitle"),


                      }).ToList<Customers>();

            return result;
        }
       
    }
}

   

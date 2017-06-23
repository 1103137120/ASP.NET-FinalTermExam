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


        //   public List<Customers> SearchOrder(Models.cus cus)
        //   {
        //       List<Customers> result = new List<Customers>();
        //       DataTable dt = new DataTable();
        //       String sqlwhere = "1=1";
        //       if (cus.OrderId != 0)
        //       {
        //           sqlwhere = sqlwhere + "AND OrderID=@OrderID";
        //       }
        //       if (cus.CustId != 0)
        //       {
        //           sqlwhere = sqlwhere + " AND c.CustomerID=@CustomerID";
        //       }
        //       if (cus.EmpId != 0)
        //       {
        //           sqlwhere = sqlwhere + " AND e.EmployeeID=@EmployeeID";
        //       }
        //       if (cus.ShipperName != null)
        //       {
        //           sqlwhere = sqlwhere + " AND ShipperName=@ShipperName";
        //       }
        //       if (cus.OrderDate != null)
        //       {
        //           sqlwhere = sqlwhere + " AND OrderDate=@OrderDate";
        //       }
        //       if (cus.RequireDate != null)
        //       {
        //           sqlwhere = sqlwhere + " AND RequiredDate=@RequiredDate"; ;
        //       }
        //       if (cus.ShippedDate != null)
        //       {
        //           sqlwhere = sqlwhere + " AND ShippedDate=@ShippedDate"; ;
        //       }
        //       String sql = @"SELECT OrderID,c.CompanyName,LastName+' '+FirstName AS EmpName,ship.CompanyName AS ShipperName,convert(char(10),OrderDate,111) AS OrderDate,convert(char(10),OrderDate,111) AS RequiredDate,convert(char(10),ShippedDate,111) AS ShippedDate
        //                  FROM [Sales].[Orders] AS o                           
        //               JOIN [Sales].[Customers] AS c
        //               ON o.CustomerID=c.CustomerID
        //JOIN [HR].[Employees] AS e
        //ON o.EmployeeID=e.EmployeeID
        //JOIN [Production].[Suppliers] AS ship
        //ON o.[ShipperID]=ship.SupplierID
        //                  WHERE " + sqlwhere;

        //       using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
        //       {
        //           conn.Open();
        //           SqlCommand cmd = new SqlCommand(sql, conn);
        //           if (cus.OrderId != 0) { cmd.Parameters.Add(new SqlParameter("@OrderID", cus.OrderId)); }
        //           if (cus.CustId != 0) { cmd.Parameters.Add(new SqlParameter("@CustomerID", cus.CustId)); }
        //           if (cus.EmpId != 0) { cmd.Parameters.Add(new SqlParameter("@EmployeeID", cus.EmpId)); }
        //           if (cus.ShipperName != null) { cmd.Parameters.Add(new SqlParameter("@ShipperName", cus.ShipperName)); }
        //           if (cus.OrderDate != null) { cmd.Parameters.Add(new SqlParameter("@OrderDate", cus.OrderDate)); }
        //           if (cus.RequireDate != null) { cmd.Parameters.Add(new SqlParameter("@RequiredDate", cus.RequireDate)); }
        //           if (cus.ShippedDate != null) { cmd.Parameters.Add(new SqlParameter("@ShippedDate", cus.ShippedDate)); }

        //           SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
        //           sqlAdapter.Fill(dt);
        //           conn.Close();
        //       }

        //       result = (from i in dt.AsEnumerable()
        //                 select new cus()
        //                 {
        //                     OrderId = i.Field<int>("OrderID"),
        //                     CompanyName = i.Field<string>("CompanyName"),
        //                     EmpName = i.Field<string>("EmpName"),
        //                     ShipperName = i.Field<string>("ShipperName"),
        //                     OrderDate = i.Field<string>("OrderDate"),
        //                     RequireDate = i.Field<string>("RequiredDate"),
        //                     ShippedDate = i.Field<string>("ShippedDate")

        //                 }).ToList<cus>();

        //       return result;
        //   }



        //   /// <summary>
        //   /// 刪除訂單
        //   /// </summary>
        //   public void DeleteOrder(int? orderId)
        //   {
        //       DataTable dt = new DataTable();
        //       String sql = @"DELETE FROM [Sales].[Orders]
        //                  WHERE [OrderID]=@OrderId";

        //       using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
        //       {
        //           conn.Open();
        //           SqlCommand cmd = new SqlCommand(sql, conn);
        //           cmd.Parameters.Add(new SqlParameter("@OrderId", orderId));
        //           SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
        //           sqlAdapter.Fill(dt);
        //           conn.Close();
        //       }
        //   }
        //   /// <summary>
        //   /// 修改訂單
        //   /// </summary>
        //   /// <param name="cus"></param>
        //   public void UpdateOrder(Models.cus cus)
        //   {
        //       DataTable dt = new DataTable();
        //       String sql = @"UPDATE [Sales].[Orders]
        //                  SET [CustomerID]=@CustomerID,[EmployeeID]=@EmployeeID,[OrderDate]=@OrderDate,[RequiredDate]=@RequiredDate,[ShippedDate]=@ShippedDate,[Freight]=@Freight,[ShipperID]=@ShipperID,[ShipName]=@ShipName,[ShipAddress]=@ShipAddress,[ShipCity]=@ShipCity,[ShipRegion]=@ShipRegion,[ShipPostalCode]=@ShipPostalCode,[ShipCountry]=@ShipCountry
        //                  WHERE [OrderID]=@OrderID";

        //       using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
        //       {
        //           conn.Open();
        //           SqlCommand cmd = new SqlCommand(sql, conn);
        //           cmd.Parameters.Add(new SqlParameter("@OrderID", cus.OrderId));
        //           cmd.Parameters.Add(new SqlParameter("@CustomerID", cus.CustId));
        //           cmd.Parameters.Add(new SqlParameter("@EmployeeID", cus.EmpId));
        //           cmd.Parameters.Add(new SqlParameter("@OrderDate", cus.OrderDate));
        //           cmd.Parameters.Add(new SqlParameter("@RequiredDate", cus.RequireDate));
        //           cmd.Parameters.Add(new SqlParameter("@ShippedDate", cus.ShippedDate));
        //           cmd.Parameters.Add(new SqlParameter("@Freight", cus.Freight));
        //           cmd.Parameters.Add(new SqlParameter("@ShipperID", cus.ShipperId));
        //           cmd.Parameters.Add(new SqlParameter("@ShipName", cus.ShipName));
        //           cmd.Parameters.Add(new SqlParameter("@ShipAddress", cus.ShipAddress));
        //           cmd.Parameters.Add(new SqlParameter("@ShipCity", cus.ShipCity));
        //           cmd.Parameters.Add(new SqlParameter("@ShipRegion", cus.ShipRegion));
        //           cmd.Parameters.Add(new SqlParameter("@ShipPostalCode", cus.ShipPostalCode));
        //           cmd.Parameters.Add(new SqlParameter("@ShipCountry", cus.ShipCountry));
        //           SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
        //           sqlAdapter.Fill(dt);
        //           conn.Close();
        //       }
        //   }

        //   /// <summary>
        //   /// 取得每一筆訂單明細
        //   /// </summary>
        //   /// <param name="orderId">訂單ID</param>
        //   /// <returns></returns>
        //   public Models.cus GetOrderById(int? orderId)
        //   {
        //       Models.cus result = new cus();

        //       DataTable dt = new DataTable();
        //       String sql = @"SELECT OrderID,o.CustomerID,o.EmployeeID,c.CompanyName,LastName+' '+FirstName AS EmpName,convert(char(10),OrderDate,111) AS OrderDate,convert(char(10),OrderDate,111) AS RequiredDate,convert(char(10),ShippedDate,111) AS ShippedDate,o.ShipperID,ship.CompanyName AS ShipperName,Freight,ShipName,ShipAddress,ShipCity,ShipCountry,ShipPostalCode,ShipRegion
        //                  FROM [Sales].[Orders] AS o                           
        //               JOIN [Sales].[Customers] AS c
        //               ON o.CustomerID=c.CustomerID
        //JOIN [HR].[Employees] AS e
        //ON o.EmployeeID=e.EmployeeID
        //JOIN [Production].[Suppliers] AS ship
        //ON o.[ShipperID]=ship.SupplierID
        //                  WHERE o.[OrderID]=@OrderId";

        //       using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
        //       {
        //           conn.Open();
        //           SqlCommand cmd = new SqlCommand(sql, conn);
        //           cmd.Parameters.Add(new SqlParameter("@OrderId", orderId));
        //           SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
        //           sqlAdapter.Fill(dt);
        //           conn.Close();
        //       }

        //       foreach (DataRow dr in dt.Rows)
        //       {
        //           result.OrderId = Convert.ToInt32(dr["OrderID"]);
        //           result.CustId = Convert.ToInt32(dr["CustomerID"]);
        //           result.EmpId = Convert.ToInt32(dr["EmployeeID"]);
        //           result.CompanyName = Convert.ToString(dr["CompanyName"]);
        //           result.EmpName = Convert.ToString(dr["EmpName"]);
        //           result.ShipperId = Convert.ToInt32(dr["ShipperID"]);
        //           result.ShipperName = Convert.ToString(dr["ShipperName"]);
        //           result.OrderDate = Convert.ToString(dr["OrderDate"]);
        //           result.RequireDate = Convert.ToString(dr["RequiredDate"]);
        //           result.ShippedDate = Convert.ToString(dr["ShippedDate"]);
        //           result.Freight = Convert.ToInt32(dr["Freight"]);
        //           result.ShipName = Convert.ToString(dr["ShipName"]);
        //           result.ShipAddress = Convert.ToString(dr["ShipAddress"]);
        //           result.ShipCity = Convert.ToString(dr["ShipCity"]);
        //           result.ShipRegion = Convert.ToString(dr["ShipRegion"]);
        //           result.ShipPostalCode = Convert.ToString(dr["ShipPostalCode"]);
        //           result.ShipCountry = Convert.ToString(dr["ShipCountry"]);

        //       }
        //       return result;
        //   }

        //   /// <summary>
        //   /// 取得訂單列表
        //   /// </summary>
        //   /// <returns></returns>
        //   public List<cus> GetOrders()
        //   {
        //       List<cus> result = new List<cus>();
        //       DataTable dt = new DataTable();
        //       String sql = @"SELECT OrderID,c.CompanyName,LastName+' '+FirstName AS EmpName,ship.CompanyName AS ShipperName,convert(char(10),OrderDate,111) AS OrderDate,convert(char(10),OrderDate,111) AS RequiredDate,convert(char(10),ShippedDate,111) AS ShippedDate
        //                  FROM [Sales].[Orders] AS o                           
        //               JOIN [Sales].[Customers] AS c
        //               ON o.CustomerID=c.CustomerID
        //JOIN [HR].[Employees] AS e
        //ON o.EmployeeID=e.EmployeeID
        //JOIN [Production].[Suppliers] AS ship
        //ON o.[ShipperID]=ship.SupplierID";

        //       using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
        //       {
        //           conn.Open();
        //           SqlCommand cmd = new SqlCommand(sql, conn);
        //           SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
        //           sqlAdapter.Fill(dt);
        //           conn.Close();
        //       }

        //       result = (from i in dt.AsEnumerable()
        //                 select new cus()
        //                 {
        //                     OrderId = i.Field<int>("OrderID"),
        //                     CompanyName = i.Field<string>("CompanyName"),
        //                     EmpName = i.Field<string>("EmpName"),
        //                     ShipperName = i.Field<string>("ShipperName"),
        //                     OrderDate = i.Field<string>("OrderDate"),
        //                     RequireDate = i.Field<string>("RequiredDate"),
        //                     ShippedDate = i.Field<string>("ShippedDate")

        //                 }).ToList<cus>();

        //       return result;
        //   }
        //   
        //   /// <summary>
        //   /// 取得員工下拉式選單資料
        //   /// </summary>
        //   /// <returns></returns>
        //   public List<cus> GetEmpDropListItem()
        //   {
        //       List<Models.cus> MapResult = new List<cus>();
        //       DataTable dt = new DataTable();
        //       String sql = @"SELECT EmployeeID,LastName+' '+FirstName AS EmpName
        //                  FROM [HR].[Employees]
        //                  SELECT ShipperID,CompanyName AS ShipperName
        //                  FROM [Sales].[Shippers]";

        //       using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
        //       {
        //           conn.Open();
        //           SqlCommand cmd = new SqlCommand(sql, conn);
        //           SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
        //           sqlAdapter.Fill(dt);
        //           conn.Close();
        //       }

        //       foreach (DataRow Row in dt.Rows)
        //       {
        //           MapResult.Add(new cus()
        //           {
        //               EmpId = (int)Row["EmployeeID"],
        //               EmpName = Row["EmpName"].ToString()
        //           }
        //           );
        //       }
        //       return MapResult;
        //   }

        //   /// <summary>
        //   /// 取得出貨公司下拉式選單資料
        //   /// </summary>
        //   /// <returns></returns>
        //   public List<cus> GetShipDropListItem()
        //   {
        //       List<Models.cus> MapResult = new List<cus>();
        //       DataTable dt = new DataTable();
        //       String sql = @"SELECT ShipperID,CompanyName AS ShipperName
        //                  FROM [Sales].[Shippers]";

        //       using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
        //       {
        //           conn.Open();
        //           SqlCommand cmd = new SqlCommand(sql, conn);
        //           SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
        //           sqlAdapter.Fill(dt);
        //           conn.Close();
        //       }

        //       foreach (DataRow Row in dt.Rows)
        //       {
        //           MapResult.Add(new cus()
        //           {
        //               ShipperId = (int)Row["ShipperID"],
        //               ShipperName = Row["ShipperName"].ToString()
        //           }
        //           );
        //       }
        //       return MapResult;
        //   }

        //   /// <summary>
        //   /// 暫無用到的map
        //   /// </summary>
        //   /// <param name="OrderData"></param>
        //   /// <returns></returns>
        //   public List<Models.cus> MapOrderDropListData(DataTable OrderData)
        //   {
        //       List<Models.cus> MapResult = new List<cus>();
        //       foreach (DataRow Row in OrderData.Rows)
        //       {
        //           MapResult.Add(new cus()
        //           {
        //               CustId = (int)Row["CustomerID"],
        //               CompanyName = Row["CompanyName"].ToString(),
        //               EmpId = (int)Row["EmployeeID"],
        //               EmpName = Row["EmpName"].ToString(),
        //               Freight = (int)Row["Freight"],
        //               OrderDate = Row["OrderDate"].ToString(),
        //               OrderId = (int)Row["OrderID"],
        //               RequireDate = Row["RequireDate"].ToString(),
        //               ShipAddress = Row["ShipAddress"].ToString(),
        //               ShipCity = Row["ShipCity"].ToString(),
        //               ShipCountry = Row["ShipCountry"].ToString(),
        //               ShipName = Row["ShipName"].ToString(),
        //               ShippedDate = Row["ShippedDate"].ToString(),
        //               ShipperId = (int)Row["ShipperID"],
        //               ShipperName = Row["ShipperName"].ToString(),
        //               ShipPostalCode = Row["ShipPostalCode"].ToString(),
        //               ShipRegion = Row["ShipRegion"].ToString()
        //           }
        //           );
        //       }
        //       return MapResult;
        //   }
    }
}

   

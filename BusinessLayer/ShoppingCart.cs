using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace OnlineShoppingWebApp.BusinessLayer
{
    public class ShoppingCart : System.Web.UI.Page, IDisposable
    {

        public string CategoryName;
        public int CategoryID;
        public int ProductID;
        public int CustomerID;

        public string ProductName;
        public string ProductImage;
        public string ProductPrice;
        public string ProductDescription;

        public string CustomerName;
        public string CustomerEmailID;
        public string CustomerPhoneNo;
        public string CustomerAddress;
        public string ProductList;
        public string PaymentMethod;

        public string OrderStatus;
        public string OrderNo;

        public int ProductQuantity;
        public int TotalProducts;
        public int TotalPrice;
        public int StockType;
        public int Flag;


        void IDisposable.Dispose()
        {

        }

        //Add new Category to the Datatable
        public void AddNewCategory()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParameter("@CategoryName", CategoryName, System.Data.SqlDbType.VarChar, 200);
            DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_AddNewCategory", parameters);
        }

        //Add new Product to the Datatable
        public void AddNewProduct()
        {
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = DataLayer.DataAccess.AddParameter("@ProductName", ProductName, System.Data.SqlDbType.VarChar, 300);
            parameters[1] = DataLayer.DataAccess.AddParameter("@ProductPrice", ProductPrice, System.Data.SqlDbType.Int, 100);
            parameters[2] = DataLayer.DataAccess.AddParameter("@ProductImage", ProductImage, System.Data.SqlDbType.VarChar, 500);
            parameters[3] = DataLayer.DataAccess.AddParameter("@ProductDescription", ProductDescription, System.Data.SqlDbType.VarChar, 1000);
            parameters[4] = DataLayer.DataAccess.AddParameter("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 100);
            parameters[5] = DataLayer.DataAccess.AddParameter("@ProductQuantity", TotalProducts, System.Data.SqlDbType.Int, 100);

            DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_AddNewProduct", parameters);

        }

        //Getting all the products by CategoryID
        public DataTable GetAllProducts()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParameter("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 20);
            DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_GetAllProducts", parameters);
            return dt;
        }

        //Method to delete products from Products table by using ProductID

        public DataTable DeleteProducts()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParameter("@ProductID", ProductID, System.Data.SqlDbType.Int, 20);
            DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_DeleteProducts", parameters);
            return dt;
        }
        //Get Products searching by Name
        public DataTable GetAllProductsBySearch()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParameter("@ProductName", ProductName, System.Data.SqlDbType.VarChar, 100);
          //  parameters[1] = DataLayer.DataAccess.AddParameter("@CategoryName", CategoryName, System.Data.SqlDbType.VarChar, 100);
            DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_GetAllProductsBySearch", parameters);
            return dt;
        }

        //Getting all the Categories from Datatable
        public DataTable GetCategories()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_GetAllCategories", parameters);
            return dt;
        }

        //Getting MaxOrderId from OrderDetails table
        //public string GetMaxOrderId()
        //{
        //  //  string s = "";
        //    SqlParameter[] parameters = new SqlParameter[0];
        //    DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_GetMaxOrderId", parameters);

        //    string currentOrderId = "";

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        currentOrderId = dr["OrderId"].ToString();
        //    }


        //    Session["currentOrderId"] = currentOrderId;

        //    return currentOrderId;
        //}
        //Saves Customer details to the Datatable
        internal DataTable SaveCustomerDetails()
        {
            SqlParameter[] parameters = new SqlParameter[8];
            parameters[0] = DataLayer.DataAccess.AddParameter("@CustomerName", CustomerName, System.Data.SqlDbType.VarChar, 100);
            parameters[1] = DataLayer.DataAccess.AddParameter("@CustomerEmailID", CustomerEmailID, System.Data.SqlDbType.VarChar, 100);
            parameters[2] = DataLayer.DataAccess.AddParameter("@CustomerPhoneNo", CustomerPhoneNo, System.Data.SqlDbType.VarChar, 12);
            parameters[3] = DataLayer.DataAccess.AddParameter("@CustomerAddress", CustomerAddress, System.Data.SqlDbType.VarChar, 500);
            parameters[4] = DataLayer.DataAccess.AddParameter("@TotalProducts", TotalProducts, System.Data.SqlDbType.Int, 100);
            parameters[5] = DataLayer.DataAccess.AddParameter("@TotalPrice", TotalPrice, System.Data.SqlDbType.Int, 100);
            parameters[6] = DataLayer.DataAccess.AddParameter("@PaymentMethod", PaymentMethod, System.Data.SqlDbType.VarChar, 100);
            parameters[7] = DataLayer.DataAccess.AddParameter("@ProductName", ProductName, System.Data.SqlDbType.VarChar, 100);

            DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_SaveCustomerDetails", parameters);

            return dt;
        }

        //Add Orders to the DataTable
        internal DataTable AddOrders()
        {
            SqlParameter[] parameters = new SqlParameter[4];

            parameters[0] = DataLayer.DataAccess.AddParameter("@ProductID", ProductID, System.Data.SqlDbType.Int, 100);
            parameters[1] = DataLayer.DataAccess.AddParameter("@ProductName", ProductName, System.Data.SqlDbType.VarChar, 100);
            parameters[2] = DataLayer.DataAccess.AddParameter("@ProductQuantity", ProductQuantity, System.Data.SqlDbType.Int, 100);
            parameters[3] = DataLayer.DataAccess.AddParameter("@ProductPrice", ProductPrice, System.Data.SqlDbType.VarChar, 10);
            //  parameters[4] = DataLayer.DataAccess.AddParameter("@OrderDateTime", dateTime, System.Data.SqlDbType.DateTime, 100);
            //  parameters[5] = DataLayer.DataAccess.AddParameter("@OrderShipped", order.OrderShipped, System.Data.SqlDbType.VarChar, 100);

            DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_AddOrders", parameters);

            return dt;
        }

        //Save Order details to the DataTable
        internal DataTable SaveOrderDetails(Order1 order1)
        {
            SqlParameter[] parameters = new SqlParameter[9];
            parameters[0] = DataLayer.DataAccess.AddParameter("@UserName", order1.Username, System.Data.SqlDbType.VarChar, 100);
            parameters[1] = DataLayer.DataAccess.AddParameter("@FirstName", order1.FirstName, System.Data.SqlDbType.VarChar, 100);
            parameters[2] = DataLayer.DataAccess.AddParameter("@LastName", order1.LastName, System.Data.SqlDbType.VarChar, 50);
            parameters[3] = DataLayer.DataAccess.AddParameter("@Address", order1.Address, System.Data.SqlDbType.VarChar, 500);
            parameters[4] = DataLayer.DataAccess.AddParameter("@City", order1.City, System.Data.SqlDbType.VarChar, 100);
            parameters[5] = DataLayer.DataAccess.AddParameter("@State", order1.State, System.Data.SqlDbType.VarChar, 100);
            parameters[6] = DataLayer.DataAccess.AddParameter("@PostalCode", order1.PostalCode, System.Data.SqlDbType.VarChar, 100);
            parameters[7] = DataLayer.DataAccess.AddParameter("@Country", order1.Country, System.Data.SqlDbType.VarChar, 100);
            parameters[8] = DataLayer.DataAccess.AddParameter("@CustomerEmailAddress", order1.Email, System.Data.SqlDbType.VarChar, 100);

            DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_SaveOrderDetails", parameters);

            return dt;
        }

        //public void  UpdateOrderDetails(int OrderId, string PaymentTransactionId)
        //{
        //    SqlParameter[] parameters = new SqlParameter[2];
        
        //    parameters[0] = DataLayer.DataAccess.AddParameter("@OrderId", OrderId, System.Data.SqlDbType.Int, 20);

        //    parameters[1] = DataLayer.DataAccess.AddParameter("@PaymentTransactionId", PaymentTransactionId, System.Data.SqlDbType.nchar, 30);

        //    DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_UpdateOrderDetails", parameters);

        
        //}
       
      
        internal DataTable SaveCustomerProducts()
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = DataLayer.DataAccess.AddParameter("@CustomerID", CustomerID, System.Data.SqlDbType.Int, 20);

            parameters[1] = DataLayer.DataAccess.AddParameter("@ProductID", ProductID, System.Data.SqlDbType.Int, 10);

            parameters[2] = DataLayer.DataAccess.AddParameter("@TotalProduct", TotalProducts, System.Data.SqlDbType.Int, 10);

        

            DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_SaveCustomerProducts", parameters);

            return dt;
        }


        //Get OrderDetails by ID
        internal DataTable GetOrdersList()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParameter("@Flag", Flag, System.Data.SqlDbType.Int, 20);
            DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_GetOrdersList", parameters);

            return dt;
        }


        //Get TransactionDetails from DataTable
        internal DataTable GetTransactionDetails()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParameter("@TransactionNo", Flag, System.Data.SqlDbType.Int, 20);
            DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_GetTransactionDetails", parameters);

            return dt;
        }


        //Get Order status and set delivery status 
        internal DataTable GetSetOrderStatus()
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = DataLayer.DataAccess.AddParameter("@TransactionNo", Convert.ToInt32(OrderNo), System.Data.SqlDbType.Int, 20);

            parameters[1] = DataLayer.DataAccess.AddParameter("@OrderStatus", OrderStatus, System.Data.SqlDbType.VarChar, 300);

            parameters[2] = DataLayer.DataAccess.AddParameter("@Flag", Flag, System.Data.SqlDbType.Int, 10);

            DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_OrderStatus", parameters);

            return dt;
        }


        //Get available stock from Datatable
        internal DataTable GetAvailableStock()
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = DataLayer.DataAccess.AddParameter("@StockType", StockType, System.Data.SqlDbType.Int, 10);

            parameters[1] = DataLayer.DataAccess.AddParameter("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 10);

            DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_GetAvailableStock", parameters);

            return dt;
        }


        //Get Income report
        internal DataTable GetIncomeReport()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParameter("@ReportType", Flag, System.Data.SqlDbType.Int, 10);
            DataTable dt = DataLayer.DataAccess.ExcuteDTByProcedure("SP_GetIncomeReport", parameters);

            return dt;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingWebApp.BusinessLayer
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
    //    public string Client { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductPrice { get; set; }
        public DateTime dateTime { get; set; }
     //   public bool OrderShipped { get; set; }

        public Order(int id, int productID,  string productName, int productQuantity, int productPrice, DateTime date )
        {
            ProductID = productID;
         //   Client = client;
            ProductName = productName;
            ProductQuantity = productQuantity;
            ProductPrice = productPrice;
            dateTime = date;
          //  OrderShipped = orderShipped;

        }

        public Order( int productID,  string productName, int productQuantity, int productPrice, DateTime date)
        {
            ProductID = productID;
         //   Client = client;
            ProductName = productName;
            ProductQuantity = productQuantity;
            ProductPrice = productPrice;
            dateTime = date;
        //    OrderShipped = orderShipped;

        }
    }
}
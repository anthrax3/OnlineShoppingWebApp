using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingWebApp.BusinessLayer
{
    public class OrderDetail
    {
      //  public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public string Username { get; set; }

        public int ProductID { get; set; }

        public int ProductQuantity { get; set; }

        public int ProductPrice { get; set; }
    }
}
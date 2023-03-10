using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class Delete_Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string deletedProductID = Request.QueryString.Get("id");
            string deletedProductIDInCookies = deletedProductID + ",";
            string cartCookies = Request.Cookies["cart"].Value;
            int deletedProductIDPositionInCookies = cartCookies.IndexOf(deletedProductID);
            string newCookiesAfterDeletedProduct = cartCookies.Remove(deletedProductIDPositionInCookies, deletedProductIDInCookies.Length);
                                                                      //vị trí bắt đầu                   //Xóa bao nhiêu kí tự (bằng id + ,)
            Response.Cookies["cart"].Value = newCookiesAfterDeletedProduct;
            Response.Cookies["cart"].Expires = DateTime.Now.AddDays(12);
            Response.Redirect("Cart.aspx");
        }
    }
}
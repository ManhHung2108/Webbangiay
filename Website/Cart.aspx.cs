using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void displayUserInformation()
        {
            // Hiển thị thông tin người dùng
            if (Session["login"].ToString() == "1")
            {
                string username = Session["username"].ToString();

                login_status_desktop.InnerHtml = "<li>Chào " + username + "</li>" +
                                                 "<span>|</span>" +
                                                 "<li><a href='signOut.aspx'>Đăng xuất</a></li>";

                login_status_mobile.InnerHtml = "<li>Chào " + username + "</li>" +
                                                "<li class='signOut-mobile'><a href='signOut.aspx'><img src='./Images/Icons/LogOut.svg' alt=''></a></li>";
            }
        }
        protected string displayCartNumber()
        {
            // Hiển thị số giỏ hàng
            if (Request.Cookies["cart"] != null)
            {
                string[] cartProductsID = Request.Cookies["cart"].Value.Split(',');
                // -1 chuỗi trống sau chuỗi cuối cùng,
                Cart_Total_Products.InnerText = (cartProductsID.Length - 1).ToString();
                Cart_Total_Products_Mobile.InnerText = (cartProductsID.Length - 1).ToString();
                return (cartProductsID.Length - 1).ToString(); ;
            }
            else
            {
                Cart_Total_Products.InnerText = "0";
                Cart_Total_Products_Mobile.InnerText = "0";
                return "0";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            displayUserInformation();
            displayCartNumber();

            //========= Hiển thị nội dung trang

            //Trưng bày sản phẩm
            if (Request.Cookies["cart"] != null)
            {
                List<ProductsList> cartList = new List<ProductsList>();
                List<ProductsList> productsLists = (List<ProductsList>)Application["productsList"];
                string[] productsID = Request.Cookies["cart"].Value.Split(',');
                foreach (string productID in productsID)
                {
                    foreach (ProductsList product in productsLists)
                    {
                        if (product.id == productID)
                        {
                            cartList.Add(product);
                        }
                    }
                }

                ListViewCart.DataSource = cartList;
                ListViewCart.DataBind();

                //Hiển thị tổng số sản phẩm
                total_products.InnerText = displayCartNumber();

                //Hiển thị giá sản phẩm
                int productsPrice = 0;
                foreach (ProductsList product in cartList) productsPrice += Int32.Parse(product.price);
                products_price.InnerHtml = $"{productsPrice} <span class='cart__product-price-unit'>đ</span>";

                //Hiển thị giá giao hàng
                const int DELIVERY = 50000;
                delivery_price.InnerHtml = $"{DELIVERY} <span class='cart__product-price-unit'>đ</span>";

                //Hiển thị tổng giá đơn đặt hàng
                int orderTotal = productsPrice + DELIVERY;
                order_total_price.InnerHtml = $"{orderTotal} <span class='cart__product-price-unit'>đ</span>";
            }
        }
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = "";

            if (search_text.Value != "")
            {
                searchText = search_text.Value.ToLower();
            }
            else if (search_text_mobile.Value != "")
            {
                searchText = search_text_mobile.Value.ToLower();
            }

            Response.Redirect($"all_products.aspx?search={searchText}");
        }

    }
}
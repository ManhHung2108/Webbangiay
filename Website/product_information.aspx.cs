﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class product_information : System.Web.UI.Page
    {
        protected void displayUserInformation()
        {
            //Hiển thị thông tin người dùng
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
        protected void displayCartNumber()
        {
            //Hiển thị số giỏ hàng
            if (Request.Cookies["cart"] != null)
            {
                string[] cartProductsID = Request.Cookies["cart"].Value.Split(',');
                //-1 chuỗi trống sau chuỗi cuối cùng,
                Cart_Total_Products.InnerText = (cartProductsID.Length - 1).ToString();
                Cart_Total_Products_Mobile.InnerText = (cartProductsID.Length - 1).ToString();
            }
            else
            {
                Cart_Total_Products.InnerText = "0";
                Cart_Total_Products_Mobile.InnerText = "0";
            }    
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString.Get("id");
  
            if (id != null)
            {
                displayUserInformation();
                displayCartNumber();

                //Hiển thị nội dung trang              
                string pageTitle = "";

                // Hiển thị thông tin sản phẩm
                List<ProductsList> productsList = (List<ProductsList>)Application["productsList"];
                List<ProductsList> productInformation = new List<ProductsList>();
                foreach (ProductsList product in productsList)
                {
                    if (id == product.id)
                    {
                        productInformation.Add(product);
                        pageTitle = product.name;
                    }
                }
                //Đẩy code sang Lisview bên html
                ListViewProductInformation1.DataSource = productInformation;
                ListViewProductInformation1.DataBind();
                ListViewProductInformation2.DataSource = productInformation;
                ListViewProductInformation2.DataBind();

                //Hiển thị màu sắc sản phẩm
                List<ProductsList> productColors = new List<ProductsList>();
                //Nhận productID không có phần màu, ví dụ: "1.1" -> "1", "12.1" -> "12"
                string currentProductIDBeforeDot = id.Substring(0, id.Length - 2);
                foreach(ProductsList product in productsList)
                {
                    //So sánh với productID không có màu từ danh sách
                    string productIDBeforeDot = product.id.Substring(0, product.id.Length - 2);
                    if (currentProductIDBeforeDot == productIDBeforeDot)
                    {
                        productColors.Add(product);
                    }
                }

                ListViewProductColors.DataSource = productColors;
                ListViewProductColors.DataBind();

                //Thay đổi tiêu đề trang
                Page.Title = pageTitle;
            }
            else
                Response.Redirect("index.aspx");   
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

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString.Get("id");

            //Lưu trữ giỏ hàng vào cookie
            if (Request.Cookies["cart"] == null)
            {
                Response.Cookies["cart"].Value = $"{id},";
                Response.Cookies["cart"].Expires = DateTime.Now.AddDays(14);
            }
            else
            {
                //Lưu trữ cookie theo productID, ví dụ: 1,2,3,40,50, ...
                Response.Cookies["cart"].Value = Request.Cookies["cart"].Value + $"{id},";
                Response.Cookies["cart"].Expires = DateTime.Now.AddDays(14);
            }

            //Làm mới để cập nhật số giỏ hàng
            Response.Redirect(Request.Url.ToString());
        }
    }
}
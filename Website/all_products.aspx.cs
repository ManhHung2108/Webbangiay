using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class all_products : System.Web.UI.Page
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
                // -1 chuỗi trống sau chuỗi cuối cùng,
                Cart_Total_Products.InnerText = (cartProductsID.Length - 1).ToString();
                Cart_Total_Products_Mobile.InnerText = (cartProductsID.Length - 1).ToString();
            }
            else
            {
                Cart_Total_Products.InnerText = "0";
                Cart_Total_Products_Mobile.InnerText = "0";
            }   
        }

        protected void getProductsListByTypeAndFilter(string type, int begin, int end, List<ProductsList> productsListsByTypeAndFilter, List<ProductsList> productsLists)
        {
            foreach (ProductsList product in productsLists)
            {
                if (type == product.type && Int32.Parse(product.price) >= begin && Int32.Parse(product.price) <= end)
                {
                    productsListsByTypeAndFilter.Add(product);
                }
            }
            ListViewAllProducts.DataSource = productsListsByTypeAndFilter;
            ListViewAllProducts.DataBind();
        }

        protected void getProductsListBySearchAndFilter(string search, int begin, int end, List<ProductsList> productsListsBySearchAndFilter, List<ProductsList> productsLists)
        {
            foreach (ProductsList product in productsLists)
            {
                if (product.name.ToLower().IndexOf(search) != - 1 && Int32.Parse(product.price) >= begin && Int32.Parse(product.price) <= end)
                {
                    productsListsBySearchAndFilter.Add(product);
                }
            }
            ListViewAllProducts.DataSource = productsListsBySearchAndFilter;
            ListViewAllProducts.DataBind();
        }

        protected string totalProducts(List<ProductsList> productsListsByTypeAndFilter)
        {
            int total = 0;
            foreach (ProductsList product in productsListsByTypeAndFilter)
                total++;
            return total.ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.QueryString.Get("type");        //lay tren url 
            string search = Request.QueryString.Get("search");    //lấy trên thanh url
            string filter = Request.QueryString.Get("filter");    //lấy trên thanh url

            if (type != null || search != null)
            {
                displayUserInformation();
                displayCartNumber();
                List<ProductsList> productsLists = (List<ProductsList>)Application["productsList"];
                

                if (type != null)
                {
                    //======Hiển thị nội dung trang
                    //Trưng bày sản phẩm
                    type = type.ToLower(); 

                    if (type == "nike" || type == "adidas" || type == "puma") //type chỉ đc bằng 3 giá trị này trên menu
                    {
                        //Thay đổi tiêu đề trang
                        Page.Title = type.ToUpper();
                        //Tạo danh sách sản phẩm
                        List<ProductsList> productsListByTypeAndFilter = new List<ProductsList>();
                        //Filter
                        if (filter != null)
                        {
                            if (filter == "01")
                            {
                                getProductsListByTypeAndFilter(type, 0, 1000000, productsListByTypeAndFilter, productsLists);
                                all_products_brand_name.InnerText = $"{type} Dưới 1 triệu ({totalProducts(productsListByTypeAndFilter)})";
                            }

                            if (filter == "02")
                            {
                                getProductsListByTypeAndFilter(type, 1000000, 3000000, productsListByTypeAndFilter, productsLists);
                                all_products_brand_name.InnerText = $"{type} Từ 1 - 3 triệu ({totalProducts(productsListByTypeAndFilter)})";
                            }

                            if (filter == "03")
                            {
                                getProductsListByTypeAndFilter(type, 3000000, 999999999, productsListByTypeAndFilter, productsLists);
                                all_products_brand_name.InnerText = $"{type} Trên 3 triệu ({totalProducts(productsListByTypeAndFilter)})";
                            }
                        }
                        else
                        {
                            getProductsListByTypeAndFilter(type, 0, 999999999, productsListByTypeAndFilter, productsLists);
                            all_products_brand_name.InnerText = $"{type} ({totalProducts(productsListByTypeAndFilter)})";
                        }
                    }                  
                }
                else if(search != null) { //xử lý thanh url seach 57
                    //======Nội dung trang hiển thị
                    //Sản phẩm trưng bày
                    search = search.ToLower();

                    //Thay đổi tiêu đề trang
                    Page.Title = "Tìm kiếm";

                    //Tạo danh sách sản phẩm
                    List<ProductsList> productsListBySearchAndFilter = new List<ProductsList>();

                    if (filter != null)
                    {
                        if (filter == "01")
                        {
                            getProductsListBySearchAndFilter(search, 0, 1000000, productsListBySearchAndFilter, productsLists);
                            all_products_brand_name.InnerText = $"Kết quả tìm kiếm cho '{search}' Dưới 1 triệu ({totalProducts(productsListBySearchAndFilter)})";
                        }

                        if (filter == "02")
                        {
                            getProductsListBySearchAndFilter(search, 1000000, 3000000, productsListBySearchAndFilter, productsLists);
                            all_products_brand_name.InnerText = $"Kết quả tìm kiếm cho '{search}' Từ 1 - 3 triệu ({totalProducts(productsListBySearchAndFilter)})";
                        }

                        if (filter == "03")
                        {
                            getProductsListBySearchAndFilter(search, 3000000, 999999999, productsListBySearchAndFilter, productsLists);
                            all_products_brand_name.InnerText = $"Kết quả tìm kiếm cho '{search}' Trên 3 triệu ({totalProducts(productsListBySearchAndFilter)})";
                        }
                    }
                    else
                    {
                        getProductsListBySearchAndFilter(search, 0, 999999999, productsListBySearchAndFilter, productsLists);
                        all_products_brand_name.InnerText = $"Kết quả tìm kiếm cho '{search}' ({totalProducts(productsListBySearchAndFilter)})";
                    }
                }


                //Thêm bộ lọc href
                string currentUrl = Request.Url.ToString();
                int andSignPosition = currentUrl.IndexOf('&');  //tìm & trong chuỗi
                if(andSignPosition != -1)
                {
                    //Avoid multiple filter if already having a filter, ex: example.aspx?type=nike&filter=01&filter=02,...
                    string currentUrlWithOutFilter = currentUrl.Substring(0, andSignPosition); //từ 0 cho đến &
                    Filter_01.HRef = $"{currentUrlWithOutFilter}&filter=01";
                    Filter_02.HRef = $"{currentUrlWithOutFilter}&filter=02";
                    Filter_03.HRef = $"{currentUrlWithOutFilter}&filter=03";
                }
                else
                {
                    Filter_01.HRef = $"{currentUrl}&filter=01";
                    Filter_02.HRef = $"{currentUrl}&filter=02";
                    Filter_03.HRef = $"{currentUrl}&filter=03";
                }
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

            Response.Redirect($"all_products.aspx?search={searchText}"); //để ý trên thanh url
        }
    }
}
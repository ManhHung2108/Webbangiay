<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Website.index" %>

    <!DOCTYPE aspx>

    <aspx xmlns="http://www.w3.org/1999/xaspx">

        <head runat="server">
            <meta charset="UTF-8" />
            <meta name="viewport" content="width=device-width, initial-scale=1.0" />
            <link rel="stylesheet" href="./styles/global.css" />
            <link rel="stylesheet" href="./styles/products_wrapper.css" />
            <link rel="stylesheet" href="./styles/index.css" />
            <link rel="preconnect" href="https://fonts.gstatic.com" />
            <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;700&display=swap" rel="stylesheet" />
            <title>Trang Chủ</title>
        </head>

        <body>
            <form id="form1" runat="server">
                <div class="header">
                    <div class="header__top">
                        <div class="header__phone">
                            <img src="./Images/Icons/Phone.png" alt="">
                            <p>012-345-6789</p>
                        </div>

                        <div class="header__user-menu">
                            <ul class="header__user-menu-desktop" runat="server" id="login_status_desktop">
                                <!-- Nếu chưa đăng nhập-->
                                <li><a href="signIn.aspx">Đăng nhập</a></li>
                                <span>|</span>
                                <!-- Nếu đã đăng nhập, hãy thay đổi đăng nhập thành tên người dùng và đăng ký thành đăng xuất  -->
                                <li><a href="signUp.aspx">Đăng ký</a></li>
                            </ul>

                            <ul class="header__user-menu-mobile" runat="server" id="login_status_mobile">
                                <!-- Nếu chưa đăng nhập -->
                                <li><a href="signIn.aspx">Đăng nhập</a></li>
                                <span>|</span>
                                <li><a href="signUp.aspx">Đăng ký</a></li>
                                <!-- Nếu đã đăng nhập, hãy thay đổi đăng nhập Đăng nhập vào tên người dùng, đăng ký vào biểu tượng, xóa span -->
                                <!-- Hiển thị trong aspx phía máy chủ -->
                                <!-- <li class="signOut-mobile"><a href="signOut.aspx"><img src="./Images/Icons/LogOut.svg" alt=""></a></li> -->
                            </ul>
                        </div>
                    </div>
                    <div class="header__main">
                        <div class="header__logo">
                            <a class="logo" href="index.aspx"><img src="./Images/Logo.png" alt=""></a>
                            <a class="brand" href="index.aspx">
                                SMOKE STORE
                            </a>
                        </div>
                        <div class="header__menu">
                            <ul>
                                <li><a href="all_products.aspx?type=nike">Nike</a></li>
                                <li><a href="all_products.aspx?type=adidas">Adidas</a></li>
                                <li><a href="all_products.aspx?type=puma">Puma</a></li>
                            </ul>
                        </div>

                        <div class="header__icons">
                            <div class="header__search">
                                <img src="./Images/Icons/Search.png" alt="">
                                <input type="text" name="search" placeholder="Search" runat="server" id="search_text">
                                <button type="button" runat="server" id="search_button" onserverclick="SearchButton_Click">Tìm</button>
                            </div>

                            <div class="header__cart">
                                <div class="cart__status">
                                    <p class="cart__number" runat="server" id="Cart_Total_Products"></p>
                                </div>
                                <a href="cart.aspx">
                                    <img src="./Images/Icons/Cart.svg" alt="">
                                </a>
                            </div>
                        </div>

                        <div class="header__mobile">
                            <div class="mobile__menu">
                                <div class="header__cart-mobile">
                                    <div class="cart__status">
                                        <p class="cart__number" runat="server" id="Cart_Total_Products_Mobile">0</p>
                                    </div>
                                    <a href="cart.aspx">
                                        <img src="./Images/Icons/Cart.svg" alt="">
                                    </a>
                                </div>
                                <div class="mobile__menu-burger">
                                    <div class="line-1"></div>
                                    <div class="line-2"></div>
                                    <div class="line-3"></div>
                                </div>
                            </div>
                            <div class="mobile__sub-menu">
                                <!-- Sao chép từ bên trên, kế thừa tất cả style -->
                                <div class="header__menu-mobile">
                                    <ul>
                                        <li><a href="all_products.aspx?type=nike">Nike</a></li>
                                        <li><a href="all_products.aspx?type=adidas">Adidas</a></li>
                                        <li><a href="all_products.aspx?type=puma">Puma</a></li>
                                    </ul>
                                </div>
                                <div class="header__icons-mobile">
                                    <div class="header__search-mobile">
                                        <img src="./Images/Icons/Search.png" alt="">
                                        <input type="text" name="search" placeholder="Search" runat="server" id="search_text_mobile">
                                        <button type="button" runat="server" id="search_button_mobile" onserverclick="SearchButton_Click">Tìm</button>
                                    </div>
                                </div>
                                <!-- Kết thúc copy -->
                            </div>
                        </div>
                    </div>
                </div>

                <div class="index-page-content">
                    <div class="slider">
                        <div class="slider__wrapper">
                            <div class="slider__images-container">
                                <img src="./Images/Nike/Nike_Banner.jpg" alt="">
                                <img src="./Images/Adidas/Adidas_Banner.jpg" alt="">
                                <img src="./Images/Puma/Puma_Banner.jpg" alt="">
                            </div>
                        </div>
                        <div class="slider__content">
                            <div class="slider__heading">
                                <h1>SMOKE STORE</h1>
                                <p>Giày thể thao chính hãng</p>
                            </div>
                            <!--<div class="slider__button">
                                <a href="#">Giày Nam</a>
                                <a href="#">Giày Nữ</a>
                            </div>-->
                        </div>
                        <div class="slider__circles">                  
                            <div class="slider__circle active"></div>  <!--dấu tròn chuyển slide -->
                            <div class="slider__circle"></div>
                            <div class="slider__circle"></div>
                        </div>
                    </div>

                    <div class="products">
                        <div class="products__nike">
                            <div class="products__heading">
                                <h2 class="products__brand-name">Nike</h2>
                                <a href="all_products.aspx?type=nike">Xem thêm</a>
                            </div>

                            <div class="products__left-arrow"></div>

                            <div class="products__slide">
                                <div class="products__slide-wrapper">
                                    <asp:ListView ID="ListViewNikeSlideProducts" runat="server">
                                        <ItemTemplate>

                                            <div class="products__wrapper">
                                                <a href="product_information.aspx?id=<%# Eval("id") %>">
                                                    <img class="products__image" src="<%# Eval("img") %>" alt="">
                                                </a>
                                                <div class="products__content">
                                                    <h3 class="products__name"><%# Eval("name") %></h3>
                                                    <div class="products__colors">
                                                        <div class="products__color--white"></div>
                                                        <div class="products__color--black"></div>
                                                        <div class="products__color--red"></div>
                                                    </div>
                                                    <p class="products__price">Giá: <%# Eval("price") %> <span class="products__price-unit">đ</span></p>
                                                    <a class="products__button" href="product_information.aspx?id=<%# Eval("id") %>">Chi tiết</a>
                                                </div>
                                            </div>

                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>        
                            </div>
                            

                            <div class="products__right-arrow"></div>
                        </div>

                        <div class="products__adidas">
                            <div class="products__heading">
                                <h2 class="products__brand-name">Adidas</h2>
                                <a href="all_products.aspx?type=adidas">Xem thêm</a>
                            </div>

                            <div class="products__left-arrow"></div>

                            <div class="products__slide">
                                <div class="products__slide-wrapper">

                                    <asp:ListView ID="ListViewAdidasSlideProducts" runat="server">
                                        <ItemTemplate>

                                            <div class="products__wrapper">
                                                <a href="product_information.aspx?id=<%# Eval("id") %>">
                                                    <img class="products__image" src="<%# Eval("img") %>" alt="">
                                                </a>
                                                <div class="products__content">
                                                    <h3 class="products__name"><%# Eval("name") %></h3>
                                                    <div class="products__colors">
                                                        <div class="products__color--white"></div>
                                                        <div class="products__color--black"></div>
                                                        <div class="products__color--red"></div>
                                                    </div>
                                                    <p class="products__price">Giá: <%# Eval("price") %> <span class="products__price-unit">đ</span></p>
                                                    <a class="products__button" href="product_information.aspx?id=<%# Eval("id") %>">Chi tiết</a>
                                                </div>
                                            </div>

                                        </ItemTemplate>
                                    </asp:ListView>
                                    
                                </div>
                            </div>

                            <div class="products__right-arrow"></div>
                        </div>

                        <div class="products__puma">
                            <div class="products__heading">
                                <h2 class="products__brand-name">Puma</h2>
                                <a href="all_products.aspx?type=puma">Xem thêm</a>
                            </div>

                            <div class="products__left-arrow"></div>

                            <div class="products__slide">
                                <div class="products__slide-wrapper">
                                    <asp:ListView ID="ListViewPumaSlideProducts" runat="server">
                                        <ItemTemplate>
                                            <div class="products__wrapper">
                                                <a href="product_information.aspx?id=<%# Eval("id") %>">
                                                    <img class="products__image" src="<%# Eval("img") %>" alt="">
                                                </a>
                                                <div class="products__content">
                                                    <h3 class="products__name"><%# Eval("name") %></h3>
                                                    <div class="products__colors">
                                                        <div class="products__color--white"></div>
                                                        <div class="products__color--black"></div>
                                                        <div class="products__color--red"></div>
                                                    </div>
                                                    <p class="products__price">Giá: <%# Eval("price") %> <span class="products__price-unit">đ</span></p>
                                                    <a class="products__button" href="product_information.aspx?id=<%# Eval("id") %>">Chi tiết</a>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>
                            </div>
                            <div class="products__right-arrow"></div>
                        </div>
                    </div>
                </div>

                <div class="footer">
                    <div class="footer__contact">
                        <p>Số điện thoại: 091.333.333</p>
                        <p>Email: SmokeStore@gmail.com</p>
                    </div>
                    <div class="footer__branch">
                        <p>Chi nhánh 1: 96 Định Công - Hà Nội</p>
                        <p>Chi nhánh 2: 96 Định Công - Hà Nội</p>
                    </div>
                    <div class="footer__social">
                        <a href="https://www.facebook.com/171O2O17/" target="_blank"><img
                                src="./Images/Social/Facebook.svg" alt=""></a>
                        <a href="#"><img src="./Images/Social/Twitter.svg" alt=""></a>
                        <a href="#"><img src="./Images/Social/Instagram.svg" alt=""></a>
                    </div>
                    <a href="Thaydoithongtintaikhoan.aspx">Thay đổi tài khoản của bạn</a>
                </div>

                <script src="./scripts/global.js"></script>
                <script src="./scripts/index.js"></script>
            </form>
        </body>
    </aspx>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class Thaydoithongtintaikhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tentaikhoanmuonthaydoi = Session["username"].ToString();
            List<User> dstaikhoan = (List<User>)Application["user"];

            if (IsPostBack)
            {
                string matkhaumoi = Request.Form.Get("matkhaumoi");
                foreach (User taikhoan in dstaikhoan)
                {
                    if (taikhoan.username == tentaikhoanmuonthaydoi)
                    {
                        taikhoan.password = matkhaumoi;
                        break;
                    }
                }
            }

           
            foreach(User taikhoan in dstaikhoan)
            {
                if(taikhoan.username == tentaikhoanmuonthaydoi)
                {
                    usernamethi.InnerText = tentaikhoanmuonthaydoi;
                    passwordthi.InnerText = taikhoan.password;
                }    
            }    
        }
    }
}
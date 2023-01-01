<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Thaydoithongtintaikhoan.aspx.cs" Inherits="Website.Thaydoithongtintaikhoan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post">
        <div>
            <label>Username</label>
            <span id="usernamethi" runat="server"></span>
            <br />
            <label>Mật khẩu cũ</label>
            <span id ="passwordthi" runat="server"></span>
            <br />
            <label>Mật khẩu mới</label> 
            <span><input name ="matkhaumoi" type ="text"/></span>
            <button type="submit">Gửi</button>
            <br />
            <a href="index.aspx">Về trang chủ</a>
        </div>
    </form>
</body>
</html>

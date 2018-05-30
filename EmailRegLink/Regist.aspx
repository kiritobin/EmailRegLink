<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Regist.aspx.cs" Inherits="EmailRegLink.Regist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="名字"></asp:Label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </div>
            <asp:Label ID="Label2" runat="server" Text="密码"></asp:Label>
            <asp:TextBox ID="txtPwd" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" Text="邮箱"></asp:Label>
            <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
            <p>
                <asp:Button ID="btnReg" runat="server" Text="注册" OnClick="btnReg_Click" />
            </p>
        </div>
    </form>
</body>
</html>

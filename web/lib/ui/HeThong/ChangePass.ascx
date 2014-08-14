<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangePass.ascx.cs" Inherits="lib_ui_HeThong_ChangePass" %>
<div class="container">
    <div class="form-signin">
        <h2 class="form-signin-heading">Đổi mật khẩu</h2>
            <asp:TextBox ID="OldPwd" TextMode="Password" runat="server" CssClass="form-control" placeholder="Mật khẩu cũ" required autofocus></asp:TextBox>
            <asp:TextBox ID="Pwd" TextMode="Password" CssClass="form-control" runat="server" placeholder="Mật khẩu mới" required></asp:TextBox>
            <div id="msg" runat="server" Visible="False" class="alert alert-danger">
            mật khẩu không hợp lệ                    
            </div>
        <asp:LinkButton ID="btnLogin" CssClass="btn btn-lg btn-primary btn-block" runat="server" OnClick="btnLogin_Click">Đổi</asp:LinkButton>
    </div>
</div> 
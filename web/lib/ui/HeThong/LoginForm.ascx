<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginForm.ascx.cs" Inherits="lib_ui_HeThong_LoginForm" %>

<div class="container">
    <div class="form-signin">
            <h2 class="form-signin-heading">Đăng nhập</h2>
            <asp:TextBox ID="Username" runat="server" CssClass="form-control" placeholder="Username" required autofocus></asp:TextBox>
            <asp:TextBox ID="Pwd" TextMode="Password" CssClass="form-control" runat="server" placeholder="Mật khẩu" required></asp:TextBox>
            <div class="checkbox">
                <label>        
                <asp:CheckBox runat="server" ID="ckb"/> Ghi nhớ
            </label>
            </div>
            <div id="msg" runat="server" Visible="False" class="alert alert-danger">
            Username và mật khẩu không hợp lệ                    
        </div>
        <asp:LinkButton ID="btnLogin" CssClass="btn btn-lg btn-primary btn-block" runat="server" OnClick="btnLogin_Click">Đăng nhập</asp:LinkButton>
    </div>
</div> 

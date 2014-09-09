<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginForm.ascx.cs" Inherits="lib_ui_HeThong_LoginForm" %>

<div class="container">
    <div class="form-signin">
            <h2 class="form-signin-heading">Đăng nhập</h2>
            <asp:TextBox ID="Username" runat="server" CssClass="form-control" placeholder="Username" required autofocus></asp:TextBox>
            <asp:TextBox ID="Pwd" TextMode="Password" CssClass="form-control" runat="server" placeholder="Mật khẩu" required></asp:TextBox>
            <div style="" class="checkbox">
                <label>        
                <asp:CheckBox runat="server" ID="ckb"/> Ghi nhớ
            </label>
            </div>
            <div id="msg" runat="server" Visible="False" class="alert alert-danger">
            Username và mật khẩu không hợp lệ                    
        </div>
        <asp:Button ID="btnLogin" ClientIDMode="Static" CssClass="btn btn-lg btn-primary btn-block" runat="server" OnClick="btnLogin_Click" Text="Đăng nhập"/>
            <a class="btn btn-default btn-block" href="/lib/pages/MemberList.aspx">
                Danh sách thành viên
            </a>
    </div>
</div> 
<script>
    $(document).ready(function(){
        var btn = $('#btnLogin');
        var form = $('form');

        form.keypress(function (e) {
            if (e.which == 13) {
                btn.click();
            }
        });
    });
</script>

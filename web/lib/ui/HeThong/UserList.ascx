<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserList.ascx.cs" Inherits="lib_ui_HeThong_UserList" %>
<%@ Register Src="~/lib/ui/HeThong/templates/Item-UserList.ascx" TagPrefix="uc1" TagName="ItemUserList" %>

<div class="container">
    <div class="form-signin">
        <table class="table table-striped table-bordered table-hover">
            <thead>
                <th>
                    Tên
                </th>
                <th>
                    Tài khoản
                </th>
                <th>
                    Mật khẩu
                </th>
            </thead>
            <tbody>
                <asp:Repeater runat="server" ID="rpt">
                    <ItemTemplate>
                        <uc1:ItemUserList runat="server" ID="ItemUserList" Item='<%# Container.DataItem %>' /> 
                    </ItemTemplate>
                </asp:Repeater>   
            </tbody>
        </table>
    </div>
</div> 
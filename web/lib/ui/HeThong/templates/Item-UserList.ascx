<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-UserList.ascx.cs" Inherits="lib_ui_HeThong_templates_Item_UserList" %>
<%@ Import Namespace="linh.common" %>
<tr>
    <td>
        <%=Item.Ten %>
    </td>
    <td>
        <%=Item.Username %>
    </td>
    <td>
        <%--<%=maHoa.DecryptString(Item.Password,Item.Username) == "123" ? "123" : "Đã đổi" %>--%>
        <%=Item.Password == maHoa.MD5Encrypt("123") ? "123" : "Đã đổi" %>
    </td>
</tr>
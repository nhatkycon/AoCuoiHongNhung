<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddTask.ascx.cs" Inherits="lib_ui_HeThong_templates_AddTask" %>
<%if (string.IsNullOrEmpty(Ret))
    { %>
    <a href="<%=ListUrl %>" class="btn btn-default">
        <i class="glyphicon glyphicon-chevron-left"></i>
    </a>
<% }else{ %>
    <a href="<%=Ret %>" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
<%} %>
<%if (!string.IsNullOrEmpty(Id))
    {%>
    <%if (AddAble)
      { %>
        <a href="<%=AddUrl %>" data-ret="<%=Ret %>" class="btn btn-success newbtn">Thêm</a>
    <%} %>
    <%if (EditAble)
      { %>
        <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
        <%if (DeleteAble){ %>
            <a href="javascript:;" data-id="<%=Id %>" class="btn btn-warning xoaBtn">Xóa</a>
        <%} %>
    <%} %>
    <%if (!string.IsNullOrEmpty(PrintUrl)){ %>
        <a href="<%=PrintUrl %>" target="_blank"  class="btn btn-primary">In</a>
    <%} %>
<%}
else
{%>
    <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
<%} %> 
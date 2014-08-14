<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="List-Admin.aspx.cs" Inherits="lib_pages_PhieuBaoHong_List_Admin" %>

<%@ Register Src="~/lib/ui/PhieuBaoHong/List-Admin.ascx" TagPrefix="uc1" TagName="ListAdmin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="ModuleHeader">
        <div class="panel panel-default">
            <div class="panel-body" role="form">
                <div class="form-inline">
                    <div class="form-group pull-left">
                        <a href="/lib/pages/PhieuBaoHong/List-Admin.aspx" class="btn btn-success">
                            <i class="glyphicon glyphicon-refresh"></i>
                        </a>
                    </div>
                    <div class="form-group pull-right">
                        <a href="javascript:;" class="btn btn-default" data-toggle="collapse" data-target="#filtering">
                            <i class="glyphicon glyphicon-search"></i>
                        </a>
                    </div>
                </div>
            </div>               
        </div>
        <div id="filtering" class="panel panel-default collapse">
            <div class="panel-body">
                <div class="form-inline">
                    <div class="row">
                        <div class="col-sm-2">
                        </div>
                        <div class="col-sm-2">
                            <div class="pull-right">
                                <div class="input-group">
                                  <input name="q" type="text" value="<%=Request["q"] %>" class="form-control">
                                  <div class="input-group-btn">
                                    <a class="btn btn-default searchBtn">
                                        <i class="glyphicon glyphicon-search"></i>
                                    </a>                                
                                  </div>
                                </div>            
                            </div>                    
                        </div>
                    </div>   
                </div>            
            </div>
        </div>

    </div>   
    <uc1:ListAdmin runat="server" ID="List" />
    <ul class="pagination">
        <%=paging %>
    </ul>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_pages_PhieuDichVu_Default" %>

<%@ Register Src="~/lib/ui/PhieuDichVu/List.ascx" TagPrefix="uc1" TagName="List" %>
<%@ Register TagPrefix="uc1" TagName="ListPhieuDichVuTrangThai" Src="~/lib/ui/HeThong/ListPhieuDichVuTrangThai.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="ModuleHeader">
        <div class="panel panel-default">
            <div class="panel-body" role="form">
                <div class="form-inline">
                    <div class="form-group pull-left">
                        <a href="/lib/pages/PhieuDichVu/Add.aspx" class="btn btn-primary">Thêm</a>      
                        <a href="/lib/pages/PhieuDichVu/Default.aspx" class="btn btn-success">
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
                            <div class="input-group">
                                <span class="input-group-addon btn autocomplete-btn">
                                    <i class="glyphicon glyphicon-chevron-down"></i>
                                </span>
                                <input type="text" data-cached="1"  placeholder="Nhân viên" data-src="/lib/ajax/NhanVien/Default.aspx" 
                                    data-refId="NHANVIEN_ID"
                                    value="" class="form-control form-autocomplete-input">
                                <input type="text" name="NHANVIEN_ID" id="NHANVIEN_ID" value="<%=NhanVienId %>" class="form-control NHANVIEN_ID" style="display: none;">
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="input-append datepicker-input date input-group">
                                <input 
                                    value="<%=Ngay %>"
                                    data-format="dd/MM/yyyy" 
                                    class="form-control Ngay" 
                                    id="Ngay" 
                                    name="Ngay" 
                                    type="text"/>
                                <span class="add-on input-group-addon">
                                    <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                    </i>
                                </span>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <uc1:ListPhieuDichVuTrangThai runat="server" ID="ListPhieuDichVuTrangThai" />
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
    <uc1:List runat="server" id="List" />
    <ul class="pagination">
        <%=paging %>
    </ul>
</asp:Content>


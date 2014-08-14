<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="LichSapToi.aspx.cs" Inherits="lib_pages_PhieuDichVu_LichSapToi" %>
<%@ Register TagPrefix="uc1" TagName="EventsViewer" Src="~/lib/ui/LichHen/EventsViewer.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default ModuleHeader">
        <div class="panel-body" role="form">
            <div class="form-inline">
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <a href="/lib/pages/PhieuDichVu/LichSapToi.aspx" class="btn btn-success">
                             <i class="glyphicon glyphicon-refresh"></i>
                        </a>                                  
                    </div>                    
                </div>
                <div class="col-sm-2">
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon btn autocomplete-btn">
                                <i class="glyphicon glyphicon-chevron-down"></i>
                            </span>
                            <input type="text" data-url="/lib/pages/PhieuDichVu/LichSapToi.aspx?NHANVIEN_ID=" data-src="/lib/ajax/NhanVien/Default.aspx" data-refId="NhanVien_ID" name="NhanVien_Ten" id="NhanVien_Ten" value="" placeholder="Chọn nhân viên" autofocus="" class="form-control LichThang-NhanVien-input NhanVien_Ten">
                        </div>
                    </div>
                </div>
                <div class="col-sm-2">
                    <div class="form-group">
                    </div>
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
    <uc1:EventsViewer Target="/lib/pages/PhieuDichVu/Add.aspx?ID=" runat="server" ID="EventsViewer" />
</asp:Content>


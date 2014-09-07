<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Admin_User.master" AutoEventWireup="true" CodeFile="ChamCong.aspx.cs" Inherits="lib_pages_BaoCao_ChamCong" %>

<%@ Register Src="~/lib/ui/BaoCao/ChamCong.ascx" TagPrefix="uc1" TagName="ChamCong" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-default ModuleHeader">
        <div class="panel-body" role="form">
            <div class="form-inline">
            <div class="row">
                <div class="col-sm-4">
                    <div class="form-group">
                        <a href="/lib/pages/BaoCao/ChamCong.aspx" class="btn btn-success">
                             <i class="glyphicon glyphicon-refresh"></i>
                        </a>  
                        <a href="/lib/pages/BaoCao/ChamCong-Print.aspx" class="btn btn-primary">In</a>      
                    </div>                    
                </div>
                <div class="col-sm-2">
                    <div class="form-group">
                        <div class="input-append datepicker-input date input-group">
                            <input 
                                data-format="dd/MM/yyyy" 
                                placeholder="Từ ngày"
                                class="form-control" 
                                name="TuNgay" 
                                type="text"/>
                            <span class="add-on input-group-addon">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                </i>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="col-sm-2">
                    <div class="form-group">
                        <div class="input-append datepicker-input date input-group">
                            <input 
                                data-format="dd/MM/yyyy" 
                                placeholder="Đến ngày"
                                class="form-control" 
                                name="DenNgay" 
                                type="text"/>
                            <span class="add-on input-group-addon">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                </i>
                            </span>
                        </div>
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
    <uc1:ChamCong runat="server" ID="ChamCong" />
</asp:Content>


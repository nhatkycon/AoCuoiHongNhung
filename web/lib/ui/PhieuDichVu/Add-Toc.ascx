<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add-Toc.ascx.cs" Inherits="lib_ui_PhieuDichVu_Add_Toc" %>
<%@ Register TagPrefix="uc1" TagName="AddTask_1_1" Src="~/lib/ui/HeThong/templates/AddTask.ascx" %>
<%@ Register Src="~/lib/ui/KhachHang/AddQuickModal.ascx" TagPrefix="uc1" TagName="AddQuickModal" %>
<%@ Register Src="~/lib/ui/HeThong/ListPhieuDichVuTrangThai.ascx" TagPrefix="uc1" TagName="ListPhieuDichVuTrangThai" %>
<%@ Register Src="~/lib/ui/PhieuDichVuDichVu/List-View.ascx" TagPrefix="uc1" TagName="ListView" %>


<link href="/lib/css/web/bootstrap-timepicker.min.css" rel="stylesheet" />
<div class="panel panel-default Normal-Pnl-Add PhieuDichVu-Pnl-Add"
    data-url="/lib/ajax/PhieuDichVu/default.aspx"
    data-success="/lib/pages/PhieuDichVu/Add-Toc.aspx?ID="
    data-list="/lib/pages/PhieuDichVu/List-Toc.aspx"
    >
    <div class="panel-heading">
        <uc1:AddTask_1_1 AddUrl="/lib/pages/PhieuDichVu/Add-Toc.aspx" 
            ListUrl="/lib/pages/PhieuDichVu/List-Toc.aspx" runat="server" id="AddTask" />
    </div>
    <div class="panel-body">
        <div class="form-horizontal" role="form">
            <input id="Id" style="display: none;" value="<%=Item.ID == Guid.Empty ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
            <div class="form-group">
                <label for="Ma" class="col-sm-2 control-label">Mã</label>
                <div class="col-sm-2">
                    <p class="form-control-static"><%=Item.MaStr %></p>
                </div>
                
                <label for="KH_Ten" class="col-sm-2 control-label">Khách hàng:</label>
                <div class="col-sm-2">
                    <p class="form-control-static"><%=Item.KH_Ten %></p>
                </div>
                <label for="NgayTuVan" class="col-sm-2 control-label">Ngày:</label>
                <div class="col-sm-2">
                    <p class="form-control-static"><%=Item.NgayTuVan.ToString("dd/MM/yyyy") %></p>
                </div>
            </div>            
            <div class="form-group">
                <label for="TuVanVien_Ten" class="col-sm-2 control-label">Tư vấn:</label>
                <div class="col-sm-2">
                    <p class="form-control-static"><%=Item.TuVanVien_Ten %></p>
                </div>
                <label for="TrangThai" class="col-sm-2 control-label">Trạng thái:</label>
                <div class="col-sm-2">
                    <p class="form-control-static"><%=Item.TrangThaistr %></p>
                </div>
                <label for="GDV_Ten" class="col-sm-2 control-label">Gói:</label>
                <div class="col-sm-2">
                    <p class="form-control-static">
                        <%=Item.GDV_Ten %>
                    </p>
                </div>
            </div>
            
            <hr/>
            <p>
                <a href="javascript:;" class="btn btn-link" data-toggle="collapse" data-target="#DichVuPnl">
                    Dịch vụ
                </a>
            </p>
            <div class="collapse in" id="DichVuPnl">
                <uc1:ListView runat="server" ID="DichVuList" />
            </div>
            
            <hr/>
            <p>
                <a href="javascript:;" class="btn btn-link" data-toggle="collapse" data-target="#TocPnl">
                    Làm tóc
                </a>
            </p>
            <div class="collapse in" id="TocPnl">
                <hr/>
                <div class="form-group">
                    <label for="TOC_NhanVien" class="col-sm-2 control-label">Nhân viên:</label>
                    <div class="col-sm-2">
                        <p class="form-control-static">
                            <%=Item.TOC_NhanVien_Ten %>
                        </p>
                    </div>
                    <label for="TOC_NgayBatDau" class="col-sm-2 control-label">Thời gian:</label>
                    <div class="col-sm-2">
                        <p class="form-control-static">
                            <%if (Item.TOC_NgayBatDau != DateTime.MinValue){ %>
                                <%=Item.TOC_NgayBatDau.ToString("HH:mm") %>-<%=Item.TOC_NgayKetThuc.ToString("HH:mm") %> 
                                <%=Item.TOC_NgayBatDau.ToString("dd/MM/yyyy") %>
                            <%} %>
                        </p>
                    </div>
                </div>

            </div>
            
            
           
            
            <%if (!string.IsNullOrEmpty(Id))
              { %>
                <div class="help-block">
                    <div class="well well-sm">
                        <i class="glyphicon glyphicon-info-sign"></i>
                        <strong><%=Item.NguoiTao_Ten %></strong> tạo ngày <%=Item.NgayTao.ToString("HH:mm dd/MM/yyyy") %>.
                        .<strong><%=Item.NguoiCapNhat_Ten %></strong> sửa lúc <%=Item.NgayCapNhat.ToString("HH:mm dd/MM/yyyy") %>
                    </div>
                </div>            
            <%} %>
        </div>
    </div>
    <div class="panel-footer">
        <uc1:AddTask_1_1 AddUrl="/lib/pages/PhieuDichVu/Add-Toc.aspx" 
            ListUrl="/lib/pages/PhieuDichVu/List-Toc.aspx" runat="server" id="AddTask1" />
    </div>
</div>
<uc1:AddQuickModal runat="server" ID="AddQuickModal" />
<script src="/lib/js/jQueryLib/bootstrap-timepicker.min.js"></script>
<%if (!string.IsNullOrEmpty(Id))
  { %>
    <script>
        $(function () {
            $('.TrangThai').val('<%=Item.TrangThai %>');
        });
    </script>
<% } %>

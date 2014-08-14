<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add-Td.ascx.cs" Inherits="lib_ui_PhieuDichVu_Add_Td" %>
<%@ Register TagPrefix="uc1" TagName="AddTask_1_1" Src="~/lib/ui/HeThong/templates/AddTask.ascx" %>
<%@ Register Src="~/lib/ui/KhachHang/AddQuickModal.ascx" TagPrefix="uc1" TagName="AddQuickModal" %>
<%@ Register Src="~/lib/ui/PhieuDichVuDichVu/List-View.ascx" TagPrefix="uc1" TagName="ListView" %>


<link href="/lib/css/web/bootstrap-timepicker.min.css" rel="stylesheet" />
<div class="panel panel-default Normal-Pnl-Add PhieuDichVu-Pnl-Add"
    data-url="/lib/ajax/PhieuDichVu/default.aspx"
    data-success="/lib/pages/PhieuDichVu/List-Td.aspx?ID="
    data-list="/lib/pages/PhieuDichVu/List-Td.aspx"
    >
    <div class="panel-heading">
        <uc1:AddTask_1_1 AddUrl="/lib/pages/PhieuDichVu/Add-Td.aspx" 
            ListUrl="/lib/pages/PhieuDichVu/List-Td.aspx" runat="server" id="AddTask" />
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
                <a href="javascript:;" class="btn btn-link" data-toggle="collapse" data-target="#TrangDiemPnl">
                    Trang điểm
                </a>
            </p>
            <div class="collapse in" id="TrangDiemPnl">
                <hr/>
                <div class="form-group">
                    <label for="TD_NhanVien_Ten" class="col-sm-2 control-label">Trang điểm:</label>
                    <div class="col-sm-2">
                        <p class="form-control-static">
                            <%=Item.TD_NhanVien_Ten %>
                        </p>
                    </div>
                    <label for="TD_NgayBatDau" class="col-sm-2 control-label">Từ:</label>
                    <div class="col-sm-2">
                       <p class="form-control-static">
                            <%if (Item.TOC_NgayBatDau != DateTime.MinValue){ %>
                                <%=Item.TOC_NgayBatDau.ToString("HH:mm") %>-<%=Item.TOC_NgayKetThuc.ToString("HH:mm") %> 
                                <%=Item.TOC_NgayBatDau.ToString("dd/MM/yyyy") %>
                            <%} %>
                        </p>
                    </div>
                    
                </div>
                <div class="form-group">
                    <label for="TD_DiaDiem" class="col-sm-2 control-label">Địa điểm:</label>
                    <div class="col-sm-2">
                        <textarea id="TD_DiaDiem" name="TD_DiaDiem" rows="3" class="form-control"><%=Item.TD_DiaDiem%></textarea>
                    </div>
                    <label for="TD_KhoangCach" class="col-sm-2 control-label">Phí đi lại:</label>
                    <div class="col-sm-1">
                        <div class="input-group">
                          <input id="TD_KhoangCach" type="text" class="form-control TD_KhoangCach" value="<%=Item.TD_KhoangCach %>" name="TD_KhoangCach"/>
                          <span class="input-group-addon">km</span>
                        </div>
                    </div>
                    <div class="col-sm-1">
                        <input id="TD_PhiDiLai" type="text" class="form-control money-input TD_PhiDiLai" value="<%=Item.TD_PhiDiLai %>" name="TD_PhiDiLai"/>
                    </div>
                    <label for="TD_KhoanPhaiThu" class="col-sm-2 control-label">Phải thu:</label>
                    <div class="col-sm-2">
                        <input id="TD_KhoanPhaiThu" type="text" class="form-control money-input TD_KhoanPhaiThu" value="<%=Item.TD_KhoanPhaiThu %>" name="TD_KhoanPhaiThu"/>
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
        <uc1:AddTask_1_1 AddUrl="/lib/pages/PhieuDichVu/Add-Td.aspx" 
            ListUrl="/lib/pages/PhieuDichVu/List-Td.aspx" runat="server" id="AddTask1" />
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

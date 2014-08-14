<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_GiatLa_Add" %>
<%@ Register TagPrefix="uc1" TagName="AddTask_1" Src="~/lib/ui/HeThong/templates/AddTask.ascx" %>
<%@ Register Src="~/lib/ui/HeThong/ListXuatNhapSanPhamTrangThai.ascx" TagPrefix="uc1" TagName="ListXuatNhapSanPhamTrangThai" %>
<%@ Register Src="~/lib/ui/PhieuXuatNhapSanPhamChiTiet/List-Edit.ascx" TagPrefix="uc1" TagName="ListEdit" %>


<link href="/lib/css/web/bootstrap-timepicker.min.css" rel="stylesheet" />
<div class="panel panel-default Normal-Pnl-Add GiatLa-Pnl-Add"
    data-url="/lib/ajax/GiatLa/default.aspx"
    data-success="/lib/pages/GiatLa/Add.aspx?ID="
    data-list="/lib/pages/GiatLa/"
    >
    <div class="panel-heading">
       <uc1:AddTask_1 AddUrl="/lib/pages/GiatLa/Add.aspx" ListUrl="/lib/pages/GiatLa/Default.aspx" 
           runat="server" id="AddTask" />               
    </div>
    <div class="panel-body">
        <div class="form-horizontal" role="form">
            <input id="Id" style="display: none;" value="<%=Item.ID == Guid.Empty ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
            <div class="form-group">
                <label for="Ma" class="col-sm-2 control-label">Mã:</label>
                <div class="col-sm-2">
                    <input id="Ma" type="text"  class="form-control" data-ma="<%=Item.Ma %>" value="<%=Item.MaStr %>" name="Ma"/>
                </div>
                <label for="DM_ID" class="col-sm-2 control-label">Cửa hàng:</label>
                <div class="col-sm-2">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-cached="1" data-src="/lib/ajax/DanhMuc/Default.aspx?LDM=CuaHangGiatLa" data-refId="CH_ID" name="CH_Ten" id="CH_Ten"  value="<%=Item.CH_Ten %>" 
                            class="form-control form-autocomplete-input CH_Ten" autofocus>
                        <input type="text" name="CH_ID" id="CH_ID" value="<%=Item.CH_ID %>" class="form-control CH_ID" style="display: none;">
                    </div>
                </div>
                <label for="TrangThai" class="col-sm-2 control-label">Trạng thái:</label>
                <div class="col-sm-2">
                    <uc1:ListXuatNhapSanPhamTrangThai runat="server" ID="ListXuatNhapSanPhamTrangThai" />
                </div>
            </div>
            <div class="form-group">
                <label for="NgayBatDau" class="col-sm-2 control-label">Ngày gửi:</label>
                <div class="col-sm-2">
                    <div class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.NgayBatDau == DateTime.MinValue ?  "" : Item.NgayBatDau.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control NgayBatDau" 
                            id="NgayBatDau" 
                            name="NgayBatDau" 
                            type="text"/>
                        <span class="add-on input-group-addon">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                            </i>
                        </span>
                    </div>
                </div>
                
                <label for="NguoiXuat_Ten" class="col-sm-2 control-label">Người gửi:</label>
                <div class="col-sm-2">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-cached="1" data-src="/lib/ajax/NhanVien/Default.aspx" data-refId="NguoiXuat" name="NguoiXuat_Ten" id="NguoiXuat_Ten" value="<%=Item.NguoiXuat_Ten %>" class="form-control form-autocomplete-input NguoiXuat_Ten">
                        <input type="text" name="NguoiXuat" id="NguoiXuat" value="<%=Item.NguoiXuat %>" class="form-control NguoiXuat" style="display: none;">
                    </div>
                </div>
            </div>
            <div class="form-group">
                
                <label for="NgayKetThuc" class="col-sm-2 control-label">Ngày nhập:</label>
                <div class="col-sm-2">
                    <div class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.NgayKetThuc == DateTime.MinValue ?  "" : Item.NgayKetThuc.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control NgayKetThuc" 
                            id="NgayKetThuc" 
                            name="NgayKetThuc" 
                            type="text"/>
                        <span class="add-on input-group-addon">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                            </i>
                        </span>
                    </div>
                </div>
                <label for="NguoiNhap_Ten" class="col-sm-2 control-label">Người nhập:</label>
                <div class="col-sm-2">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-cached="1" data-src="/lib/ajax/NhanVien/Default.aspx" data-refId="NguoiNhap" name="NguoiNhap_Ten" id="NguoiNhap_Ten" value="<%=Item.NguoiNhap_Ten %>" class="form-control form-autocomplete-input NguoiNhap">
                        <input type="text" name="NguoiNhap" id="NguoiNhap" value="<%=Item.NguoiNhap %>" class="form-control NguoiNhap" style="display: none;">
                    </div>
                </div>
            </div>
            <hr/>
            <div class="form-group">
                <label for="Tien" class="col-sm-2 control-label">Tiền:</label>
                <div class="col-sm-2">
                    <input id="Tong" type="text" class="form-control money-input Tien" value="<%=Item.Tien %>" name="Tien"/>
                </div>
               
            </div>
            <hr/>
            <uc1:ListEdit runat="server" ID="ListEdit" />
            <hr/>
            <%if (!string.IsNullOrEmpty(Id)){ %>
                <div class="help-block">
                    <div class="well well-sm">
                        <i class="glyphicon glyphicon-info-sign"></i>
                        <strong><%=Item.NguoiTao_Ten %></strong> tạo ngày <%=Item.NgayTao.ToString("HH:mm dd/MM/yyyy") %>.
                        sửa lúc <%=Item.NgayCapNhat.ToString("HH:mm dd/MM/yyyy") %>
                    </div>
                </div>
            <%} %>
        </div>
    </div>
    <div class="panel-footer">
        <uc1:AddTask_1 AddUrl="/lib/pages/GiatLa/Add.aspx" ListUrl="/lib/pages/GiatLa/Default.aspx" 
           runat="server" id="AddTask1" />
    </div>
</div>

<script src="/lib/js/jQueryLib/bootstrap-timepicker.min.js"></script>
<%if (!string.IsNullOrEmpty(Id))
{%>
<script>
    $(function () {
        $('.TrangThai').val('<%=Item.TrangThai %>');
    })
</script>
<%} %>
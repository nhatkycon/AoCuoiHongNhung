<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_ChoThueVay_Add" %>
<%@ Register TagPrefix="uc1" TagName="AddTask_1" Src="~/lib/ui/HeThong/templates/AddTask.ascx" %>
<%@ Register Src="~/lib/ui/HeThong/ListXuatNhapSanPhamTrangThai.ascx" TagPrefix="uc1" TagName="ListXuatNhapSanPhamTrangThai" %>
<%@ Register Src="~/lib/ui/PhieuXuatNhapSanPhamChiTiet/List-Edit.ascx" TagPrefix="uc1" TagName="ListEdit" %>
<%@ Register Src="~/lib/ui/ThuChi/List-PhieuDichVu.ascx" TagPrefix="uc1" TagName="ListPhieuDichVu" %>

<link href="/lib/css/web/bootstrap-timepicker.min.css" rel="stylesheet" />
<div class="panel panel-default Normal-Pnl-Add ChoThueVay-Pnl-Add"
    data-url="/lib/ajax/ChoThueVay/default.aspx"
    data-success="/lib/pages/ChoThueVay/Add.aspx?ID="
    data-list="/lib/pages/ChoThueVay/"
    >
    <div class="panel-heading">
       <uc1:AddTask_1 AddUrl="/lib/pages/ChoThueVay/Add.aspx" ListUrl="/lib/pages/ChoThueVay/Default.aspx" 
           runat="server" id="AddTask" />               
    </div>
    <div class="panel-body">
        <div class="form-horizontal" role="form">
            <input id="Id" style="display: none;" value="<%=Item.ID == Guid.Empty ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
            <div class="form-group">
                <label for="Ma" class="col-sm-2 control-label">Mã</label>
                <div class="col-sm-2">
                    <input id="Ma" type="text"  class="form-control" data-ma="<%=Item.Ma %>" value="<%=Item.MaStr %>" name="Ma"/>
                </div>
                <label for="KH_Ten" class="col-sm-2 control-label">Khách hàng:</label>
                <div class="col-sm-2">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" autofocus data-src="/lib/ajax/KhachHang/Default.aspx" data-refId="KH_ID" name="KH_Ten" id="KH_Ten"  value="<%=Item.KH_Ten %>" 
                            class="form-control form-autocomplete-input KH_Ten" >
                        <input type="text" name="KH_ID" id="KH_ID" value="<%=Item.KH_ID %>" class="form-control KH_ID" style="display: none;">
                        <a href="javascript:;" class="input-group-addon btn btn-default btnThemNhanhKH" data-toggle="modal" data-target="#KhachHangAddQuickModal">
                            <i class="glyphicon glyphicon-user"></i> Thêm
                        </a>
                    </div>
                    <%if (!string.IsNullOrEmpty(Item.KH_Ten)){ %>
                        <div class="help-block">
                            <a class="btn btn-link" href="/lib/pages/KhachHang/Add.aspx?ID=<%=Item.KH_ID %>&ret=<%=Server.UrlEncode(Request.Url.PathAndQuery) %>">
                                <i class="glyphicon glyphicon-info-sign"></i> <%=Item.KH_Ten %>
                            </a>
                        </div>
                    <%} %>
                </div>
                <label for="Ngay" class="col-sm-2 control-label">Ngày lập:</label>
                <div class="col-sm-2">
                    <div class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.Ngay == DateTime.MinValue ?  DateTime.Now.ToString("dd/MM/yyyy") : Item.Ngay.ToString("dd/MM/yyyy") %>"
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
            </div>
            <div class="form-group">
                <label for="TrangThai" class="col-sm-2 control-label">Trạng thái:</label>
                <div class="col-sm-2">
                    <uc1:ListXuatNhapSanPhamTrangThai runat="server" ID="ListXuatNhapSanPhamTrangThai" />
                </div>
            </div>
            <div class="form-group">
                <label for="NgayBatDau" class="col-sm-2 control-label">Ngày xuất:</label>
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
                
                <label for="NgayKetThuc" class="col-sm-2 control-label">Ngày trả dự kiến:</label>
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
                
                
                <label for="NguoiXuat_Ten" class="col-sm-2 control-label">Người xuất:</label>
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
                
                <label for="NgayTraVayThucTe" class="col-sm-2 control-label">Ngày nhập:</label>
                <div class="col-sm-2">
                    <div class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.NgayTraVayThucTe == DateTime.MinValue ?  "" : Item.NgayTraVayThucTe.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control NgayTraVayThucTe" 
                            id="NgayTraVayThucTe" 
                            name="NgayTraVayThucTe" 
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
                <label for="ThuKho_Ten" class="col-sm-2 control-label">Thủ kho:</label>
                <div class="col-sm-2">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-cached="1" data-src="/lib/ajax/NhanVien/Default.aspx" data-refId="ThuKho" name="ThuKho_Ten" id="ThuKho_Ten" value="<%=Item.ThuKho_Ten %>" class="form-control form-autocomplete-input ThuKho_Ten">
                        <input type="text" name="ThuKho" id="ThuKho" value="<%=Item.ThuKho %>" class="form-control ThuKho" style="display: none;">
                    </div>
                </div>
            </div>
            <hr/>
            <div class="form-group">
                <label for="Tong" class="col-sm-1 control-label">Tổng:</label>
                <div class="col-sm-2">
                    <input id="Tong" type="text" class="form-control money-input Tong" value="<%=Item.Tong %>" name="Tong"/>
                </div>
                <label for="DatCong" class="col-sm-1 control-label">Đặt cọc:</label>
                <div class="col-sm-2">
                    <input id="DatCong" type="text" class="form-control money-input DatCong" value="<%=Item.DatCong %>" name="DatCong"/>
                </div>
                <label for="ThanhToan" class="col-sm-1 control-label">Đã trả:</label>
                <div class="col-sm-2">
                    <input id="ThanhToan" disabled="disabled" type="text" class="form-control money-input ThanhToan" value="<%=Item.ThanhToan %>"/>
                </div>
                <label for="ConNo" class="col-sm-1 control-label">Còn nợ:</label>
                <div class="col-sm-2">
                    <input id="ConNo" type="text" disabled="disabled" class="form-control money-input ConNo" value="<%=Item.ConNo %>"/>
                </div>
            </div>
            <hr/>
            <div class="form-group">
                <label for="GiayTo" class="col-sm-1 control-label">Giấy tờ:</label>
                <div class="col-sm-7">
                    <textarea id="GiayTo" name="GiayTo" type="text" rows="3" class="form-control"><%=Item.GiayTo%></textarea>
                </div>
                <label for="DaTraGiayTo" class="col-sm-2 control-label">Trả giấy tờ:</label>
                <div class="col-sm-2">
                    <%if (Item.DaTraGiayTo)
                    {%>
                        <input class="DaTraGiayTo input-sm" id="DaTraGiayTo" checked="checked" name="DaTraGiayTo" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="DaTraGiayTo input-sm" id="DaTraGiayTo" name="DaTraGiayTo" type="checkbox"/>
                    <% } %>
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
        <uc1:AddTask_1 AddUrl="/lib/pages/ChoThueVay/Add.aspx" ListUrl="/lib/pages/ChoThueVay/Default.aspx" 
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
<%if (!string.IsNullOrEmpty(Id))
  { %>
    <script>
        $(function () {
            $('.TrangThai').val('<%=Item.TrangThai %>');
        });
    </script>
    <hr />
    <h3>
        Phiếu thu
    </h3>
    <div class="panel panel-default">
        <div class="panel-heading">
            <a class="btn btn-primary" href="/lib/pages/ThuChi/Add-Thu.aspx?CTV_ID=<%=Item.ID %>">
                Thêm phiếu thu
            </a>
        </div>
        <div class="panel-body">
            <uc1:ListPhieuDichVu runat="server" ID="ListPhieuDichVu" />
        </div>
    </div>

<% } %>
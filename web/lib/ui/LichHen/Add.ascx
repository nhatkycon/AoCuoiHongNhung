<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_Bally_LichHen_Add" %>
<%@ Import Namespace="docsoft" %>
<%@ Register src="~/lib/ui/HeThong/DanhMucListByLdmMa.ascx" tagname="DanhMucListByLdmMa" tagprefix="uc1" %>
<%@ Register Src="~/lib/ui/KhachHang/AddQuickModal.ascx" TagPrefix="uc1" TagName="AddQuickModal" %>


<link href="/lib/css/web/bootstrap-timepicker.min.css" rel="stylesheet" />
<div class="panel panel-default Normal-Pnl-Add LichHen-Pnl-Add"
    data-url="/lib/ajax/LichHen/default.aspx"
    data-success="/lib/pages/LichHen/Add.aspx?ID="
    data-list="/lib/pages/LichHen/"
    >
    <div class="panel-heading">
        <%if (string.IsNullOrEmpty(Ret))
          { %>
            <a href="/lib/pages/LichHen/Default.aspx" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <% }else{ %>
            <a href="<%=Ret %>" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <%} %>
        <%if (!string.IsNullOrEmpty(Id))
            {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
            <a href="/lib/pages/LichHen/Add.aspx" data-ret="<%=Ret %>" class="btn btn-success newbtn">Thêm</a>
            <%if(Item.NguoiTao == Security.Username){ %>
                <a href="javascript:;" data-id="<%=Item.ID %>" class="btn btn-warning xoaBtn">Xóa</a>
            <%} %>
        <%}
        else
        {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
        <%} %>                    
    </div>
    <div class="panel-body">
        <div class="form-horizontal" role="form">
            <input id="Id" style="display: none;" value="<%=Item.ID == Guid.Empty ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
            <div class="form-group">
                <label for="KH_Ten" class="col-sm-2 control-label">Khách hàng</label>
                <div class="col-sm-10">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-src="/lib/ajax/KhachHang/Default.aspx" data-refId="KH_ID" name="KH_Ten" id="KH_Ten"  value="<%=Item.KH_Ten %>" 
                            class="form-control form-autocomplete-input KH_Ten" autofocus>
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
            </div>
            <div class="form-group">
                <label for="DM_ID" class="col-sm-2 control-label">Loại</label>
                <div class="col-sm-10">
                    <uc1:DanhMucListByLdmMa ClientIDMode="Static" 
                    ControlId="DM_ID" ID="DM_ID" 
                    ControlName="DM_ID" runat="server" />
                </div>
            </div>
            <div class="form-group">
                <label for="Ten" class="col-sm-2 control-label">Tên</label>
                <div class="col-sm-10">
                    <input id="Ten" type="text" class="form-control" value="<%=Item.Ten %>" name="Ten"/>
                </div>
            </div>
            <div class="form-group">
                <label for="NgayBatDau" class="col-sm-2 control-label">Từ:</label>
                <div class="col-sm-6">
                    <div class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.NgayBatDau == DateTime.MinValue ?  DateTime.Now.ToString("dd/MM/yyyy") : Item.NgayBatDau.ToString("dd/MM/yyyy") %>"
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
                <div class="col-sm-2">
                    <div class="input-group bootstrap-timepicker">
                        <input type="text" name="NgayBatDau_Gio" id="GioXuatBen" value="<%=Item.NgayBatDau.ToString("HH:mm") %>" class="form-control NgayBatDau_Gio timePicker-input">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                    </div>
                </div>
                <div class="col-sm-2">
                    <div class="input-group bootstrap-timepicker">
                        <input type="text" name="NgayKetThuc_Gio" id="NgayKetThuc_Gio" value="<%=Item.NgayKetThuc.ToString("HH:mm") %>" class="form-control NgayKetThuc_Gio timePicker-input">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                    </div>
                </div>

            </div>
            <div class="form-group">
                <label for="NhanVien_Ten" class="col-sm-2 control-label">Nhân viên</label>
                <div class="col-sm-10">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-cached="1" data-src="/lib/ajax/NhanVien/Default.aspx" data-refId="NhanVien" name="NhanVien_Ten" id="NhanVien_Ten" value="<%=Item.NhanVien_Ten %>" class="form-control form-autocomplete-input NhanVien_Ten">
                        <input type="text" name="NhanVien" id="NhanVien" value="<%=Item.NhanVien %>" class="form-control NhanVien" style="display: none;">
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label for="MoTa" class="col-sm-2 control-label">Mô tả</label>
                <div class="col-sm-10">
                    <textarea id="MoTa" name="MoTa" type="text" rows="3" class="form-control"><%=Item.MoTa%></textarea>
                </div>
            </div>
            <div class="form-group">
                <label for="BoQua" class="col-sm-2 control-label">Bỏ qua</label>
                <div class="col-sm-10">
                    <%if (Item.BoQua)
                    {%>
                        <input class="BoQua input-sm" id="BoQua" checked="checked" name="BoQua" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="BoQua input-sm" id="BoQua" name="BoQua" type="checkbox"/>
                    <% } %>
                </div>
            </div>
            <div class="form-group">
                <label for="ThanhCong" class="col-sm-2 control-label">Thành công</label>
                <div class="col-sm-10">
                    <%if (Item.ThanhCong)
                    {%>
                        <input class="ThanhCong input-sm" id="ThanhCong" checked="checked" name="ThanhCong" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="ThanhCong input-sm" id="ThanhCong" name="ThanhCong" type="checkbox"/>
                    <% } %>
                </div>
            </div>
            <%if (!string.IsNullOrEmpty(Id)){ %>
                <div class="help-block">
                    <div class="well well-sm">
                        <i class="glyphicon glyphicon-info-sign"></i>
                        <strong><%=Item.NguoiTao %></strong> tạo ngày <%=Item.NgayTao.ToString("HH:mm dd/MM/yyyy") %>.
                        <strong><%=Item.NguoiCapNhat %></strong> sửa lúc <%=Item.NgayCapNhat.ToString("HH:mm dd/MM/yyyy") %>
                    </div>
                </div>
            <%} %>
        </div>
    </div>
    <div class="panel-footer">
        <%if (string.IsNullOrEmpty(Ret))
          { %>
            <a href="/lib/pages/LichHen/Default.aspx" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <% }else{ %>
            <a href="<%=Ret %>" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
        <%} %>
        <%if (!string.IsNullOrEmpty(Id))
            {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
            <a href="/lib/pages/LichHen/Add.aspx" data-ret="<%=Ret %>" class="btn btn-success newbtn">Thêm</a>
            <%if(Item.NguoiTao == Security.Username){ %>
                <a href="javascript:;" data-id="<%=Item.ID %>" class="btn btn-warning xoaBtn">Xóa</a>
            <%} %>
        <%}
        else
        {%>
            <a href="javascript:;" data-ret="<%=Ret %>" class="btn btn-primary savebtn">Lưu</a>
        <%} %>
    </div>
</div>
<uc1:AddQuickModal runat="server" ID="AddQuickModal" />
<script src="/lib/js/jQueryLib/bootstrap-timepicker.min.js"></script>
<%if (!string.IsNullOrEmpty(Id))
{%>
<script>
    $(function () {
        $('.DM_ID').val('<%=Item.DM_ID %>');
    })
</script>
<%} %>
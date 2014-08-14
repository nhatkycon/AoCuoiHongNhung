<%@ Control Language="C#" AutoEventWireup="true" CodeFile="View-Item.ascx.cs" Inherits="lib_ui_LichHen_templates_View_Item" %>
<div class="panel panel-default Normal-Pnl-Add LichHen-Pnl-Add"
    data-url="/lib/ajax/LichHen/default.aspx"
    data-success="/lib/pages/LichHen/Add.aspx?ID="
    data-list="/lib/pages/LichHen/"
    >
    <div class="panel-heading">
        <a href="/lib/pages/LichHen/ListByNhanVien.aspx" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>              
    </div>
    <div class="panel-body">
        <div class="form-horizontal" role="form">
            <input id="Id" style="display: none;" value="<%=Item.ID == Guid.Empty ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
            <div class="form-group">
                <label for="KH_Ten" class="col-sm-2 control-label">Khách hàng</label>
                <div class="col-sm-10">
                    <p class="form-control-static">
                        <%=Item.KH_Ten %>
                        <%--<%if (!string.IsNullOrEmpty(Item.KH_Ten)){ %>
                            <a class="btn btn-link" href="/lib/pages/KhachHang/Add.aspx?ID=<%=Item.KH_ID %>&ret=<%=Server.UrlEncode(Request.Url.PathAndQuery) %>">
                                <i class="glyphicon glyphicon-info-sign"></i>
                            </a>
                        <%} %>--%>
                    </p>
                </div>
            </div>
            <div class="form-group">
                <label for="DM_ID" class="col-sm-2 control-label">Loại</label>
                <div class="col-sm-10">
                    <p class="form-control-static">
                        <%=Item.DM_Ten %>
                    </p>
                </div>
            </div>
            <div class="form-group">
                <label for="Ten" class="col-sm-2 control-label">Tên</label>
                <div class="col-sm-10">
                    <p class="form-control-static">
                        <%=Item.Ten %>
                    </p>
                </div>
            </div>
            <div class="form-group">
                <label for="NgayBatDau" class="col-sm-2 control-label">Từ:</label>
                <div class="col-sm-6">
                    <p class="form-control-static">
                        <%=Item.NgayBatDau.ToString("HH:mm") %>-<%=Item.NgayKetThuc.ToString("HH:mm") %> <%=Item.NgayBatDau.ToString("dd/MM/yyyy") %>
                    </p>
                </div>
            </div>
            <div class="form-group">
                <label for="NhanVien_Ten" class="col-sm-2 control-label">Nhân viên</label>
                <div class="col-sm-10">
                    <p class="form-control-static">
                        <%=Item.NhanVien_Ten %>
                    </p>
                </div>
            </div>
            <div class="form-group">
                <label for="MoTa" class="col-sm-2 control-label">Mô tả</label>
                <div class="col-sm-10">
                    <p class="form-control-static">
                        <%=Item.MoTa %>
                    </p>
                </div>
            </div>
            <div class="form-group">
                <label for="BoQua" class="col-sm-2 control-label">Bỏ qua</label>
                <div class="col-sm-10">
                    <%if (Item.BoQua)
                    {%>
                        <input class="BoQua input-sm" disabled="disabled" id="BoQua" checked="checked" name="BoQua" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="BoQua input-sm" disabled="disabled" id="Checkbox1" name="BoQua" type="checkbox"/>
                    <% } %>
                </div>
            </div>
            <div class="form-group">
                <label for="ThanhCong" class="col-sm-2 control-label">Thành công</label>
                <div class="col-sm-10">
                    <%if (Item.ThanhCong)
                    {%>
                        <input class="ThanhCong input-sm" disabled="disabled" id="ThanhCong" checked="checked" name="ThanhCong" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="ThanhCong input-sm" disabled="disabled" id="Checkbox2" name="ThanhCong" type="checkbox"/>
                    <% } %>
                </div>
            </div>
                <div class="help-block">
                    <div class="well well-sm">
                        <i class="glyphicon glyphicon-info-sign"></i>
                        <strong><%=Item.NguoiTao %></strong> tạo ngày <%=Item.NgayTao.ToString("HH:mm dd/MM/yyyy") %>.
                        <strong><%=Item.NguoiCapNhat %></strong> sửa lúc <%=Item.NgayCapNhat.ToString("HH:mm dd/MM/yyyy") %>
                    </div>
                </div>
        </div>
    </div>
    <div class="panel-footer">
        <a href="/lib/pages/LichHen/ListByNhanVien.aspx" class="btn btn-default"><i class="glyphicon glyphicon-chevron-left"></i></a>
    </div>
</div>
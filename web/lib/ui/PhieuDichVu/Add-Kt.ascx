<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add-Kt.ascx.cs" Inherits="lib_ui_PhieuDichVu_Add_Kt" %>
<%@ Register TagPrefix="uc1" TagName="AddTask_1_1" Src="~/lib/ui/HeThong/templates/AddTask.ascx" %>
<%@ Register Src="~/lib/ui/KhachHang/AddQuickModal.ascx" TagPrefix="uc1" TagName="AddQuickModal" %>
<%@ Register Src="~/lib/ui/PhieuDichVuDichVu/List.ascx" TagPrefix="uc1" TagName="List" %>
<%@ Register Src="~/lib/ui/HeThong/ListPhieuDichVuTrangThai.ascx" TagPrefix="uc1" TagName="ListPhieuDichVuTrangThai" %>
<%@ Register Src="~/lib/ui/ThuChi/List-PhieuDichVu.ascx" TagPrefix="uc1" TagName="ListPhieuDichVu" %>

<link href="/lib/css/web/bootstrap-timepicker.min.css" rel="stylesheet" />
<div class="panel panel-default Normal-Pnl-Add PhieuDichVu-Pnl-Add"
    data-url="/lib/ajax/PhieuDichVu/default.aspx"
    data-success="/lib/pages/PhieuDichVu/Add.aspx?ID="
    data-list="<%=ListUrl %>"
    >
    <div class="panel-heading">
        <uc1:AddTask_1_1 AddUrl="/lib/pages/PhieuDichVu/Add.aspx" runat="server" id="AddTask" />
        <%if(ThungRac){ %>
            <a href="javascript:;" class="btn btn-success restorebtn">Khôi phục</a>
        <%} %>
        <%if(!string.IsNullOrEmpty(Id)){ %>
            <div class="btn-group">
              <a href="#" class="btn btn-danger">In</a>
              <button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown">
                <span class="caret"></span>
                <span class="sr-only">Danh sách in</span>
              </button>
              <ul class="dropdown-menu" role="menu">
                <li><a href="/lib/pages/PhieuDichVu/In-HopDongDichVu.aspx?ID=<%=Item.ID %>">Hợp đồng</a></li>
                <li><a href="/lib/pages/PhieuDichVu/In-PhieuDichVu.aspx?ID=<%=Item.ID %>">Phiếu dịch vụ</a></li>
                <li class="divider"></li>
                <li><a href="/lib/pages/PhieuDichVu/In-PhieuChonAnh.aspx?ID=<%=Item.ID %>">Phiếu chọn ảnh</a></li>
              </ul>
            </div>
        <%} %>
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
                            <i class="glyphicon glyphicon-plus"></i>
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
                <label for="NgayTuVan" class="col-sm-2 control-label">Ngày:</label>
                <div class="col-sm-2">
                    <div class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.NgayTuVan == DateTime.MinValue ?  DateTime.Now.ToString("dd/MM/yyyy") : Item.NgayTuVan.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control NgayTuVan" 
                            id="NgayTuVan" 
                            name="NgayTuVan" 
                            type="text"/>
                        <span class="add-on input-group-addon">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                            </i>
                        </span>
                    </div>
                </div>
            </div>            
            <div class="form-group">
                <label for="TuVanVien_Ten" class="col-sm-2 control-label">Tư vấn:</label>
                <div class="col-sm-2">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-cached="1" data-src="/lib/ajax/NhanVien/Default.aspx" data-refId="TuVanVien" name="TuVanVien_Ten" id="TuVanVien_Ten" 
                            value="<%=Item.TuVanVien_Ten %>" class="form-control form-autocomplete-input TuVanVien_Ten">
                        <input type="text" name="TuVanVien" id="TuVanVien" value="<%=Item.TuVanVien %>" class="form-control TuVanVien" style="display: none;">
                    </div>
                </div>
                <label for="TrangThai" class="col-sm-2 control-label">Trạng thái:</label>
                <div class="col-sm-2">
                    <uc1:ListPhieuDichVuTrangThai runat="server" ID="ListPhieuDichVuTrangThai" />
                </div>
                <label for="GDV_Ten" class="col-sm-2 control-label">Gói:</label>
                <div class="col-sm-2">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-cached="1" 
                            data-src="/lib/ajax/GoiDichVu/Default.aspx" 
                            data-savedUrl="/lib/ajax/PhieuDichVuDichVu/Default.aspx"
                            data-refId="GDV_ID" name="GDV_Ten" 
                            data-pdvId="<%=Item.ID %>"
                            id="GDV_Ten" value="<%=Item.GDV_Ten %>" 
                            class="form-control form-autocomplete-input-PdvChonGoi GDV_Ten">
                        <input type="text" name="GDV_ID" id="GDV_ID" value="<%=Item.GDV_ID %>" class="form-control GDV_ID" style="display: none;">
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label for="TrangThai" class="col-sm-2 control-label">
                    Duyệt Ekip:
                </label>
                <div class="col-sm-10">
                    <%if (Item.DuyetEkip)
                    {%>
                        <p class="form-control-static">
                            Đã duyệt Ekip. <strong><%=Item.NguoiDuyet_Ten %></strong> ngày <%=Item.NgayDuyetEkip.ToString("dd/MM/yyyy") %>
                        </p>
                    <%}
                    else
                    {%>
                        <p class="form-control-static">
                            Chưa duyệt e-kip
                            </p>
                    <% } %>
                </div>
            </div>
            <hr/>
            <p>
                <a href="javascript:;" class="btn btn-link" data-toggle="collapse" data-target="#DichVuPnl">
                    Dịch vụ
                </a>
            </p>
            <div class="collapse in" id="DichVuPnl">
                <uc1:List runat="server" ID="DichVuList" />
            </div>
            <hr/>
            <div class="form-group">
                <label for="TongTien" class="col-sm-1 control-label">Tổng:</label>
                <div class="col-sm-2">
                    <input id="TongTien" type="text" class="form-control money-input TongTien" value="<%=Item.TongTien %>" name="TongTien"/>
                </div>
                <label for="DatCoc" class="col-sm-1 control-label">Đặt cọc:</label>
                <div class="col-sm-2">
                    <input id="DatCoc" type="text" class="form-control money-input DatCoc" value="<%=Item.DatCoc %>" name="DatCoc"/>
                </div>
                <label for="ThanhToan" class="col-sm-1 control-label">Đã trả:</label>
                <div class="col-sm-2">
                    <input id="ThanhToan" disabled="disabled" type="text" class="form-control money-input ThanhToan" value="<%=Item.X_ThanhToan %>"/>
                </div>
                <label for="ConNo" class="col-sm-1 control-label">Còn nợ:</label>
                <div class="col-sm-2">
                    <input id="ConNo" type="text" disabled="disabled" class="form-control money-input ConNo" value="<%=Item.X_ConNo %>"/>
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
        <uc1:AddTask_1_1 AddUrl="/lib/pages/PhieuDichVu/Add.aspx" runat="server" id="AddTask1" />
        <%if(ThungRac){ %>
            <a href="javascript:;" class="btn btn-success restorebtn">Khôi phục</a>
        <%} %>
        <%if(!string.IsNullOrEmpty(Id)){ %>
            <div class="btn-group">
              <a href="#" class="btn btn-danger">In</a>
              <button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown">
                <span class="caret"></span>
                <span class="sr-only">Danh sách in</span>
              </button>
              <ul class="dropdown-menu" role="menu">
                <li><a href="/lib/pages/PhieuDichVu/In-HopDongDichVu.aspx?ID=<%=Item.ID %>">Hợp đồng</a></li>
                <li><a href="/lib/pages/PhieuDichVu/In-PhieuDichVu.aspx?ID=<%=Item.ID %>">Phiếu dịch vụ</a></li>
                <li class="divider"></li>
                <li><a href="/lib/pages/PhieuDichVu/In-PhieuChonAnh.aspx?ID=<%=Item.ID %>">Phiếu chọn ảnh</a></li>
              </ul>
            </div>
        <%} %>
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
    <hr />
    <h3>
        Phiếu thu
    </h3>
    <div class="panel panel-default">
        <div class="panel-heading">
            <a class="btn btn-primary" href="/lib/pages/ThuChi/Add-Thu.aspx?PDV_ID=<%=Item.ID %>">
                Thêm phiếu thu
            </a>
        </div>
        <div class="panel-body">
            <uc1:ListPhieuDichVu runat="server" ID="ListPhieuDichVu" />
        </div>
    </div>

<% } %>


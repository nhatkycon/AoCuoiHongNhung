<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_XuatNhapSanPham_Add" %>
<%@ Register TagPrefix="uc1" TagName="AddTask_1" Src="~/lib/ui/HeThong/templates/AddTask.ascx" %>
<%@ Register Src="~/lib/ui/HeThong/ListXuatNhapSanPhamTrangThai.ascx" TagPrefix="uc1" TagName="ListXuatNhapSanPhamTrangThai" %>
<%@ Register Src="~/lib/ui/PhieuXuatNhapSanPhamChiTiet/List-Edit.ascx" TagPrefix="uc1" TagName="ListEdit" %>


<link href="/lib/css/web/bootstrap-timepicker.min.css" rel="stylesheet" />
<div class="panel panel-default Normal-Pnl-Add XuatNhapSanPham-Pnl-Add"
    data-url="/lib/ajax/XuatNhapSanPham/default.aspx"
    data-success="/lib/pages/XuatNhapSanPham/Add.aspx?ID="
    data-list="/lib/pages/XuatNhapSanPham/"
    >
    <div class="panel-heading">
       <uc1:AddTask_1 AddUrl="/lib/pages/XuatNhapSanPham/Add.aspx" ListUrl="/lib/pages/XuatNhapSanPham/Default.aspx" 
           runat="server" id="AddTask" />      
        <%if(!string.IsNullOrEmpty(Id)){ %>
            <div class="btn-group">
              <a target="_blank" href="/lib/pages/XuatNhapSanPham/Print.aspx?ID=<%=Item.ID %>" class="btn btn-danger">In</a>
              <button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown">
                <span class="caret"></span>
                <span class="sr-only">Danh sách in</span>
              </button>
              <ul class="dropdown-menu" role="menu">
                  <li>
                    <a target="_blank" href="/lib/pages/XuatNhapSanPham/HopDong-Print.aspx?ID=<%=Item.ID %>" target="_blank">Hợp đồng</a>                      
                  </li>
                  <li>
                    <a target="_blank" href="/lib/pages/XuatNhapSanPham/ThanhLy-Print.aspx?ID=<%=Item.ID %>" target="_blank">Thanh lý</a>                      
                  </li>
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
                <label for="PDV_Ma" class="col-sm-2 control-label">Phiếu DV:</label>
                <div class="col-sm-2">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-src="/lib/ajax/PhieuDichVu/Default.aspx" data-refId="PDV_ID" name="PDV_Ma" id="PDV_Ma"  value="<%=Item.PDV_MaStr %>" 
                            class="form-control form-autocomplete-input PDV_Ma" autofocus>

                        <input type="text" name="PDV_ID" id="PDV_ID" value="<%=Item.PDV_ID %>" class="form-control PDV_ID" style="display: none;">
                    </div>
                </div>
                <label for="NgayLap" class="col-sm-2 control-label">Ngày lập:</label>
                <div class="col-sm-2">
                    <div class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.NgayLap == DateTime.MinValue ?  DateTime.Now.ToString("dd/MM/yyyy") : Item.NgayLap.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control NgayLap" 
                            id="NgayLap" 
                            name="NgayLap" 
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
                <label for="NgayXuat" class="col-sm-2 control-label">Ngày xuất:</label>
                <div class="col-sm-2">
                    <div class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.NgayXuat == DateTime.MinValue ?  "" : Item.NgayXuat.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control NgayXuat" 
                            id="NgayXuat" 
                            name="NgayXuat" 
                            type="text"/>
                        <span class="add-on input-group-addon">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                            </i>
                        </span>
                    </div>
                </div>
                
                <label for="NgayNhapDuKien" class="col-sm-2 control-label">Ngày trả dự kiến:</label>
                <div class="col-sm-2">
                    <div class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.NgayNhapDuKien == DateTime.MinValue ?  "" : Item.NgayNhapDuKien.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control NgayNhapDuKien" 
                            id="NgayNhapDuKien" 
                            name="NgayNhapDuKien" 
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
                
                <label for="NgayNhap" class="col-sm-2 control-label">Ngày nhập:</label>
                <div class="col-sm-2">
                    <div class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.NgayNhap == DateTime.MinValue ?  "" : Item.NgayNhap.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control NgayNhap" 
                            id="NgayNhap" 
                            name="NgayNhap" 
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
        <uc1:AddTask_1 AddUrl="/lib/pages/XuatNhapSanPham/Add.aspx" ListUrl="/lib/pages/XuatNhapSanPham/Default.aspx" 
           runat="server" id="AddTask1" />
        <%if(!string.IsNullOrEmpty(Id)){ %>
            <div class="btn-group">
              <a target="_blank" href="/lib/pages/XuatNhapSanPham/Print.aspx?ID=<%=Item.ID %>" class="btn btn-danger">In</a>
              <button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown">
                <span class="caret"></span>
                <span class="sr-only">Danh sách in</span>
              </button>
              <ul class="dropdown-menu" role="menu">
                  <li>
                    <a target="_blank" href="/lib/pages/XuatNhapSanPham/HopDong-Print.aspx?ID=<%=Item.ID %>" target="_blank">Hợp đồng</a>                      
                  </li>
                  <li>
                    <a target="_blank" href="/lib/pages/XuatNhapSanPham/ThanhLy-Print.aspx?ID=<%=Item.ID %>" target="_blank">Thanh lý</a>                      
                  </li>
              </ul>
            </div>
        <%} %>
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
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_PhieuDichVu_Add" %>
<%@ Register TagPrefix="uc1" TagName="AddTask_1_1" Src="~/lib/ui/HeThong/templates/AddTask.ascx" %>
<%@ Register Src="~/lib/ui/KhachHang/AddQuickModal.ascx" TagPrefix="uc1" TagName="AddQuickModal" %>
<%@ Register Src="~/lib/ui/PhieuDichVuDichVu/List.ascx" TagPrefix="uc1" TagName="List" %>
<%@ Register Src="~/lib/ui/DuyetAnh/List-Edit.ascx" TagPrefix="uc1" TagName="ListEdit" %>
<%@ Register Src="~/lib/ui/BaiHat/List-Edit.ascx" TagPrefix="uc2" TagName="ListEdit" %>
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
            <div class="collapse" id="DichVuPnl">
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

            <hr/>
            <p>
                <a href="javascript:;" class="btn btn-link" data-toggle="collapse" data-target="#ChupAnhPnl">
                    Chụp ảnh
                </a>
            </p>
            <div class="collapse<%=Item.TrangThai == 1 ? " in": "" %>" id="ChupAnhPnl">
                <hr/>
                <div class="form-group">
                    <%if(!Item.DuyetEkip){ %>
                    <label for="CHUP_NhanVien_Ten" class="col-sm-2 control-label">Thợ ảnh:</label>
                    <div class="col-sm-2">
                        <div class="input-group">
                            <span class="input-group-addon btn autocomplete-btn">
                                <i class="glyphicon glyphicon-chevron-down"></i>
                            </span>
                            <input type="text" data-cached="1"  placeholder="Nhân viên" data-src="/lib/ajax/NhanVien/Default.aspx" data-refId="CHUP_NhanVien" name="CHUP_NhanVien_Ten" id="CHUP_NhanVien_Ten" value="<%=Item.CHUP_NhanVien_Ten %>" class="form-control form-autocomplete-input CHUP_NhanVien_Ten">
                            <input type="text" name="CHUP_NhanVien" id="CHUP_NhanVien" value="<%=Item.CHUP_NhanVien %>" class="form-control CHUP_NhanVien" style="display: none;">
                        </div>
                    </div>
                    <label for="CHUP_NgayBatDau" class="col-sm-2 control-label">Từ:</label>
                    <div class="col-sm-2">
                        <div class="input-append datepicker-input date input-group">
                            <input 
                                value="<%=Item.CHUP_NgayBatDau == DateTime.MinValue ?  "" : Item.CHUP_NgayBatDau.ToString("dd/MM/yyyy") %>"
                                data-format="dd/MM/yyyy" 
                                class="form-control CHUP_NgayBatDau" 
                                id="CHUP_NgayBatDau" 
                                name="CHUP_NgayBatDau" 
                                type="text"/>
                            <span class="add-on input-group-addon">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                </i>
                            </span>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="input-group bootstrap-timepicker">
                            <input type="text" name="CHUP_NgayBatDau_Gio" id="GioXuatBen" value="<%=Item.CHUP_NgayBatDau.ToString("HH:mm") %>" class="form-control CHUP_NgayBatDau_Gio timePicker-input">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="input-group bootstrap-timepicker">
                            <input type="text" name="CHUP_NgayKetThuc_Gio" id="CHUP_NgayKetThuc_Gio" value="<%=Item.CHUP_NgayKetThuc.ToString("HH:mm") %>" class="form-control CHUP_NgayKetThuc_Gio timePicker-input">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                        </div>
                    </div>
                    <%}
                        else
                        {%>
                        <label for="CHUP_NhanVien_Ten" class="col-sm-2 control-label">Thợ ảnh:</label>
                        <div class="col-sm-2">
                            <p class="form-control-static"><%=Item.CHUP_NhanVien_Ten %></p>
                        </div>
                        <label for="CHUP_NgayBatDau" class="col-sm-2 control-label">Thời gian:</label>
                        <div class="col-sm-2">
                            <p class="form-control-static">
                            <%if (Item.CHUP_NgayBatDau != DateTime.MinValue){ %>
                                <%=Item.CHUP_NgayBatDau.ToString("HH:mm") %>-<%=Item.CHUP_NgayKetThuc.ToString("HH:mm") %> 
                                <%=Item.CHUP_NgayBatDau.ToString("dd/MM/yyyy") %>
                            <%} %>
                            </p>
                        </div>
                    <% } %>
                </div>
                <div class="form-group">
                    <label for="CHUP_DiaDiem" class="col-sm-2 control-label">Địa điểm:</label>
                    <div class="col-sm-2">
                        <textarea id="CHUP_DiaDiem" name="CHUP_DiaDiem" rows="3" class="form-control"><%=Item.CHUP_DiaDiem%></textarea>
                    </div>
                    <label for="CHUP_LoaiAlbum" class="col-sm-2 control-label">Album:</label>
                    <div class="col-sm-2">
                        <textarea id="CHUP_LoaiAlbum" name="CHUP_LoaiAlbum" rows="3" class="form-control"><%=Item.CHUP_LoaiAlbum%></textarea>
                    </div>
                    <label for="CHUP_YeuCauKhach" class="col-sm-2 control-label">Yêu cầu:</label>
                    <div class="col-sm-2">
                        <textarea id="CHUP_YeuCauKhach" name="CHUP_YeuCauKhach" rows="3" class="form-control"><%=Item.CHUP_YeuCauKhach%></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label for="CHUP_DaChuyenAnh" class="col-sm-2 control-label">Nhận ảnh thô:</label>
                    <div class="col-sm-10">
                        <%if (Item.CHUP_DaChuyenAnh)
                        {%>
                            <input class="CHUP_DaChuyenAnh input-sm" id="CHUP_DaChuyenAnh" checked="checked" name="CHUP_DaChuyenAnh" type="checkbox"/>
                            <p class="form-control-static">
                                <%=Item.CHUP_NgayChuyenAnh.ToString("HH:mm dd/MM/yyyy") %>
                            </p>
                        <%}
                        else
                        {%>
                            <input class="CHUP_DaChuyenAnh input-sm" id="Checkbox5" name="CHUP_DaChuyenAnh" type="checkbox"/>
                        <% } %>
                    </div>
                </div>
            </div>

            <hr/>
            <p>
                <a href="javascript:;" class="btn btn-link" data-toggle="collapse" data-target="#TrangDiemPnl">
                    Trang điểm
                </a>
            </p>
            <div class="collapse<%=Item.TrangThai == 1 ? " in": "" %>" id="TrangDiemPnl">
                <hr/>
                    <div class="form-group">
                <%if(!Item.DuyetEkip){ %>
                        <label for="TD_NhanVien_Ten" class="col-sm-2 control-label">Trang điểm:</label>
                        <div class="col-sm-2">
                            <div class="input-group">
                                <span class="input-group-addon btn autocomplete-btn">
                                    <i class="glyphicon glyphicon-chevron-down"></i>
                                </span>
                                <input type="text" data-cached="1"  placeholder="Nhân viên" data-src="/lib/ajax/NhanVien/Default.aspx" data-refId="TD_NhanVien" name="TD_NhanVien_Ten" id="TD_NhanVien_Ten" 
                                    value="<%=Item.TD_NhanVien_Ten %>" class="form-control form-autocomplete-input TD_NhanVien_Ten">
                                <input type="text" name="TD_NhanVien" id="TD_NhanVien" value="<%=Item.TD_NhanVien %>" class="form-control TD_NhanVien" style="display: none;">
                            </div>
                        </div>
                        <label for="TD_NgayBatDau" class="col-sm-2 control-label">Từ:</label>
                        <div class="col-sm-2">
                            <div class="input-append datepicker-input date input-group">
                                <input 
                                    value="<%=Item.TD_NgayBatDau == DateTime.MinValue ?  "" : Item.TD_NgayBatDau.ToString("dd/MM/yyyy") %>"
                                    data-format="dd/MM/yyyy" 
                                    class="form-control TD_NgayBatDau" 
                                    id="TD_NgayBatDau" 
                                    name="TD_NgayBatDau" 
                                    type="text"/>
                                <span class="add-on input-group-addon">
                                    <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                    </i>
                                </span>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="input-group bootstrap-timepicker">
                                <input type="text" name="TD_NgayBatDau_Gio" id="TD_NgayBatDau_Gio" value="<%=Item.TD_NgayBatDau.ToString("HH:mm") %>" class="form-control TD_NgayBatDau_Gio timePicker-input">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <div class="input-group bootstrap-timepicker">
                                <input type="text" name="TD_NgayKetThuc_Gio" id="TD_NgayKetThuc_Gio" value="<%=Item.TD_NgayKetThuc.ToString("HH:mm") %>" class="form-control TD_NgayKetThuc_Gio timePicker-input">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                            </div>
                        </div>
                    <%}else{ %>
                        <label for="TD_NhanVien_Ten" class="col-sm-2 control-label">
                            Trang điểm:
                        </label>
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
                    <%} %>
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
            
            <hr/>
            <p>
                <a href="javascript:;" class="btn btn-link" data-toggle="collapse" data-target="#TocPnl">
                    Làm tóc
                </a>
            </p>
            <div class="collapse<%=Item.TrangThai == 1 ? " in": "" %>" id="TocPnl">
                <hr/>
                <div class="form-group">
                    <%if(!Item.DuyetEkip){ %>
                    <label for="TOC_NhanVien" class="col-sm-2 control-label">Tóc:</label>
                    <div class="col-sm-2">
                        <div class="input-group">
                            <span class="input-group-addon btn autocomplete-btn">
                                <i class="glyphicon glyphicon-chevron-down"></i>
                            </span>
                            <input type="text"  placeholder="Nhân viên" data-cached="1" data-src="/lib/ajax/NhanVien/Default.aspx" data-refId="TOC_NhanVien" name="TOC_NhanVien_Ten" id="TOC_NhanVien_Ten" 
                                value="<%=Item.TOC_NhanVien_Ten %>" class="form-control form-autocomplete-input TOC_NhanVien_Ten">
                            <input type="text" name="TOC_NhanVien" id="TOC_NhanVien" value="<%=Item.TOC_NhanVien %>" class="form-control TOC_NhanVien" style="display: none;">
                        </div>
                    </div>
                    <label for="TOC_NgayBatDau" class="col-sm-2 control-label">Từ:</label>
                    <div class="col-sm-2">
                        <div class="input-append datepicker-input date input-group">
                            <input 
                                value="<%=Item.TOC_NgayBatDau == DateTime.MinValue ?  "" : Item.TOC_NgayBatDau.ToString("dd/MM/yyyy") %>"
                                data-format="dd/MM/yyyy" 
                                class="form-control TOC_NgayBatDau" 
                                id="TOC_NgayBatDau" 
                                name="TOC_NgayBatDau" 
                                type="text"/>
                            <span class="add-on input-group-addon">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                </i>
                            </span>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="input-group bootstrap-timepicker">
                            <input type="text" name="TOC_NgayBatDau_Gio" id="TOC_NgayBatDau_Gio" value="<%=Item.TOC_NgayBatDau.ToString("HH:mm") %>" class="form-control TOC_NgayBatDau_Gio timePicker-input">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="input-group bootstrap-timepicker">
                            <input type="text" name="TOC_NgayKetThuc_Gio" id="TOC_NgayKetThuc_Gio" value="<%=Item.TOC_NgayKetThuc.ToString("HH:mm") %>" class="form-control TOC_NgayKetThuc_Gio timePicker-input">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-time"></i></span>
                        </div>
                    </div>
                    <%}else{ %>
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
                    <%} %>
                </div>

            </div>
            
            <hr/>
            <p>
                <a href="javascript:;" class="btn btn-link" data-toggle="collapse" data-target="#PhotoShopPnl">
                    Photoshop
                </a>
            </p>
            <div class="collapse<%=Item.TrangThai == 2 ? " in": "" %>" id="PhotoShopPnl">
                <hr/>
                <div class="form-group">
                    <%if(!Item.DuyetEkip){ %>
                    <label for="PTS_NhanVien_Ten" class="col-sm-2 control-label">PhotoShop:</label>
                    <div class="col-sm-2">
                        <div class="input-group">
                            <span class="input-group-addon btn autocomplete-btn">
                                <i class="glyphicon glyphicon-chevron-down"></i>
                            </span>
                            <input type="text" placeholder="Nhân viên" data-cached="1" data-src="/lib/ajax/NhanVien/Default.aspx" data-refId="PTS_NhanVien" name="PTS_NhanVien_Ten" id="PTS_NhanVien_Ten" 
                                value="<%=Item.PTS_NhanVien_Ten %>" class="form-control form-autocomplete-input PTS_NhanVien_Ten">
                            <input type="text" name="PTS_NhanVien" id="PTS_NhanVien" value="<%=Item.PTS_NhanVien %>" class="form-control PTS_NhanVien" style="display: none;">
                        </div>
                    </div>
                    <label for="PTS_NgayBatDau" class="col-sm-2 control-label">Từ:</label>
                    <div class="col-sm-2">
                        <div class="input-append datepicker-input date input-group">
                            <input 
                                value="<%=Item.PTS_NgayBatDau == DateTime.MinValue ?  "" : Item.PTS_NgayBatDau.ToString("dd/MM/yyyy") %>"
                                data-format="dd/MM/yyyy" 
                                class="form-control PTS_NgayBatDau" 
                                id="PTS_NgayBatDau" 
                                name="PTS_NgayBatDau" 
                                type="text"/>
                            <span class="add-on input-group-addon">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                </i>
                            </span>
                        </div>
                    </div>
                    <label for="PTS_NgayKetThuc" class="col-sm-2 control-label">Đến:</label>
                    <div class="col-sm-2">
                        <div class="input-append datepicker-input date input-group">
                            <input 
                                value="<%=Item.PTS_NgayKetThuc == DateTime.MinValue ?  "" : Item.PTS_NgayKetThuc.ToString("dd/MM/yyyy") %>"
                                data-format="dd/MM/yyyy" 
                                class="form-control PTS_NgayKetThuc" 
                                id="PTS_NgayKetThuc" 
                                name="PTS_NgayKetThuc" 
                                type="text"/>
                            <span class="add-on input-group-addon">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                </i>
                            </span>
                        </div>
                    </div>
                    <%}else{ %>
                        <label for="PTS_NhanVien_Ten" class="col-sm-2 control-label">PhotoShop:</label>
                        <div class="col-sm-2">
                            <p class="form-control-static">
                                <%=Item.PTS_NhanVien_Ten %>
                            </p>
                        </div>
                        <label for="PTS_NgayBatDau" class="col-sm-2 control-label">Từ:</label>
                        <div class="col-sm-2">
                            <p class="form-control-static">
                                <%if (Item.PTS_NgayBatDau != DateTime.MinValue){ %>
                                    <%=Item.PTS_NgayBatDau.ToString("dd/MM/yyyy") %>
                                <%} %>
                                <%if (Item.PTS_NgayKetThuc != DateTime.MinValue){ %>
                                    - <%=Item.PTS_NgayKetThuc.ToString("dd/MM/yyyy") %>
                                <%} %>
                            </p>
                        </div>
                    
                    <%} %>
                </div>
                <div class="form-group">
                    <label for="PTS_NhanVienDaNhan" class="col-sm-2 control-label">Nhận việc:</label>
                    <div class="col-sm-2">
                        <%if (Item.PTS_NhanVienDaNhan)
                        {%>
                            <input class="PTS_NhanVienDaNhan input-sm" id="PTS_NhanVienDaNhan" checked="checked" name="PTS_NhanVienDaNhan" type="checkbox"/>
                        <%}
                        else
                        {%>
                            <input class="PTS_NhanVienDaNhan input-sm" id="Checkbox1" name="PTS_NhanVienDaNhan" type="checkbox"/>
                        <% } %>
                    </div>
                    <label for="PTS_NgayXemMaket" class="col-sm-2 control-label">Ngày xem maket:</label>
                    <div class="col-sm-2">
                        <div class="input-append datepicker-input date input-group">
                            <input 
                                value="<%=Item.PTS_NgayXemMaket == DateTime.MinValue ?  "" : Item.PTS_NgayXemMaket.ToString("dd/MM/yyyy") %>"
                                data-format="dd/MM/yyyy" 
                                class="form-control PTS_NgayXemMaket" 
                                id="PTS_NgayXemMaket" 
                                name="PTS_NgayXemMaket" 
                                type="text"/>
                            <span class="add-on input-group-addon">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                </i>
                            </span>
                        </div>
                    </div>
                    <label for="PTS_YeuCauKhachHang" class="col-sm-2 control-label">Yêu cầu:</label>
                    <div class="col-sm-2">
                        <textarea id="PTS_YeuCauKhachHang" name="PTS_YeuCauKhachHang" rows="3" class="form-control"><%=Item.PTS_YeuCauKhachHang%></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label for="PTS_AnhBia" class="col-sm-2 control-label">Ảnh bìa:</label>
                    <div class="col-sm-2">
                        <input id="PTS_AnhBia" type="text" class="form-control PTS_AnhBia" value="<%=Item.PTS_AnhBia %>" name="PTS_AnhBia"/>
                    </div>
                    <label for="PTS_AnhPhong" class="col-sm-2 control-label">Ảnh phóng:</label>
                    <div class="col-sm-2">
                        <input id="PTS_AnhPhong" type="text" class="form-control PTS_AnhPhong" value="<%=Item.PTS_AnhPhong %>" name="PTS_AnhPhong"/>
                    </div>
                    <label for="PTS_AnhPhongGhiChu" class="col-sm-2 control-label">Yêu cầu ảnh phóng:</label>
                    <div class="col-sm-2">
                        <textarea id="PTS_AnhPhongGhiChu" name="PTS_AnhPhongGhiChu" rows="3" class="form-control"><%=Item.PTS_AnhPhongGhiChu%></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label for="PTS_AnhBan" class="col-sm-2 control-label">Ảnh bàn:</label>
                    <div class="col-sm-2">
                        <input id="PTS_AnhBan" type="text" class="form-control PTS_AnhBan" value="<%=Item.PTS_AnhBan %>" name="PTS_AnhBan"/>
                    </div>
                    <label for="PTS_AnhBanQuyCach" class="col-sm-2 control-label">Quy cách ảnh bàn:</label>
                    <div class="col-sm-2">
                        <textarea id="PTS_AnhBanQuyCach" name="PTS_AnhBanQuyCach" rows="3" class="form-control"><%=Item.PTS_AnhBanQuyCach%></textarea>
                    </div>
                    <label for="PTS_AnhBanGhiChu" class="col-sm-2 control-label">Ghi chú ảnh bàn:</label>
                    <div class="col-sm-2">
                        <textarea id="PTS_AnhBanGhiChu" name="PTS_AnhBanGhiChu" rows="3" class="form-control"><%=Item.PTS_AnhBanGhiChu%></textarea>
                    </div>
                </div>
                <div class="form-group">
                    <label for="PTS_CD3D" class="col-sm-2 control-label">CD3D:</label>
                    <div class="col-sm-2">
                        <%if (Item.PTS_CD3D)
                        {%>
                            <input class="PTS_CD3D input-sm" id="PTS_CD3D" checked="checked" name="PTS_CD3D" type="checkbox"/>
                        <%}
                        else
                        {%>
                            <input class="PTS_CD3D input-sm" id="Checkbox2" name="PTS_CD3D" type="checkbox"/>
                        <% } %>
                    </div>
                    <label for="HoanThanh" class="col-sm-2 control-label">Hoàn thành:</label>
                    <div class="col-sm-2">
                        <%if (Item.HoanThanh)
                        {%>
                            <input class="HoanThanh input-sm" id="HoanThanh" checked="checked" name="HoanThanh" type="checkbox"/>
                        <%}
                        else
                        {%>
                            <input class="HoanThanh input-sm" id="Checkbox3" name="HoanThanh" type="checkbox"/>
                        <% } %>
                    </div>
                </div>
            </div>
            
            <hr/>
            <p>
                <a href="javascript:;" class="btn btn-link" data-toggle="collapse" data-target="#ChonAnhPnl">
                    Chọn ảnh
                </a>
            </p>
            <div class="collapse<%=Item.TrangThai == 3 ? " in": "" %>" id="ChonAnhPnl">
                <uc1:ListEdit runat="server" ID="ChonAnhList" />
            </div>
            
            <hr/>
            <p>
                <a href="javascript:;" class="btn btn-link" data-toggle="collapse" data-target="#BaiHatPnl">
                    Bài hát
                </a>
            </p>
            <div class="collapse<%=Item.TrangThai == 3 ? " in": "" %>" id="BaiHatPnl">
                <uc2:ListEdit runat="server" ID="BaiHatList" />
            </div>

            <hr/>
            <p>
                <a href="javascript:;" class="btn btn-link" data-toggle="collapse" data-target="#TraSanPhamPnl">
                    Trả sản phẩm
                </a>
            </p>
            <div class="collapse<%=Item.TrangThai == 4 ? " in": "" %>" id="TraSanPhamPnl">
                <hr/>
                <div class="form-group">
                    <label for="PTS_HenSanPham" class="col-sm-2 control-label">Hẹn khách SP:</label>
                    <div class="col-sm-2">
                        <div class="input-append datepicker-input date input-group">
                            <input 
                                value="<%=Item.PTS_HenSanPham == DateTime.MinValue ?  "" : Item.PTS_HenSanPham.ToString("dd/MM/yyyy") %>"
                                data-format="dd/MM/yyyy" 
                                class="form-control PTS_HenSanPham" 
                                id="PTS_HenSanPham" 
                                name="PTS_HenSanPham" 
                                type="text"/>
                            <span class="add-on input-group-addon">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                </i>
                            </span>
                        </div>
                    </div>
                    <label for="PTS_NgayCoSanPham" class="col-sm-2 control-label">Ngày có SP dự kiến:</label>
                    <div class="col-sm-2">
                        <div class="input-append datepicker-input date input-group">
                            <input 
                                value="<%=Item.PTS_NgayCoSanPham == DateTime.MinValue ?  "" : Item.PTS_NgayCoSanPham.ToString("dd/MM/yyyy") %>"
                                data-format="dd/MM/yyyy" 
                                class="form-control PTS_NgayCoSanPham" 
                                id="PTS_NgayCoSanPham" 
                                name="PTS_NgayCoSanPham" 
                                type="text"/>
                            <span class="add-on input-group-addon">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                </i>
                            </span>
                        </div>
                    </div>
                    
                </div>
                <div>
                    <label for="PTS_DaCoSanPham" class="col-sm-2 control-label">Đã có sản phẩm:</label>
                    <div class="col-sm-2">
                        <%if (Item.PTS_DaCoSanPham)
                        {%>
                            <input class="PTS_DaCoSanPham input-sm" id="PTS_DaCoSanPham" checked="checked" name="PTS_DaCoSanPham" type="checkbox"/>
                        <%}
                        else
                        {%>
                            <input class="PTS_DaCoSanPham input-sm" id="Checkbox4" name="PTS_DaCoSanPham" type="checkbox"/>
                        <% } %>
                    </div>
                    <label for="PTS_NgayLaySanPham" class="col-sm-2 control-label">Ngày KH lấy SP:</label>
                    <div class="col-sm-2">
                        <div class="input-append datepicker-input date input-group">
                            <input 
                                value="<%=Item.PTS_NgayLaySanPham == DateTime.MinValue ?  "" : Item.PTS_NgayLaySanPham.ToString("dd/MM/yyyy") %>"
                                data-format="dd/MM/yyyy" 
                                class="form-control PTS_NgayLaySanPham" 
                                id="PTS_NgayLaySanPham" 
                                name="PTS_NgayLaySanPham" 
                                type="text"/>
                            <span class="add-on input-group-addon">
                                <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                                </i>
                            </span>
                        </div>
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


<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add-Pts.ascx.cs" Inherits="lib_ui_PhieuDichVu_Add_Pts" %>
<%@ Register Src="~/lib/ui/KhachHang/AddQuickModal.ascx" TagPrefix="uc1" TagName="AddQuickModal" %>
<%@ Register Src="~/lib/ui/DuyetAnh/List-Edit.ascx" TagPrefix="uc1" TagName="ListEdit" %>
<%@ Register Src="~/lib/ui/BaiHat/List-Edit.ascx" TagPrefix="uc2" TagName="ListEdit" %>
<%@ Register Src="~/lib/ui/HeThong/ListPhieuDichVuTrangThai.ascx" TagPrefix="uc1" TagName="ListPhieuDichVuTrangThai" %>
<%@ Register TagPrefix="uc1" TagName="AddTask_1_1_1" Src="~/lib/ui/HeThong/templates/AddTask.ascx" %>
<%@ Register Src="~/lib/ui/PhieuDichVuDichVu/List-View.ascx" TagPrefix="uc1" TagName="ListView" %>




<link href="/lib/css/web/bootstrap-timepicker.min.css" rel="stylesheet" />
<div class="panel panel-default Normal-Pnl-Add PhieuDichVu-Pnl-Add"
    data-url="/lib/ajax/PhieuDichVu/default.aspx"
    data-success="/lib/pages/PhieuDichVu/Add-Pts.aspx?ID="
    data-list="/lib/pages/PhieuDichVu/List-Pts.aspx"
    >
    <div class="panel-heading">
        <uc1:AddTask_1_1_1 AddUrl="/lib/pages/PhieuDichVu/Add-Pts.aspx" 
            ListUrl="/lib/pages/PhieuDichVu/List-Pts.aspx" runat="server" id="AddTask" />
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
                    <uc1:ListPhieuDichVuTrangThai runat="server" ID="ListPhieuDichVuTrangThai" />
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
            <div class="collapse" id="DichVuPnl">
                <uc1:ListView runat="server" ID="DichVuList" />
            </div>
            
            <hr/>
            <p>
                <a href="javascript:;" class="btn btn-link" data-toggle="collapse" data-target="#ChupAnhPnl">
                    Chụp ảnh
                </a>
            </p>
            <div class="collapse in" id="ChupAnhPnl">
                <hr/>
                <div class="form-group">
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
                </div>
                <div class="form-group">
                    <label for="CHUP_DiaDiem" class="col-sm-2 control-label">Địa điểm:</label>
                    <div class="col-sm-2">
                        <p class="form-control-static"><%=Item.CHUP_DiaDiem %></p>
                    </div>
                    <label for="CHUP_LoaiAlbum" class="col-sm-2 control-label">Album:</label>
                    <div class="col-sm-2">
                        <p class="form-control-static"><%=Item.CHUP_LoaiAlbum %></p>
                    </div>
                    <label for="CHUP_YeuCauKhach" class="col-sm-2 control-label">Yêu cầu:</label>
                    <div class="col-sm-2">
                        <p class="form-control-static"><%=Item.CHUP_YeuCauKhach %></p>
                    </div>
                </div>
                <div class="form-group">
                    <label for="CHUP_DaChuyenAnh" class="col-sm-2 control-label">Nhận ảnh thô:</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" value="1" style="display: none;" name="CHUP_DaChuyenAnh_U"/>
                        <%if (Item.CHUP_DaChuyenAnh)
                        {%>
                            <input class="CHUP_DaChuyenAnh input-sm" id="CHUP_DaChuyenAnh" disabled checked="checked" type="checkbox"/>
                            <p class="form-control-static">
                                <%=Item.CHUP_NgayChuyenAnh.ToString("HH:mm dd/MM/yyyy") %>
                            </p>
                        <%}
                        else
                        {%>
                            <input class="CHUP_DaChuyenAnh input-sm" id="Checkbox5"  disabled type="checkbox"/>
                        <% } %>
                    </div>
                    <label for="PTS_ThuMuc" class="col-sm-2 control-label">Thư mục:</label>
                    <div class="col-sm-6">
                        <input id="PTS_ThuMuc" type="text" class="form-control PTS_ThuMuc" value="<%=Item.PTS_ThuMuc %>" name="PTS_ThuMuc"/>
                    </div>
                </div>
            </div>

            
            <hr/>
            <p>
                <a href="javascript:;" class="btn btn-link" data-toggle="collapse" data-target="#PhotoShopPnl">
                    Photoshop
                </a>
            </p>
            <div class="collapse in" id="PhotoShopPnl">
                <hr/>
                <div class="form-group">
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
                </div>
                <div class="form-group">
                    <label for="PTS_NhanVienDaNhan" class="col-sm-2 control-label">Nhận việc:</label>
                    <div class="col-sm-2">
                        <input type="text" class="form-control" value="1" style="display: none;" name="PTS_NhanVienDaNhan_U"/>
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
                    <label for="PTS_AnhBiaMau" class="col-sm-2 control-label">màu bìa:</label>
                    <div class="col-sm-2">
                        <input id="PTS_AnhBiaMau" type="text" class="form-control PTS_AnhBiaMau" value="<%=Item.PTS_AnhBiaMau %>" name="PTS_AnhBiaMau"/>
                    </div>
                </div>
                <div class="form-group">
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
                        <input type="text" class="form-control" value="1" style="display: none;" name="PTS_CD3D_U"/>
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
                        <input type="text" class="form-control" value="1" style="display: none;" name="HoanThanh_U"/>
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
            <div class="collapse in" id="ChonAnhPnl">
                <uc1:ListEdit runat="server" ID="ChonAnhList" />
            </div>
            
            <hr/>
            <p>
                <a href="javascript:;" class="btn btn-link" data-toggle="collapse" data-target="#BaiHatPnl">
                    Bài hát
                </a>
            </p>
            <div class="collapse in" id="BaiHatPnl">
                <uc2:ListEdit runat="server" ID="BaiHatList" />
            </div>

            <hr/>
            <p>
                <a href="javascript:;" class="btn btn-link" data-toggle="collapse" data-target="#TraSanPhamPnl">
                    Trả sản phẩm
                </a>
            </p>
            <div class="collapse in" id="TraSanPhamPnl">
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
                    <label for="PTS_DaCoSanPham" class="col-sm-2 control-label">Đã có sản phẩm:</label>
                    <div class="col-sm-2">
                        <input type="text" class="form-control" value="1" style="display: none;" name="PTS_DaCoSanPham_U"/>
                        <%if (Item.PTS_DaCoSanPham)
                        {%>
                            <input class="PTS_DaCoSanPham input-sm" id="PTS_DaCoSanPham" checked="checked" name="PTS_DaCoSanPham" type="checkbox"/>
                        <%}
                        else
                        {%>
                            <input class="PTS_DaCoSanPham input-sm" id="Checkbox4" name="PTS_DaCoSanPham" type="checkbox"/>
                        <% } %>
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
        <uc1:AddTask_1_1_1 AddUrl="/lib/pages/PhieuDichVu/Add-Pts.aspx" ListUrl="/lib/pages/PhieuDichVu/List-Pts.aspx" runat="server" id="AddTask1" />
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
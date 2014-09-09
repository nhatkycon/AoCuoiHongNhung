<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add-Core.ascx.cs" Inherits="lib_ui_ThuChi_Add_Core" %>
<%@ Register TagPrefix="uc1" TagName="DanhMucListByLdmMa" Src="~/lib/ui/HeThong/DanhMucListByLdmMa.ascx" %>
<%@ Import Namespace="linh.common" %>
<div class="form-horizontal" role="form">
    <input id="Id" style="display: none;" value="<%=Item.ID == Guid.Empty ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
    <div class="form-group">
            <label for="SoPhieu" class="col-sm-2 control-label">Mã:</label>
            <div class="col-sm-4">
                <input id="SoPhieu" type="text"  class="form-control" value="<%=Item.Ma %>" name="SoPhieu"/>
            </div>
            <label for="NgayTrenPhieu" class="col-sm-2 control-label">Ngày lập:</label>
            <div class="col-sm-4">
                <div class="input-append datepicker-input date input-group">
                    <input 
                        value="<%=Item.NgayTrenPhieu == DateTime.MinValue ?  DateTime.Now.ToString("dd/MM/yyyy") : Item.NgayTrenPhieu.ToString("dd/MM/yyyy") %>"
                        data-format="dd/MM/yyyy" 
                        class="form-control NgayTrenPhieu" 
                        id="NgayTrenPhieu" 
                        name="NgayTrenPhieu" 
                        type="text"/>
                    <span class="add-on input-group-addon">
                        <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                        </i>
                    </span>
                </div>
            </div>
        </div>
        <%if (Thu){ %>
            <input style="display: none;" value="true" name="Thu" type="text" />
            <div class="form-group">
                <label for="PDV_Ma" class="col-sm-2 control-label">Phiếu DV:</label>
                <div class="col-sm-4">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-src="/lib/ajax/PhieuDichVu/Default.aspx" data-refId="PDV_ID" name="PDV_Ma" id="PDV_Ma"  value="<%=Item.PDV_MaStr %>" 
                            class="form-control form-autocomplete-input PDV_Ma" autofocus>
                        <input type="text" name="PDV_ID" id="PDV_ID" value="<%=Item.PDV_ID %>" class="form-control PDV_ID" style="display: none;">
                    </div>
                </div>
                <div class="col-sm-2">
                    <%if(Item.PDV_ID!=Guid.Empty){ %>
                        <a class="btn btn-link" href="/lib/pages/PhieuDichVu/Add.aspx?ID=<%=Item.PDV_ID %>&ret=<%=Server.UrlEncode(Request.Url.PathAndQuery) %>">
                            <i class="glyphicon glyphicon-info-sign"></i>
                        </a>
                    <%} %>
                </div>
            </div>
            <div class="form-group">
                <label for="CTV_MaStr" class="col-sm-2 control-label">Phiếu Thuê váy:</label>
                <div class="col-sm-4">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-src="/lib/ajax/ChoThueVay/Default.aspx" data-refId="CTV_ID" name="CTV_MaStr" id="CTV_MaStr"  value="<%=Item.CTV_MaStr %>" 
                            class="form-control form-autocomplete-input CTV_MaStr" autofocus>
                        <input type="text" name="CTV_ID" id="CTV_ID" value="<%=Item.CTV_ID %>" class="form-control CTV_ID" style="display: none;">
                    </div>
                </div>
                <div class="col-sm-2">
                    <%if(Item.CTV_ID!=Guid.Empty){ %>
                        <a class="btn btn-link" href="/lib/pages/ChoThueVay/Add.aspx?ID=<%=Item.CTV_ID %>&ret=<%=Server.UrlEncode(Request.Url.PathAndQuery) %>">
                            <i class="glyphicon glyphicon-info-sign"></i>
                        </a>
                    <%} %>
                </div>
            </div>
            <div class="form-group">
                <label for="PBH_MaStr" class="col-sm-2 control-label">Phiếu báo hỏng:</label>
                <div class="col-sm-4">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-src="/lib/ajax/PhieuBaoHong/Default.aspx" data-refId="PBH_ID" name="PBH_MaStr" id="PBH_MaStr"  value="<%=Item.PBH_MaStr %>" 
                            class="form-control form-autocomplete-input PBH_MaStr" autofocus>
                        <input type="text" name="PBH_ID" id="PBH_ID" value="<%=Item.PBH_ID %>" class="form-control PBH_ID" style="display: none;">
                    </div>
                </div>
                <div class="col-sm-2">
                    <%if(Item.PBH_ID!=Guid.Empty){ %>
                        <a class="btn btn-link" href="/lib/pages/PhieuBaoHong/Add.aspx?ID=<%=Item.PBH_ID %>&ret=<%=Server.UrlEncode(Request.Url.PathAndQuery) %>">
                            <i class="glyphicon glyphicon-info-sign"></i>
                        </a>
                    <%} %>
                </div>
            </div>
        <%}else{ %>
            <div class="form-group">
            <input style="display: none;" value="false" name="Thu" type="text" />
                    <label for="PGV_MaStr" class="col-sm-2 control-label">Phiếu giặt là:</label>
                <div class="col-sm-4">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-src="/lib/ajax/GiatLa/Default.aspx" data-refId="PGV_ID" name="PGV_MaStr" id="PGV_MaStr"  value="<%=Item.PGV_MaStr %>" 
                            class="form-control form-autocomplete-input PGV_MaStr" autofocus>
                        <input type="text" name="PGV_ID" id="PGV_ID" value="<%=Item.PGV_ID %>" class="form-control PGV_ID" style="display: none;">
                    </div>
                </div>
                <div class="col-sm-2">
                    <%if(Item.PDV_ID!=Guid.Empty){ %>
                        <a class="btn btn-link" href="/lib/pages/GiatLa/Add.aspx?ID=<%=Item.PGV_ID %>&ret=<%=Server.UrlEncode(Request.Url.PathAndQuery) %>">
                            <i class="glyphicon glyphicon-info-sign"></i>
                        </a>
                    <%} %>
                </div>
            </div>
        <%} %>
    <div class="form-group">
        <label for="P_Ten" class="col-sm-2 control-label">
            <%=Thu ? "Người nộp:" : "Người lĩnh:"  %>
        </label>
        <div class="col-sm-4">
            <div class="input-group">
                <span class="input-group-addon btn autocomplete-btn">
                    <i class="glyphicon glyphicon-chevron-down"></i>
                </span>
                <input type="text" data-src="/lib/ajax/KhachHang/Default.aspx" data-refId="P_ID" name="P_Ten" id="P_Ten"  value="<%=Item.P_Ten %>" 
                    class="form-control form-autocomplete-input P_Ten" autofocus>
                <input type="text" name="P_ID" id="P_ID" value="<%=Item.P_ID == Guid.Empty ? string.Empty : Item.P_ID.ToString() %>" class="form-control P_ID" style="display: none;">
                <a href="javascript:;" class="input-group-addon btn btn-default btnThemNhanhKH" data-toggle="modal" data-target="#KhachHangAddQuickModal">
                    <i class="glyphicon glyphicon-user"></i> Thêm
                </a>
            </div>
            <%if (!string.IsNullOrEmpty(Item.P_Ten)){ %>
                <div class="help-block">
                    <a class="btn btn-link" href="/lib/pages/KhachHang/Add.aspx?ID=<%=Item.P_Ten %>&ret=<%=Server.UrlEncode(Request.Url.PathAndQuery) %>">
                        <i class="glyphicon glyphicon-info-sign"></i> <%=Item.P_Ten %>
                    </a>
                </div>
            <%} %>
        </div>
    </div>
    <div class="form-group">
        <label for="DM_ID" class="col-sm-2 control-label">Loại:</label>
        <div class="col-sm-4">
            <uc1:DanhMucListByLdmMa ClientIDMode="Static" 
            ControlId="NDTC_ID" ID="DM_ID" 
            ControlName="NDTC_ID" runat="server" />
        </div>
        <label for="LoaiQuy" class="col-sm-2 control-label">Quỹ:</label>
        <div class="col-sm-4">
            <select name="LoaiQuy" id="LoaiQuy" class="form-control LoaiQuy">
                <option value="0">Tiền mặt</option>
                <option value="1">Tài khoản</option>
            </select>
        </div>
    </div>
    <div class="form-group">
        <label for="SoTien" class="col-sm-2 control-label">Tiền:</label>
        <div class="col-sm-4">
            <input id="SoTien" type="text" class="form-control money-input SoTien" value="<%=Lib.TienVietNam(Item.SoTien) %>" name="SoTien"/>
        </div>
        <label for="NguoiTao_Ten" class="col-sm-2 control-label">Nhân viên:</label>
        <div class="col-sm-4">
            <div class="input-group">
                <span class="input-group-addon btn autocomplete-btn">
                    <i class="glyphicon glyphicon-chevron-down"></i>
                </span>
                <input type="text" data-cached="1" data-src="/lib/ajax/NhanVien/Default.aspx" data-refId="NguoiTao" name="NguoiTao_Ten" id="NguoiTao_Ten" value="<%=Item.NguoiTao_Ten %>" class="form-control form-autocomplete-input NguoiTao_Ten">
                <input type="text" name="NguoiTao" id="NguoiTao" value="<%=Item.NguoiTao %>" class="form-control NguoiTao" style="display: none;">
            </div>
        </div>
    </div>
    <div class="form-group">
        <label for="MoTa" class="col-sm-2 control-label">Mô tả:</label>
        <div class="col-sm-10">
            <textarea id="Mota" name="Mota" type="text" rows="3" class="form-control"><%=Item.Mota%></textarea>
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
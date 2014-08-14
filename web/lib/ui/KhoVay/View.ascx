<%@ Control Language="C#" AutoEventWireup="true" CodeFile="View.ascx.cs" Inherits="lib_ui_KhoVay_View" %>
<%@ Import Namespace="linh.common" %>
<%@ Register Src="~/lib/ui/HeThong/templates/AddTask.ascx" TagPrefix="uc1" TagName="AddTask" %>
<%@ Register Src="~/lib/ui/KhoVay/LichThang.ascx" TagPrefix="uc1" TagName="LichThang" %>
<%@ Register Src="~/lib/ui/XuatNhapSanPham/List.ascx" TagPrefix="uc1" TagName="List" %>
<%@ Register Src="~/lib/ui/ChoThueVay/List.ascx" TagPrefix="uc2" TagName="List" %>
<%@ Register Src="~/lib/ui/GiatLa/List.ascx" TagPrefix="uc3" TagName="List" %>
<%@ Register Src="~/lib/ui/PhieuBaoHong/List.ascx" TagPrefix="uc4" TagName="List" %>

<div class="panel panel-default KhoVay-Pnl-Add">
    <div class="panel-heading">
        <uc1:AddTask ListUrl="/lib/pages/KhoVay/Default.aspx" runat="server" Id="AddTask" />
    </div>
    <div class="panel-body">
        <div class="form-horizontal" role="form">
            <input id="Id" style="display: none;" value="<%=Item.ID == Guid.Empty ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
            <div class="form-group">
                <label class="col-sm-2 control-label">Mã:</label>
                <div class="col-sm-4">
                    <p class="form-control-static">
                        <%=Item.Ma %>
                    </p>
                </div>
                <label class="col-sm-2 control-label">Tên:</label>
                <div class="col-sm-4">
                    <p class="form-control-static">
                        <%=Item.Ten %>
                    </p>
                </div>
            </div>

            <div class="form-group">
                <label class="col-sm-2 control-label">Nhóm:</label>
                <div class="col-sm-4">
                    <p class="form-control-static">
                        <%=Item.DM_Ten %>
                    </p>
                </div>
                <label class="col-sm-2 control-label">Giá:</label>
                <div class="col-sm-4">
                    <p class="form-control-static">
                        <%=Lib.TienVietNam(Item.GNY) %>
                    </p>
                </div>
            </div>
            
            <div class="form-group">
                <label class="col-sm-2 control-label">Mô tả:</label>
                <div class="col-sm-10">
                    <p class="form-control-static">
                        <%=Item.MoTa %>
                    </p>
                    <%if (!string.IsNullOrEmpty(Item.Anh)){ %>
                        <hr/>
                        <img src="<%=Item.Anh %>" class="img-rounded img-thumbnail imgfinder-img"/>
                    <%} %>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-2 control-label">Hỏng:</label>
                <div class="col-sm-4">
                    <p class="form-control-static">
                        <%if (Item.HongVay)
                        {%>
                            Đã hỏng
                        <%}
                        else
                        {%>
                            Chưa hỏng
                        <% } %>
                    </p>    
                </div>
                <label class="col-sm-2 control-label">Tình trạng:</label>
                <div class="col-sm-4">
                    <p class="form-control-static">
                        <%if (Item.HetHang)
                        {%>
                            Hết
                        <%}
                        else
                        {%>
                            Còn
                        <% } %>
                    </p>    
                </div>
            </div>
            <hr />
            <div class="form-group">
                <uc1:LichThang runat="server" ID="LichThang" />
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
        <uc1:AddTask ListUrl="/lib/pages/KhoVay/Default.aspx" runat="server" Id="AddTask1" />
    </div>
</div>

<%if (!string.IsNullOrEmpty(Id)){ %>

<h3> Xuất Sản phẩm phụ kiện</h3>
<uc1:List runat="server" ID="ListXuatNhap" />
<hr/>
<h3>
    Cho thuê váy
</h3>
<hr/>
<uc2:List runat="server" ID="ListChoThueVay" />
<h3>
     Giặt là
</h3>
<uc3:List runat="server" ID="ListGiatLa" />
<hr/>
<h3>
     Báo hỏng
</h3>
<uc4:List runat="server" ID="ListPhieuBaoHong" />
<%} %>
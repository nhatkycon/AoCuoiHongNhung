<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_PhieuBaoHong_Add" %>
<%@ Register TagPrefix="uc1" TagName="AddTask_1" Src="~/lib/ui/HeThong/templates/AddTask.ascx" %>
<%@ Register Src="~/lib/ui/ThuChi/List-PhieuDichVu.ascx" TagPrefix="uc1" TagName="ListPhieuDichVu" %>

<link href="/lib/css/web/bootstrap-timepicker.min.css" rel="stylesheet" />
<div class="panel panel-default Normal-Pnl-Add PhieuBaoHong-Pnl-Add"
    data-url="/lib/ajax/PhieuBaoHong/default.aspx"
    data-success="/lib/pages/PhieuBaoHong/Add.aspx?ID="
    data-list="/lib/pages/PhieuBaoHong/"
    >
    <div class="panel-heading">
       <uc1:AddTask_1 AddUrl="/lib/pages/PhieuBaoHong/Add.aspx" ListUrl="/lib/pages/PhieuBaoHong/Default.aspx" 
           runat="server" id="AddTask" />               
    </div>
    <div class="panel-body">
        <div class="form-horizontal" role="form">
            <input id="Id" style="display: none;" value="<%=Item.ID == Guid.Empty ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
            <div class="form-group">
                <label for="Ma" class="col-sm-2 control-label">Mã:</label>
                <div class="col-sm-4">
                    <input id="Ma" type="text"  class="form-control" data-ma="<%=Item.Ma %>" value="<%=Item.MaStr %>" name="Ma"/>
                </div>
                <label for="LYDO_Ten" class="col-sm-2 control-label">Lý do:</label>
                <div class="col-sm-4">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-cached="1" data-src="/lib/ajax/DanhMuc/Default.aspx?LDM=LyDoHongVay" data-refId="LYDO_ID" name="LYDO_Ten" id="LYDO_Ten"  
                            value="<%=Item.LYDO_Ten %>" 
                            class="form-control form-autocomplete-input CH_Ten" autofocus>
                        <input type="text" name="LYDO_ID" id="LYDO_ID" value="<%=Item.LYDO_ID %>" class="form-control LYDO_ID" style="display: none;">
                    </div>
                </div>
                
            </div>
            <div class="form-group">
                
                <label for="NgayBaoHong" class="col-sm-2 control-label">Ngày:</label>
                <div class="col-sm-4">
                    <div class="input-append datepicker-input date input-group">
                        <input 
                            value="<%=Item.NgayBaoHong == DateTime.MinValue ?  "" : Item.NgayBaoHong.ToString("dd/MM/yyyy") %>"
                            data-format="dd/MM/yyyy" 
                            class="form-control NgayBaoHong" 
                            id="NgayBaoHong" 
                            name="NgayBaoHong" 
                            type="text"/>
                        <span class="add-on input-group-addon">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar" class="glyphicon glyphicon-calendar">
                            </i>
                        </span>
                    </div>
                </div>
                <label for="NhanVien_Ten" class="col-sm-2 control-label">Nhân viên:</label>
                <div class="col-sm-4">
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
                <label for="HH_Ten" class="col-sm-2 control-label">Váy:</label>
                <div class="col-sm-4">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-cached="1" data-src="/lib/ajax/HangHoa/Default.aspx" data-refId="HH_ID" name="HH_Ten" id="HH_Ten" value="<%=Item.HH_Ten %>" class="form-control form-autocomplete-input HH_Ten">
                        <input type="text" name="HH_ID" id="HH_ID" value="<%=Item.HH_ID %>" class="form-control HH_ID" style="display: none;">
                    </div>
                </div>
                <label for="Tien" class="col-sm-2 control-label">Tiền:</label>
                <div class="col-sm-4">
                    <input id="Tong" type="text" class="form-control money-input Tien" value="<%=Item.Tien %>" name="Tien"/>
                </div>
            </div>
            <div class="form-group">
                <label for="MoTa" class="col-sm-2 control-label">Ghi chú:</label>
                <div class="col-sm-10">
                    <textarea id="MoTa" name="MoTa" type="text" rows="3" class="form-control"><%=Item.MoTa%></textarea>
                </div>
            </div>
            <%if (!string.IsNullOrEmpty(Id))
            {%>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Tình trạng:</label>
                    <div class="col-sm-2">
                        <%if (Item.Duyet)
                        {%>
                            <p class="form-control-static">
                                <strong><%=Item.NguoiDuyet_Ten %></strong> ngày <%=Item.NgayDuyet.ToString("dd/MM/yyyy") %>                        
                            </p>
                        <%}
                        else
                        {%>
                           <p class="form-control-static">
                                Chưa duyệt
                            </p>
                        <% } %>
                    </div>
                </div>
            <%} %>
            
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
        <uc1:AddTask_1 AddUrl="/lib/pages/PhieuBaoHong/Add.aspx" ListUrl="/lib/pages/PhieuBaoHong/Default.aspx" 
           runat="server" id="AddTask1" />
    </div>
</div>

<script src="/lib/js/jQueryLib/bootstrap-timepicker.min.js"></script>
<%if (!string.IsNullOrEmpty(Id))
{%>
    <hr />
    <h3>
        Phiếu thu
    </h3>
    <div class="panel panel-default">
        <div class="panel-heading">
            <a class="btn btn-primary" href="/lib/pages/ThuChi/Add-Thu.aspx?PBH_ID=<%=Item.ID %>">
                Thêm phiếu thu
            </a>
        </div>
        <div class="panel-body">
            <uc1:ListPhieuDichVu runat="server" ID="ListPhieuDichVu" />
        </div>
    </div>
<%} %>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_HangHoa_Add" %>
<%@ Register Src="~/lib/ui/HeThong/templates/AddTask.ascx" TagPrefix="uc1" TagName="AddTask" %>

<div class="panel panel-default Normal-Pnl-Add HangHoa-Pnl-Add"
    data-url="/lib/ajax/HangHoa/default.aspx"
    data-success="/lib/pages/HangHoa/Add.aspx?ID="
    data-list="/lib/pages/HangHoa/"
    >
    <div class="panel-heading">
        <uc1:AddTask AddUrl="/lib/pages/HangHoa/Add.aspx" ListUrl="/lib/pages/HangHoa/Default.aspx" runat="server" id="AddTask" />
    </div>
    <div class="panel-body">
        <div class="form-horizontal" role="form">
            <input id="Id" style="display: none;" value="<%=Item.ID == Guid.Empty ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
            <div class="form-group">
                <label for="DM_ID" class="col-sm-2 control-label">Nhóm</label>
                <div class="col-sm-4">
                    <div class="input-group">
                        <span class="input-group-addon btn autocomplete-btn">
                            <i class="glyphicon glyphicon-chevron-down"></i>
                        </span>
                        <input type="text" data-cached="1" data-src="/lib/ajax/DanhMuc/Default.aspx?LDM=HangHoa" data-refId="DM_ID" name="DM_Ten" id="DM_Ten"  value="<%=Item.DM_Ten %>" 
                            class="form-control form-autocomplete-input DM_ID" autofocus>
                        <input type="text" name="DM_ID" id="DM_ID" value="<%=Item.DM_ID %>" class="form-control DM_ID" style="display: none;">
                    </div>
                </div>
                <label for="Ma" class="col-sm-2 control-label">Mã</label>
                <div class="col-sm-4">
                    <input id="Ma" type="text" class="form-control" value="<%=Item.Ma %>" name="Ma"/>
                </div>
            </div>            
            <div class="form-group">
                <label for="Ten" class="col-sm-2 control-label">Tên</label>
                <div class="col-sm-10">
                    <input id="Ten" type="text" class="form-control" value="<%=Item.Ten %>" name="Ten"/>
                </div>
            </div>
            <div class="form-group">
                <label for="MoTa" class="col-sm-2 control-label">Mô tả</label>
                <div class="col-sm-10">
                    <textarea id="MoTa" name="MoTa" type="text" rows="3" class="form-control"><%=Item.MoTa%></textarea>
                </div>
            </div>
            <div class="form-group">
                <label for="GNY" class="col-sm-2 control-label">Giá:</label>
                <div class="col-sm-2">
                    <input id="GNY" type="text" class="form-control money-input" value="<%=Item.GNY %>" name="GNY"/>
                </div>
                <label for="GiaMin" class="col-sm-2 control-label">Min:</label>
                <div class="col-sm-2">
                    <input id="GiaMin" type="text" class="form-control money-input" value="<%=Item.GiaMin %>" name="GiaMin"/>
                </div>
                <label for="GiaMax" class="col-sm-2 control-label">Max:</label>
                <div class="col-sm-2">
                    <input id="GiaMax" type="text" class="form-control money-input" value="<%=Item.GiaMax %>" name="GiaMax"/>
                </div>
            </div>
            <div class="form-group">
                <label for="Anh" class="col-sm-2 control-label">Ảnh</label>
                <div class="col-sm-10">
                    <input id="Anh" class="Anh" name="Anh" value="<%=Item.Anh %>" type="text" style="display: none;" />
                    <div class="imgfinder-box">
                        <div class="imgfinder-cover">
                            <div class="imgfinder-overlay">
                                <span title="Chọn ảnh" class="btn btn-primary imgfinder-changeBtn">Chọn</span> &nbsp;
                                <span title="xóa ảnh" class="btn btn-default imgfinder-removeBtn">
                                    <i class="glyphicon glyphicon-remove"></i>
                                </span>
                            </div>
                        </div>
                        <img src="<%=Item.Anh %>" class="img-rounded img-thumbnail imgfinder-img"/>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label for="DichVu" class="col-sm-2 control-label">Dịch vụ:</label>
                <div class="col-sm-2">
                    <%if (Item.DichVu)
                    {%>
                        <input class="DichVu input-sm" id="DichVu" checked="checked" name="DichVu" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="DichVu input-sm" id="DichVu" name="DichVu" type="checkbox"/>
                    <% } %>
                </div>
                <label for="KhoVay" class="col-sm-2 control-label">Kho váy:</label>
                <div class="col-sm-2">
                    <%if (Item.KhoVay)
                    {%>
                        <input class="KhoVay input-sm" id="KhoVay" checked="checked" name="KhoVay" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="KhoVay input-sm" id="KhoVay" name="KhoVay" type="checkbox"/>
                    <% } %>
                </div>
                <label for="HongVay" class="col-sm-2 control-label">Hỏng:</label>
                <div class="col-sm-2">
                    <%if (Item.HongVay)
                    {%>
                        <input class="HongVay input-sm" id="HongVay" checked="checked" name="HongVay" type="checkbox"/>
                    <%}
                    else
                    {%>
                        <input class="HongVay input-sm" id="HongVay" name="HongVay" type="checkbox"/>
                    <% } %>
                </div>
            </div>
            <%if (Item.ID != Guid.Empty)
              { %>
                <div class="help-block">
                    <div class="well well-sm">
                        <i class="glyphicon glyphicon-info-sign"></i>
                        <strong><%=Item.NguoiTao_Ten %></strong> tạo ngày <%=Item.NgayTao.ToString("HH:mm dd/MM/yyyy") %>.
                        <strong><%=Item.NguoiCapNhat_Ten %></strong> sửa lúc <%=Item.NgayCapNhat.ToString("HH:mm dd/MM/yyyy") %>
                    </div>
                </div>
            <%} %>
        </div>
    </div>
    <div class="panel-footer">
        <uc1:AddTask AddUrl="/lib/pages/HangHoa/Add.aspx" ListUrl="/lib/pages/HangHoa/Default.aspx" runat="server" id="AddTask1" />
    </div>
</div>
<script src="/lib/js/ckfinder/ckfinder.js" type="text/javascript"></script>                
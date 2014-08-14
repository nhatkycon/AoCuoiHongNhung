<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Add.ascx.cs" Inherits="lib_ui_GoiDichVu_Add" %>
<%@ Register TagPrefix="uc1" TagName="AddTask_1" Src="~/lib/ui/HeThong/templates/AddTask.ascx" %>
<%@ Register Src="~/lib/ui/GoiDichVu/templates/Item-DichVu.ascx" TagPrefix="uc1" TagName="ItemDichVu" %>
<%@ Register Src="~/lib/ui/GoiDichVu/templates/Item-DichVu-Add.ascx" TagPrefix="uc1" TagName="ItemDichVuAdd" %>


<div class="panel panel-default Normal-Pnl-Add HangHoa-Pnl-Add"
    data-url="/lib/ajax/GoiDichVu/default.aspx"
    data-success="/lib/pages/GoiDichVu/Add.aspx?ID="
    data-list="/lib/pages/GoiDichVu/"
    >
    <div class="panel-heading">
        <uc1:AddTask_1 AddUrl="/lib/pages/GoiDichVu/Add.aspx" ListUrl="/lib/pages/GoiDichVu/Default.aspx" runat="server" id="AddTask" />
    </div>
    <div class="panel-body">
        <div class="form-horizontal" role="form">
            <input id="Id" style="display: none;" value="<%=Item.ID == Guid.Empty ? string.Empty  : Item.ID.ToString() %>" name="Id" type="text" />
            <div class="form-group">
                <label for="ThuTu" class="col-sm-2 control-label">Thứ tự</label>
                <div class="col-sm-4">
                    <input id="ThuTu" type="text" class="form-control" value="<%=Item.ThuTu %>" name="ThuTu"/>
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
            
            <%if (Item.ID != Guid.Empty)
              { %>
                <div class="help-block">
                    <div class="well well-sm">
                        <i class="glyphicon glyphicon-info-sign"></i>
                        <strong><%=Item.NguoiTao_Ten %></strong> tạo ngày <%=Item.NgayTao.ToString("HH:mm dd/MM/yyyy") %>.
                        . sửa lúc <%=Item.NgayCapNhat.ToString("HH:mm dd/MM/yyyy") %>
                    </div>
                </div>            
            <%} %>
        </div>
    </div>
    <div class="panel-footer">
        <uc1:AddTask_1 AddUrl="/lib/pages/GoiDichVu/Add.aspx" ListUrl="/lib/pages/GoiDichVu/Default.aspx" runat="server" id="AddTask1" />
    </div>
</div>

<%if(Item.ID!= Guid.Empty)
  { %>
    <table class="table table-striped table-bordered table-hover GoiDichVu-ThemChiTiet-Pnl">
        <thead>
            <tr>
                <th class="">
                    Tên
                </th>
                <th class="">
                    TT
                </th>
                <th>
                    Giá
                </th>
                <th>
                    SL
                </th> 
                <th>
                </th>            
            </tr>    
        </thead>
        <uc1:ItemDichVuAdd runat="server" ID="ItemDichVuAdd" />
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc1:ItemDichVu runat="server" id="ItemDichVu" Item='<%# Container.DataItem %>' /> 
            </ItemTemplate>
        </asp:Repeater>    
    </table>

<% } %>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SinhNhat.ascx.cs" Inherits="lib_ui_Bally_KhachHang_SinhNhat" %>
<%@ Register src="DanhSachAll.ascx" tagname="DanhSachAll" tagprefix="uc1" %>
<%@ Register src="templates/SinhNhat.ascx" tagname="SinhNhat" tagprefix="uc2" %>

    <table class="table table-striped table-bordered table-hover">
        <thead>
            <tr>
                <th class="">
                    Mã
                </th>
                <th class="">
                    Tên
                </th>
                <th class="">
                    S/Nhật
                </th>
                <th class="hidden-xs">
                    Tuổi
                </th>
                <th class="">
                    N/Cưới
                </th>
                <th class="hidden-xs">
                    Nguồn
                </th>
            </tr>    
        </thead>
        <asp:Repeater runat="server" ID="rpt">
            <ItemTemplate>
                <uc2:SinhNhat ID="SinhNhat1" runat="server"  TargetUrl="<%# Target %>" runat="server" Item='<%# Container.DataItem %>' />
            </ItemTemplate>
        </asp:Repeater>    
    </table>



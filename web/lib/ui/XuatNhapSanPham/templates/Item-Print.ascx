<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Print.ascx.cs" Inherits="lib_ui_XuatNhapSanPham_templates_Item_Print" %>
<%@ Register Src="~/lib/ui/PhieuXuatNhapSanPhamChiTiet/List-Print.ascx" TagPrefix="uc1" TagName="ListPrint" %>

<table width="100%">
    <tr>
        <td style="width: 200px;">
            <h3>
                Áo cưới Hồng nhung
            </h3>
        </td>
        <td style="text-align: center;">
            <h1>
                Phiếu xuất phụ kiện & Váy
            </h1>
        </td>
        <td style="width: 200px;">
            <p style="text-align: right;">
                Mã: <%=Item.MaStr %>
            </p>
            <p style="text-align: right;">
                Ngày: <%=Item.NgayLap.ToString("dd/MM/yyyy") %>
            </p>
        </td>
        <td style="width: 200px;">
            <p style="text-align: right;">
                <%if(Item.NgayXuat!= DateTime.Now){ %>
                  Ngày xuất: <%=Item.NgayXuat.ToString("dd/MM/yyyy") %>
                <%} %>
            </p>
            <p style="text-align: right;">
                <%if(Item.NgayNhap!= DateTime.Now){ %>
                  Ngày nhập: <%=Item.NgayNhap.ToString("dd/MM/yyyy") %>
                <%} %>
            </p>
        </td>
    </tr>
</table>
<table width="100%">
    <tr>
        <td style="width: 100px; text-align: right;">
            Khách:
        </td>
        <td>
            <b>
                <%=KhachHangItem.Ten %>
            </b>
        </td>
        <td style="width: 100px; text-align: right;">
            Phiếu DV:
        </td>
        <td>
            <b>
           <%=PhieuDichVuItem.MaStr %>                 
            </b>
        </td>
        <td style="width: 100px; text-align: right;">
            Người lập:
        </td>
        <td>
            <b>
           <%=Item.NguoiTao_Ten%>                 
            </b>
        </td>
    </tr>
</table>
<br/>
<br/>
<uc1:ListPrint runat="server" ID="ListPrint" />
<br/>
<br/>
<p style="text-align: right;">
    <i>
        Hà nội, ngày <%=DateTime.Now.ToString("dd/MM/yyyy") %>
    </i>
</p>
<br/>
<table width="100%">
    <tr>
        <td style="width: 33%; text-align: center;">
            <i>
                Người xuất
            </i>
        </td>
        <td style="width: 33%; text-align: center;">
            <i>
                Người nhập
            </i>
        </td>
        <td style="text-align: center;">
            <i>
                Thủ kho
            </i>
        </td>
    </tr>
    <tr>
        <td>
           <br/><br/><br/>
        </td>
        <td>
           
        </td>
        <td>
           
        </td>
    </tr>
    <tr>
        <td style="text-align: center;">
            <b>
                <%=Item.NguoiXuat_Ten %>
            </b>
        </td>
        <td style="text-align: center;">
            <b>
                <%=Item.NguoiNhap_Ten %>
            </b>
        </td>
        <td style="text-align: center;">
            <b>
                <%=Item.ThuKho_Ten %>
            </b>
        </td>
    </tr>
</table>
<script type="text/javascript">
    function PrintWindow() {
        window.print();
        CheckWindowState();
    }

    function CheckWindowState() {
        if (document.readyState == "complete") {
            window.close();
        }
        else {
            setTimeout("CheckWindowState()", 100);
        }
    }

    PrintWindow();
</script>
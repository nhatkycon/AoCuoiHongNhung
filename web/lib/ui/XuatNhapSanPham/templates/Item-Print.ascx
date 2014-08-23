<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Item-Print.ascx.cs" Inherits="lib_ui_XuatNhapSanPham_templates_Item_Print" %>
<%@ Register Src="~/lib/ui/PhieuXuatNhapSanPhamChiTiet/List-Print.ascx" TagPrefix="uc1" TagName="ListPrint" %>
<div class="print-frame">
<table width="100%">
    <tr>
        <td style="width: 200px;">
            <h3>
                <%=LogoStr %>
            </h3>
        </td>
        <td style="text-align: center;">
            <h1>
                Xuất phụ kiện & Váy
            </h1>
        </td>
        <td style="width: 200px;" valign="top">
            <table>
                <tr>
                    <td style="width: 100px; text-align: right;">
                        Số:                
                    </td>
                    <td style="width: 100px; font-weight: bold;">
                        <%=Item.MaStr %>                
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Ngày:                
                    </td>
                    <td style="font-weight: bold;">
                        <%=Item.NgayLap.ToString("dd/MM/yyyy") %>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Nhân viên:                
                    </td>
                    <td style="font-weight: bold;">
                        <%=Item.NguoiTao_Ten %>                
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Ngày xuất:           
                    </td>
                    <td style="font-weight: bold;">
                        <%=Item.NgayXuat.ToString("dd/MM/yyyy") %>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        Ngày nhập:           
                    </td>
                    <td style="font-weight: bold;">
                        <%=Item.NgayNhap == DateTime.MinValue ? "" : Item.NgayNhap.ToString("dd/MM/yyyy") %>
                    </td>
                </tr>
            </table>
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
        <td style="width:33%; text-align: center;">
            <strong>
                Người xuất
            </strong>
        </td>
        <td style="width: 33%; text-align: center;">
            <strong>
                Người nhập
            </strong>
        </td>
        <td style="text-align: center;">
            <strong>
                Thủ kho
            </strong>
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
        //window.print();
        //CheckWindowState();
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
</div>
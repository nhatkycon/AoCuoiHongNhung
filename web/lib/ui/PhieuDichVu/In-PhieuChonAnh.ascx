<%@ Control Language="C#" AutoEventWireup="true" CodeFile="In-PhieuChonAnh.ascx.cs" Inherits="lib_ui_PhieuDichVu_In_PhieuChonAnh" %>
<%@ Import Namespace="linh.common" %>
<%@ Register Src="~/lib/ui/DuyetAnh/List-PhieuDichVu-Print.ascx" TagPrefix="uc1" TagName="ListPhieuDichVuPrint" %>

<div class="print-frame">
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td valign="top">
                <%=LogoStr %>
            </td>
            <td valign="top" style="width: 300px;">
                <table>
                    <tr>
                        <td style="width: 100px; text-align: right;">
                            Số:                
                        </td>
                        <td style="width: 200px; font-weight: bold;">
                            <%=Lib.FormatMa(Item.Ma) %>                
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right;">
                            Ngày:                
                        </td>
                        <td style="width: 200px; font-weight: bold;">
                            <%=Item.PTS_NgayBatDau.ToString("dd/MM/yyyy") %>              
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right;">
                            Photoshop:                
                        </td>
                        <td style="width: 200px; font-weight: bold;">
                            <%=Item.PTS_NhanVien_Ten %>                
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <h1 style="text-align: center;">
        PHIẾU CHỌN ẢNH
    </h1>
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td style="text-align: right; width: 80px;">
                K/Hàng:
            </td>
            <td>
                <strong>
                    <%=Item.KH_Ten %>
                </strong>
            </td>
            <td style="text-align: right; width: 80px;">
                Hẹn maket:
            </td>
            <td>
                <strong>
                    <%=Item.PTS_NgayXemMaket == DateTime.MinValue ? "" : Item.PTS_NgayXemMaket.ToString("dd/MM/yyyy") %>
                </strong>
            </td>
        </tr>
    </table>
    <br/>
    <h3>Chọn ảnh:</h3>
    <uc1:ListPhieuDichVuPrint runat="server" ID="ListPhieuDichVuPrint" />
    <br/>
    <br/>
    <table width="100%" cellpadding="5" cellspacing="0">
        <tr>
            <td style="width: 33%; text-align: center; font-weight: bold;">
                KHÁCH HÀNG
                <br/><br/><br/><br/><br/>
            </td>
            <td style="width: 33%; text-align: center; font-weight: bold;">
                PHOTOSHOP
            </td>
            <td style="text-align: center; font-weight: bold;">
                QUẢN LÝ
            </td>
        </tr>
        <tr>
            <td style="text-align: center;">
                <i>
                    <%=Item.KH_Ten %>
                </i>
            </td>
            <td style="text-align: center;">
                <i>
                    <%=Item.PTS_NhanVien_Ten %>
                </i>
            </td>
            <td>
                
            </td>
        </tr>
    </table>
</div>
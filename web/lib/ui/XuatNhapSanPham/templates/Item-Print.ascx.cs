using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;

public partial class lib_ui_XuatNhapSanPham_templates_Item_Print : System.Web.UI.UserControl
{
    public PhieuXuatNhapSanPham Item { get; set; }
    public KhachHang KhachHangItem { get; set; }
    public PhieuDichVu PhieuDichVuItem { get; set; }

    public List<PhieuXuatNhapSanPhamChiTiet> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        ListPrint.List = List;
    }
}
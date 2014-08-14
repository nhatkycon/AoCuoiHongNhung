using System;
using System.Collections.Generic;
using docsoft.entities;


public partial class lib_ui_PhieuXuatNhapSanPhamChiTiet_List_Edit : System.Web.UI.UserControl
{
    public PhieuXuatNhapSanPham Item { get; set; }
    public string PID { get; set; }
    public List<PhieuXuatNhapSanPhamChiTiet> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}
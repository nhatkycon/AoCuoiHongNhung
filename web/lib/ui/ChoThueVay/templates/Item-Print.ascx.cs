using System;
using System.Collections.Generic;
using docsoft.entities;


public partial class lib_ui_ChoThueVay_templates_Item_Print : System.Web.UI.UserControl
{
    public ChoThueVay Item { get; set; }
    public List<PhieuXuatNhapSanPhamChiTiet> List { get; set; }
    public string LogoStr { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        ListPrint.List = List;
    }
}
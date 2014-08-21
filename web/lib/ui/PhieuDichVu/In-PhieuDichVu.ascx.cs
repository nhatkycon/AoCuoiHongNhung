using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_PhieuDichVu_In_PhieuDichVu : System.Web.UI.UserControl
{
    public PhieuDichVu Item { get; set; }
    public List<PhieuDichVuDichVu> ListDichVu { get; set; }
    public string LogoStr { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        ListPhieuDichVuPrint.List = ListDichVu;
    }
}
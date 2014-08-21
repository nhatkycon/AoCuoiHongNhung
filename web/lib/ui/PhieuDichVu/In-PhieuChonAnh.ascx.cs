using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_PhieuDichVu_In_PhieuChonAnh : System.Web.UI.UserControl
{
    public PhieuDichVu Item { get; set; }
    public string LogoStr { get; set; }
    public List<DuyetAnh> ListDuyetAnh { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        ListPhieuDichVuPrint.List = ListDuyetAnh;
    }
}
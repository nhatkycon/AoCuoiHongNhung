using System;
using System.Collections.Generic;
using docsoft.entities;


public partial class lib_ui_ThuChi_In_PhieuThu : System.Web.UI.UserControl
{
    public string Id { get; set; }
    public string Ret { get; set; }
    public ThuChi Item { get; set; }
    public List<DanhMuc> ListLoai { get; set; }
    public string LogoStr { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
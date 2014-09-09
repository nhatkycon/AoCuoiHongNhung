using System;
using docsoft.entities;

public partial class lib_ui_ChoThueVay_HopDong_In : System.Web.UI.UserControl
{
    public string LogoStr { get; set; }
    public ChoThueVay Item { get; set; }
    public KhachHang Khach { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
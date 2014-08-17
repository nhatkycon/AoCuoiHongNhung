using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_PhieuDichVu_LichThang : System.Web.UI.UserControl
{
    public List<SuKien> List { get; set; }
    public string Target { get; set; }
    public bool ShowHeader { get; set; }
    public Member NhanVien { get; set; }
    public string ClassName { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
}
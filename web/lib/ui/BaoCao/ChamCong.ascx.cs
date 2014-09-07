using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_BaoCao_ChamCong : System.Web.UI.UserControl
{
    public List<SuKien> List { get; set; }
    public DateTime TuNgay { get; set; }
    public DateTime DenNgay { get; set; }
    public List<Member> Members { get; set; }
    protected void Page_Load(object sender, 
        EventArgs e)
    {

    }
}
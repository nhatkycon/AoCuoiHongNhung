using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_PhieuDichVuDichVu_List_View : System.Web.UI.UserControl
{
    public List<PhieuDichVuDichVu> List { get; set; }
    public PhieuDichVu Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}
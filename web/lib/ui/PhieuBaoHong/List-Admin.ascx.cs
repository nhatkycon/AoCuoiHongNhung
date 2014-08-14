using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_PhieuBaoHong_List_Admin : System.Web.UI.UserControl
{
    public List<PhieuBaoHong> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}
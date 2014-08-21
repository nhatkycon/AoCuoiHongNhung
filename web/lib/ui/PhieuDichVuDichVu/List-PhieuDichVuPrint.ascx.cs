using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_PhieuDichVuDichVu_List_PhieuDichVuPrint : System.Web.UI.UserControl
{
    public List<PhieuDichVuDichVu> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}
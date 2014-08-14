using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_DuyetAnh_List_Edit : System.Web.UI.UserControl
{
    public List<DuyetAnh> List { get; set; }
    public PhieuDichVu Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}
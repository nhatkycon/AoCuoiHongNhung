using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_ChoThueVay_List : System.Web.UI.UserControl
{
    public List<ChoThueVay> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}
using System;
using System.Collections.Generic;
using System;
using docsoft.entities;

public partial class lib_ui_BaoCao_DichVuThem : System.Web.UI.UserControl
{
    public List<PhieuDichVuDichVu> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}
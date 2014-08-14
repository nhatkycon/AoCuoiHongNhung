using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;

public partial class lib_ui_Bally_KhachHang_templates_Item : System.Web.UI.UserControl
{
    public KhachHang Item { get; set; }
    public string TargetUrl { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
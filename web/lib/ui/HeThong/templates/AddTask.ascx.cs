using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lib_ui_HeThong_templates_AddTask : System.Web.UI.UserControl
{
    public string Id { get; set; }
    public string Ret { get; set; }
    public string AddUrl { get; set; }
    public string ListUrl { get; set; }
    public string PrintUrl { get; set; }
    public string ViewUrl { get; set; }
    public bool EditAble { get; set; }
    public bool DeleteAble { get; set; }
    public bool AddAble { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["ID"];
        Ret = Request["ret"];
        if (!string.IsNullOrEmpty(Ret))
        {
            Ret = Server.UrlDecode(Ret);
        }
    }
}
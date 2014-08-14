using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.json;

public partial class lib_ajax_NhanVien_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        switch (subAct)
        {
            case "search":
                #region search
                var pg = MemberDal.pagerNormal(null, false, null);
                rendertext(JavaScriptConvert.SerializeObject(pg.List), "text/javascript");
                break;
                #endregion
            default: break;
        }
    }
}
using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_GoiDichVu_Default : System.Web.UI.Page
{
    public string paging { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "10";

        var url = string.Format("?q={0}&size={1}&", q, size) + "{1}={0}";
        using (var con = DAL.con())
        {

            var pg =
                GoiDichVuDal.pagerNormal( url, false, null, q, Convert.ToInt32(size));
            List.List = pg.List;
            paging = pg.Paging;

        }

    }
}
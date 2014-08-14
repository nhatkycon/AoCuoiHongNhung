using System;
using docsoft.entities;
using linh.core.dal;
using System.Globalization;

public partial class lib_pages_ThungRac_PhieuDichVu : System.Web.UI.Page
{
    public string paging { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        using (var con = DAL.con())
        {

            var pg =
                PhieuDichVuDal.pagerXoa(con, string.Empty, false, "PDV_Ma desc", q, 20);
            List.List = pg.List;
            paging = pg.Paging;

        }
    }
}
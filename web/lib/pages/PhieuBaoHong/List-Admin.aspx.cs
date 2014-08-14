using System;
using docsoft.entities;
using linh.core.dal;


public partial class lib_pages_PhieuBaoHong_List_Admin : System.Web.UI.Page
{
    public string paging { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "10";
        var duyet = Request["Duyet"];
        var nhanVien = Request["NhanVien"];
        var url = string.Format("?q={0}&size={1}&NhanVien={2}&", q, size, nhanVien) + "{1}={0}";

        using (var con = DAL.con())
        {

            var pg =
                PhieuBaoHongDal.pagerDuyet(con, url, false, "PBH_Ma desc", q, Convert.ToInt32(size), null, nhanVien);
            List.List = pg.List;
            paging = pg.Paging;

        }
    }
}
using System;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_GiatLa_Default : System.Web.UI.Page
{
    public string paging { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "10";
        var trangThai = Request["TrangThai"];
        var nhanVien = Request["NhanVien"];
        var chId = Request["CH_ID"];
        var url = string.Format("?q={0}&size={1}&TrangThai={2}&NhanVien={3}&CH_ID={4}&", q, size, trangThai, nhanVien, chId) + "{1}={0}";

        using (var con = DAL.con())
        {

            var pg =
                PhieuGiatVayDal.pagerNormal(con, url, false, "PGV_Ma desc", q, Convert.ToInt32(size), trangThai, nhanVien, chId);
            List.List = pg.List;
            paging = pg.Paging;

        }
    }
}
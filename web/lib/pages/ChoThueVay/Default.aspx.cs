using System;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_ChoThueVay_Default : System.Web.UI.Page
{
    public string paging { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "10";
        var trangThai = Request["TrangThai"];
        var nhanVien = Request["NhanVien"];
        var url = string.Format("?q={0}&size={1}&TrangThai={2}&NhanVien={3}&", q, size, trangThai, nhanVien) + "{1}={0}";

        using (var con = DAL.con())
        {

            var pg =
                ChoThueVayDal.pagerNormal(con, url, false, "CTV_Ma desc", q, Convert.ToInt32(size), trangThai, nhanVien);
            List.List = pg.List;
            paging = pg.Paging;

        }
    }
}
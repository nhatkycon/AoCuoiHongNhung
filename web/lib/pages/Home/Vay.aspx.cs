using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Home_Vay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var d = DateTime.Now;
        var cuoiThangTruoc = new DateTime(d.Year, d.Month, 1).AddDays(-1);
        var dauThangSau = d.AddMonths(6);
        const int size = 10;
        using (var con = DAL.con())
        {
            var pgChoThueVay =
                ChoThueVayDal.pagerNormal(con, null, false, "CTV_Ma desc", null, size, null, null);

            var pgGiatLa =
                PhieuGiatVayDal.pagerNormal(con, null, false, "PGV_Ma desc", null, size, null, null, null);

            var pgXuatNhap =
                PhieuXuatNhapSanPhamDal.pagerNormal(con, null, false, "PXNSP_Ma desc",null, size, null, null);

            ListChoThueVay.List = pgChoThueVay.List;
            ListGiatLa.List = pgGiatLa.List;
            ListXuatNhap.List = pgXuatNhap.List;

        }
    }
}
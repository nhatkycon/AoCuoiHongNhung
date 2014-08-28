using System;
using docsoft.entities;
using linh.core.dal;
using System.Globalization;

public partial class lib_pages_Home_Kt : System.Web.UI.Page
{
    public string paging { get; set; }
    public string Ngay { get; set; }
    public string NhanVienId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var tuNgay = "";
        var denNgay = "";
        var d = DateTime.Now;
        tuNgay = new DateTime(d.Year, d.Month, d.Day).AddDays(-10).ToString("yyyy-MM-dd");
        denNgay = new DateTime(d.Year, d.Month, d.Day).AddDays(1).ToString("yyyy-MM-dd");

        using (var con = DAL.con())
        {

            var pg =
                PhieuDichVuDal.pagerByNhanVienNgay(con, string.Empty, false, "PDV_Ma desc", q, 10, null
                                           , null, tuNgay, denNgay);
            List.List = pg.List;
            paging = pg.Paging;

        }
    }
}
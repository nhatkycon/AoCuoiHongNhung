using System;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_PhieuDichVu_List_Pts : System.Web.UI.Page
{
    public string paging { get; set; }
    public string Ngay { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "10";
        var trangThai = Request["TrangThai"];
        Ngay = Request["Ngay"];
        var url = string.Format("?q={0}&size={1}&TrangThai={2}&Ngay={3}&", q, size, trangThai, Ngay) + "{1}={0}";
        var tuNgay = "";
        var denNgay = "";
        if (!string.IsNullOrEmpty(Ngay))
        {
            Ngay = Server.UrlDecode(Ngay);
            var d = Convert.ToDateTime(Ngay, new CultureInfo("Vi-vn"));
            Ngay = d.ToString("yyyy-MM-dd");
        }
        using (var con = DAL.con())
        {

            var pg =
                PhieuDichVuDal.pagerPts(con, url, false, "PDV_Ma desc", q, Convert.ToInt32(size), trangThai,
                                        Security.UserId.ToString(), Ngay, null, null);
            List.List = pg.List;
            paging = pg.Paging;

        }

    }
}
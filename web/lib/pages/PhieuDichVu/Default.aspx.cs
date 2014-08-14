using System;
using docsoft.entities;
using linh.core.dal;
using System.Globalization;

public partial class lib_pages_PhieuDichVu_Default : System.Web.UI.Page
{
    public string paging { get; set; }
    public string Ngay { get; set; }
    public string NhanVienId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "10";
        var trangThai = Request["TrangThai"];
        Ngay = Request["Ngay"];
        NhanVienId = Request["NHANVIEN_ID"];
        var url = string.Format("?q={0}&size={1}&TrangThai={2}&Ngay={3}&NHANVIEN_ID={4}&", q, size, trangThai, Ngay, NhanVienId) + "{1}={0}";
        var tuNgay = "";
        var denNgay = "";
        if (!string.IsNullOrEmpty(Ngay))
        {
            Ngay = Server.UrlDecode(Ngay);
            var d = Convert.ToDateTime(Ngay, new CultureInfo("Vi-vn"));
            tuNgay = new DateTime(d.Year, d.Month, d.Day).AddDays(-1).ToString("yyyy-MM-dd");
            denNgay = new DateTime(d.Year, d.Month, d.Day).AddDays(1).ToString("yyyy-MM-dd");
        }
        
        using (var con = DAL.con())
        {

            var pg =
                PhieuDichVuDal.pagerByNhanVienNgay(con, url, false, "PDV_Ma desc", q, Convert.ToInt32(size), trangThai
                                           , NhanVienId, tuNgay, denNgay);
            List.List = pg.List;
            paging = pg.Paging;

        }
    }
}
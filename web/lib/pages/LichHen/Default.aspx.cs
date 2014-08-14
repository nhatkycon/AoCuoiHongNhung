using System;
using System.Globalization;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_LichHen_Default : System.Web.UI.Page
{
    public string paging { get; set; }
    public string Ngay { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var dm_id = Request["DM_ID"];
        var khId = Request["KH_ID"];
        var NHANVIEN_ID = Request["NHANVIEN_ID"];
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "10";

        Ngay = Request["Ngay"];

        using (var con = DAL.con())
        {
            var ListLoai = DanhMucDal.SelectByLDMMa(con, "NHOM-SK");
            DM_ID.List = ListLoai;
            var tuNgay = "";
            var denNgay = "";
            if(!string.IsNullOrEmpty(Ngay))
            {
                Ngay = Server.UrlDecode(Ngay);
                var d = Convert.ToDateTime(Ngay, new CultureInfo("Vi-vn"));
                tuNgay = new DateTime(d.Year, d.Month, d.Day).ToString("yyyy-MM-dd");
                denNgay = new DateTime(d.Year, d.Month, d.Day).AddDays(1).ToString("yyyy-MM-dd");
            }

            var pg =
                SuKienDal.pagerNormal(
                    string.Format("?q={0}&size={1}&DM_ID={2}&KH_ID={3}&NHANVIEN_ID={4}&", q, size, dm_id, khId, NHANVIEN_ID) + "{1}={0}"
                    , false, "SK_NgayBatDau desc", q, Convert.ToInt32(size)
                    , dm_id, khId, NHANVIEN_ID, null, null, tuNgay, denNgay);
            paging = pg.Paging;
            DanhSach1.List = pg.List;
        }

    }
}
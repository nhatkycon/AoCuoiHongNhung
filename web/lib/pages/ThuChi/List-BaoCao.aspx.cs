using System;
using System.Globalization;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_ThuChi_List_BaoCao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        var tt_id = Request["TT_ID"];
        var giaoHang = Request["GiaoHang"];
        var TuNgay = Request["TuNgay"];
        var DenNgay = Request["DenNgay"];
        var dNow = DateTime.Now;
        var dauThang = new DateTime(dNow.Year, 1, 1).ToString("yyyy-MM-dd");
        var cuoiThang = new DateTime(dNow.Year, dNow.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

        TuNgay = string.IsNullOrEmpty(TuNgay) ? dauThang : Convert.ToDateTime(TuNgay, new CultureInfo("vi-Vn")).ToString("yyyy-MM-dd");
        DenNgay = string.IsNullOrEmpty(DenNgay) ? cuoiThang : Convert.ToDateTime(DenNgay, new CultureInfo("vi-Vn")).ToString("yyyy-MM-dd");
        if (string.IsNullOrEmpty(size)) size = "30";
        using (var con = DAL.con())
        {
            var listLoai = DanhMucDal.SelectByLDMMa(con, "NDTC-CHI");
            DM_ID.List = listLoai;
            var pg = ThuChiReportDal.SelectTuNgayDenNgay(TuNgay, DenNgay);
            List.List = pg;
        }
    }
}
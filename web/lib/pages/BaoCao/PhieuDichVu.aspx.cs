using System;
using System.Globalization;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_BaoCao_PhieuDichVu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var d = DateTime.Now;

        var dauThang = new DateTime(d.Year, d.Month, 1).AddMonths(-1);
        var cuoiThang = new DateTime(d.Year, d.Month, 1).AddMonths(1);
        var tuNgayStr = Request["TuNgay"];
        var denNgayStr = Request["DenNgay"];
        if (string.IsNullOrEmpty(tuNgayStr))
        {
            tuNgayStr = dauThang.ToString("dd/MM/yyyy");
        }
        if (string.IsNullOrEmpty(denNgayStr))
        {
            denNgayStr = cuoiThang.ToString("dd/MM/yyyy");
        }
        var nhanVien_Id = Request["NhanVien_Id"];
        var tuNgay = Convert.ToDateTime(tuNgayStr, new CultureInfo("Vi-vn"));
        var denNgay = Convert.ToDateTime(denNgayStr, new CultureInfo("Vi-vn"));
        using (var con = DAL.con())
        {
            var pg = PhieuDichVuDal.pagerBaoCao(con, string.Empty, false, "PDV_Ma desc", string.Empty, 20, tuNgay.ToString("yyyy-MM-dd"),
                                                  denNgay.ToString("yyyy-MM-dd"));
            List.List = pg.List;
        }
    }
}
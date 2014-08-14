using System;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_XuatNhapSanPham_Default : System.Web.UI.Page
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
                PhieuXuatNhapSanPhamDal.pagerNormal(con, url, false, "PXNSP_Ma desc", q, Convert.ToInt32(size), trangThai, nhanVien);
            List1.List = pg.List;
            paging = pg.Paging;

        }

    }
}
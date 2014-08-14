using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_PhieuDichVu_LichSapToi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var d = DateTime.Now;
        var cuoiThangTruoc = new DateTime(d.Year, d.Month, 1).AddDays(-1);
        var dauThangSau = d.AddMonths(6);
        var nhanVienId = Request["NHANVIEN_ID"];
        using (var con = DAL.con())
        {

            EventsViewer.List = SuKienDal.SelectPhieuDichVuEventsViewer(con, d.AddDays(-1).ToString("yyyy-MM-dd"), dauThangSau.ToString("yyyy-MM-dd"), nhanVienId);
        }
    }
}
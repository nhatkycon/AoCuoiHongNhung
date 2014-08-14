using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_Home_Lt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var d = DateTime.Now;
        var cuoiThangTruoc = new DateTime(d.Year, d.Month, 1).AddDays(-1);
        var muoiNgayToi = cuoiThangTruoc.AddMonths(1);
        var dauThangSau = d.AddMonths(6);
        using (var con = DAL.con())
        {

            var list = SuKienDal.SelectPhieuDichVuForCalendar(con, cuoiThangTruoc, dauThangSau, null);
            LichThang.List = list;

            SinhNhat.List = KhachHangDal.pagerSinhNhat(null, false, null, null, 20, null, null).List;

            EventsViewer.List = SuKienDal.SelectPhieuDichVuEventsViewer(con, d.AddDays(-1).ToString("yyyy-MM-dd"), muoiNgayToi.ToString("yyyy-MM-dd"), null);
        }
    }
}
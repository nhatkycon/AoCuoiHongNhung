using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;


public partial class lib_pages_Home_Pts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var d = DateTime.Now;
        var cuoiThangTruoc = new DateTime(d.Year, d.Month, 1).AddDays(-1);
        var dauThangSau = d.AddMonths(6);
        var muoiNgayToi = cuoiThangTruoc.AddMonths(1);
        using (var con = DAL.con())
        {

            var list = SuKienDal.SelectPhieuDichVuForCalendarPts(con, cuoiThangTruoc, dauThangSau, Security.UserId.ToString());
            LichThang.List = list;

            EventsViewer.List = SuKienDal.SelectPhieuDichVuEventsViewer(con, d.AddDays(-1).ToString("yyyy-MM-dd"), muoiNgayToi.ToString("yyyy-MM-dd"), Security.UserId.ToString());

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_LichHen_LichThang : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var d = DateTime.Now;
        var cuoiThangTruoc = new DateTime(d.Year, d.Month, 1).AddDays(-1);
        var dauThangSau = d.AddMonths(6);
        var NHANVIEN_ID = Request["NHANVIEN_ID"];
        using(var con = DAL.con())
        {

            var list = SuKienDal.SelectForCalendar(con, cuoiThangTruoc, dauThangSau, NHANVIEN_ID);
            LichThang.List = list;
        }
    }
}
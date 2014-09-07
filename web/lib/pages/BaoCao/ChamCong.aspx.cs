using System;
using System.Globalization;
using System.Linq;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_BaoCao_ChamCong : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var d = DateTime.Now;

        var dauThang = new DateTime(d.Year, d.Month, 1).AddMonths(-1);
        var cuoiThang = new DateTime(d.Year, d.Month, 1);
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

        var tuNgay = Convert.ToDateTime(tuNgayStr, new CultureInfo("Vi-vn"));
        var denNgay = Convert.ToDateTime(denNgayStr, new CultureInfo("Vi-vn"));
        using(var con = DAL.con())
        {
            var list = SuKienDal.SelectPhieuDichVuBaoCao(con, tuNgay.ToString("yyyy-MM-dd"), denNgay.ToString("yyyy-MM-dd"), null);
            var members = (from p in list
                          group p by p.NhanVien_Id
                          into g
                          select g.Key).ToList();
            ChamCong.Members = MemberDal.SelectAll().Where(x => members.Contains(x.ID)).ToList();

            ChamCong.TuNgay = tuNgay;
            ChamCong.DenNgay = denNgay;
            ChamCong.List = list;
        }
        
    }
}
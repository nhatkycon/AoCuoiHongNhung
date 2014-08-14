using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_PhieuDichVu_LichThang_GiaoViec_NhanVien : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var d = DateTime.Now;
        var cuoiThangTruoc = new DateTime(d.Year, d.Month, 1).AddDays(-1);
        var dauThangSau = d.AddMonths(6);
        var nhanVienId = Request["NHANVIEN_ID"];
        using (var con = DAL.con())
        {
            var member = new Member();
            if(!string.IsNullOrEmpty(nhanVienId))
            {
                member = MemberDal.SelectById(Convert.ToInt32(nhanVienId));
            }

            var list = SuKienDal.SelectPhieuDichVuForCalendar(con, cuoiThangTruoc, dauThangSau, nhanVienId);
            LichThang.List = list;
            LichThang.NhanVien = member;
        }
    }
}
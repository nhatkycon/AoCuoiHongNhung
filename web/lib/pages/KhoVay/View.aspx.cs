using System;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_KhoVay_View : System.Web.UI.Page
{
    public HangHoa Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var d = DateTime.Now;
        var cuoiThangTruoc = new DateTime(d.Year, d.Month, 1).AddDays(-1);
        var dauThangSau = d.AddMonths(6);
        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id))
            {
                View.Item = new HangHoa(); ;
            }
            else
            {
                Item = HangHoaDal.SelectById(new Guid(id));
                View.Item = Item;
            }
            var list = SuKienDal.SelectPhieuDichVuForVay(con, cuoiThangTruoc, dauThangSau, id);
            View.List = list;
            var phieuBaoHongList = PhieuBaoHongDal.SelectTopByHhId(con, 10, id);

            var choThueVayList = ChoThueVayDal.SelectTopByHhId(con, 10, id);

            var phieuGiatVayList = PhieuGiatVayDal.SelectTopByHhId(con, 10, id);

            var phieuXuatNhapSanPhamList = PhieuXuatNhapSanPhamDal.SelectTopByHhId(con, 10, id);

            View.PhieuBaoHongList = phieuBaoHongList;
            View.ChoThueVayList = choThueVayList;
            View.PhieuGiatVayList = phieuGiatVayList;
            View.PhieuXuatNhapSanPhamList = phieuXuatNhapSanPhamList;

        }

    }
}
using System;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_XuatNhapSanPham_HopDong_Print : System.Web.UI.Page
{
    public PhieuXuatNhapSanPham Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        using (var con = DAL.con())
        {
            Item = PhieuXuatNhapSanPhamDal.SelectById(con, new Guid(id));
            var phieuDichVuItem = PhieuDichVuDal.SelectById(con, Item.PDV_ID);
            var khachHangItem = KhachHangDal.SelectById(phieuDichVuItem.KH_ID, con);

            Print.Item = Item;
            Print.Khach = khachHangItem;

            var logoStr = DanhMucDal.SelectByMa("BAOCAO-HEADER-THUCHI", con).Description;
            Print.LogoStr = logoStr;
        }
    }
}
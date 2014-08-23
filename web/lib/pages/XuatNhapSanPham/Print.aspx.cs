using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.core.dal;


public partial class lib_pages_XuatNhapSanPham_Print : System.Web.UI.Page
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
            var list = new List<PhieuXuatNhapSanPhamChiTiet>();
            list = PhieuXuatNhapSanPhamChiTietDal.SelectByPxnSpId(con, id);

            ItemPrint.List = list;
            ItemPrint.Item = Item;
            ItemPrint.PhieuDichVuItem = phieuDichVuItem;
            ItemPrint.KhachHangItem = khachHangItem;

            var logoStr = DanhMucDal.SelectByMa("BAOCAO-HEADER-THUCHI", con).Description;
            ItemPrint.LogoStr = logoStr;
        }
    }
}
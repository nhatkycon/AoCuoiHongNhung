using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.core.dal;


public partial class lib_pages_XuatNhapSanPham_Add : System.Web.UI.Page
{
    public PhieuXuatNhapSanPham Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var pdvId = Request["PDV_ID"];
        var list = new List<PhieuXuatNhapSanPhamChiTiet>();
        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id))
            {
                Item = PhieuXuatNhapSanPhamDal.SelectDraff(con);
                Item.Ma = Item.Ma == 0 ? 1 : Item.Ma + 1;
                Item.ID = Guid.NewGuid();
                if(!string.IsNullOrEmpty(pdvId))
                {
                    var pdv = PhieuDichVuDal.SelectById(con, new Guid(pdvId));
                    Item.PDV_ID = pdv.ID;
                    Item.PDV_Ma = pdv.Ma;
                }

            }
            else
            {
                Item = PhieuXuatNhapSanPhamDal.SelectById(con, new Guid(id));
                list = PhieuXuatNhapSanPhamChiTietDal.SelectByPxnSpId(con, id);

            }
            Add.List = list;
            Add.Item = Item; ;
        }
    }
}
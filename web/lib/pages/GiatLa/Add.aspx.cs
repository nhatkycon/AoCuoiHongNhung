using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.core.dal;


public partial class lib_pages_GiatLa_Add : System.Web.UI.Page
{
    public PhieuGiatVay Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var list = new List<PhieuXuatNhapSanPhamChiTiet>();
        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id))
            {
                Item = PhieuGiatVayDal.SelectDraff(con);
                Item.Ma = Item.Ma == 0 ? 1 : Item.Ma + 1;
                Item.ID = Guid.NewGuid();

            }
            else
            {
                Item = PhieuGiatVayDal.SelectById(con, new Guid(id));
                list = PhieuXuatNhapSanPhamChiTietDal.SelectByPxnSpId(con, id);

            }
            Add.List = list;
            Add.Item = Item; ;
        }
    }
}
using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.core.dal;
public partial class lib_pages_ChoThueVay_Print : System.Web.UI.Page
{
    public ChoThueVay Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var khId = Request["KH_ID"];
        var list = new List<PhieuXuatNhapSanPhamChiTiet>();
        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id))
            {
                Item = ChoThueVayDal.SelectDraff(con);
                Item.Ma = Item.Ma == 0 ? 1 : Item.Ma + 1;
                Item.ID = Guid.NewGuid();
                if (!string.IsNullOrEmpty(khId))
                {
                    var kh = KhachHangDal.SelectById(new Guid(khId), con);
                    Item.KH_ID = kh.ID;
                    Item.KH_Ten = kh.Ten;
                }
            }
            else
            {
                Item = ChoThueVayDal.SelectById(con, new Guid(id));
                list = PhieuXuatNhapSanPhamChiTietDal.SelectByPxnSpId(con, id);

            }
            var logoStr = DanhMucDal.SelectByMa("BAOCAO-HEADER-THUCHI", con).Description;
            Add.LogoStr = logoStr;
            Add.List = list;
            Add.Item = Item; ;
        }
    }
}
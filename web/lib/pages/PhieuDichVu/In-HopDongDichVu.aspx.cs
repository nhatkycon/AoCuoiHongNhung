using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.core.dal;
public partial class lib_pages_PhieuDichVu_In_HopDongDichVu : System.Web.UI.Page
{
    public PhieuDichVu Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id))
            {
                Item = PhieuDichVuDal.SelectDraff(con);
                Item.Ma = Item.Ma == 0 ? 1 : Item.Ma + 1;
                Item.ID = Guid.NewGuid();

            }
            else
            {
                Item = PhieuDichVuDal.SelectById(con, new Guid(id));
                Item._KhachHang = KhachHangDal.SelectById(Item.KH_ID, con);
            }
            Add.Item = Item; ;
        }
    }
}
using System;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_PhieuBaoHong_Add_Admin : System.Web.UI.Page
{
    public PhieuBaoHong Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id))
            {
                Item = PhieuBaoHongDal.SelectDraff(con);
                Item.Ma = Item.Ma == 0 ? 1 : Item.Ma + 1;
                Item.ID = Guid.NewGuid();

            }
            else
            {
                Item = PhieuBaoHongDal.SelectById(con, new Guid(id));

            }
            Add.Item = Item; ;
        }
    }
}
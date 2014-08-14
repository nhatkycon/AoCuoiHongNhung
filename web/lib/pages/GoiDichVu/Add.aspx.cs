using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_GoiDichVu_Add : System.Web.UI.Page
{
    public GoiDichVu Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id))
            {
                Add.Item = new GoiDichVu(); ;
                Add.List=new List<GoiDichVuChiTiet>();
            }
            else
            {
                Item = GoiDichVuDal.SelectById(new Guid(id));
                Add.Item = Item;
                Add.List = GoiDichVuChiTietDal.SelectByGDV(con, id);
            }
        }
    }
}
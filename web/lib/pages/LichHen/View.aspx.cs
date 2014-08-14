using System;
using docsoft.entities;
using linh.common;
using linh.core.dal;

public partial class lib_pages_LichHen_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var khId = Request["KH_ID"];
        SuKien Item;
        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id))
            {
                Item = new SuKien();
                if (!string.IsNullOrEmpty(khId))
                {
                    if (khId.Length > 36)
                    {
                        khId = khId.Substring(khId.LastIndexOf(',') + 1);
                    }
                    var kh = KhachHangDal.SelectById(new Guid(khId), con);
                    Item.KH_Ten = kh.Ten;
                    Item.KH_ID = kh.ID;
                }
                ViewItem.Item = Item;
            }
            else
            {
                Item = SuKienDal.SelectById(new Guid(id));
                Item.KH_Ten = maHoa.DecryptString(Item.KH_Ten, Item.KH_ID.ToString());
                ViewItem.Item = Item;
            }
        }
    }
}
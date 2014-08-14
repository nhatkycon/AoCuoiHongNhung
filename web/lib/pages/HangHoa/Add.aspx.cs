using System;
using docsoft.entities;
using linh.core.dal;
public partial class lib_pages_HangHoa_Add : System.Web.UI.Page
{
    public HangHoa Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id))
            {
                Add.Item = new HangHoa(); ;
            }
            else
            {
                Item = HangHoaDal.SelectById(new Guid(id));
                Add.Item = Item;
            }
        }
    }
}
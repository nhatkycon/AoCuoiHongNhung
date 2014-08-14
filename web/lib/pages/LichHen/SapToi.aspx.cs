using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_LichHen_SapToi : System.Web.UI.Page
{
    public string paging { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        using(var con = DAL.con())
        {
            Upcoming.List = SuKienDal.SelectUpcoming(con, "50");
        }
    }
}
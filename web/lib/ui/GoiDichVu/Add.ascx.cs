using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;

public partial class lib_ui_GoiDichVu_Add : System.Web.UI.UserControl
{
    public GoiDichVu Item { get; set; }
    public List<GoiDichVuChiTiet> List { get; set; } 
    protected void Page_Load(object sender, EventArgs e)
    {
        AddTask.EditAble = Item.NguoiTao == Security.UserId;
        AddTask1.EditAble = Item.NguoiTao == Security.UserId;

        ItemDichVuAdd.Item = new GoiDichVuChiTiet(){ GDV_ID = Item.ID};

        if (List == null) return;
        rpt.DataSource = List;
        rpt.DataBind();
    }
}
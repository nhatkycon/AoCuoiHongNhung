using System;
using docsoft;
using docsoft.entities;

public partial class lib_ui_PhieuBaoHong_Add_Admin : System.Web.UI.UserControl
{
    public string Id { get; set; }
    public string Ret { get; set; }
    public PhieuBaoHong Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["ID"];
        Ret = Request["ret"];
        if (!string.IsNullOrEmpty(Ret))
        {
            Ret = Server.UrlDecode(Ret);
        }
        AddTask.EditAble = true;
        AddTask1.EditAble = true;
        AddTask.PrintUrl = Item.UrlPrint;
        AddTask1.PrintUrl = Item.UrlPrint;
    }
}
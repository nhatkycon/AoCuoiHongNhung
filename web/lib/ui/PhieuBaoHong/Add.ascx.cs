using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;

public partial class lib_ui_PhieuBaoHong_Add : System.Web.UI.UserControl
{
    public string Id { get; set; }
    public string Ret { get; set; }
    public PhieuBaoHong Item { get; set; }
    public List<ThuChi> ListThuChi { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["ID"];
        Ret = Request["ret"];
        if (!string.IsNullOrEmpty(Ret))
        {
            Ret = Server.UrlDecode(Ret);
        }
        AddTask.EditAble = Item.NguoiTao == Security.UserId;
        AddTask1.EditAble = Item.NguoiTao == Security.UserId;
        AddTask.PrintUrl = Item.UrlPrint;
        AddTask1.PrintUrl = Item.UrlPrint;

        ListPhieuDichVu.List = ListThuChi;
        ListPhieuDichVu.Target = "/lib/pages/ThuChi/Add-Thu.aspx?ID=";
    }
}
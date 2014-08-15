using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;

public partial class lib_ui_ChoThueVay_Add : System.Web.UI.UserControl
{
    public string Id { get; set; }
    public string Ret { get; set; }
    public string PDV_ID { get; set; }
    public ChoThueVay Item { get; set; }
    public List<ThuChi> ListThuChi { get; set; }
    public List<PhieuXuatNhapSanPhamChiTiet> List { get; set; }
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

        ListEdit.PID = Item.ID.ToString();
        ListEdit.List = List;

        ListPhieuDichVu.List = ListThuChi;
        ListPhieuDichVu.Target = "/lib/pages/ThuChi/Add-Thu.aspx?ID=";
    }
}
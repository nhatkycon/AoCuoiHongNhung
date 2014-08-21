using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;

public partial class lib_ui_PhieuDichVu_Add_Pts : System.Web.UI.UserControl
{
    public PhieuDichVu Item { get; set; }
    public string Id { get; set; }
    public List<DuyetAnh> ListDuyetAnh { get; set; }
    public List<BaiHat> ListBaiHat { get; set; }
    public List<PhieuDichVuDichVu> ListDichVu { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        AddTask1.EditAble = Item.PTS_NhanVien == Security.UserId;
        AddTask.EditAble = Item.PTS_NhanVien == Security.UserId;

        AddTask.PrintUrl = AddTask1.PrintUrl = string.Format("/lib/pages/PhieuDichVu/In-PhieuChonAnh.aspx?ID={0}", Item.ID);

        Id = Request["ID"];

        ChonAnhList.List = ListDuyetAnh;
        ChonAnhList.Item = Item;

        BaiHatList.List = ListBaiHat;
        BaiHatList.Item = Item;

        DichVuList.Item = Item;
        DichVuList.List = ListDichVu;
    }
}
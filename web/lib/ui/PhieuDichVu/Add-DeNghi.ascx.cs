using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;

public partial class lib_ui_PhieuDichVu_Add_DeNghi : System.Web.UI.UserControl
{
    public PhieuDichVu Item { get; set; }
    public string Id { get; set; }
    public List<PhieuDichVuDichVu> ListDichVu { get; set; }
    public List<DuyetAnh> ListDuyetAnh { get; set; }
    public List<BaiHat> ListBaiHat { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        AddTask.EditAble = true;
        AddTask1.EditAble = true;

        Id = Request["ID"];

        DichVuList.Item = Item;
        DichVuList.List = ListDichVu;

        ChonAnhList.List = ListDuyetAnh;
        ChonAnhList.Item = Item;

        BaiHatList.List = ListBaiHat;
        BaiHatList.Item = Item;
    }
}
using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_DuyetAnh_View : System.Web.UI.UserControl
{
    public PhieuDichVu Item { get; set; }
    public List<DuyetAnh> DuyetAnhs { get; set; }
    public List<DuyetAnh> DanhSachAnh { get; set; }
    public List<BaiHat> ListBaiHat { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        ListDuyetAll.List = DanhSachAnh;
        ListDuyetCarousel.List = DanhSachAnh;

        BaiHatList.List = ListBaiHat;
        BaiHatList.Item = Item;
    }
}
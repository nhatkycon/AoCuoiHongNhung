using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_KhoVay_View : System.Web.UI.UserControl
{
    public string Id { get; set; }
    public string Ret { get; set; }
    public HangHoa Item { get; set; }
    public List<SuKien> List { get; set; }
    public List<PhieuBaoHong> PhieuBaoHongList { get; set; }
    public List<ChoThueVay> ChoThueVayList { get; set; }
    public List<PhieuGiatVay> PhieuGiatVayList { get; set; }
    public List<PhieuXuatNhapSanPham> PhieuXuatNhapSanPhamList { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["ID"];
        Ret = Request["ret"];
        if (!string.IsNullOrEmpty(Ret))
        {
            Ret = Server.UrlDecode(Ret);
        }
        LichThang.List = List;

        ListChoThueVay.List = ChoThueVayList;
        ListGiatLa.List = PhieuGiatVayList;
        ListPhieuBaoHong.List = PhieuBaoHongList;
        ListXuatNhap.List = PhieuXuatNhapSanPhamList;

    }
}
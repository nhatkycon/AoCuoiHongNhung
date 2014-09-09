using System;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_ChoThueVay_HopDong_In : System.Web.UI.Page
{
    public ChoThueVay Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        using (var con = DAL.con())
        {
            if (!string.IsNullOrEmpty(id))
            {
                Item = ChoThueVayDal.SelectById(con, new Guid(id));
                HopDongIn.Item = Item; ;
                HopDongIn.Khach = KhachHangDal.SelectById(Item.KH_ID,con);
                var logoStr = DanhMucDal.SelectByMa("BAOCAO-HEADER-THUCHI", con).Description;
                HopDongIn.LogoStr = logoStr;
            }
           
        }
    }
}
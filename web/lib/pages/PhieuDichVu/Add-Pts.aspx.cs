using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_PhieuDichVu_Add_Pts : System.Web.UI.Page
{
    public PhieuDichVu Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var listDuyetAnh = new List<DuyetAnh>();
        var listBaiHat = new List<BaiHat>();
        var dichVuList = new List<PhieuDichVuDichVu>();
        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id))
            {
                Item = PhieuDichVuDal.SelectDraff(con);
                Item.Ma = Item.Ma == 0 ? 1 : Item.Ma + 1;
                Item.ID = Guid.NewGuid();

            }
            else
            {
                Item = PhieuDichVuDal.SelectById(con, new Guid(id));
                listDuyetAnh = DuyetAnhDal.SelectByPdvId(con, id);
                listBaiHat = BaiHatDal.SelectByPdvId(con, id);
                dichVuList = PhieuDichVuDichVuDal.SelectByPdvId(con, id);
            }
            AddPts.Item = Item; ;
            AddPts.ListDuyetAnh = listDuyetAnh;
            AddPts.ListBaiHat = listBaiHat;
            AddPts.ListDichVu = dichVuList;
        }
    }
}
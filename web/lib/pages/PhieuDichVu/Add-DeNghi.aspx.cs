using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_PhieuDichVu_Add_DeNghi : System.Web.UI.Page
{
    public PhieuDichVu Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var dichVuList = new List<PhieuDichVuDichVu>();
        var listDuyetAnh = new List<DuyetAnh>();
        var listBaiHat = new List<BaiHat>();
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
                dichVuList = PhieuDichVuDichVuDal.SelectByPdvId(con, id);
                listDuyetAnh = DuyetAnhDal.SelectByPdvId(con, id);
                listBaiHat = BaiHatDal.SelectByPdvId(con, id);
            }
            Add.ListDichVu = dichVuList;
            Add.Item = Item; ;
            Add.ListDuyetAnh = listDuyetAnh;
            Add.ListBaiHat = listBaiHat;
        }
    }
}
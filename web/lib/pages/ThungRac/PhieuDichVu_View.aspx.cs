using System;
using System.Collections.Generic;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_ThungRac_PhieuDichVu_View : System.Web.UI.Page
{
    public PhieuDichVu Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var dichVuList = new List<PhieuDichVuDichVu>();
        var listDuyetAnh = new List<DuyetAnh>();
        var listBaiHat = new List<BaiHat>();
        var listThuChi = new List<ThuChi>();
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
                listThuChi = ThuChiDal.SelectByPdvId(con, Item.ID);
            }
            Add.ListDichVu = dichVuList;
            Add.Item = Item; ;
            Add.ListDuyetAnh = listDuyetAnh;
            Add.ListBaiHat = listBaiHat;
            Add.ListThuChi = listThuChi;
            Add.ListUrl = "/lib/pages/ThungRac/PhieuDichVu.aspx";
        }
    }
}
using System;
using docsoft.entities;
using linh.common;
using linh.core.dal;
public partial class lib_pages_ThuChi_Add_Thu : System.Web.UI.Page
{
    public ThuChi Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request["ID"];
        var khId = Request["KH_ID"];
        var pdvId = Request["PDV_ID"];
        using (var con = DAL.con())
        {
            if (string.IsNullOrEmpty(id))
            {
                Item = ThuChiDal.SelectByDraff(con, true);
                if (khId!= null && khId.Length >= 36)
                {
                    khId = khId.Substring(khId.LastIndexOf(',') + 1);
                    var kh = KhachHangDal.SelectById(new Guid(khId), con);
                    Item.P_Ten = kh.Ten;
                    Item.P_ID = kh.ID;
                }
                

                if (pdvId != null && pdvId.Length >= 36)
                {
                    pdvId = pdvId.Substring(pdvId.LastIndexOf(',') + 1);
                    var pdv = PhieuDichVuDal.SelectById(con, new Guid(pdvId));
                    Item.PDV_ID = pdv.ID;
                    Item.PDV_Ma = pdv.Ma;
                    var kh = KhachHangDal.SelectById(pdv.KH_ID, con);
                    Item.P_Ten = kh.Ten;
                    Item.P_ID = kh.ID;
                }
                

            }
            else
            {
                Item = ThuChiDal.SelectById(con, new Guid(id));
            }
            var listLoai = DanhMucDal.SelectByLDMMa(con, "NDTC-THU");
            AddThu.ListLoai = listLoai;
            AddThu.Item = Item;
        }
    }
}
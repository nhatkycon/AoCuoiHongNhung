using System;
using docsoft.entities;
using linh.common;
using linh.core.dal;

public partial class lib_pages_ThuChi_Add_Chi : System.Web.UI.Page
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
                Item = ThuChiDal.SelectByDraff(con, false);
                if (khId != null && khId.Length > 36)
                {
                    khId = khId.Substring(khId.LastIndexOf(',') + 1);
                    var kh = KhachHangDal.SelectById(new Guid(khId), con);
                    Item.P_Ten = kh.Ten;
                    Item.P_ID = kh.ID;
                }

            }
            else
            {
                Item = ThuChiDal.SelectById(con, new Guid(id));
            }
            var listLoai = DanhMucDal.SelectByLDMMa(con, "NDTC-CHI");
            AddChi.ListLoai = listLoai;
            AddChi.Item = Item;
        }
    }
}
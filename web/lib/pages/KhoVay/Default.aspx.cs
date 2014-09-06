using System;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_KhoVay_Default : System.Web.UI.Page
{
    public string paging { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "10";
        var dmId = Request["DM_ID"];
        var gia = Request["Gia"];

        var url = string.Format("?q={0}&size={1}&DM_ID={2}&Gia={3}", q, size, dmId, gia) + "{1}={0}";
        using (var con = DAL.con())
        {

            var pg =
                HangHoaDal.KhoVay(con, url, false, null, q, Convert.ToInt32(size), dmId, gia);
            List.List = pg.List;
            paging = pg.Paging;

            var nhomHangHoa = DanhMucDal.SelectByLDMMa(con, "HangHoa");
            DM_ID.List = nhomHangHoa;
        }
    }
}
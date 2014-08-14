using System;
using System.Globalization;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_ThuChi_List_Thu : System.Web.UI.Page
{
    public string paging { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var khId = Request["KH_ID"];
        var ndtcId = Request["NDTC_ID"];
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "10";

        var url = string.Format("?q={0}&size={1}&NDTC_ID={2}&", q, size, ndtcId) + "{1}={0}";

        var tuNgay = Request["TuNgay"];
        var denNgay = Request["DenNgay"];

        if (!string.IsNullOrEmpty(tuNgay))
        {
            if(string.IsNullOrEmpty(denNgay))
            {
                tuNgay = Server.UrlDecode(tuNgay);
                var d = Convert.ToDateTime(tuNgay, new CultureInfo("Vi-vn"));
                tuNgay = d.AddDays(-1).ToString("yyyy-MM-dd");
                denNgay = d.AddDays(1).ToString("yyyy-MM-dd");    
            }
            else
            {
                tuNgay = Server.UrlDecode(tuNgay);
                var d = Convert.ToDateTime(tuNgay, new CultureInfo("Vi-vn"));
                tuNgay = d.ToString("yyyy-MM-dd");

                denNgay = Server.UrlDecode(denNgay);
                var d1 = Convert.ToDateTime(denNgay, new CultureInfo("Vi-vn"));
                denNgay = d1.ToString("yyyy-MM-dd");
            }

            
        }


        using (var con = DAL.con())
        {
            var listLoai = DanhMucDal.SelectByLDMMa(con, "NDTC-THU");
            DM_ID.List = listLoai;
            var pg =
                ThuChiDal.pagerNormal(con, url, false, "TC_SoPhieu desc", q, Convert.ToInt32(size), true, ndtcId, tuNgay,
                                      denNgay);
            List.List = pg.List;
            paging = pg.Paging;

        }

    }
}
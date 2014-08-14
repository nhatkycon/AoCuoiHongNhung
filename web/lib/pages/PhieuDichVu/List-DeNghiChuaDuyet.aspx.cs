using System;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_PhieuDichVu_List_DeNghiChuaDuyet : System.Web.UI.Page
{
    public string paging { get; set; }
    public string Ngay { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "10";
        Ngay = Request["Ngay"];
        var url = string.Format("?size={0}&", size) + "{1}={0}";

        using (var con = DAL.con())
        {

            var pg =
                PhieuDichVuDal.pagerDuyetEkip(con, url, false, "PDV_Ma desc", Convert.ToInt32(size), "0");
            ListDeNghiChuaDuyet.List = pg.List;
            paging = pg.Paging;

        }

    }
}
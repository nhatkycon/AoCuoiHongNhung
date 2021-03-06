﻿using System;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_HangHoa_Default : System.Web.UI.Page
{
    public string paging { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = Request["q"];
        var size = Request["size"];
        if (string.IsNullOrEmpty(size)) size = "10";
        var dmId = Request["DM_ID"];

        var url = string.Format("?q={0}&size={1}&DM_ID={2}&", q, size, dmId) + "{1}={0}";
        using (var con = DAL.con())
        {

            var pg =
                HangHoaDal.ByDm(con, url, false, null, q, Convert.ToInt32(size), dmId);
            List.List = pg.List;
            paging = pg.Paging;

            var nhomHangHoa = DanhMucDal.SelectByLDMMa(con, "HangHoa");
            DM_ID.List = nhomHangHoa;
        }
    }
}
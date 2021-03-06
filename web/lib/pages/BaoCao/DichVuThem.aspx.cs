﻿using System;
using System.Globalization;
using docsoft.entities;
using linh.core.dal;

public partial class lib_pages_BaoCao_DichVuThem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var d = DateTime.Now;

        var dauThang = new DateTime(d.Year, d.Month, 1).AddMonths(-1);
        var cuoiThang = new DateTime(d.Year, d.Month, 1);
        var tuNgayStr = Request["TuNgay"];
        var denNgayStr = Request["DenNgay"];
        if (string.IsNullOrEmpty(tuNgayStr))
        {
            tuNgayStr = dauThang.ToString("dd/MM/yyyy");
        }
        if (string.IsNullOrEmpty(denNgayStr))
        {
            denNgayStr = cuoiThang.ToString("dd/MM/yyyy");
        }
        var nhanVien_Id = Request["NhanVien_Id"];
        var tuNgay = Convert.ToDateTime(tuNgayStr, new CultureInfo("Vi-vn"));
        var denNgay = Convert.ToDateTime(denNgayStr, new CultureInfo("Vi-vn"));
        using(var con = DAL.con())
        {
            var list = PhieuDichVuDichVuDal.SelectBaoCao(con, tuNgay.ToString("yyyy-MM-dd"), denNgay.ToString("yyyy-MM-dd"), nhanVien_Id);
            DichVuThem.List = list;
        }
    }
}
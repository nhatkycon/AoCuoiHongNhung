﻿using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;


public partial class lib_ui_XuatNhapSanPham_Add : System.Web.UI.UserControl
{
    public string Id { get; set; }
    public string Ret { get; set; }
    public string PDV_ID { get; set; }
    public PhieuXuatNhapSanPham Item { get; set; }
    public List<PhieuXuatNhapSanPhamChiTiet> List { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["ID"];
        Ret = Request["ret"];
        if (!string.IsNullOrEmpty(Ret))
        {
            Ret = Server.UrlDecode(Ret);
        }
        AddTask.EditAble = Item.NguoiTao == Security.UserId;
        AddTask1.EditAble = Item.NguoiTao == Security.UserId;

        ListEdit.PID = Item.ID.ToString();
        ListEdit.List = List;

    }
}
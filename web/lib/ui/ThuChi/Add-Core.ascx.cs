﻿using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;

public partial class lib_ui_ThuChi_Add_Core : System.Web.UI.UserControl
{
    public string Id { get; set; }
    public string Ret { get; set; }
    public ThuChi Item { get; set; }
    public List<DanhMuc> ListLoai { get; set; }
    public bool Thu { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["ID"];
        Ret = Request["ret"];

        if (!string.IsNullOrEmpty(Ret))
        {
            Ret = Server.UrlDecode(Ret);
        }

        DM_ID.List = ListLoai;
    }
}
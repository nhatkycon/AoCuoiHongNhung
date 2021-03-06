﻿using System;
using System.Collections.Generic;
using docsoft.entities;

public partial class lib_ui_Bally_KhachHang_Add : System.Web.UI.UserControl
{
    public List<DanhMuc> KhuVuc { get; set; }
    public List<DanhMuc> LinhVuc { get; set; }
    public List<DanhMuc> NguonGoc { get; set; }
    public KhachHang Item { get; set; }
    public string Id { get; set; }
    public string Ret { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["ID"];
        Ret = Request["ret"];
        if (!string.IsNullOrEmpty(Ret)) Ret = Server.UrlDecode(Ret);
        Add1.NguonGoc = NguonGoc;
        Add1.LinhVuc = LinhVuc;
        Add1.KhuVuc = KhuVuc;
        Add1.Item = Item;
    }
}
﻿using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;

public partial class lib_ui_PhieuDichVu_Add_Td : System.Web.UI.UserControl
{
    public PhieuDichVu Item { get; set; }
    public string Id { get; set; }
    public List<PhieuDichVuDichVu> ListDichVu { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

        AddTask1.EditAble = Item.TD_NhanVien == Security.UserId;
        AddTask.EditAble = Item.TD_NhanVien == Security.UserId;

        Id = Request["ID"];

        DichVuList.Item = Item;
        DichVuList.List = ListDichVu;

    }
}
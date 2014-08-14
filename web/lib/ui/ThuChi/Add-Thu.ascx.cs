using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;

public partial class lib_ui_ThuChi_Add_Thu : System.Web.UI.UserControl
{
    public string Id { get; set; }
    public string Ret { get; set; }
    public ThuChi Item { get; set; }
    public List<DanhMuc> ListLoai { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Request["ID"];
        Ret = Request["ret"];
        var editAble = Item.NguoiTao == Security.UserId;
        AddTask.EditAble = editAble;
        AddTask_1_1.EditAble = editAble;

        const bool addAble = true;
        AddTask.AddAble = addAble;
        AddTask_1_1.AddAble = addAble;

        const bool removeAble = true;
        AddTask.DeleteAble = removeAble;
        AddTask_1_1.DeleteAble = removeAble;

        if (!string.IsNullOrEmpty(Ret))
        {
            Ret = Server.UrlDecode(Ret);
        }

        AddCore.ListLoai = ListLoai;
        AddCore.Item = Item;
    }
}
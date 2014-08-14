using System;
using System.Collections.Generic;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.common;

public partial class lib_ui_HeThong_LoginForm : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Username.Text) || string.IsNullOrEmpty(Pwd.Text))
        {
            msg.Visible = true;
            return;

        }
        var ok = Security.Login(Username.Text, Pwd.Text, ckb.Checked.ToString());
        if (ok)
        {
            var ret = Request["ret"];
            Session["Menu"] = null;
            Session["Roles"] = null;

            var roleList = RoleDal.SelectRoleByUsername(Username.Text);
            Session["Roles"] = roleList;

            var homeUrl = "/lib/pages/Home/Guest.aspx";
            if(roleList.Any())
            {
                homeUrl = roleList[0].HomeUrl;
            }

            Response.Redirect(string.IsNullOrEmpty(ret) ? homeUrl : Server.UrlDecode(ret));
        }
        else
        {
            msg.Visible = true;
        }
    }
    #region TreeProcess
    List<Function> GetTree(List<Function> inputList)
    {
        var list = new List<Function>();
        foreach (var item in buildTree(inputList))
        {
            item.Entity.Level = item.Depth;
            list.Add(item.Entity);
            buildChild(item, list);
        }
        return list;
    }
    void buildChild(HierarchyNode<Function> item, List<Function> list)
    {
        foreach (var _item in item.ChildNodes)
        {
            _item.Entity.Level = _item.Depth;
            list.Add(_item.Entity);
            buildChild(_item, list);
        }
    }
    IEnumerable<HierarchyNode<Function>> buildTree(List<Function> listInput)
    {
        var tree = listInput.OrderByDescending(e => e.ThuTu).ToList().AsHierarchy(e => e.ID, e => e.PID);
        return tree.ToList();
    }
    #endregion

}
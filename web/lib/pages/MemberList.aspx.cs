using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;


public partial class lib_pages_MemberList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserList.List = MemberDal.SelectAll();
    }
}
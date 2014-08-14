using System;
using System.Collections.Generic;
using System.Linq;
using docsoft;
using docsoft.entities;
using linh.core.dal;
public partial class lib_pages_Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        var HomePageUrl = string.Empty;
        var roles = Session["Roles"];
        List<Role> roleList;
        if (roles == null)
        {
            roleList = RoleDal.SelectRoleByUsername(Security.Username);
            Session["Roles"] = roleList;
        }
        else
        {
            roleList = (List<Role>)roles;
        }

        if (roleList.Any())
        {
            HomePageUrl = roleList[0].HomeUrl;
            Response.Redirect(HomePageUrl);
        }
    }
}
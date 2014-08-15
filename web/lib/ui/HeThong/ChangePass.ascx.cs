using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.common;

public partial class lib_ui_HeThong_ChangePass : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Security.IsAuthenticated())
        {
            Response.Redirect(domain + "/lib/pages/Login.aspx?ret=" + Server.UrlEncode(Request.Url.PathAndQuery));
        }
        if(!IsPostBack)
        {
            OldPwd.Text = "";
            Pwd.Text = "";
        }
    }
    public string domain
    {
        get
        {
            HttpContext c = HttpContext.Current;
            if (c.Request.Url.Host.ToLower() == "localhost")
            {
                return string.Format("http://{0}{1}", c.Request.Url.Host
                , c.Request.IsLocal ? string.Format(":{0}{1}", c.Request.Url.Port, c.Request.ApplicationPath) : (c.Request.Url.Port == 80 ? "" : ":" + c.Request.Url.Port));
            }
            return string.Format("http://{0}{1}", c.Request.Url.Host, (c.Request.Url.Port == 80 ? "" : ":" + c.Request.Url.Port));
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        var u = Security.Username;
        if(string.IsNullOrEmpty(OldPwd.Text) || string.IsNullOrEmpty(Pwd.Text))
        {
            msg.Visible = true;
            return;
        }

        var ok = Security.Login(u, OldPwd.Text, "true");
        if(ok)
        {
            var member = MemberDal.SelectByUser(Security.Username);
            member.Password = maHoa.MD5Encrypt(Pwd.Text);
            member.NgayCapNhat = DateTime.Now;
            MemberDal.Update(member);
            var ret = Request["ret"];
            Response.Redirect(Server.UrlDecode(ret));
        }
        else
        {
            msg.Visible = true;
            return;
        }
        
    }
}
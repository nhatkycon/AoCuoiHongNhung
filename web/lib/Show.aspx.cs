using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.json;
using System.IO;

public partial class lib_Show : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var path = Request["path"];
        if(!string.IsNullOrEmpty(path))
        {
            path = Server.MapPath(path);
            var dic = new DirectoryInfo(path);
            
            var files = dic.GetFiles();

            var sb = new StringBuilder();
            foreach (var file in files)
            {
                sb.AppendFormat("{0}|", file.Name);
            }
            rendertext(sb.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using docsoft.entities;
using linh.common;
using linh.core.dal;

public partial class lib_pages_DuyetAnh_View : System.Web.UI.Page
{
    private const string ImgPath = @"E:\GIAITRI\Images\Demo";
    private const string PdvId = "B532256B-EE5D-4D3C-9B77-71E8B1E77D45";
    public PhieuDichVu Item { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        var id = Request["ID"];
        if (string.IsNullOrEmpty(id)) id = PdvId;
        using (var con = DAL.con())
        {
            var selected = DuyetAnhDal.SelectByPdvId(con, id);

            var pdv = PhieuDichVuDal.SelectById(con, new Guid(id));
            Item = pdv;
            var listBaiHat = BaiHatDal.SelectByPdvId(con, id);
            var pdvDic = pdv.PTS_ThuMuc;
            if (string.IsNullOrEmpty(pdvDic)) pdvDic = ImgPath;
            var dic = new DirectoryInfo(pdvDic);


            var targetDic = Lib.ImgDomain() + pdvDic;

            var wc = new WebClient();
            var filesInTargetDic = wc.DownloadString(targetDic);
            if (string.IsNullOrEmpty(filesInTargetDic))
            {
            }
            else
            {
                var files = filesInTargetDic.Split(new char[] {'|'});


                var list = (from f in files
                            where f.Length > 1
                            select new DuyetAnh()
                                       {
                                           Ten = f
                                           ,
                                           FullName = string.Format("{0}{1}", targetDic, f)
                                       }).ToList();

                foreach (var item in selected)
                {
                    var items = list.FirstOrDefault(x => x.Ten.ToLower() == item.Ten.ToLower());
                    if (items == null) continue;
                    items.ID = item.ID;
                    items.Selected = true;
                    items.GhiChu = item.GhiChu;
                    items.ThuTu = item.ThuTu;
                }
                View.DuyetAnhs = list.Where(x => x.Selected).ToList();
                View.DanhSachAnh = list;
                View.Item = pdv;
                View.ListBaiHat = listBaiHat;
            }
        }
        

       

    }
}
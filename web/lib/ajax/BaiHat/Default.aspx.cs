using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.json;

public partial class lib_ajax_BaiHat_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var logged = Security.IsAuthenticated();
        var Id = Request["Id"];
        var PDVDV_Id = Request["PDVDV_Id"];
        var IdNull = string.IsNullOrEmpty(Id);

        var PDV_ID = Request["BH_PDV_ID"];
        var BH_ID = Request["BH_ID"];
        var STT = Request["STT"];
        var Ten = Request["Ten"];

        var refUrl = Request["refUrl"];
        if (!string.IsNullOrEmpty(refUrl))
            refUrl = Server.UrlDecode(refUrl);

        switch (subAct)
        {
            case "save":

                #region save Bai hat

                if (!string.IsNullOrEmpty(PDV_ID))
                {

                    var item = new BaiHat();
                    item.ID = Guid.NewGuid();

                    item.PDV_ID = new Guid(PDV_ID);
                    item.NgayTao = DateTime.Now;
                    item.NgayCapNhat = DateTime.Now;
                    item.NguoiTao = Security.UserId;
                    item.Ten = Ten;
                    if (!string.IsNullOrEmpty(STT))
                    {
                        item.STT = Convert.ToInt32(STT);
                    }
                    item = BaiHatDal.Insert(item);
                    ItemEdit.Item = item;
                    ItemEdit.Visible = true;
                }
                break;

                #endregion

            case "update":

                #region update  Bai hat

                if (!string.IsNullOrEmpty(BH_ID))
                {

                    var item = BaiHatDal.SelectById(new Guid(BH_ID));

                    if (!string.IsNullOrEmpty(STT))
                    {
                        item.STT = Convert.ToInt32(STT);
                    }

                    item.Ten = Ten;
                    item.NgayCapNhat = DateTime.Now;
                    item = BaiHatDal.Update(item);
                    rendertext(item.ID.ToString());
                }
                break;

                #endregion

            case "remove":

                #region Xóa  Bai hat

                if (logged && !IdNull)
                {
                    var item = BaiHatDal.SelectById(new Guid(Id));
                    if (item.NguoiTao == Security.UserId)
                    {
                        BaiHatDal.DeleteById(new Guid(Id));
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);

                        #region log

                        LogDal.log(item, new Log()
                                             {
                                                 Checked = false
                                                 ,
                                                 Info =
                                                     string.Format("{1} xóa bài hát {0}", item.Ten,
                                                                   Security.Username)
                                                 ,
                                                 NgayTao = DateTime.Now
                                                 ,
                                                 Username = Security.Username
                                                 ,
                                                 PRowId = item.ID
                                                 ,
                                                 PTen = item.Ten
                                                 ,
                                                 RequestIp = Request.UserHostAddress
                                                 ,
                                                 RawUrl = refUrl
                                                 ,
                                                 LLOG_ID = 3
                                                 ,
                                                 Ten = "Xóa"
                                             });

                        #endregion

                        rendertext("1");
                    }
                    else
                    {
                        rendertext("0");
                    }
                }
                break;

                #endregion

            default:
                break;
        }
    }
}
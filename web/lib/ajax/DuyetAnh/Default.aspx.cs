using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.json;
using System.Linq;
using System.Linq.Expressions;

public partial class lib_ajax_DuyetAnh_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var logged = Security.IsAuthenticated();
        var Id = Request["Id"];
        var PDVDV_Id = Request["PDVDV_Id"];
        var IdNull = string.IsNullOrEmpty(Id);

        var PDV_ID = Request["DUYETANH_PDV_ID"];
        var DUYETANH_ID = Request["DUYETANH_ID"];
        var ThuTu = Request["ThuTu"];
        var Ten = Request["Ten"];
        var GhiChu = Request["GhiChu"];

        var refUrl = Request["refUrl"];
        if (!string.IsNullOrEmpty(refUrl))
            refUrl = Server.UrlDecode(refUrl);

        switch (subAct)
        {
            case "save":
                #region save Duyet anh
                if (!string.IsNullOrEmpty(PDV_ID))
                {

                    var item = new DuyetAnh();
                    item.ID = Guid.NewGuid();

                    item.PDV_ID = new Guid(PDV_ID);
                    item.NgayTao = DateTime.Now;
                    item.NhanVien = Security.UserId;
                    item.Ten = Ten;
                    item.GhiChu = GhiChu;
                    if(!string.IsNullOrEmpty(ThuTu))
                    {
                        item.ThuTu = Convert.ToInt32(ThuTu);
                    }
                    item = DuyetAnhDal.Insert(item);
                    ItemEdit.Item = item;
                    ItemEdit.Visible = true;
                }
                break;
                #endregion
            case "saveQuick":
                #region save Duyet anh
                if (!string.IsNullOrEmpty(PDV_ID))
                {

                    var item = new DuyetAnh();
                    item.ID = Guid.NewGuid();

                    item.PDV_ID = new Guid(PDV_ID);
                    item.NgayTao = DateTime.Now;
                    item.NhanVien = Security.UserId;
                    item.Ten = Ten;
                    item.GhiChu = GhiChu;
                    if (!string.IsNullOrEmpty(ThuTu))
                    {
                        item.ThuTu = Convert.ToInt32(ThuTu);
                    }
                    item = DuyetAnhDal.Insert(item);
                    rendertext(item.ID.ToString());
                }
                break;
                #endregion
            case "update":
                #region update Goi dich vu chi tiet
                if (!string.IsNullOrEmpty(DUYETANH_ID))
                {

                    var item = DuyetAnhDal.SelectById(new Guid(DUYETANH_ID));
                    
                    if (!string.IsNullOrEmpty(ThuTu))
                    {
                        item.ThuTu = Convert.ToInt32(ThuTu);
                    }
                    if (!string.IsNullOrEmpty(ThuTu))
                    {
                        item.ThuTu = Convert.ToInt32(ThuTu);
                    }
                    item.Ten = Ten;
                    item.GhiChu = GhiChu;
                    item = DuyetAnhDal.Update(item);
                    rendertext(item.ID.ToString());
                }
                break;
                #endregion
            case "remove":
                #region Xóa Goi dich vu chi tiet
                if (logged && !IdNull)
                {
                    var item = DuyetAnhDal.SelectById(new Guid(Id));
                    if (item.NhanVien == Security.UserId)
                    {
                        DuyetAnhDal.DeleteById(new Guid(Id));
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} xóa gói ảnh {0}", item.Ten,
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
            case "removeByTen":
                #region Xóa by Ten
                if (logged && !string.IsNullOrEmpty(PDV_ID) && !string.IsNullOrEmpty(Ten))
                {
                    var item = DuyetAnhDal.SelectByPdvIdTen(DAL.con(), PDV_ID, Ten).FirstOrDefault();
                    if (item == null) rendertext("0");

                    if (item.NhanVien == Security.UserId)
                    {
                        DuyetAnhDal.DeleteById(item.ID);
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} xóa ảnh của phiếu dịch vụ {0}", item.Ten,
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
            default: break;
        }

    }
}
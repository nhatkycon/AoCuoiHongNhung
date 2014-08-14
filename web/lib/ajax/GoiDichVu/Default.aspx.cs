using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.json;

public partial class lib_ajax_GoiDichVu_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var logged = Security.IsAuthenticated();
        var Id = Request["Id"];
        var IdNull = string.IsNullOrEmpty(Id);

        var Ma = Request["Ma"];
        var ThuTu = Request["ThuTu"];
        var Ten = Request["Ten"];
        var MoTa = Request["MoTa"];
        var GNY = Request["GNY"];


        var GiaMin = Request["GiaMin"];
        var GiaMax = Request["GiaMax"];
        var refUrl = Request["refUrl"];
        var GDVID = Request["GDVID"];
        var q = Request["q"];
        if (!string.IsNullOrEmpty(refUrl))
            refUrl = Server.UrlDecode(refUrl);


        switch (subAct)
        {
            case "save":
                #region Thêm khách hàng
                if (logged)
                {
                    var item = IdNull ? new GoiDichVu() : GoiDichVuDal.SelectById(new Guid(Id));
                    item.Ten = Ten;
                    item.Ma = Ma;
                    item.MoTa = MoTa;
                    item.NgayCapNhat = DateTime.Now;
                    if (!string.IsNullOrEmpty(GNY))
                    {
                        item.GNY = Convert.ToDouble(GNY);
                    }
                    if (!string.IsNullOrEmpty(ThuTu))
                    {
                        item.ThuTu = Convert.ToInt32(ThuTu);
                    }
                    if (!string.IsNullOrEmpty(GiaMin))
                    {
                        item.GiaMin = Convert.ToDouble(GiaMin);
                    }
                    if (!string.IsNullOrEmpty(GiaMax))
                    {
                        item.GiaMax = Convert.ToDouble(GiaMax);
                    }
                    
                    if (IdNull)
                    {
                        item.NgayTao = DateTime.Now;
                        item.NguoiTao = Security.UserId;
                        item.ID = Guid.NewGuid();
                        item = GoiDichVuDal.Insert(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{2} thêm mới gói dịch vụ {1}-{0}", item.Ten, item.Ma,
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
                            LLOG_ID = 1
                            ,
                            Ten = "Thêm"
                        });
                        #endregion
                    }
                    else
                    {
                        item = GoiDichVuDal.Update(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{2} sửa gói dịch vụ {1}-{0}", item.Ten, item.Ma,
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
                            LLOG_ID = 2
                            ,
                            Ten = "Sửa"
                        });
                        #endregion
                    }
                    TimKiemDal.Add(item, item.ID);
                    rendertext(item.ID.ToString());
                }
                break;
                #endregion
            case "saveDvCt":
                #region save Goi dich vu chi tiet
                if (!string.IsNullOrEmpty(GDVID) && !string.IsNullOrEmpty(Id))
                {
                    var hh = HangHoaDal.SelectById(new Guid(Id));
                    var gdv = GoiDichVuDal.SelectById(new Guid(GDVID));

                    var item = new GoiDichVuChiTiet();
                    item.ID = Guid.NewGuid();
                    item.HH_ID = hh.ID;
                    item.GDV_ID = gdv.ID;
                    item.Gia = hh.GNY;
                    item.SoLuong = 1;
                    item.Tien = item.Gia*item.SoLuong;
                    item.NgayCapNhat = DateTime.Now;
                    item.NgayTao = DateTime.Now;
                    item.NguoiTao = Security.UserId;
                    item = GoiDichVuChiTietDal.Insert(item);
                    ItemDichVu.Item = item;
                    ItemDichVu.Visible = true;
                }
                break;
                #endregion
            case "updateDvCt":
                #region update Goi dich vu chi tiet
                if (!string.IsNullOrEmpty(Id))
                {
                    var SoLuong = Request["SoLuong"];
                    var Gia = Request["Gia"];

                    var item = GoiDichVuChiTietDal.SelectById(new Guid(Id));
                    if (!string.IsNullOrEmpty(Gia))
                    {
                        item.Gia = Convert.ToDouble(Gia);
                    }
                    if (!string.IsNullOrEmpty(SoLuong))
                    {
                        item.SoLuong = Convert.ToInt32(SoLuong);
                    }
                    if (!string.IsNullOrEmpty(ThuTu))
                    {
                        item.ThuTu = Convert.ToInt32(ThuTu);
                    }
                    item.Tien = item.Gia * item.SoLuong;
                    item.NgayCapNhat = DateTime.Now;
                    item = GoiDichVuChiTietDal.Update(item);
                    rendertext(item.ID.ToString());
                }
                break;
                #endregion
            case "remove":
                #region Xóa khách hàng
                if (logged && !IdNull)
                {
                    var item = GoiDichVuDal.SelectById(new Guid(Id));
                    if (item.NguoiTao == Security.UserId)
                    {
                        GoiDichVuDal.DeleteById(new Guid(Id));
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{2} xóa gói dịch vụ {1}-{0}", item.Ten, item.Ma,
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
            case "removeDvCt":
                #region Xóa Goi dich vu chi tiet
                if (logged && !IdNull)
                {
                    var item = GoiDichVuChiTietDal.SelectById(new Guid(Id));
                    if (item.NguoiTao == Security.UserId)
                    {
                        GoiDichVuChiTietDal.DeleteById(new Guid(Id));
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} xóa gói dịch vụ chi tiết {0}", item.HH_Ten,
                                              Security.Username)
                            ,
                            NgayTao = DateTime.Now
                            ,
                            Username = Security.Username
                            ,
                            PRowId = item.ID
                            ,
                            PTen = item.HH_Ten
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
            case "search":
                #region search
                var list = GoiDichVuDal.SelectAll();
                rendertext(JavaScriptConvert.SerializeObject(list), "text/javascript");
                break;
                #endregion
            default: break;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using docsoft;
using docsoft.entities;
using linh.core;
using linh.core.dal;
using linh.json;

public partial class lib_ajax_KhachHang_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var act = Request["act"];
        var logged = Security.IsAuthenticated();
        var Id = Request["Id"];
        var IdNull = string.IsNullOrEmpty(Id);
        var Ten = Request["Ten"];
        var Ma = Request["Ma"];
        var DanhGia = Request["DanhGia"];
        var Mobile = Request["Mobile"];
        var Email = Request["Email"];
        var Ym = Request["Ym"];
        var FacebookUid = Request["FacebookUid"];
        var NguonGoc_ID = Request["NguonGoc_ID"];
        var KhuVuc_ID = Request["KhuVuc_ID"];
        var XungHo = Request["XungHo"];
        var LinhVuc_ID = Request["LinhVuc_ID"];
        var NgungTheoDoi = Request["NgungTheoDoi"];
        var ThoiGianGoiDien = Request["ThoiGianGoiDien"];
        var CMND = Request["CMND"];
        var CMND_NgayCap = Request["CMND_NgayCap"];
        var CMND_NoiCap = Request["CMND_NoiCap"];
        var DiaChi = Request["DiaChi"];
        var Anh = Request["Anh"];
        var NgaySinh = Request["NgaySinh"];
        var NgayCuoi = Request["NgayCuoi"];
        var TiemNang = Request["TiemNang"];
        var BoQua = Request["BoQua"];
        var ThanhCong = Request["ThanhCong"];
        var refUrl = Request["refUrl"];
        var q = Request["q"];
        if (!string.IsNullOrEmpty(refUrl))
            refUrl = Server.UrlDecode(refUrl);
        NgungTheoDoi = !string.IsNullOrEmpty(NgungTheoDoi) ? "true" : "false";
        BoQua = !string.IsNullOrEmpty(BoQua) ? "true" : "false";
        ThanhCong = !string.IsNullOrEmpty(ThanhCong) ? "true" : "false";
        switch (subAct)
        {
            case "save":
            #region Thêm khách hàng
                if(logged)
                {
                    var item = IdNull ? new KhachHang() : KhachHangDal.SelectById(new Guid(Id));
                    item.Ten = Ten;
                    item.Ma = Ma;
                    item.Anh = Anh;
                    item.ThoiGianGoiDien = ThoiGianGoiDien;
                    item.Mobile = Mobile;
                    item.FacebookUid = FacebookUid;
                    item.NgungTheoDoi = Convert.ToBoolean(NgungTheoDoi);
                    item.NguoiCapNhat = Security.Username;
                    item.NgayCapNhat = DateTime.Now;
                    item.DiaChi = DiaChi;
                    item.Ym = Ym;
                    item.TiemNang = Convert.ToBoolean(TiemNang);
                    item.CMND = CMND;
                    item.XungHo = XungHo;
                    item.CMND_NoiCap = CMND_NoiCap;
                    if (!string.IsNullOrEmpty(CMND_NgayCap))
                    {
                        item.CMND_NgayCap = Convert.ToDateTime(CMND_NgayCap, new CultureInfo("vi-vn"));
                    }

                    if (!string.IsNullOrEmpty(NgaySinh))
                    {
                        item.NgaySinh = Convert.ToDateTime(NgaySinh, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NgayCuoi))
                    {
                        item.NgayCuoi = Convert.ToDateTime(NgayCuoi, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NguonGoc_ID))
                    {
                        item.NguonGoc_ID = new Guid(NguonGoc_ID);
                    }
                    if (!string.IsNullOrEmpty(KhuVuc_ID))
                    {
                        item.KhuVuc_ID = new Guid(KhuVuc_ID);
                    }
                    if (!string.IsNullOrEmpty(LinhVuc_ID))
                    {
                        item.LinhVuc_ID = new Guid(LinhVuc_ID);
                    }
                    item.DanhGia = Convert.ToInt16(DanhGia);
                    if (IdNull)
                    {
                        item.NgayTao = DateTime.Now;
                        item.NguoiTao = Security.Username;
                        item.ID = Guid.NewGuid();
                        item = KhachHangDal.Insert(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{2} thêm mới khách hàng {1}-{0}", item.Ten, item.Ma,
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
                        item = KhachHangDal.Update(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{2} sửa khách hàng {1}-{0}", item.Ten, item.Ma,
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
                    TimKiemDal.Add(item,item.ID);
                    //SearchManager.Add(Ten,string.Format("Khách hàng: {0}, Mobile: {1}, Địa chỉ: {2}"
                    //    , Ten, Mobile, DiaChi),item.IndexContent, Ten,item.ID.ToString(),item.Url,typeof(KhachHang).Name);
                    rendertext(item.ID.ToString());
                }
                break;
            #endregion
            case "quickSave":
                #region Thêm khách hàng nhanh
                if (logged)
                {
                    var item = IdNull ? new KhachHang() : KhachHangDal.SelectById(new Guid(Id));
                    item.Ten = Ten;
                    item.Ma = Ma;
                    item.Mobile = Mobile;
                    item.Email = Email;
                    item.NguoiCapNhat = Security.Username;
                    item.NgayCapNhat = DateTime.Now;
                    item.DiaChi = DiaChi;
                    if (!string.IsNullOrEmpty(NguonGoc_ID))
                    {
                        item.NguonGoc_ID = new Guid(NguonGoc_ID);
                    }
                    if (IdNull)
                    {
                        item.NgayTao = DateTime.Now;
                        item.NguoiTao = Security.Username;
                        item.ID = Guid.NewGuid();
                        item = KhachHangDal.Insert(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{2} thêm mới khách hàng {1}-{0}", item.Ten, item.Ma,
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
                        item = KhachHangDal.Update(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{2} sửa khách hàng {1}-{0}", item.Ten, item.Ma,
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
                    rendertext(string.Format("({0})", JavaScriptConvert.SerializeObject(item)));
                }
                break;
                #endregion
            case "remove":
            #region Xóa khách hàng
                if(logged && !IdNull)
                {
                    var item = KhachHangDal.SelectById(new Guid(Id));
                    if(item.NguoiTao==Security.Username)
                    {
                        KhachHangDal.DeleteById(new Guid(Id));
                        //SearchManager.Remove(Id);
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{2} xóa khách hàng {1}-{0}", item.Ten, item.Ma,
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
            case "search":
            #region search

                var pgTiemNang = KhachHangDal.pagerAll(null, false, "KH_NgayTao desc", q, 20, null, null, null, "0");
                rendertext(JavaScriptConvert.SerializeObject(pgTiemNang.List), "text/javascript");
                break;
            #endregion
            default: break;
        }
        
    }
}
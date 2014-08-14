using System;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class lib_ajax_LichHen_Default : basePage
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
        var Ym = Request["Ym"];
        var FacebookUid = Request["FacebookUid"];
        var NguonGoc_ID = Request["NguonGoc_ID"];
        var KhuVuc_ID = Request["KhuVuc_ID"];
        var LinhVuc_ID = Request["LinhVuc_ID"];
        var NgungTheoDoi = Request["NgungTheoDoi"];
        var ThoiGianGoiDien = Request["ThoiGianGoiDien"];
        var DiaChi = Request["DiaChi"];
        var Anh = Request["Anh"];
        var NgaySinh = Request["NgaySinh"];
        var TiemNang = Request["TiemNang"];
        var KH_ID = Request["KH_ID"];
        var TT_ID = Request["TT_ID"];
        var LOAI_ID = Request["LOAI_ID"];
        var NoiDung = Request["NoiDung"];
        var NgayBatDau = Request["NgayBatDau"];
        var DM_ID = Request["DM_ID"];
        var NhanVien = Request["NhanVien"];
        var MoTa = Request["MoTa"];
        var BoQua = Request["BoQua"];
        var ThanhCong = Request["ThanhCong"];
        var refUrl = Request["refUrl"];
        var DV_ID = Request["DV_ID"];
        var Gia = Request["Gia"];
        var CK = Request["CK"];
        var ThanhToan = Request["ThanhToan"];
        var ConNo = Request["ConNo"];
        var BaoHanh_ID = Request["BaoHanh_ID"];
        var NgayLap = Request["NgayLap"];
        var NgayLam = Request["NgayLam"];
        var TVDV_ID = Request["TVDV_ID"];
        var ThuTu = Request["ThuTu"];
        var SoLan = Request["SoLan"];
        var GhiChu = Request["GhiChu"];
        var NgayBatDau_Gio = Request["NgayBatDau_Gio"];
        var NgayKetThuc_Gio = Request["NgayKetThuc_Gio"];
        if (!string.IsNullOrEmpty(refUrl))
            refUrl = Server.UrlDecode(refUrl);
        NgungTheoDoi = !string.IsNullOrEmpty(NgungTheoDoi) ? "true" : "false";
        BoQua = !string.IsNullOrEmpty(BoQua) ? "true" : "false";
        ThanhCong = !string.IsNullOrEmpty(ThanhCong) ? "true" : "false";
        switch (subAct)
        {
            case "save":
                #region Thêm lịch hẹn

                if (Security.IsAuthenticated())
                {
                    SuKien item;
                    if (IdNull)
                    {
                        item = new SuKien { ID = Guid.NewGuid(), NgayTao = DateTime.Now, NguoiTao = Security.Username, NguoiCapNhat = Security.Username, NgayCapNhat = DateTime.Now };
                    }
                    else
                    {
                        item = SuKienDal.SelectById(new Guid(Id));

                    }
                    item.Ten = Ten;
                    item.MoTa = MoTa;
                    if (!string.IsNullOrEmpty(NgayBatDau) && !string.IsNullOrEmpty(NgayBatDau_Gio))
                    {
                        item.NgayBatDau = Convert.ToDateTime(string.Format("{0} {1}", NgayBatDau, NgayBatDau_Gio), new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NgayBatDau) && !string.IsNullOrEmpty(NgayKetThuc_Gio))
                    {
                        item.NgayKetThuc = Convert.ToDateTime(string.Format("{0} {1}", NgayBatDau, NgayKetThuc_Gio), new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(KH_ID))
                    {
                        item.KH_ID = new Guid(KH_ID);
                    }
                    if (!string.IsNullOrEmpty(DM_ID))
                    {
                        item.DM_ID = new Guid(DM_ID);
                    }
                    item.BoQua = Convert.ToBoolean(BoQua);
                    item.ThanhCong = Convert.ToBoolean(ThanhCong);
                    item.NhanVien = NhanVien;
                    if (IdNull)
                    {
                        item = SuKienDal.Insert(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} thêm mới lịch hẹn: {0}", item.Ten,
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
                        item = SuKienDal.Update(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} sửa lịch hẹn: {0}", item.Ten,
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
                    //SearchManager.Add(Ten, item.IndexNoiDung, item.IndexContent, Ten, item.ID.ToString(), item.Url, typeof(SuKien).Name);
                    TimKiemDal.Add(item, item.ID);
                    rendertext(item.ID.ToString());
                }
                break;

                #endregion
            case "LichHen-Xoa":
                #region Xóa lịch hẹn

                if (Security.IsAuthenticated())
                {
                    var item = SuKienDal.SelectById(new Guid(Id));
                    if (item.NguoiTao == Security.Username)
                    {
                        SuKienDal.DeleteById(new Guid(Id));
                        //SearchManager.Remove(Id);
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} xóa lịch hẹn: {0}", item.Ten,
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
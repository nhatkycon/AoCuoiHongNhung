using System;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.json;
public partial class lib_ajax_GiatLa_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        var logged = Security.IsAuthenticated();
        var Id = Request["Id"];
        var IdNull = string.IsNullOrEmpty(Id);

        var q = Request["q"];
        var refUrl = Request["refUrl"];
        if (!string.IsNullOrEmpty(refUrl))
            refUrl = Server.UrlDecode(refUrl);

        var CH_ID = Request["CH_ID"];
        var Ma = Request["Ma"];
        var Tien = Request["Tien"];
        var NgayBatDau = Request["NgayBatDau"];
        var NgayKetThuc = Request["NgayKetThuc"];
        var NguoiXuat = Request["NguoiXuat"];
        var NguoiNhap = Request["NguoiNhap"];
        var NgayTao = Request["NgayTao"];
        var NguoiTao = Request["NguoiTao"];
        var NgayCapNhat = Request["NgayCapNhat"];
        var NguoiCapNhat = Request["NguoiCapNhat"];
        var TrangThai = Request["TrangThai"];
        switch (subAct)
        {
            case "save":
                #region Thêm khách hàng
                if (logged)
                {
                    var item = PhieuGiatVayDal.SelectById(DAL.con(), new Guid(Id));
                    IdNull = item.ID == Guid.Empty;
                    if (!string.IsNullOrEmpty(NguoiXuat))
                    {
                        item.NguoiXuat = Convert.ToInt32(NguoiXuat);
                    }
                    if (!string.IsNullOrEmpty(NguoiNhap))
                    {
                        item.NguoiNhap = Convert.ToInt32(NguoiNhap);
                    }
                    if (!string.IsNullOrEmpty(CH_ID))
                    {
                        item.CH_ID = new Guid(CH_ID);
                    }

                    if (!string.IsNullOrEmpty(Tien))
                    {
                        item.Tien = Convert.ToDouble(Tien);
                    }
                    
                    if (!string.IsNullOrEmpty(Ma))
                    {
                        item.Ma = Convert.ToInt32(Ma);
                    }
                    if (!string.IsNullOrEmpty(TrangThai))
                    {
                        item.TrangThai = Convert.ToInt32(TrangThai);
                    }
                   
                    if (!string.IsNullOrEmpty(NgayBatDau))
                    {
                        item.NgayBatDau = Convert.ToDateTime(NgayBatDau, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NgayKetThuc))
                    {
                        item.NgayKetThuc = Convert.ToDateTime(NgayKetThuc, new CultureInfo("vi-vn"));
                    }

                    if (IdNull)
                    {
                        item.ID = new Guid(Id);
                        item.NgayTao = DateTime.Now;
                        item.NguoiTao = Security.UserId;
                    }
                    item.NgayCapNhat = DateTime.Now;
                    item.NguoiCapNhat = Security.UserId;

                    if (IdNull)
                    {
                        item = PhieuGiatVayDal.Insert(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} thêm mới phiếu giặt váy: {0}", item.MaStr,
                                              Security.Username)
                            ,
                            NgayTao = DateTime.Now
                            ,
                            Username = Security.Username
                            ,
                            PRowId = item.ID
                            ,
                            PTen = item.MaStr
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
                        item = PhieuGiatVayDal.Update(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} sửa phiếu giặt váy: {0}", item.MaStr,
                                              Security.Username)
                            ,
                            NgayTao = DateTime.Now
                            ,
                            Username = Security.Username
                            ,
                            PRowId = item.ID
                            ,
                            PTen = item.MaStr
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
            case "remove":
                #region Xóa phiếu xuất nhập/ phiếu dịch vụ
                if (logged && !IdNull)
                {
                    var item = PhieuGiatVayDal.SelectById(DAL.con(), new Guid(Id));
                    if (item.NguoiTao == Security.UserId)
                    {
                        PhieuGiatVayDal.DeleteById(new Guid(Id));
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} xóa phiếu giặt váy: {0}", item.MaStr,
                                              Security.Username)
                            ,
                            NgayTao = DateTime.Now
                            ,
                            Username = Security.Username
                            ,
                            PRowId = item.ID
                            ,
                            PTen = item.MaStr
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
                var list = ChoThueVayDal.SelectAll();
                rendertext(JavaScriptConvert.SerializeObject(list), "text/javascript");
                break;
                #endregion
            default: break;
        }

    }
}
using System;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.json;

public partial class lib_ajax_ChoThueVay_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var logged = Security.IsAuthenticated();
        var Id = Request["Id"];
        var IdNull = string.IsNullOrEmpty(Id);

        var KH_ID = Request["KH_ID"];
        var Ma = Request["Ma"];
        var Tong = Request["Tong"];
        var DatCong = Request["DatCong"];
        var ThanhToan = Request["ThanhToan"];
        var ConNo = Request["ConNo"];
        var Ngay = Request["Ngay"];
        var NgayBatDau = Request["NgayBatDau"];
        var NgayKetThuc = Request["NgayKetThuc"];
        var NgayTraVayThucTe = Request["NgayTraVayThucTe"];
        var ThuKho = Request["ThuKho"];
        var NguoiXuat = Request["NguoiXuat"];
        var NguoiNhap = Request["NguoiNhap"];
        var NguoiTao = Request["NguoiTao"];
        var NgayTao = Request["NgayTao"];
        var NguoiCapNhat = Request["NguoiCapNhat"];
        var NgayCapNhat = Request["NgayCapNhat"];
        var TrangThai = Request["TrangThai"];

        var q = Request["q"];
        var refUrl = Request["refUrl"];
        if (!string.IsNullOrEmpty(refUrl))
            refUrl = Server.UrlDecode(refUrl);

        switch (subAct)
        {
            case "save":
                #region Thêm khách hàng
                if (logged)
                {
                    var item = ChoThueVayDal.SelectById(DAL.con(), new Guid(Id));
                    IdNull = item.ID == Guid.Empty;
                    if (!string.IsNullOrEmpty(NguoiXuat))
                    {
                        item.NguoiXuat = Convert.ToInt32(NguoiXuat);
                    }
                    if (!string.IsNullOrEmpty(NguoiNhap))
                    {
                        item.NguoiNhap = Convert.ToInt32(NguoiNhap);
                    }
                    if (!string.IsNullOrEmpty(ThuKho))
                    {
                        item.ThuKho = Convert.ToInt32(ThuKho);
                    }

                    if(!string.IsNullOrEmpty(Tong))
                    {
                        item.Tong = Convert.ToDouble(Tong);
                    }
                    if (!string.IsNullOrEmpty(DatCong))
                    {
                        item.DatCong = Convert.ToDouble(DatCong);
                    }

                    if (!string.IsNullOrEmpty(Ma))
                    {
                        item.Ma = Convert.ToInt32(Ma);                        
                    }
                    if (!string.IsNullOrEmpty(TrangThai))
                    {
                        item.TrangThai = Convert.ToInt32(TrangThai);
                    }
                    if (!string.IsNullOrEmpty(KH_ID))
                    {
                        item.KH_ID = new Guid(KH_ID);
                    }


                    if (!string.IsNullOrEmpty(Ngay))
                    {
                        item.Ngay = Convert.ToDateTime(Ngay, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NgayBatDau))
                    {
                        item.NgayBatDau = Convert.ToDateTime(NgayBatDau, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NgayKetThuc))
                    {
                        item.NgayKetThuc = Convert.ToDateTime(NgayKetThuc, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NgayTraVayThucTe))
                    {
                        item.NgayTraVayThucTe = Convert.ToDateTime(NgayTraVayThucTe, new CultureInfo("vi-vn"));
                    }

                    if(IdNull)
                    {
                        item.ID = new Guid(Id);
                        item.NgayTao = DateTime.Now;
                        item.NguoiTao = Security.UserId;
                    }
                    item.NgayCapNhat = DateTime.Now;
                    item.NguoiCapNhat = Security.UserId;

                    if (IdNull)
                    {
                        item = ChoThueVayDal.Insert(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} thêm mới phiếu cho thuê váy: {0}", item.MaStr,
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
                        item = ChoThueVayDal.Update(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} sửa phiếu cho thuê váy: {0}", item.MaStr,
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
                    var item = ChoThueVayDal.SelectById(DAL.con(), new Guid(Id));
                    if (item.NguoiTao == Security.UserId)
                    {
                        ChoThueVayDal.DeleteById(new Guid(Id));
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} xóa phiếu cho thuê váy: {0}", item.MaStr,
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
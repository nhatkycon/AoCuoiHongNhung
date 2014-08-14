using System;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.json;

public partial class lib_ajax_XuatNhapSanPham_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var logged = Security.IsAuthenticated();
        var Id = Request["Id"];
        var IdNull = string.IsNullOrEmpty(Id);

        var Ma = Request["Ma"];
        var PDV_ID = Request["PDV_ID"];
        var PXNSP_ID = Request["PXNSP_ID"];
        var HH_ID = Request["HH_ID"];
        var PXNSPCT_ID = Request["PXNSPCT_ID"];
        var NgayLap = Request["NgayLap"];
        var TrangThai = Request["TrangThai"];
        var NgayXuat = Request["NgayXuat"];
        var NgayNhapDuKien = Request["NgayNhapDuKien"];
        var NguoiXuat = Request["NguoiXuat"];
        var NgayNhap = Request["NgayNhap"];
        var NguoiNhap = Request["NguoiNhap"];
        var ThuKho = Request["ThuKho"];
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
                    var item = PhieuXuatNhapSanPhamDal.SelectById(DAL.con(), new Guid(Id));
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


                    if (!string.IsNullOrEmpty(Ma))
                    {
                        item.Ma = Convert.ToInt32(Ma);                        
                    }
                    if (!string.IsNullOrEmpty(TrangThai))
                    {
                        item.TrangThai = Convert.ToInt32(TrangThai);
                    }
                    if (!string.IsNullOrEmpty(PDV_ID))
                    {
                        item.PDV_ID = new Guid(PDV_ID);
                    }


                    if (!string.IsNullOrEmpty(NgayLap))
                    {
                        item.NgayLap = Convert.ToDateTime(NgayLap, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NgayXuat))
                    {
                        item.NgayXuat = Convert.ToDateTime(NgayXuat, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NgayNhapDuKien))
                    {
                        item.NgayNhapDuKien = Convert.ToDateTime(NgayNhapDuKien, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(NgayNhap))
                    {
                        item.NgayNhap = Convert.ToDateTime(NgayNhap, new CultureInfo("vi-vn"));
                    }

                    item.NgayCapNhat = DateTime.Now;

                    if(IdNull)
                    {
                        item.ID = new Guid(Id);
                        item.NgayTao = DateTime.Now;
                        item.NguoiTao = Security.UserId;
                    }
                    item.NgayCapNhat = DateTime.Now;

                    if (IdNull)
                    {
                        item = PhieuXuatNhapSanPhamDal.Insert(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} thêm mới phiếu xuất sản phẩm/ phiếu dịch vụ: {0}", item.MaStr,
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
                        item = PhieuXuatNhapSanPhamDal.Update(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} sửa phiếu xuất sản phẩm/ phiếu dịch vụ: {0}", item.MaStr,
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
            case "saveCt":
                #region save Goi dich vu chi tiet
                if (!string.IsNullOrEmpty(PXNSP_ID) && !string.IsNullOrEmpty(HH_ID))
                {
                    var hh = HangHoaDal.SelectById(new Guid(HH_ID));

                    var item = new PhieuXuatNhapSanPhamChiTiet();
                    item.ID = Guid.NewGuid();
                    item.HH_ID = hh.ID;
                    item.PXNSP_ID = new Guid(PXNSP_ID);
                    item.SoLuong = 1;
                    item.NgayCapNhat = DateTime.Now;
                    item.NgayTao = DateTime.Now;
                    item.NguoiTao = Security.UserId;
                    item = PhieuXuatNhapSanPhamChiTietDal.Insert(item);
                    ItemEdit.Item = item;
                    ItemEdit.Visible = true;
                }
                break;
                #endregion
            case "updateCt":
                #region update Goi dich vu chi tiet
                if (!string.IsNullOrEmpty(PXNSPCT_ID))
                {
                    var SoLuong = Request["SoLuong"];
                    var DaXuat = Request["DaXuat"];
                    var DaNhap = Request["DaNhap"];
                    DaXuat = !string.IsNullOrEmpty(DaXuat) ? "true" : "false";
                    DaNhap = !string.IsNullOrEmpty(DaNhap) ? "true" : "false";

                    var item = PhieuXuatNhapSanPhamChiTietDal.SelectById(new Guid(PXNSPCT_ID));
                    if(!string.IsNullOrEmpty(SoLuong))
                    {
                        item.SoLuong = Convert.ToInt32(SoLuong);
                    }
                    item.DaXuat = Convert.ToBoolean(DaXuat);
                    item.DaNhap = Convert.ToBoolean(DaNhap);
                    item.NgayCapNhat = DateTime.Now;
                    item = PhieuXuatNhapSanPhamChiTietDal.Update(item);
                    rendertext(item.ID.ToString());
                }
                break;
                #endregion
            case "remove":
                #region Xóa phiếu xuất nhập/ phiếu dịch vụ
                if (logged && !IdNull)
                {
                    var item = PhieuXuatNhapSanPhamDal.SelectById(DAL.con(), new Guid(Id));
                    if (item.NguoiTao == Security.UserId)
                    {
                        PhieuXuatNhapSanPhamDal.DeleteById(new Guid(Id));
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} xóa phiếu xuất sản phẩm/ phiếu dịch vụ: {0}", item.MaStr,
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
            case "removeCt":
                #region Xóa Goi dich vu chi tiet
                if (logged && !string.IsNullOrEmpty(Id))
                {
                    var item = PhieuXuatNhapSanPhamChiTietDal.SelectById(new Guid(Id));
                    if (item.NguoiTao == Security.UserId)
                    {
                        PhieuXuatNhapSanPhamChiTietDal.DeleteById(new Guid(Id));
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} xóa sản phẩm xuất nhập chi tiết {0}", item.HH_Ten,
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
                var list = PhieuXuatNhapSanPhamDal.SelectAll();
                rendertext(JavaScriptConvert.SerializeObject(list), "text/javascript");
                break;
                #endregion
            default: break;
        }
    }
}
using System;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.json;

public partial class lib_ajax_PhieuDichVu_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var logged = Security.IsAuthenticated();
        var Id = Request["Id"];
        var IdNull = string.IsNullOrEmpty(Id);
        var Ma = Request["Ma"];
        var KH_ID = Request["KH_ID"];
        var GDV_ID = Request["GDV_ID"];
        var TongTien = Request["TongTien"];
        var ChietKhau = Request["ChietKhau"];
        var DatCoc = Request["DatCoc"];
        var ThanhToan = Request["ThanhToan"];
        var ConNo = Request["ConNo"];
        var TuVanVien = Request["TuVanVien"];
        var NgayTuVan = Request["NgayTuVan"];
        var CHUP_NhanVien = Request["CHUP_NhanVien"];
        var CHUP_NgayBatDau = Request["CHUP_NgayBatDau"];
        var CHUP_NgayKetThuc = Request["CHUP_NgayKetThuc"];
        var CHUP_DiaDiem = Request["CHUP_DiaDiem"];
        var CHUP_LoaiAlbum = Request["CHUP_LoaiAlbum"];
        var CHUP_YeuCauKhach = Request["CHUP_YeuCauKhach"];
        var CHUP_DaChuyenAnh = Request["CHUP_DaChuyenAnh"];
        var CHUP_NgayChuyenAnh = Request["CHUP_NgayChuyenAnh"];
        var TD_NhanVien = Request["TD_NhanVien"];
        var TD_NgayBatDau = Request["TD_NgayBatDau"];
        var TD_NgayKetThuc = Request["TD_NgayKetThuc"];
        var TOC_NhanVien = Request["TOC_NhanVien"];
        var TOC_NgayBatDau = Request["TOC_NgayBatDau"];
        var TOC_NgayKetThuc = Request["TOC_NgayKetThuc"];
        var TD_DiaDiem = Request["TD_DiaDiem"];
        var TD_KhoangCach = Request["TD_KhoangCach"];
        var TD_PhiDiLai = Request["TD_PhiDiLai"];
        var TD_KhoanPhaiThu = Request["TD_KhoanPhaiThu"];
        var PTS_NhanVien = Request["PTS_NhanVien"];
        var PTS_NhanVienDaNhan = Request["PTS_NhanVienDaNhan"];
        var PTS_NgayXemMaket = Request["PTS_NgayXemMaket"];
        var PTS_NgayBatDau = Request["PTS_NgayBatDau"];
        var PTS_NgayKetThuc = Request["PTS_NgayKetThuc"];
        var PTS_YeuCauKhachHang = Request["PTS_YeuCauKhachHang"];
        var PTS_HenSanPham = Request["PTS_HenSanPham"];
        var PTS_DaCoSanPham = Request["PTS_DaCoSanPham"];
        var PTS_NgayCoSanPham = Request["PTS_NgayCoSanPham"];
        var PTS_NgayLaySanPham = Request["PTS_NgayLaySanPham"];
        var PTS_AnhPhong = Request["PTS_AnhPhong"];
        var PTS_AnhPhongGhiChu = Request["PTS_AnhPhongGhiChu"];
        var PTS_AnhBan = Request["PTS_AnhBan"];
        var PTS_AnhBanGhiChu = Request["PTS_AnhBanGhiChu"];
        var PTS_AnhBanQuyCach = Request["PTS_AnhBanQuyCach"];
        var PTS_AnhBia = Request["PTS_AnhBia"];
        var PTS_CD3D = Request["PTS_CD3D"];
        var HoanThanh = Request["HoanThanh"];
        var Voucher = Request["Voucher"];
        var Voucher_Ma = Request["Voucher_Ma"];
        var NguoiTao = Request["NguoiTao"];
        var NguoiCapNhat = Request["NguoiCapNhat"];
        var NgayTao = Request["NgayTao"];
        var NgayCapNhat = Request["NgayCapNhat"];
        var Xoa = Request["Xoa"];
        var TrangThai = Request["TrangThai"];
        var Huy = Request["Huy"];
        var LyDoHuy = Request["LyDoHuy"];
        var NgayHuy = Request["NgayHuy"];
        var NhanVienHuy = Request["NhanVienHuy"];

        var DuyetEkip = Request["DuyetEkip"];
        var DeNghiDuyetEkip = Request["DeNghiDuyetEkip"];
        
        var CHUP_NgayBatDau_Gio = Request["CHUP_NgayBatDau_Gio"];
        var CHUP_NgayKetThuc_Gio = Request["CHUP_NgayKetThuc_Gio"];
        var TD_NgayBatDau_Gio = Request["TD_NgayBatDau_Gio"];
        var TD_NgayKetThuc_Gio = Request["TD_NgayKetThuc_Gio"];
        var TOC_NgayBatDau_Gio = Request["TOC_NgayBatDau_Gio"];
        var TOC_NgayKetThuc_Gio = Request["TOC_NgayKetThuc_Gio"];
        var PTS_NgayBatDau_Gio = Request["PTS_NgayBatDau_Gio"];
        var PTS_NgayKetThuc_Gio = Request["PTS_NgayKetThuc_Gio"];
        
        
        CHUP_DaChuyenAnh = string.IsNullOrEmpty(CHUP_DaChuyenAnh) ? "false" : "true";
        PTS_NhanVienDaNhan = string.IsNullOrEmpty(PTS_NhanVienDaNhan) ? "false" : "true";
        PTS_CD3D = string.IsNullOrEmpty(PTS_CD3D) ? "false" : "true";
        PTS_DaCoSanPham = string.IsNullOrEmpty(PTS_DaCoSanPham) ? "false" : "true";
        Huy = string.IsNullOrEmpty(Huy) ? "false" : "true";
        HoanThanh = string.IsNullOrEmpty(HoanThanh) ? "false" : "true";
        DuyetEkip = string.IsNullOrEmpty(DuyetEkip) ? "false" : "true";

        var refUrl = Request["refUrl"];
        if (!string.IsNullOrEmpty(refUrl))
            refUrl = Server.UrlDecode(refUrl);
        var q = Request["q"];

        switch (subAct)
        {
            case "save":
                #region Thêm phiếu dịch vụ

                if (Security.IsAuthenticated())
                {
                    var item = PhieuDichVuDal.SelectById(DAL.con(),new Guid(Id));
                    IdNull = item.ID == Guid.Empty;
                    item.ID=new Guid(Id);
                    if (IdNull)
                    {
                        item = new PhieuDichVu
                                   {
                                       ID = new Guid(Id),
                                       NgayTao = DateTime.Now,
                                       NguoiTao = Security.UserId                                       
                                   };
                    }
                    item.NguoiCapNhat = Security.UserId;
                    item.NgayCapNhat = DateTime.Now;

                    if (Convert.ToBoolean(DuyetEkip))
                    {
                        if(!item.DuyetEkip)
                        {
                            item.NgayDuyetEkip = DateTime.Now;
                            item.NguoiDuyet = Security.UserId;    
                        }
                    }
                    if (!string.IsNullOrEmpty(DeNghiDuyetEkip))
                    {
                        item.DuyetEkip = Convert.ToBoolean(DuyetEkip);                        
                    }
                    if (!string.IsNullOrEmpty(Ma))
                    {
                        item.Ma = Convert.ToInt32(Ma);
                    }
                    if (!string.IsNullOrEmpty(KH_ID))
                    {
                        item.KH_ID = new Guid(KH_ID);
                    }
                    if (!string.IsNullOrEmpty(NgayTuVan))
                    {
                        item.NgayTuVan = Convert.ToDateTime(NgayTuVan, new CultureInfo("vi-vn"));
                    }

                    if (!string.IsNullOrEmpty(TuVanVien))
                    {
                        item.TuVanVien = Convert.ToInt32(TuVanVien);
                    }
                    if (!string.IsNullOrEmpty(GDV_ID))
                    {
                        item.GDV_ID = new Guid(GDV_ID);
                    }

                    // Chup anh
                    if (!string.IsNullOrEmpty(CHUP_NhanVien))
                    {
                        item.CHUP_NhanVien = Convert.ToInt32(CHUP_NhanVien);
                    }

                    if (!string.IsNullOrEmpty(CHUP_NgayBatDau) && !string.IsNullOrEmpty(CHUP_NgayBatDau_Gio))
                    {
                        item.CHUP_NgayBatDau = Convert.ToDateTime(string.Format("{0} {1}", CHUP_NgayBatDau, CHUP_NgayBatDau_Gio), new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(CHUP_NgayBatDau) && !string.IsNullOrEmpty(CHUP_NgayKetThuc_Gio))
                    {
                        item.CHUP_NgayKetThuc = Convert.ToDateTime(string.Format("{0} {1}", CHUP_NgayBatDau, CHUP_NgayKetThuc_Gio), new CultureInfo("vi-vn"));
                    }
                    item.CHUP_DiaDiem = CHUP_DiaDiem;
                    item.CHUP_LoaiAlbum = CHUP_LoaiAlbum;
                    item.CHUP_YeuCauKhach = CHUP_YeuCauKhach;
                    item.CHUP_DaChuyenAnh = Convert.ToBoolean(CHUP_DaChuyenAnh);
                    item.Huy = Convert.ToBoolean(Huy);
                    // Trang diem
                    if (!string.IsNullOrEmpty(TD_NhanVien))
                    {
                        item.TD_NhanVien = Convert.ToInt32(TD_NhanVien);
                    }
                    if (!string.IsNullOrEmpty(TD_NgayBatDau) && !string.IsNullOrEmpty(TD_NgayBatDau_Gio))
                    {
                        item.TD_NgayBatDau = Convert.ToDateTime(string.Format("{0} {1}", TD_NgayBatDau, TD_NgayBatDau_Gio), new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(TD_NgayBatDau) && !string.IsNullOrEmpty(TD_NgayKetThuc_Gio))
                    {
                        item.TD_NgayKetThuc = Convert.ToDateTime(string.Format("{0} {1}", TD_NgayBatDau, TD_NgayKetThuc_Gio), new CultureInfo("vi-vn"));
                    }
                    item.TD_DiaDiem = TD_DiaDiem;
                    if (!string.IsNullOrEmpty(TD_KhoangCach))
                    {
                        item.TD_KhoangCach = Convert.ToInt32(TD_KhoangCach);
                    }
                    if (!string.IsNullOrEmpty(TD_PhiDiLai))
                    {
                        item.TD_PhiDiLai = Convert.ToDouble(TD_PhiDiLai);
                    }
                    if (!string.IsNullOrEmpty(TD_KhoanPhaiThu))
                    {
                        item.TD_KhoanPhaiThu = Convert.ToDouble(TD_KhoanPhaiThu);
                    }

                    // Toc
                    if (!string.IsNullOrEmpty(TOC_NhanVien))
                    {
                        item.TOC_NhanVien = Convert.ToInt32(TOC_NhanVien);
                    }
                    if (!string.IsNullOrEmpty(TOC_NgayBatDau) && !string.IsNullOrEmpty(TOC_NgayBatDau_Gio))
                    {
                        item.TOC_NgayBatDau = Convert.ToDateTime(string.Format("{0} {1}", TOC_NgayBatDau, TOC_NgayBatDau_Gio), new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(TOC_NgayBatDau) && !string.IsNullOrEmpty(TOC_NgayKetThuc_Gio))
                    {
                        item.TOC_NgayKetThuc = Convert.ToDateTime(string.Format("{0} {1}", TOC_NgayBatDau, TOC_NgayKetThuc_Gio), new CultureInfo("vi-vn"));
                    }

                    // Photoshop
                    if (!string.IsNullOrEmpty(PTS_NhanVien))
                    {
                        item.PTS_NhanVien = Convert.ToInt32(PTS_NhanVien);
                    }
                    if (!string.IsNullOrEmpty(PTS_NgayBatDau))
                    {
                        item.PTS_NgayBatDau = Convert.ToDateTime(PTS_NgayBatDau, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(PTS_NgayLaySanPham))
                    {
                        item.PTS_NgayLaySanPham = Convert.ToDateTime(PTS_NgayLaySanPham, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(PTS_NgayKetThuc))
                    {
                        item.PTS_NgayKetThuc = Convert.ToDateTime(PTS_NgayKetThuc, new CultureInfo("vi-vn"));
                    }

                    item.PTS_NhanVienDaNhan = Convert.ToBoolean(PTS_NhanVienDaNhan);

                    if (!string.IsNullOrEmpty(PTS_NgayXemMaket))
                    {
                        item.PTS_NgayXemMaket = Convert.ToDateTime(PTS_NgayXemMaket, new CultureInfo("vi-vn"));
                    }
                    item.PTS_YeuCauKhachHang = PTS_YeuCauKhachHang;
                    item.PTS_AnhBia = PTS_AnhBia;
                    item.PTS_AnhPhong = PTS_AnhPhong;
                    item.PTS_AnhPhongGhiChu = PTS_AnhPhongGhiChu;
                    item.PTS_AnhBan = PTS_AnhBan;
                    item.PTS_AnhBanQuyCach = PTS_AnhBanQuyCach;
                    item.PTS_AnhBanGhiChu = PTS_AnhBanGhiChu;
                    item.PTS_CD3D = Convert.ToBoolean(PTS_CD3D);
                    item.HoanThanh = Convert.ToBoolean(HoanThanh);

                    if (!string.IsNullOrEmpty(PTS_HenSanPham))
                    {
                        item.PTS_HenSanPham = Convert.ToDateTime(PTS_HenSanPham, new CultureInfo("vi-vn"));
                    }
                    if (!string.IsNullOrEmpty(PTS_NgayCoSanPham))
                    {
                        item.PTS_NgayCoSanPham = Convert.ToDateTime(PTS_NgayCoSanPham, new CultureInfo("vi-vn"));
                    }
                    item.PTS_DaCoSanPham = Convert.ToBoolean(PTS_DaCoSanPham);

                    if(!string.IsNullOrEmpty(TongTien))
                    {
                        item.TongTien = Convert.ToDouble(TongTien);
                    }
                    if (!string.IsNullOrEmpty(DatCoc))
                    {
                        item.DatCoc = Convert.ToDouble(DatCoc);
                    }
                    if (!string.IsNullOrEmpty(ConNo))
                    {
                        item.ConNo = Convert.ToDouble(ConNo);
                    }

                    // Huy + Trang Thai
                    if(!string.IsNullOrEmpty(TrangThai))
                    {
                        item.TrangThai = Convert.ToInt32(TrangThai);
                    }
                    if (!string.IsNullOrEmpty(NgayHuy))
                    {
                        item.NgayHuy = Convert.ToDateTime(NgayHuy, new CultureInfo("vi-vn"));
                    }
                    item.LyDoHuy = LyDoHuy;
                    if(!string.IsNullOrEmpty(NhanVienHuy))
                    {
                        item.NhanVienHuy = Convert.ToInt32(NhanVienHuy);
                    }


                    if (IdNull)
                    {
                        item = PhieuDichVuDal.Insert(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} thêm mới phiếu dịch vụ: {0}", item.MaStr,
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
                        item = PhieuDichVuDal.Update(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} sửa phiếu dịch vụ: {0}", item.MaStr,
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
                    //SearchManager.Add(Ten, item.IndexNoiDung, item.IndexContent, Ten, item.ID.ToString(), item.Url, typeof(SuKien).Name);
                    TimKiemDal.Add(item, item.ID);
                    rendertext(item.ID.ToString());
                }
                break;

                #endregion
            case "remove":
                #region Xóa phiếu dịch vụ

                if (logged)
                {
                    var item = PhieuDichVuDal.SelectById(DAL.con(),new Guid(Id));
                    if (item.NguoiTao != 0)
                    {
                        item.Xoa = true;
                        item.NgayCapNhat = DateTime.Now;
                        item.NguoiCapNhat = Security.UserId;
                        PhieuDichVuDal.Update(item);
                        //SearchManager.Remove(Id);
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} xóa phiếu dịch vụ: {0}", item.MaStr,
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
            case "removeAdm":
                #region Xóa phiếu dịch vụ

                if (Security.IsAuthenticated())
                {
                    var item = PhieuDichVuDal.SelectById(DAL.con(), new Guid(Id));
                    if (item.NguoiTao == Security.UserId)
                    {
                        item.XoaAdm = true;
                        item.NgayCapNhat = DateTime.Now;
                        item.NguoiCapNhat = Security.UserId;
                        PhieuDichVuDal.Update(item);
                        //SearchManager.Remove(Id);
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} xóa phiếu dịch vụ: {0}", item.MaStr,
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
            case "restore":
                #region khôi phục phiếu dịch vụ

                if (Security.IsAuthenticated())
                {
                    var item = PhieuDichVuDal.SelectById(DAL.con(), new Guid(Id));
                    if (item.NguoiTao == Security.UserId)
                    {
                        item.Xoa = false;
                        item.XoaAdm = false;
                        item.NgayCapNhat = DateTime.Now;
                        item.NguoiCapNhat = Security.UserId;
                        PhieuDichVuDal.Update(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} khôi phục phiếu dịch vụ: {0}", item.MaStr,
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
                            Ten = "Khôi phục"
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
                var pg = PhieuDichVuDal.pagerNormal(DAL.con(), null, false, "PDV_Ma desc", q, 20, null);
                rendertext(JavaScriptConvert.SerializeObject(pg.List), "text/javascript");
                break;
                #endregion
            default: break;
        }
    }
}
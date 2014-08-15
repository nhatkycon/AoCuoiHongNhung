using System;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.json;

public partial class lib_ajax_PhieuBaoHong_Default : basePage
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

        var Ma = Request["Ma"];
        var HH_ID = Request["HH_ID"];
        var NgayBaoHong = Request["NgayBaoHong"];
        var LYDO_ID = Request["LYDO_ID"];
        var MoTa = Request["MoTa"];
        var NhanVien = Request["NhanVien"];
        var Duyet = Request["Duyet"];
        var NguoiDuyet = Request["NguoiDuyet"];
        var Tien = Request["Tien"];
        var NgayDuyet = Request["NgayDuyet"];
        Duyet = string.IsNullOrEmpty(Duyet) ? "false" : "true";
        switch (subAct)
        {
            case "save":
                #region Thêm khách hàng
                if (logged)
                {
                    var item = PhieuBaoHongDal.SelectById(DAL.con(), new Guid(Id));
                    IdNull = item.ID == Guid.Empty;
                    if (!string.IsNullOrEmpty(NguoiDuyet))
                    {
                        item.NguoiDuyet = Convert.ToInt32(NguoiDuyet);
                    }
                    if (!string.IsNullOrEmpty(NhanVien))
                    {
                        item.NhanVien = Convert.ToInt32(NhanVien);
                    }
                    if (!string.IsNullOrEmpty(LYDO_ID))
                    {
                        item.LYDO_ID = new Guid(LYDO_ID);
                    }
                    if (!string.IsNullOrEmpty(HH_ID))
                    {
                        item.HH_ID = new Guid(HH_ID);
                    }
                    if (!string.IsNullOrEmpty(Tien))
                    {
                        item.Tien = Convert.ToDouble(Tien);
                    }
                    item.MoTa = MoTa;
                    
                    if (!string.IsNullOrEmpty(Ma))
                    {
                        item.Ma = Convert.ToInt32(Ma);
                    }

                    if(Convert.ToBoolean(Duyet))
                    {
                        if(!item.Duyet)
                        {
                            item.NgayDuyet = DateTime.Now;
                            item.NguoiDuyet = Convert.ToInt32(Security.UserId);
                            var hh = HangHoaDal.SelectById(item.HH_ID);
                            hh.HongVay = true;
                            hh.NgayCapNhat = DateTime.Now;
                            hh.NguoiCapNhat = Security.UserId;
                            HangHoaDal.Update(hh);
                        }
                        
                    }


                    item.Duyet = Convert.ToBoolean(Duyet);

                    if (!string.IsNullOrEmpty(NgayBaoHong))
                    {
                        item.NgayBaoHong = Convert.ToDateTime(NgayBaoHong, new CultureInfo("vi-vn"));
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
                        item = PhieuBaoHongDal.Insert(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} thêm mới phiếu báo hỏng: {0}", item.MaStr,
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
                        item = PhieuBaoHongDal.Update(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} sửa phiếu báo hỏng: {0}", item.MaStr,
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
                    var item = PhieuBaoHongDal.SelectById(DAL.con(), new Guid(Id));
                    if (item.NguoiTao == Security.UserId)
                    {
                        PhieuBaoHongDal.DeleteById(new Guid(Id));
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} xóa phiếu báo hỏng: {0}", item.MaStr,
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
                var pg = PhieuBaoHongDal.pagerNormal(null, false, "PBH_Ma desc", q, 10);
                rendertext(JavaScriptConvert.SerializeObject(pg.List), "text/javascript");
                break;
                #endregion
            default: break;
        }


    }
}

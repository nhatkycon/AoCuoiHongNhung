using System;
using System.Globalization;
using docsoft;
using docsoft.entities;
using linh.core;
using linh.core.dal;

public partial class lib_ajax_ThuChi_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var NDTC_ID = Request["NDTC_ID"];
        var CQ_ID = Request["CQ_ID"];
        var MaPhieu = Request["MaPhieu"];
        var SoPhieu = Request["SoPhieu"];
        var SoPhieuAll = Request["SoPhieuAll"];
        var SoTien = Request["SoTien"];
        var Mota = Request["Mota"];
        var NgayTrenPhieu = Request["NgayTrenPhieu"];
        var NgayTao = Request["NgayTao"];
        var NguoiTao = Request["NguoiTao"];
        var NgayCapNhat = Request["NgayCapNhat"];
        var NguoiCapNhat = Request["NguoiCapNhat"];
        var LoaiQuy = Request["LoaiQuy"];
        var LoaiCandoi = Request["LoaiCandoi"];
        var isCandoi = Request["isCandoi"];
        var Thu = Request["Thu"];
        var XN_ID = Request["XN_ID"];
        var P_ID = Request["P_ID"];
        var PDV_ID = Request["PDV_ID"];

        var logged = Security.IsAuthenticated();
        var Id = Request["ID"];
        var IdNull = string.IsNullOrEmpty(Id);

        var refUrl = Request["refUrl"];
        if (!string.IsNullOrEmpty(refUrl))
            refUrl = Server.UrlDecode(refUrl);

        switch (subAct)
        {
            case "save":
                #region Thêm Thu chi

                if (logged)
                {
                    var item = ThuChiDal.SelectById(new Guid(Id));
                    IdNull = item.ID == Guid.Empty;

                    if (IdNull)
                    {
                        item = new ThuChi { ID = new Guid(Id), NgayTao = DateTime.Now, NguoiTao = Security.UserId, NguoiCapNhat = Security.UserId, NgayCapNhat = DateTime.Now };
                    }
                    else
                    {
                        item.NgayCapNhat = DateTime.Now;
                        item.NguoiCapNhat = Security.UserId;

                    }
                    item.isCandoi = false;
                    if(!string.IsNullOrEmpty(LoaiQuy))
                    {
                        item.LoaiQuy = Convert.ToInt32(LoaiQuy);
                    }
                    if (!string.IsNullOrEmpty(NgayTrenPhieu))
                    {
                        item.NgayTrenPhieu = Convert.ToDateTime(NgayTrenPhieu, new CultureInfo("vi-vn"));
                    }
                    if(!string.IsNullOrEmpty(SoTien))
                    {
                        item.SoTien = Convert.ToDouble(SoTien);
                    }
                    if (!string.IsNullOrEmpty(P_ID))
                    {
                        item.P_ID = new Guid(P_ID);
                    }
                    if (!string.IsNullOrEmpty(PDV_ID))
                    {
                        item.PDV_ID = new Guid(PDV_ID);
                        var pdv = PhieuDichVuDal.SelectById(DAL.con(), item.PDV_ID);
                        item.P_ID = pdv.KH_ID;
                    }
                    
                    if (!string.IsNullOrEmpty(NDTC_ID))
                    {
                        item.NDTC_ID = new Guid(NDTC_ID);
                    }
                    if (!string.IsNullOrEmpty(SoPhieu))
                    {
                        item.SoPhieu = Convert.ToInt32(SoPhieu);
                    }
                    item.Thu = Convert.ToBoolean(Thu);

                    item.Mota = Mota;

                    if (IdNull)
                    {
                        item = ThuChiDal.Insert(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} thêm mới phiếu thu: {0}", item.Ma,
                                              Security.Username)
                            ,
                            NgayTao = DateTime.Now
                            ,
                            Username = Security.Username
                            ,
                            PRowId = item.ID
                            ,
                            PTen = item.Ma
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
                        item = ThuChiDal.Update(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} sửa phiếu thu: {0}", item.Ma,
                                              Security.Username)
                            ,
                            NgayTao = DateTime.Now
                            ,
                            Username = Security.Username
                            ,
                            PRowId = item.ID
                            ,
                            PTen = item.Ma
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
                #region Xóa

                if (Security.IsAuthenticated())
                {
                    var item = ThuChiDal.SelectById(new Guid(Id));
                    if (item.NguoiTao == Security.UserId)
                    {
                        ThuChiDal.DeleteById(new Guid(Id));
                        //SearchManager.Remove(Id);
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} xóa thu: {0}", item.Ma,
                                              Security.Username)
                            ,
                            NgayTao = DateTime.Now
                            ,
                            Username = Security.Username
                            ,
                            PRowId = item.ID
                            ,
                            PTen = item.Ma
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
using System;
using System.Collections.Generic;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.json;


public partial class lib_ajax_PhieuDichVuDichVu_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var logged = Security.IsAuthenticated();
        var Id = Request["Id"];
        var PDVDV_Id = Request["PDVDV_Id"];
        var IdNull = string.IsNullOrEmpty(Id);

        var PDV_ID = Request["PDV_ID"];
        var GDV_ID = Request["GDV_ID"];
        var HH_ID = Request["HH_ID"];
        var ThuTu = Request["ThuTu"];
        var Ten = Request["Ten"];
        var MoTa = Request["MoTa"];
        var Gia = Request["Gia"];
        var SoLuong = Request["SoLuong"];
        var Tien = Request["Tien"];
        var PDVDV_NhanVien = Request["PDVDV_NhanVien"];

        var refUrl = Request["refUrl"];
        if (!string.IsNullOrEmpty(refUrl))
            refUrl = Server.UrlDecode(refUrl);

        switch (subAct)
        {
            case "save":
                #region save Goi dich vu chi tiet
                if (!string.IsNullOrEmpty(PDV_ID) && !string.IsNullOrEmpty(HH_ID))
                {
                    var hh = HangHoaDal.SelectById(new Guid(HH_ID));

                    var item = new PhieuDichVuDichVu();
                    item.ID = Guid.NewGuid();

                    item.HH_ID = hh.ID;
                    item.PDV_ID = new Guid(PDV_ID);
                    item.MoTa = string.Empty;
                    item.Gia = hh.GNY;
                    item.SoLuong = 1;
                    item.Tien = item.Gia * item.SoLuong;
                    item.NgayCapNhat = DateTime.Now;
                    item.NgayTao = DateTime.Now;
                    item.NguoiTao = Security.UserId;
                    item.DichVuThem = true;
                    item = PhieuDichVuDichVuDal.Insert(item);
                    if (!string.IsNullOrEmpty(PDVDV_NhanVien))
                    {
                        item.NhanVien = Convert.ToInt32(PDVDV_NhanVien);                        
                    }else
                    {
                        item.NhanVien = Security.UserId;
                    }
                    ItemEdit.Item = item;
                    ItemEdit.Visible = true;
                }
                break;
                #endregion
            case "saveByGoiDichVu":
                #region save all goi dich vu
                if (!string.IsNullOrEmpty(PDV_ID) && !string.IsNullOrEmpty(GDV_ID))
                {
                     var listDichVu = new List<PhieuDichVuDichVu>();
                    using(var con = DAL.con())
                    {
                        var listDichVuTheoDoi = GoiDichVuChiTietDal.SelectByGDV(con, GDV_ID);

                        foreach (var itemDv in listDichVuTheoDoi)
                        {
                            var item = new PhieuDichVuDichVu();
                            item.ID = Guid.NewGuid();

                            item.HH_ID = itemDv.HH_ID;
                            item.PDV_ID = new Guid(PDV_ID);
                            item.MoTa = string.Empty;
                            item.Gia = itemDv.Gia;
                            item.SoLuong = itemDv.SoLuong;
                            item.Tien = item.Gia * item.SoLuong;
                            item.NgayCapNhat = DateTime.Now;
                            item.ThuTu = itemDv.ThuTu;
                            item.NgayTao = DateTime.Now;
                            item.NguoiTao = Security.UserId;
                            item.DichVuThem = false;
                            item.NhanVien = Security.UserId;
                            item = PhieuDichVuDichVuDal.Insert(item);
                            listDichVu.Add(item);
                        }
                    
                    }
                    ListAjaxResult.List = listDichVu;
                    ListAjaxResult.Visible = true;
                }
                break;
                #endregion
            case "update":
                #region update Goi dich vu chi tiet
                if (!string.IsNullOrEmpty(PDVDV_Id))
                {

                    var item = PhieuDichVuDichVuDal.SelectById(new Guid(PDVDV_Id));
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
                    if (!string.IsNullOrEmpty(PDVDV_NhanVien))
                    {
                        item.NhanVien = Convert.ToInt32(PDVDV_NhanVien);
                    }
                    item.MoTa = MoTa;
                    item.Tien = item.Gia * item.SoLuong;
                    item.NgayCapNhat = DateTime.Now;
                    item = PhieuDichVuDichVuDal.Update(item);
                    rendertext(item.ID.ToString());
                }
                break;
                #endregion
            case "remove":
                #region Xóa Goi dich vu chi tiet
                if (logged && !IdNull)
                {
                    var item = PhieuDichVuDichVuDal.SelectById(new Guid(Id));
                    if (item.NguoiTao == Security.UserId)
                    {
                        PhieuDichVuDichVuDal.DeleteById(new Guid(Id));
                        TimKiemDal.DeleteByPRowId(DAL.con(), item.ID);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{1} xóa gói dịch vụ trong phiếu dịch vụ {0}", item.PDV_Ma,
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
            default: break;
        }
    }
}
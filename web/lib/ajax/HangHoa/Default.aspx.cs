using System;
using docsoft;
using docsoft.entities;
using linh.core.dal;
using linh.json;

public partial class lib_ajax_HangHoa_Default : basePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var logged = Security.IsAuthenticated();
        var Id = Request["Id"];
        var IdNull = string.IsNullOrEmpty(Id);

        var DM_ID = Request["DM_ID"];
        var Ma = Request["Ma"];
        var Ten = Request["Ten"];
        var MoTa = Request["MoTa"];
        var GNY = Request["GNY"];
        var GiaMin = Request["GiaMin"];
        var GiaMax = Request["GiaMax"];
        var Anh = Request["Anh"];
        var DichVu = Request["DichVu"];
        var KhoVay = Request["KhoVay"];
        var HetHang = Request["HetHang"];
        var HongVay = Request["HongVay"];
        var refUrl = Request["refUrl"];
        var q = Request["q"];
        if (!string.IsNullOrEmpty(refUrl))
            refUrl = Server.UrlDecode(refUrl);

        DichVu = !string.IsNullOrEmpty(DichVu) ? "true" : "false";
        KhoVay = !string.IsNullOrEmpty(KhoVay) ? "true" : "false";
        HetHang = !string.IsNullOrEmpty(HetHang) ? "true" : "false";
        HongVay = !string.IsNullOrEmpty(HongVay) ? "true" : "false";

        switch (subAct)
        {
            case "save":
                #region Thêm khách hàng
                if (logged)
                {
                    var item = IdNull ? new HangHoa() : HangHoaDal.SelectById(new Guid(Id));
                    item.Ten = Ten;
                    item.Ma = Ma;
                    item.Anh = Anh;
                    item.MoTa = MoTa;
                    item.NguoiCapNhat = Security.UserId;
                    item.NgayCapNhat = DateTime.Now;
                    if (!string.IsNullOrEmpty(GNY))
                    {
                        item.GNY = Convert.ToDouble(GNY);
                    }
                    if (!string.IsNullOrEmpty(GiaMin))
                    {
                        item.GiaMin = Convert.ToDouble(GiaMin);
                    }
                    if (!string.IsNullOrEmpty(GiaMax))
                    {
                        item.GiaMax = Convert.ToDouble(GiaMax);
                    }
                    if (!string.IsNullOrEmpty(DM_ID))
                    {
                        item.DM_ID = new Guid(DM_ID);
                    }
                    item.KhoVay = Convert.ToBoolean(KhoVay);
                    item.DichVu = Convert.ToBoolean(DichVu);
                    item.HetHang = Convert.ToBoolean(HetHang);
                    item.HongVay = Convert.ToBoolean(HongVay);
                    if (IdNull)
                    {
                        item.NgayTao = DateTime.Now;
                        item.NguoiTao = Security.UserId;
                        item.ID = Guid.NewGuid();
                        item = HangHoaDal.Insert(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{2} thêm mới hàng hóa {1}-{0}", item.Ten, item.Ma,
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
                        item = HangHoaDal.Update(item);
                        #region log
                        LogDal.log(item, new Log()
                        {
                            Checked = false
                            ,
                            Info =
                                string.Format("{2} sửa hàng hóa {1}-{0}", item.Ten, item.Ma,
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
            case "remove":
                #region Xóa khách hàng
                if (logged && !IdNull)
                {
                    var item = HangHoaDal.SelectById(new Guid(Id));
                    if (item.NguoiTao == Security.UserId)
                    {
                        HangHoaDal.DeleteById(new Guid(Id));
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
                var pg = HangHoaDal.ByDm(null, false, "HH_NgayTao desc", q, 20, null);
                rendertext(JavaScriptConvert.SerializeObject(pg.List), "text/javascript");
                break;
                #endregion
            default: break;
        }
    }
}
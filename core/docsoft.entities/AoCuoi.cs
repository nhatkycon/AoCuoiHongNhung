using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.common;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
namespace docsoft.entities
{
    #region BaiHat
    #region BO
    public class BaiHat : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid PDV_ID { get; set; }
        public Int32 STT { get; set; }
        public String Ten { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 NguoiTao { get; set; }
        #endregion
        #region Contructor
        public BaiHat()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return BaiHatDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class BaiHatCollection : BaseEntityCollection<BaiHat>
    { }
    #endregion
    #region Dal
    public class BaiHatDal
    {
        #region Methods

        public static void DeleteById(Guid BH_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BH_ID", BH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_BaiHat_Delete_DeleteById_linhnx", obj);
        }

        public static BaiHat Insert(BaiHat item)
        {
            var Item = new BaiHat();
            var obj = new SqlParameter[7];
            obj[0] = new SqlParameter("BH_ID", item.ID);
            obj[1] = new SqlParameter("BH_PDV_ID", item.PDV_ID);
            obj[2] = new SqlParameter("BH_STT", item.STT);
            obj[3] = new SqlParameter("BH_Ten", item.Ten);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("BH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("BH_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("BH_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[5] = new SqlParameter("BH_NgayCapNhat", DBNull.Value);
            }
            obj[6] = new SqlParameter("BH_NguoiTao", item.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_BaiHat_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BaiHat Update(BaiHat item)
        {
            var Item = new BaiHat();
            var obj = new SqlParameter[7];
            obj[0] = new SqlParameter("BH_ID", item.ID);
            obj[1] = new SqlParameter("BH_PDV_ID", item.PDV_ID);
            obj[2] = new SqlParameter("BH_STT", item.STT);
            obj[3] = new SqlParameter("BH_Ten", item.Ten);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("BH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[4] = new SqlParameter("BH_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("BH_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[5] = new SqlParameter("BH_NgayCapNhat", DBNull.Value);
            }
            obj[6] = new SqlParameter("BH_NguoiTao", item.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_BaiHat_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BaiHat SelectById(Guid BH_ID)
        {
            var Item = new BaiHat();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("BH_ID", BH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_BaiHat_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static BaiHatCollection SelectAll()
        {
            var List = new BaiHatCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_BaiHat_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<BaiHat> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<BaiHat>("sp_tblAoCuoi_BaiHat_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static BaiHat getFromReader(IDataReader rd)
        {
            var Item = new BaiHat();
            if (rd.FieldExists("BH_ID"))
            {
                Item.ID = (Guid)(rd["BH_ID"]);
            }
            if (rd.FieldExists("BH_PDV_ID"))
            {
                Item.PDV_ID = (Guid)(rd["BH_PDV_ID"]);
            }
            if (rd.FieldExists("BH_STT"))
            {
                Item.STT = (Int32)(rd["BH_STT"]);
            }
            if (rd.FieldExists("BH_Ten"))
            {
                Item.Ten = (String)(rd["BH_Ten"]);
            }
            if (rd.FieldExists("BH_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["BH_NgayTao"]);
            }
            if (rd.FieldExists("BH_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["BH_NgayCapNhat"]);
            }
            if (rd.FieldExists("BH_NguoiTao"))
            {
                Item.NguoiTao = (Int32)(rd["BH_NguoiTao"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static BaiHatCollection SelectByPdvId(SqlConnection con, string PDV_ID)
        {
            var List = new BaiHatCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PDV_ID", PDV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure
                , "sp_tblAoCuoi_BaiHat_Select_SelectByPdvId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion

    #endregion

    #region PhieuBaoHong
    #region BO
    public class PhieuBaoHong : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Int32 Ma { get; set; }
        public Guid HH_ID { get; set; }
        public DateTime NgayBaoHong { get; set; }
        public Guid LYDO_ID { get; set; }
        public String MoTa { get; set; }
        public Int32 NhanVien { get; set; }
        public Boolean Duyet { get; set; }
        public Int32 NguoiDuyet { get; set; }
        public DateTime NgayDuyet { get; set; }
        public DateTime NgayTao { get; set; }
        public Int32 NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 NguoiCapNhat { get; set; }
        public Double Tien { get; set; }
        #endregion
        #region Contructor
        public PhieuBaoHong()
        { }
        #endregion
        #region Customs properties

        public string NguoiTao_Ten { get; set; }
        public string NguoiCapNhat_Ten { get; set; }
        public string NguoiDuyet_Ten { get; set; }
        public string NhanVien_Ten { get; set; }
        public string HH_Ten { get; set; }
        public string LYDO_Ten { get; set; }
        public string Ten
        {
            get { return MaStr; }
        }
        public string Hint
        {
            get { return MaStr; }
        }
        public string MaStr
        {
            get { return Lib.FormatMa(Ma); }
        }
        public string Url
        {
            get { return string.Format("/lib/pages/PhieuBaoHong/Add.aspx?ID={0}", ID); }
        }
        public string UrlPrint
        {
            get { return string.Format("/lib/pages/PhieuBaoHong/Print.aspx?ID={0}", ID); }
        }
        public string UrlView
        {
            get { return string.Format("/lib/pages/PhieuBaoHong/View.aspx?ID={0}", ID); }
        }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return PhieuBaoHongDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class PhieuBaoHongCollection : BaseEntityCollection<PhieuBaoHong>
    { }
    #endregion
    #region Dal
    public class PhieuBaoHongDal
    {
        #region Methods

        public static void DeleteById(Guid PBH_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PBH_ID", PBH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuBaoHong_Delete_DeleteById_linhnx", obj);
        }

        public static PhieuBaoHong Insert(PhieuBaoHong item)
        {
            var Item = new PhieuBaoHong();
            var obj = new SqlParameter[15];
            obj[0] = new SqlParameter("PBH_ID", item.ID);
            obj[1] = new SqlParameter("PBH_Ma", item.Ma);
            obj[2] = new SqlParameter("PBH_HH_ID", item.HH_ID);
            if (item.NgayBaoHong > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("PBH_NgayBaoHong", item.NgayBaoHong);
            }
            else
            {
                obj[3] = new SqlParameter("PBH_NgayBaoHong", DBNull.Value);
            }
            obj[4] = new SqlParameter("PBH_LYDO_ID", item.LYDO_ID);
            obj[5] = new SqlParameter("PBH_MoTa", item.MoTa);
            obj[6] = new SqlParameter("PBH_NhanVien", item.NhanVien);
            obj[7] = new SqlParameter("PBH_Duyet", item.Duyet);
            obj[8] = new SqlParameter("PBH_NguoiDuyet", item.NguoiDuyet);
            if (item.NgayDuyet > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("PBH_NgayDuyet", item.NgayDuyet);
            }
            else
            {
                obj[9] = new SqlParameter("PBH_NgayDuyet", DBNull.Value);
            }
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("PBH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("PBH_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("PBH_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("PBH_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[12] = new SqlParameter("PBH_NgayCapNhat", DBNull.Value);
            }
            obj[13] = new SqlParameter("PBH_NguoiCapNhat", item.NguoiCapNhat);
            obj[14] = new SqlParameter("PBH_Tien", item.Tien);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuBaoHong_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuBaoHong Update(PhieuBaoHong item)
        {
            var Item = new PhieuBaoHong();
            var obj = new SqlParameter[15];
            obj[0] = new SqlParameter("PBH_ID", item.ID);
            obj[1] = new SqlParameter("PBH_Ma", item.Ma);
            obj[2] = new SqlParameter("PBH_HH_ID", item.HH_ID);
            if (item.NgayBaoHong > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("PBH_NgayBaoHong", item.NgayBaoHong);
            }
            else
            {
                obj[3] = new SqlParameter("PBH_NgayBaoHong", DBNull.Value);
            }
            obj[4] = new SqlParameter("PBH_LYDO_ID", item.LYDO_ID);
            obj[5] = new SqlParameter("PBH_MoTa", item.MoTa);
            obj[6] = new SqlParameter("PBH_NhanVien", item.NhanVien);
            obj[7] = new SqlParameter("PBH_Duyet", item.Duyet);
            obj[8] = new SqlParameter("PBH_NguoiDuyet", item.NguoiDuyet);
            if (item.NgayDuyet > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("PBH_NgayDuyet", item.NgayDuyet);
            }
            else
            {
                obj[9] = new SqlParameter("PBH_NgayDuyet", DBNull.Value);
            }
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("PBH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("PBH_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("PBH_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("PBH_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[12] = new SqlParameter("PBH_NgayCapNhat", DBNull.Value);
            }
            obj[13] = new SqlParameter("PBH_NguoiCapNhat", item.NguoiCapNhat);
            obj[14] = new SqlParameter("PBH_Tien", item.Tien);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuBaoHong_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuBaoHong SelectById(SqlConnection con, Guid PBH_ID)
        {
            var Item = new PhieuBaoHong();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PBH_ID", PBH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuBaoHong_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuBaoHongCollection SelectAll()
        {
            var List = new PhieuBaoHongCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuBaoHong_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<PhieuBaoHong> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<PhieuBaoHong>("sp_tblAoCuoi_PhieuBaoHong_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static PhieuBaoHong getFromReader(IDataReader rd)
        {
            var Item = new PhieuBaoHong();
            if (rd.FieldExists("PBH_ID"))
            {
                Item.ID = (Guid)(rd["PBH_ID"]);
            }
            if (rd.FieldExists("PBH_Ma"))
            {
                Item.Ma = (Int32)(rd["PBH_Ma"]);
            }
            if (rd.FieldExists("PBH_HH_ID"))
            {
                Item.HH_ID = (Guid)(rd["PBH_HH_ID"]);
            }
            if (rd.FieldExists("PBH_NgayBaoHong"))
            {
                Item.NgayBaoHong = (DateTime)(rd["PBH_NgayBaoHong"]);
            }
            if (rd.FieldExists("PBH_LYDO_ID"))
            {
                Item.LYDO_ID = (Guid)(rd["PBH_LYDO_ID"]);
            }
            if (rd.FieldExists("PBH_MoTa"))
            {
                Item.MoTa = (String)(rd["PBH_MoTa"]);
            }
            if (rd.FieldExists("PBH_NhanVien"))
            {
                Item.NhanVien = (Int32)(rd["PBH_NhanVien"]);
            }
            if (rd.FieldExists("PBH_Duyet"))
            {
                Item.Duyet = (Boolean)(rd["PBH_Duyet"]);
            }
            if (rd.FieldExists("PBH_NguoiDuyet"))
            {
                Item.NguoiDuyet = (Int32)(rd["PBH_NguoiDuyet"]);
            }
            if (rd.FieldExists("PBH_NgayDuyet"))
            {
                Item.NgayDuyet = (DateTime)(rd["PBH_NgayDuyet"]);
            }
            if (rd.FieldExists("PBH_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["PBH_NgayTao"]);
            }
            if (rd.FieldExists("PBH_NguoiTao"))
            {
                Item.NguoiTao = (Int32)(rd["PBH_NguoiTao"]);
            }
            if (rd.FieldExists("PBH_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["PBH_NgayCapNhat"]);
            }
            if (rd.FieldExists("PBH_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (Int32)(rd["PBH_NguoiCapNhat"]);
            }
            if (rd.FieldExists("PBH_Tien"))
            {
                Item.Tien = (Double)(rd["PBH_Tien"]);
            }

            if (rd.FieldExists("NguoiCapNhat_Ten"))
            {
                Item.NguoiCapNhat_Ten = (String)(rd["NguoiCapNhat_Ten"]);
            }
            if (rd.FieldExists("NguoiDuyet_Ten"))
            {
                Item.NguoiDuyet_Ten = (String)(rd["NguoiDuyet_Ten"]);
            }
            if (rd.FieldExists("NguoiTao_Ten"))
            {
                Item.NguoiTao_Ten = (String)(rd["NguoiTao_Ten"]);
            }
            if (rd.FieldExists("HH_Ten"))
            {
                Item.HH_Ten = (String)(rd["HH_Ten"]);
            }
            if (rd.FieldExists("LYDO_Ten"))
            {
                Item.LYDO_Ten = (String)(rd["LYDO_Ten"]);
            }
            if (rd.FieldExists("NhanVien_Ten"))
            {
                Item.NhanVien_Ten = (String)(rd["NhanVien_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<PhieuBaoHong> pagerDuyet(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string Duyet, string NhanVien)
        {
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Duyet))
            {
                obj[2] = new SqlParameter("Duyet", Duyet);
            }
            else
            {
                obj[2] = new SqlParameter("Duyet", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NhanVien))
            {
                obj[3] = new SqlParameter("NhanVien", NhanVien);
            }
            else
            {
                obj[3] = new SqlParameter("NhanVien", DBNull.Value);
            }
            var pg = new Pager<PhieuBaoHong>(con, "sp_tblAoCuoi_PhieuBaoHong_Pager_Duyet_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static PhieuBaoHong SelectDraff(SqlConnection con)
        {
            var Item = new PhieuBaoHong();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuBaoHong_Select_SelectDraff_linhnx"))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static PhieuBaoHongCollection SelectTopByHhId(SqlConnection con, int Top, string HH_ID)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("HH_ID", HH_ID);
            var List = new PhieuBaoHongCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuBaoHong_Select_SelectTopByHhId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion

    #endregion

    #region ChoThueVay
    #region BO
    public class ChoThueVay : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid KH_ID { get; set; }
        public Int32 Ma { get; set; }
        public Double Tong { get; set; }
        public Double DatCong { get; set; }
        public Double ThanhToan { get; set; }
        public Double ConNo { get; set; }
        public DateTime Ngay { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public DateTime NgayTraVayThucTe { get; set; }
        public Int32 ThuKho { get; set; }
        public Int32 NguoiXuat { get; set; }
        public Int32 NguoiNhap { get; set; }
        public Int32 NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public Int32 NguoiCapNhat { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 TrangThai { get; set; }
        public String GiayTo { get; set; }
        public Boolean DaTraGiayTo { get; set; }
        #endregion
        #region Contructor
        public ChoThueVay()
        { }
        #endregion
        #region Customs properties
        public string Ten
        {
            get { return MaStr; }
        }
        public string Hint
        {
            get { return MaStr; }
        }
        public string NguoiTao_Ten { get; set; }
        public string NguoiCapNhat_Ten { get; set; }
        public string ThuKho_Ten { get; set; }
        public string NguoiXuat_Ten { get; set; }
        public string NguoiNhap_Ten { get; set; }
        public string KH_Ten { get; set; }
        public Double X_ConNo { get; set; }
        public Double X_ThanhToan { get; set; }
        public string MaStr
        {
            get { return Lib.FormatMa(Ma); }
        }
        public string Url
        {
            get { return string.Format("/lib/pages/ChoThueVay/Add.aspx?ID={0}", ID); }
        }
        public string UrlPrint
        {
            get { return string.Format("/lib/pages/ChoThueVay/Print.aspx?ID={0}", ID); }
        }
        public string UrlView
        {
            get { return string.Format("/lib/pages/ChoThueVay/View.aspx?ID={0}", ID); }
        }
        public string TrangThai_Ten
        {
            get
            {
                switch (TrangThai)
                {
                    case 0:
                        return string.Empty;
                        break;
                    case 1:
                        return "Mới lập";
                        break;
                    case 2:
                        return "Đã xuất";
                        break;
                    case 3:
                        return "Đã nhập";
                        break;
                    case 4:
                        return "Quá hạn";
                        break;
                    default:
                        return string.Empty;
                        break;
                }
            }
        }

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ChoThueVayDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ChoThueVayCollection : BaseEntityCollection<ChoThueVay>
    { }
    #endregion
    #region Dal
    public class ChoThueVayDal
    {
        #region Methods

        public static void DeleteById(Guid CTV_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CTV_ID", CTV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_ChoThueVay_Delete_DeleteById_linhnx", obj);
        }

        public static ChoThueVay Insert(ChoThueVay item)
        {
            var Item = new ChoThueVay();
            var obj = new SqlParameter[21];
            obj[0] = new SqlParameter("CTV_ID", item.ID);
            obj[1] = new SqlParameter("CTV_KH_ID", item.KH_ID);
            obj[2] = new SqlParameter("CTV_Ma", item.Ma);
            obj[3] = new SqlParameter("CTV_Tong", item.Tong);
            obj[4] = new SqlParameter("CTV_DatCong", item.DatCong);
            obj[5] = new SqlParameter("CTV_ThanhToan", item.ThanhToan);
            obj[6] = new SqlParameter("CTV_ConNo", item.ConNo);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("CTV_Ngay", item.Ngay);
            }
            else
            {
                obj[7] = new SqlParameter("CTV_Ngay", DBNull.Value);
            }
            if (item.NgayBatDau > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("CTV_NgayBatDau", item.NgayBatDau);
            }
            else
            {
                obj[8] = new SqlParameter("CTV_NgayBatDau", DBNull.Value);
            }
            if (item.NgayKetThuc > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("CTV_NgayKetThuc", item.NgayKetThuc);
            }
            else
            {
                obj[9] = new SqlParameter("CTV_NgayKetThuc", DBNull.Value);
            }
            if (item.NgayTraVayThucTe > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("CTV_NgayTraVayThucTe", item.NgayTraVayThucTe);
            }
            else
            {
                obj[10] = new SqlParameter("CTV_NgayTraVayThucTe", DBNull.Value);
            }
            obj[11] = new SqlParameter("CTV_ThuKho", item.ThuKho);
            obj[12] = new SqlParameter("CTV_NguoiXuat", item.NguoiXuat);
            obj[13] = new SqlParameter("CTV_NguoiNhap", item.NguoiNhap);
            obj[14] = new SqlParameter("CTV_NguoiTao", item.NguoiTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[15] = new SqlParameter("CTV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[15] = new SqlParameter("CTV_NgayTao", DBNull.Value);
            }
            obj[16] = new SqlParameter("CTV_NguoiCapNhat", item.NguoiCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[17] = new SqlParameter("CTV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[17] = new SqlParameter("CTV_NgayCapNhat", DBNull.Value);
            }
            obj[18] = new SqlParameter("CTV_TrangThai", item.TrangThai);
            obj[19] = new SqlParameter("CTV_GiayTo", item.GiayTo);
            obj[20] = new SqlParameter("CTV_DaTraGiayTo", item.DaTraGiayTo);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_ChoThueVay_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ChoThueVay Update(ChoThueVay item)
        {
            var Item = new ChoThueVay();
            var obj = new SqlParameter[21];
            obj[0] = new SqlParameter("CTV_ID", item.ID);
            obj[1] = new SqlParameter("CTV_KH_ID", item.KH_ID);
            obj[2] = new SqlParameter("CTV_Ma", item.Ma);
            obj[3] = new SqlParameter("CTV_Tong", item.Tong);
            obj[4] = new SqlParameter("CTV_DatCong", item.DatCong);
            obj[5] = new SqlParameter("CTV_ThanhToan", item.ThanhToan);
            obj[6] = new SqlParameter("CTV_ConNo", item.ConNo);
            if (item.Ngay > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("CTV_Ngay", item.Ngay);
            }
            else
            {
                obj[7] = new SqlParameter("CTV_Ngay", DBNull.Value);
            }
            if (item.NgayBatDau > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("CTV_NgayBatDau", item.NgayBatDau);
            }
            else
            {
                obj[8] = new SqlParameter("CTV_NgayBatDau", DBNull.Value);
            }
            if (item.NgayKetThuc > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("CTV_NgayKetThuc", item.NgayKetThuc);
            }
            else
            {
                obj[9] = new SqlParameter("CTV_NgayKetThuc", DBNull.Value);
            }
            if (item.NgayTraVayThucTe > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("CTV_NgayTraVayThucTe", item.NgayTraVayThucTe);
            }
            else
            {
                obj[10] = new SqlParameter("CTV_NgayTraVayThucTe", DBNull.Value);
            }
            obj[11] = new SqlParameter("CTV_ThuKho", item.ThuKho);
            obj[12] = new SqlParameter("CTV_NguoiXuat", item.NguoiXuat);
            obj[13] = new SqlParameter("CTV_NguoiNhap", item.NguoiNhap);
            obj[14] = new SqlParameter("CTV_NguoiTao", item.NguoiTao);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[15] = new SqlParameter("CTV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[15] = new SqlParameter("CTV_NgayTao", DBNull.Value);
            }
            obj[16] = new SqlParameter("CTV_NguoiCapNhat", item.NguoiCapNhat);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[17] = new SqlParameter("CTV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[17] = new SqlParameter("CTV_NgayCapNhat", DBNull.Value);
            }
            obj[18] = new SqlParameter("CTV_TrangThai", item.TrangThai);
            obj[19] = new SqlParameter("CTV_GiayTo", item.GiayTo);
            obj[20] = new SqlParameter("CTV_DaTraGiayTo", item.DaTraGiayTo);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_ChoThueVay_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ChoThueVay SelectById(SqlConnection con, Guid CTV_ID)
        {
            var Item = new ChoThueVay();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("CTV_ID", CTV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_ChoThueVay_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ChoThueVayCollection SelectAll()
        {
            var List = new ChoThueVayCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_ChoThueVay_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<ChoThueVay> pagerNormal(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string TrangThai, string NhanVien)
        {
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TrangThai))
            {
                obj[2] = new SqlParameter("TrangThai", TrangThai);
            }
            else
            {
                obj[2] = new SqlParameter("TrangThai", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NhanVien))
            {
                obj[3] = new SqlParameter("NhanVien", NhanVien);
            }
            else
            {
                obj[3] = new SqlParameter("NhanVien", DBNull.Value);
            }
            var pg = new Pager<ChoThueVay>(con, "sp_tblAoCuoi_ChoThueVay_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static ChoThueVay getFromReader(IDataReader rd)
        {
            var Item = new ChoThueVay();
            if (rd.FieldExists("CTV_ID"))
            {
                Item.ID = (Guid)(rd["CTV_ID"]);
            }
            if (rd.FieldExists("CTV_KH_ID"))
            {
                Item.KH_ID = (Guid)(rd["CTV_KH_ID"]);
            }
            if (rd.FieldExists("CTV_Ma"))
            {
                Item.Ma = (Int32)(rd["CTV_Ma"]);
            }
            if (rd.FieldExists("CTV_Tong"))
            {
                Item.Tong = (Double)(rd["CTV_Tong"]);
            }
            if (rd.FieldExists("CTV_DatCong"))
            {
                Item.DatCong = (Double)(rd["CTV_DatCong"]);
            }
            if (rd.FieldExists("CTV_ThanhToan"))
            {
                Item.ThanhToan = (Double)(rd["CTV_ThanhToan"]);
            }
            if (rd.FieldExists("CTV_ConNo"))
            {
                Item.ConNo = (Double)(rd["CTV_ConNo"]);
            }
            if (rd.FieldExists("CTV_Ngay"))
            {
                Item.Ngay = (DateTime)(rd["CTV_Ngay"]);
            }
            if (rd.FieldExists("CTV_NgayBatDau"))
            {
                Item.NgayBatDau = (DateTime)(rd["CTV_NgayBatDau"]);
            }
            if (rd.FieldExists("CTV_NgayKetThuc"))
            {
                Item.NgayKetThuc = (DateTime)(rd["CTV_NgayKetThuc"]);
            }
            if (rd.FieldExists("CTV_NgayTraVayThucTe"))
            {
                Item.NgayTraVayThucTe = (DateTime)(rd["CTV_NgayTraVayThucTe"]);
            }
            if (rd.FieldExists("CTV_ThuKho"))
            {
                Item.ThuKho = (Int32)(rd["CTV_ThuKho"]);
            }
            if (rd.FieldExists("CTV_NguoiXuat"))
            {
                Item.NguoiXuat = (Int32)(rd["CTV_NguoiXuat"]);
            }
            if (rd.FieldExists("CTV_NguoiNhap"))
            {
                Item.NguoiNhap = (Int32)(rd["CTV_NguoiNhap"]);
            }
            if (rd.FieldExists("CTV_NguoiTao"))
            {
                Item.NguoiTao = (Int32)(rd["CTV_NguoiTao"]);
            }
            if (rd.FieldExists("CTV_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["CTV_NgayTao"]);
            }
            if (rd.FieldExists("CTV_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (Int32)(rd["CTV_NguoiCapNhat"]);
            }
            if (rd.FieldExists("CTV_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["CTV_NgayCapNhat"]);
            }
            if (rd.FieldExists("CTV_TrangThai"))
            {
                Item.TrangThai = (Int32)(rd["CTV_TrangThai"]);
            }
            if (rd.FieldExists("CTV_GiayTo"))
            {
                Item.GiayTo = (String)(rd["CTV_GiayTo"]);
            }
            if (rd.FieldExists("CTV_DaTraGiayTo"))
            {
                Item.DaTraGiayTo = (Boolean)(rd["CTV_DaTraGiayTo"]);
            }

            if (rd.FieldExists("NguoiTao_Ten"))
            {
                Item.NguoiTao_Ten = (String)(rd["NguoiTao_Ten"]);
            }
            if (rd.FieldExists("NguoiCapNhat_Ten"))
            {
                Item.NguoiCapNhat_Ten = (String)(rd["NguoiCapNhat_Ten"]);
            }
            if (rd.FieldExists("ThuKho_Ten"))
            {
                Item.ThuKho_Ten = (String)(rd["ThuKho_Ten"]);
            }
            if (rd.FieldExists("NguoiXuat_Ten"))
            {
                Item.NguoiXuat_Ten = (String)(rd["NguoiXuat_Ten"]);
            }
            if (rd.FieldExists("NguoiNhap_Ten"))
            {
                Item.NguoiNhap_Ten = (String)(rd["NguoiNhap_Ten"]);
            }
            if (rd.FieldExists("KH_Ten"))
            {
                Item.KH_Ten = (String)(rd["KH_Ten"]);
                if(!string.IsNullOrEmpty(Item.KH_Ten) && Item.KH_ID != Guid.Empty)
                {
                    Item.KH_Ten = maHoa.DecryptString(Item.KH_Ten, Item.KH_ID.ToString());
                }
            }

            if (rd.FieldExists("X_ThanhToan"))
            {
                Item.X_ThanhToan = (Double)(rd["X_ThanhToan"]);
            }
            if (rd.FieldExists("X_ConNo"))
            {
                Item.X_ConNo = (Double)(rd["X_ConNo"]);
            }

            return Item;
        }
        #endregion

        #region Extend
        public static ChoThueVay SelectDraff(SqlConnection con)
        {
            var Item = new ChoThueVay();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_ChoThueVay_Select_SelectDraff_linhnx"))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static ChoThueVayCollection SelectTopByHhId(SqlConnection con, int Top, string HH_ID)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("HH_ID", HH_ID);
            var List = new ChoThueVayCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_ChoThueVay_Select_SelectTopByHhId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion

    #endregion

    #region PhieuGiatVay
    #region BO

    public class PhieuGiatVay : BaseEntity
    {
        #region Properties

        public Guid ID { get; set; }
        public Guid CH_ID { get; set; }
        public Int32 Ma { get; set; }
        public Double Tien { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public Int32 NguoiXuat { get; set; }
        public Int32 NguoiNhap { get; set; }
        public DateTime NgayTao { get; set; }
        public Int32 NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 NguoiCapNhat { get; set; }
        public Int32 TrangThai { get; set; }

        #endregion

        #region Contructor

        public PhieuGiatVay()
        {
        }

        #endregion

        #region Customs properties
        public string Ten
        {
            get { return MaStr; }
        }
        public string Hint
        {
            get { return MaStr; }
        }
        public string Url
        {
            get { return string.Format("/lib/pages/GiatLa/Add.aspx?ID={0}", ID); }
        }
        public string UrlPrint
        {
            get { return string.Format("/lib/pages/GiatLa/Print.aspx?ID={0}", ID); }
        }
        public string UrlView
        {
            get { return string.Format("/lib/pages/GiatLa/View.aspx?ID={0}", ID); }
        }
        public string CH_Ten { get; set; }
        public string NguoiXuat_Ten { get; set; }
        public string NguoiNhap_Ten { get; set; }
        public string NguoiTao_Ten { get; set; }
        public string NguoiCapNhat_Ten { get; set; }
        public string MaStr {
            get { return Lib.FormatMa(Ma); }
        }
        public string TrangThai_Ten
        {
            get
            {
                switch (TrangThai)
                {
                    case 0:
                        return string.Empty;
                        break;
                    case 1:
                        return "Mới lập";
                        break;
                    case 2:
                        return "Đã xuất";
                        break;
                    case 3:
                        return "Đã nhập";
                        break;
                    case 4:
                        return "Quá hạn";
                        break;
                    default:
                        return string.Empty;
                        break;
                }
            }
        }
    #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return PhieuGiatVayDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class PhieuGiatVayCollection : BaseEntityCollection<PhieuGiatVay>
    { }
    #endregion
    #region Dal
    public class PhieuGiatVayDal
    {
        #region Methods

        public static void DeleteById(Guid PGV_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PGV_ID", PGV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuGiatVay_Delete_DeleteById_linhnx", obj);
        }

        public static PhieuGiatVay Insert(PhieuGiatVay item)
        {
            var Item = new PhieuGiatVay();
            var obj = new SqlParameter[13];
            obj[0] = new SqlParameter("PGV_ID", item.ID);
            obj[1] = new SqlParameter("PGV_CH_ID", item.CH_ID);
            obj[2] = new SqlParameter("PGV_Ma", item.Ma);
            obj[3] = new SqlParameter("PGV_Tien", item.Tien);
            if (item.NgayBatDau > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("PGV_NgayBatDau", item.NgayBatDau);
            }
            else
            {
                obj[4] = new SqlParameter("PGV_NgayBatDau", DBNull.Value);
            }
            if (item.NgayKetThuc > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("PGV_NgayKetThuc", item.NgayKetThuc);
            }
            else
            {
                obj[5] = new SqlParameter("PGV_NgayKetThuc", DBNull.Value);
            }
            obj[6] = new SqlParameter("PGV_NguoiXuat", item.NguoiXuat);
            obj[7] = new SqlParameter("PGV_NguoiNhap", item.NguoiNhap);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("PGV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[8] = new SqlParameter("PGV_NgayTao", DBNull.Value);
            }
            obj[9] = new SqlParameter("PGV_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("PGV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[10] = new SqlParameter("PGV_NgayCapNhat", DBNull.Value);
            }
            obj[11] = new SqlParameter("PGV_NguoiCapNhat", item.NguoiCapNhat);
            obj[12] = new SqlParameter("PGV_TrangThai", item.TrangThai);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuGiatVay_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuGiatVay Update(PhieuGiatVay item)
        {
            var Item = new PhieuGiatVay();
            var obj = new SqlParameter[13];
            obj[0] = new SqlParameter("PGV_ID", item.ID);
            obj[1] = new SqlParameter("PGV_CH_ID", item.CH_ID);
            obj[2] = new SqlParameter("PGV_Ma", item.Ma);
            obj[3] = new SqlParameter("PGV_Tien", item.Tien);
            if (item.NgayBatDau > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("PGV_NgayBatDau", item.NgayBatDau);
            }
            else
            {
                obj[4] = new SqlParameter("PGV_NgayBatDau", DBNull.Value);
            }
            if (item.NgayKetThuc > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("PGV_NgayKetThuc", item.NgayKetThuc);
            }
            else
            {
                obj[5] = new SqlParameter("PGV_NgayKetThuc", DBNull.Value);
            }
            obj[6] = new SqlParameter("PGV_NguoiXuat", item.NguoiXuat);
            obj[7] = new SqlParameter("PGV_NguoiNhap", item.NguoiNhap);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("PGV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[8] = new SqlParameter("PGV_NgayTao", DBNull.Value);
            }
            obj[9] = new SqlParameter("PGV_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("PGV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[10] = new SqlParameter("PGV_NgayCapNhat", DBNull.Value);
            }
            obj[11] = new SqlParameter("PGV_NguoiCapNhat", item.NguoiCapNhat);
            obj[12] = new SqlParameter("PGV_TrangThai", item.TrangThai);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuGiatVay_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuGiatVay SelectById(Guid PGV_ID)
        {
            return SelectById(DAL.con(),PGV_ID);
        }
        public static PhieuGiatVay SelectById(SqlConnection con, Guid PGV_ID)
        {
            var Item = new PhieuGiatVay();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PGV_ID", PGV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuGiatVay_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static PhieuGiatVayCollection SelectAll()
        {
            var List = new PhieuGiatVayCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuGiatVay_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<PhieuGiatVay> pagerNormal(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string TrangThai, string NhanVien, string CH_ID)
        {
            var obj = new SqlParameter[5];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TrangThai))
            {
                obj[2] = new SqlParameter("TrangThai", TrangThai);
            }
            else
            {
                obj[2] = new SqlParameter("TrangThai", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NhanVien))
            {
                obj[3] = new SqlParameter("NhanVien", NhanVien);
            }
            else
            {
                obj[3] = new SqlParameter("NhanVien", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(CH_ID))
            {
                obj[4] = new SqlParameter("CH_ID", CH_ID);
            }
            else
            {
                obj[4] = new SqlParameter("CH_ID", DBNull.Value);
            }
            var pg = new Pager<PhieuGiatVay>(con, "sp_tblAoCuoi_PhieuGiatVay_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static PhieuGiatVay getFromReader(IDataReader rd)
        {
            var Item = new PhieuGiatVay();
            if (rd.FieldExists("PGV_ID"))
            {
                Item.ID = (Guid)(rd["PGV_ID"]);
            }
            if (rd.FieldExists("PGV_CH_ID"))
            {
                Item.CH_ID = (Guid)(rd["PGV_CH_ID"]);
            }
            if (rd.FieldExists("PGV_Ma"))
            {
                Item.Ma = (Int32)(rd["PGV_Ma"]);
            }
            if (rd.FieldExists("PGV_Tien"))
            {
                Item.Tien = (Double)(rd["PGV_Tien"]);
            }
            if (rd.FieldExists("PGV_NgayBatDau"))
            {
                Item.NgayBatDau = (DateTime)(rd["PGV_NgayBatDau"]);
            }
            if (rd.FieldExists("PGV_NgayKetThuc"))
            {
                Item.NgayKetThuc = (DateTime)(rd["PGV_NgayKetThuc"]);
            }
            if (rd.FieldExists("PGV_NguoiXuat"))
            {
                Item.NguoiXuat = (Int32)(rd["PGV_NguoiXuat"]);
            }
            if (rd.FieldExists("PGV_NguoiNhap"))
            {
                Item.NguoiNhap = (Int32)(rd["PGV_NguoiNhap"]);
            }
            if (rd.FieldExists("PGV_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["PGV_NgayTao"]);
            }
            if (rd.FieldExists("PGV_NguoiTao"))
            {
                Item.NguoiTao = (Int32)(rd["PGV_NguoiTao"]);
            }
            if (rd.FieldExists("PGV_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["PGV_NgayCapNhat"]);
            }
            if (rd.FieldExists("PGV_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (Int32)(rd["PGV_NguoiCapNhat"]);
            }
            if (rd.FieldExists("PGV_TrangThai"))
            {
                Item.TrangThai = (Int32)(rd["PGV_TrangThai"]);
            }

            if (rd.FieldExists("NguoiCapNhat_Ten"))
            {
                Item.NguoiCapNhat_Ten = (String)(rd["NguoiCapNhat_Ten"]);
            }
            if (rd.FieldExists("NguoiTao_Ten"))
            {
                Item.NguoiTao_Ten = (String)(rd["NguoiTao_Ten"]);
            }
            if (rd.FieldExists("CH_Ten"))
            {
                Item.CH_Ten = (String)(rd["CH_Ten"]);
            }
            if (rd.FieldExists("NguoiNhap_Ten"))
            {
                Item.NguoiNhap_Ten = (String)(rd["NguoiNhap_Ten"]);
            }
            if (rd.FieldExists("NguoiXuat_Ten"))
            {
                Item.NguoiXuat_Ten = (String)(rd["NguoiXuat_Ten"]);
            }

            return Item;
        }
        #endregion

        #region Extend
        public static PhieuGiatVay SelectDraff(SqlConnection con)
        {
            var Item = new PhieuGiatVay();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuGiatVay_Select_SelectDraff_linhnx"))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static PhieuGiatVayCollection SelectTopByHhId(SqlConnection con, int Top, string HH_ID)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("HH_ID", HH_ID);
            var List = new PhieuGiatVayCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuGiatVay_Select_SelectTopByHhId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion

    #endregion

    #region DuyetAnh
    #region BO
    public class DuyetAnh : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid PDV_ID { get; set; }
        public String Ten { get; set; }
        public Int32 ThuTu { get; set; }
        public String GhiChu { get; set; }
        public DateTime NgayTao { get; set; }
        public Int32 NhanVien { get; set; }
        #endregion
        #region Contructor
        public DuyetAnh()
        { }
        #endregion
        #region Customs properties

        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return DuyetAnhDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class DuyetAnhCollection : BaseEntityCollection<DuyetAnh>
    { }
    #endregion
    #region Dal
    public class DuyetAnhDal
    {
        #region Methods

        public static void DeleteById(Guid DUYETANH_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DUYETANH_ID", DUYETANH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_DuyetAnh_Delete_DeleteById_linhnx", obj);
        }

        public static DuyetAnh Insert(DuyetAnh item)
        {
            var Item = new DuyetAnh();
            var obj = new SqlParameter[7];
            obj[0] = new SqlParameter("DUYETANH_ID", item.ID);
            obj[1] = new SqlParameter("DUYETANH_PDV_ID", item.PDV_ID);
            obj[2] = new SqlParameter("DUYETANH_Ten", item.Ten);
            obj[3] = new SqlParameter("DUYETANH_ThuTu", item.ThuTu);
            obj[4] = new SqlParameter("DUYETANH_GhiChu", item.GhiChu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("DUYETANH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("DUYETANH_NgayTao", DBNull.Value);
            }
            obj[6] = new SqlParameter("DUYETANH_NhanVien", item.NhanVien);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_DuyetAnh_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DuyetAnh Update(DuyetAnh item)
        {
            var Item = new DuyetAnh();
            var obj = new SqlParameter[7];
            obj[0] = new SqlParameter("DUYETANH_ID", item.ID);
            obj[1] = new SqlParameter("DUYETANH_PDV_ID", item.PDV_ID);
            obj[2] = new SqlParameter("DUYETANH_Ten", item.Ten);
            obj[3] = new SqlParameter("DUYETANH_ThuTu", item.ThuTu);
            obj[4] = new SqlParameter("DUYETANH_GhiChu", item.GhiChu);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("DUYETANH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[5] = new SqlParameter("DUYETANH_NgayTao", DBNull.Value);
            }
            obj[6] = new SqlParameter("DUYETANH_NhanVien", item.NhanVien);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_DuyetAnh_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DuyetAnh SelectById(Guid DUYETANH_ID)
        {
            var Item = new DuyetAnh();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("DUYETANH_ID", DUYETANH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_DuyetAnh_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static DuyetAnhCollection SelectAll()
        {
            var List = new DuyetAnhCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_DuyetAnh_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<DuyetAnh> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<DuyetAnh>("sp_tblAoCuoi_DuyetAnh_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static DuyetAnh getFromReader(IDataReader rd)
        {
            var Item = new DuyetAnh();
            if (rd.FieldExists("DUYETANH_ID"))
            {
                Item.ID = (Guid)(rd["DUYETANH_ID"]);
            }
            if (rd.FieldExists("DUYETANH_PDV_ID"))
            {
                Item.PDV_ID = (Guid)(rd["DUYETANH_PDV_ID"]);
            }
            if (rd.FieldExists("DUYETANH_Ten"))
            {
                Item.Ten = (String)(rd["DUYETANH_Ten"]);
            }
            if (rd.FieldExists("DUYETANH_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["DUYETANH_ThuTu"]);
            }
            if (rd.FieldExists("DUYETANH_GhiChu"))
            {
                Item.GhiChu = (String)(rd["DUYETANH_GhiChu"]);
            }
            if (rd.FieldExists("DUYETANH_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["DUYETANH_NgayTao"]);
            }
            if (rd.FieldExists("DUYETANH_NhanVien"))
            {
                Item.NhanVien = (Int32)(rd["DUYETANH_NhanVien"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static DuyetAnhCollection SelectByPdvId(SqlConnection con, string PDV_ID)
        {
            var List = new DuyetAnhCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PDV_ID", PDV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure
                , "sp_tblAoCuoi_DuyetAnh_Select_SelectByPdvId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion

    #endregion

    #region GoiDichVu
    #region BO
    public class GoiDichVu : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Int32 ThuTu { get; set; }
        public String Ma { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public Double GNY { get; set; }
        public Double GiaMax { get; set; }
        public Double GiaMin { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 NguoiTao { get; set; }
        #endregion
        #region Contructor
        public GoiDichVu()
        { }
        #endregion
        #region Customs properties
        public string Hint
        {
            get { return string.Format("{0} {1} {2}", Ten, Ma, MoTa); }

        }

        public string NguoiTao_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return GoiDichVuDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class GoiDichVuCollection : BaseEntityCollection<GoiDichVu>
    { }
    #endregion
    #region Dal
    public class GoiDichVuDal
    {
        #region Methods

        public static void DeleteById(Guid GDV_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GDV_ID", GDV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_GoiDichVu_Delete_DeleteById_linhnx", obj);
        }

        public static GoiDichVu Insert(GoiDichVu item)
        {
            var Item = new GoiDichVu();
            var obj = new SqlParameter[11];
            obj[0] = new SqlParameter("GDV_ID", item.ID);
            obj[1] = new SqlParameter("GDV_ThuTu", item.ThuTu);
            obj[2] = new SqlParameter("GDV_Ma", item.Ma);
            obj[3] = new SqlParameter("GDV_Ten", item.Ten);
            obj[4] = new SqlParameter("GDV_MoTa", item.MoTa);
            obj[5] = new SqlParameter("GDV_GNY", item.GNY);
            obj[6] = new SqlParameter("GDV_GiaMax", item.GiaMax);
            obj[7] = new SqlParameter("GDV_GiaMin", item.GiaMin);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("GDV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[8] = new SqlParameter("GDV_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("GDV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[9] = new SqlParameter("GDV_NgayCapNhat", DBNull.Value);
            }
            obj[10] = new SqlParameter("GDV_NguoiTao", item.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_GoiDichVu_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GoiDichVu Update(GoiDichVu item)
        {
            var Item = new GoiDichVu();
            var obj = new SqlParameter[11];
            obj[0] = new SqlParameter("GDV_ID", item.ID);
            obj[1] = new SqlParameter("GDV_ThuTu", item.ThuTu);
            obj[2] = new SqlParameter("GDV_Ma", item.Ma);
            obj[3] = new SqlParameter("GDV_Ten", item.Ten);
            obj[4] = new SqlParameter("GDV_MoTa", item.MoTa);
            obj[5] = new SqlParameter("GDV_GNY", item.GNY);
            obj[6] = new SqlParameter("GDV_GiaMax", item.GiaMax);
            obj[7] = new SqlParameter("GDV_GiaMin", item.GiaMin);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("GDV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[8] = new SqlParameter("GDV_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("GDV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[9] = new SqlParameter("GDV_NgayCapNhat", DBNull.Value);
            }
            obj[10] = new SqlParameter("GDV_NguoiTao", item.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_GoiDichVu_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GoiDichVu SelectById(Guid GDV_ID)
        {
            var Item = new GoiDichVu();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GDV_ID", GDV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_GoiDichVu_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GoiDichVuCollection SelectAll()
        {
            var List = new GoiDichVuCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_GoiDichVu_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<GoiDichVu> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<GoiDichVu>("sp_tblAoCuoi_GoiDichVu_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static GoiDichVu getFromReader(IDataReader rd)
        {
            var Item = new GoiDichVu();
            if (rd.FieldExists("GDV_ID"))
            {
                Item.ID = (Guid)(rd["GDV_ID"]);
            }
            if (rd.FieldExists("GDV_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["GDV_ThuTu"]);
            }
            if (rd.FieldExists("GDV_Ma"))
            {
                Item.Ma = (String)(rd["GDV_Ma"]);
            }
            if (rd.FieldExists("GDV_Ten"))
            {
                Item.Ten = (String)(rd["GDV_Ten"]);
            }
            if (rd.FieldExists("GDV_MoTa"))
            {
                Item.MoTa = (String)(rd["GDV_MoTa"]);
            }
            if (rd.FieldExists("GDV_GNY"))
            {
                Item.GNY = (Double)(rd["GDV_GNY"]);
            }
            if (rd.FieldExists("GDV_GiaMax"))
            {
                Item.GiaMax = (Double)(rd["GDV_GiaMax"]);
            }
            if (rd.FieldExists("GDV_GiaMin"))
            {
                Item.GiaMin = (Double)(rd["GDV_GiaMin"]);
            }
            if (rd.FieldExists("GDV_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["GDV_NgayTao"]);
            }
            if (rd.FieldExists("GDV_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["GDV_NgayCapNhat"]);
            }
            if (rd.FieldExists("GDV_NguoiTao"))
            {
                Item.NguoiTao = (Int32)(rd["GDV_NguoiTao"]);
            }
            if (rd.FieldExists("NguoiTao_Ten"))
            {
                Item.NguoiTao_Ten = (String)(rd["NguoiTao_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        #endregion
    }
    #endregion

    #endregion

    #region GoiDichVuChiTiet
    #region BO
    public class GoiDichVuChiTiet : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid GDV_ID { get; set; }
        public Guid HH_ID { get; set; }
        public Int32 ThuTu { get; set; }
        public Int32 SoLuong { get; set; }
        public Double Gia { get; set; }
        public Double Tien { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 NguoiTao { get; set; }
        #endregion
        #region Contructor
        public GoiDichVuChiTiet()
        { }
        #endregion
        #region Customs properties

        public string HH_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return GoiDichVuChiTietDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class GoiDichVuChiTietCollection : BaseEntityCollection<GoiDichVuChiTiet>
    { }
    #endregion
    #region Dal
    public class GoiDichVuChiTietDal
    {
        #region Methods

        public static void DeleteById(Guid GDVCT_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GDVCT_ID", GDVCT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_GoiDichVuChiTiet_Delete_DeleteById_linhnx", obj);
        }

        public static GoiDichVuChiTiet Insert(GoiDichVuChiTiet item)
        {
            var Item = new GoiDichVuChiTiet();
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("GDVCT_ID", item.ID);
            obj[1] = new SqlParameter("GDVCT_GDV_ID", item.GDV_ID);
            obj[2] = new SqlParameter("GDVCT_HH_ID", item.HH_ID);
            obj[3] = new SqlParameter("GDVCT_ThuTu", item.ThuTu);
            obj[4] = new SqlParameter("GDVCT_SoLuong", item.SoLuong);
            obj[5] = new SqlParameter("GDVCT_Gia", item.Gia);
            obj[6] = new SqlParameter("GDVCT_Tien", item.Tien);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("GDVCT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("GDVCT_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("GDVCT_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[8] = new SqlParameter("GDVCT_NgayCapNhat", DBNull.Value);
            }
            obj[9] = new SqlParameter("GDVCT_NguoiTao", item.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_GoiDichVuChiTiet_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GoiDichVuChiTiet Update(GoiDichVuChiTiet item)
        {
            var Item = new GoiDichVuChiTiet();
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("GDVCT_ID", item.ID);
            obj[1] = new SqlParameter("GDVCT_GDV_ID", item.GDV_ID);
            obj[2] = new SqlParameter("GDVCT_HH_ID", item.HH_ID);
            obj[3] = new SqlParameter("GDVCT_ThuTu", item.ThuTu);
            obj[4] = new SqlParameter("GDVCT_SoLuong", item.SoLuong);
            obj[5] = new SqlParameter("GDVCT_Gia", item.Gia);
            obj[6] = new SqlParameter("GDVCT_Tien", item.Tien);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("GDVCT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("GDVCT_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("GDVCT_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[8] = new SqlParameter("GDVCT_NgayCapNhat", DBNull.Value);
            }
            obj[9] = new SqlParameter("GDVCT_NguoiTao", item.NguoiTao);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_GoiDichVuChiTiet_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GoiDichVuChiTiet SelectById(Guid GDVCT_ID)
        {
            var Item = new GoiDichVuChiTiet();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GDVCT_ID", GDVCT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_GoiDichVuChiTiet_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static GoiDichVuChiTietCollection SelectAll()
        {
            var List = new GoiDichVuChiTietCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_GoiDichVuChiTiet_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<GoiDichVuChiTiet> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<GoiDichVuChiTiet>("sp_tblAoCuoi_GoiDichVuChiTiet_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static GoiDichVuChiTiet getFromReader(IDataReader rd)
        {
            var Item = new GoiDichVuChiTiet();
            if (rd.FieldExists("GDVCT_ID"))
            {
                Item.ID = (Guid)(rd["GDVCT_ID"]);
            }
            if (rd.FieldExists("GDVCT_GDV_ID"))
            {
                Item.GDV_ID = (Guid)(rd["GDVCT_GDV_ID"]);
            }
            if (rd.FieldExists("GDVCT_HH_ID"))
            {
                Item.HH_ID = (Guid)(rd["GDVCT_HH_ID"]);
            }
            if (rd.FieldExists("GDVCT_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["GDVCT_ThuTu"]);
            }
            if (rd.FieldExists("GDVCT_SoLuong"))
            {
                Item.SoLuong = (Int32)(rd["GDVCT_SoLuong"]);
            }
            if (rd.FieldExists("GDVCT_Gia"))
            {
                Item.Gia = (Double)(rd["GDVCT_Gia"]);
            }
            if (rd.FieldExists("GDVCT_Tien"))
            {
                Item.Tien = (Double)(rd["GDVCT_Tien"]);
            }
            if (rd.FieldExists("GDVCT_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["GDVCT_NgayTao"]);
            }
            if (rd.FieldExists("GDVCT_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["GDVCT_NgayCapNhat"]);
            }
            if (rd.FieldExists("GDVCT_NguoiTao"))
            {
                Item.NguoiTao = (Int32)(rd["GDVCT_NguoiTao"]);
            }
            if (rd.FieldExists("HH_Ten"))
            {
                Item.HH_Ten = (String)(rd["HH_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static GoiDichVuChiTietCollection SelectByGDV(SqlConnection con, string GDV_ID)
        {
            var List = new GoiDichVuChiTietCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("GDV_ID", GDV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_GoiDichVuChiTiet_Select_SelectByGDV_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion

    #endregion

    #region PhieuDichVu
    #region BO
    public class PhieuDichVu : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Int32 Ma { get; set; }
        public Guid KH_ID { get; set; }
        public Guid GDV_ID { get; set; }
        public Double TongTien { get; set; }
        public Double ChietKhau { get; set; }
        public Double DatCoc { get; set; }
        public Double ThanhToan { get; set; }
        public Double ConNo { get; set; }
        public Int32 TuVanVien { get; set; }
        public DateTime NgayTuVan { get; set; }
        public Int32 CHUP_NhanVien { get; set; }
        public DateTime CHUP_NgayBatDau { get; set; }
        public DateTime CHUP_NgayKetThuc { get; set; }
        public String CHUP_DiaDiem { get; set; }
        public String CHUP_LoaiAlbum { get; set; }
        public String CHUP_YeuCauKhach { get; set; }
        public Boolean CHUP_DaChuyenAnh { get; set; }
        public DateTime CHUP_NgayChuyenAnh { get; set; }
        public Int32 TD_NhanVien { get; set; }
        public DateTime TD_NgayBatDau { get; set; }
        public DateTime TD_NgayKetThuc { get; set; }
        public Int32 TOC_NhanVien { get; set; }
        public DateTime TOC_NgayBatDau { get; set; }
        public DateTime TOC_NgayKetThuc { get; set; }
        public Boolean TD_NgoaiCanh { get; set; }
        public String TD_DiaDiem { get; set; }
        public Int32 TD_KhoangCach { get; set; }
        public Double TD_PhiDiLai { get; set; }
        public Double TD_KhoanPhaiThu { get; set; }
        public Int32 PTS_NhanVien { get; set; }
        public Boolean PTS_NhanVienDaNhan { get; set; }
        public DateTime PTS_NgayXemMaket { get; set; }
        public DateTime PTS_NgayBatDau { get; set; }
        public DateTime PTS_NgayKetThuc { get; set; }
        public String PTS_YeuCauKhachHang { get; set; }
        public DateTime PTS_HenSanPham { get; set; }
        public Boolean PTS_DaCoSanPham { get; set; }
        public DateTime PTS_NgayCoSanPham { get; set; }
        public DateTime PTS_NgayLaySanPham { get; set; }
        public String PTS_AnhPhong { get; set; }
        public String PTS_AnhPhongGhiChu { get; set; }
        public String PTS_AnhBan { get; set; }
        public String PTS_AnhBanGhiChu { get; set; }
        public String PTS_AnhBanQuyCach { get; set; }
        public String PTS_AnhBia { get; set; }
        public Boolean PTS_CD3D { get; set; }
        public Boolean HoanThanh { get; set; }
        public Boolean Voucher { get; set; }
        public String Voucher_Ma { get; set; }
        public Int32 NguoiTao { get; set; }
        public Int32 NguoiCapNhat { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Boolean Xoa { get; set; }
        public Int32 TrangThai { get; set; }
        public Boolean Huy { get; set; }
        public String LyDoHuy { get; set; }
        public DateTime NgayHuy { get; set; }
        public Int32 NhanVienHuy { get; set; }
        public Boolean DuyetEkip { get; set; }
        public DateTime NgayDuyetEkip { get; set; }
        public Int32 NguoiDuyet { get; set; }
        public Boolean XoaAdm { get; set; }
        #endregion
        #region Contructor
        public PhieuDichVu()
        { }
        #endregion
        #region Customs properties

        public KhachHang _KhachHang { get; set; }
        public string GDV_Ten { get; set; }
        public string NguoiTao_Ten { get; set; }
        public string NguoiCapNhat_Ten { get; set; }
        public string CHUP_NhanVien_Ten { get; set; }
        public string PTS_NhanVien_Ten { get; set; }
        public string TD_NhanVien_Ten { get; set; }
        public string TOC_NhanVien_Ten { get; set; }
        public string TuVanVien_Ten { get; set; }
        public string NguoiDuyet_Ten { get; set; }
        public string KH_Ten { get; set; }

        public double X_ThanhToan { get; set; }
        public double X_ConNo { get; set; }

        public string Hint
        {
            get { return string.Format("{0}", Ma); }
        }
        public string Ten
        {
            get { return MaStr; }
        }

        public string MaStr
        {
            get { return Lib.FormatMa(Ma); }
        }
        public string TrangThaistr
        {
            get
            {
                switch (TrangThai)
                {                    
                    case 10:
                        return "Mới lập phiếu";
                        break;
                    case 20:
                        return "Chờ chụp ảnh";
                        break;
                    case 30:
                        return "Chụp ảnh";
                        break;
                    case 35:
                        return "Trang điểm cô dâu";
                        break;
                    case 40:
                        return "Đã có ảnh thô";
                        break;
                    case 50:
                        return "Chờ chọn ảnh";
                        break;
                    case 60:
                        return "Đang PTS";
                        break;
                    case 62:
                        return "Xong PTS - chờ duyệt maket";
                        break;
                    case 70:
                        return "Đã duyệt maket";
                        break;
                    case 80:
                        return "Đã có sản phẩm";
                        break;
                    case 90:
                        return "Đã trả sản phẩm";
                        break;
                    case 95:
                        return "Thành công";
                        break;
                    case 100:
                        return "Hủy";
                        break;
                    default:
                        return "";
                        break;
                }
            }
        }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return PhieuDichVuDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class PhieuDichVuCollection : BaseEntityCollection<PhieuDichVu>
    { }
    #endregion
    #region Dal
    public class PhieuDichVuDal
    {
        #region Methods

        public static void DeleteById(Guid PDV_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PDV_ID", PDV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuDichVu_Delete_DeleteById_linhnx", obj);
        }

        public static PhieuDichVu Insert(PhieuDichVu item)
        {
            var Item = new PhieuDichVu();
            var obj = new SqlParameter[64];
            obj[0] = new SqlParameter("PDV_ID", item.ID);
            obj[1] = new SqlParameter("PDV_Ma", item.Ma);
            obj[2] = new SqlParameter("PDV_KH_ID", item.KH_ID);
            obj[3] = new SqlParameter("PDV_GDV_ID", item.GDV_ID);
            obj[4] = new SqlParameter("PDV_TongTien", item.TongTien);
            obj[5] = new SqlParameter("PDV_ChietKhau", item.ChietKhau);
            obj[6] = new SqlParameter("PDV_DatCoc", item.DatCoc);
            obj[7] = new SqlParameter("PDV_ThanhToan", item.ThanhToan);
            obj[8] = new SqlParameter("PDV_ConNo", item.ConNo);
            obj[9] = new SqlParameter("PDV_TuVanVien", item.TuVanVien);
            if (item.NgayTuVan > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("PDV_NgayTuVan", item.NgayTuVan);
            }
            else
            {
                obj[10] = new SqlParameter("PDV_NgayTuVan", DBNull.Value);
            }
            obj[11] = new SqlParameter("PDV_CHUP_NhanVien", item.CHUP_NhanVien);
            if (item.CHUP_NgayBatDau > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("PDV_CHUP_NgayBatDau", item.CHUP_NgayBatDau);
            }
            else
            {
                obj[12] = new SqlParameter("PDV_CHUP_NgayBatDau", DBNull.Value);
            }
            if (item.CHUP_NgayKetThuc > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("PDV_CHUP_NgayKetThuc", item.CHUP_NgayKetThuc);
            }
            else
            {
                obj[13] = new SqlParameter("PDV_CHUP_NgayKetThuc", DBNull.Value);
            }
            obj[14] = new SqlParameter("PDV_CHUP_DiaDiem", item.CHUP_DiaDiem);
            obj[15] = new SqlParameter("PDV_CHUP_LoaiAlbum", item.CHUP_LoaiAlbum);
            obj[16] = new SqlParameter("PDV_CHUP_YeuCauKhach", item.CHUP_YeuCauKhach);
            obj[17] = new SqlParameter("PDV_CHUP_DaChuyenAnh", item.CHUP_DaChuyenAnh);
            if (item.CHUP_NgayChuyenAnh > DateTime.MinValue)
            {
                obj[18] = new SqlParameter("PDV_CHUP_NgayChuyenAnh", item.CHUP_NgayChuyenAnh);
            }
            else
            {
                obj[18] = new SqlParameter("PDV_CHUP_NgayChuyenAnh", DBNull.Value);
            }
            obj[19] = new SqlParameter("PDV_TD_NhanVien", item.TD_NhanVien);
            if (item.TD_NgayBatDau > DateTime.MinValue)
            {
                obj[20] = new SqlParameter("PDV_TD_NgayBatDau", item.TD_NgayBatDau);
            }
            else
            {
                obj[20] = new SqlParameter("PDV_TD_NgayBatDau", DBNull.Value);
            }
            if (item.TD_NgayKetThuc > DateTime.MinValue)
            {
                obj[21] = new SqlParameter("PDV_TD_NgayKetThuc", item.TD_NgayKetThuc);
            }
            else
            {
                obj[21] = new SqlParameter("PDV_TD_NgayKetThuc", DBNull.Value);
            }
            obj[22] = new SqlParameter("PDV_TOC_NhanVien", item.TOC_NhanVien);
            if (item.TOC_NgayBatDau > DateTime.MinValue)
            {
                obj[23] = new SqlParameter("PDV_TOC_NgayBatDau", item.TOC_NgayBatDau);
            }
            else
            {
                obj[23] = new SqlParameter("PDV_TOC_NgayBatDau", DBNull.Value);
            }
            if (item.TOC_NgayKetThuc > DateTime.MinValue)
            {
                obj[24] = new SqlParameter("PDV_TOC_NgayKetThuc", item.TOC_NgayKetThuc);
            }
            else
            {
                obj[24] = new SqlParameter("PDV_TOC_NgayKetThuc", DBNull.Value);
            }
            obj[25] = new SqlParameter("PDV_TD_NgoaiCanh", item.TD_NgoaiCanh);
            obj[26] = new SqlParameter("PDV_TD_DiaDiem", item.TD_DiaDiem);
            obj[27] = new SqlParameter("PDV_TD_KhoangCach", item.TD_KhoangCach);
            obj[28] = new SqlParameter("PDV_TD_PhiDiLai", item.TD_PhiDiLai);
            obj[29] = new SqlParameter("PDV_TD_KhoanPhaiThu", item.TD_KhoanPhaiThu);
            obj[30] = new SqlParameter("PDV_PTS_NhanVien", item.PTS_NhanVien);
            obj[31] = new SqlParameter("PDV_PTS_NhanVienDaNhan", item.PTS_NhanVienDaNhan);
            if (item.PTS_NgayXemMaket > DateTime.MinValue)
            {
                obj[32] = new SqlParameter("PDV_PTS_NgayXemMaket", item.PTS_NgayXemMaket);
            }
            else
            {
                obj[32] = new SqlParameter("PDV_PTS_NgayXemMaket", DBNull.Value);
            }
            if (item.PTS_NgayBatDau > DateTime.MinValue)
            {
                obj[33] = new SqlParameter("PDV_PTS_NgayBatDau", item.PTS_NgayBatDau);
            }
            else
            {
                obj[33] = new SqlParameter("PDV_PTS_NgayBatDau", DBNull.Value);
            }
            if (item.PTS_NgayKetThuc > DateTime.MinValue)
            {
                obj[34] = new SqlParameter("PDV_PTS_NgayKetThuc", item.PTS_NgayKetThuc);
            }
            else
            {
                obj[34] = new SqlParameter("PDV_PTS_NgayKetThuc", DBNull.Value);
            }
            obj[35] = new SqlParameter("PDV_PTS_YeuCauKhachHang", item.PTS_YeuCauKhachHang);
            if (item.PTS_HenSanPham > DateTime.MinValue)
            {
                obj[36] = new SqlParameter("PDV_PTS_HenSanPham", item.PTS_HenSanPham);
            }
            else
            {
                obj[36] = new SqlParameter("PDV_PTS_HenSanPham", DBNull.Value);
            }
            obj[37] = new SqlParameter("PDV_PTS_DaCoSanPham", item.PTS_DaCoSanPham);
            if (item.PTS_NgayCoSanPham > DateTime.MinValue)
            {
                obj[38] = new SqlParameter("PDV_PTS_NgayCoSanPham", item.PTS_NgayCoSanPham);
            }
            else
            {
                obj[38] = new SqlParameter("PDV_PTS_NgayCoSanPham", DBNull.Value);
            }
            if (item.PTS_NgayLaySanPham > DateTime.MinValue)
            {
                obj[39] = new SqlParameter("PDV_PTS_NgayLaySanPham", item.PTS_NgayLaySanPham);
            }
            else
            {
                obj[39] = new SqlParameter("PDV_PTS_NgayLaySanPham", DBNull.Value);
            }
            obj[40] = new SqlParameter("PDV_PTS_AnhPhong", item.PTS_AnhPhong);
            obj[41] = new SqlParameter("PDV_PTS_AnhPhongGhiChu", item.PTS_AnhPhongGhiChu);
            obj[42] = new SqlParameter("PDV_PTS_AnhBan", item.PTS_AnhBan);
            obj[43] = new SqlParameter("PDV_PTS_AnhBanGhiChu", item.PTS_AnhBanGhiChu);
            obj[44] = new SqlParameter("PDV_PTS_AnhBanQuyCach", item.PTS_AnhBanQuyCach);
            obj[45] = new SqlParameter("PDV_PTS_AnhBia", item.PTS_AnhBia);
            obj[46] = new SqlParameter("PDV_PTS_CD3D", item.PTS_CD3D);
            obj[47] = new SqlParameter("PDV_HoanThanh", item.HoanThanh);
            obj[48] = new SqlParameter("PDV_Voucher", item.Voucher);
            obj[49] = new SqlParameter("PDV_Voucher_Ma", item.Voucher_Ma);
            obj[50] = new SqlParameter("PDV_NguoiTao", item.NguoiTao);
            obj[51] = new SqlParameter("PDV_NguoiCapNhat", item.NguoiCapNhat);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[52] = new SqlParameter("PDV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[52] = new SqlParameter("PDV_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[53] = new SqlParameter("PDV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[53] = new SqlParameter("PDV_NgayCapNhat", DBNull.Value);
            }
            obj[54] = new SqlParameter("PDV_Xoa", item.Xoa);
            obj[55] = new SqlParameter("PDV_TrangThai", item.TrangThai);
            obj[56] = new SqlParameter("PDV_Huy", item.Huy);
            obj[57] = new SqlParameter("PDV_LyDoHuy", item.LyDoHuy);
            if (item.NgayHuy > DateTime.MinValue)
            {
                obj[58] = new SqlParameter("PDV_NgayHuy", item.NgayHuy);
            }
            else
            {
                obj[58] = new SqlParameter("PDV_NgayHuy", DBNull.Value);
            }
            obj[59] = new SqlParameter("PDV_NhanVienHuy", item.NhanVienHuy);
            obj[60] = new SqlParameter("PDV_DuyetEkip", item.DuyetEkip);
            if (item.NgayDuyetEkip > DateTime.MinValue)
            {
                obj[61] = new SqlParameter("PDV_NgayDuyetEkip", item.NgayDuyetEkip);
            }
            else
            {
                obj[61] = new SqlParameter("PDV_NgayDuyetEkip", DBNull.Value);
            }
            obj[62] = new SqlParameter("PDV_NguoiDuyet", item.NguoiDuyet);
            obj[63] = new SqlParameter("PDV_XoaAdm", item.XoaAdm);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuDichVu_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuDichVu Update(PhieuDichVu item)
        {
            var Item = new PhieuDichVu();
            var obj = new SqlParameter[64];
            obj[0] = new SqlParameter("PDV_ID", item.ID);
            obj[1] = new SqlParameter("PDV_Ma", item.Ma);
            obj[2] = new SqlParameter("PDV_KH_ID", item.KH_ID);
            obj[3] = new SqlParameter("PDV_GDV_ID", item.GDV_ID);
            obj[4] = new SqlParameter("PDV_TongTien", item.TongTien);
            obj[5] = new SqlParameter("PDV_ChietKhau", item.ChietKhau);
            obj[6] = new SqlParameter("PDV_DatCoc", item.DatCoc);
            obj[7] = new SqlParameter("PDV_ThanhToan", item.ThanhToan);
            obj[8] = new SqlParameter("PDV_ConNo", item.ConNo);
            obj[9] = new SqlParameter("PDV_TuVanVien", item.TuVanVien);
            if (item.NgayTuVan > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("PDV_NgayTuVan", item.NgayTuVan);
            }
            else
            {
                obj[10] = new SqlParameter("PDV_NgayTuVan", DBNull.Value);
            }
            obj[11] = new SqlParameter("PDV_CHUP_NhanVien", item.CHUP_NhanVien);
            if (item.CHUP_NgayBatDau > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("PDV_CHUP_NgayBatDau", item.CHUP_NgayBatDau);
            }
            else
            {
                obj[12] = new SqlParameter("PDV_CHUP_NgayBatDau", DBNull.Value);
            }
            if (item.CHUP_NgayKetThuc > DateTime.MinValue)
            {
                obj[13] = new SqlParameter("PDV_CHUP_NgayKetThuc", item.CHUP_NgayKetThuc);
            }
            else
            {
                obj[13] = new SqlParameter("PDV_CHUP_NgayKetThuc", DBNull.Value);
            }
            obj[14] = new SqlParameter("PDV_CHUP_DiaDiem", item.CHUP_DiaDiem);
            obj[15] = new SqlParameter("PDV_CHUP_LoaiAlbum", item.CHUP_LoaiAlbum);
            obj[16] = new SqlParameter("PDV_CHUP_YeuCauKhach", item.CHUP_YeuCauKhach);
            obj[17] = new SqlParameter("PDV_CHUP_DaChuyenAnh", item.CHUP_DaChuyenAnh);
            if (item.CHUP_NgayChuyenAnh > DateTime.MinValue)
            {
                obj[18] = new SqlParameter("PDV_CHUP_NgayChuyenAnh", item.CHUP_NgayChuyenAnh);
            }
            else
            {
                obj[18] = new SqlParameter("PDV_CHUP_NgayChuyenAnh", DBNull.Value);
            }
            obj[19] = new SqlParameter("PDV_TD_NhanVien", item.TD_NhanVien);
            if (item.TD_NgayBatDau > DateTime.MinValue)
            {
                obj[20] = new SqlParameter("PDV_TD_NgayBatDau", item.TD_NgayBatDau);
            }
            else
            {
                obj[20] = new SqlParameter("PDV_TD_NgayBatDau", DBNull.Value);
            }
            if (item.TD_NgayKetThuc > DateTime.MinValue)
            {
                obj[21] = new SqlParameter("PDV_TD_NgayKetThuc", item.TD_NgayKetThuc);
            }
            else
            {
                obj[21] = new SqlParameter("PDV_TD_NgayKetThuc", DBNull.Value);
            }
            obj[22] = new SqlParameter("PDV_TOC_NhanVien", item.TOC_NhanVien);
            if (item.TOC_NgayBatDau > DateTime.MinValue)
            {
                obj[23] = new SqlParameter("PDV_TOC_NgayBatDau", item.TOC_NgayBatDau);
            }
            else
            {
                obj[23] = new SqlParameter("PDV_TOC_NgayBatDau", DBNull.Value);
            }
            if (item.TOC_NgayKetThuc > DateTime.MinValue)
            {
                obj[24] = new SqlParameter("PDV_TOC_NgayKetThuc", item.TOC_NgayKetThuc);
            }
            else
            {
                obj[24] = new SqlParameter("PDV_TOC_NgayKetThuc", DBNull.Value);
            }
            obj[25] = new SqlParameter("PDV_TD_NgoaiCanh", item.TD_NgoaiCanh);
            obj[26] = new SqlParameter("PDV_TD_DiaDiem", item.TD_DiaDiem);
            obj[27] = new SqlParameter("PDV_TD_KhoangCach", item.TD_KhoangCach);
            obj[28] = new SqlParameter("PDV_TD_PhiDiLai", item.TD_PhiDiLai);
            obj[29] = new SqlParameter("PDV_TD_KhoanPhaiThu", item.TD_KhoanPhaiThu);
            obj[30] = new SqlParameter("PDV_PTS_NhanVien", item.PTS_NhanVien);
            obj[31] = new SqlParameter("PDV_PTS_NhanVienDaNhan", item.PTS_NhanVienDaNhan);
            if (item.PTS_NgayXemMaket > DateTime.MinValue)
            {
                obj[32] = new SqlParameter("PDV_PTS_NgayXemMaket", item.PTS_NgayXemMaket);
            }
            else
            {
                obj[32] = new SqlParameter("PDV_PTS_NgayXemMaket", DBNull.Value);
            }
            if (item.PTS_NgayBatDau > DateTime.MinValue)
            {
                obj[33] = new SqlParameter("PDV_PTS_NgayBatDau", item.PTS_NgayBatDau);
            }
            else
            {
                obj[33] = new SqlParameter("PDV_PTS_NgayBatDau", DBNull.Value);
            }
            if (item.PTS_NgayKetThuc > DateTime.MinValue)
            {
                obj[34] = new SqlParameter("PDV_PTS_NgayKetThuc", item.PTS_NgayKetThuc);
            }
            else
            {
                obj[34] = new SqlParameter("PDV_PTS_NgayKetThuc", DBNull.Value);
            }
            obj[35] = new SqlParameter("PDV_PTS_YeuCauKhachHang", item.PTS_YeuCauKhachHang);
            if (item.PTS_HenSanPham > DateTime.MinValue)
            {
                obj[36] = new SqlParameter("PDV_PTS_HenSanPham", item.PTS_HenSanPham);
            }
            else
            {
                obj[36] = new SqlParameter("PDV_PTS_HenSanPham", DBNull.Value);
            }
            obj[37] = new SqlParameter("PDV_PTS_DaCoSanPham", item.PTS_DaCoSanPham);
            if (item.PTS_NgayCoSanPham > DateTime.MinValue)
            {
                obj[38] = new SqlParameter("PDV_PTS_NgayCoSanPham", item.PTS_NgayCoSanPham);
            }
            else
            {
                obj[38] = new SqlParameter("PDV_PTS_NgayCoSanPham", DBNull.Value);
            }
            if (item.PTS_NgayLaySanPham > DateTime.MinValue)
            {
                obj[39] = new SqlParameter("PDV_PTS_NgayLaySanPham", item.PTS_NgayLaySanPham);
            }
            else
            {
                obj[39] = new SqlParameter("PDV_PTS_NgayLaySanPham", DBNull.Value);
            }
            obj[40] = new SqlParameter("PDV_PTS_AnhPhong", item.PTS_AnhPhong);
            obj[41] = new SqlParameter("PDV_PTS_AnhPhongGhiChu", item.PTS_AnhPhongGhiChu);
            obj[42] = new SqlParameter("PDV_PTS_AnhBan", item.PTS_AnhBan);
            obj[43] = new SqlParameter("PDV_PTS_AnhBanGhiChu", item.PTS_AnhBanGhiChu);
            obj[44] = new SqlParameter("PDV_PTS_AnhBanQuyCach", item.PTS_AnhBanQuyCach);
            obj[45] = new SqlParameter("PDV_PTS_AnhBia", item.PTS_AnhBia);
            obj[46] = new SqlParameter("PDV_PTS_CD3D", item.PTS_CD3D);
            obj[47] = new SqlParameter("PDV_HoanThanh", item.HoanThanh);
            obj[48] = new SqlParameter("PDV_Voucher", item.Voucher);
            obj[49] = new SqlParameter("PDV_Voucher_Ma", item.Voucher_Ma);
            obj[50] = new SqlParameter("PDV_NguoiTao", item.NguoiTao);
            obj[51] = new SqlParameter("PDV_NguoiCapNhat", item.NguoiCapNhat);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[52] = new SqlParameter("PDV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[52] = new SqlParameter("PDV_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[53] = new SqlParameter("PDV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[53] = new SqlParameter("PDV_NgayCapNhat", DBNull.Value);
            }
            obj[54] = new SqlParameter("PDV_Xoa", item.Xoa);
            obj[55] = new SqlParameter("PDV_TrangThai", item.TrangThai);
            obj[56] = new SqlParameter("PDV_Huy", item.Huy);
            obj[57] = new SqlParameter("PDV_LyDoHuy", item.LyDoHuy);
            if (item.NgayHuy > DateTime.MinValue)
            {
                obj[58] = new SqlParameter("PDV_NgayHuy", item.NgayHuy);
            }
            else
            {
                obj[58] = new SqlParameter("PDV_NgayHuy", DBNull.Value);
            }
            obj[59] = new SqlParameter("PDV_NhanVienHuy", item.NhanVienHuy);
            obj[60] = new SqlParameter("PDV_DuyetEkip", item.DuyetEkip);
            if (item.NgayDuyetEkip > DateTime.MinValue)
            {
                obj[61] = new SqlParameter("PDV_NgayDuyetEkip", item.NgayDuyetEkip);
            }
            else
            {
                obj[61] = new SqlParameter("PDV_NgayDuyetEkip", DBNull.Value);
            }
            obj[62] = new SqlParameter("PDV_NguoiDuyet", item.NguoiDuyet);
            obj[63] = new SqlParameter("PDV_XoaAdm", item.XoaAdm);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuDichVu_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuDichVu SelectById(SqlConnection con, Guid PDV_ID)
        {
            var Item = new PhieuDichVu();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PDV_ID", PDV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuDichVu_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuDichVuCollection SelectAll()
        {
            var List = new PhieuDichVuCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuDichVu_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<PhieuDichVu> pagerNormal(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string TrangThai)
        {

            return pagerNormal(con, url, rewrite, sort, q, size, TrangThai, null, null, null, null, null,null,null);
        }
        public static Pager<PhieuDichVu> pagerNormal(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string TrangThai
            , string TuVanVien
            , string CHUP_NhanVien
            , string TD_NhanVien
            , string TOC_NhanVien
            , string PTS_NhanVien
            , string TuNgay)
        {

            return pagerNormal(con, url, rewrite, sort, q, size, TrangThai, TuVanVien, CHUP_NhanVien, TD_NhanVien, TOC_NhanVien, PTS_NhanVien, null, null);
        }
        public static Pager<PhieuDichVu> pagerNormal(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string TrangThai
            , string TuVanVien
            , string CHUP_NhanVien
            , string TD_NhanVien
            , string TOC_NhanVien
            , string PTS_NhanVien
            , string TuNgay
            , string DenNgay
            )
        {
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TrangThai))
            {
                obj[2] = new SqlParameter("TrangThai", TrangThai);
            }
            else
            {
                obj[2] = new SqlParameter("TrangThai", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(CHUP_NhanVien))
            {
                obj[3] = new SqlParameter("CHUP_NhanVien", CHUP_NhanVien);
            }
            else
            {
                obj[3] = new SqlParameter("CHUP_NhanVien", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TD_NhanVien))
            {
                obj[4] = new SqlParameter("TD_NhanVien", TD_NhanVien);
            }
            else
            {
                obj[4] = new SqlParameter("TD_NhanVien", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TOC_NhanVien))
            {
                obj[5] = new SqlParameter("TOC_NhanVien", TOC_NhanVien);
            }
            else
            {
                obj[5] = new SqlParameter("TOC_NhanVien", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(PTS_NhanVien))
            {
                obj[6] = new SqlParameter("PTS_NhanVien", PTS_NhanVien);
            }
            else
            {
                obj[6] = new SqlParameter("PTS_NhanVien", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TuVanVien))
            {
                obj[7] = new SqlParameter("TuVanVien", TuVanVien);
            }
            else
            {
                obj[7] = new SqlParameter("TuVanVien", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[8] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[8] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[9] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[9] = new SqlParameter("DenNgay", DBNull.Value);
            }
            var pg = new Pager<PhieuDichVu>(con, "sp_tblAoCuoi_PhieuDichVu_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static PhieuDichVu getFromReader(IDataReader rd)
        {
            var Item = new PhieuDichVu();
            if (rd.FieldExists("PDV_ID"))
            {
                Item.ID = (Guid)(rd["PDV_ID"]);
            }
            if (rd.FieldExists("PDV_Ma"))
            {
                Item.Ma = (Int32)(rd["PDV_Ma"]);
            }
            if (rd.FieldExists("PDV_KH_ID"))
            {
                Item.KH_ID = (Guid)(rd["PDV_KH_ID"]);
            }
            if (rd.FieldExists("PDV_GDV_ID"))
            {
                Item.GDV_ID = (Guid)(rd["PDV_GDV_ID"]);
            }
            if (rd.FieldExists("PDV_TongTien"))
            {
                Item.TongTien = (Double)(rd["PDV_TongTien"]);
            }
            if (rd.FieldExists("PDV_ChietKhau"))
            {
                Item.ChietKhau = (Double)(rd["PDV_ChietKhau"]);
            }
            if (rd.FieldExists("PDV_DatCoc"))
            {
                Item.DatCoc = (Double)(rd["PDV_DatCoc"]);
            }
            if (rd.FieldExists("PDV_ThanhToan"))
            {
                Item.ThanhToan = (Double)(rd["PDV_ThanhToan"]);
            }
            if (rd.FieldExists("PDV_ConNo"))
            {
                Item.ConNo = (Double)(rd["PDV_ConNo"]);
            }
            if (rd.FieldExists("PDV_TuVanVien"))
            {
                Item.TuVanVien = (Int32)(rd["PDV_TuVanVien"]);
            }
            if (rd.FieldExists("PDV_NgayTuVan"))
            {
                Item.NgayTuVan = (DateTime)(rd["PDV_NgayTuVan"]);
            }
            if (rd.FieldExists("PDV_CHUP_NhanVien"))
            {
                Item.CHUP_NhanVien = (Int32)(rd["PDV_CHUP_NhanVien"]);
            }
            if (rd.FieldExists("PDV_CHUP_NgayBatDau"))
            {
                Item.CHUP_NgayBatDau = (DateTime)(rd["PDV_CHUP_NgayBatDau"]);
            }
            if (rd.FieldExists("PDV_CHUP_NgayKetThuc"))
            {
                Item.CHUP_NgayKetThuc = (DateTime)(rd["PDV_CHUP_NgayKetThuc"]);
            }
            if (rd.FieldExists("PDV_CHUP_DiaDiem"))
            {
                Item.CHUP_DiaDiem = (String)(rd["PDV_CHUP_DiaDiem"]);
            }
            if (rd.FieldExists("PDV_CHUP_LoaiAlbum"))
            {
                Item.CHUP_LoaiAlbum = (String)(rd["PDV_CHUP_LoaiAlbum"]);
            }
            if (rd.FieldExists("PDV_CHUP_YeuCauKhach"))
            {
                Item.CHUP_YeuCauKhach = (String)(rd["PDV_CHUP_YeuCauKhach"]);
            }
            if (rd.FieldExists("PDV_CHUP_DaChuyenAnh"))
            {
                Item.CHUP_DaChuyenAnh = (Boolean)(rd["PDV_CHUP_DaChuyenAnh"]);
            }
            if (rd.FieldExists("PDV_CHUP_NgayChuyenAnh"))
            {
                Item.CHUP_NgayChuyenAnh = (DateTime)(rd["PDV_CHUP_NgayChuyenAnh"]);
            }
            if (rd.FieldExists("PDV_TD_NhanVien"))
            {
                Item.TD_NhanVien = (Int32)(rd["PDV_TD_NhanVien"]);
            }
            if (rd.FieldExists("PDV_TD_NgayBatDau"))
            {
                Item.TD_NgayBatDau = (DateTime)(rd["PDV_TD_NgayBatDau"]);
            }
            if (rd.FieldExists("PDV_TD_NgayKetThuc"))
            {
                Item.TD_NgayKetThuc = (DateTime)(rd["PDV_TD_NgayKetThuc"]);
            }
            if (rd.FieldExists("PDV_TOC_NhanVien"))
            {
                Item.TOC_NhanVien = (Int32)(rd["PDV_TOC_NhanVien"]);
            }
            if (rd.FieldExists("PDV_TOC_NgayBatDau"))
            {
                Item.TOC_NgayBatDau = (DateTime)(rd["PDV_TOC_NgayBatDau"]);
            }
            if (rd.FieldExists("PDV_TOC_NgayKetThuc"))
            {
                Item.TOC_NgayKetThuc = (DateTime)(rd["PDV_TOC_NgayKetThuc"]);
            }
            if (rd.FieldExists("PDV_TD_NgoaiCanh"))
            {
                Item.TD_NgoaiCanh = (Boolean)(rd["PDV_TD_NgoaiCanh"]);
            }
            if (rd.FieldExists("PDV_TD_DiaDiem"))
            {
                Item.TD_DiaDiem = (String)(rd["PDV_TD_DiaDiem"]);
            }
            if (rd.FieldExists("PDV_TD_KhoangCach"))
            {
                Item.TD_KhoangCach = (Int32)(rd["PDV_TD_KhoangCach"]);
            }
            if (rd.FieldExists("PDV_TD_PhiDiLai"))
            {
                Item.TD_PhiDiLai = (Double)(rd["PDV_TD_PhiDiLai"]);
            }
            if (rd.FieldExists("PDV_TD_KhoanPhaiThu"))
            {
                Item.TD_KhoanPhaiThu = (Double)(rd["PDV_TD_KhoanPhaiThu"]);
            }
            if (rd.FieldExists("PDV_PTS_NhanVien"))
            {
                Item.PTS_NhanVien = (Int32)(rd["PDV_PTS_NhanVien"]);
            }
            if (rd.FieldExists("PDV_PTS_NhanVienDaNhan"))
            {
                Item.PTS_NhanVienDaNhan = (Boolean)(rd["PDV_PTS_NhanVienDaNhan"]);
            }
            if (rd.FieldExists("PDV_PTS_NgayXemMaket"))
            {
                Item.PTS_NgayXemMaket = (DateTime)(rd["PDV_PTS_NgayXemMaket"]);
            }
            if (rd.FieldExists("PDV_PTS_NgayBatDau"))
            {
                Item.PTS_NgayBatDau = (DateTime)(rd["PDV_PTS_NgayBatDau"]);
            }
            if (rd.FieldExists("PDV_PTS_NgayKetThuc"))
            {
                Item.PTS_NgayKetThuc = (DateTime)(rd["PDV_PTS_NgayKetThuc"]);
            }
            if (rd.FieldExists("PDV_PTS_YeuCauKhachHang"))
            {
                Item.PTS_YeuCauKhachHang = (String)(rd["PDV_PTS_YeuCauKhachHang"]);
            }
            if (rd.FieldExists("PDV_PTS_HenSanPham"))
            {
                Item.PTS_HenSanPham = (DateTime)(rd["PDV_PTS_HenSanPham"]);
            }
            if (rd.FieldExists("PDV_PTS_DaCoSanPham"))
            {
                Item.PTS_DaCoSanPham = (Boolean)(rd["PDV_PTS_DaCoSanPham"]);
            }
            if (rd.FieldExists("PDV_PTS_NgayCoSanPham"))
            {
                Item.PTS_NgayCoSanPham = (DateTime)(rd["PDV_PTS_NgayCoSanPham"]);
            }
            if (rd.FieldExists("PDV_PTS_NgayLaySanPham"))
            {
                Item.PTS_NgayLaySanPham = (DateTime)(rd["PDV_PTS_NgayLaySanPham"]);
            }
            if (rd.FieldExists("PDV_PTS_AnhPhong"))
            {
                Item.PTS_AnhPhong = (String)(rd["PDV_PTS_AnhPhong"]);
            }
            if (rd.FieldExists("PDV_PTS_AnhPhongGhiChu"))
            {
                Item.PTS_AnhPhongGhiChu = (String)(rd["PDV_PTS_AnhPhongGhiChu"]);
            }
            if (rd.FieldExists("PDV_PTS_AnhBan"))
            {
                Item.PTS_AnhBan = (String)(rd["PDV_PTS_AnhBan"]);
            }
            if (rd.FieldExists("PDV_PTS_AnhBanGhiChu"))
            {
                Item.PTS_AnhBanGhiChu = (String)(rd["PDV_PTS_AnhBanGhiChu"]);
            }
            if (rd.FieldExists("PDV_PTS_AnhBanQuyCach"))
            {
                Item.PTS_AnhBanQuyCach = (String)(rd["PDV_PTS_AnhBanQuyCach"]);
            }
            if (rd.FieldExists("PDV_PTS_AnhBia"))
            {
                Item.PTS_AnhBia = (String)(rd["PDV_PTS_AnhBia"]);
            }
            if (rd.FieldExists("PDV_PTS_CD3D"))
            {
                Item.PTS_CD3D = (Boolean)(rd["PDV_PTS_CD3D"]);
            }
            if (rd.FieldExists("PDV_HoanThanh"))
            {
                Item.HoanThanh = (Boolean)(rd["PDV_HoanThanh"]);
            }
            if (rd.FieldExists("PDV_Voucher"))
            {
                Item.Voucher = (Boolean)(rd["PDV_Voucher"]);
            }
            if (rd.FieldExists("PDV_Voucher_Ma"))
            {
                Item.Voucher_Ma = (String)(rd["PDV_Voucher_Ma"]);
            }
            if (rd.FieldExists("PDV_NguoiTao"))
            {
                Item.NguoiTao = (Int32)(rd["PDV_NguoiTao"]);
            }
            if (rd.FieldExists("PDV_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (Int32)(rd["PDV_NguoiCapNhat"]);
            }
            if (rd.FieldExists("PDV_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["PDV_NgayTao"]);
            }
            if (rd.FieldExists("PDV_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["PDV_NgayCapNhat"]);
            }
            if (rd.FieldExists("PDV_Xoa"))
            {
                Item.Xoa = (Boolean)(rd["PDV_Xoa"]);
            }
            if (rd.FieldExists("PDV_TrangThai"))
            {
                Item.TrangThai = (Int32)(rd["PDV_TrangThai"]);
            }
            if (rd.FieldExists("PDV_Huy"))
            {
                Item.Huy = (Boolean)(rd["PDV_Huy"]);
            }
            if (rd.FieldExists("PDV_LyDoHuy"))
            {
                Item.LyDoHuy = (String)(rd["PDV_LyDoHuy"]);
            }
            if (rd.FieldExists("PDV_NgayHuy"))
            {
                Item.NgayHuy = (DateTime)(rd["PDV_NgayHuy"]);
            }
            if (rd.FieldExists("PDV_NhanVienHuy"))
            {
                Item.NhanVienHuy = (Int32)(rd["PDV_NhanVienHuy"]);
            }

            if (rd.FieldExists("PDV_DuyetEkip"))
            {
                Item.DuyetEkip = (Boolean)(rd["PDV_DuyetEkip"]);
            }
            if (rd.FieldExists("PDV_NgayDuyetEkip"))
            {
                Item.NgayDuyetEkip = (DateTime)(rd["PDV_NgayDuyetEkip"]);
            }
            if (rd.FieldExists("PDV_NguoiDuyet"))
            {
                Item.NguoiDuyet = (Int32)(rd["PDV_NguoiDuyet"]);
            }
            if (rd.FieldExists("PDV_XoaAdm"))
            {
                Item.XoaAdm = (Boolean)(rd["PDV_XoaAdm"]);
            }
            // Extended


            if (rd.FieldExists("GDV_Ten"))
            {
                Item.GDV_Ten = (String)(rd["GDV_Ten"]);
            }
            if (rd.FieldExists("NguoiTao_Ten"))
            {
                Item.NguoiTao_Ten = (String)(rd["NguoiTao_Ten"]);
            }
            if (rd.FieldExists("NguoiCapNhat_Ten"))
            {
                Item.NguoiCapNhat_Ten = (String)(rd["NguoiCapNhat_Ten"]);
            }
            if (rd.FieldExists("CHUP_NhanVien_Ten"))
            {
                Item.CHUP_NhanVien_Ten = (String)(rd["CHUP_NhanVien_Ten"]);
            }
            if (rd.FieldExists("PTS_NhanVien_Ten"))
            {
                Item.PTS_NhanVien_Ten = (String)(rd["PTS_NhanVien_Ten"]);
            }
            if (rd.FieldExists("TD_NhanVien_Ten"))
            {
                Item.TD_NhanVien_Ten = (String)(rd["TD_NhanVien_Ten"]);
            }
            if (rd.FieldExists("TOC_NhanVien_Ten"))
            {
                Item.TOC_NhanVien_Ten = (String)(rd["TOC_NhanVien_Ten"]);
            }
            if (rd.FieldExists("KH_Ten") && Item.KH_ID!= Guid.Empty)
            {
                Item.KH_Ten = maHoa.DecryptString((String) (rd["KH_Ten"]), Item.KH_ID.ToString());
            }
            if (rd.FieldExists("TuVanVien_Ten"))
            {
                Item.TuVanVien_Ten = (String)(rd["TuVanVien_Ten"]);
            }
            if (rd.FieldExists("NguoiDuyet_Ten"))
            {
                Item.NguoiDuyet_Ten = (String)(rd["NguoiDuyet_Ten"]);
            }

            if (rd.FieldExists("X_ConNo"))
            {
                Item.X_ConNo = (Double)(rd["X_ConNo"]);
            }

            if (rd.FieldExists("X_ThanhToan"))
            {
                Item.X_ThanhToan = (Double)(rd["X_ThanhToan"]);
            }

            //Item._KhachHang = KhachHangDal.getFromReader(rd);
            Item._KhachHang =new KhachHang();
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<PhieuDichVu> pagerXoa(SqlConnection con, string url, bool rewrite, string sort, string q, int size
            )
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            var pg = new Pager<PhieuDichVu>(con, "sp_tblAoCuoi_PhieuDichVu_Pager_Xoa_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }

        public static PhieuDichVu SelectDraff(SqlConnection con)
        {
            var Item = new PhieuDichVu();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuDichVu_Select_SelectDraff_linhnx"))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }


        public static Pager<PhieuDichVu> pagerByNhanVienNgay(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string TrangThai
            , string NhanVien
            , string TuNgay
            , string DenNgay
            )
        {
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TrangThai))
            {
                obj[2] = new SqlParameter("TrangThai", TrangThai);
            }
            else
            {
                obj[2] = new SqlParameter("TrangThai", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NhanVien))
            {
                obj[3] = new SqlParameter("NhanVien", NhanVien);
            }
            else
            {
                obj[3] = new SqlParameter("NhanVien", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[4] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[4] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[5] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[5] = new SqlParameter("DenNgay", DBNull.Value);
            }
            var pg = new Pager<PhieuDichVu>(con, "sp_tblAoCuoi_PhieuDichVu_Pager_pagerByNhanVienNgay_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<PhieuDichVu> pagerPts(SqlConnection con, string url, bool rewrite, string sort, string q, int size
            , string TrangThai
            , string PTS_NhanVien
            , string Ngay
            , string TuNgay
            , string DenNgay
            )
        {
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TrangThai))
            {
                obj[2] = new SqlParameter("TrangThai", TrangThai);
            }
            else
            {
                obj[2] = new SqlParameter("TrangThai", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(PTS_NhanVien))
            {
                obj[3] = new SqlParameter("PTS_NhanVien", PTS_NhanVien);
            }
            else
            {
                obj[3] = new SqlParameter("PTS_NhanVien", DBNull.Value);
            }
            
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[4] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[4] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[5] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[5] = new SqlParameter("DenNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Ngay))
            {
                obj[6] = new SqlParameter("Ngay", Ngay);
            }
            else
            {
                obj[6] = new SqlParameter("Ngay", DBNull.Value);
            } 
            var pg = new Pager<PhieuDichVu>(con, "sp_tblAoCuoi_PhieuDichVu_Pager_pagerPts_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<PhieuDichVu> pagerTd(SqlConnection con, string url, bool rewrite, string sort, string q, int size
           , string TrangThai
           , string TD_NhanVien
           , string TuNgay
           , string DenNgay
           )
        {
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TrangThai))
            {
                obj[2] = new SqlParameter("TrangThai", TrangThai);
            }
            else
            {
                obj[2] = new SqlParameter("TrangThai", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TD_NhanVien))
            {
                obj[3] = new SqlParameter("TD_NhanVien", TD_NhanVien);
            }
            else
            {
                obj[3] = new SqlParameter("TD_NhanVien", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[4] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[4] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[5] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[5] = new SqlParameter("DenNgay", DBNull.Value);
            }
            
            var pg = new Pager<PhieuDichVu>(con, "sp_tblAoCuoi_PhieuDichVu_Pager_pagerTd_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }


        public static Pager<PhieuDichVu> pagerTdToc(SqlConnection con, string url, bool rewrite, string sort, string q, int size
          , string TrangThai
          , string NhanVien
          , string TuNgay
          , string DenNgay
          )
        {
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TrangThai))
            {
                obj[2] = new SqlParameter("TrangThai", TrangThai);
            }
            else
            {
                obj[2] = new SqlParameter("TrangThai", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NhanVien))
            {
                obj[3] = new SqlParameter("NhanVien", NhanVien);
            }
            else
            {
                obj[3] = new SqlParameter("NhanVien", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[4] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[4] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[5] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[5] = new SqlParameter("DenNgay", DBNull.Value);
            }
            var pg = new Pager<PhieuDichVu>(con, "sp_tblAoCuoi_PhieuDichVu_Pager_pagerTdToc_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<PhieuDichVu> pagerToc(SqlConnection con, string url, bool rewrite, string sort, string q, int size
          , string TrangThai
          , string TOC_NhanVien
          , string TuNgay
          , string DenNgay
          )
        {
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TrangThai))
            {
                obj[2] = new SqlParameter("TrangThai", TrangThai);
            }
            else
            {
                obj[2] = new SqlParameter("TrangThai", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TOC_NhanVien))
            {
                obj[3] = new SqlParameter("TOC_NhanVien", TOC_NhanVien);
            }
            else
            {
                obj[3] = new SqlParameter("TOC_NhanVien", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[4] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[4] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[5] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[5] = new SqlParameter("DenNgay", DBNull.Value);
            }
            var pg = new Pager<PhieuDichVu>(con, "sp_tblAoCuoi_PhieuDichVu_Pager_pagerToc_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<PhieuDichVu> pagerChupAnh(SqlConnection con, string url, bool rewrite, string sort, string q, int size
          , string TrangThai
          , string TOC_NhanVien
          , string TuNgay
          , string DenNgay
          )
        {
            var obj = new SqlParameter[10];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TrangThai))
            {
                obj[2] = new SqlParameter("TrangThai", TrangThai);
            }
            else
            {
                obj[2] = new SqlParameter("TrangThai", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TOC_NhanVien))
            {
                obj[3] = new SqlParameter("TOC_NhanVien", TOC_NhanVien);
            }
            else
            {
                obj[3] = new SqlParameter("TOC_NhanVien", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[4] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[4] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[5] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[5] = new SqlParameter("DenNgay", DBNull.Value);
            }
            var pg = new Pager<PhieuDichVu>(con, "sp_tblAoCuoi_PhieuDichVu_Pager_pagerChupAnh_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }

        public static Pager<PhieuDichVu> pagerDuyetEkip(SqlConnection con, string url, bool rewrite, string sort, int size, string Duyet
            )
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(Duyet))
            {
                obj[1] = new SqlParameter("Duyet", Duyet);
            }
            else
            {
                obj[1] = new SqlParameter("Duyet", DBNull.Value);
            }
            var pg = new Pager<PhieuDichVu>(con, "sp_tblAoCuoi_PhieuDichVu_Pager_DuyetEkip_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }

        #endregion
    }
    #endregion

    #endregion

    #region PhieuDichVuDichVu
    #region BO
    public class PhieuDichVuDichVu : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid PDV_ID { get; set; }
        public Guid HH_ID { get; set; }
        public Int32 ThuTu { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public Double Gia { get; set; }
        public Int32 SoLuong { get; set; }
        public Double Tien { get; set; }
        public Boolean DichVuThem { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 NguoiTao { get; set; }
        public Int32 NhanVien { get; set; }
        #endregion
        #region Contructor
        public PhieuDichVuDichVu()
        { }
        #endregion
        #region Customs properties

        public string HH_Ten { get; set; }
        public Int32 PDV_Ma { get; set; }
        public string NhanVien_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return PhieuDichVuDichVuDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class PhieuDichVuDichVuCollection : BaseEntityCollection<PhieuDichVuDichVu>
    { }
    #endregion
    #region Dal
    public class PhieuDichVuDichVuDal
    {
        #region Methods

        public static void DeleteById(Guid PDVDV_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PDVDV_ID", PDVDV_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuDichVuDichVu_Delete_DeleteById_linhnx", obj);
        }

        public static PhieuDichVuDichVu Insert(PhieuDichVuDichVu item)
        {
            var Item = new PhieuDichVuDichVu();
            var obj = new SqlParameter[14];
            obj[0] = new SqlParameter("PDVDV_ID", item.ID);
            obj[1] = new SqlParameter("PDVDV_PDV_ID", item.PDV_ID);
            obj[2] = new SqlParameter("PDVDV_HH_ID", item.HH_ID);
            obj[3] = new SqlParameter("PDVDV_ThuTu", item.ThuTu);
            obj[4] = new SqlParameter("PDVDV_Ten", item.Ten);
            obj[5] = new SqlParameter("PDVDV_MoTa", item.MoTa);
            obj[6] = new SqlParameter("PDVDV_Gia", item.Gia);
            obj[7] = new SqlParameter("PDVDV_SoLuong", item.SoLuong);
            obj[8] = new SqlParameter("PDVDV_Tien", item.Tien);
            obj[9] = new SqlParameter("PDVDV_DichVuThem", item.DichVuThem);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("PDVDV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("PDVDV_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("PDVDV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[11] = new SqlParameter("PDVDV_NgayCapNhat", DBNull.Value);
            }
            obj[12] = new SqlParameter("PDVDV_NguoiTao", item.NguoiTao);
            obj[13] = new SqlParameter("PDVDV_NhanVien", item.NhanVien);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuDichVuDichVu_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuDichVuDichVu Update(PhieuDichVuDichVu item)
        {
            var Item = new PhieuDichVuDichVu();
            var obj = new SqlParameter[14];
            obj[0] = new SqlParameter("PDVDV_ID", item.ID);
            obj[1] = new SqlParameter("PDVDV_PDV_ID", item.PDV_ID);
            obj[2] = new SqlParameter("PDVDV_HH_ID", item.HH_ID);
            obj[3] = new SqlParameter("PDVDV_ThuTu", item.ThuTu);
            obj[4] = new SqlParameter("PDVDV_Ten", item.Ten);
            obj[5] = new SqlParameter("PDVDV_MoTa", item.MoTa);
            obj[6] = new SqlParameter("PDVDV_Gia", item.Gia);
            obj[7] = new SqlParameter("PDVDV_SoLuong", item.SoLuong);
            obj[8] = new SqlParameter("PDVDV_Tien", item.Tien);
            obj[9] = new SqlParameter("PDVDV_DichVuThem", item.DichVuThem);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("PDVDV_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("PDVDV_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("PDVDV_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[11] = new SqlParameter("PDVDV_NgayCapNhat", DBNull.Value);
            }
            obj[12] = new SqlParameter("PDVDV_NguoiTao", item.NguoiTao);
            obj[13] = new SqlParameter("PDVDV_NhanVien", item.NhanVien);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuDichVuDichVu_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
                

        public static PhieuDichVuDichVu SelectById(Guid PDVDV_ID)
        {
            var Item = new PhieuDichVuDichVu();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PDVDV_ID", PDVDV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuDichVuDichVu_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuDichVuDichVuCollection SelectAll()
        {
            var List = new PhieuDichVuDichVuCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuDichVuDichVu_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<PhieuDichVuDichVu> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<PhieuDichVuDichVu>("sp_tblAoCuoi_PhieuDichVuDichVu_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static PhieuDichVuDichVu getFromReader(IDataReader rd)
        {
            var Item = new PhieuDichVuDichVu();
            if (rd.FieldExists("PDVDV_ID"))
            {
                Item.ID = (Guid)(rd["PDVDV_ID"]);
            }
            if (rd.FieldExists("PDVDV_PDV_ID"))
            {
                Item.PDV_ID = (Guid)(rd["PDVDV_PDV_ID"]);
            }
            if (rd.FieldExists("PDVDV_HH_ID"))
            {
                Item.HH_ID = (Guid)(rd["PDVDV_HH_ID"]);
            }
            if (rd.FieldExists("PDVDV_ThuTu"))
            {
                Item.ThuTu = (Int32)(rd["PDVDV_ThuTu"]);
            }
            if (rd.FieldExists("PDVDV_Ten"))
            {
                Item.Ten = (String)(rd["PDVDV_Ten"]);
            }
            if (rd.FieldExists("PDVDV_MoTa"))
            {
                Item.MoTa = (String)(rd["PDVDV_MoTa"]);
            }
            if (rd.FieldExists("PDVDV_Gia"))
            {
                Item.Gia = (Double)(rd["PDVDV_Gia"]);
            }
            if (rd.FieldExists("PDVDV_SoLuong"))
            {
                Item.SoLuong = (Int32)(rd["PDVDV_SoLuong"]);
            }
            if (rd.FieldExists("PDVDV_Tien"))
            {
                Item.Tien = (Double)(rd["PDVDV_Tien"]);
            }
            if (rd.FieldExists("PDVDV_DichVuThem"))
            {
                Item.DichVuThem = (Boolean)(rd["PDVDV_DichVuThem"]);
            }
            if (rd.FieldExists("PDVDV_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["PDVDV_NgayTao"]);
            }
            if (rd.FieldExists("PDVDV_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["PDVDV_NgayCapNhat"]);
            }
            if (rd.FieldExists("PDVDV_NguoiTao"))
            {
                Item.NguoiTao = (Int32)(rd["PDVDV_NguoiTao"]);
            }
            if (rd.FieldExists("HH_Ten"))
            {
                Item.HH_Ten = (String)(rd["HH_Ten"]);
            }
            if (rd.FieldExists("PDV_Ma"))
            {
                Item.PDV_Ma = (Int32)(rd["PDV_Ma"]);
            }
            if (rd.FieldExists("PDVDV_NhanVien"))
            {
                Item.NhanVien = (Int32)(rd["PDVDV_NhanVien"]);
            }
            if (rd.FieldExists("NhanVien_Ten"))
            {
                Item.NhanVien_Ten = (String)(rd["NhanVien_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static PhieuDichVuDichVuCollection SelectByPdvId(SqlConnection con, string PDV_ID)
        {
            var List = new PhieuDichVuDichVuCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PDV_ID", PDV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuDichVuDichVu_Select_SelectByPdvId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion

    #endregion

    #region PhieuXuatNhapSanPham
    #region BO
    public class PhieuXuatNhapSanPham : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Int32 Ma { get; set; }
        public Guid PDV_ID { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime NgayXuat { get; set; }
        public DateTime NgayNhapDuKien { get; set; }
        public DateTime NgayNhap { get; set; }
        public Int32 NguoiXuat { get; set; }
        public Int32 NguoiNhap { get; set; }
        public Int32 ThuKho { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 NguoiTao { get; set; }
        public Boolean Xoa { get; set; }
        public Int32 TrangThai { get; set; }
        #endregion
        #region Contructor
        public PhieuXuatNhapSanPham()
        { }
        #endregion
        #region Customs properties
        public string Hint
        {
            get { return string.Format("{0}", Ma); }
        }

        public string Url
        {
            get { return string.Format("/lib/pages/XuatNhapSanPham/Add.aspx?ID={0}", ID); }
        }
        public string UrlPrint
        {
            get { return string.Format("/lib/pages/XuatNhapSanPham/Print.aspx?ID={0}", ID); }
        }
        public string UrlView
        {
            get { return string.Format("/lib/pages/XuatNhapSanPham/View.aspx?ID={0}", ID); }
        }

        private const string MaFull = "000000000";
        public string MaStr
        {
            get
            {
                var maLen = Ma.ToString().Length;
                return MaFull.PadRight(maLen) + Ma.ToString();
            }
        }
        public string TrangThai_Ten
        {
            get
            {
                switch (TrangThai)
                {
                    case 0:
                        return string.Empty;
                        break;
                    case 1:
                        return "Mới lập";
                        break;
                    case 2:
                        return "Đã xuất";
                        break;
                    case 3:
                        return "Đã nhập";
                        break;
                    case 4:
                        return "Quá hạn";
                        break;
                    default:
                        return string.Empty;
                        break;
                }
            }
        }

        public string NguoiXuat_Ten { get; set; }
        public string NguoiNhap_Ten { get; set; }
        public string ThuKho_Ten { get; set; }

        public string NguoiTao_Ten { get; set; }
        public int PDV_Ma { get; set; }
        public string PDV_MaStr { get { return Lib.FormatMa(PDV_Ma); } }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return PhieuXuatNhapSanPhamDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class PhieuXuatNhapSanPhamCollection : BaseEntityCollection<PhieuXuatNhapSanPham>
    { }
    #endregion
    #region Dal
    public class PhieuXuatNhapSanPhamDal
    {
        #region Methods

        public static void DeleteById(Guid PXNSP_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PXNSP_ID", PXNSP_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuXuatNhapSanPham_Delete_DeleteById_linhnx", obj);
        }

        public static PhieuXuatNhapSanPham Insert(PhieuXuatNhapSanPham item)
        {
            var Item = new PhieuXuatNhapSanPham();
            var obj = new SqlParameter[15];
            obj[0] = new SqlParameter("PXNSP_ID", item.ID);
            obj[1] = new SqlParameter("PXNSP_Ma", item.Ma);
            obj[2] = new SqlParameter("PXNSP_PDV_ID", item.PDV_ID);
            if (item.NgayLap > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("PXNSP_NgayLap", item.NgayLap);
            }
            else
            {
                obj[3] = new SqlParameter("PXNSP_NgayLap", DBNull.Value);
            }
            if (item.NgayXuat > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("PXNSP_NgayXuat", item.NgayXuat);
            }
            else
            {
                obj[4] = new SqlParameter("PXNSP_NgayXuat", DBNull.Value);
            }
            if (item.NgayNhapDuKien > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("PXNSP_NgayNhapDuKien", item.NgayNhapDuKien);
            }
            else
            {
                obj[5] = new SqlParameter("PXNSP_NgayNhapDuKien", DBNull.Value);
            }
            if (item.NgayNhap > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("PXNSP_NgayNhap", item.NgayNhap);
            }
            else
            {
                obj[6] = new SqlParameter("PXNSP_NgayNhap", DBNull.Value);
            }
            obj[7] = new SqlParameter("PXNSP_NguoiXuat", item.NguoiXuat);
            obj[8] = new SqlParameter("PXNSP_NguoiNhap", item.NguoiNhap);
            obj[9] = new SqlParameter("PXNSP_ThuKho", item.ThuKho);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("PXNSP_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("PXNSP_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("PXNSP_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[11] = new SqlParameter("PXNSP_NgayCapNhat", DBNull.Value);
            }
            obj[12] = new SqlParameter("PXNSP_NguoiTao", item.NguoiTao);
            obj[13] = new SqlParameter("PXNSP_Xoa", item.Xoa);
            obj[14] = new SqlParameter("PXNSP_TrangThai", item.TrangThai);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuXuatNhapSanPham_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuXuatNhapSanPham Update(PhieuXuatNhapSanPham item)
        {
            var Item = new PhieuXuatNhapSanPham();
            var obj = new SqlParameter[15];
            obj[0] = new SqlParameter("PXNSP_ID", item.ID);
            obj[1] = new SqlParameter("PXNSP_Ma", item.Ma);
            obj[2] = new SqlParameter("PXNSP_PDV_ID", item.PDV_ID);
            if (item.NgayLap > DateTime.MinValue)
            {
                obj[3] = new SqlParameter("PXNSP_NgayLap", item.NgayLap);
            }
            else
            {
                obj[3] = new SqlParameter("PXNSP_NgayLap", DBNull.Value);
            }
            if (item.NgayXuat > DateTime.MinValue)
            {
                obj[4] = new SqlParameter("PXNSP_NgayXuat", item.NgayXuat);
            }
            else
            {
                obj[4] = new SqlParameter("PXNSP_NgayXuat", DBNull.Value);
            }
            if (item.NgayNhapDuKien > DateTime.MinValue)
            {
                obj[5] = new SqlParameter("PXNSP_NgayNhapDuKien", item.NgayNhapDuKien);
            }
            else
            {
                obj[5] = new SqlParameter("PXNSP_NgayNhapDuKien", DBNull.Value);
            }
            if (item.NgayNhap > DateTime.MinValue)
            {
                obj[6] = new SqlParameter("PXNSP_NgayNhap", item.NgayNhap);
            }
            else
            {
                obj[6] = new SqlParameter("PXNSP_NgayNhap", DBNull.Value);
            }
            obj[7] = new SqlParameter("PXNSP_NguoiXuat", item.NguoiXuat);
            obj[8] = new SqlParameter("PXNSP_NguoiNhap", item.NguoiNhap);
            obj[9] = new SqlParameter("PXNSP_ThuKho", item.ThuKho);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("PXNSP_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("PXNSP_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("PXNSP_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[11] = new SqlParameter("PXNSP_NgayCapNhat", DBNull.Value);
            }
            obj[12] = new SqlParameter("PXNSP_NguoiTao", item.NguoiTao);
            obj[13] = new SqlParameter("PXNSP_Xoa", item.Xoa);
            obj[14] = new SqlParameter("PXNSP_TrangThai", item.TrangThai);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuXuatNhapSanPham_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuXuatNhapSanPham SelectById(SqlConnection con, Guid PXNSP_ID)
        {
            var Item = new PhieuXuatNhapSanPham();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PXNSP_ID", PXNSP_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuXuatNhapSanPham_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuXuatNhapSanPhamCollection SelectAll()
        {
            var List = new PhieuXuatNhapSanPhamCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuXuatNhapSanPham_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<PhieuXuatNhapSanPham> pagerNormal(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string TrangThai, string NhanVien)
        {
            var obj = new SqlParameter[4];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TrangThai))
            {
                obj[2] = new SqlParameter("TrangThai", TrangThai);
            }
            else
            {
                obj[2] = new SqlParameter("TrangThai", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NhanVien))
            {
                obj[3] = new SqlParameter("NhanVien", NhanVien);
            }
            else
            {
                obj[3] = new SqlParameter("NhanVien", DBNull.Value);
            }
            var pg = new Pager<PhieuXuatNhapSanPham>(con, "sp_tblAoCuoi_PhieuXuatNhapSanPham_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static PhieuXuatNhapSanPham getFromReader(IDataReader rd)
        {
            var Item = new PhieuXuatNhapSanPham();
            if (rd.FieldExists("PXNSP_ID"))
            {
                Item.ID = (Guid)(rd["PXNSP_ID"]);
            }
            if (rd.FieldExists("PXNSP_Ma"))
            {
                Item.Ma = (Int32)(rd["PXNSP_Ma"]);
            }
            if (rd.FieldExists("PXNSP_PDV_ID"))
            {
                Item.PDV_ID = (Guid)(rd["PXNSP_PDV_ID"]);
            }
            if (rd.FieldExists("PXNSP_NgayLap"))
            {
                Item.NgayLap = (DateTime)(rd["PXNSP_NgayLap"]);
            }
            if (rd.FieldExists("PXNSP_NgayXuat"))
            {
                Item.NgayXuat = (DateTime)(rd["PXNSP_NgayXuat"]);
            }
            if (rd.FieldExists("PXNSP_NgayNhapDuKien"))
            {
                Item.NgayNhapDuKien = (DateTime)(rd["PXNSP_NgayNhapDuKien"]);
            }
            if (rd.FieldExists("PXNSP_NgayNhap"))
            {
                Item.NgayNhap = (DateTime)(rd["PXNSP_NgayNhap"]);
            }
            if (rd.FieldExists("PXNSP_NguoiXuat"))
            {
                Item.NguoiXuat = (Int32)(rd["PXNSP_NguoiXuat"]);
            }
            if (rd.FieldExists("PXNSP_NguoiNhap"))
            {
                Item.NguoiNhap = (Int32)(rd["PXNSP_NguoiNhap"]);
            }
            if (rd.FieldExists("PXNSP_ThuKho"))
            {
                Item.ThuKho = (Int32)(rd["PXNSP_ThuKho"]);
            }
            if (rd.FieldExists("PXNSP_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["PXNSP_NgayTao"]);
            }
            if (rd.FieldExists("PXNSP_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["PXNSP_NgayCapNhat"]);
            }
            if (rd.FieldExists("PXNSP_NguoiTao"))
            {
                Item.NguoiTao = (Int32)(rd["PXNSP_NguoiTao"]);
            }
            if (rd.FieldExists("PXNSP_Xoa"))
            {
                Item.Xoa = (Boolean)(rd["PXNSP_Xoa"]);
            }
            if (rd.FieldExists("PDV_Ma"))
            {
                Item.PDV_Ma = (Int32)(rd["PDV_Ma"]);
            }
            if (rd.FieldExists("NguoiTao_Ten"))
            {
                Item.NguoiTao_Ten = (String)(rd["NguoiTao_Ten"]);
            }
            if (rd.FieldExists("NguoiXuat_Ten"))
            {
                Item.NguoiXuat_Ten = (String)(rd["NguoiXuat_Ten"]);
            }
            if (rd.FieldExists("NguoiNhap_Ten"))
            {
                Item.NguoiNhap_Ten = (String)(rd["NguoiNhap_Ten"]);
            }
            if (rd.FieldExists("ThuKho_Ten"))
            {
                Item.ThuKho_Ten = (String)(rd["ThuKho_Ten"]);
            }
            if (rd.FieldExists("PXNSP_TrangThai"))
            {
                Item.TrangThai = (Int32)(rd["PXNSP_TrangThai"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static PhieuXuatNhapSanPham SelectDraff(SqlConnection con)
        {
            var Item = new PhieuXuatNhapSanPham();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuXuatNhapSanPham_Select_SelectDraff_linhnx"))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }
        public static PhieuXuatNhapSanPhamCollection SelectTopByHhId(SqlConnection con, int Top, string HH_ID)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Top", Top);
            obj[1] = new SqlParameter("HH_ID", HH_ID);
            var List = new PhieuXuatNhapSanPhamCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuXuatNhapSanPham_Select_SelectTopByHhId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion

    #endregion

    #region PhieuXuatNhapSanPhamChiTiet
    #region BO
    public class PhieuXuatNhapSanPhamChiTiet : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid PXNSP_ID { get; set; }
        public Guid PDV_ID { get; set; }
        public Guid HH_ID { get; set; }
        public Int32 SoLuong { get; set; }
        public Boolean DaXuat { get; set; }
        public Boolean DaNhap { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 NguoiTao { get; set; }
        public Boolean Xoa { get; set; }
        #endregion
        #region Contructor
        public PhieuXuatNhapSanPhamChiTiet()
        { }
        #endregion
        #region Customs properties

        public string HH_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return PhieuXuatNhapSanPhamChiTietDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class PhieuXuatNhapSanPhamChiTietCollection : BaseEntityCollection<PhieuXuatNhapSanPhamChiTiet>
    { }
    #endregion
    #region Dal
    public class PhieuXuatNhapSanPhamChiTietDal
    {
        #region Methods

        public static void DeleteById(Guid PXNSPCT_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PXNSPCT_ID", PXNSPCT_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuXuatNhapSanPhamChiTiet_Delete_DeleteById_linhnx", obj);
        }

        public static PhieuXuatNhapSanPhamChiTiet Insert(PhieuXuatNhapSanPhamChiTiet item)
        {
            var Item = new PhieuXuatNhapSanPhamChiTiet();
            var obj = new SqlParameter[11];
            obj[0] = new SqlParameter("PXNSPCT_ID", item.ID);
            obj[1] = new SqlParameter("PXNSPCT_PXNSP_ID", item.PXNSP_ID);
            obj[2] = new SqlParameter("PXNSPCT_PDV_ID", item.PDV_ID);
            obj[3] = new SqlParameter("PXNSPCT_HH_ID", item.HH_ID);
            obj[4] = new SqlParameter("PXNSPCT_SoLuong", item.SoLuong);
            obj[5] = new SqlParameter("PXNSPCT_DaXuat", item.DaXuat);
            obj[6] = new SqlParameter("PXNSPCT_DaNhap", item.DaNhap);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("PXNSPCT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("PXNSPCT_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("PXNSPCT_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[8] = new SqlParameter("PXNSPCT_NgayCapNhat", DBNull.Value);
            }
            obj[9] = new SqlParameter("PXNSPCT_NguoiTao", item.NguoiTao);
            obj[10] = new SqlParameter("PXNSPCT_Xoa", item.Xoa);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuXuatNhapSanPhamChiTiet_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuXuatNhapSanPhamChiTiet Update(PhieuXuatNhapSanPhamChiTiet item)
        {
            var Item = new PhieuXuatNhapSanPhamChiTiet();
            var obj = new SqlParameter[11];
            obj[0] = new SqlParameter("PXNSPCT_ID", item.ID);
            obj[1] = new SqlParameter("PXNSPCT_PXNSP_ID", item.PXNSP_ID);
            obj[2] = new SqlParameter("PXNSPCT_PDV_ID", item.PDV_ID);
            obj[3] = new SqlParameter("PXNSPCT_HH_ID", item.HH_ID);
            obj[4] = new SqlParameter("PXNSPCT_SoLuong", item.SoLuong);
            obj[5] = new SqlParameter("PXNSPCT_DaXuat", item.DaXuat);
            obj[6] = new SqlParameter("PXNSPCT_DaNhap", item.DaNhap);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("PXNSPCT_NgayTao", item.NgayTao);
            }
            else
            {
                obj[7] = new SqlParameter("PXNSPCT_NgayTao", DBNull.Value);
            }
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("PXNSPCT_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[8] = new SqlParameter("PXNSPCT_NgayCapNhat", DBNull.Value);
            }
            obj[9] = new SqlParameter("PXNSPCT_NguoiTao", item.NguoiTao);
            obj[10] = new SqlParameter("PXNSPCT_Xoa", item.Xoa);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuXuatNhapSanPhamChiTiet_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuXuatNhapSanPhamChiTiet SelectById(Guid PXNSPCT_ID)
        {
            var Item = new PhieuXuatNhapSanPhamChiTiet();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PXNSPCT_ID", PXNSPCT_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuXuatNhapSanPhamChiTiet_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static PhieuXuatNhapSanPhamChiTietCollection SelectAll()
        {
            var List = new PhieuXuatNhapSanPhamChiTietCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuXuatNhapSanPhamChiTiet_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<PhieuXuatNhapSanPhamChiTiet> pagerNormal(string url, bool rewrite, string sort, string q, int size)
        {
            var obj = new SqlParameter[2];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }

            var pg = new Pager<PhieuXuatNhapSanPhamChiTiet>("sp_tblAoCuoi_PhieuXuatNhapSanPhamChiTiet_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static PhieuXuatNhapSanPhamChiTiet getFromReader(IDataReader rd)
        {
            var Item = new PhieuXuatNhapSanPhamChiTiet();
            if (rd.FieldExists("PXNSPCT_ID"))
            {
                Item.ID = (Guid)(rd["PXNSPCT_ID"]);
            }
            if (rd.FieldExists("PXNSPCT_PXNSP_ID"))
            {
                Item.PXNSP_ID = (Guid)(rd["PXNSPCT_PXNSP_ID"]);
            }
            if (rd.FieldExists("PXNSPCT_PDV_ID"))
            {
                Item.PDV_ID = (Guid)(rd["PXNSPCT_PDV_ID"]);
            }
            if (rd.FieldExists("PXNSPCT_HH_ID"))
            {
                Item.HH_ID = (Guid)(rd["PXNSPCT_HH_ID"]);
            }
            if (rd.FieldExists("PXNSPCT_SoLuong"))
            {
                Item.SoLuong = (Int32)(rd["PXNSPCT_SoLuong"]);
            }
            if (rd.FieldExists("PXNSPCT_DaXuat"))
            {
                Item.DaXuat = (Boolean)(rd["PXNSPCT_DaXuat"]);
            }
            if (rd.FieldExists("PXNSPCT_DaNhap"))
            {
                Item.DaNhap = (Boolean)(rd["PXNSPCT_DaNhap"]);
            }
            if (rd.FieldExists("PXNSPCT_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["PXNSPCT_NgayTao"]);
            }
            if (rd.FieldExists("PXNSPCT_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["PXNSPCT_NgayCapNhat"]);
            }
            if (rd.FieldExists("PXNSPCT_NguoiTao"))
            {
                Item.NguoiTao = (Int32)(rd["PXNSPCT_NguoiTao"]);
            }
            if (rd.FieldExists("PXNSPCT_Xoa"))
            {
                Item.Xoa = (Boolean)(rd["PXNSPCT_Xoa"]);
            }
            if (rd.FieldExists("HH_Ten"))
            {
                Item.HH_Ten = (String)(rd["HH_Ten"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static PhieuXuatNhapSanPhamChiTietCollection SelectByPxnSpId(SqlConnection con, string PXNSP_ID)
        {
            var List = new PhieuXuatNhapSanPhamChiTietCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PXNSP_ID", PXNSP_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblAoCuoi_PhieuXuatNhapSanPhamChiTiet_Select_SelectByPxnSpId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        #endregion
    }
    #endregion

    #endregion
}



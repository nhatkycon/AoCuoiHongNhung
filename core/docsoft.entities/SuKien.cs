using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using linh.common;
using linh.controls;
using linh.core;
using linh.core.dal;

namespace docsoft.entities
{
    #region SuKien
    #region BO
    public class SuKien : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid PID { get; set; }
        public Guid DM_ID { get; set; }
        public Guid KH_ID { get; set; }
        public String Ten { get; set; }
        public String MoTa { get; set; }
        public String NhanVien { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public Boolean CaNgay { get; set; }
        public DateTime NgayTao { get; set; }
        public String NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public String NguoiCapNhat { get; set; }
        public Boolean BoQua { get; set; }
        public Boolean Xoa { get; set; }
        public Boolean ThanhCong { get; set; }
        public int Total { get; set; }
        public int PDV_Ma { get; set; }
        public string PDV_MaStr{get { return Lib.FormatMa(PDV_Ma); }}
        public string Url
        {
            get { return string.Format("/lib/pages/LichHen/Add.aspx?ID={0}", ID); }
        }
        public string IndexContent
        {
            get
            {
                return string.Format("{0} {1} {2}"
                                     , Ten, KH_Ten, MoTa);
            }
        }
        public string IndexNoiDung
        {
            get
            {
                return string.Format("Lịch hẹn {0}, Khách hàng: {1}, Mô tả: {2}"
                                     , Ten, KH_Ten, MoTa);
            }
        }
        #endregion
        #region Contructor
        public SuKien()
        { }
        #endregion
        #region Customs properties
        public String NhanVien_Ten { get; set; }
        public String DM_Ten { get; set; }
        public String KH_Ten { get; set; }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return SuKienDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class SuKienCollection : BaseEntityCollection<SuKien>
    { }
    #endregion
    #region Dal
    public class SuKienDal
    {
        #region Methods

        public static void DeleteById(Guid SK_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SK_ID", SK_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Delete_DeleteById_linhnx", obj);
        }

        public static SuKien Insert(SuKien item)
        {
            var Item = new SuKien();
            var obj = new SqlParameter[17];
            obj[0] = new SqlParameter("SK_ID", item.ID);
            obj[1] = new SqlParameter("SK_DM_ID", item.DM_ID);
            obj[2] = new SqlParameter("SK_PID", item.PID);
            obj[3] = new SqlParameter("SK_KH_ID", item.KH_ID);
            obj[4] = new SqlParameter("SK_Ten", item.Ten);
            obj[5] = new SqlParameter("SK_MoTa", item.MoTa);
            obj[6] = new SqlParameter("SK_NhanVien", item.NhanVien);
            if (item.NgayBatDau > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("SK_NgayBatDau", item.NgayBatDau);
            }
            else
            {
                obj[7] = new SqlParameter("SK_NgayBatDau", DBNull.Value);
            }
            if (item.NgayKetThuc > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("SK_NgayKetThuc", item.NgayKetThuc);
            }
            else
            {
                obj[8] = new SqlParameter("SK_NgayKetThuc", DBNull.Value);
            }
            obj[9] = new SqlParameter("SK_CaNgay", item.CaNgay);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("SK_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("SK_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("SK_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("SK_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[12] = new SqlParameter("SK_NgayCapNhat", DBNull.Value);
            }
            obj[13] = new SqlParameter("SK_NguoiCapNhat", item.NguoiCapNhat);
            obj[14] = new SqlParameter("SK_BoQua", item.BoQua);
            obj[15] = new SqlParameter("SK_Xoa", item.Xoa);
            obj[16] = new SqlParameter("SK_ThanhCong", item.ThanhCong);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SuKien Update(SuKien item)
        {
            var Item = new SuKien();
            var obj = new SqlParameter[17];
            obj[0] = new SqlParameter("SK_ID", item.ID);
            obj[1] = new SqlParameter("SK_DM_ID", item.DM_ID);
            obj[2] = new SqlParameter("SK_PID", item.PID);
            obj[3] = new SqlParameter("SK_KH_ID", item.KH_ID);
            obj[4] = new SqlParameter("SK_Ten", item.Ten);
            obj[5] = new SqlParameter("SK_MoTa", item.MoTa);
            obj[6] = new SqlParameter("SK_NhanVien", item.NhanVien);
            if (item.NgayBatDau > DateTime.MinValue)
            {
                obj[7] = new SqlParameter("SK_NgayBatDau", item.NgayBatDau);
            }
            else
            {
                obj[7] = new SqlParameter("SK_NgayBatDau", DBNull.Value);
            }
            if (item.NgayKetThuc > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("SK_NgayKetThuc", item.NgayKetThuc);
            }
            else
            {
                obj[8] = new SqlParameter("SK_NgayKetThuc", DBNull.Value);
            }
            obj[9] = new SqlParameter("SK_CaNgay", item.CaNgay);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[10] = new SqlParameter("SK_NgayTao", item.NgayTao);
            }
            else
            {
                obj[10] = new SqlParameter("SK_NgayTao", DBNull.Value);
            }
            obj[11] = new SqlParameter("SK_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[12] = new SqlParameter("SK_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[12] = new SqlParameter("SK_NgayCapNhat", DBNull.Value);
            }
            obj[13] = new SqlParameter("SK_NguoiCapNhat", item.NguoiCapNhat);
            obj[14] = new SqlParameter("SK_BoQua", item.BoQua);
            obj[15] = new SqlParameter("SK_Xoa", item.Xoa);
            obj[16] = new SqlParameter("SK_ThanhCong", item.ThanhCong);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SuKien SelectById(Guid SK_ID)
        {
            var Item = new SuKien();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("SK_ID", SK_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static SuKienCollection SelectAll()
        {
            var List = new SuKienCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<SuKien> pagerNormal(string url, bool rewrite, string sort, string q
            , int size
            ,string DM_ID, string KH_ID, string NhanVien, string BoQua, string Xoa, string TuNgay, string DenNgay)
        {
            var obj = new SqlParameter[9];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DM_ID))
            {
                obj[2] = new SqlParameter("DM_ID", DM_ID);
            }
            else
            {
                obj[2] = new SqlParameter("DM_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(KH_ID))
            {
                obj[3] = new SqlParameter("KH_ID", KH_ID);
            }
            else
            {
                obj[3] = new SqlParameter("KH_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NhanVien))
            {
                obj[4] = new SqlParameter("NhanVien", NhanVien);
            }
            else
            {
                obj[4] = new SqlParameter("NhanVien", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(BoQua))
            {
                obj[5] = new SqlParameter("BoQua", BoQua);
            }
            else
            {
                obj[5] = new SqlParameter("BoQua", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(Xoa))
            {
                obj[6] = new SqlParameter("Xoa", Xoa);
            }
            else
            {
                obj[6] = new SqlParameter("Xoa", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[7] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[7] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[8] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[8] = new SqlParameter("DenNgay", DBNull.Value);
            }
            var pg = new Pager<SuKien>("sp_tblSpaMgr_SuKien_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static SuKien getFromReader(IDataReader rd)
        {
            var Item = new SuKien();
            if (rd.FieldExists("SK_ID"))
            {
                Item.ID = (Guid)(rd["SK_ID"]);
            }
            if (rd.FieldExists("SK_DM_ID"))
            {
                Item.DM_ID = (Guid)(rd["SK_DM_ID"]);
            }
            if (rd.FieldExists("SK_PID"))
            {
                Item.PID = (Guid)(rd["SK_PID"]);
            }
            if (rd.FieldExists("SK_KH_ID"))
            {
                Item.KH_ID = (Guid)(rd["SK_KH_ID"]);
            }
            if (rd.FieldExists("SK_Ten"))
            {
                Item.Ten = (String)(rd["SK_Ten"]);
            }
            if (rd.FieldExists("SK_MoTa"))
            {
                Item.MoTa = (String)(rd["SK_MoTa"]);
            }
            if (rd.FieldExists("SK_NhanVien"))
            {
                Item.NhanVien = (String)(rd["SK_NhanVien"]);
            }
            if (rd.FieldExists("SK_NgayBatDau"))
            {
                Item.NgayBatDau = (DateTime)(rd["SK_NgayBatDau"]);
            }
            if (rd.FieldExists("SK_NgayKetThuc"))
            {
                Item.NgayKetThuc = (DateTime)(rd["SK_NgayKetThuc"]);
            }
            if (rd.FieldExists("SK_CaNgay"))
            {
                Item.CaNgay = (Boolean)(rd["SK_CaNgay"]);
            }
            if (rd.FieldExists("SK_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["SK_NgayTao"]);
            }
            if (rd.FieldExists("SK_NguoiTao"))
            {
                Item.NguoiTao = (String)(rd["SK_NguoiTao"]);
            }
            if (rd.FieldExists("SK_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["SK_NgayCapNhat"]);
            }
            if (rd.FieldExists("SK_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (String)(rd["SK_NguoiCapNhat"]);
            }
            if (rd.FieldExists("SK_BoQua"))
            {
                Item.BoQua = (Boolean)(rd["SK_BoQua"]);
            }
            if (rd.FieldExists("SK_Xoa"))
            {
                Item.Xoa = (Boolean)(rd["SK_Xoa"]);
            }
            if (rd.FieldExists("SK_NhanVien_Ten"))
            {
                Item.NhanVien_Ten = (String)(rd["SK_NhanVien_Ten"]);
            }
            if (rd.FieldExists("SK_DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["SK_DM_Ten"]);
            }
            if (rd.FieldExists("KH_Ten"))
            {
                Item.KH_Ten = (String)(rd["KH_Ten"]);
                if(!string.IsNullOrEmpty(Item.KH_Ten) && Item.KH_ID != Guid.Empty)
                {
                    Item.KH_Ten = maHoa.DecryptString(Item.KH_Ten, Item.KH_ID.ToString());
                }
            }
            if (rd.FieldExists("SK_ThanhCong"))
            {
                Item.ThanhCong = (Boolean)(rd["SK_ThanhCong"]);
            }
            if (rd.FieldExists("SK_Total"))
            {
                Item.Total = (Int32)(rd["SK_Total"]);
            }
            if (rd.FieldExists("PDV_Ma"))
            {
                Item.PDV_Ma = (Int32)(rd["PDV_Ma"]);
            }
            return Item;
        }
        #endregion

        #region Extend

        public static SuKienCollection SelectUnXoa(SqlConnection con, string xoa, string top)
        {
            var List = new SuKienCollection();
            var obj = new SqlParameter[2];
            if (!string.IsNullOrEmpty(xoa))
            {
                obj[0] = new SqlParameter("xoa", xoa);
            }
            else
            {
                obj[0] = new SqlParameter("xoa", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(top))
            {
                obj[1] = new SqlParameter("top", top);
            }
            else
            {
                obj[1] = new SqlParameter("top", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectUnXoa_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SuKienCollection SelectByKhId(SqlConnection con,string xoa, string top, string KH_ID)
        {
            var List = new SuKienCollection();
            var obj = new SqlParameter[3];
            if (!string.IsNullOrEmpty(xoa))
            {
                obj[0] = new SqlParameter("xoa", xoa);
            }
            else
            {
                obj[0] = new SqlParameter("xoa", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(top))
            {
                obj[1] = new SqlParameter("top", top);
            }
            else
            {
                obj[1] = new SqlParameter("top", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(KH_ID))
            {
                obj[2] = new SqlParameter("KH_ID", KH_ID);
            }
            else
            {
                obj[2] = new SqlParameter("KH_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectByKhId_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SuKienCollection SelectUpcoming(SqlConnection con, string top)
        {
            var List = new SuKienCollection();
            var obj = new SqlParameter[2];

            if (!string.IsNullOrEmpty(top))
            {
                obj[1] = new SqlParameter("top", top);
            }
            else
            {
                obj[1] = new SqlParameter("top", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectUpcoming_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SuKienCollection SelectPhieuDichVuEventsViewer(SqlConnection con, string tuNgay, string denNgay, string NhanVien_Id)
        {
            var List = new SuKienCollection();
            var obj = new SqlParameter[3];
            if (!string.IsNullOrEmpty(denNgay))
            {
                obj[0] = new SqlParameter("denNgay", denNgay);
            }
            else
            {
                obj[0] = new SqlParameter("denNgay", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(tuNgay))
            {
                obj[1] = new SqlParameter("tuNgay", tuNgay);
            }
            else
            {
                obj[1] = new SqlParameter("tuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NhanVien_Id))
            {
                obj[2] = new SqlParameter("NhanVien_Id", NhanVien_Id);
            }
            else
            {
                obj[2] = new SqlParameter("NhanVien_Id", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectPhieuDichVuEventsViewer_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static SuKienCollection SelectForCalendar(SqlConnection con, DateTime tuNgay, DateTime denNgay)
        {
            return SelectForCalendar(con,tuNgay,denNgay,null);
        }
        public static SuKienCollection SelectForCalendar(SqlConnection con, DateTime tuNgay, DateTime denNgay, string NhanVien_Id)
        {
            var List = new SuKienCollection();
            var obj = new SqlParameter[3];
            if (denNgay > DateTime.MinValue)
            {
                obj[0] = new SqlParameter("denNgay", denNgay);
            }
            else
            {
                obj[0] = new SqlParameter("denNgay", DBNull.Value);
            }

            if (tuNgay > DateTime.MinValue)
            {
                obj[1] = new SqlParameter("tuNgay", tuNgay);
            }
            else
            {
                obj[1] = new SqlParameter("tuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NhanVien_Id))
            {
                obj[2] = new SqlParameter("NhanVien_Id", NhanVien_Id);
            }
            else
            {
                obj[2] = new SqlParameter("NhanVien_Id", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectForCalendar_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static SuKienCollection SelectPhieuDichVuForCalendar(SqlConnection con, DateTime tuNgay, DateTime denNgay, string NhanVien_Id)
        {
            var List = new SuKienCollection();
            var obj = new SqlParameter[3];
            if (denNgay > DateTime.MinValue)
            {
                obj[0] = new SqlParameter("denNgay", denNgay);
            }
            else
            {
                obj[0] = new SqlParameter("denNgay", DBNull.Value);
            }

            if (tuNgay > DateTime.MinValue)
            {
                obj[1] = new SqlParameter("tuNgay", tuNgay);
            }
            else
            {
                obj[1] = new SqlParameter("tuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NhanVien_Id))
            {
                obj[2] = new SqlParameter("NhanVien_Id", NhanVien_Id);
            }
            else
            {
                obj[2] = new SqlParameter("NhanVien_Id", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectPhieuDichVuForCalendar_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }


        public static SuKienCollection SelectPhieuDichVuForCalendarPts(SqlConnection con, DateTime tuNgay, DateTime denNgay, string NhanVien_Id)
        {
            var List = new SuKienCollection();
            var obj = new SqlParameter[3];
            if (denNgay > DateTime.MinValue)
            {
                obj[0] = new SqlParameter("denNgay", denNgay);
            }
            else
            {
                obj[0] = new SqlParameter("denNgay", DBNull.Value);
            }

            if (tuNgay > DateTime.MinValue)
            {
                obj[1] = new SqlParameter("tuNgay", tuNgay);
            }
            else
            {
                obj[1] = new SqlParameter("tuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NhanVien_Id))
            {
                obj[2] = new SqlParameter("NhanVien_Id", NhanVien_Id);
            }
            else
            {
                obj[2] = new SqlParameter("NhanVien_Id", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectPhieuDichVuForCalendarPts_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static SuKienCollection SelectPhieuDichVuForVay(SqlConnection con, DateTime tuNgay, DateTime denNgay, string HH_ID)
        {
            var List = new SuKienCollection();
            var obj = new SqlParameter[3];
            if (denNgay > DateTime.MinValue)
            {
                obj[0] = new SqlParameter("denNgay", denNgay);
            }
            else
            {
                obj[0] = new SqlParameter("denNgay", DBNull.Value);
            }

            if (tuNgay > DateTime.MinValue)
            {
                obj[1] = new SqlParameter("tuNgay", tuNgay);
            }
            else
            {
                obj[1] = new SqlParameter("tuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(HH_ID))
            {
                obj[2] = new SqlParameter("HH_ID", HH_ID);
            }
            else
            {
                obj[2] = new SqlParameter("HH_ID", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectLichForVay_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static SuKienCollection SelectPhieuDichVuForCalendarTd(SqlConnection con, DateTime tuNgay, DateTime denNgay, string NhanVien_Id)
        {
            var List = new SuKienCollection();
            var obj = new SqlParameter[3];
            if (denNgay > DateTime.MinValue)
            {
                obj[0] = new SqlParameter("denNgay", denNgay);
            }
            else
            {
                obj[0] = new SqlParameter("denNgay", DBNull.Value);
            }

            if (tuNgay > DateTime.MinValue)
            {
                obj[1] = new SqlParameter("tuNgay", tuNgay);
            }
            else
            {
                obj[1] = new SqlParameter("tuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NhanVien_Id))
            {
                obj[2] = new SqlParameter("NhanVien_Id", NhanVien_Id);
            }
            else
            {
                obj[2] = new SqlParameter("NhanVien_Id", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectPhieuDichVuForCalendarTd_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static SuKienCollection SelectPhieuDichVuForCalendarTdToc(SqlConnection con, DateTime tuNgay, DateTime denNgay, string NhanVien_Id)
        {
            var List = new SuKienCollection();
            var obj = new SqlParameter[3];
            if (denNgay > DateTime.MinValue)
            {
                obj[0] = new SqlParameter("denNgay", denNgay);
            }
            else
            {
                obj[0] = new SqlParameter("denNgay", DBNull.Value);
            }

            if (tuNgay > DateTime.MinValue)
            {
                obj[1] = new SqlParameter("tuNgay", tuNgay);
            }
            else
            {
                obj[1] = new SqlParameter("tuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NhanVien_Id))
            {
                obj[2] = new SqlParameter("NhanVien_Id", NhanVien_Id);
            }
            else
            {
                obj[2] = new SqlParameter("NhanVien_Id", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectPhieuDichVuForCalendarTdToc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }

        public static SuKienCollection SelectPhieuDichVuForCalendarToc(SqlConnection con, DateTime tuNgay, DateTime denNgay, string NhanVien_Id)
        {
            var List = new SuKienCollection();
            var obj = new SqlParameter[3];
            if (denNgay > DateTime.MinValue)
            {
                obj[0] = new SqlParameter("denNgay", denNgay);
            }
            else
            {
                obj[0] = new SqlParameter("denNgay", DBNull.Value);
            }

            if (tuNgay > DateTime.MinValue)
            {
                obj[1] = new SqlParameter("tuNgay", tuNgay);
            }
            else
            {
                obj[1] = new SqlParameter("tuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NhanVien_Id))
            {
                obj[2] = new SqlParameter("NhanVien_Id", NhanVien_Id);
            }
            else
            {
                obj[2] = new SqlParameter("NhanVien_Id", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectPhieuDichVuForCalendarToc_linhnx", obj))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static SuKienCollection SelectPhieuDichVuForCalendarChupAnh(SqlConnection con, DateTime tuNgay, DateTime denNgay, string NhanVien_Id)
        {
            var List = new SuKienCollection();
            var obj = new SqlParameter[3];
            if (denNgay > DateTime.MinValue)
            {
                obj[0] = new SqlParameter("denNgay", denNgay);
            }
            else
            {
                obj[0] = new SqlParameter("denNgay", DBNull.Value);
            }

            if (tuNgay > DateTime.MinValue)
            {
                obj[1] = new SqlParameter("tuNgay", tuNgay);
            }
            else
            {
                obj[1] = new SqlParameter("tuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NhanVien_Id))
            {
                obj[2] = new SqlParameter("NhanVien_Id", NhanVien_Id);
            }
            else
            {
                obj[2] = new SqlParameter("NhanVien_Id", DBNull.Value);
            }
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblSpaMgr_SuKien_Select_SelectPhieuDichVuForCalendarChupAnh_linhnx", obj))
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

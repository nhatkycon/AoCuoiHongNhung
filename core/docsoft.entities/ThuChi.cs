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
    #region ThuChi
    #region BO
    public class ThuChi : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid NDTC_ID { get; set; }
        public Int32 CQ_ID { get; set; }
        public String MaPhieu { get; set; }
        public Int32 SoPhieu { get; set; }
        public Int32 SoPhieuAll { get; set; }
        public Double SoTien { get; set; }
        public String Mota { get; set; }
        public DateTime NgayTrenPhieu { get; set; }
        public DateTime NgayTao { get; set; }
        public Int32 NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 NguoiCapNhat { get; set; }
        public Int32 LoaiQuy { get; set; }
        public Int32 LoaiCandoi { get; set; }
        public Boolean isCandoi { get; set; }
        public Boolean Thu { get; set; }
        public Guid XN_ID { get; set; }
        public Guid P_ID { get; set; }
        public Guid PDV_ID { get; set; }
        public Guid CTV_ID { get; set; }
        public Guid PGV_ID { get; set; }
        #endregion
        #region Contructor
        public ThuChi()
        { }
        #endregion
        #region Customs properties

        public string NDTC_Ten { get; set; }
        public string P_Ten { get; set; }
        public string NguoiTao_Ten { get; set; }
        public string NguoiCapNhat_Ten { get; set; }
        public int PDV_Ma { get; set; }
        public string PDV_MaStr
        {
            get
            {
                return Lib.FormatMa(PDV_Ma); 
            }
        }

        public int CTV_Ma { get; set; }
        public int PGV_Ma { get; set; }
        public string CTV_MaStr
        {
            get { return Lib.FormatMa(CTV_Ma); }
        }
        public string PGV_MaStr
        {
            get { return Lib.FormatMa(PGV_Ma); }
        }
        public string Ma
        {
            get { return Lib.FormatMa(SoPhieu); }
        }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return ThuChiDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class ThuChiCollection : BaseEntityCollection<ThuChi>
    { }
    #endregion
    #region Dal
    public class ThuChiDal
    {
        #region Methods

        public static void DeleteById(Guid TC_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TC_ID", TC_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChi_Delete_DeleteById_linhnx", obj);
        }

        public static ThuChi Insert(ThuChi item)
        {
            var Item = new ThuChi();
            var obj = new SqlParameter[22];
            obj[0] = new SqlParameter("TC_ID", item.ID);
            obj[1] = new SqlParameter("TC_NDTC_ID", item.NDTC_ID);
            obj[2] = new SqlParameter("TC_CQ_ID", item.CQ_ID);
            obj[3] = new SqlParameter("TC_MaPhieu", item.MaPhieu);
            obj[4] = new SqlParameter("TC_SoPhieu", item.SoPhieu);
            obj[5] = new SqlParameter("TC_SoPhieuAll", item.SoPhieuAll);
            obj[6] = new SqlParameter("TC_SoTien", item.SoTien);
            obj[7] = new SqlParameter("TC_Mota", item.Mota);
            if (item.NgayTrenPhieu > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("TC_NgayTrenPhieu", item.NgayTrenPhieu);
            }
            else
            {
                obj[8] = new SqlParameter("TC_NgayTrenPhieu", DBNull.Value);
            }
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("TC_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("TC_NgayTao", DBNull.Value);
            }
            obj[10] = new SqlParameter("TC_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("TC_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[11] = new SqlParameter("TC_NgayCapNhat", DBNull.Value);
            }
            obj[12] = new SqlParameter("TC_NguoiCapNhat", item.NguoiCapNhat);
            obj[13] = new SqlParameter("TC_LoaiQuy", item.LoaiQuy);
            obj[14] = new SqlParameter("TC_LoaiCandoi", item.LoaiCandoi);
            obj[15] = new SqlParameter("TC_isCandoi", item.isCandoi);
            obj[16] = new SqlParameter("TC_Thu", item.Thu);
            obj[17] = new SqlParameter("TC_XN_ID", item.XN_ID);
            obj[18] = new SqlParameter("TC_P_ID", item.P_ID);
            obj[19] = new SqlParameter("TC_PDV_ID", item.PDV_ID);
            obj[20] = new SqlParameter("TC_CTV_ID", item.CTV_ID);
            obj[21] = new SqlParameter("TC_PGV_ID", item.PGV_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChi_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuChi Update(ThuChi item)
        {
            var Item = new ThuChi();
            var obj = new SqlParameter[22];
            obj[0] = new SqlParameter("TC_ID", item.ID);
            obj[1] = new SqlParameter("TC_NDTC_ID", item.NDTC_ID);
            obj[2] = new SqlParameter("TC_CQ_ID", item.CQ_ID);
            obj[3] = new SqlParameter("TC_MaPhieu", item.MaPhieu);
            obj[4] = new SqlParameter("TC_SoPhieu", item.SoPhieu);
            obj[5] = new SqlParameter("TC_SoPhieuAll", item.SoPhieuAll);
            obj[6] = new SqlParameter("TC_SoTien", item.SoTien);
            obj[7] = new SqlParameter("TC_Mota", item.Mota);
            if (item.NgayTrenPhieu > DateTime.MinValue)
            {
                obj[8] = new SqlParameter("TC_NgayTrenPhieu", item.NgayTrenPhieu);
            }
            else
            {
                obj[8] = new SqlParameter("TC_NgayTrenPhieu", DBNull.Value);
            }
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[9] = new SqlParameter("TC_NgayTao", item.NgayTao);
            }
            else
            {
                obj[9] = new SqlParameter("TC_NgayTao", DBNull.Value);
            }
            obj[10] = new SqlParameter("TC_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[11] = new SqlParameter("TC_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[11] = new SqlParameter("TC_NgayCapNhat", DBNull.Value);
            }
            obj[12] = new SqlParameter("TC_NguoiCapNhat", item.NguoiCapNhat);
            obj[13] = new SqlParameter("TC_LoaiQuy", item.LoaiQuy);
            obj[14] = new SqlParameter("TC_LoaiCandoi", item.LoaiCandoi);
            obj[15] = new SqlParameter("TC_isCandoi", item.isCandoi);
            obj[16] = new SqlParameter("TC_Thu", item.Thu);
            obj[17] = new SqlParameter("TC_XN_ID", item.XN_ID);
            obj[18] = new SqlParameter("TC_P_ID", item.P_ID);
            obj[19] = new SqlParameter("TC_PDV_ID", item.PDV_ID);
            obj[20] = new SqlParameter("TC_CTV_ID", item.CTV_ID);
            obj[21] = new SqlParameter("TC_PGV_ID", item.PGV_ID);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChi_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuChi SelectById(Guid TC_ID)
        {
            return SelectById(DAL.con(), TC_ID);
        }
        public static ThuChi SelectById(SqlConnection con, Guid TC_ID)
        {
            var Item = new ThuChi();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("TC_ID", TC_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblThuChi_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuChiCollection SelectAll()
        {
            var List = new ThuChiCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblThuChi_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<ThuChi> pagerNormal(SqlConnection con, string url, bool rewrite, string sort, string q, int size
            , bool Thu
            , string NDTC_ID
            , string TuNgay
            , string DenNgay)
        {
            var obj = new SqlParameter[6];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NDTC_ID))
            {
                obj[2] = new SqlParameter("NDTC_ID", NDTC_ID);
            }
            else
            {
                obj[2] = new SqlParameter("NDTC_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[3] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[3] = new SqlParameter("DenNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[4] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[4] = new SqlParameter("TuNgay", DBNull.Value);
            }
            obj[5] = new SqlParameter("Thu", Thu);

            var pg = new Pager<ThuChi>(con, "sp_tblThuChi_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static ThuChi getFromReader(IDataReader rd)
        {
            var Item = new ThuChi();
            if (rd.FieldExists("TC_ID"))
            {
                Item.ID = (Guid)(rd["TC_ID"]);
            }
            if (rd.FieldExists("TC_NDTC_ID"))
            {
                Item.NDTC_ID = (Guid)(rd["TC_NDTC_ID"]);
            }
            if (rd.FieldExists("TC_CQ_ID"))
            {
                Item.CQ_ID = (Int32)(rd["TC_CQ_ID"]);
            }
            if (rd.FieldExists("TC_MaPhieu"))
            {
                Item.MaPhieu = (String)(rd["TC_MaPhieu"]);
            }
            if (rd.FieldExists("TC_SoPhieu"))
            {
                Item.SoPhieu = (Int32)(rd["TC_SoPhieu"]);
            }
            if (rd.FieldExists("TC_SoPhieuAll"))
            {
                Item.SoPhieuAll = (Int32)(rd["TC_SoPhieuAll"]);
            }
            if (rd.FieldExists("TC_SoTien"))
            {
                Item.SoTien = (Double)(rd["TC_SoTien"]);
            }
            if (rd.FieldExists("TC_Mota"))
            {
                Item.Mota = (String)(rd["TC_Mota"]);
            }
            if (rd.FieldExists("TC_NgayTrenPhieu"))
            {
                Item.NgayTrenPhieu = (DateTime)(rd["TC_NgayTrenPhieu"]);
            }
            if (rd.FieldExists("TC_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["TC_NgayTao"]);
            }
            if (rd.FieldExists("TC_NguoiTao"))
            {
                Item.NguoiTao = (Int32)(rd["TC_NguoiTao"]);
            }
            if (rd.FieldExists("TC_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["TC_NgayCapNhat"]);
            }
            if (rd.FieldExists("TC_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (Int32)(rd["TC_NguoiCapNhat"]);
            }
            if (rd.FieldExists("TC_LoaiQuy"))
            {
                Item.LoaiQuy = (Int32)(rd["TC_LoaiQuy"]);
            }
            if (rd.FieldExists("TC_LoaiCandoi"))
            {
                Item.LoaiCandoi = (Int32)(rd["TC_LoaiCandoi"]);
            }
            if (rd.FieldExists("TC_isCandoi"))
            {
                Item.isCandoi = (Boolean)(rd["TC_isCandoi"]);
            }
            if (rd.FieldExists("TC_Thu"))
            {
                Item.Thu = (Boolean)(rd["TC_Thu"]);
            }
            if (rd.FieldExists("TC_XN_ID"))
            {
                Item.XN_ID = (Guid)(rd["TC_XN_ID"]);
            }
            if (rd.FieldExists("TC_P_ID"))
            {
                Item.P_ID = (Guid)(rd["TC_P_ID"]);
            }
            if (rd.FieldExists("TC_PDV_ID"))
            {
                Item.PDV_ID = (Guid)(rd["TC_PDV_ID"]);
            }
            if (rd.FieldExists("TC_CTV_ID"))
            {
                Item.CTV_ID = (Guid)(rd["TC_CTV_ID"]);
            }
            if (rd.FieldExists("TC_PGV_ID"))
            {
                Item.PGV_ID = (Guid)(rd["TC_PGV_ID"]);
            }

            if (rd.FieldExists("CTV_Ma"))
            {
                Item.CTV_Ma = (Int32)(rd["CTV_Ma"]);
            }

            if (rd.FieldExists("PGV_Ma"))
            {
                Item.PGV_Ma = (Int32)(rd["PGV_Ma"]);
            }

            if (rd.FieldExists("PDV_Ma"))
            {
                Item.PDV_Ma = (Int32)(rd["PDV_Ma"]);
            }
            if (rd.FieldExists("P_Ten"))
            {
                Item.P_Ten = (String)(rd["P_Ten"]);
                if(!string.IsNullOrEmpty(Item.P_Ten) && Item.P_ID != Guid.Empty)
                {
                    Item.P_Ten = maHoa.DecryptString(Item.P_Ten, Item.P_ID.ToString());                    
                }
            }
            if (rd.FieldExists("NDTC_Ten"))
            {
                Item.NDTC_Ten = (String)(rd["NDTC_Ten"]);
            }
            if (rd.FieldExists("NguoiTao_Ten"))
            {
                Item.NguoiTao_Ten = (String)(rd["NguoiTao_Ten"]);
            }
            if (rd.FieldExists("NguoiCapNhat_Ten"))
            {
                Item.NguoiCapNhat_Ten = (String)(rd["NguoiCapNhat_Ten"]);
            }
            return Item;  
        }
        #endregion

        #region Extend
        public static Pager<ThuChi> pagerTuNgayDenNgay(string sort, string q, int size, bool? Thu,string TuNgay, string DenNgay, string NDTC_ID)
        {
            return pagerTuNgayDenNgay(sort, q, size, Thu, TuNgay, DenNgay, NDTC_ID, null, false);
        }
        public static Pager<ThuChi> pagerTuNgayDenNgay(string sort, string q, int size, bool? Thu, string TuNgay, string DenNgay, string NDTC_ID, string P_ID)
        {
            return pagerTuNgayDenNgay(sort, q, size, Thu, TuNgay, DenNgay, NDTC_ID, P_ID, null);
        }
        public static Pager<ThuChi> pagerTuNgayDenNgay(string sort, string q, int size, bool? Thu, string TuNgay, string DenNgay, string NDTC_ID, string P_ID, bool? isCanDoi)
        {
            var obj = new SqlParameter[8];
            obj[0] = new SqlParameter("Sort", sort);
            if (!string.IsNullOrEmpty(q))
            {
                obj[1] = new SqlParameter("q", q);
            }
            else
            {
                obj[1] = new SqlParameter("q", DBNull.Value);
            }
            if (Thu != null)
            {
                obj[2] = new SqlParameter("Thu", Thu);
            }
            else
            {
                obj[2] = new SqlParameter("Thu", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(TuNgay))
            {
                obj[3] = new SqlParameter("TuNgay", TuNgay);
            }
            else
            {
                obj[3] = new SqlParameter("TuNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(DenNgay))
            {
                obj[4] = new SqlParameter("DenNgay", DenNgay);
            }
            else
            {
                obj[4] = new SqlParameter("DenNgay", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(NDTC_ID))
            {
                obj[5] = new SqlParameter("NDTC_ID", NDTC_ID);
            }
            else
            {
                obj[5] = new SqlParameter("NDTC_ID", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(P_ID))
            {
                obj[6] = new SqlParameter("P_ID", P_ID);
            }
            else
            {
                obj[6] = new SqlParameter("P_ID", DBNull.Value);
            }
            if (isCanDoi != null)
            {
                obj[7] = new SqlParameter("isCanDoi", isCanDoi);
            }
            else
            {
                obj[7] = new SqlParameter("isCanDoi", DBNull.Value);
            }
            var pg = new Pager<ThuChi>("sp_tblThuChi_Pager_pagerTuNgayDenNgay_linhnx", "page", size, 10, false, string.Empty, obj);
            return pg;
        }
        public static ThuChi SelectByDraff(SqlConnection con, bool Thu)
        {
            var Item = new ThuChi();
            var obj = new SqlParameter[3];
            obj[0] = new SqlParameter("Thu", Thu);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblThuChi_Select_SelectDraff_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static ThuChiCollection SelectByPdvId(SqlConnection con, Guid PDV_ID)
        {
            var List = new ThuChiCollection();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("PDV_ID", PDV_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_tblThuChi_Select_SelectByPdvId_linhnx", obj))
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using linh.common;
using linh.controls;
using linh.core.dal;
using linh.core;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace docsoft.entities
{
    #region HangHoa
    #region BO
    public class HangHoa : BaseEntity
    {
        #region Properties
        public Guid ID { get; set; }
        public Guid DM_ID { get; set; }
        public String Alias { get; set; }
        public String Ten { get; set; }
        public String Ma { get; set; }
        public String Keywords { get; set; }
        public String Description { get; set; }
        public String MoTa { get; set; }
        public String NoiDung { get; set; }
        public Double GNY { get; set; }
        public Double GiaNhap { get; set; }
        public Double GiaMax { get; set; }
        public Double GiaMin { get; set; }
        public String DonVi { get; set; }
        public Guid DonVi_ID { get; set; }
        public Double SoLuong { get; set; }
        public Guid RowId { get; set; }
        public DateTime NgayTao { get; set; }
        public Int32 NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public Int32 NguoiCapNhat { get; set; }
        public String Anh { get; set; }
        public Boolean DichVu { get; set; }
        public Boolean Publish { get; set; }
        public Boolean Active { get; set; }
        public Boolean Home { get; set; }
        public Boolean Draff { get; set; }
        public Double TonDinhMuc { get; set; }
        public Boolean HetHang { get; set; }
        public Boolean KhoVay { get; set; }
        public Boolean HongVay { get; set; }
        #endregion
        #region Contructor
        public HangHoa()
        { }
        #endregion
        #region Customs properties

        public string DM_Ten { get; set; }
        public string NguoiTao_Ten { get; set; }
        public string NguoiCapNhat_Ten { get; set; }
        public string Hint
        {
            get { return string.Format("{0} {1} {2}", Ten, MoTa, Ma); }
        }
        #endregion
        public override BaseEntity getFromReader(IDataReader rd)
        {
            return HangHoaDal.getFromReader(rd);
        }
    }
    #endregion
    #region Collection
    public class HangHoaCollection : BaseEntityCollection<HangHoa>
    { }
    #endregion
    #region Dal
    public class HangHoaDal
    {
        #region Methods

        public static void DeleteById(Guid HH_ID)
        {
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HH_ID", HH_ID);
            SqlHelper.ExecuteNonQuery(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Delete_DeleteById_linhnx", obj);
        }

        public static HangHoa Insert(HangHoa item)
        {
            var Item = new HangHoa();
            var obj = new SqlParameter[31];
            obj[0] = new SqlParameter("HH_ID", item.ID);
            obj[1] = new SqlParameter("HH_DM_ID", item.DM_ID);
            obj[2] = new SqlParameter("HH_Alias", item.Alias);
            obj[3] = new SqlParameter("HH_Ten", item.Ten);
            obj[4] = new SqlParameter("HH_Ma", item.Ma);
            obj[5] = new SqlParameter("HH_Keywords", item.Keywords);
            obj[6] = new SqlParameter("HH_Description", item.Description);
            obj[7] = new SqlParameter("HH_MoTa", item.MoTa);
            obj[8] = new SqlParameter("HH_NoiDung", item.NoiDung);
            obj[9] = new SqlParameter("HH_GNY", item.GNY);
            obj[10] = new SqlParameter("HH_GiaNhap", item.GiaNhap);
            obj[11] = new SqlParameter("HH_GiaMax", item.GiaMax);
            obj[12] = new SqlParameter("HH_GiaMin", item.GiaMin);
            obj[13] = new SqlParameter("HH_DonVi", item.DonVi);
            obj[14] = new SqlParameter("HH_DonVi_ID", item.DonVi_ID);
            obj[15] = new SqlParameter("HH_SoLuong", item.SoLuong);
            obj[16] = new SqlParameter("HH_RowId", item.RowId);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[17] = new SqlParameter("HH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[17] = new SqlParameter("HH_NgayTao", DBNull.Value);
            }
            obj[18] = new SqlParameter("HH_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[19] = new SqlParameter("HH_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[19] = new SqlParameter("HH_NgayCapNhat", DBNull.Value);
            }
            obj[20] = new SqlParameter("HH_NguoiCapNhat", item.NguoiCapNhat);
            obj[21] = new SqlParameter("HH_Anh", item.Anh);
            obj[22] = new SqlParameter("HH_DichVu", item.DichVu);
            obj[23] = new SqlParameter("HH_Publish", item.Publish);
            obj[24] = new SqlParameter("HH_Active", item.Active);
            obj[25] = new SqlParameter("HH_Home", item.Home);
            obj[26] = new SqlParameter("HH_Draff", item.Draff);
            obj[27] = new SqlParameter("HH_TonDinhMuc", item.TonDinhMuc);
            obj[28] = new SqlParameter("HH_HetHang", item.HetHang);
            obj[29] = new SqlParameter("HH_KhoVay", item.KhoVay);
            obj[30] = new SqlParameter("HH_HongVay", item.HongVay);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Insert_InsertNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static HangHoa Update(HangHoa item)
        {
            var Item = new HangHoa();
            var obj = new SqlParameter[31];
            obj[0] = new SqlParameter("HH_ID", item.ID);
            obj[1] = new SqlParameter("HH_DM_ID", item.DM_ID);
            obj[2] = new SqlParameter("HH_Alias", item.Alias);
            obj[3] = new SqlParameter("HH_Ten", item.Ten);
            obj[4] = new SqlParameter("HH_Ma", item.Ma);
            obj[5] = new SqlParameter("HH_Keywords", item.Keywords);
            obj[6] = new SqlParameter("HH_Description", item.Description);
            obj[7] = new SqlParameter("HH_MoTa", item.MoTa);
            obj[8] = new SqlParameter("HH_NoiDung", item.NoiDung);
            obj[9] = new SqlParameter("HH_GNY", item.GNY);
            obj[10] = new SqlParameter("HH_GiaNhap", item.GiaNhap);
            obj[11] = new SqlParameter("HH_GiaMax", item.GiaMax);
            obj[12] = new SqlParameter("HH_GiaMin", item.GiaMin);
            obj[13] = new SqlParameter("HH_DonVi", item.DonVi);
            obj[14] = new SqlParameter("HH_DonVi_ID", item.DonVi_ID);
            obj[15] = new SqlParameter("HH_SoLuong", item.SoLuong);
            obj[16] = new SqlParameter("HH_RowId", item.RowId);
            if (item.NgayTao > DateTime.MinValue)
            {
                obj[17] = new SqlParameter("HH_NgayTao", item.NgayTao);
            }
            else
            {
                obj[17] = new SqlParameter("HH_NgayTao", DBNull.Value);
            }
            obj[18] = new SqlParameter("HH_NguoiTao", item.NguoiTao);
            if (item.NgayCapNhat > DateTime.MinValue)
            {
                obj[19] = new SqlParameter("HH_NgayCapNhat", item.NgayCapNhat);
            }
            else
            {
                obj[19] = new SqlParameter("HH_NgayCapNhat", DBNull.Value);
            }
            obj[20] = new SqlParameter("HH_NguoiCapNhat", item.NguoiCapNhat);
            obj[21] = new SqlParameter("HH_Anh", item.Anh);
            obj[22] = new SqlParameter("HH_DichVu", item.DichVu);
            obj[23] = new SqlParameter("HH_Publish", item.Publish);
            obj[24] = new SqlParameter("HH_Active", item.Active);
            obj[25] = new SqlParameter("HH_Home", item.Home);
            obj[26] = new SqlParameter("HH_Draff", item.Draff);
            obj[27] = new SqlParameter("HH_TonDinhMuc", item.TonDinhMuc);
            obj[28] = new SqlParameter("HH_HetHang", item.HetHang);
            obj[29] = new SqlParameter("HH_KhoVay", item.KhoVay);
            obj[30] = new SqlParameter("HH_HongVay", item.HongVay);

            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Update_UpdateNormal_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static HangHoa SelectById(Guid HH_ID)
        {
            var Item = new HangHoa();
            var obj = new SqlParameter[1];
            obj[0] = new SqlParameter("HH_ID", HH_ID);
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectById_linhnx", obj))
            {
                while (rd.Read())
                {
                    Item = getFromReader(rd);
                }
            }
            return Item;
        }

        public static HangHoaCollection SelectAll()
        {
            var List = new HangHoaCollection();
            using (IDataReader rd = SqlHelper.ExecuteReader(DAL.con(), CommandType.StoredProcedure, "sp_tblHangHoa_Select_SelectAll_linhnx"))
            {
                while (rd.Read())
                {
                    List.Add(getFromReader(rd));
                }
            }
            return List;
        }
        public static Pager<HangHoa> pagerNormal(string url, bool rewrite, string sort, string q, int size)
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

            var pg = new Pager<HangHoa>("sp_tblHangHoa_Pager_Normal_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        #endregion

        #region Utilities
        public static HangHoa getFromReader(IDataReader rd)
        {
            var Item = new HangHoa();
            if (rd.FieldExists("HH_ID"))
            {
                Item.ID = (Guid)(rd["HH_ID"]);
            }
            if (rd.FieldExists("HH_DM_ID"))
            {
                Item.DM_ID = (Guid)(rd["HH_DM_ID"]);
            }
            if (rd.FieldExists("HH_Alias"))
            {
                Item.Alias = (String)(rd["HH_Alias"]);
            }
            if (rd.FieldExists("HH_Ten"))
            {
                Item.Ten = (String)(rd["HH_Ten"]);
            }
            if (rd.FieldExists("HH_Ma"))
            {
                Item.Ma = (String)(rd["HH_Ma"]);
            }
            if (rd.FieldExists("HH_Keywords"))
            {
                Item.Keywords = (String)(rd["HH_Keywords"]);
            }
            if (rd.FieldExists("HH_Description"))
            {
                Item.Description = (String)(rd["HH_Description"]);
            }
            if (rd.FieldExists("HH_MoTa"))
            {
                Item.MoTa = (String)(rd["HH_MoTa"]);
            }
            if (rd.FieldExists("HH_NoiDung"))
            {
                Item.NoiDung = (String)(rd["HH_NoiDung"]);
            }
            if (rd.FieldExists("HH_GNY"))
            {
                Item.GNY = (Double)(rd["HH_GNY"]);
            }
            if (rd.FieldExists("HH_GiaNhap"))
            {
                Item.GiaNhap = (Double)(rd["HH_GiaNhap"]);
            }
            if (rd.FieldExists("HH_GiaMax"))
            {
                Item.GiaMax = (Double)(rd["HH_GiaMax"]);
            }
            if (rd.FieldExists("HH_GiaMin"))
            {
                Item.GiaMin = (Double)(rd["HH_GiaMin"]);
            }
            if (rd.FieldExists("HH_DonVi"))
            {
                Item.DonVi = (String)(rd["HH_DonVi"]);
            }
            if (rd.FieldExists("HH_DonVi_ID"))
            {
                Item.DonVi_ID = (Guid)(rd["HH_DonVi_ID"]);
            }
            if (rd.FieldExists("HH_SoLuong"))
            {
                Item.SoLuong = (Double)(rd["HH_SoLuong"]);
            }
            if (rd.FieldExists("HH_RowId"))
            {
                Item.RowId = (Guid)(rd["HH_RowId"]);
            }
            if (rd.FieldExists("HH_NgayTao"))
            {
                Item.NgayTao = (DateTime)(rd["HH_NgayTao"]);
            }
            if (rd.FieldExists("HH_NguoiTao"))
            {
                Item.NguoiTao = (Int32)(rd["HH_NguoiTao"]);
            }
            if (rd.FieldExists("HH_NgayCapNhat"))
            {
                Item.NgayCapNhat = (DateTime)(rd["HH_NgayCapNhat"]);
            }
            if (rd.FieldExists("HH_NguoiCapNhat"))
            {
                Item.NguoiCapNhat = (Int32)(rd["HH_NguoiCapNhat"]);
            }
            if (rd.FieldExists("HH_Anh"))
            {
                Item.Anh = (String)(rd["HH_Anh"]);
            }
            if (rd.FieldExists("HH_DichVu"))
            {
                Item.DichVu = (Boolean)(rd["HH_DichVu"]);
            }
            if (rd.FieldExists("HH_Publish"))
            {
                Item.Publish = (Boolean)(rd["HH_Publish"]);
            }
            if (rd.FieldExists("HH_Active"))
            {
                Item.Active = (Boolean)(rd["HH_Active"]);
            }
            if (rd.FieldExists("HH_Home"))
            {
                Item.Home = (Boolean)(rd["HH_Home"]);
            }
            if (rd.FieldExists("HH_Draff"))
            {
                Item.Draff = (Boolean)(rd["HH_Draff"]);
            }
            if (rd.FieldExists("HH_TonDinhMuc"))
            {
                Item.TonDinhMuc = (Double)(rd["HH_TonDinhMuc"]);
            }
            if (rd.FieldExists("HH_HetHang"))
            {
                Item.HetHang = (Boolean)(rd["HH_HetHang"]);
            }
            if (rd.FieldExists("HH_KhoVay"))
            {
                Item.KhoVay = (Boolean)(rd["HH_KhoVay"]);
            }

            if (rd.FieldExists("DM_Ten"))
            {
                Item.DM_Ten = (String)(rd["DM_Ten"]);
            }
            if (rd.FieldExists("NguoiTao_Ten"))
            {
                Item.NguoiTao_Ten = (String)(rd["NguoiTao_Ten"]);
            }
            if (rd.FieldExists("NguoiCapNhat_Ten"))
            {
                Item.NguoiCapNhat_Ten = (String)(rd["NguoiCapNhat_Ten"]);
            }
            if (rd.FieldExists("HH_HongVay"))
            {
                Item.HongVay = (Boolean)(rd["HH_HongVay"]);
            }
            return Item;
        }
        #endregion

        #region Extend
        public static Pager<HangHoa> ByDm(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string DM_ID)
        {
            var obj = new SqlParameter[3];
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
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
            var pg = new Pager<HangHoa>(con, "sp_tblHangHoa_Pager_ByDm_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }
        public static Pager<HangHoa> ByDm(string url, bool rewrite, string sort, string q, int size, string DM_ID)
        {

            return ByDm(DAL.con(),url,rewrite,sort,q,size,DM_ID);
        }

        public static Pager<HangHoa> KhoVay(SqlConnection con, string url, bool rewrite, string sort, string q, int size, string DM_ID)
        {
            var obj = new SqlParameter[3];
            if (!string.IsNullOrEmpty(sort))
            {
                obj[0] = new SqlParameter("Sort", sort);
            }
            else
            {
                obj[0] = new SqlParameter("Sort", DBNull.Value);
            }
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
            var pg = new Pager<HangHoa>(con, "sp_tblHangHoa_Pager_KhoVay_linhnx", "page", size, 10, rewrite, url, obj);
            return pg;
        }

        #endregion
    }
    #endregion

    #endregion
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using System.Data;

namespace DAL
{
    public class LienHe
    {
        private int _MaLH;
    
        public int MaLH
        {
            get { return _MaLH; }
            set { _MaLH = value; }
        }
        private string _HoTen;

        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }
        private string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private string _DienThoai;

        public string DienThoai
        {
            get { return _DienThoai; }
            set { _DienThoai = value; }
        }
        private string _TieuDe;

        public string TieuDe
        {
            get { return _TieuDe; }
            set { _TieuDe = value; }
        }
        private string _NoiDung;

        public string NoiDung
        {
            get { return _NoiDung; }
            set { _NoiDung = value; }
        }

        private bool _Printt;

        public bool Printt
        {
            get { return _Printt; }
            set { _Printt = value; }
        }

        public LienHe()
        { }
        public static List<LienHe> ListLienHe()
        {
            try
            {
                return CBO.FillCollection<LienHe>(DataProvider.Instance.ExecuteReader("LienHe_Select"));
            }
            catch
            {
                return new List<LienHe>();
            }

        }
        //Select theo khoas chinh
        public static LienHe LienHe_Single(string id)
        {
            try
            {
                return CBO.FillObject<LienHe>(DataProvider.Instance.ExecuteReader("LienHe_Signle", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }
        public static List<LienHe> Pagings(string page, out int howManyPage)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("LienHe_Pages", page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPage = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<LienHe>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }
                howManyPage = 0;
                return new List<LienHe>();
            }
        }
        public static bool Delete(string id)
        {
            try
            {
                int result = DataProvider.Instance.ExecuteNonQuery("LienHe_Delete", id);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
        //Add
        public static bool Add(LienHe lienhe)
        {
            try
            {
                object result = DataProvider.Instance.ExecuteNonQueryWithOutput("@MaLH", "LienHe_Add", lienhe.MaLH, lienhe.HoTen, lienhe.DiaChi, lienhe.Email, lienhe.DienThoai, lienhe.TieuDe, lienhe.NoiDung,lienhe.Printt);
                return Convert.ToInt32(result) > 0;
            }
            catch
            {
                return false;
            }
        }

        //Update trang thai ve
        public static bool UpdatePrint(string id, bool status)
        {
            try
            {
                int result = DataProvider.Instance.ExecuteNonQuery("LienHe_UpdatePrint", Convert.ToInt32(id), status);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        //Thong ke ve xe
        public static int LienHe_CountHoTen(string hoten, string diachi, string email,string sodt)
        {
            object result = DataProvider.Instance.ExecuteScalar("LienHe_CountPages",hoten,diachi,email,sodt);
            return Convert.ToInt32(result);
        }

        //Search
        public static List<LienHe> LienHe_SearchPagings(string page, out int howManyPage,string hoten,string diachi,string email,string sodt)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("LienHe_SearchPages", page, GlobalConfiguration.PageSize, hoten, diachi, email, sodt);
                reader.Read();
                howManyPage = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<LienHe>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }
                howManyPage = 0;
                return new List<LienHe>();
            }
        }
    }
}

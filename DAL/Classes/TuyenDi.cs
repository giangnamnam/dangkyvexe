using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using System.Data;

namespace DAL
{
    public class TuyenDi
    {
        private int _MaTuyen;

        public int MaTuyen
        {
            get { return _MaTuyen; }
            set { _MaTuyen = value; }
        }
        private string _BenDiBenDen;

        public string BenDiBenDen
        {
            get { return _BenDiBenDen; }
            set { _BenDiBenDen = value; }
        }

        private int _MaTG;

        public int MaTG
        {
            get { return _MaTG; }
            set { _MaTG = value; }
        }

        private int _MaXe;

        public int MaXe
        {
            get { return _MaXe; }
            set { _MaXe = value; }
        }

  
        private decimal? _GiaVe;

        public decimal? GiaVe
        {
            get { return _GiaVe; }
            set { _GiaVe = value; }
        }
 
        private string _PhuThu;

        public string PhuThu
        {
            get { return _PhuThu; }
            set { _PhuThu = value; }
        }


        private bool _Printt;

        public bool Printt
        {
            get { return _Printt; }
            set { _Printt = value; }
        }

        //lay theo ten
        private string _GioXuatBen;

        public string GioXuatBen
        {
            get { return _GioXuatBen; }
            set { _GioXuatBen = value; }
        }


        private string _KieuiXe;

        public string KieuiXe
        {
            get { return _KieuiXe; }
            set { _KieuiXe = value; }
        }
        public TuyenDi()
        { }
        public static List<TuyenDi> ListTuyenDi()
        {
            try
            {
                return CBO.FillCollection<TuyenDi>(DataProvider.Instance.ExecuteReader("TuyenDi_Select"));
            }
            catch
            {
                return new List<TuyenDi>();
            }
        }
        public static List<TuyenDi> Paging(string page,out int howManyPage)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("TuyenDi_Pages", page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPage = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<TuyenDi>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }
                howManyPage = 0;
                return new List<TuyenDi>();
            }
        }
        //Delte tuyen
        public static bool Delete(string id)
        {
            try
            {
                int result = DataProvider.Instance.ExecuteNonQuery("TuyenDi_Delete", id);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        //Select TuyenDiTuyenDen
        public static List<TuyenDi> TuyenDi_Dropdownlist()
        {
            try
            {
                return CBO.FillCollection<TuyenDi>(DataProvider.Instance.ExecuteReader("TuyenDi_SelectLoadDropDowList"));
            }
            catch
            {
                return new List<TuyenDi>();
            }
        }


        //Single
        public static TuyenDi TuyenDi_Single(string id)
        {
            try
            {
                return CBO.FillObject<TuyenDi>(DataProvider.Instance.ExecuteReader("TuyenDi_Single", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }

        //Add tuyen di
        public static bool TuyenDi_Add(TuyenDi td)
        {
            try
            {
                object result = DataProvider.Instance.ExecuteNonQueryWithOutput("@MaTuyen", "TuyenDi_Add", td.MaTuyen, td.BenDiBenDen, td.MaTG, td.MaXe, td.GiaVe, td.PhuThu,td.Printt);
                return Convert.ToInt32(result) > 0;
            }
            catch
            {
                return false;
            }
        }
        //Update
        public static bool TuyenDi_Update(TuyenDi td)
        {
            try
            {
                int result = DataProvider.Instance.ExecuteNonQuery("TuyenDi_Update",td.MaTuyen, td.BenDiBenDen, td.MaTG, td.MaXe, td.GiaVe, td.PhuThu,td.Printt);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        //Search tuyen di
        public static List<TuyenDi> SearchTuyenDi(string bendibenden,string thoigian,string loaixe)
        {
            try
            {
                return CBO.FillCollection<TuyenDi>(DataProvider.Instance.ExecuteReader("TuyenDi_Search", bendibenden, thoigian, loaixe));
            }
            catch
            {
                return new List<TuyenDi>();
            }
        }

        //Search tuyen di Pages
        public static List<TuyenDi> SearchPaging(string page, out int howManyPage, string bendibenden, string thoigian, string loaixe)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("TuyenDi_SearchPages", page, GlobalConfiguration.PageSize,bendibenden,thoigian,loaixe);
                reader.Read();
                howManyPage = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<TuyenDi>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }
                howManyPage = 0;
                return new List<TuyenDi>();
            }
        }

        //Update trang thai ve
        public static bool UpdatePrint(string id, bool status)
        {
            try
            {
                int result = DataProvider.Instance.ExecuteNonQuery("TuyenDi_UpdatePrint", Convert.ToInt32(id), status);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        //Count BenDiBenDen

        public static int VeXe_CountBenDiBenDen(string bendibenden,string gioxuatben,string kieuxe)
        {
            object result = DataProvider.Instance.ExecuteScalar("TuyenDi_CountBenDiBenDen", bendibenden, gioxuatben, kieuxe);
            return Convert.ToInt32(result);
        }
    }
}

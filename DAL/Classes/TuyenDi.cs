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
        private int _SoGheDat;

        public int SoGheDat
        {
            get { return _SoGheDat; }
            set { _SoGheDat = value; }
        }
        private string _PhuThu;

        public string PhuThu
        {
            get { return _PhuThu; }
            set { _PhuThu = value; }
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
    }
}

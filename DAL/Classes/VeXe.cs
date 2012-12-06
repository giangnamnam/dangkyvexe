using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using System.Data;

namespace DAL
{
    public class VeXe
    {
        private int _MaVe;

        public int MaVe
        {
            get { return _MaVe; }
            set { _MaVe = value; }
        }
        private string _HoTen;

        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }
        private string _GioiTinh;

        public string GioiTinh
        {
            get { return _GioiTinh; }
            set { _GioiTinh = value; }
        }
        private int _Tuoi;

        public int Tuoi
        {
            get { return _Tuoi; }
            set { _Tuoi = value; }
        }
        private string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        private string _SoDT;

        public string SoDT
        {
            get { return _SoDT; }
            set { _SoDT = value; }
        }
        private DateTime _NgayXuatBen;

        public DateTime NgayXuatBen
        {
            get { return _NgayXuatBen; }
            set { _NgayXuatBen = value; }
        }
        private bool _TrangThaiVeXe;

        public bool TrangThaiVeXe
        {
            get { return _TrangThaiVeXe; }
            set { _TrangThaiVeXe = value; }
        }
        private int _MaTG;

        public int MaTG
        {
            get { return _MaTG; }
            set { _MaTG = value; }
        }
        private int _MaTuyen;

        public int MaTuyen
        {
            get { return _MaTuyen; }
            set { _MaTuyen = value; }
        }
        private int _MaXe;

        public int MaXe
        {
            get { return _MaXe; }
            set { _MaXe = value; }
        }
        private string _MaTKKH;

        public string MaTKKH
        {
            get { return _MaTKKH; }
            set { _MaTKKH = value; }
        }




        private bool _Printt;

        public bool Printt
        {
            get { return _Printt; }
            set { _Printt = value; }
        }

        // Xuat name
        private string _KieuiXe;

        public string KieuiXe
        {
            get { return _KieuiXe; }
            set { _KieuiXe = value; }
        }

        private string _GioXuatBen;

        public string GioXuatBen
        {
            get { return _GioXuatBen; }
            set { _GioXuatBen = value; }
        }

        private string _BenDiBenDen;

        public string BenDiBenDen
        {
            get { return _BenDiBenDen; }
            set { _BenDiBenDen = value; }
        }

        private decimal? _GiaVe;

        public decimal? GiaVe
        {
            get { return _GiaVe; }
            set { _GiaVe = value; }
        }

        public VeXe()
        {}
        public static List<VeXe> ListVeXe()
        {
            try
            {
                return CBO.FillCollection<VeXe>(DataProvider.Instance.ExecuteReader("VeXe_Select"));
            }
            catch
            {
                return new List<VeXe>();
            }
        }
        public static List<VeXe> Paging(string page,out int howManyPage)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("VeXe_Paging", page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPage = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<VeXe>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }
                howManyPage = 0;
                return new List<VeXe>();
            }
        }
        //Single
        public static VeXe VeXe_Single(string id)
        {
            try
            {
                return CBO.FillObject<VeXe>(DataProvider.Instance.ExecuteReader("VeXe_Single", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }
        //Add ve xe
        public static bool Add(VeXe vx)
        {
            try
            {
                //lay soghemax cua cung chuyen xe

                object result = DataProvider.Instance.ExecuteNonQueryWithOutput("@MaVe", "VeXe_Add", vx.MaVe, vx.HoTen, vx.GioiTinh, vx.Tuoi, vx.DiaChi, vx.SoDT, vx.NgayXuatBen, vx.TrangThaiVeXe, vx.MaTG, vx.MaTuyen, vx.MaXe, vx.MaTKKH,vx.Printt);
                return Convert.ToInt32(result) > 0;
            }
            catch
            {
                return false;
            }
        }

        //Delete
        public static bool Delete(string id)
        {
            try
            {
                int result = DataProvider.Instance.ExecuteNonQuery("VeXe_Delete", id);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
        //Update trang thai ve
        public static bool UpdateTrangThaiVeXe(string id, bool status)
        {
            try
            {
                int result = DataProvider.Instance.ExecuteNonQuery("VeXe_UpdateTrangThaiVeXe", Convert.ToInt32(id), status);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        //Select ve xe theo username
        public static List<VeXe> VeXe_SlectAcountKH(string tendangnhap)
        {
            try
            {
                return CBO.FillCollection<VeXe>(DataProvider.Instance.ExecuteReader("VeXe_SelectUsernameAcount",tendangnhap));
            }
            catch
            {
                return null;
            }
        }

        //Update ve xe
        public static bool Update(VeXe vx)
        {
            try
            {
                int result = DataProvider.Instance.ExecuteNonQuery("VeXe_Update", vx.MaVe, vx.HoTen, vx.GioiTinh, vx.Tuoi, vx.DiaChi, vx.SoDT, vx.NgayXuatBen, vx.TrangThaiVeXe, vx.MaTG, vx.MaTuyen, vx.MaXe, vx.MaTKKH,vx.Printt);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        //
        public static List<VeXe> SearchNoPaging(string diachi)
        {
            try
            {
                return CBO.FillCollection<VeXe>(DataProvider.Instance.ExecuteReader("VeXe_Search",diachi));
            }
            catch
            {
                return new List<VeXe>();
            }
        }

        //Search tuyen di Pages
        public static List<VeXe> SearchPagingss(string page, out int howManyPage, string diachi, string ngayxuatben, string thoigian,string loaixe, string bendibenden)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("VeXe_SearchPaging", page, GlobalConfiguration.PageSize, diachi,Convert.ToDateTime(ngayxuatben),thoigian,loaixe,bendibenden);
                reader.Read();
                howManyPage = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<VeXe>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                {
                    reader.Close();
                }
                howManyPage = 0;
                return new List<VeXe>();
            }
        }

        //Update trang thai ve
        public static bool UpdatePrint(string id, bool status)
        {
            try
            {
                int result = DataProvider.Instance.ExecuteNonQuery("VeXe_UpdatePrint", Convert.ToInt32(id), status);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        //Ham dem so luong ve xe co dieu kien

        public static int VeXe_CountWhere(string date, string mathoigian, string matuyen, string mave)
        {
            object result = DataProvider.Instance.ExecuteScalar("VeXe_CountWhere", Convert.ToDateTime(date), Convert.ToInt32(mathoigian), Convert.ToInt32(matuyen), Convert.ToInt32(mave));
            return Convert.ToInt32(result);
        }

        //Ham dem so luong Count ho ten

        public static int VeXe_CountHoTen(string diachi,string ngayxuatben,string gioxuatben,string kieuxe,string bendibenden)
        {
            object result = DataProvider.Instance.ExecuteScalar("VeVe_CountHoTen",diachi,Convert.ToDateTime(ngayxuatben),gioxuatben,kieuxe,bendibenden);
            return Convert.ToInt32(result);
        }
        
        //Tinh doanh thu
        public static int VeXe_SumGiaVe(string tungay, string denngay,string kieuxe, string bendibenden)
        {
            object result = DataProvider.Instance.ExecuteScalar("VeXe_SumGiaVe", Convert.ToDateTime(tungay), Convert.ToDateTime(denngay), kieuxe, bendibenden);
            return Convert.ToInt32(result);
        }
    }
}

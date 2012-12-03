using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;

namespace DAL
{
    public class LienHePrint
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
        public LienHePrint()
        { 
        
        }
        //add
        //Add
        public static bool Add(LienHePrint lienhe)
        {
            try
            {
                object result = DataProvider.Instance.ExecuteNonQueryWithOutput("@MaLH", "LienHePrint_Add", lienhe.MaLH, lienhe.HoTen, lienhe.DiaChi, lienhe.Email, lienhe.DienThoai, lienhe.TieuDe, lienhe.NoiDung);
                return Convert.ToInt32(result) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}

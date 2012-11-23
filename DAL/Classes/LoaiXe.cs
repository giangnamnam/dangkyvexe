using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;

namespace DAL
{
    public class LoaiXe
    {
        private int _MaXe;

        public int MaXe
        {
            get { return _MaXe; }
            set { _MaXe = value; }
        }
        private string _KieuiXe;

        public string KieuiXe
        {
            get { return _KieuiXe; }
            set { _KieuiXe = value; }
        }
        private int _SoGhe;

        public int SoGhe
        {
            get { return _SoGhe; }
            set { _SoGhe = value; }
        }
        public LoaiXe()
        { }
        public static List<LoaiXe> LoaiXe_DropDownList()
        {
            try
            {
                return CBO.FillCollection<LoaiXe>(DataProvider.Instance.ExecuteReader("LoaiXe_SelectLoadDropDowList"));
            }
            catch
            {
                return null;
            }
        }
    }
}

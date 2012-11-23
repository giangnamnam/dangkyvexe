using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;

namespace DAL
{
    public class ThoiGian
    {
        private int _MaTG;

        public int MaTG
        {
            get { return _MaTG; }
            set { _MaTG = value; }
        }
        private string _GioXuatBen;

        public string GioXuatBen
        {
            get { return _GioXuatBen; }
            set { _GioXuatBen = value; }
        }
        public ThoiGian()
        { }
        public static List<ThoiGian> ThoiGian_DropDownList()
        {
            try
            {
                return CBO.FillCollection<ThoiGian>(DataProvider.Instance.ExecuteReader("ThoiGian_Select"));
            }
            catch
            {
                return null;
            }
        }
    }
}

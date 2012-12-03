using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;

namespace DAL
{
    public class TKKhachHang
    {
        public TKKhachHang()
        { }
        public static List<TKKhachHang> Find_TKKHUsername(string user)
        {
            try
            {
                return CBO.FillCollection<TKKhachHang>(DataProvider.Instance.ExecuteReader("Find_CreateDate", user));
            }
            catch
            {
                return null;
            }
        }
    }
}

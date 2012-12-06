using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DAL
{
    public class Link
    {
        private static string BuildAbsolute(string url)
        {
            Uri uri = HttpContext.Current.Request.Url;
            string app = HttpContext.Current.Request.ApplicationPath;
            if (!app.EndsWith("/"))
            {
                app += "/";
            }
            url = url.TrimStart('/');
            return HttpUtility.UrlPathEncode(String.Format("http://{0}:{1}{2}{3}", uri.Host, uri.Port, app, url));
        }
        
        //Phan trang tai khoan khach hang

        //public static string ToTaiKhoanKH(string page)
        //{
        //    if (page == "1")
        //    {
        //        return BuildAbsolute(String.Format("Admin/Acountkhachhang.aspx"));
        //    }
        //    else
        //    {
        //        return BuildAbsolute(String.Format("Admin/Acountkhachhang.aspx?Page={0}", page));
        //    }

        //}
        //public static string ToTaiKhoanKH()
        //{
        //    return ToTaiKhoanKH("1");
        //}
        //public static string ToTaiKhoanKhachHangID(string Id)
        //{
        //    return BuildAbsolute(String.Format("Admin/Acountkhachhang.aspx?Id={0}", Id));
        //}


        public static string ToTaiKhoanKH(string page)
        {
            if (page == "1")
            {
                return BuildAbsolute(String.Format("Admin/GerAll.aspx"));
            }
            else
            {
                return BuildAbsolute(String.Format("Admin/GerAll.aspx?Page={0}", page));
            }

        }
        public static string ToTaiKhoanKH()
        {
            return ToTaiKhoanKH("1");
        }
        public static string ToTaiKhoanKhachHangID(string Id)
        {
            return BuildAbsolute(String.Format("Admin/GerAll.aspx?Id={0}", Id));
        }
        //Phan trang cua lien he
        public static string ToLienHe(string page)
        {
            if (page == "1")
            {
                return BuildAbsolute(String.Format("Admin/Lienhe.aspx"));
            }
            else
            {
                return BuildAbsolute(String.Format("Admin/Lienhe.aspx?Page={0}", page));
            }
        }
        public static string ToLienHe()
        {
            return ToLienHe("1");
        }
        //Phan trang cua ve xe
        public static string ToVeXe(string page)
        {
            if (page == "1")
            {
                return BuildAbsolute(String.Format("Admin/VeXe.aspx"));
            }
            else
            {
                return BuildAbsolute(String.Format("Admin/VeXe.aspx?Page={0}",page));
            }
        }
        public static string ToVeXe()
        {
            return ToVeXe("1");
        }

        //Tim kiem vexe
        public static string SearchVeXe(string page, string diachi, string ngayxuatben, string gioxuatben,string loaixe, string bendibenden)
        {
            if (page == "1")
            {
                return BuildAbsolute(String.Format("Admin/VeXe.aspx?Diachi={0}&Ngayxuatben={1}&Gioxuatben={2}&Loaixe={3}&Bendibenden={4}", diachi, ngayxuatben, gioxuatben, loaixe, bendibenden));
            }
            else
            {
                return BuildAbsolute(String.Format("Admin/VeXe.aspx?Page={0}&Diachi={1}&Ngayxuatben={2}&Gioxuatben={3}&Loaixe={4}Bendibenden={5}", page, diachi, ngayxuatben, gioxuatben, loaixe, bendibenden));
            }

        }
        public static string SearchVeXe()
        {
            return SearchVeXe("1","","","","","");
        }


        //TimKiemLienHe
        public static string SearchLienHe(string page,string hoten,string diachi,string email,string sodt)
        {
            if (page == "1")
            {
                return BuildAbsolute(String.Format("Admin/Lienhe.aspx?Hoten={0}&Diachi={1}&Email={2}&Sodt={3}", hoten, diachi, email, sodt));
            }
            else
            {
                return BuildAbsolute(String.Format("Admin/Lienhe.aspx?Page={0}&Hoten={1}&Diachi={2}&Email={3}&Sodt={4}", page, hoten, diachi, email, sodt));
            }

        }
        public static string SearchLienHe()
        {
            return SearchLienHe("1", "", "", "", "");
        }







        //Phan trang cua tuyen di
        public static string ToTuyenDi(String page)
        {
            if (page == "1")
            {
                return BuildAbsolute(String.Format("Admin/Tuyendi.aspx"));
            }
            else
            {
                return BuildAbsolute(String.Format("Admin/Tuyendi.aspx?Page={0}", page));
            }
        }
        public static string ToTuyenDi()
        {
            return ToTuyenDi("1");
        }

        //Tim kiem tuyen di
        public static string SearchTuyenDi(string page,string bendibenden, string thoigian, string loaixe)
        {
            if (page == "1")
            {
                return BuildAbsolute(String.Format("Admin/Tuyendi.aspx?BendiBenden={0}&Thoigian={1}&Loaixe={2}", bendibenden, thoigian, loaixe));
            }
            else
            {
                return BuildAbsolute(String.Format("Admin/Tuyendi.aspx?Page={0}&BendiBenden={1}&Thoigian={2}&Loaixe={3}",page,bendibenden, thoigian, loaixe));
            }

        }
        public static string SearchTuyenDi()
        {
            return SearchTuyenDi("1","","","");
        }
    }
}

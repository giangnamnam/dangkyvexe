﻿using System;
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
        private int _MaTuyen;

        public int MaTuyen
        {
            get { return _MaTuyen; }
            set { _MaTuyen = value; }
        }
        private DateTime _NgayXuatBen;

        public DateTime NgayXuatBen
        {
            get { return _NgayXuatBen; }
            set { _NgayXuatBen = value; }
        }
        private string _LoaiXe;

        public string LoaiXe
        {
            get { return _LoaiXe; }
            set { _LoaiXe = value; }
        }
        private bool _TrangThaiVeXe;

        public bool TrangThaiVeXe
        {
            get { return _TrangThaiVeXe; }
            set { _TrangThaiVeXe = value; }
        }
        private int _MaTK;

        public int MaTK
        {
            get { return _MaTK; }
            set { _MaTK = value; }
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

    }
}
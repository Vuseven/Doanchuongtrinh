using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TT_GDTX_ANGIANG.BusinessObject;

namespace TT_GDTX_ANGIANG.DataLayer
{
    public class LichSuBanThanData
    {
        #region Service
        private DataService m_Service;
        public DataService Service
        {
            get { return m_Service; }
            set { m_Service = value; }
        }
        #endregion

        #region lay_dsLichSuBanThan()
        public DataTable lay_dsLichSuBanThan()
        {
            if (Service == null)
                Service = new DataService();
            SqlCommand cmd = new SqlCommand("Select * From LICHSUBANTHAN");
            Service.Load(cmd);
            return Service;
        }
        #endregion

        #region lay_dsLichSuBanThan()
        public DataTable lay_dsLichSuBanThan(String ma)
        {
            if (Service == null)
                Service = new DataService();
            String sql = ("Select MALSBT, MANHANVIEN, NGAYBD, NGAYKT, NOIDUNG, MANV From LICHSUBANTHAN , NHANVIEN WHERE NHANVIEN.MANV = LICHSUBANTHAN.MANHANVIEN AND LICHSUBANTHAN.MANHANVIEN = @ma");
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = ma;
            cmd.CommandText = sql;
            Service.Load(cmd);
            return Service;
        }
        #endregion

        #region Update()
        public bool Update()
        {
            return Service.Update();
        }
        #endregion



        #region CapNhatLichSuBanThan()
        public void CapNhatLichSuBanThan(LichSuBanThanInfo lichSuBTInfo)
        {
            if (Service == null)
                Service = new DataService();
            String sql = "UPDATE  LICHSUBANTHAN SET NGAYBD =@ngayBD, NGAYKT =@ngayKT, NOIDUNG = @noidung WHERE MALSBT = @malsbt";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("@malsbt", SqlDbType.VarChar).Value = lichSuBTInfo.MaLichSuBanThan;
            cmd.Parameters.Add("@ngayBD",SqlDbType.DateTime).Value=lichSuBTInfo.TuNgay;
            cmd.Parameters.Add("@ngayKT", SqlDbType.DateTime).Value = lichSuBTInfo.DenNgay;
            cmd.Parameters.Add("@noidung", SqlDbType.NVarChar).Value = lichSuBTInfo.NoiDung;
            cmd.CommandText = sql;
            Service.Load(cmd);
        }
        #endregion

      



        #region Xoa_LichSuBanThan

        public void Xoa_LichSuBanThan(String MaLSBT)
        {

            if (Service == null)
                Service = new DataService();
            String sql = "delete from LICHSUBANTHAN where MALSBT = @ma";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = MaLSBT;
            cmd.CommandText = sql;
            Service.Load(cmd);
        }
        #endregion

        #region Xoa_LichSuBanThan_NhanVien

        public void Xoa_LichSuBanThan_NhanVien(String MaNV)
        {

            if (Service == null)
                Service = new DataService();
            String sql = "delete from LICHSUBANTHAN where MANHANVIEN = @ma";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = MaNV;
            cmd.CommandText = sql;
            Service.Load(cmd);
        }
        #endregion
    }
}

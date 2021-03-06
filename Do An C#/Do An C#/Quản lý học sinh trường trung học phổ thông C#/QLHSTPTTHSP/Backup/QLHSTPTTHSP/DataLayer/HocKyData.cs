using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using QLHSTPTTHSP.Initiation;
using QLHSTPTTHSP.BusinessObjects;

namespace QLHSTPTTHSP.DataLayer
{
    public class HocKyData
    {
        MySqlCommand mySqlCommand;
        DataServices dataServices = new DataServices();
        /// <summary>
        /// Lấy bảng hoc_ky dựa vào ma_nien_hoc
        /// </summary>
        /// <returns>Bảng học kỳ</returns>
        public DataTable BangHocKy(string maNienHoc)
        {
            mySqlCommand = new MySqlCommand("select * from hoc_ky where ma_nien_hoc = @manienhoc;");
            mySqlCommand.Parameters.Add("@manienhoc", MySqlDbType.VarChar, 6).Value = maNienHoc;
            dataServices.Load(mySqlCommand);
            return dataServices;
        }
        /// <summary>
        /// Thêm học kỳ với những giá trị mặc định
        /// </summary>
        /// <param name="nienHocInfo"></param>
        /// <returns></returns>
        public bool ThemHocky(NienHocInfo nienHocInfo)
        {
            mySqlCommand = new MySqlCommand();
            string mySQLQuery1 = "insert into hoc_ky(ten_hoc_ky,tg_bat_dau,tg_ket_thuc,ma_nien_hoc) values(@tenhocky1,@tgbatdau1,@tgketthuc1,@manienhoc);";
            string mySQLQuery2 = "insert into hoc_ky(ten_hoc_ky,tg_bat_dau,tg_ket_thuc,ma_nien_hoc) values(@tenhocky2,@tgbatdau2,@tgketthuc2,@manienhoc);";
            mySqlCommand.CommandText = mySQLQuery1 + mySQLQuery2;
            mySqlCommand.Parameters.Add("@tenhocky1", MySqlDbType.VarChar, 50).Value = "Học kỳ 1";
            mySqlCommand.Parameters.Add("@tenhocky2", MySqlDbType.VarChar, 50).Value = "Học kỳ 2";
            mySqlCommand.Parameters.Add("@tgbatdau1", MySqlDbType.Date).Value = nienHocInfo.ThoiGianBatDau;
            mySqlCommand.Parameters.Add("@tgbatdau2", MySqlDbType.Date).Value = nienHocInfo.ThoiGianKetThuc;
            mySqlCommand.Parameters.Add("@tgketthuc1", MySqlDbType.Date).Value = nienHocInfo.ThoiGianBatDau;
            mySqlCommand.Parameters.Add("@tgketthuc2", MySqlDbType.Date).Value = nienHocInfo.ThoiGianKetThuc;
            mySqlCommand.Parameters.Add("@manienhoc", MySqlDbType.VarChar, 6).Value = nienHocInfo.MaNienHoc;

            try
            {
                DataServices.OpenConnection(true);
                return dataServices.ExecuteUpdate(mySqlCommand) > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaHocKy(string maNienHoc)
        {
            mySqlCommand = new MySqlCommand();
            mySqlCommand.CommandText = "delete from hoc_ky where ma_nien_hoc = @manienhoc";
            mySqlCommand.Parameters.Add("@manienhoc", MySqlDbType.VarChar, 6).Value = maNienHoc;
            try
            {
                DataServices.OpenConnection(true);
                return dataServices.ExecuteUpdate(mySqlCommand) > 0;                
            }
            catch { return false; }
        }
        /// <summary>
        /// Cập nhật học kỳ
        /// </summary>
        /// <param name="hocKyInfo"></param>
        /// <returns></returns>
        public bool CapNhatHocKy(HocKyInfo hocKyInfo1, HocKyInfo hocKyInfo2)
        {
            mySqlCommand = new MySqlCommand();
            string mySQLQuery1 = "update hoc_ky set tg_bat_dau=@tgbatdau1, tg_ket_thuc=@tgketthuc1 where ma_nien_hoc = @manienhoc and ten_hoc_ky like 'Học kỳ 1';";
            string mySQLQuery2 = "update hoc_ky set tg_bat_dau=@tgbatdau2, tg_ket_thuc=@tgketthuc2 where ma_nien_hoc = @manienhoc and ten_hoc_ky like 'Học kỳ 2';";
            mySqlCommand.CommandText = mySQLQuery1 + mySQLQuery2;
            mySqlCommand.Parameters.Add("@manienhoc", MySqlDbType.VarChar, 6).Value = hocKyInfo1.MaNienhoc;
            mySqlCommand.Parameters.Add("@tgbatdau1", MySqlDbType.Date).Value = hocKyInfo1.ThoiGianBatDau;
            mySqlCommand.Parameters.Add("@tgketthuc1", MySqlDbType.Date).Value = hocKyInfo1.ThoiGianKetThuc;
            mySqlCommand.Parameters.Add("@tgbatdau2", MySqlDbType.Date).Value = hocKyInfo2.ThoiGianBatDau;
            mySqlCommand.Parameters.Add("@tgketthuc2", MySqlDbType.Date).Value = hocKyInfo2.ThoiGianKetThuc;
            try
            {
                DataServices.OpenConnection(true);
                return dataServices.ExecuteUpdate(mySqlCommand) > 0;
            }
            catch { return false; }
        }
    }
}

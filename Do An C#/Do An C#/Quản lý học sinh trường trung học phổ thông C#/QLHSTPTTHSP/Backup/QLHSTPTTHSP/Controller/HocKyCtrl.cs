using System;
using System.Collections.Generic;
using System.Text;
using QLHSTPTTHSP.DataLayer;
using DevComponents.DotNetBar.Controls;
using QLHSTPTTHSP.BusinessObjects;
using System.Data;
using DevComponents.Editors.DateTimeAdv;

namespace QLHSTPTTHSP.Controller
{
    public class HocKyCtrl
    {
        NienHocData nienHocData = new NienHocData();
        NienHocInfo nienHocInfo = null;
        HocKyData hocKyData = new HocKyData();

        #region Hiển thị ComboBox
        public void LoadComboBoxNienHoc(ComboBoxEx cmb)
        {
            cmb.DataSource = nienHocData.LayBangNienHoc();
            cmb.DisplayMember = "ten_nien_hoc";
            cmb.ValueMember = "ma_nien_hoc";
        }
        #endregion

        public void HienThiBieuDoThoiGian(ComboBoxEx comboBoxEx_NienHoc, DateTimeInput dateTimeInput_DauNam, DateTimeInput dateTimeInput_Dau_HK1, DateTimeInput dateTimeInput_Cuoi_HK1, DateTimeInput dateTimeInput_Dau_HK2, DateTimeInput dateTimeInput_Cuoi_HK2, DateTimeInput dateTimeInput_CuoiNam)
        {
            if (comboBoxEx_NienHoc.SelectedIndex >= 0)
            {
                nienHocInfo = this.LayNienhoc(comboBoxEx_NienHoc.SelectedValue.ToString());
                HocKyInfo[] hocKyInfoArray = this.LayThongTinHocKy(comboBoxEx_NienHoc.SelectedValue.ToString());
                if (nienHocInfo != null)
                {
                    dateTimeInput_DauNam.Value = nienHocInfo.ThoiGianBatDau;
                    dateTimeInput_CuoiNam.Value = nienHocInfo.ThoiGianKetThuc;
                    if (hocKyInfoArray.Length == 2)
                    {
                        dateTimeInput_Dau_HK1.Value = hocKyInfoArray[0].ThoiGianBatDau;
                        dateTimeInput_Cuoi_HK1.Value = hocKyInfoArray[0].ThoiGianKetThuc;
                        dateTimeInput_Dau_HK2.Value = hocKyInfoArray[1].ThoiGianBatDau;
                        dateTimeInput_Cuoi_HK2.Value = hocKyInfoArray[1].ThoiGianKetThuc;
                    }
                }               

            }
            else
            {                
                dateTimeInput_DauNam.Visible = false;
                dateTimeInput_Dau_HK1.Visible = false;
                dateTimeInput_Cuoi_HK1.Visible = false;
                dateTimeInput_Dau_HK2.Visible = false;
                dateTimeInput_Cuoi_HK2.Visible = false;
                dateTimeInput_CuoiNam.Visible = false;
            }
        }

        /// <summary>
        /// Lấy một đối tượng Niên Học với mã niên học tương ứng
        /// </summary>
        /// <param name="maHH">mã niên học</param>
        /// <returns></returns>
        public NienHocInfo LayNienhoc(string maNienHoc)
        {
            NienHocInfo nienHocInfo = null;            
            DataTable table = new NienHocData().BangNienHoc(maNienHoc);
            if (table.Rows.Count > 0)
            {
                nienHocInfo = new NienHocInfo();
                nienHocInfo.MaNienHoc = maNienHoc;
                nienHocInfo.TenNienHoc = Convert.ToString(table.Rows[0]["ten_nien_hoc"]);
                nienHocInfo.ThoiGianBatDau = Convert.ToDateTime(Convert.ToDateTime(table.Rows[0]["tg_bat_dau"]).ToString("dd/MM/yyyy"));
                nienHocInfo.ThoiGianKetThuc = Convert.ToDateTime(Convert.ToDateTime(table.Rows[0]["tg_ket_thuc"]).ToString("dd/MM/yyyy"));
            }

            return nienHocInfo;
        }
        /// <summary>
        /// Lấy thông tin 2 học kỳ tương ứng với niên học
        /// </summary>
        /// <param name="maNienHoc"></param>
        /// <returns></returns>
        public HocKyInfo[] LayThongTinHocKy(string maNienHoc)
        {            
            DataTable table = new HocKyData().BangHocKy(maNienHoc);
            HocKyInfo[] hocKyInfo = new HocKyInfo[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                hocKyInfo[i] = new HocKyInfo();
                hocKyInfo[i].Id = Convert.ToInt32(table.Rows[i]["ma_hoc_ky"]);
                hocKyInfo[i].TenHocKy = Convert.ToString(table.Rows[i]["ten_hoc_ky"]);
                hocKyInfo[i].ThoiGianBatDau = Convert.ToDateTime(Convert.ToDateTime(table.Rows[i]["tg_bat_dau"]).ToString("dd/MM/yyyy"));
                hocKyInfo[i].ThoiGianKetThuc = Convert.ToDateTime(Convert.ToDateTime(table.Rows[i]["tg_ket_thuc"]).ToString("dd/MM/yyyy"));
                hocKyInfo[i].MaNienhoc = Convert.ToString(table.Rows[i]["ma_nien_hoc"]);
            }
            return hocKyInfo;
        }
        /// <summary>
        /// Thêm vào học kỳ 1, học kỳ 2 cùng với Niên học tương ứng
        /// </summary>
        /// <param name="maNienHoc"></param>
        public void ThemHocKy(string maNienHoc)
        {
            NienHocInfo nienHocInfo = this.LayNienhoc(maNienHoc);
            if (nienHocInfo != null)
            {
                hocKyData.ThemHocky(nienHocInfo);
            }
        }
        /// <summary>
        /// Xóa những học kỳ của Niên học
        /// </summary>
        /// <param name="maNienHoc"></param>
        public void XoaHocKy(string maNienHoc)
        {
            hocKyData.XoaHocKy(maNienHoc);
        }
        public bool CapNhat(ComboBoxEx comboBoxEx_NienHoc, DateTimeInput dateTimeInput_DauNam, DateTimeInput dateTimeInput_Dau_HK1, DateTimeInput dateTimeInput_Cuoi_HK1, DateTimeInput dateTimeInput_Dau_HK2, DateTimeInput dateTimeInput_Cuoi_HK2, DateTimeInput dateTimeInput_CuoiNam)
        {
            bool ok = false;
                        
            // cập nhật thời gian bắt đầu và kết thúc niên học
            nienHocInfo = new NienHocInfo(comboBoxEx_NienHoc.SelectedValue.ToString(), comboBoxEx_NienHoc.Text, dateTimeInput_DauNam.Value, dateTimeInput_CuoiNam.Value);
            ok = nienHocData.CapNhat(nienHocInfo) >= 0;

            // cập nhật những mốc thời gian từng học kỳ
            HocKyInfo hocKy1 = new HocKyInfo();
            hocKy1.MaNienhoc = comboBoxEx_NienHoc.SelectedValue.ToString();
            hocKy1.ThoiGianBatDau = dateTimeInput_Dau_HK1.Value;
            hocKy1.ThoiGianKetThuc = dateTimeInput_Cuoi_HK1.Value;            

            HocKyInfo hocKy2 = new HocKyInfo();
            hocKy2.MaNienhoc = comboBoxEx_NienHoc.SelectedValue.ToString();
            hocKy2.ThoiGianBatDau = dateTimeInput_Dau_HK2.Value;
            hocKy2.ThoiGianKetThuc = dateTimeInput_Cuoi_HK2.Value;

            ok = ok && hocKyData.CapNhatHocKy(hocKy1, hocKy2);
            
            return ok;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DevComponents.Editors.DateTimeAdv;
using DevComponents.DotNetBar.Controls;
using System.Windows.Forms;
using QLHSTPTTHSP.Initiation;
using QLHSTPTTHSP.DataLayer;

namespace QLHSTPTTHSP.Controller
{
    public class NienHocCtrl
    {
        NienHocData nienHocData = new NienHocData();
        public void LayDanhSachNienHoc(DataGridViewX dataGridView, BindingNavigator bindingNav, TextBoxX txtMaNienHoc, ComboBoxEx cmbTenNienHoc, DateTimeInput dateTimeTGBD, DateTimeInput dateTimeTGKT)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = nienHocData.LayBangNienHoc();
            bindingNav.BindingSource = bindingSource;
            dataGridView.DataSource = bindingSource;

            // Buộc text box mã niên học vào bindingSource
            txtMaNienHoc.DataBindings.Clear();
            txtMaNienHoc.DataBindings.Add("Text", bindingSource, "ma_nien_hoc");
            
            // Buộc combobox tên niên học vào bindingSource
            cmbTenNienHoc.DataBindings.Clear();
            cmbTenNienHoc.DataBindings.Add("Text", bindingSource, "ten_nien_hoc");

            // Buộc dateTime thời gian bắt đầu niên học vào bindingSource
            dateTimeTGBD.DataBindings.Clear();
            dateTimeTGBD.DataBindings.Add("Value", bindingSource, "tg_bat_dau", true).FormatString = "dd/MM/yyyy";

            // Buộc dateTime thời gian kết thúc niên học vào bindingSource
            dateTimeTGKT.DataBindings.Clear();
            dateTimeTGKT.DataBindings.Add("Value", bindingSource, "tg_ket_thuc", true).FormatString = "dd/MM/yyyy";

        }
        public string SinhMaNienHoc()
        {
            int max = Convert.ToInt32(this.LayMaNienHocMax()) + 1;
            string ma = "";
            if (max < 10)
                ma = "000" + max.ToString();
            else
                if (max < 100)
                    ma = "00" + max.ToString();
                else if (max < 1000)
                    ma = "0" + max.ToString();
                else ma = max.ToString();
            return "NH" + ma;
        }

        private string LayMaNienHocMax()
        {
            int Max = -1;
            int Current = 0;
            string MaMax = "0";
            DataTable table = new NienHocData().LayBangNienHoc("ma_nien_hoc");
            foreach (DataRow row in table.Rows)
            {
                try
                {
                    Current = Convert.ToInt32(row["ma_nien_hoc"].ToString().Trim().Substring(2));
                    if (Max < Current)
                    {
                        Max = Current;
                        MaMax = row["ma_nien_hoc"].ToString().Trim().Substring(2);
                    }
                }
                catch
                {
                    MaMax = "0000";
                }
            }
            return MaMax;
        }
        public DataRow ThemDongMoi()
        {
            return nienHocData.ThemDongMoi();
        }
        public void ThemNienHoc(DataRow row)
        {
            nienHocData.ThemNienHoc(row);
        }
        /// <summary>
        /// Cập nhật cơ sở dữ liệu và trả về kết quả có bao nhiêu dòng bị tác động
        /// </summary>
        /// <returns></returns>
        public int CapNhat()
        {
            return nienHocData.CapNhat();
        }
        
    }
}

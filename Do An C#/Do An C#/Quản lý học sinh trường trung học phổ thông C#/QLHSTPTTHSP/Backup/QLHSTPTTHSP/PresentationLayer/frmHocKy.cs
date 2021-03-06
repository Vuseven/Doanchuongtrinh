using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QLHSTPTTHSP.Controller;
using QLHSTPTTHSP.BusinessObjects;

namespace QLHSTPTTHSP.PresentationLayer
{
    public partial class frmHocKy : DevComponents.DotNetBar.Office2007Form
    {
        NienHocCtrl nienHocCtrl = new NienHocCtrl();
        HocKyCtrl hocKyCtrl = new HocKyCtrl();
        
        public frmHocKy()
        {
            InitializeComponent(); 
        }

        private void frmHocKy_Load(object sender, EventArgs e)
        {            
            hocKyCtrl.LoadComboBoxNienHoc(this.comboBoxEx_NienHoc);            
            hocKyCtrl.HienThiBieuDoThoiGian(this.comboBoxEx_NienHoc, this.dateTimeInput_DauNam, this.dateTimeInput_Dau_HK1, this.dateTimeInput_Cuoi_HK1, this.dateTimeInput_Dau_HK2, this.dateTimeInput_Cuoi_HK2, this.dateTimeInput_CuoiNam);
        }

        private void buttonXCapNhat_Click(object sender, EventArgs e)
        {
            if (this.comboBoxEx_NienHoc.SelectedIndex >= 0)
            {
                if (this.KiemTra())
                {
                    if (hocKyCtrl.CapNhat(this.comboBoxEx_NienHoc, this.dateTimeInput_DauNam, this.dateTimeInput_Dau_HK1, this.dateTimeInput_Cuoi_HK1, this.dateTimeInput_Dau_HK2, this.dateTimeInput_Cuoi_HK2, this.dateTimeInput_CuoiNam))
                    {
                        MessageBoxEx.Show("Cập nhật thành công!", "Xin chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBoxEx.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Kiểm tra chọn mốc thời gian
        /// </summary>
        /// <returns></returns>
        private bool KiemTra()
        {
            if (this.dateTimeInput_DauNam.Value.CompareTo(this.dateTimeInput_CuoiNam.Value) >= 0)
            {
                MessageBoxEx.Show("Thời gian bắt đầu niên học không thể trễ hơn Thời gian kết thúc niên học!", "Không thể cập nhật niên học " + this.comboBoxEx_NienHoc.SelectedValue.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.dateTimeInput_Dau_HK1.Value.CompareTo(this.dateTimeInput_DauNam.Value) < 0)
            {
                MessageBoxEx.Show("Thời gian bắt đầu học kỳ 1 không thể sớm hơn Thời gian bắt đầu niên học!", "Không thể cập nhật niên học " + this.comboBoxEx_NienHoc.SelectedValue.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.dateTimeInput_Cuoi_HK1.Value.CompareTo(this.dateTimeInput_Dau_HK1.Value) <= 0)
            {
                MessageBoxEx.Show("Thời gian kết thúc học kỳ 1 không thể sớm hơn Thời gian bắt đầu học kỳ 1!", "Không thể cập nhật niên học " + this.comboBoxEx_NienHoc.SelectedValue.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.dateTimeInput_Dau_HK2.Value.CompareTo(this.dateTimeInput_Cuoi_HK1.Value) < 0)
            {
                MessageBoxEx.Show("Thời gian bắt đầu học kỳ 2 không thể sớm hơn Thời gian kết thúc học kỳ 1!", "Không thể cập nhật niên học " + this.comboBoxEx_NienHoc.SelectedValue.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.dateTimeInput_Cuoi_HK2.Value.CompareTo(this.dateTimeInput_Dau_HK2.Value) <= 0)
            {
                MessageBoxEx.Show("Thời gian kết thúc học kỳ 2 không thể sớm hơn Thời gian bắt đầu học kỳ 2!", "Không thể cập nhật niên học " + this.comboBoxEx_NienHoc.SelectedValue.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.dateTimeInput_CuoiNam.Value.CompareTo(this.dateTimeInput_Cuoi_HK2.Value) < 0)
            {
                MessageBoxEx.Show("Thời gian kết thúc học kỳ 2 không thể trễ hơn Thời gian kết thúc niên học!", "Không thể cập nhật niên học " + this.comboBoxEx_NienHoc.SelectedValue.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            return true;
        }

        private void buttonX_DongLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.labelXThoiGian.Text = DateTime.Now.ToLongTimeString() + "  " + DateTime.Now.ToShortDateString();
        }        

        private void comboBoxEx_NienHoc_SelectedIndexChanged(object sender, EventArgs e)
        {                        
            hocKyCtrl.HienThiBieuDoThoiGian(this.comboBoxEx_NienHoc, this.dateTimeInput_DauNam, this.dateTimeInput_Dau_HK1, this.dateTimeInput_Cuoi_HK1, this.dateTimeInput_Dau_HK2, this.dateTimeInput_Cuoi_HK2, this.dateTimeInput_CuoiNam);
        }


    }
}
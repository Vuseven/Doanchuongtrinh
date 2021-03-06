using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLDiemSoHocSinhTHPT.BusinessObject;
using QLDiemSoHocSinhTHPT.Controller;

namespace QLDiemSoHocSinhTHPT.GiaoDien
{
    public partial class frmCapNhatPhanCong : Form
    {
        #region PhanCong
        private PhanCongInfo m_PhanCong;

        public PhanCongInfo PhanCong
        {
            get { return m_PhanCong; }
            set { m_PhanCong = value; }
        }

        #endregion

        public frmCapNhatPhanCong(PhanCongInfo phanCong)
        {
            InitializeComponent();
            this.PhanCong = phanCong;
        }

        private void frmCapNhatPhanCong_Load(object sender, EventArgs e)
        {
            this.txtMonHoc.Text = this.PhanCong.LopMonHoc.MonHoc.TenMonHoc;
            new GiaoVienController().HienThiComboBox(this.cmbGiaoVien, this.PhanCong.LopMonHoc.MonHoc);
            this.cmbGiaoVien.SelectedValue = this.PhanCong.GiaoVien.MaGiaoVien;
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            this.PhanCong.GiaoVien = new GiaoVienController().LayTuMa(((DataRowView)this.cmbGiaoVien.SelectedItem).Row.ItemArray[0].ToString());
            this.DialogResult = DialogResult.OK;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLDiemSoHocSinhTHPT;
using QLDiemSoHocSinhTHPT.Controller;
using QLDiemSoHocSinhTHPT.BusinessObject;

namespace QLDiemSoHocSinhTHPT.GiaoDien
{
    public partial class frmDangNhap : Form
    {
        #region TenDangNhap
        private string m_TenDangNhap;

        public string TenDangNhap
        {
            get { return m_TenDangNhap; }
            set { m_TenDangNhap = value; }
        }
        #endregion

        #region MatKhau
        private string m_MatKhau;

        public string MatKhau
        {
            get { return m_MatKhau; }
            set { m_MatKhau = value; }
        }
        #endregion

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.txtTenDangNhap.Text = "";
            this.txtMatKhau.Text = "";
            this.txtTenDangNhap.Focus();
        }

        public bool CheckValid()
        {
            if (this.txtTenDangNhap.Text == "" || this.txtTenDangNhap.Text == null)
            {
                MessageBox.Show("Chưa nhập tên!");
                this.txtTenDangNhap.Focus();
                return false;
            }
            if (this.txtMatKhau.Text == "" || this.txtMatKhau.Text == null)
            {
                MessageBox.Show("Chưa nhập mật khẩu!");
                this.txtMatKhau.Focus();
                return false;
            }
            return true;
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            if (CheckValid())
            {
                this.TenDangNhap = this.txtTenDangNhap.Text;
                this.MatKhau = this.txtMatKhau.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Dispose();
        }
    }
}
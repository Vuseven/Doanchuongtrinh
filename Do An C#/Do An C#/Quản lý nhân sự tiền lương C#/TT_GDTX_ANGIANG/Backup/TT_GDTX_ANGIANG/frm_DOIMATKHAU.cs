using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using System.Collections;
using TT_GDTX_ANGIANG.BusinessObject;
using TT_GDTX_ANGIANG.Controller;
using TT_GDTX_ANGIANG.DataLayer;

namespace TT_GDTX_ANGIANG
{
    public partial class frm_DOIMATKHAU : DevComponents.DotNetBar.Office2007Form
    {
        public frm_DOIMATKHAU()
        {
            InitializeComponent();
        }

        #region ctrlNguoiDung
        private NguoiDungCtrl m_ctrlNguoiDung;
        public NguoiDungCtrl ctrlNguoiDung
        {
            get { return m_ctrlNguoiDung; }
            set { m_ctrlNguoiDung = value; }
        }
        #endregion

        #region Property
        private String m_User;
        public String Lay_UserName
        {
            get { return m_User; }
            set { m_User = value; }
        }
        #endregion

        #region frm_DOIMATKHAU_Load        
       
        private void frm_DOIMATKHAU_Load(object sender, EventArgs e)
        {
            this.txtNguoiDung.Text = this.Lay_UserName;
        }
        #endregion


        #region btDongY_Click

        private void btDongY_Click(object sender, EventArgs e)
        {
            String username = this.txtNguoiDung.Text;
            String pass_Old = this.txtMKHienTai.Text;
            String pass_New = this.txtMKMoi.Text;

            if (this.CheckValid())
            {
                if (ctrlNguoiDung == null)
                    ctrlNguoiDung = new NguoiDungCtrl();

                int ketqua = ctrlNguoiDung.KiemTra_NguoiDung(username);
                if (ketqua == 1)
                {
                    int kq = ctrlNguoiDung.DoiMatKhau(pass_Old, pass_New);
                    if (kq == 0)
                    {
                        MessageBoxEx.Show("Thay đổi thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBoxEx.Show("Bạn đã quên mật khẩu hiện tại! Bạn nghĩ kỹ lại xem...", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtMKHienTai.Text = "";
                        this.txtMKMoi.Text = "";
                        this.txtKDMatKhau.Text = "";
                        this.txtMKHienTai.Focus();
                    }
                }
                else
                {

                }
            }
        }
        #endregion

        #region CheckValid()
        private bool CheckValid()
        {
            if (this.txtMKHienTai.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Bạn chưa nhập Mật khẩu hiện tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMKHienTai.Focus();
                return false;
            }
            if (this.txtMKMoi.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Mật khẩu mới không được phép rỗng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMKMoi.Focus();
                return false;
            }
            if (this.txtKDMatKhau.Text != this.txtMKMoi.Text)
            {
                MessageBoxEx.Show("Bạn đã quên mật khẩu vừa mới nhập. Xin vui lòng nhập lại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtMKMoi.Text = "";
                this.txtKDMatKhau.Text = "";
                this.txtMKMoi.Focus();
                return false;
            }
            return true;

        }
        #endregion

        #region btThoat_Click        
       
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        
    }
}
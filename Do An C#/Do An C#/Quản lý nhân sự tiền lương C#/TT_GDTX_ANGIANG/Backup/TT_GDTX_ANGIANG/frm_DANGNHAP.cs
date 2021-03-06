using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using System.Collections;
using TT_GDTX_ANGIANG.Controller;

namespace TT_GDTX_ANGIANG
{
    public partial class frm_DANGNHAP : DevComponents.DotNetBar.Office2007Form
    {
        public frm_DANGNHAP()
        {
            InitializeComponent();
        }

        #region ctrlNguoiDung
        private NguoiDungCtrl m_NguoiDung;
        public NguoiDungCtrl CtrlNguoiDung
        {
            get { return m_NguoiDung; }
            set { m_NguoiDung = value; }
        }
        #endregion


        #region frm_DANGNHAP_Load        
       
        private void frm_DANGNHAP_Load(object sender, EventArgs e)
        {
           
            this.ngaygio.Text = DateTime.Now.ToString();
            this.txtTAIKHOAN.Text = "";           
            this.txtMATKHAU.Text = "";
           
        }
        #endregion

        #region btDongY_Click        
       
        private void btDongY_Click(object sender, EventArgs e)
        {
            
            if (CheckValid())
            {
                this.txtTAIKHOAN.Focus();
                this.DialogResult = DialogResult.OK;
                
            }
           
            
        }
        #endregion

        #region CheckValid()
        public bool CheckValid()
        {
            if (this.txtTAIKHOAN.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Chưa nhập Tên đăng nhập!","Thông Báo");
                this.txtTAIKHOAN.Focus();
                return false;
            }
            if (this.txtMATKHAU.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Chưa nhập Mật khẩu đăng nhập!","Thông Báo");
                this.txtMATKHAU.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region btThoat_Click        
       
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        private void txtMATKHAU_KeyDown(object sender, KeyEventArgs e)
        {
           
               
                if (e.KeyCode == Keys.Enter)
                    this.btDongY_Click(sender, e);          
               

           
        }
    }
}
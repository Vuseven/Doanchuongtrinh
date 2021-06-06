using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;



namespace Quanlydoanvien
{
    public partial class frmLogin : DevComponents.DotNetBar.Office2007Form
    {
		

        private void btnExit_Click(object sender, EventArgs e)
        {
          
        }
        public void ktrong()
        {
            if (txtpass.Text == "" || txtuser.Text == "")
                MessageBoxEx.Show("Tên User hoặc Password không được rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBoxEx.Show("User name hoặc Password không đúng. Xin kiểm tra lại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        ClassNoiCSDL bd = new ClassNoiCSDL();
        private void btnlogin_Click(object sender, EventArgs e)
        {
           
            
            if (bd.Checklogin(txtuser.Text, txtpass.Text) != "")
            {
                frmFormchinh fc = new frmFormchinh();
                if (bd.Checklogin(txtuser.Text, txtpass.Text) == "Admin")
                {
                    MessageBoxEx.Show("Bạn đã đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fc.Show();
                    fc.adminenble();
                    string k = txtuser.Text;
                    fc.Text = "Chào Mừng " + txtuser.Text + " Đã Quay Trở Lại Chương Trình Quanlydoanvien Tonducthang University Software v1.0";
                    this.Hide();
                        
                                                           

                }
                else
                {
                    MessageBoxEx.Show("Bạn đã đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            
                        fc.Show();
                        fc.admindisble();
                        string k = txtuser.Text;
                        fc.Text = "Chào Mừng " + txtuser.Text + " Đã Quay Trở Lại Chương Trình Quanlydoanvien Tonducthang University Software v1.0";
                        this.Hide();                                    

                }

            }

            else
            {
                ktrong();
               
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                                
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult thoat = MessageBoxEx.Show("Có phải bạn muốn thoát khỏi chương trình này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.Yes)
                Application.Exit();

        }
       
   }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;
using System.Globalization;
using DevComponents.DotNetBar;


namespace Quanlydoanvien
{
    public partial class frmFormchinh : DevComponents.DotNetBar.Office2007Form
    {
        public frmFormchinh()
        {
            InitializeComponent();
          


        }

       
        
        
       
        private void frmFormchinh_Load(object sender, EventArgs e)
        {
        
            AdvancedCursors av = new AdvancedCursors();
            this.Cursor = AdvancedCursors.Create(@".\chopper.ani");
            timer1.Enabled = true;
            timer1.Start();
            labelX1.Text = DateTime.Now.ToLongTimeString();
            notifyIcon1.Visible = true;

            
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult thoat = MessageBoxEx.Show("Có phải bạn muốn thoát khỏi chương trình này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.Yes)
                Application.Exit();

        }

        public void adminenble()
        {
           
            
        }

        public void admindisble()
        {

            
            thayĐổiMậtKhẩuToolStripMenuItem.Enabled = true;

        }

        

       
        private void timer1_Tick(object sender, EventArgs e)
        {
            ClassNoiCSDL bd = new ClassNoiCSDL();
            this.Opacity = (float.Parse(slider1.Value.ToString())) / 100;
            labelX2.Text = slider1.Value.ToString() + "%";
            lblthoigian.Text = "Bây giờ là " + DateTime.Now.ToLongTimeString();
            lblngay.Text = "Ngày " + DateTime.Now.ToShortDateString();
            
            
        }
        



        private void quảnLýĐoànViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoanvien dv = new frmDoanvien();
            dv.Show();
        }



        private void quảnLýKỷLuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKyluat kl = new frmKyluat();
            kl.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            frmKyluat kl = new frmKyluat();
            kl.Show();
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {

        }

        

        private void quảnLýĐoànPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoanphi DP = new frmDoanphi();
            DP.Show();
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            frmDoanphi dp = new frmDoanphi();
            dp.Show();
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonItem10_Click_1(object sender, EventArgs e)
        {
            frmHinhthuckyluat htkl = new frmHinhthuckyluat();
            htkl.Show();

        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            frmNhanxet nx = new frmNhanxet();
            nx.Show();
        }

      

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            frmVipham vp = new frmVipham();
            vp.Show();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
           
        }

        

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmNhanxet nx = new frmNhanxet();
            nx.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmVipham vp = new frmVipham();
            vp.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmHinhthuckyluat htkl = new frmHinhthuckyluat();
            htkl.Show();
        }



        private void tìmKiếmĐoànViênChưaĐóngĐoànPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimliemDVchuadongDP dp = new frmTimliemDVchuadongDP();
            dp.Show();
        }

        private void frmFormchinh_Resize(object sender, EventArgs e)
        {
           

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.Focus();

        }

        private void mởLạiChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            this.WindowState = FormWindowState.Normal;
        }

        private void tắtChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void thoátKhỏiChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult thoat = MessageBoxEx.Show("Có phải bạn muốn thoát khỏi chương trình này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.Yes)
                Application.Exit();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            frmTimkiemdv tkdv = new frmTimkiemdv();
            tkdv.Show();
        }

        private void tìmKiếmĐoànViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimkiemdv tkdv = new frmTimkiemdv();
            tkdv.Show();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            frmTimliemDVchuadongDP dp = new frmTimliemDVchuadongDP();
            dp.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
           
        }

        private void thôngTinVềPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }

        private void thôngTinPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }

       

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Huongdan.chm";
            p.Start();

        }



        private void xuấtDanhSáchĐoànViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void xuấtDanhSáchĐoànViênBịKỷLuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKyluat th=new frmKyluat();
            try
            {
                              
            frmInKL kl = new frmInKL();
            kl.Show();
                
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Không thể bật chức năng này vì bạn chưa cài đặt ReportViewer!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       

        private void hươngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "Huongdan.chm";
            p.Start();
        }
       
        
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin lf = new frmLogin();
            lf.Show();
        }



        private void qủanLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoginmanager mn = new frmLoginmanager();
            mn.Show();
        }
       
        private void frmFormchinh_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                
            }
            else
            {
                notifyIcon1.Visible = false;
                
            }
        }
      

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

       

        private void bubbleButton3_Click(object sender, DevComponents.DotNetBar.ClickEventArgs e)
        {
           
        }

       
        private void thayĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePass cp = new frmChangePass();
            cp.Show();
        }

       
        frmDoanvien dv = new frmDoanvien();
        private void inDanhSáchTátCảCácĐoànViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
             
                
                    frmInDV kk = new frmInDV();
                    kk.Show();
                
            }
            catch (Exception)
            {
                MessageBoxEx.Show(" Bạn chưa cài đặt Reportreview để bật chức năng này!", " Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void inDaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                frmInDVNu dvk = new frmInDVNu();
                dvk.Show();

            }
            catch (Exception)
            {
                MessageBoxEx.Show(" Bạn chưa cài đặt Reportreview để bật chức năng này!", " Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                      
        }

        private void inDanhSáchĐoànViênNamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                frmInDVNam dvn = new frmInDVNam();
                dvn.Show();

            }
            catch (Exception)
            {
                MessageBoxEx.Show(" Bạn chưa cài đặt Reportreview để bật chức năng này!", " Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void xuấtDanhSáchCácĐoànViênChưĐóngĐoànPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                frmInDP dp = new frmInDP();
                dp.Show();

            }
            catch (Exception)
            {
                MessageBoxEx.Show(" Bạn chưa cài đặt Reportreview để bật chức năng này!", " Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DialogResult thoat = MessageBoxEx.Show("Có phải bạn muốn thoát khỏi chương trình này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.Yes)
                Application.Exit();
            else
            {
            }
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void frmFormchinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            
                Application.Exit();
            
        }

        private void btndv_Click(object sender, EventArgs e)
        {
            frmDoanvien dv = new frmDoanvien();
            dv.Show();
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using QuanLyNhaSach.Control;
using QuanLyNhaSach.Builder_layer;


namespace QuanLyNhaSach
{
    public partial class frmTonKho : DockContent
    {
        TonKhoCtrl tk_Ctrl = new TonKhoCtrl();         
        CurrencyManager row;
        DataTable tbl_TonKho;
        public frmTonKho()
        {
            InitializeComponent();
            LoadTable();
            hienthilen_TextBox();
            an_TextBox();
        }      

        void LoadTable()
        {
            tbl_TonKho = tk_Ctrl.Tbl_SachTK();
            row = BindingContext[tbl_TonKho] as CurrencyManager;
            dataGridView1.DataSource = tbl_TonKho;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            hienthilen_TextBox();            
        }

        void hienthilen_TextBox()
        {            
            txtMaSach.Text = tbl_TonKho.Rows[row.Position]["MASACH"].ToString();
            txtThang.Text = tbl_TonKho.Rows[row.Position]["THANG"].ToString();
            txtNam.Text = tbl_TonKho.Rows[row.Position]["NAM"].ToString();
            txtDGBQ.Text = tbl_TonKho.Rows[row.Position]["DONGIABQ"].ToString();
            txtTongNhap.Text = tbl_TonKho.Rows[row.Position]["TONGNHAP"].ToString();
            txtTongXuat.Text = tbl_TonKho.Rows[row.Position]["TONGXUAT"].ToString();
            txtTonDK.Text = tbl_TonKho.Rows[row.Position]["TONDAUKY"].ToString();
            txtTonCK.Text = tbl_TonKho.Rows[row.Position]["TONCUOIKY"].ToString();
        }

        void an_TextBox()
        {

            txtMaSach.Enabled = false;
            txtThang.Enabled = false;
            txtNam.Enabled = false;
            txtDGBQ.Enabled = false;
            txtTongNhap.Enabled = false;
            txtTongXuat.Enabled = false;
            txtTonDK.Enabled = false;
            txtTonCK.Enabled = false;
        }

        void HienTextBox()
        {

            txtMaSach.Enabled = true;
            txtThang.Enabled = true;
            txtNam.Enabled = true;
            txtDGBQ.Enabled = true;
            txtTongNhap.Enabled = true;
            txtTongXuat.Enabled = true;
            txtTonDK.Enabled = true;
            txtTonCK.Enabled = true;
        }

        void XoaTextBox()
        {
            txtMaSach.Text= "";
            txtThang.Text = "";
            txtNam.Text = "";
            txtDGBQ.Text = "";
            txtTongNhap.Text = "";
            txtTongXuat.Text = "";
            txtTonDK.Text = "";
            txtTonCK.Text = "";
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            row.Position--;
            hienthilen_TextBox();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            row.Position++;
            hienthilen_TextBox();
        }
        private void btnTKTC_Click(object sender, EventArgs e)
        {
            frmTimSachTon tk = new frmTimSachTon();
            tk.ShowDialog();

            if (tk.DialogResult == DialogResult.OK)
            {
                //-- tao moi doi tuong tra ve
                TonKhoInfo tk_Info = tk.TONKHO;

                //--bo thong tin vao cac object
                txtMaSach.Text = tk_Info.MaSach;
                txtThang.Text = tk_Info.Thang;
                txtNam.Text = tk_Info.Nam;
                txtDGBQ.Text = tk_Info.DonGia;
                txtTongNhap.Text = tk_Info.TongNhap;
                txtTongXuat.Text = tk_Info.TongXuat;
                txtTonDK.Text = tk_Info.TonDauKy;
                txtTonCK.Text = tk_Info.TonCuoiKy;
            }
        }

        bool them = false;
        private void btnThem_Click(object sender, EventArgs e)
        {
            HienTextBox();
            XoaTextBox();
            them = true;        
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            tk_Ctrl.XoaSachTon(txtMaSach.Text);
            LoadTable();
            hienthilen_TextBox();
            an_TextBox();
        }

        bool sua = false;
        string maNV;
        private void btnSua_Click(object sender, EventArgs e)
        {         
            HienTextBox();
            sua = true;
            maNV = txtMaSach.Text;        
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                tk_Ctrl.ThemSachTon(txtMaSach.Text, txtThang.Text, txtNam.Text, txtDGBQ.Text, txtTongNhap.Text, txtTongXuat.Text, txtTonDK.Text, txtTonCK.Text);
                them = false;
            }
            if (sua)
            {
                TonKhoInfo tk_Info = new TonKhoInfo();
                tk_Info.MaSach = txtMaSach.Text;
                tk_Info.Thang = txtThang.Text;
                tk_Info.Nam = txtNam.Text;
                tk_Info.DonGia = txtDGBQ.Text;
                tk_Info.TongNhap = txtTongNhap.Text;
                tk_Info.TongXuat = txtTongXuat.Text;
                tk_Info.TonDauKy = txtTonDK.Text;
                tk_Info.TonCuoiKy = txtTonCK.Text;                
                tk_Ctrl.UpdateSachTon(tk_Info, maNV);
                sua = false;
            }
            LoadTable();
            an_TextBox();
        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đã chắc chắn thoát!", "QUANLYNHASACH", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            tk_Ctrl.load_data(txtMaSach, txtThang, txtNam, txtDGBQ, txtTongNhap, txtTongXuat, txtTonDK, txtTonCK, dataGridView1.Rows[e.RowIndex]);
        }
    }
}
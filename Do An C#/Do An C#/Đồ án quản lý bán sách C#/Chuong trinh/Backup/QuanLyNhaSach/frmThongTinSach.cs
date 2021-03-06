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
    public partial class frmThongTinSach : DockContent
    {
        ThongTinSachCtrl tts_Ctrl = new ThongTinSachCtrl();
        CurrencyManager row;
        DataTable tbl_ThongTinSach;

        public frmThongTinSach()
        {
            InitializeComponent();
            LoadTable();
            hienthilen_TextBox();
            an_TextBox();
        }
        bool them = false;
        private void btnThem_Click(object sender, System.EventArgs e)
        {
            HienTextBox();
            XoaTextBox();
            them = true;
        }

        void LoadTable()
        {
            tbl_ThongTinSach = tts_Ctrl.Tbl_ThongTinSach();
            row = BindingContext[tbl_ThongTinSach] as CurrencyManager;
            dataGridView1.DataSource = tbl_ThongTinSach;
        }
       
        bool sua = false;
        string maSach;       
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            hienthilen_TextBox();
        }
        void hienthilen_TextBox()
        {
            txtMaSach.Text = tbl_ThongTinSach.Rows[row.Position]["MASACH"].ToString();
            txtTheLoai.Text = tbl_ThongTinSach.Rows[row.Position]["THELOAISACH"].ToString();
            txtTenSach.Text = tbl_ThongTinSach.Rows[row.Position]["TENSACH"].ToString();                                
            txtTacGia.Text = tbl_ThongTinSach.Rows[row.Position]["TACGIA"].ToString();
            txtDonGia.Text = tbl_ThongTinSach.Rows[row.Position]["DONGIA"].ToString();
            txtSoLuong.Text = tbl_ThongTinSach.Rows[row.Position]["SOLUONG"].ToString();
            txtNamXB.Text = tbl_ThongTinSach.Rows[row.Position]["NAMXB"].ToString();
            txtNhaXB.Text = tbl_ThongTinSach.Rows[row.Position]["NHAXB"].ToString();
        }

        void an_TextBox()
        {

            txtMaSach.Enabled = false;
            txtTheLoai.Enabled = false;
            txtTenSach.Enabled = false;
            txtTacGia.Enabled = false;
            txtDonGia.Enabled = false;
            txtSoLuong.Enabled = false;
            txtNamXB.Enabled = false;
            txtNhaXB.Enabled = false;
        }

        void HienTextBox()
        {

             txtMaSach.Enabled = true;
            txtTheLoai.Enabled = true;
            txtTenSach.Enabled = true;
            txtTacGia.Enabled = true;
            txtDonGia.Enabled = true;
            txtSoLuong.Enabled = true;
            txtNamXB.Enabled = true;
            txtNhaXB.Enabled = true;
        }

        void XoaTextBox()
        {
            txtMaSach.Text = " ";
            txtTheLoai.Text = " ";
            txtTenSach.Text = " ";
            txtTacGia.Text = " ";
            txtDonGia.Text = " ";
            txtSoLuong.Text = " ";
            txtNamXB.Text = " ";
            txtNhaXB.Text = " ";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            tts_Ctrl.XoaThongTinSach(txtMaSach.Text);
            LoadTable();
            hienthilen_TextBox();
            an_TextBox();
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "" || txtTheLoai.Text == "" || txtTenSach.Text == "" || txtTacGia.Text == "" || txtSoLuong.Text == "" || txtNhaXB.Text == "" || txtNamXB.Text == "" || txtDonGia.Text == "")
            {
                MessageBox.Show("Thông tin nhập ko được trống");
                txtMaSach.Focus();
            }
            else
            {
                if (them)
                {
                    tts_Ctrl.ThemThongTinSach(txtMaSach.Text,txtTheLoai.Text, txtTenSach.Text, txtTacGia.Text, txtDonGia.Text,txtSoLuong.Text,txtNamXB.Text,txtNhaXB.Text);
                    them = false;
                }
                if (sua)
                {
                    ThongTinSachInfo tts_Info = new ThongTinSachInfo();
                    tts_Info.MaSach = txtMaSach.Text;
                    tts_Info.LoaiSach = txtTheLoai.Text;
                    tts_Info.TenSach = txtTenSach.Text;
                    tts_Info.TacGia = txtTacGia.Text;
                    tts_Info.DonGia = txtDonGia.Text;
                    tts_Info.SoLuong = txtSoLuong.Text;
                    tts_Info.NamXB = txtNamXB.Text;
                    tts_Info.NhaXB = txtNhaXB.Text;
                    tts_Ctrl.UpdateTTS(tts_Info, maSach);
                    sua = false;
                }
                LoadTable();
                an_TextBox();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            HienTextBox();
            sua = true;
            maSach = txtMaSach.Text;
        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }

 }

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
    public partial class frmDanhMucLoaiSach : DockContent
    {
        DanhMucLoaiSachCtrl dmls_Ctrl = new DanhMucLoaiSachCtrl();
        ErrorInfo er_Info = new ErrorInfo();
        
        public frmDanhMucLoaiSach()
        {
            InitializeComponent();
        }
        void Enable()
        { 
            txtMaLS.Enabled = true;
            txtTenLS.Enabled = true;
        }
        void Disable()
        {
            txtMaLS.Enabled = false;
            txtTenLS.Enabled = false;
        }
        private void frmDanhMucLoaiSach_Load(object sender, EventArgs e)
        {
            dmls_Ctrl.HienThi(dataGridView1);
            Disable();
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {          
            dmls_Ctrl.load_data(txtMaLS,txtTenLS, dataGridView1.Rows[e.RowIndex]);
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            er_Info = dmls_Ctrl.themLoaiSach(txtMaLS, txtTenLS);
            if (er_Info.Loi == 0)
            {
                MessageBox.Show(er_Info.Message, "Lỗi khi thêm loại sách");
            }
            dmls_Ctrl.HienThi(dataGridView1);
            Disable();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaLS.Text = "";
            txtTenLS.Text = "";
            Enable();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            er_Info = dmls_Ctrl.xoaLoaiSach(txtMaLS,txtTenLS);
            if (er_Info.Loi == 0)
            {
                MessageBox.Show(er_Info.Message, "Lỗi khi xóa loại sách");
            }
            dmls_Ctrl.HienThi(dataGridView1);
            Disable();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đã chắc chắn thoát!", "QUANLYNHASACH", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                this.Close();
            } 
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaLS.Enabled = true;
            txtTenLS.Enabled = true;
        }

        private void btnLS_Click(object sender, EventArgs e)
        {
            er_Info = dmls_Ctrl.capnhatLoaiSach(txtMaLS, txtTenLS);
            if (er_Info.Loi == 0)
            {
                MessageBox.Show(er_Info.Message, "Lỗi khi cập nhật loại sách ");
            }
            dmls_Ctrl.HienThi(dataGridView1);
            Disable();
        }
    }
}
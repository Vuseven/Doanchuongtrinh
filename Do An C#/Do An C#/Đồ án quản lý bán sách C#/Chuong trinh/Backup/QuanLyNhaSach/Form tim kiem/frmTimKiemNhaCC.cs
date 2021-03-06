using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using QuanLyNhaSach.Control;
using QuanLyNhaSach.Data;
using QuanLyNhaSach.Builder_layer;

namespace QuanLyNhaSach
{
    public partial class frmTimKiemNhaCC : Form
    {
        NhaCungCapCtrl ncc_Ctrl = new NhaCungCapCtrl();
        private NhaCungCapInfo m_ncc;
        public NhaCungCapInfo NCC
        {
            get { return m_ncc; }
            set { m_ncc = value; }
        }
        public frmTimKiemNhaCC()
        {
            InitializeComponent();
            ncc_Ctrl.LoadComboBox(cbMaNCC, "MANCC", "MANCC");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ncc_Ctrl.TimNCC(cbMaNCC, cbHoTenNC, txtTenNCC, cbDCNC, txtDiaChi, cbDTNC, txtDT, dataGridView1);
        }

        private void frmTimKiemNhaCC_Load(object sender, EventArgs e)
        {
            cbMaNCC.Text = "Chọn mã NCC";
            //ncc_Ctrl.HienThi(dataGridView1, bindingNavigator1);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            IEnumerator ie = dataGridView1.SelectedRows.GetEnumerator();

            if (ie.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)ie.Current;
                m_ncc = new NhaCungCapInfo();
                m_ncc.MaNhaCungCap = row.Cells[0].Value.ToString();
                m_ncc.TenNhaCungCap = row.Cells[1].Value.ToString();
                m_ncc.DiaChi = row.Cells[2].Value.ToString();                
                m_ncc.DienThoai = row.Cells[3].Value.ToString();
                m_ncc.MaSoThue = row.Cells[4].Value.ToString();
                m_ncc.GhiChu = row.Cells[5].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đã chắc chắn thoát!", "QUANLYNHASACH", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
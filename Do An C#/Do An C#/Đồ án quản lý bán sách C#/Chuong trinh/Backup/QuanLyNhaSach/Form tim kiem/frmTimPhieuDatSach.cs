using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuanLyNhaSach.Control;
using QuanLyNhaSach.Builder_layer;
using System.Data.OleDb;

namespace QuanLyNhaSach
{
    public partial class frmTimPhieuDatSach : Form
    {
        PhieuDatCtrl pd_Ctrl = new PhieuDatCtrl();        
        private PhieuDatSachInfo m_PD;
        public PhieuDatSachInfo PD
        {
            get { return m_PD; }
            
        }
        
        public frmTimPhieuDatSach()
        {
            InitializeComponent();
        }       

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmTimPhieuDatSach tim = new frmTimPhieuDatSach();
            tim.dataGridView1.DataBindings.Clear();
            pd_Ctrl.timPhieuDatSach(txtMaPD, cbChonMaNV, txtMaNV, cbChonNCC, txtMaNCC, cbChonNgay, dtTuNgay, dtDenNgay, dataGridView1);
            toolStripButton2.Enabled = true;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmTimPhieuDatSach timPD = new frmTimPhieuDatSach();
            timPD.dataGridView1.Columns.Clear();
            IEnumerator ie = dataGridView1.SelectedRows.GetEnumerator();
            m_PD = new PhieuDatSachInfo();
            if (ie.MoveNext())
            {
                DataGridViewRow row = (DataGridViewRow)ie.Current;
                m_PD = new PhieuDatSachInfo();
                //MessageBox.Show(m_PD.MaPhieuDatSach);
                m_PD.MaPhieuDatSach = row.Cells[0].Value.ToString();
                //MessageBox.Show(m_PD.MaNhanVien);
                m_PD.MaNhanVien = row.Cells[1].Value.ToString();
                m_PD.MaNhaCC = row.Cells[2].Value.ToString();
                //m_PD.TongTien = Convert.ToInt64(row.Cells[3].Value.ToString());
                m_PD.NgayDat = Convert.ToDateTime(row.Cells[3].Value.ToString());
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
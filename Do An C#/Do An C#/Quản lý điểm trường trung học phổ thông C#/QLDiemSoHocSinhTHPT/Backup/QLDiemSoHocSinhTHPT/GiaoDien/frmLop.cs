using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLDiemSoHocSinhTHPT.Controller;

namespace QLDiemSoHocSinhTHPT.GiaoDien
{
    public partial class frmLop : Form
    {
       
        #region Controller
        private LopController m_Controller;

        public LopController Controller
        {
            get { return m_Controller; }
            set { m_Controller = value; }
        }

        #endregion

        #region KhoiLopController
        private KhoiLopController m_KhoiLopController;

        public KhoiLopController KhoiLopController
        {
            get { return m_KhoiLopController; }
            set { m_KhoiLopController = value; }
        }
        #endregion
        
        #region NamHocController
        private NamHocController m_NamHocController;

        public NamHocController NamHocController
        {
            get { return m_NamHocController; }
            set { m_NamHocController = value; }
        }
        #endregion

        #region GiaoVienController
        private GiaoVienController m_GiaoVienController;

        public GiaoVienController GiaoVienController
        {
            get { return m_GiaoVienController; }
            set { m_GiaoVienController = value; }
        }
        #endregion
 
        public frmLop()
        {
            InitializeComponent();
            this.Controller = new LopController();
            this.KhoiLopController = new KhoiLopController();
            this.NamHocController = new NamHocController();
            this.GiaoVienController = new GiaoVienController();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLop_Load(object sender, EventArgs e)
        {
            //Khoi tao doi tuong m_Controller
            if (this.Controller == null)
            {
                this.Controller = new LopController();
            }

            //Khoi tao doi tuong m_KhoiLopController
            if (this.KhoiLopController == null)
            {
                this.KhoiLopController = new KhoiLopController();
            }

            //Khoi tao doi tuong m_NamHocController
            if (this.NamHocController == null)
            {
                this.NamHocController = new NamHocController();
            }

            //Khoi tao doi tuong m_GiaoVienController
            if (this.GiaoVienController == null)
            {
                this.GiaoVienController = new GiaoVienController();
            }

            //Hien thi ComboBox Khoi lop
            this.KhoiLopController.HienThiCombobox(this.cmbMaKhoiLop);
            //Hien thi DataGridViewComboBoxColumn khoi lop
            this.KhoiLopController.HienThiDataGridComboBoxColumn(this.colMaKhoiLop);

            //Hien thi ComboBox Nam hoc
            this.NamHocController.HienThiCombobox(this.cmbMaNamHoc);
            //Hien thi DataGridViewComboBoxColumn Nam hoc
            this.NamHocController.HienThiDataGridComboBoxColumn(this.colMaNamHoc);

            //Hien thi ComboBox Giao vien
            this.GiaoVienController.HienThiComboBox(this.cmbMaGiaoVien);
            //Hien thi DataGridViewComboBoxColumn Giao vien
            this.GiaoVienController.HienThiDataGridComboBoxColumn(this.colMaGiaoVien);


            //Hien thi DS lop
            this.Controller.HienThiDS(this.txtMaLop, this.txtTenLop, this.txtSiSo, this.cmbMaKhoiLop, this.cmbMaNamHoc, this.cmbMaGiaoVien, this.dgvDS, this.bnDS);
            //Neu trong danh sach khong co dong nao
            if (this.dgvDS.Rows.Count == 0)
            {
                this.btXoa.Enabled = false;
                this.itXoa.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btThemMoi_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)this.bnDS.BindingSource.AddNew();
            this.bnDS.BindingSource.MoveLast();

            this.btThemMoi.Enabled = false;
            this.btXoa.Enabled = false;
            this.btBoQua.Enabled = true;
            this.btLuu.Enabled = true;

            this.itThemMoi.Enabled = false;
            this.itXoa.Enabled = false;
            this.itBoQua.Enabled = true;
            this.itLuu.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btBoQua_Click(object sender, EventArgs e)
        {
            this.Controller.Data.LayDS();

            this.btThemMoi.Enabled = true;
            this.btXoa.Enabled = true;
            this.btLuu.Enabled = false;
            this.btBoQua.Enabled = false;

            this.itThemMoi.Enabled = true;
            this.itXoa.Enabled = true;
            this.itLuu.Enabled = false;
            this.itBoQua.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btLuu_Click(object sender, EventArgs e)
        {
            //Dua con tro de bindingNavigatorPositionItem
            this.bindingNavigatorPositionItem.Focus();
            //Bind de dong cuoi de cap nhat thong tin tren DataGridView
            this.bnDS.BindingSource.Position = int.Parse(this.bindingNavigatorPositionItem.Text);
            //Neu luu thanh cong
            if (!this.Controller.Update())
            {
                MessageBox.Show("Không thể lưu!", "Lưu lớp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Controller.Data.LayDS();
            }
            
            
            this.btThemMoi.Enabled = true;
            this.btXoa.Enabled = true;
            this.btBoQua.Enabled = false;
            this.btLuu.Enabled = false;

            this.itThemMoi.Enabled = true;
            this.itXoa.Enabled = true;
            this.itBoQua.Enabled = false;
            this.itLuu.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc xóa không?", "Xóa lớp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IEnumerator ie = this.dgvDS.SelectedRows.GetEnumerator();
                //Truong hop co nhieu dong duoc chon
                if (ie.MoveNext())
                {
                    DataGridViewRow row = (DataGridViewRow)ie.Current;
                    this.dgvDS.Rows.Remove(row);
                    while (ie.MoveNext())
                    {
                        row = (DataGridViewRow)ie.Current;
                        this.dgvDS.Rows.Remove(row);
                    }
                }
                else    //Chi chon mot dong
                {
                    this.bnDS.BindingSource.RemoveCurrent();
                }

                if (this.Controller.Update())
                {
                    MessageBox.Show("Đã xóa!", "Xóa lớp", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Neu trong danh sach khong con dong nao
                    if (this.dgvDS.Rows.Count == 0)
                    {
                        this.btXoa.Enabled = false;
                        this.itXoa.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xóa!", "Xóa lớp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    //Khong the xoa, load lai danh sach
                    this.Controller.Data.LayDS();

                }
            }
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btThemNamHoc_Click(object sender, EventArgs e)
        {
            frmNamHoc frm_NamHoc = new frmNamHoc(this.NamHocController);
            frm_NamHoc.WindowState = FormWindowState.Normal;
            frm_NamHoc.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btThemKhoiLop_Click(object sender, EventArgs e)
        {
            frmKhoiLop frm_KhoiLop = new frmKhoiLop(this.KhoiLopController);
            frm_KhoiLop.WindowState = FormWindowState.Normal;
            frm_KhoiLop.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btThemGVCN_Click(object sender, EventArgs e)
        {
            frmGiaoVien frm_GiaoVien = new frmGiaoVien(this.GiaoVienController);
            frm_GiaoVien.WindowState = FormWindowState.Normal;
            frm_GiaoVien.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDS_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /* 
        * Khi co mot cell trong DataGridView bo thay doi gia tri
        * Ta cho enable va disable cac button va cac item context menu cho phu hop
        * */
            this.btBoQua.Enabled = true;
            this.btLuu.Enabled = true;
            this.btThemMoi.Enabled = false;
            this.btXoa.Enabled = false;

            this.itBoQua.Enabled = true;
            this.itLuu.Enabled = true;
            this.itThemMoi.Enabled = false;
            this.itXoa.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLop_Shown(object sender, EventArgs e)
        {
            this.btThemMoi.Enabled = true;
            this.btXoa.Enabled = true;

            this.itThemMoi.Enabled = true;
            this.itXoa.Enabled = true;
        }                     
    }
}
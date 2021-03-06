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
    public partial class frmTimHocSinh1 : Form
    {
        public frmTimHocSinh1()
        {
            InitializeComponent();
        }

        #region Controller
        private HocSinhController m_Controller;

        public HocSinhController Controller
        {
            get { return m_Controller; }
            set { m_Controller = value; }
        }

        #endregion

        #region DanTocController
        private DanTocController m_DanTocController;

        public DanTocController DanTocController
        {
            get { return m_DanTocController; }
            set { m_DanTocController = value; }
        }

        #endregion

        #region TonGiaoController
        private TonGiaoController m_TonGiaoController;

        public TonGiaoController TonGiaoController
        {
            get { return m_TonGiaoController; }
            set { m_TonGiaoController = value; }
        }

        #endregion

        #region NgheNghiepChaController
        private NgheNghiepController m_NgheNghiepChaController;

        public NgheNghiepController NgheNghiepChaContorller
        {
            get { return m_NgheNghiepChaController; }
            set { m_NgheNghiepChaController = value; }
        }

        #endregion

        #region NgheNghiepMeController
        private NgheNghiepController m_NgheNghiepMeController;

        public NgheNghiepController NgheNghiepMeController
        {
            get { return m_NgheNghiepMeController; }
            set { m_NgheNghiepMeController = value; }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTimHocSinh1_Load(object sender, EventArgs e)
        {
            //Khoi tao doi tuong m_DanTocController
            if (this.DanTocController == null)
            {
                this.DanTocController = new DanTocController();
            }

            //Khoi tao doi tuong m_TonGiaoController
            if (this.TonGiaoController == null)
            {
                this.TonGiaoController = new TonGiaoController();
            }

            //Khoi tao doi tuong m_NgheNghiepController
            if (this.NgheNghiepChaContorller == null)
            {
                this.NgheNghiepChaContorller = new NgheNghiepController();
            }

            //Khoi tao doi tuong m_NgheNghiepController
            if (this.NgheNghiepMeController == null)
            {
                this.NgheNghiepMeController = new NgheNghiepController();
            }


            this.DanTocController.HienThiDataGridComboBoxColumn(this.colDanToc);
            this.TonGiaoController.HienThiDataGridComboBoxColumn(this.colTonGiao);
            this.NgheNghiepChaContorller.HienThiDataGridComboBoxColumn(this.colNNghiepCha, "MaNNghiepCha");
            this.NgheNghiepMeController.HienThiDataGridComboBoxColumn(this.colNNghiepMe, "MaNNghiepMe");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btTim_Click(object sender, EventArgs e)
        {
            if (this.Controller == null)
            {
                this.Controller = new HocSinhController();
            }
            this.Controller.TimTenHocSinh(dgvDS, bnDS, txtTenHocSinh.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btBoQua_Click(object sender, EventArgs e)
        {
            this.Controller.Data.LayDS();

            this.btXoa.Enabled = true;
            this.btLuu.Enabled = false;
            this.btBoQua.Enabled = false;
        }


        private void btLuu_Click(object sender, EventArgs e)
        {
            //Dua con tro de bindingNavigatorPositionItem
            this.bindingNavigatorPositionItem.Focus();
            //Bind de dong cuoi de cap nhat thong tin tren DataGridView
            this.bnDS.BindingSource.Position = int.Parse(this.bindingNavigatorPositionItem.Text);
            //Neu luu thanh cong
            if (!this.Controller.Update())
            {
                if (MessageBox.Show("Không thể lưu!\nBạn cần nhập đầy đủ thông tin trước khi lưu lại!\nBạn có muốn tiếp tục không?", "Lưu học sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                {
                    this.Controller.Data.LayDS();
                    this.btXoa.Enabled = true;
                    this.btBoQua.Enabled = false;
                    this.btLuu.Enabled = false;
                }
            }
            else
            {
                //this.btThemMoi.Enabled = true;
                this.btXoa.Enabled = true;
                this.btBoQua.Enabled = false;
                this.btLuu.Enabled = false;

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc xóa không?", "Xóa học sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    MessageBox.Show("Đã xóa!", "Xóa học sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Neu trong danh sach khong con dong nao
                    if (this.dgvDS.Rows.Count == 0)
                    {
                        this.btXoa.Enabled = false;
                      }
                }
                else
                {
                    MessageBox.Show("Không thể xóa!", "Xóa học sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Controller = new HocSinhController();
                    //Khong the xoa, load lai danh sach
                    this.Controller.Data.LayDS();
                    //GiaoVienController.this.Controller.HienThiDS(this.dgvList, this.bn);
                }
            }
        }

        private void btThoat1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btChinhSua_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
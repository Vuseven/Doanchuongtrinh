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
    public partial class frmNgheNghiep : Form
    {
        #region Controller
        private NgheNghiepController m_Controller;

        public NgheNghiepController Controller
        {
            get { return m_Controller; }
            set { m_Controller = value; }
        }

        #endregion

        public frmNgheNghiep()
        {
            InitializeComponent();
        }

        public frmNgheNghiep(NgheNghiepController nn)
        {
            InitializeComponent();
            this.Controller = nn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNgheNghiep_Load(object sender, EventArgs e)
        {
            //Khoi tao doi tuong m_Controller
            if (this.Controller == null)
            {
                this.Controller = new NgheNghiepController();
            }


            this.Controller.HienThiDS(dgvDS, bnDS);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btThemMoi_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)this.bnDS.BindingSource.AddNew();
            row["MaNghe"] = this.PhatSinhMa();
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
        /// <returns></returns>
        public int PhatSinhMa()
        {
            int lastID = new NgheNghiepController().LayMaCuoi();
            lastID++;
            return lastID;
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
                MessageBox.Show("Không thể lưu!", "Lưu nghề nghiệp", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (MessageBox.Show("Bạn có chắc xóa không?", "Xóa nghề nghiệp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    MessageBox.Show("Đã xóa!", "Xóa nghề nghiệp", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Neu trong danh sach khong con dong nao
                    if (this.dgvDS.Rows.Count == 0)
                    {
                        this.btXoa.Enabled = false;
                        this.itXoa.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xóa!", "Xóa nghề nghiệp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    //Khong the xoa, load lai danh sach
                    this.Controller.Data.LayDS();

                }
            }
        }

        /// <summary>
        /// 
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
        private void frmNgheNghiep_Shown(object sender, EventArgs e)
        {
            this.btThemMoi.Enabled = true;
            this.btXoa.Enabled = true;

            this.itThemMoi.Enabled = true;
            this.itXoa.Enabled = true;
        }
    }
}
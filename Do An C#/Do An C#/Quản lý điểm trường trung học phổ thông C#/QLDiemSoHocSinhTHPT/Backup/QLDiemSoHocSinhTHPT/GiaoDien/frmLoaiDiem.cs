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
    public partial class frmLoaiDiem : Form
    {
        //LoaiDiemController loaiDiemCtrl = new LoaiDiemController();
        public frmLoaiDiem()
        {
            InitializeComponent();
            this.Controller = new LoaiDiemController();
        }

        #region Controller
        private LoaiDiemController m_Controller;

        public LoaiDiemController Controller
        {
            get { return m_Controller; }
            set { m_Controller = value; }
        }
        #endregion

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btThemMoi_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)this.bnDS.BindingSource.AddNew();
            row["MaLoai"] = this.PhatSinhMa();
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
            //if (!this.Controller.Update())
            if (!this.Controller.Update())
            {
                MessageBox.Show("Không thể lưu!", "Lưu loại điểm", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc xóa không?", "Xóa hạnh kiểm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                //if (this.Controller.Update())
                if (this.Controller.Update())
                {
                    MessageBox.Show("Đã xóa!", "Xóa hạnh kiểm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Neu trong danh sach khong con dong nao
                    if (this.dgvDS.Rows.Count == 0)
                    {
                        this.btXoa.Enabled = false;
                        this.itXoa.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xóa!", "Xóa hạnh kiểm", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void frmLoaiDiem_Load(object sender, EventArgs e)
        {
            //Khoi tao doi tuong m_Controller
            if (this.Controller == null)
            {
                this.Controller = new LoaiDiemController();
            }

            this.Controller.HienThiDS(dgvDS, bnDS);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDS_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
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
        private void frmLoaiDiem_Shown(object sender, EventArgs e)
        {
            this.btThemMoi.Enabled = true;
            this.btXoa.Enabled = true;

            this.itThemMoi.Enabled = true;
            this.itXoa.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string PhatSinhMa()
        {
            string lastID = new LoaiDiemController().LayMaCuoi();
            int numOfLastID;
            //khi chua co record nao trong csdl this lastID se la "", khi co ta bat dau tu 1
            if (lastID == "")
            {
                numOfLastID = 1;
            }
            else
            {
                numOfLastID = int.Parse(lastID.Substring(2, 1));
                numOfLastID++;
            }
            return "LD" + numOfLastID.ToString();
        }

    }
}
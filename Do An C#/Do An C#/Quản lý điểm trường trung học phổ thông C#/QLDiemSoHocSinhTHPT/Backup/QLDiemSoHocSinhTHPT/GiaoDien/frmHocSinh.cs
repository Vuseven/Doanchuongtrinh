using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLDiemSoHocSinhTHPT.Controller;
using QLDiemSoHocSinhTHPT.BusinessObject;

namespace QLDiemSoHocSinhTHPT.GiaoDien
{
    public partial class frmHocSinh : Form
    {
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

        #region LopInfo
        private LopInfo m_LopInfo;

        public LopInfo LopInfo
        {
            get { return m_LopInfo; }
            set { m_LopInfo = value; }
        }

        #endregion

        #region IsThem
        private bool m_IsThem;

        public bool IsThem
        {
            get { return m_IsThem; }
            set { m_IsThem = value; }
        }

        #endregion

        public frmHocSinh()
        {
            InitializeComponent();

            this.Controller = new HocSinhController();
            this.DanTocController = new DanTocController();
            this.TonGiaoController = new TonGiaoController();
            this.NgheNghiepChaContorller = new NgheNghiepController();
            this.NgheNghiepMeController = new NgheNghiepController();
            this.LopInfo = null;
        }

        /// <summary>
        /// Form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHocSinh_Load(object sender, EventArgs e)
        {
            //Khoi tao doi tuong m_Controller
            if (this.Controller == null)
            {
                this.Controller = new HocSinhController();
            }

            //Khoi tao doi tuong m_DanTocController
            if (this.DanTocController == null)
            {
                this.DanTocController = new DanTocController();
            }

            if (this.TonGiaoController == null)
            {
                this.TonGiaoController = new TonGiaoController();
            }

            if (this.NgheNghiepChaContorller == null)
            {
                this.NgheNghiepChaContorller = new NgheNghiepController();
            }

            if (this.NgheNghiepMeController == null)
            {
                this.NgheNghiepMeController = new NgheNghiepController();
            }


            this.DanTocController.HienThiCombobox(this.cmbDanToc);
            this.DanTocController.HienThiDataGridComboBoxColumn(this.colDanToc);

            this.TonGiaoController.HienThiCombobox(this.cmbTonGiao);
            this.TonGiaoController.HienThiDataGridComboBoxColumn(this.colTonGiao);

            this.NgheNghiepChaContorller.HienThiCombobox(this.cmbNNghiepCha);
            this.NgheNghiepChaContorller.HienThiDataGridComboBoxColumn(this.colNNghiepCha, "MaNNghiepCha");

            this.NgheNghiepMeController.HienThiCombobox(this.cmbNNghiepMe);
            this.NgheNghiepMeController.HienThiDataGridComboBoxColumn(this.colNNghiepMe, "MaNNghiepMe");

            //Hien thi DS Giao vien
            this.Controller.HienThiDS(this.dgvDS, this.bnDS, this.txtMaHocSinh, this.txtHoTen, this.dpNgaySinh, this.cbxGioiTinh, this.txtNoiSinh, this.txtDiaChi, this.cmbDanToc, this.cmbTonGiao, this.txtHoTenCha, this.cmbNNghiepCha, this.txtHoTenMe, this.cmbNNghiepMe);

            //Neu trong danh sach khong co dong nao
            if (this.dgvDS.Rows.Count == 0)
            {
                this.btXoa.Enabled = false;
                this.itXoa.Enabled = false;
            }
        }

        /// <summary>
        /// Phat sinh MaGiaoVien tu dong
        /// </summary>
        /// <returns></returns>
        public string PhatSinhMa()
        {
            if (this.Controller == null)
            {
                this.Controller = new HocSinhController();
            }
            string lastID = this.Controller.LayMaCuoi();
            int numOfLastID;
            //khi chua co record nao trong csdl this lastID se la "", khi co ta bat dau tu 1
            if (lastID == "")
            {
                numOfLastID = 1;
            }
            else
            {
                numOfLastID = int.Parse(lastID.Substring(2, 6));
                numOfLastID++;
            }
            return "HS" + (numOfLastID + 1000000).ToString().Substring(1, 6);
        }

        /// <summary>
        /// Click nut Them Moi hoac context menu Them Moi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btThemMoi_Click(object sender, EventArgs e)
        {
            frmChonLopThemHS frm = new frmChonLopThemHS();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.LopInfo = frm.Info;

                DataRowView row = (DataRowView)this.bnDS.BindingSource.AddNew();
                row["MaHocSinh"] = this.PhatSinhMa();
                row["GioiTinh"] = true;
                this.bnDS.BindingSource.MoveLast();

                this.IsThem = true;

                this.btThemMoi.Enabled = false;
                this.btXoa.Enabled = false;
                this.btBoQua.Enabled = true;
                this.btLuu.Enabled = true;

                this.itThemMoi.Enabled = false;
                this.itXoa.Enabled = false;
                this.itBoQua.Enabled = true;
                this.itLuu.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btBoQua_Click(object sender, EventArgs e)
        {
            //this.Controler.DisplayList(this.dgvList, this.bn);
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
                if (MessageBox.Show("Không thể lưu!\nBạn cần nhập đầy đủ thông tin trước khi lưu lại!\nBạn có muốn tiếp tục không?", "Lưu Học sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                {
                    this.Controller.Data.LayDS();

                    this.btThemMoi.Enabled = true;
                    this.btXoa.Enabled = true;
                    this.btBoQua.Enabled = false;
                    this.btLuu.Enabled = false;

                    this.itThemMoi.Enabled = true;
                    this.itXoa.Enabled = true;
                    this.itBoQua.Enabled = false;
                    this.itLuu.Enabled = false;
                }
            }
            else
            {

                //Neu trang thai la Them, them hoc sinh vao phan lop.
                if (this.IsThem)
                {
                    //Luu Hoc sinh vao phan lop
                    PhanLopController phanLopCtrl = new PhanLopController();
                    PhanLopInfo phanLopInfo = new PhanLopInfo();
                    phanLopInfo.MaHocSinhLop = PhanLopController.PhatSinhMa(this.LopInfo.MaLop);
                    phanLopInfo.MaLop = this.LopInfo.MaLop;
                    phanLopInfo.MaHocSinh = ((DataRowView)this.bnDS.BindingSource.Current)["MaHocSinh"].ToString();
                    phanLopCtrl.ThemPhanLop(phanLopInfo);
                    this.IsThem = false;
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc xóa không?", "Xóa Giáo viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    MessageBox.Show("Đã xóa!", "Xóa Giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Neu trong danh sach khong con dong nao
                    if (this.dgvDS.Rows.Count == 0)
                    {
                        this.btXoa.Enabled = false;
                        this.itXoa.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xóa!", "Xóa Giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
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
        private void dgvDS_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc xóa không?", "Xóa Giáo viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                //Neu chon No, cancel thao tac xoa
                e.Cancel = true;
            }
            else
            {
                /*
                 * Vi thao tac xoa chi co tac dung tren DataGridView nen ta cancel di
                 * Sau co xoa theo cach cua ta
                 * */
                e.Cancel = true;
                IEnumerator ie = this.dgvDS.SelectedRows.GetEnumerator();
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
                else
                {
                    this.bnDS.BindingSource.RemoveCurrent();
                }

                if (this.Controller.Update())
                {
                    MessageBox.Show("Đã xóa!", "Xóa Giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Neu trong danh sach khong con dong nao
                    if (this.dgvDS.Rows.Count == 0)
                    {
                        this.btXoa.Enabled = false;
                        this.itXoa.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xóa!", "Xóa chủ đề", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Controller = new HocSinhController();
                    this.Controller.Data.LayDS();
                    //this.Controller.DisplayList(this.dgvList, this.bn);
                }
            }
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
        private void frmHocSinh_Shown(object sender, EventArgs e)
        {
            this.btThemMoi.Enabled = true;
            this.btXoa.Enabled = true;

            this.itThemMoi.Enabled = true;
            this.itXoa.Enabled = true;
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
        private void btThemDanToc_Click(object sender, EventArgs e)
        {
            frmDanToc frm_DanToc = new frmDanToc(this.DanTocController);
            frm_DanToc.WindowState = FormWindowState.Normal;
            frm_DanToc.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btThemTonGiao_Click(object sender, EventArgs e)
        {
            frmTonGiao frm_TonGiao = new frmTonGiao(this.TonGiaoController);
            frm_TonGiao.WindowState = FormWindowState.Normal;
            frm_TonGiao.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btThemNgheCha_Click(object sender, EventArgs e)
        {
            int meSelectednIndex = this.cmbNNghiepMe.SelectedIndex;
            frmNgheNghiep frm_NgheNghiep = new frmNgheNghiep(this.NgheNghiepChaContorller);
            frm_NgheNghiep.ControlBox = false;//Khong cho hien thi nut "X" tren thanh tieu de
            frm_NgheNghiep.WindowState = FormWindowState.Normal;
            if (frm_NgheNghiep.ShowDialog() == DialogResult.OK)
            {
                this.NgheNghiepMeController.Data.LayDS();
                this.cmbNNghiepMe.SelectedIndex = meSelectednIndex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btThemNgheMe_Click(object sender, EventArgs e)
        {
            int chaSelectednIndex = this.cmbNNghiepCha.SelectedIndex;
            frmNgheNghiep frm_NgheNghiep = new frmNgheNghiep(this.NgheNghiepMeController);
            frm_NgheNghiep.ControlBox = false;//Khong cho hien thi nut "X" tren thanh tieu de
            frm_NgheNghiep.WindowState = FormWindowState.Normal;
            if (frm_NgheNghiep.ShowDialog() == DialogResult.OK)
            {
                this.NgheNghiepChaContorller.Data.LayDS();
                this.cmbNNghiepCha.SelectedIndex = chaSelectednIndex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckValid()
        {
            //Kiem tra Ma hoc sinh co duoc nhap chua
            if (this.txtMaHocSinh.Text == "" || this.txtMaHocSinh.Text == null)
            {
                MessageBox.Show("Chưa nhập Mã học sinh!", "Ma hoc sinh invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtMaHocSinh.Focus();
                return false;
            }

            //Kiem tra ten hoc sinh co duoc nhap chua
            if (this.txtHoTen.Text == "" || this.txtHoTen.Text == null)
            {
                MessageBox.Show("Chưa nhập tên học sinh!", "Ten hoc sinh invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtHoTen.Focus();
                return false;
            }

            ////Kiem tra gioi tinh cua hoc sinh co duoc nhap chua
            //if (this.txtGioiTinh.Text == "" || this.txtGioiTinh.Text == null)
            //{
            //    MessageBox.Show("Chưa nhập giới tính của học sinh!", "Gioi tinh cua hoc sinh invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.txtHoTen.Focus();
            //    return false;
            //}

            //Kiem tra noi sinh co duoc nhap chua
            if (this.txtNoiSinh.Text == "" || this.txtNoiSinh.Text == null)
            {
                MessageBox.Show("Chưa check vào nơi sinh!", "Noi sinh invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNoiSinh.Focus();
                return false;
            }

            //Kiem tra dia chi co duoc nhap chua
            if (this.txtDiaChi.Text == "" || this.txtDiaChi.Text == null)
            {
                MessageBox.Show("Chưa nhập địa chỉ!", "Dia chi invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtDiaChi.Focus();
                return false;
            }
            //Kiem tra ho ten cha co duoc nhap chua
            if (this.txtHoTenCha.Text == "" || this.txtHoTenCha.Text == null)
            {
                MessageBox.Show("Chưa nhập họ tên Cha!", "Ho ten Cha invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtHoTenCha.Focus();
                return false;
            }
            //Kiem tra ho ten Me co duoc nhap chua
            if (this.txtHoTenMe.Text == "" || this.txtHoTenMe.Text == null)
            {
                MessageBox.Show("Chưa nhập họ tên Mẹ!", "Ho ten Me invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtHoTenMe.Focus();
                return false;
            }

            return true;
        }
    }
}
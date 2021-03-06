using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using System.Collections;
using TT_GDTX_ANGIANG.BusinessObject;
using TT_GDTX_ANGIANG.Controller;
using TT_GDTX_ANGIANG.DataLayer;

namespace TT_GDTX_ANGIANG
{
    public partial class frm_QUATRINHCONGTACNUOCNGOAI : DevComponents.DotNetBar.Office2007Form
    {
        public frm_QUATRINHCONGTACNUOCNGOAI()
        {
            InitializeComponent();
        }

        #region ctrlQuaTrinhCongTac
        private QuaTrinhCongTacNuocNgoaiCtrl m_ctrlQuaTrinhCongTacNuocNgoai;
        public QuaTrinhCongTacNuocNgoaiCtrl ctrlQuaTrinhCongTacNuocNgoai
        {
            get { return m_ctrlQuaTrinhCongTacNuocNgoai; }
            set { m_ctrlQuaTrinhCongTacNuocNgoai = value; }
        }
        #endregion

        #region SelectedIndex
        /// <summary>
        /// Vi tri dong da chon
        /// </summary>
        private int m_SelectedIndex;
        public int SelectedIndex
        {
            get { return m_SelectedIndex; }
            set { m_SelectedIndex = value; }
        }
        #endregion

        #region IsAddNew
        /// <summary>
        /// True trong khi chon Them, sau do chon Save.
        /// </summary>
        private bool m_IsAddNew;
        public bool IsAddNew
        {
            get { return m_IsAddNew; }
            set { m_IsAddNew = value; }
        }
        #endregion

        #region PhanQuyen_Xem
        public void PhanQuyen_Xem_An()
        {
            //this.itemThemMoi.Enabled = false;
            //this.itemBoQua.Enabled = false;
            //this.itemLuu.Enabled = false;
            //this.itemXoa.Enabled = false;
        }
        public void PhanQuyen_Xem_Hien()
        {
            //this.itemThemMoi.Enabled = true;
            //this.itemBoQua.Enabled = true;
            //this.itemLuu.Enabled = true;
            //this.itemXoa.Enabled = true;
        }
        #endregion

        #region Property

        private QuaTrinhCongTacNuocNgoaiInfo m_QuaTrinhCongTacNuocNgoaiSelected;
        public QuaTrinhCongTacNuocNgoaiInfo QuaTrinhCongTacNuocNgoaiSelected
        {
            get { return m_QuaTrinhCongTacNuocNgoaiSelected; }
            set { m_QuaTrinhCongTacNuocNgoaiSelected = value; }
        }

        private string m_Open;
        public string Open
        {
            get { return m_Open; }
            set { m_Open = value; }
        }

        private string m_MANV;
        public string LayMaNhanVien_QTCongTacNuocNgoai
        {
            get { return m_MANV; }
            set { m_MANV = value; }
        }
        private string m_HOTEN;
        public string LayTenNhanVien
        {
            get { return m_HOTEN; }
            set { m_HOTEN = value; }
        }


        private string m_Enable;
        public string An_Hien
        {
            get { return m_Enable; }
            set { m_Enable = value; }
        }
        #endregion

        #region CheckValid()
        private bool CheckValid()
        {
            //kiểm Tra mã
            if (this.txtMACT.Text.Trim() == "")
            {
                MessageBoxEx.Show("Chưa nhập Mã Quá Trình Công Tác, Hãy Nhấn Nút Thêm Mới. ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.itemThemMoi.Focus();
                return false;
            }
            //kiểm tra ngày
            if (this.dtNgayBD.Value.Date >= this.dtNgayKT.Value.Date)
            {
                MessageBoxEx.Show("Ngày Kết Thúc phải lớn hơn ngày Bắt Đầu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtNgayKT.Focus();
                return false;
            }
            //Kiểm Tra nước Công tác
            if (this.txtNuocCongTac.Text.Trim() == "")
            {
                MessageBoxEx.Show("Chưa nhập Nước Công Tác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNuocCongTac.Focus();
                return false;
            }
            //Kiểm tên Cơ Quan
            if (this.txtTenCoQuan.Text.Trim() == "")
            {
                MessageBoxEx.Show("Chưa nhập Tên Cơ Quan!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtTenCoQuan.Focus();
                return false;
            }
            //Kiểm Tra Mục Đích
            if (this.txtMucDich.Text.Trim() == "")
            {
                MessageBoxEx.Show("Chưa nhập Mục Đích!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtMucDich.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region ReloadData()
        private void ReloadData()
        {
            if (ctrlQuaTrinhCongTacNuocNgoai == null)
            {
                ctrlQuaTrinhCongTacNuocNgoai = new QuaTrinhCongTacNuocNgoaiCtrl();
            }
            ctrlQuaTrinhCongTacNuocNgoai.HienThi_dsQuaTrinhCongTacNuocNgoai(this.listViewExQTDaoTao, this.LayMaNhanVien_QTCongTacNuocNgoai);
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                this.SelectedIndex = 0;
                this.listViewExQTDaoTao.Items[this.SelectedIndex].Selected = true;
                ctrlQuaTrinhCongTacNuocNgoai.HienThiInfo(this.txtMACT, this.txtNuocCongTac, this.txtTenCoQuan, this.txtMucDich, this.dtNgayBD, this.dtNgayKT, (QuaTrinhCongTacNuocNgoaiInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                this.itemXoa.Enabled = true;
            }
            else
            {

                this.txtMACT.Text = null;
                this.dtNgayBD.Text = null;
                this.dtNgayKT.Text = null;
                this.txtNuocCongTac.Text = null;
                this.txtTenCoQuan.Text = null;
                this.txtMucDich.Text = null;

                this.IsAddNew = true;
                this.txtMACT.Focus();
                this.itemXoa.Enabled = false;
            }
        }
        #endregion


        #region frm_QUATRINHCONGTACNUOCNGOAI_Load        
       
        private void frm_QUATRINHCONGTACNUOCNGOAI_Load(object sender, EventArgs e)
        {
            if (An_Hien == "Xem")
            {
                this.PhanQuyen_Xem_An();
            }
            else
            {
                this.PhanQuyen_Xem_Hien();
            }

            if (ctrlQuaTrinhCongTacNuocNgoai == null)
            {
                ctrlQuaTrinhCongTacNuocNgoai = new QuaTrinhCongTacNuocNgoaiCtrl();
            }
            ctrlQuaTrinhCongTacNuocNgoai.HienThi_dsQuaTrinhCongTacNuocNgoai(this.listViewExQTDaoTao, this.LayMaNhanVien_QTCongTacNuocNgoai);
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                this.SelectedIndex = 0;
                this.listViewExQTDaoTao.Items[this.SelectedIndex].Selected = true;
                ctrlQuaTrinhCongTacNuocNgoai.HienThiInfo(this.txtMACT, this.txtNuocCongTac, this.txtTenCoQuan, this.txtMucDich, this.dtNgayBD, this.dtNgayKT, (QuaTrinhCongTacNuocNgoaiInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                this.itemXoa.Enabled = true;
            }
            else
            {

                this.txtMACT.Text = null;
                this.dtNgayBD.Text = null;
                this.dtNgayKT.Text = null;
                this.txtNuocCongTac.Text = null;
                this.txtTenCoQuan.Text = null;
                this.txtMucDich.Text = null;

                this.IsAddNew = true;
                this.txtMACT.Focus();
                this.itemXoa.Enabled = false;
            }
        }
        #endregion

        #region itemThemMoi_Click

        private void itemThemMoi_Click(object sender, EventArgs e)
        {
            if (!this.IsAddNew)
            {
                this.txtMACT.Text = null;
                this.dtNgayBD.Text = null;
                this.dtNgayKT.Text = null;
                this.txtNuocCongTac.Text = null;
                this.txtTenCoQuan.Text = null;
                this.txtMucDich.Text = null;

                this.IsAddNew = true;



            }
            ctrlQuaTrinhCongTacNuocNgoai.Create(txtMACT);
            this.dtNgayBD.Focus();
        }
        #endregion

        #region itemBoQua_Click        
        
        private void itemBoQua_Click(object sender, EventArgs e)
        {
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                ctrlQuaTrinhCongTacNuocNgoai.HienThiInfo(this.txtMACT, this.txtNuocCongTac, this.txtTenCoQuan, this.txtMucDich, this.dtNgayBD, this.dtNgayKT, (QuaTrinhCongTacNuocNgoaiInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
                if (this.IsAddNew)
                    this.IsAddNew = false;
            }
        }
        #endregion

        #region itemLuu_Click

        private void itemLuu_Click(object sender, EventArgs e)
        {
            if (this.CheckValid())
            {
                QuaTrinhCongTacNuocNgoaiInfo info = new QuaTrinhCongTacNuocNgoaiInfo();
                info.MaQuaTrinhCongTacNuocNgoai = this.txtMACT.Text;
                info.MaNhanVien = this.LayMaNhanVien_QTCongTacNuocNgoai;
                info.TuNgay = this.dtNgayBD.Value;
                info.DenNgay = this.dtNgayKT.Value;
                info.NuocCongTac = this.txtNuocCongTac.Text;
                info.TenCoQuan = this.txtTenCoQuan.Text;
                info.MucDich = this.txtMucDich.Text;
                if (IsAddNew)
                {
                    if (ctrlQuaTrinhCongTacNuocNgoai.Add(info))
                    {
                        this.IsAddNew = false;
                        MessageBoxEx.Show("Một dòng mới đã được thêm vào!", "Thêm Thành Công");
                    }
                    this.ReloadData();
                }
                else
                {
                    if (MessageBoxEx.Show("Ban có chắc là cập nhật dòng này không?", "Cập Nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ctrlQuaTrinhCongTacNuocNgoai.CapNhatQuaTrinhCongTacNuocNgoai(info, SelectedIndex);
                        this.ReloadData();
                    }
                    ctrlQuaTrinhCongTacNuocNgoai.HienThiInfo(this.txtMACT, this.txtNuocCongTac, this.txtTenCoQuan, this.txtMucDich, this.dtNgayBD, this.dtNgayKT, (QuaTrinhCongTacNuocNgoaiInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);

                }
            }
        }
        #endregion


        #region itemXoa_Click        
       
        private void itemXoa_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("Bạn có chắc là xóa dòng này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IEnumerator ie = this.listViewExQTDaoTao.SelectedItems.GetEnumerator();
                while (ie.MoveNext())
                {
                    ListViewItem item = (ListViewItem)ie.Current;
                    listViewExQTDaoTao.Items.Remove(item);
                    if (ctrlQuaTrinhCongTacNuocNgoai == null)
                        ctrlQuaTrinhCongTacNuocNgoai = new QuaTrinhCongTacNuocNgoaiCtrl();
                    ctrlQuaTrinhCongTacNuocNgoai.Xoa_QuaTrinhCongTacNuocNgoai(item.SubItems[0].Text);
                    if (this.SelectedIndex != 0)
                    {
                        this.SelectedIndex--;
                    }
                }
                this.ReloadData();
            }
        }
        #endregion

        #region listViewExDanToc_SelectedIndexChanged        
      

        private void listViewExDanToc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                IEnumerator ie = this.listViewExQTDaoTao.SelectedItems.GetEnumerator();
                if (ie.MoveNext())
                {
                    this.listViewExQTDaoTao.Items[this.SelectedIndex].ImageIndex = -1;
                    this.listViewExQTDaoTao.Items[this.SelectedIndex].BackColor = Color.White;
                    this.listViewExQTDaoTao.Items[this.SelectedIndex].ForeColor = Color.Black;

                    ListViewItem item = (ListViewItem)ie.Current;
                    item.ImageIndex = 0;
                    item.BackColor = Color.FromArgb(100, 150, 255);
                    item.ForeColor = Color.White;

                    this.SelectedIndex = this.listViewExQTDaoTao.Items.IndexOf(item);
                    ctrlQuaTrinhCongTacNuocNgoai.HienThiInfo(this.txtMACT, this.txtNuocCongTac, this.txtTenCoQuan, this.txtMucDich, this.dtNgayBD, this.dtNgayKT, (QuaTrinhCongTacNuocNgoaiInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
                }
            }
        }
        #endregion

        #region itemThoat_Click        
      
        private void itemThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
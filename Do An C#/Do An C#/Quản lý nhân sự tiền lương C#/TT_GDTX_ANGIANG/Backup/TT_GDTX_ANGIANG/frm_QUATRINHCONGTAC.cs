using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class frm_QUATRINHCONGTAC : DevComponents.DotNetBar.Office2007Form
    {
        public frm_QUATRINHCONGTAC()
        {
            InitializeComponent();
        }

        #region ctrlQuaTrinhCongTac
        private QuaTrinhCongTacCtrl m_ctrlQuaTrinhCongTac;
        public QuaTrinhCongTacCtrl ctrlQuaTrinhCongTac
        {
            get { return m_ctrlQuaTrinhCongTac; }
            set { m_ctrlQuaTrinhCongTac = value; }
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

        private QuaTrinhCongTacInfo m_QuaTrinhCongTacSelected;
        public QuaTrinhCongTacInfo QuaTrinhCongTacSelected
        {
            get { return m_QuaTrinhCongTacSelected; }
            set { m_QuaTrinhCongTacSelected = value; }
        }

        private string m_Open;
        public string Open
        {
            get { return m_Open; }
            set { m_Open = value; }
        }

        private string m_MANV;
        public string LayMaNhanVien_QTCongTac
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
            if (this.txtMACT.Text.Trim() == "" )
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
            //Kiểm Tra nơi Công tác
            if (this.txtNoiCongTac.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Chưa nhập Nơi Công Tác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNoiCongTac.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region ReloadData()
        private void ReloadData()
        {
            if (ctrlQuaTrinhCongTac == null)
            {
                ctrlQuaTrinhCongTac = new QuaTrinhCongTacCtrl();
            }
            ctrlQuaTrinhCongTac.HienThi_dsQuaTrinhCongTac(this.listViewExQTDaoTao,this.LayMaNhanVien_QTCongTac);
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                this.SelectedIndex = 0;
                this.listViewExQTDaoTao.Items[this.SelectedIndex].Selected = true;
                ctrlQuaTrinhCongTac.HienThiInfo(this.txtMACT, this.dtNgayBD, this.dtNgayKT, this.txtNoiCongTac, this.txtChucDanh, this.txtChucVuCaoNhat, (QuaTrinhCongTacInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                this.itemXoa.Enabled = true;
            }
            else
            {

                this.txtMACT.Text = null;
                this.dtNgayBD.Text = null;
                this.dtNgayKT.Text = null;
                this.txtNoiCongTac.Text = null;
                this.txtChucDanh.Text = null;
                this.txtChucVuCaoNhat.Text = null;
                
                this.IsAddNew = true;
                this.txtMACT.Focus();
                this.itemXoa.Enabled = false;
            }
        }
        #endregion

        #region frm_QUATRINHCONGTAC_Load        
       
        private void frm_QUATRINHCONGTAC_Load(object sender, EventArgs e)
        {
            if (An_Hien == "Xem")
            {
                this.PhanQuyen_Xem_An();
            }
            else
            {
                this.PhanQuyen_Xem_Hien();
            }

            if (ctrlQuaTrinhCongTac == null)
            {
                ctrlQuaTrinhCongTac = new QuaTrinhCongTacCtrl();
            }
            ctrlQuaTrinhCongTac.HienThi_dsQuaTrinhCongTac(this.listViewExQTDaoTao,LayMaNhanVien_QTCongTac);
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                this.SelectedIndex = 0;
                this.listViewExQTDaoTao.Items[this.SelectedIndex].Selected = true;
                ctrlQuaTrinhCongTac.HienThiInfo(this.txtMACT, this.dtNgayBD, this.dtNgayKT, this.txtNoiCongTac, this.txtChucDanh, this.txtChucVuCaoNhat, (QuaTrinhCongTacInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                this.itemXoa.Enabled = true;
            }
            else
            {

                this.txtMACT.Text = null;
                this.dtNgayBD.Text = null;
                this.dtNgayKT.Text = null;
                this.txtNoiCongTac.Text = null;
                this.txtChucDanh.Text = null;
                this.txtChucVuCaoNhat.Text = null;

                this.IsAddNew = true;
                this.txtMACT.Focus();
                this.itemXoa.Enabled = false;
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
                    ctrlQuaTrinhCongTac.HienThiInfo(this.txtMACT, this.dtNgayBD, this.dtNgayKT, this.txtNoiCongTac, this.txtChucDanh, this.txtChucVuCaoNhat, (QuaTrinhCongTacInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
                }
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
                this.txtNoiCongTac.Text = null;
                this.txtChucDanh.Text = null;
                this.txtChucVuCaoNhat.Text = null;

                this.IsAddNew = true;



            }
            ctrlQuaTrinhCongTac.Create(txtMACT);
            this.dtNgayBD.Focus();
        }
        #endregion

        #region itemBoQua_Click        
       
        private void itemBoQua_Click(object sender, EventArgs e)
        {
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                ctrlQuaTrinhCongTac.HienThiInfo(this.txtMACT, this.dtNgayBD, this.dtNgayKT, this.txtNoiCongTac, this.txtChucDanh, this.txtChucVuCaoNhat, (QuaTrinhCongTacInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
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
                QuaTrinhCongTacInfo info = new QuaTrinhCongTacInfo();
                info.MaQuaTrinhCongTac = this.txtMACT.Text;
                info.MaNhanVien = this.LayMaNhanVien_QTCongTac;
                info.TuNgay = this.dtNgayBD.Value;
                info.DenNgay = this.dtNgayKT.Value;
                info.NoiCongTac = this.txtNoiCongTac.Text;
                info.ChucDanh = this.txtChucDanh.Text;
                info.ChucVuCaoNhat = this.txtChucVuCaoNhat.Text;
                if (IsAddNew)
                {
                    if (ctrlQuaTrinhCongTac.Add(info))
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
                        ctrlQuaTrinhCongTac.CapNhatQTCongTac(info, SelectedIndex);
                        this.ReloadData();
                    }
                    ctrlQuaTrinhCongTac.HienThiInfo(this.txtMACT, this.dtNgayBD, this.dtNgayKT, this.txtNoiCongTac, this.txtChucDanh, this.txtChucVuCaoNhat, (QuaTrinhCongTacInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
                    
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
                    if (ctrlQuaTrinhCongTac == null)
                        ctrlQuaTrinhCongTac = new QuaTrinhCongTacCtrl();
                    ctrlQuaTrinhCongTac.Xoa_QuaTrinhCongTac(item.SubItems[0].Text);
                    if (this.SelectedIndex != 0)
                    {
                        this.SelectedIndex--;
                    }
                }
                this.ReloadData();
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
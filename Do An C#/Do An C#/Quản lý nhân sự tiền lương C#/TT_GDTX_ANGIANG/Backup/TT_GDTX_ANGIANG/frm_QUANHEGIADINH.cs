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
    public partial class frm_QUANHEGIADINH : DevComponents.DotNetBar.Office2007Form
    {
        public frm_QUANHEGIADINH()
        {
            InitializeComponent();
        }

        #region ctrlQuanHeGiaDinh
        private QuanHeGiaDinhCtrl m_ctrlQuanHeGiaDinh;
        public QuanHeGiaDinhCtrl ctrlQuanHeGiaDinh
        {
            get { return m_ctrlQuanHeGiaDinh; }
            set { m_ctrlQuanHeGiaDinh = value; }
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

        private QuanHeGiaDinhInfo m_QuanHeGiaDinhSelected;
        public QuanHeGiaDinhInfo QuanHeGiaDinhSelected
        {
            get { return m_QuanHeGiaDinhSelected; }
            set { m_QuanHeGiaDinhSelected = value; }
        }

        private string m_Open;
        public string Open
        {
            get { return m_Open; }
            set { m_Open = value; }
        }

        private string m_MANV;
        public string LayMaNhanVien_QuanHeGiaDinh
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
            if (this.txtMaQH.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Chưa nhập Mã Quan Hệ, Hãy Nhấn Nút Thêm Mới!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.itemThemMoi.Focus();
                return false;
            }
            if (this.txtMoiQH.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Chưa nhập Mối Quan Hệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtMoiQH.Focus();
                return false;
            }

            if (this.txtHoTen.Text.Trim() == "")
            {
                MessageBoxEx.Show("Chưa nhập Họ Tên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtHoTen.Focus();
                return false;
            }
            if (this.txtQueQuan.Text.Trim() == "")
            {
                MessageBoxEx.Show("Chưa nhập Quê Quán!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtQueQuan.Focus();
                return false;
            }

            if (this.txtNoiOHienNay.Text.Trim() == "")
            {
                MessageBoxEx.Show("Chưa nhập Nơi Ở Hiện Nay!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNoiOHienNay.Focus();
                return false;
            }

            if (this.txtNgheNghiep.Text.Trim() == "")
            {
                MessageBoxEx.Show("Chưa nhập Nghề Nghiệp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNgheNghiep.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region ReloadData()
        private void ReloadData()
        {
            if (ctrlQuanHeGiaDinh == null)
            {
                ctrlQuanHeGiaDinh = new QuanHeGiaDinhCtrl();
            }
            ctrlQuanHeGiaDinh.HienThi_dsQuanHeGiaDinh(this.listViewExQTDaoTao,this.LayMaNhanVien_QuanHeGiaDinh);
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                this.SelectedIndex = 0;
                this.listViewExQTDaoTao.Items[this.SelectedIndex].Selected = true;
                ctrlQuanHeGiaDinh.HienThiInfo(this.txtMaQH, this.txtMoiQH,this.txtHoTen, this.dtNamSinh, this.txtQueQuan, this.txtNoiOHienNay, this.txtNgheNghiep,this.txtDVCongTac,this.txtChucVu, (QuanHeGiaDinhInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                this.itemXoa.Enabled = true;
            }
            else
            {

                this.txtMaQH.Text = null;
                this.txtMoiQH.Text = null;
                this.txtHoTen.Text = null;
                this.dtNamSinh.Text = null;
                this.txtQueQuan.Text = null;
                this.txtNoiOHienNay.Text = null;
                this.txtNgheNghiep.Text = null;
                this.txtDVCongTac.Text = null;
                this.txtChucVu.Text = null;

                this.IsAddNew = true;
                this.txtMaQH.Focus();
                this.itemXoa.Enabled = false;
            }
        }
        #endregion


        #region frm_DM_QUANHEGIADINH_Load        
       
        private void frm_DM_QUANHEGIADINH_Load(object sender, EventArgs e)
        {
            if (An_Hien == "Xem")
            {
                this.PhanQuyen_Xem_An();
            }
            else
            {
                this.PhanQuyen_Xem_Hien();
            }

            if (ctrlQuanHeGiaDinh == null)
            {
                ctrlQuanHeGiaDinh = new QuanHeGiaDinhCtrl();
            }
            ctrlQuanHeGiaDinh.HienThi_dsQuanHeGiaDinh(this.listViewExQTDaoTao,this.LayMaNhanVien_QuanHeGiaDinh);
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                this.SelectedIndex = 0;
                this.listViewExQTDaoTao.Items[this.SelectedIndex].Selected = true;
                ctrlQuanHeGiaDinh.HienThiInfo(this.txtMaQH, this.txtMoiQH,this.txtHoTen, this.dtNamSinh, this.txtQueQuan, this.txtNoiOHienNay, this.txtNgheNghiep, this.txtDVCongTac, this.txtChucVu, (QuanHeGiaDinhInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                this.itemXoa.Enabled = true;
            }
            else
            {

                this.txtMaQH.Text = null;
                this.txtMoiQH.Text = null;
                this.txtHoTen.Text = null;
                this.dtNamSinh.Text = null;
                this.txtQueQuan.Text = null;
                this.txtNoiOHienNay.Text = null;
                this.txtNgheNghiep.Text = null;
                this.txtDVCongTac.Text = null;
                this.txtChucVu.Text = null;

                this.IsAddNew = true;
                this.txtMaQH.Focus();
                this.itemXoa.Enabled = false;
            }
        }
        #endregion

        #region itemThemMoi_Click

        private void itemThemMoi_Click(object sender, EventArgs e)
        {
            if (!this.IsAddNew)
            {
                this.txtMaQH.Text = null;
                this.txtMoiQH.Text = null;
                this.txtHoTen.Text = null;
                this.dtNamSinh.Text = null;
                this.txtQueQuan.Text = null;
                this.txtNoiOHienNay.Text = null;
                this.txtNgheNghiep.Text = null;
                this.txtDVCongTac.Text = null;
                this.txtChucVu.Text = null;

                this.IsAddNew = true;

            }
            ctrlQuanHeGiaDinh.Create(txtMaQH);
            this.txtMoiQH.Focus();
        }
        #endregion

        #region itemBoQua_Click        
       
        private void itemBoQua_Click(object sender, EventArgs e)
        {
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                ctrlQuanHeGiaDinh.HienThiInfo(this.txtMaQH, this.txtMoiQH, this.txtHoTen, this.dtNamSinh, this.txtQueQuan, this.txtNoiOHienNay, this.txtNgheNghiep, this.txtDVCongTac, this.txtChucVu, (QuanHeGiaDinhInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
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
                QuanHeGiaDinhInfo info = new QuanHeGiaDinhInfo();
                info.MaQuanHeGiaDinh = this.txtMaQH.Text;
                info.MaNhanVien = this.LayMaNhanVien_QuanHeGiaDinh;
                info.MoiQuanHe = this.txtMoiQH.Text;
                info.HoTen = this.txtHoTen.Text;
                info.QueQuan = this.txtQueQuan.Text;
                info.NamSinh = this.dtNamSinh.Value;
                info.NoiOHienNay = this.txtNoiOHienNay.Text;
                info.NgheNghiep = this.txtNgheNghiep.Text;
                info.DonViCongTac = this.txtDVCongTac.Text;
                info.ChucVu = this.txtChucVu.Text;
                if (IsAddNew)
                {
                    if (ctrlQuanHeGiaDinh.Add(info))
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
                        ctrlQuanHeGiaDinh.CapNhatQHGiaDinh(info, SelectedIndex);
                        this.ReloadData();
                    }
                    ctrlQuanHeGiaDinh.HienThiInfo(this.txtMaQH, this.txtMoiQH,this.txtHoTen, this.dtNamSinh, this.txtQueQuan, this.txtNoiOHienNay, this.txtNgheNghiep, this.txtDVCongTac, this.txtChucVu, (QuanHeGiaDinhInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
                    
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
                    if (ctrlQuanHeGiaDinh == null)
                        ctrlQuanHeGiaDinh = new QuanHeGiaDinhCtrl();
                    ctrlQuanHeGiaDinh.Xoa_QuanHeGiaDinh(item.SubItems[0].Text);
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
                    ctrlQuanHeGiaDinh.HienThiInfo(this.txtMaQH, this.txtMoiQH, this.txtHoTen, this.dtNamSinh, this.txtQueQuan, this.txtNoiOHienNay, this.txtNgheNghiep, this.txtDVCongTac, this.txtChucVu, (QuanHeGiaDinhInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
                }
            }
        }
        #endregion
    }
}
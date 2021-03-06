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
    public partial class frm_PHONGBAN : DevComponents.DotNetBar.Office2007Form
    {
        public frm_PHONGBAN()
        {
            InitializeComponent();
        }

        

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

        #region Property
        private string m_Enable;
        public string An_Hien
        {
            get { return m_Enable; }
            set { m_Enable = value; }
        }
        #endregion

        #region PhanQuyen_Xem
        public void PhanQuyen_Xem_An()
        {
            this.itemThemMoi.Enabled = false;
            this.itemBoQua.Enabled = false;
            this.itemLuu.Enabled = false;
            this.itemXoa.Enabled = false;
            this.itemInNhanh.Enabled = false;
        }
        public void PhanQuyen_Xem_Hien()
        {
            this.itemThemMoi.Enabled = true;
            this.itemBoQua.Enabled = true;
            this.itemLuu.Enabled = true;
            this.itemXoa.Enabled = true;
            this.itemInNhanh.Enabled = true;
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
        
         
        #region CheckValid()
        private bool CheckValid()
        {
            if (this.txtMAPH.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Bạn Chưa Nhập Mã Phòng. Hãy Bấm nút Thêm Mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.itemThemMoi.Focus();
                return false;
            }
            if (this.txtTENPH.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Chưa nhập Tên phòng ban!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtTENPH.Focus();
                return false;
            }
            if (int.Parse(this.txtSONHANVIEN.Text) < 0)
            {
                MessageBoxEx.Show("Số nhân viên không được phép âm!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtSONHANVIEN.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region ReloadData()
        private void ReloadData()
        {
            if (ctrlPhongBan == null)
            {
                ctrlPhongBan = new PhongBanCtrl();
            }
            ctrlPhongBan.HienThi_dsPhongBan(listViewExPhongBan);
            if (listViewExPhongBan.Items.Count > 0)
            {
                this.listViewExPhongBan.Items[this.SelectedIndex].Selected = true;
                this.ctrlPhongBan.HienThiInfo(this.txtMAPH, this.txtTENPH, this.txtSONHANVIEN, this.txtGHICHU, (PhongBanInfo)this.listViewExPhongBan.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                //this.itemXoa.Enabled = true;
            }
            else
            {
                this.txtMAPH.Text = null;
                this.txtTENPH.Text = null;
                this.txtSONHANVIEN.Text = null;
                this.txtGHICHU.Text = null;

                this.IsAddNew = true;
                this.txtMAPH.Focus();
                this.itemXoa.Enabled = false;
            }
        }
        #endregion

        #region itemThemMoi_Click       
       

        private void itemThemMoi_Click(object sender, EventArgs e)
        {
            if (!this.IsAddNew)
            {
                this.txtMAPH.Text = null;
                this.txtTENPH.Text = null;
                this.txtSONHANVIEN.Text = "0";
                this.txtGHICHU.Text = null;
                this.IsAddNew = true;
            }
            ctrlPhongBan.Create(txtMAPH);
            this.txtTENPH.Focus();
        }
        #endregion

        #region ctrlPhongBan
        private PhongBanCtrl m_ctrlPhongBan;
        public PhongBanCtrl ctrlPhongBan
        {
            get { return m_ctrlPhongBan; }
            set { m_ctrlPhongBan = value; }
        }
        #endregion

        #region frm_DM_PHONGBAN_Load        
       
        private void frm_DM_PHONGBAN_Load(object sender, EventArgs e)
        {
            if (An_Hien == "Xem")
            {
                this.PhanQuyen_Xem_An();
            }
            else
            {
                this.PhanQuyen_Xem_Hien();
            }

            if (ctrlPhongBan == null)
            {
                ctrlPhongBan = new PhongBanCtrl();
            }
            ctrlPhongBan.HienThi_dsPhongBan(this.listViewExPhongBan);
            if (this.listViewExPhongBan.Items.Count > 0)
            {
                this.SelectedIndex = 0;
                this.listViewExPhongBan.Items[this.SelectedIndex].Selected = true;
                ctrlPhongBan.HienThiInfo(this.txtMAPH, this.txtTENPH, this.txtSONHANVIEN, this.txtGHICHU, (PhongBanInfo)this.listViewExPhongBan.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                //this.itemXoa.Enabled = true;
            }
            else
            {
                this.txtMAPH.Text = null;
                this.txtTENPH.Text = null;
                this.txtSONHANVIEN.Text = "0";
                this.txtGHICHU.Text = null;

                this.IsAddNew = true;
                this.txtMAPH.Focus();
                this.itemXoa.Enabled = false;
            }
        }
        #endregion

        #region itemLuu_Click       
        
        private void itemLuu_Click(object sender, EventArgs e)
        {
            if (this.CheckValid())
            {
                PhongBanInfo info = new PhongBanInfo(this.txtMAPH.Text, this.txtTENPH.Text, int.Parse(this.txtSONHANVIEN.Text), this.txtGHICHU.Text);
                if (IsAddNew)
                {
                    if (ctrlPhongBan.Add(info))
                    {
                        this.IsAddNew = false;
                        MessageBoxEx.Show("Một dòng mới đã được thêm vào!", "Thêm Thành Công");
                    }
                    this.ReloadData();
                }
                else
                {
                    if (MessageBoxEx.Show("Bạn có chắc là cập nhật dòng này không?", "Cập Nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ctrlPhongBan.Update(info, SelectedIndex);
                        this.ReloadData();
                    }
                    ctrlPhongBan.HienThiInfo(this.txtMAPH, this.txtTENPH, this.txtSONHANVIEN, this.txtGHICHU, (PhongBanInfo)this.listViewExPhongBan.Items[this.SelectedIndex].Tag);
                   
                }
            }
        }
        #endregion


        #region listViewExDanToc_SelectedIndexChanged        
       
        private void listViewExDanToc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewExPhongBan.Items.Count > 0)
            {
                IEnumerator ie = this.listViewExPhongBan.SelectedItems.GetEnumerator();
                if (ie.MoveNext())
                {
                    this.listViewExPhongBan.Items[this.SelectedIndex].ImageIndex = -1;
                    this.listViewExPhongBan.Items[this.SelectedIndex].BackColor = Color.White;
                    this.listViewExPhongBan.Items[this.SelectedIndex].ForeColor = Color.Black;

                    ListViewItem item = (ListViewItem)ie.Current;
                    item.ImageIndex = 0;
                    item.BackColor = Color.FromArgb(100, 160, 255);
                    item.ForeColor = Color.White;

                    this.SelectedIndex = this.listViewExPhongBan.Items.IndexOf(item);
                    ctrlPhongBan.HienThiInfo(this.txtMAPH, this.txtTENPH, this.txtSONHANVIEN, this.txtGHICHU, (PhongBanInfo)item.Tag);
                }
            }
        }
        #endregion

        #region itemBoQua_Click        
       
        private void itemBoQua_Click(object sender, EventArgs e)
        {
            if (this.listViewExPhongBan.Items.Count > 0)
            {
                ctrlPhongBan.HienThiInfo(this.txtMAPH, this.txtTENPH, this.txtSONHANVIEN, this.txtGHICHU, (PhongBanInfo)this.listViewExPhongBan.Items[this.SelectedIndex].Tag);
                if (this.IsAddNew)
                    this.IsAddNew = false;
            }
        }
        #endregion

        #region itemXoa_Click        
        
        private void itemXoa_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("Bạn có chắc là xóa dòng này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IEnumerator ie = this.listViewExPhongBan.SelectedItems.GetEnumerator();
                while (ie.MoveNext())
                {
                    ListViewItem item = (ListViewItem)ie.Current;
                    listViewExPhongBan.Items.Remove(item);
                    if (ctrlPhongBan == null)
                        ctrlPhongBan = new PhongBanCtrl();
                    ctrlPhongBan.XoaPhongBan(item.SubItems[0].Text);
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
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
    public partial class frm_VITRITUYENDUNG : DevComponents.DotNetBar.Office2007Form
    {
        public frm_VITRITUYENDUNG()
        {
            InitializeComponent();
        }
        public int Index = 0;

        #region ctrlVTTD
        private ViTri_TuyenDungCtrl m_ctrlVTTD;
        public ViTri_TuyenDungCtrl ctrlVTTD
        {
            get { return m_ctrlVTTD; }
            set { m_ctrlVTTD = value; }
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
            this.itemThemMoi.Enabled = false;
            this.itemBoQua.Enabled = false;
            this.itemLuu.Enabled = false;
            this.itemXoa.Enabled = false;
        }
        public void PhanQuyen_Xem_Hien()
        {
            this.itemThemMoi.Enabled = true;
            this.itemBoQua.Enabled = true;
            this.itemLuu.Enabled = true;
            this.itemXoa.Enabled = true;
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

        #region CheckValid()
        private bool CheckValid()
        {
            if (this.txtMAVTTD.Text.Trim() == "")
            {
                MessageBoxEx.Show("Chưa Nhấn Nút Thêm Mới!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.itemThemMoi.Focus();
                return false;
            }
            if (this.txtTENVTTD.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Chưa nhập Tên vị trí tuyển dụng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtTENVTTD.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region ReloadData()
        private void ReloadData()
        {
            if (ctrlVTTD == null)
            {
                ctrlVTTD = new ViTri_TuyenDungCtrl();
            }
            ctrlVTTD.HienThi_dsVTTuyenDung(listViewExQTDaoTao);
            if (listViewExQTDaoTao.Items.Count > 0)
            {
                this.listViewExQTDaoTao.Items[this.SelectedIndex].Selected = true;
                this.ctrlVTTD.HienThiInfo(this.txtMAVTTD, this.txtTENVTTD, this.txtTENTAT, this.txtGHICHU, (ViTri_TuyenDungInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                //this.itemXoa.Enabled = true;
            }
            else
            {
                this.txtMAVTTD.Text = null;
                this.txtTENVTTD.Text = null;
                this.txtTENTAT.Text = null;
                this.txtGHICHU.Text = null;

                this.IsAddNew = true;
                this.txtMAVTTD.Focus();
                this.itemXoa.Enabled = false;
            }
        }
        #endregion

        #region frm_DM_VITRITUYENDUNG_Load        
      
        private void frm_DM_VITRITUYENDUNG_Load(object sender, EventArgs e)
        {
            if (An_Hien == "Xem")
            {
                this.PhanQuyen_Xem_An();
            }
            else
            {
                this.PhanQuyen_Xem_Hien();
            }

            if (ctrlVTTD == null)
            {
                ctrlVTTD = new ViTri_TuyenDungCtrl();
            }
            ctrlVTTD.HienThi_dsVTTuyenDung(this.listViewExQTDaoTao);
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                this.SelectedIndex = 0;
                this.listViewExQTDaoTao.Items[this.SelectedIndex].Selected = true;
                ctrlVTTD.HienThiInfo(this.txtMAVTTD, this.txtTENVTTD, this.txtTENTAT, this.txtGHICHU, (ViTri_TuyenDungInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
               // this.itemXoa.Enabled = true;
            }
            else
            {
                this.txtMAVTTD.Text = null;
                this.txtTENVTTD.Text = null;
                this.txtTENTAT.Text = null;
                this.txtGHICHU.Text = null;

           
                this.IsAddNew = true;
                this.txtMAVTTD.Focus();
                this.itemXoa.Enabled = false;
                
            }
        }
        #endregion

        #region itemThemMoi_Click        
       
        private void itemThemMoi_Click(object sender, EventArgs e)
        {
            if (!this.IsAddNew)
            {
                this.txtMAVTTD.Text = null;
                this.txtTENVTTD.Text = null;
                this.txtTENTAT.Text = null;
                this.txtGHICHU.Text = null;
                this.IsAddNew = true;
            }
            ctrlVTTD.Create(txtMAVTTD);
            this.txtTENVTTD.Focus();
        }
        #endregion

        #region itemBoQua_Click        
       
        private void itemBoQua_Click(object sender, EventArgs e)
        {
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                ctrlVTTD.HienThiInfo(this.txtMAVTTD, this.txtTENVTTD, this.txtTENTAT, this.txtGHICHU, (ViTri_TuyenDungInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
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
                ViTri_TuyenDungInfo info = new ViTri_TuyenDungInfo(this.txtMAVTTD.Text, this.txtTENVTTD.Text, this.txtTENTAT.Text, this.txtGHICHU.Text);
                if (IsAddNew)
                {
                    if (ctrlVTTD.Add(info))
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
                        ctrlVTTD.Update(info, SelectedIndex);
                        this.ReloadData();
                    }
                    ctrlVTTD.HienThiInfo(this.txtMAVTTD, this.txtTENVTTD, this.txtTENTAT, this.txtGHICHU, (ViTri_TuyenDungInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
                   
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
                    if (ctrlVTTD == null)
                        ctrlVTTD = new ViTri_TuyenDungCtrl();
                    ctrlVTTD.XoaViTriTuyenDung(item.SubItems[0].Text);
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
                    ctrlVTTD.HienThiInfo(this.txtMAVTTD, this.txtTENVTTD, this.txtTENTAT, this.txtGHICHU, (ViTri_TuyenDungInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
                }
            }
        }
        #endregion

        private void labelX4_Click(object sender, EventArgs e)
        {

        }
    }
}
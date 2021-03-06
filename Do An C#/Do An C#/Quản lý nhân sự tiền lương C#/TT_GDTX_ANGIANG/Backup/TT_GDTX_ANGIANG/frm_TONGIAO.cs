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

namespace TT_GDTX_ANGIANG
{
    public partial class frm_TONGIAO : DevComponents.DotNetBar.Office2007Form
    {
        public frm_TONGIAO()
        {
            InitializeComponent();
        }

        public int Index = 0;

        #region ctrl_TonGiao
        private TonGiaoCtrl m_ctrlTonGiao;
        public TonGiaoCtrl ctrl_TonGiao
        {
            get { return m_ctrlTonGiao; }
            set { m_ctrlTonGiao = value; }
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

        #region frm_DM_TONGIAO_Load        
        
        private void frm_DM_TONGIAO_Load(object sender, EventArgs e)
        {
            if (An_Hien == "Xem")
            {
                this.PhanQuyen_Xem_An();
            }
            else
            {
                this.PhanQuyen_Xem_Hien();
            }

            if (ctrl_TonGiao == null)
            {
                ctrl_TonGiao = new TonGiaoCtrl();
            }
            ctrl_TonGiao.HienThi_dsTonGiao(this.listViewExTonGiao);
            if (this.listViewExTonGiao.Items.Count > 0)
            {
                this.SelectedIndex = 0;
                this.listViewExTonGiao.Items[this.SelectedIndex].Selected = true;
                ctrl_TonGiao.HienThiInfo(this.txtMATG, this.txtTENTG, this.txtGHICHU, (TonGiaoInfo)this.listViewExTonGiao.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                //this.itemXoa.Enabled = true;
            }
            else
            {
                this.txtMATG.Text = null;
                this.txtTENTG.Text = null;
                this.txtGHICHU.Text = null;

                this.IsAddNew = true;
                this.txtMATG.Focus();
                this.itemXoa.Enabled = false;
            }
        }
        #endregion

        #region itemThemMoi_Click        
       
        private void itemThemMoi_Click(object sender, EventArgs e)
        {
            if (!this.IsAddNew)
            {
                this.txtMATG.Text = null;
                this.txtTENTG.Text = null;
                this.txtGHICHU.Text = null;
                this.IsAddNew = true;

            }
            ctrl_TonGiao.Create(txtMATG);
            this.txtTENTG.Focus();
        }
        #endregion

        #region itemBoQua_Click        
       
        private void itemBoQua_Click(object sender, EventArgs e)
        {
            if (this.listViewExTonGiao.Items.Count > 0)
            {
                ctrl_TonGiao.HienThiInfo(this.txtMATG, this.txtTENTG, this.txtGHICHU, (TonGiaoInfo)this.listViewExTonGiao.Items[this.SelectedIndex].Tag);
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
                TonGiaoInfo info = new TonGiaoInfo(this.txtMATG.Text, this.txtTENTG.Text, this.txtGHICHU.Text);
                if (IsAddNew)
                {
                    if (ctrl_TonGiao.Add(info))
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
                        ctrl_TonGiao.Update(info, SelectedIndex);
                        this.ReloadData();
                    }
                    ctrl_TonGiao.HienThiInfo(this.txtMATG, this.txtTENTG, this.txtGHICHU, (TonGiaoInfo)this.listViewExTonGiao.Items[this.SelectedIndex].Tag);
                }
            }
        }
        #endregion

        #region itemXoa_Click        
       
        private void itemXoa_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("Bạn có chắc là xóa dòng này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IEnumerator ie = this.listViewExTonGiao.SelectedItems.GetEnumerator();
                while (ie.MoveNext())
                {
                    ListViewItem item = (ListViewItem)ie.Current;
                    listViewExTonGiao.Items.Remove(item);
                    if (ctrl_TonGiao == null)
                        ctrl_TonGiao = new TonGiaoCtrl();
                    ctrl_TonGiao.XoaTonGiao(item.SubItems[0].Text);
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

        #region CheckValid()
        private bool CheckValid()
        {
            if (this.txtMATG.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Chưa Nhấn Nút Thêm Mới!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.itemThemMoi.Focus();
                return false;
            }
            if (this.txtTENTG.Text == "" || this.txtTENTG.Text == null)
            {
                MessageBoxEx.Show("Chưa nhập Tên tôn giáo!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtTENTG.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region ReloadData()
        private void ReloadData()
        {
            if (ctrl_TonGiao == null)
            {
                ctrl_TonGiao = new TonGiaoCtrl();
            }
            ctrl_TonGiao.HienThi_dsTonGiao(listViewExTonGiao);
            if (listViewExTonGiao.Items.Count > 0)
            {
                this.listViewExTonGiao.Items[this.SelectedIndex].Selected = true;
                this.ctrl_TonGiao.HienThiInfo(this.txtMATG, this.txtTENTG, this.txtGHICHU, (TonGiaoInfo)this.listViewExTonGiao.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                //this.itemXoa.Enabled = true;
            }
            else
            {
                this.txtMATG.Text = null;
                this.txtTENTG.Text = null;
                this.txtGHICHU.Text = null;

                this.IsAddNew = true;
                this.txtMATG.Focus();
                this.itemXoa.Enabled = false;
            }
        }
        #endregion

        #region listViewExDanToc_SelectedIndexChanged        
       
        private void listViewExDanToc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewExTonGiao.Items.Count > 0)
            {
                IEnumerator ie = this.listViewExTonGiao.SelectedItems.GetEnumerator();
                if (ie.MoveNext())
                {
                    this.listViewExTonGiao.Items[this.SelectedIndex].ImageIndex = -1;
                    this.listViewExTonGiao.Items[this.SelectedIndex].BackColor = Color.White;
                    this.listViewExTonGiao.Items[this.SelectedIndex].ForeColor = Color.Black;

                    ListViewItem item = (ListViewItem)ie.Current;
                    item.ImageIndex = 0;
                    item.BackColor = Color.FromArgb(100, 150, 255);
                    item.ForeColor = Color.White;

                    this.SelectedIndex = this.listViewExTonGiao.Items.IndexOf(item);
                    ctrl_TonGiao.HienThiInfo(this.txtMATG, this.txtTENTG, this.txtGHICHU, (TonGiaoInfo)item.Tag);
                }
            }
        }
        #endregion
    }
}
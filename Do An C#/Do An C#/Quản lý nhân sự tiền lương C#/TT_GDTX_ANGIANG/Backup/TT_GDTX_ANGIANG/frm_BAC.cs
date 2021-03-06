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
    public partial class frm_BAC : DevComponents.DotNetBar.Office2007Form
    {
        public frm_BAC()
        {
            InitializeComponent();
        }

        #region ctrlBac
        private BacCtrl m_ctrlBac;
        public BacCtrl ctrlBac
        {
            get { return m_ctrlBac; }
            set { m_ctrlBac = value; }
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
        }
        public void PhanQuyen_Xem_Hien()
        {
            this.itemThemMoi.Enabled = true;
            this.itemBoQua.Enabled = true;
            this.itemLuu.Enabled = true;
            this.itemXoa.Enabled = true;
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
            if (this.txtMaBac.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Chưa Nhấn Nút Thêm Mới!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.itemThemMoi.Focus();
                return false;
            }
            
            if (this.txtTenBac.Text.Trim() != "")
            {
                if (int.Parse(this.txtTenBac.Text) < 1 || int.Parse(this.txtTenBac.Text) > 12)
                {
                    MessageBoxEx.Show("Tên Bậc Không Được < 1 và >12!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtTenBac.Text = "";
                    this.txtTenBac.Focus();
                    return false;
                }
            }
            else
            {
                MessageBoxEx.Show("Chưa nhập Bậc Lương ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtTenBac.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region ReloadData()
        private void ReloadData()
        {
            if (ctrlBac == null)
            {
                ctrlBac = new BacCtrl();
            }
            ctrlBac.HienThi_dsBac(listViewExDanToc);
            if (listViewExDanToc.Items.Count > 0)
            {
                this.listViewExDanToc.Items[this.SelectedIndex].Selected = true;
                this.ctrlBac.HienThiInfo(this.txtMaBac, this.txtTenBac, (BacInfo)this.listViewExDanToc.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                this.itemXoa.Enabled = true;
            }
            else
            {
                this.txtMaBac.Text = null;
                this.txtTenBac.Text = null;
               

                this.IsAddNew = true;
                this.txtMaBac.Focus();
                this.itemXoa.Enabled = false;
            }

        }
        #endregion

       

        private void frm_LUONGCOBAN_Load(object sender, EventArgs e)
        {
            if (An_Hien == "Xem")
            {
                this.PhanQuyen_Xem_An();
            }
            else
            {
                this.PhanQuyen_Xem_Hien();
            }

            if (ctrlBac == null)
            {
                ctrlBac = new BacCtrl();
            }
            ctrlBac.HienThi_dsBac(listViewExDanToc);
            if (listViewExDanToc.Items.Count > 0)
            {
                this.listViewExDanToc.Items[this.SelectedIndex].Selected = true;
                this.ctrlBac.HienThiInfo(this.txtMaBac, this.txtTenBac, (BacInfo)this.listViewExDanToc.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                this.itemXoa.Enabled = true;
            }
            else
            {
                this.txtMaBac.Text = null;
                this.txtTenBac.Text = null;

                this.IsAddNew = true;
                this.txtMaBac.Focus();
                this.itemXoa.Enabled = false;
            }
        }

        private void itemThemMoi_Click(object sender, EventArgs e)
        {
            if (!this.IsAddNew)
            {
                this.txtMaBac.Text = null;
                this.txtTenBac.Text = null;


                this.IsAddNew = true;
            }
            ctrlBac.Create(txtMaBac);
            this.txtTenBac.Focus();
        }

        private void itemBoQua_Click(object sender, EventArgs e)
        {
            if (this.listViewExDanToc.Items.Count > 0)
            {
                this.ctrlBac.HienThiInfo(this.txtMaBac, this.txtTenBac, (BacInfo)this.listViewExDanToc.Items[this.SelectedIndex].Tag);
                if (this.IsAddNew)
                    this.IsAddNew = false;
            }
        }

        private void itemLuu_Click(object sender, EventArgs e)
        {

            if (this.CheckValid())
            {
                BacInfo info = new BacInfo(this.txtMaBac.Text, this.txtTenBac.Text);
                if (IsAddNew)
                {
                    if (ctrlBac.Add(info))
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
                        ctrlBac.Update(info, SelectedIndex);
                        this.ReloadData();
                    }
                    this.ctrlBac.HienThiInfo(this.txtMaBac, this.txtTenBac, (BacInfo)this.listViewExDanToc.Items[this.SelectedIndex].Tag);
                   
                }
            }
        }

        private void itemXoa_Click(object sender, EventArgs e)
        {

            if (MessageBoxEx.Show("Bạn có chắc là xóa dòng này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ctrlBac.Delete(this.SelectedIndex))
                {
                    if (this.SelectedIndex != 0)
                    {
                        this.SelectedIndex--;
                    }

                }
                this.ReloadData();
            }
        }

        private void itemThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listViewExDanToc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewExDanToc.Items.Count > 0)
            {
                IEnumerator ie = this.listViewExDanToc.SelectedItems.GetEnumerator();
                if (ie.MoveNext())
                {
                    this.listViewExDanToc.Items[this.SelectedIndex].ImageIndex = -1;
                    this.listViewExDanToc.Items[this.SelectedIndex].BackColor = Color.White;
                    this.listViewExDanToc.Items[this.SelectedIndex].ForeColor = Color.Black;

                    ListViewItem item = (ListViewItem)ie.Current;
                    item.ImageIndex = 0;
                    item.BackColor = Color.FromArgb(100, 150, 255);
                    item.ForeColor = Color.White;

                    this.SelectedIndex = this.listViewExDanToc.Items.IndexOf(item);
                    ctrlBac.HienThiInfo(this.txtMaBac, this.txtTenBac, (BacInfo)this.listViewExDanToc.Items[this.SelectedIndex].Tag);
                }
            }
        }

        
    }
}
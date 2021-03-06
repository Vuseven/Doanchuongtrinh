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
    public partial class frm_TRINHDO_NGOAINGU : DevComponents.DotNetBar.Office2007Form
    {
        public frm_TRINHDO_NGOAINGU()
        {
            InitializeComponent();
        }
        public int Index = 0;

        #region ctrlChucVu
        private TrinhDo_NgoaiNguCtrl m_ctrlTrinhDoNgoaiNgu;
        public TrinhDo_NgoaiNguCtrl ctrlTrinhDoNgoaiNgu
        {
            get { return m_ctrlTrinhDoNgoaiNgu; }
            set { m_ctrlTrinhDoNgoaiNgu = value; }
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
            if (this.txtMaTDNN.Text.Trim() == "")
            {
                MessageBoxEx.Show("Chưa Nhấn Nút Thêm Mới!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.itemThemMoi.Focus();
                return false;
            }

            if (this.txtTenTDNN.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Chưa nhập Tên Trình Độ Ngoại Ngữ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtTenTDNN.Focus();
                return false;
            }
            
            return true;
        }
        #endregion

        #region ReloadData()
        private void ReloadData()
        {
            if (ctrlTrinhDoNgoaiNgu == null)
            {
                ctrlTrinhDoNgoaiNgu = new TrinhDo_NgoaiNguCtrl();
            }
            ctrlTrinhDoNgoaiNgu.HienThi_dsTrinhDoNgoaiNgu(listViewExDanToc);
            if (listViewExDanToc.Items.Count > 0)
            {
                this.listViewExDanToc.Items[this.SelectedIndex].Selected = true;
                this.ctrlTrinhDoNgoaiNgu.HienThiInfo(this.txtMaTDNN, this.txtTenTDNN, (TrinhDo_NgoaiNguInfo)this.listViewExDanToc.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                //this.itemXoa.Enabled = true;
            }
            else
            {
                this.txtMaTDNN.Text = null;
                this.txtTenTDNN.Text = null;
               

                this.IsAddNew = true;
                this.txtMaTDNN.Focus();
                this.itemXoa.Enabled = false;
            }

        }
        #endregion

        #region frm_TRINHDO_NGOAINGU_Load        
       
        private void frm_TRINHDO_NGOAINGU_Load(object sender, EventArgs e)
        {
            if (An_Hien == "Xem")
            {
                this.PhanQuyen_Xem_An();
            }
            else
            {
                this.PhanQuyen_Xem_Hien();
            }

            if (ctrlTrinhDoNgoaiNgu == null)
            {
                ctrlTrinhDoNgoaiNgu = new TrinhDo_NgoaiNguCtrl();
            }
            ctrlTrinhDoNgoaiNgu.HienThi_dsTrinhDoNgoaiNgu(listViewExDanToc);
            if (listViewExDanToc.Items.Count > 0)
            {
                this.listViewExDanToc.Items[this.SelectedIndex].Selected = true;
                this.ctrlTrinhDoNgoaiNgu.HienThiInfo(this.txtMaTDNN, this.txtTenTDNN,  (TrinhDo_NgoaiNguInfo)this.listViewExDanToc.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                //this.itemXoa.Enabled = true;
            }
            else
            {
                this.txtMaTDNN.Text = null;
                this.txtTenTDNN.Text = null;
                

                this.IsAddNew = true;
                this.txtMaTDNN.Focus();
                this.itemXoa.Enabled = false;
            }
        }
        #endregion

        #region itemThemMoi_Click        
        
        private void itemThemMoi_Click(object sender, EventArgs e)
        {
            if (!this.IsAddNew)
            {
                this.txtMaTDNN.Text = null;
                this.txtTenTDNN.Text = null;
                

                this.IsAddNew = true;
            }
            ctrlTrinhDoNgoaiNgu.Create(txtMaTDNN);
            this.txtTenTDNN.Focus();
        }
        #endregion

        #region itemBoQua_Click        
       
        private void itemBoQua_Click(object sender, EventArgs e)
        {
            if (this.listViewExDanToc.Items.Count > 0)
            {
                this.ctrlTrinhDoNgoaiNgu.HienThiInfo(this.txtMaTDNN, this.txtTenTDNN, (TrinhDo_NgoaiNguInfo)this.listViewExDanToc.Items[this.SelectedIndex].Tag);
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
                TrinhDo_NgoaiNguInfo info = new TrinhDo_NgoaiNguInfo(this.txtMaTDNN.Text, this.txtTenTDNN.Text);
                if (IsAddNew)
                {
                    if (ctrlTrinhDoNgoaiNgu.Add(info))
                    {
                        this.IsAddNew = false;
                        MessageBoxEx.Show("Một dòng mới đã được thêm vào!", "TThêm Thành Công");
                    }
                    this.ReloadData();
                }
                else
                {
                    if (MessageBoxEx.Show("Ban có chắc là cập nhật dòng này không?", "Cập Nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ctrlTrinhDoNgoaiNgu.Update(info, SelectedIndex);
                        this.ReloadData();
                    }
                    ctrlTrinhDoNgoaiNgu.HienThiInfo(this.txtMaTDNN, this.txtTenTDNN, (TrinhDo_NgoaiNguInfo)this.listViewExDanToc.Items[this.SelectedIndex].Tag);
                    
                }
            }
        }
        #endregion

        #region itemXoa_Click        
        
        private void itemXoa_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("Bạn có chắc là xóa dòng này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IEnumerator ie = this.listViewExDanToc.SelectedItems.GetEnumerator();
                while (ie.MoveNext())
                {
                    ListViewItem item = (ListViewItem)ie.Current;
                    listViewExDanToc.Items.Remove(item);
                    if (ctrlTrinhDoNgoaiNgu == null)
                        ctrlTrinhDoNgoaiNgu = new TrinhDo_NgoaiNguCtrl();
                    ctrlTrinhDoNgoaiNgu.XoaTrinhDoNgoaiNgu(item.SubItems[0].Text);
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
                    ctrlTrinhDoNgoaiNgu.HienThiInfo(this.txtMaTDNN, this.txtTenTDNN, (TrinhDo_NgoaiNguInfo)this.listViewExDanToc.Items[this.SelectedIndex].Tag);
                }
            }
        }
        #endregion
    }
}
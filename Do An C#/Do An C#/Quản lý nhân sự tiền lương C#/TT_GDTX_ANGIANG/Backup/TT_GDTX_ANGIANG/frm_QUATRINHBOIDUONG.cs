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
    public partial class frm_QUATRINHBOIDUONG : DevComponents.DotNetBar.Office2007Form
    {
        public frm_QUATRINHBOIDUONG()
        {
            InitializeComponent();
        }

        #region ctrlQuaTrinhBoiDuong
        private QuaTrinhBoiDuongCtrl m_ctrlQuaTrinhBoiDuong;
        public QuaTrinhBoiDuongCtrl ctrlQuaTrinhBoiDuong
        {
            get { return m_ctrlQuaTrinhBoiDuong; }
            set { m_ctrlQuaTrinhBoiDuong = value; }
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

        private QuaTrinhBoiDuongInfo m_QuaTrinhBoiDuongSelected;
        public QuaTrinhBoiDuongInfo QuaTrinhBoiDuongSelected
        {
            get { return m_QuaTrinhBoiDuongSelected; }
            set { m_QuaTrinhBoiDuongSelected = value; }
        }

        private string m_Open;
        public string Open
        {
            get { return m_Open; }
            set { m_Open = value; }
        }

        private string m_MANV;
        public string LayMaNhanVien_BoiDuong
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

        #region frm_QUATRINHBOIDUONG_Load        
        
        private void frm_QUATRINHBOIDUONG_Load(object sender, EventArgs e)
        {
            if (An_Hien == "Xem")
            {
                this.PhanQuyen_Xem_An();
            }
            else
            {
                this.PhanQuyen_Xem_Hien();
            }

           // this.lbl_NhanVien.Text = "Nhân Viên" + ": " + this.LayTenNhanVien;
             

            if (ctrlQuaTrinhBoiDuong == null)
            {
                ctrlQuaTrinhBoiDuong = new QuaTrinhBoiDuongCtrl();
            }
            
           
                ctrlQuaTrinhBoiDuong.HienThi_dsQuaTrinhBoiDuong(this.listViewExQTDaoTao, this.LayMaNhanVien_BoiDuong);
                if (this.listViewExQTDaoTao.Items.Count > 0)
                {
                    
                    {
                        this.SelectedIndex = 0;
                        this.listViewExQTDaoTao.Items[this.SelectedIndex].Selected = true;
                        ctrlQuaTrinhBoiDuong.HienThiInfo(this.txtmaQTBD, this.dtNgayBD, this.dtNgayKT, this.txtNoiBoDuong, this.txtNoiDungBoiDuong, (QuaTrinhBoiDuongInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);

                        this.IsAddNew = false;
                        this.itemXoa.Enabled = true;
                    }
                }
                else
                {

                    this.txtmaQTBD.Text = null;
                    this.dtNgayBD.Value = DateTime.Now;
                    this.dtNgayKT.Value = DateTime.Now;
                    this.txtNoiBoDuong.Text = null;
                    this.txtNoiDungBoiDuong.Text = null;


                    this.IsAddNew = true;
                    this.txtmaQTBD.Focus();
                    this.itemXoa.Enabled = false;
                }

            }
        #endregion

        #region CheckValid()
            private bool CheckValid()
        {
            // Kiểm Tra Mã Hồ Sơ
            if (this.txtmaQTBD.Text.Trim() == "")
            {
                MessageBoxEx.Show("Bạn Chưa Nhập Mã Quá Trình Bồi Dưỡng. Hãy Bấm nút Thêm Mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.itemThemMoi.Focus();
                return false;
            }
            //Kiểm Tra Ngày
                
           
            if (this.dtNgayBD.Value.Year == this.dtNgayKT.Value.Year)
            {
                if ((this.dtNgayKT.Value.Month - this.dtNgayBD.Value.Month) < 1)
                {
                    MessageBoxEx.Show("Ngày Kết Thúc phải lớn hơn ngày Bắt Đầu ít nhất 1 tháng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.dtNgayKT.Focus();
                    return false;
                    
                }
                //else if (((this.dtNgayKT.Value.Month - this.dtNgayBD.Value.Month) == 1) && (this.dtNgayBD.Value.Year == this.dtNgayKT.Value.Year)&&(this.dtNgayKT.Value.Date <= this.dtNgayBD.Value.Date))
                //{
                //    MessageBoxEx.Show("Ngày Kết Thúc phải lớn hơn ngày Bắt Đầu ít nhất 1 tháng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    this.dtNgayKT.Focus();
                //    return false;
                //}
            }
            
            
            //Kiểm Tra nơi bồi dưỡng
            if (this.txtNoiBoDuong.Text.Trim() == "" )
            {
                MessageBox.Show("Chưa nhập Nơi Bồi Dưỡng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNoiBoDuong.Focus();
                return false;
            }
            //Kiểm tra nội dung bồi dưỡng
            if (this.txtNoiDungBoiDuong.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập Nội Dung Bồi Dưỡng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNoiDungBoiDuong.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region ReloadData()
        private void ReloadData()
        {
            if (ctrlQuaTrinhBoiDuong == null)
            {
                ctrlQuaTrinhBoiDuong = new QuaTrinhBoiDuongCtrl();
            }
            ctrlQuaTrinhBoiDuong.HienThi_dsQuaTrinhBoiDuong(this.listViewExQTDaoTao,this.LayMaNhanVien_BoiDuong);
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                this.SelectedIndex = 0;
                this.listViewExQTDaoTao.Items[this.SelectedIndex].Selected = true;
                ctrlQuaTrinhBoiDuong.HienThiInfo(this.txtmaQTBD, this.dtNgayBD, this.dtNgayKT, this.txtNoiBoDuong, this.txtNoiDungBoiDuong, (QuaTrinhBoiDuongInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                this.itemXoa.Enabled = true;
            }
            else
            {

                this.txtmaQTBD.Text = null;
                this.dtNgayBD.Value = DateTime.Now;
                this.dtNgayKT.Value = DateTime.Now;
                this.txtNoiBoDuong.Text = null;
                this.txtNoiDungBoiDuong.Text = null;


                this.IsAddNew = true;
                this.txtmaQTBD.Focus();
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
                    ctrlQuaTrinhBoiDuong.HienThiInfo(this.txtmaQTBD, this.dtNgayBD, this.dtNgayKT, this.txtNoiBoDuong, this.txtNoiDungBoiDuong, (QuaTrinhBoiDuongInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
                }
            }
        }
        #endregion

        #region itemThemMoi_Click

        private void itemThemMoi_Click(object sender, EventArgs e)
        {
            if (!this.IsAddNew)
            {
                this.txtmaQTBD.Text = null;
                this.dtNgayBD.Value = DateTime.Now;
                this.dtNgayKT.Value = DateTime.Now;
                this.txtNoiBoDuong.Text = null;
                this.txtNoiDungBoiDuong.Text = null;
                this.IsAddNew = true;
            }
            ctrlQuaTrinhBoiDuong.Create(txtmaQTBD);
            this.dtNgayBD.Focus();
        }
        #endregion

        #region itemBoQua_Click        
       
        private void itemBoQua_Click(object sender, EventArgs e)
        {
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                ctrlQuaTrinhBoiDuong.HienThiInfo(this.txtmaQTBD, this.dtNgayBD, this.dtNgayKT, this.txtNoiBoDuong, this.txtNoiDungBoiDuong, (QuaTrinhBoiDuongInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
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
                QuaTrinhBoiDuongInfo info = new QuaTrinhBoiDuongInfo();
                info.MaQTBD = this.txtmaQTBD.Text;
                info.MaNhanVien = this.LayMaNhanVien_BoiDuong;
                info.NgayBatDau = this.dtNgayBD.Value;
                info.NgayKetThuc = this.dtNgayKT.Value;
                info.NoiBoiDUong = this.txtNoiBoDuong.Text;
                info.NoiDungBoiDUong = this.txtNoiDungBoiDuong.Text;
                if (IsAddNew)
                {
                    if (ctrlQuaTrinhBoiDuong.Add(info))
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
                        ctrlQuaTrinhBoiDuong.CapNhatQuaTrinhBoiDuong(info, SelectedIndex);
                        this.ReloadData();
                    }
                    ctrlQuaTrinhBoiDuong.HienThiInfo(this.txtmaQTBD, this.dtNgayBD, this.dtNgayKT, this.txtNoiBoDuong, this.txtNoiDungBoiDuong, (QuaTrinhBoiDuongInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
                  
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
                    if (ctrlQuaTrinhBoiDuong == null)
                        ctrlQuaTrinhBoiDuong = new QuaTrinhBoiDuongCtrl();
                    ctrlQuaTrinhBoiDuong.Xoa_QuaTrinhBoiDuong(item.SubItems[0].Text);
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
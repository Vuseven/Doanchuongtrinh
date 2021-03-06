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
    public partial class frm_NGHIVIEC : DevComponents.DotNetBar.Office2007Form
    {
        public frm_NGHIVIEC()
        {
            InitializeComponent();
        }
        #region Property

        private NghiViecInfo m_NghiViecSelected;
        public NghiViecInfo NghiViecSelected
        {
            get { return m_NghiViecSelected; }
            set { m_NghiViecSelected = value; }
        }

        private string m_Open;
        public string Open
        {
            get { return m_Open; }
            set { m_Open = value; }
        }

        private string m_MANV;
        public string LayMaNhanVien_NghiViec
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

        #region PhanQuyen_Xem
        public void PhanQuyen_Xem_An()
        {
            //this.btnLuu.Enabled = false;
            //this.btnXoa.Enabled = false;
            //this.btnIn.Enabled = false;
        }
        public void PhanQuyen_Xem_Hien()
        {
            //this.btnLuu.Enabled = true;
            //this.btnXoa.Enabled = true;
            //this.btnIn.Enabled = true;
        }
        #endregion

        #region ctrlNghiViec
        private NghiViecCtrl m_ctrlNghiViec;
        public NghiViecCtrl ctrlNghiViec
        {
            get { return m_ctrlNghiViec; }
            set { m_ctrlNghiViec = value; }
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

        NhanVienCtrl ctrlNV = null;

        #region frm_NGHIVIEC_Load        
       
        private void frm_NGHIVIEC_Load(object sender, EventArgs e)
        {
            #region HienThiComboBox
            ChucVuCtrl ChucVu_ctrl = new ChucVuCtrl();
            ChucVu_ctrl.HienThiComboBox(this.cboChucVu);
            #endregion     

            if (An_Hien == "Xem")
            {
                this.PhanQuyen_Xem_An();
            }
            else
            {
                this.PhanQuyen_Xem_Hien();
            }

            
            if (ctrlNV == null)
                ctrlNV = new NhanVienCtrl();
            int kq = ctrlNV.TimNV_NghiViec(this.LayMaNhanVien_NghiViec, 0);

            if (kq == 1)//Ton tai Nhan vien bi cham dut hop dong
            {
                this.txtMANGHIVIEC.Text = LayMaNhanVien_NghiViec;
                this.IsAddNew = false;

                if (ctrlNghiViec == null)
                    ctrlNghiViec = new NghiViecCtrl();
                int kt = ctrlNghiViec.KiemTra(this.LayMaNhanVien_NghiViec);

                if (kt == 1)//Ton tai Nhan vien bi cham dut hop dong
                {
                    ctrlNghiViec.Tim_MaNghiViec(this.LayMaNhanVien_NghiViec, txtSOQD, dateNGAYQD, txtNGUOIKY,cboChucVu, dateNGAYTV, txtLyDoThoiViec);
                    this.chkChapNhan.Checked = true;
                }
                else
                {
                    this.IsAddNew = true;
                    if (ctrlNghiViec == null)
                        ctrlNghiViec = new NghiViecCtrl();
                    ctrlNghiViec.Create(txtMANGHIVIEC);
                    this.txtSOQD.Focus();
                }
            }
            else //Khong ton tai
            {
                this.IsAddNew = true;
                if (ctrlNghiViec == null)
                    ctrlNghiViec = new NghiViecCtrl();
                ctrlNghiViec.Create(txtMANGHIVIEC);
                this.txtSOQD.Focus();
            }
        }
        #endregion

        #region itemLuu_Click

        private void itemLuu_Click(object sender, EventArgs e)
        {
            if (this.CheckValid())
            {
                NghiViecInfo info = new NghiViecInfo();
                info.MaNghiViec = this.txtMANGHIVIEC.Text;
                info.MaNhanVien = this.LayMaNhanVien_NghiViec;
                info.SoQuyetDinh = this.txtSOQD.Text;
                info.NgayQuyetDinh = this.dateNGAYQD.Value;
                info.NguoiKy = this.txtNGUOIKY.Text;

                ChucVuCtrl ctrl = new ChucVuCtrl();
                info.ChucVu = ctrl.GetChucVu(this.cboChucVu.SelectedValue.ToString());

                info.NgayThoiViec = this.dateNGAYTV.Value;
                info.LyDoTV = this.txtLyDoThoiViec.Text;
               
                if (IsAddNew)
                {
                    if (MessageBoxEx.Show("Bạn có thực sự Chấm dứt Hợp Đồng này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (ctrlNghiViec == null)
                            ctrlNghiViec = new NghiViecCtrl();
                        if (ctrlNghiViec.Add(info))
                        {
                            this.IsAddNew = false;
                            if (ctrlNV == null)
                                ctrlNV = new NhanVienCtrl();
                            ctrlNV.Update_NhanVien(this.LayMaNhanVien_NghiViec, 0);
                            MessageBoxEx.Show("Lưu Thành Công!", "Lưu Thành Công");
                        }
                    }
                }
                else
                {
                    if (MessageBoxEx.Show("Ban có chắc là cập nhật dòng này không?", "Cập Nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (this.chkChapNhan.Checked == true)
                        {
                            if (ctrlNghiViec == null)
                                ctrlNghiViec = new NghiViecCtrl();
                            ctrlNghiViec.Update(info, SelectedIndex);
                        }
                        else
                        {
                            if (ctrlNV == null)
                                ctrlNV = new NhanVienCtrl();
                            ctrlNV.Update_NhanVien(this.LayMaNhanVien_NghiViec, 1);

                            if (ctrlNghiViec == null)
                                ctrlNghiViec = new NghiViecCtrl();
                            ctrlNghiViec.Update(info, SelectedIndex);
                        }

                    }
                   
                }
            }
        }

        #endregion

        #region CheckValid()
        private bool CheckValid()
        {
            if (this.txtSOQD.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Số quyết định không được phép rỗng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtSOQD.Focus();
                return false;
            }
            if (this.txtNGUOIKY.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Người ký quyết định không được phép rỗng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNGUOIKY.Focus();
                return false;
            }

            if (this.txtLyDoThoiViec.Text.Trim() == "")
            {
                MessageBoxEx.Show("Lý Do Thôi Việc không được phép rỗng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtLyDoThoiViec.Focus();
                return false;
            }
            if (this.dateNGAYTV.Value.Date < this.dateNGAYQD.Value.Date)
            {
                MessageBoxEx.Show("Ngày Thôi việc không được nhỏ hơn Ngày quyết định thôi việc !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNGUOIKY.Focus();
                return false;
            }
            
            if (this.chkChapNhan.Checked == false)
            {
                MessageBoxEx.Show("Bạn hãy check vào Ô xác nhận Chấm dứt Hợp đồng lao động !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
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
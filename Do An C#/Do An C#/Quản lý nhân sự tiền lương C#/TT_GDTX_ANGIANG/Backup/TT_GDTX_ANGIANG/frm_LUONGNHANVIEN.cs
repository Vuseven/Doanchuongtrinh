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
    public partial class frm_LUONGNHANVIEN : DevComponents.DotNetBar.Office2007Form
    {
        public frm_LUONGNHANVIEN()
        {
            InitializeComponent();
        }
        
       
        private string m_Enable;
        public string An_Hien
        {
            get { return m_Enable; }
            set { m_Enable = value; }
        }
        #region ctrlLuongNhanVien
        private LuongNhanVienCtrl m_ctrlLuongNhanVien;
        public LuongNhanVienCtrl ctrlLuongNhanVien
        {
            get { return m_ctrlLuongNhanVien; }
            set { m_ctrlLuongNhanVien = value; }
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

        private LươngNhanVienInfo m_LuongNhanVienSelected;
        public LươngNhanVienInfo LuongNhanVienSelected
        {
            get { return m_LuongNhanVienSelected; }
            set { m_LuongNhanVienSelected = value; }
        }

        private string m_Open;
        public string Open
        {
            get { return m_Open; }
            set { m_Open = value; }
        }

        private string m_MANV;
        public string LayMaNhanVien_LuongNhanVien
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


       
        #endregion

        #region CheckValid()
        private bool CheckValid()
        {
            if (this.txtMaLuong.Text.Trim() == "")
            {
                MessageBoxEx.Show("Chưa Nhấn Nút Thêm Mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.itemThemMoi.Focus();
                return false;
            }
            if (this.txtHeSoLuong.Text.Trim() == "")
            {
                MessageBoxEx.Show("Chưa Nhập hệ số lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtHeSoLuong.Focus();
                return false;
            }
            if (this.check2nam.Checked == true && this.check3nam.Checked == true)
            {
                MessageBox.Show("Chỉ Có Thể Chọn 2 Năm hoặc 3 Năm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.check2nam.Focus();
                return false;
            }
            if (this.check2nam.Checked == false && this.check3nam.Checked == false)
            {
                MessageBox.Show("Bạn phải Chọn 2 Năm hoặc 3 Năm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.check2nam.Focus();
                return false;
            }
            if ((this.checkGiaoVien.Checked == true && this.checkNVVanPhong.Checked == true))
            {
                MessageBox.Show("Chỉ Có Thể Chọn Nhân Viên Văn Phòng Hoặc Giáo Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.checkGiaoVien.Focus();
                return false;
            }
            if ((this.checkGiaoVien.Checked == false && this.checkNVVanPhong.Checked == false))
            {
                MessageBox.Show("Bạn Phải Chọn Giáo Viên Hoặc Chọn Nhân Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.checkGiaoVien.Focus();
                return false;
            }
            //if ((this.dtNgayKT.Value.Year - this.dtNgayBD.Value.Year) != 2)
            //{
            //    MessageBox.Show("Ngày Bắt Đầu Phải Cách Ngày Kết Thúc 2 năm ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.dtNgayBD.Focus();
            //    return false;
            //}
            if (this.check2nam.Checked == true)
            {
                if ((this.dtNgayKT.Value.Year - this.dtNgayBD.Value.Year) != 2)
                {
                    MessageBox.Show("Ngày Bắt Đầu Phải Cách Ngày Kết Thúc 2 năm ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.dtNgayBD.Focus();
                    return false;
                }
            }
            if (this.check3nam.Checked == true)
            {
                if ((this.dtNgayKT.Value.Year - this.dtNgayBD.Value.Year) != 3)
                {
                    MessageBox.Show("Ngày Bắt Đầu Phải Cách Ngày Kết Thúc 3 năm ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.dtNgayBD.Focus();
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region ReloadData()
        private void ReloadData()
        {
            if (ctrlLuongNhanVien == null)
            {
                ctrlLuongNhanVien = new LuongNhanVienCtrl();
            }
            ctrlLuongNhanVien.HienThi_dsLuongNhanVien(this.listViewExQTDaoTao, this.LayMaNhanVien_LuongNhanVien);
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                this.SelectedIndex = 0;
                this.listViewExQTDaoTao.Items[this.SelectedIndex].Selected = true;
                ctrlLuongNhanVien.HienThiInfo(this.check2nam, this.check3nam, this.checkThuViec, this.checkGiaoVien, this.checkNVVanPhong, this.txtMaLuong, this.cboTenNgach, this.dtNgayBD, this.dtNgayKT, this.cboTenBac, this.txtHeSoLuong, this.dbLuongCoBan, this.dbHSPCCV, this.dbLuong, this.dbTruCacKhoan, this.dbLuongConLai, this.dbDangPhi, this.dbLuongThucLanh, this.dbGiaoVien, this.dbNhanVienVanPhong, (LươngNhanVienInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                this.itemXoa.Enabled = true;
            }
            else
            {

                this.txtMaLuong.Text = null;
                //this.txtTenNgach.Text = null;
                //this.dbBacLuong.Text = "1";
                //this.txtHeSoLuong.Text = "0.0";
                this.dbLuongConLai.Text = "0.0";
                this.dtNgayBD.Value = DateTime.Now;
                this.dtNgayKT.Value = DateTime.Now;
                this.dbHSPCCV.Text = "0.0";
                this.dbLuong.Text = "0.0";
                this.dbTruCacKhoan.Text = "0.0";
                this.dbLuongConLai.Text = "0.0";
                this.dbDangPhi.Text = "0.0";
                this.dbLuongThucLanh.Text = "0.0";
                this.dbGiaoVien.Text = "0.0";
                this.dbNhanVienVanPhong.Text = "0.0";


                this.IsAddNew = true;
                this.txtMaLuong.Focus();
                this.itemXoa.Enabled = false;
            }
        }
        #endregion

        #region frm_LUONGNHANVIEN_Load

        private void frm_LUONGNHANVIEN_Load(object sender, EventArgs e)
        {


            NgachCtrl ctrlNgach = new NgachCtrl();
            ctrlNgach.HienThiComboBox(this.cboTenNgach);

            BacCtrl ctrlBac = new BacCtrl();
            ctrlBac.HienThiComboBox(this.cboTenBac);

            cboTenNgach.SelectedValueChanged += new EventHandler(cboTenNgach_SelectedIndexChanged);
            cboTenBac.SelectedValueChanged += new EventHandler(cboTenNgach_SelectedIndexChanged);





            if (An_Hien == "Xem")
            {
                this.PhanQuyen_Xem_An();
            }
            else
            {
                this.PhanQuyen_Xem_Hien();
            }

            if (ctrlLuongNhanVien == null)
            {
                ctrlLuongNhanVien = new LuongNhanVienCtrl();
            }
            ctrlLuongNhanVien.HienThi_dsLuongNhanVien(this.listViewExQTDaoTao, this.LayMaNhanVien_LuongNhanVien);
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {

                LuongNhanVienData dataLuong = new LuongNhanVienData();
                dataLuong.lay_dsLuongNhanVienDS(this.LayMaNhanVien_LuongNhanVien);
                DataTable Table = new DataTable();
                Table = dataLuong.lay_dsLuongNhanVienDS(this.LayMaNhanVien_LuongNhanVien);
                bool b = true; int max = 0; int[] a = new int[100]; int k = 0;
                while (b)
                {
                    for (int i=0 ; i < Table.Rows.Count; i++)
                    {
                        if (Table.Rows[i][0].ToString().Length == 3)
                        {
                            if ((a[i] = Convert.ToInt16(Table.Rows[i][0].ToString().Substring(2, 1))) > max)
                            {
                                max = a[i]; k = i;
                            }
                        }
                        if (Table.Rows[i][0].ToString().Length == 4)
                        {
                            if ((a[i] = Convert.ToInt16(Table.Rows[i][0].ToString().Substring(2, 2))) > max)
                            {
                                max = a[i]; k = i;
                            }
                        }
                        if (Table.Rows[i][0].ToString().Length == 5)
                        {
                            if ((a[i] = Convert.ToInt16(Table.Rows[i][0].ToString().Substring(2, 3))) > max)
                            {
                                max = a[i]; k = i;
                            }
                        }
                        if (Table.Rows[i][0].ToString().Length == 6)
                        {
                            if ((a[i] = Convert.ToInt16(Table.Rows[i][0].ToString().Substring(2, 4))) > max)
                            {
                                max = a[i]; k = i;
                            }
                        }

                    }
                    
                    this.SelectedIndex = k;
                    b = false;
                }


                
                
                this.listViewExQTDaoTao.Items[this.SelectedIndex].Selected = true;
                ctrlLuongNhanVien.HienThiInfo(this.check2nam,this.check3nam,this.checkThuViec, this.checkGiaoVien, this.checkNVVanPhong, this.txtMaLuong, this.cboTenNgach, this.dtNgayBD, this.dtNgayKT, this.cboTenBac, this.txtHeSoLuong, this.dbLuongCoBan, this.dbHSPCCV, this.dbLuong, this.dbTruCacKhoan, this.dbLuongConLai, this.dbDangPhi, this.dbLuongThucLanh, this.dbGiaoVien, this.dbNhanVienVanPhong, (LươngNhanVienInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);

                this.IsAddNew = false;
                this.itemXoa.Enabled = true;

                #region capnhatluong2nam
                if (((dtNgayKT.Value.DayOfYear) <= (System.DateTime.Now.DayOfYear)) && ((dtNgayKT.Value.Year) <= (System.DateTime.Now.Year)) && check2nam.Checked == true)
                {




                    if (MessageBoxEx.Show("Đã đến thời điểm tăng Bậc Lương Cho Nhân Viên này. \nBạn có muốn cập nhật Bậc Lương tự độ cho Nhân Viên không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dtNgayBD.Text = dtNgayKT.Value.ToShortDateString();
                        String ngay = "";
                        String thang = "";
                        String nam = "";
                        ngay = dtNgayKT.Value.Day.ToString();
                        thang = dtNgayKT.Value.Month.ToString();
                        if (Convert.ToInt16(cboTenBac.Text.ToString()) >= 12)
                        {
                            int nam_ = dtNgayKT.Value.Year + 1;
                            nam = nam_.ToString();
                            String ngayKT = thang + "/" + ngay + "/" + nam;
                            dtNgayKT.Value = Convert.ToDateTime(ngayKT);

                            int tenbac = Convert.ToInt16(cboTenBac.Text.ToString());
                            cboTenBac.Text = Convert.ToString(tenbac);

                        }
                        else
                        {
                            int nam_ = dtNgayKT.Value.Year + 2;
                            nam = nam_.ToString();
                            String ngayKT = thang + "/" + ngay + "/" + nam;
                            dtNgayKT.Value = Convert.ToDateTime(ngayKT);

                            int tenbac = Convert.ToInt16(cboTenBac.Text.ToString()) + 1;
                            cboTenBac.Text = Convert.ToString(tenbac);
                        }

                        ctrlLuongNhanVien.Create(txtMaLuong);

                        LươngNhanVienInfo info = new LươngNhanVienInfo();
                        info.MaLuong = this.txtMaLuong.Text;
                        info.MaNhanVien = this.LayMaNhanVien_LuongNhanVien;
                        info.TenNgach = this.cboTenNgach.Text;
                        info.NgayBatDau = this.dtNgayBD.Value;
                        info.NgayKetThuc = this.dtNgayKT.Value;
                        ///////////////////////////////////////////////







                        /////////////////////////////////////////////////
                        info.BacLuong = int.Parse(this.cboTenBac.Text);
                        if ((Convert.ToInt16(cboTenBac.Text)) + 1 >= 13)
                        {
                            info.HeSoLuong = (float.Parse(this.txtHeSoLuong.Text)) + ((float.Parse(this.txtHeSoLuong.Text)) / 20);
                        }
                        else
                            info.HeSoLuong = float.Parse(this.txtHeSoLuong.Text);
                        this.txtHeSoLuong.Text = info.HeSoLuong.ToString();
                        
                        info.HeSoPCChucVu = float.Parse(this.dbHSPCCV.Text);
                        info.LuongCoBan = float.Parse(this.dbLuongCoBan.Text);
                        info.Luong = ((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text));
                        info.TruCacKhoan = (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"));
                        info.LuongConLai = (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06")));
                        info.DangPhi = float.Parse(this.dbDangPhi.Text);

                        if (this.check2nam.Checked == true)
                        {

                            info.Chon2Nam = int.Parse("1");
                            info.Chon3Nam = int.Parse("0");

                        }
                        if (this.check3nam.Checked == true)
                        {
                            info.Chon2Nam = int.Parse("0");
                            info.Chon3Nam = int.Parse("1");
                        }
                        //Kiểm tra có phải là Giáo Viên không? Là Giáo Viên thử việc hay chính thức?
                        if (this.checkGiaoVien.Checked == true)
                        {
                            if (checkThuViec.Checked == false)
                            {
                                info.LuongThucLanh = ((((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"))) + (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.3")) - float.Parse(this.dbDangPhi.Text));
                                info.ChonThuViec = int.Parse("0");
                            }
                            else
                            {
                                info.LuongThucLanh = ((((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"))) + (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.3")) - float.Parse(this.dbDangPhi.Text)) * float.Parse("0.85");
                                info.ChonThuViec = int.Parse("1");
                            }
                            info.GiaoVien = (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.3"));
                            info.ChonGiaoVien = int.Parse("1");


                        }
                        else
                        {
                            info.ChonGiaoVien = int.Parse("0");
                        }

                        //Kiểm tra có phải là Nhân Viên Văn Phòng không? Là Nhân viên thử việc hay chính thức?
                        if (this.checkNVVanPhong.Checked == true)
                        {
                            info.NhanVienVanPhong = (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.2"));
                            info.ChonNhanVienVanPhong = int.Parse("1");
                            if (checkThuViec.Checked == false)
                            {
                                info.LuongThucLanh = ((((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"))) + (((float.Parse(this.dbHSPCCV.Text) + float.Parse(this.txtHeSoLuong.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.2")) - float.Parse(this.dbDangPhi.Text));
                                info.ChonThuViec = int.Parse("0");
                            }
                            else
                            {
                                info.LuongThucLanh = ((((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"))) + (((float.Parse(this.dbHSPCCV.Text) + float.Parse(this.txtHeSoLuong.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.2")) - float.Parse(this.dbDangPhi.Text)) * float.Parse("0.85");
                                info.ChonThuViec = int.Parse("1");
                            }

                        }
                        else
                        {
                            info.ChonNhanVienVanPhong = int.Parse("0");
                        }
                        ctrlLuongNhanVien.Add(info);
                        this.ReloadData();
                    }




                }
                #endregion
                #region capnhatluong3nam
                if (((dtNgayKT.Value.DayOfYear) <= (System.DateTime.Now.DayOfYear)) && ((dtNgayKT.Value.Year) <= (System.DateTime.Now.Year)) && check3nam.Checked == true)
                {




                    if (MessageBoxEx.Show("Đã đến thời điểm tăng Bậc Lương Cho Nhân Viên này. \nBạn có muốn cập nhật Bậc Lương tự độ cho Nhân Viên không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dtNgayBD.Text = dtNgayKT.Value.ToShortDateString();
                        String ngay = "";
                        String thang = "";
                        String nam = "";
                        ngay = dtNgayKT.Value.Day.ToString();
                        thang = dtNgayKT.Value.Month.ToString();

                        if (Convert.ToInt16(cboTenBac.Text.ToString()) >= 9)
                        {
                            int nam_ = dtNgayKT.Value.Year + 1;
                            nam = nam_.ToString();
                            String ngayKT = thang + "/" + ngay + "/" + nam;
                            dtNgayKT.Value = Convert.ToDateTime(ngayKT);

                            int tenbac = Convert.ToInt16(cboTenBac.Text.ToString());
                            cboTenBac.Text = Convert.ToString(tenbac);

                        }
                        else
                        {
                            int nam_ = dtNgayKT.Value.Year + 3;
                            nam = nam_.ToString();
                            String ngayKT = thang + "/" + ngay + "/" + nam;
                            dtNgayKT.Value = Convert.ToDateTime(ngayKT);

                            int tenbac = Convert.ToInt16(cboTenBac.Text.ToString()) + 1;
                            cboTenBac.Text = Convert.ToString(tenbac);
                        }


                        

                        ctrlLuongNhanVien.Create(txtMaLuong);

                        LươngNhanVienInfo info = new LươngNhanVienInfo();
                        info.MaLuong = this.txtMaLuong.Text;
                        info.MaNhanVien = this.LayMaNhanVien_LuongNhanVien;
                        info.TenNgach = this.cboTenNgach.Text;
                        info.NgayBatDau = this.dtNgayBD.Value;
                        info.NgayKetThuc = this.dtNgayKT.Value;
                        ///////////////////////////////////////////////







                        /////////////////////////////////////////////////
                        info.BacLuong = int.Parse(this.cboTenBac.Text);

                        if ((Convert.ToInt16(cboTenBac.Text)) + 1 >= 10)
                        {
                            info.HeSoLuong = (float.Parse(this.txtHeSoLuong.Text)) + ((float.Parse(this.txtHeSoLuong.Text)) / 20);
                        }
                        else
                            info.HeSoLuong = float.Parse(this.txtHeSoLuong.Text);
                        this.txtHeSoLuong.Text = info.HeSoLuong.ToString();
                        info.HeSoPCChucVu = float.Parse(this.dbHSPCCV.Text);
                        info.LuongCoBan = float.Parse(this.dbLuongCoBan.Text);
                        info.Luong = ((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text));
                        info.TruCacKhoan = (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"));
                        info.LuongConLai = (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06")));
                        info.DangPhi = float.Parse(this.dbDangPhi.Text);

                        if (this.check2nam.Checked == true)
                        {

                            info.Chon2Nam = int.Parse("1");
                            info.Chon3Nam = int.Parse("0");

                        }
                        if (this.check3nam.Checked == true)
                        {
                            info.Chon2Nam = int.Parse("0");
                            info.Chon3Nam = int.Parse("1");
                        }
                        //Kiểm tra có phải là Giáo Viên không? Là Giáo Viên thử việc hay chính thức?
                        if (this.checkGiaoVien.Checked == true)
                        {
                            if (checkThuViec.Checked == false)
                            {
                                info.LuongThucLanh = ((((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"))) + (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.3")) - float.Parse(this.dbDangPhi.Text));
                                info.ChonThuViec = int.Parse("0");
                            }
                            else
                            {
                                info.LuongThucLanh = ((((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"))) + (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.3")) - float.Parse(this.dbDangPhi.Text)) * float.Parse("0.85");
                                info.ChonThuViec = int.Parse("1");
                            }
                            info.GiaoVien = (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.3"));
                            info.ChonGiaoVien = int.Parse("1");


                        }
                        else
                        {
                            info.ChonGiaoVien = int.Parse("0");
                        }

                        //Kiểm tra có phải là Nhân Viên Văn Phòng không? Là Nhân viên thử việc hay chính thức?
                        if (this.checkNVVanPhong.Checked == true)
                        {
                            info.NhanVienVanPhong = (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.2"));
                            info.ChonNhanVienVanPhong = int.Parse("1");
                            if (checkThuViec.Checked == false)
                            {
                                info.LuongThucLanh = ((((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"))) + (((float.Parse(this.dbHSPCCV.Text) + float.Parse(this.txtHeSoLuong.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.2")) - float.Parse(this.dbDangPhi.Text));
                                info.ChonThuViec = int.Parse("0");
                            }
                            else
                            {
                                info.LuongThucLanh = ((((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"))) + (((float.Parse(this.dbHSPCCV.Text) + float.Parse(this.txtHeSoLuong.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.2")) - float.Parse(this.dbDangPhi.Text)) * float.Parse("0.85");
                                info.ChonThuViec = int.Parse("1");
                            }

                        }
                        else
                        {
                            info.ChonNhanVienVanPhong = int.Parse("0");
                        }
                        ctrlLuongNhanVien.Add(info);
                        this.ReloadData();
                    }




                }
                #endregion
            }
            else
            {

                this.txtMaLuong.Text = null;
                //this.txtTenNgach.Text = null;
                //this.dbBacLuong.Text = "1";
                //this.txtHeSoLuong.Text = "0.0";
                this.dbLuongCoBan.Text = "540";
                this.dtNgayBD.Value = DateTime.Now;
                this.dtNgayKT.Value = DateTime.Now;
                this.dbHSPCCV.Text = "0.0";
                this.dbLuong.Text = "0.0";
                this.dbTruCacKhoan.Text = "0.0";
                this.dbLuongConLai.Text = "0.0";
                this.dbDangPhi.Text = "0.0";
                this.dbLuongThucLanh.Text = "0.0";
                this.dbGiaoVien.Text = "0.0";
                this.dbNhanVienVanPhong.Text = "0.0";


                this.IsAddNew = true;
                this.txtMaLuong.Focus();
                this.itemXoa.Enabled = false;
            }
        }
        #endregion

        #region itemThemMoi_Click

        private void itemThemMoi_Click(object sender, EventArgs e)
        {
            if (!this.IsAddNew)
            {
                this.txtMaLuong.Text = null;
                this.cboTenNgach.SelectedIndex = 0;
                this.cboTenBac.SelectedIndex = 0;
                this.txtHeSoLuong.Text = "0.0";
                this.dbLuongCoBan.Text = "540";
                this.dtNgayBD.Value = DateTime.Now;
                this.dtNgayKT.Value = DateTime.Now;
                this.dbHSPCCV.Text = "0.0";
                this.dbLuong.Text = "0.0";
                this.dbTruCacKhoan.Text = "0.0";
                this.dbLuongConLai.Text = "0.0";
                this.dbDangPhi.Text = "0.0";
                this.dbLuongThucLanh.Text = "0.0";
                this.dbGiaoVien.Text = "0.0";
                this.dbNhanVienVanPhong.Text = "0.0";
                this.checkGiaoVien.Checked = false;
                this.checkNVVanPhong.Checked = false;
                this.checkThuViec.Checked = false;
                this.check2nam.Checked = false;
                this.check3nam.Checked = false;
                this.IsAddNew = true;

            }
            ctrlLuongNhanVien.Create(txtMaLuong);
            this.cboTenNgach.Focus();
        }
        #endregion

        #region itemLuu_Click

        private void itemLuu_Click(object sender, EventArgs e)
        {

            if (this.CheckValid())
            {
                LươngNhanVienInfo info = new LươngNhanVienInfo();
                info.MaLuong = this.txtMaLuong.Text;
                info.MaNhanVien = this.LayMaNhanVien_LuongNhanVien;
                info.TenNgach = this.cboTenNgach.Text;
                info.NgayBatDau = this.dtNgayBD.Value;
                info.NgayKetThuc = this.dtNgayKT.Value;
                ///////////////////////////////////////////////







                /////////////////////////////////////////////////
                info.BacLuong = int.Parse(this.cboTenBac.Text);
                info.HeSoLuong = float.Parse(this.txtHeSoLuong.Text);
                info.HeSoPCChucVu = float.Parse(this.dbHSPCCV.Text);
                info.LuongCoBan = float.Parse(this.dbLuongCoBan.Text);
                info.Luong = ((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text));
                info.TruCacKhoan = (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"));
                info.LuongConLai = (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06")));
                info.DangPhi = float.Parse(this.dbDangPhi.Text);

                #region CapNhatDanhDau
                LuongNhanVienData dataluong = new LuongNhanVienData();
                DataTable tb = new DataTable();
                tb = dataluong.lay_dsLuongNhanVien();
                bool b = true;
                
                //int max = 0;
                int[] a = new int[1000];
                while (b)
                {
                    
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        
                        if (tb.Rows[i][1].ToString()==info.MaNhanVien)
                        {

                            #region CapNhatLuong
                            int index = i;
                 

                            tb.Rows[index]["DANHDAU"] = 0;
                            string maL = tb.Rows[index][0].ToString();
                            int t = 0;

                            dataluong.CapNhatLuongNhanVienDanhDau(t, maL);
                            LuongNhanVienData dataluong1 = new LuongNhanVienData();
                            DataTable tb1 = new DataTable();
                            tb1 = dataluong.lay_dsLuongNhanVien();
                            tb = tb1;
                            #endregion

                        }


                    }

                    b = false;

                }
                #endregion
                if (this.check2nam.Checked == true)
                {
                   
                        info.Chon2Nam = int.Parse("1");
                        info.Chon3Nam = int.Parse("0");
                   
                }
                if (this.check3nam.Checked == true)
                {
                    info.Chon2Nam = int.Parse("0");
                    info.Chon3Nam = int.Parse("1");
                }

                //Kiểm tra có phải là Giáo Viên không? Là Giáo Viên thử việc hay chính thức?
                if (this.checkGiaoVien.Checked == true)
                {
                    if (checkThuViec.Checked == false)
                    {
                        info.LuongThucLanh = ((((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"))) + (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.3")) - float.Parse(this.dbDangPhi.Text));
                        info.ChonThuViec = int.Parse("0");
                    }
                    else
                    {
                        info.LuongThucLanh = ((((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"))) + (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.3")) - float.Parse(this.dbDangPhi.Text)) * float.Parse("0.85");
                        info.ChonThuViec = int.Parse("1");
                    }
                    info.GiaoVien = (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.3"));
                    info.ChonGiaoVien = int.Parse("1");


                }
                else
                {
                    info.ChonGiaoVien = int.Parse("0");
                }

                //Kiểm tra có phải là Nhân Viên Văn Phòng không? Là Nhân viên thử việc hay chính thức?
                if (this.checkNVVanPhong.Checked == true)
                {
                    info.NhanVienVanPhong = (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.2"));
                    info.ChonNhanVienVanPhong = int.Parse("1");
                    if (checkThuViec.Checked == false)
                    {
                        info.LuongThucLanh = ((((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"))) + (((float.Parse(this.dbHSPCCV.Text) + float.Parse(this.txtHeSoLuong.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.2")) - float.Parse(this.dbDangPhi.Text));
                        info.ChonThuViec = int.Parse("0");
                    }
                    else
                    {
                        info.LuongThucLanh = ((((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"))) + (((float.Parse(this.dbHSPCCV.Text) + float.Parse(this.txtHeSoLuong.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.2")) - float.Parse(this.dbDangPhi.Text)) * float.Parse("0.85");
                        info.ChonThuViec = int.Parse("1");
                    }

                }
                else
                {
                    info.ChonNhanVienVanPhong = int.Parse("0");
                }



                if (IsAddNew)
                {
                    if (ctrlLuongNhanVien.Add(info))
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
                        ctrlLuongNhanVien.CapNhatLuongNhanVien(info, SelectedIndex);
                        this.ReloadData();
                    }
                    ctrlLuongNhanVien.HienThiInfo(this.check2nam, this.check3nam, this.checkThuViec, this.checkGiaoVien, this.checkNVVanPhong, this.txtMaLuong, this.cboTenNgach, this.dtNgayBD, this.dtNgayKT, this.cboTenBac, this.txtHeSoLuong, this.dbLuongCoBan, this.dbHSPCCV, this.dbLuong, this.dbTruCacKhoan, this.dbLuongConLai, this.dbDangPhi, this.dbLuongThucLanh, this.dbGiaoVien, this.dbNhanVienVanPhong, (LươngNhanVienInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);

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
                    ctrlLuongNhanVien.HienThiInfo(this.check2nam, this.check3nam, this.checkThuViec, this.checkGiaoVien, this.checkNVVanPhong, this.txtMaLuong, this.cboTenNgach, this.dtNgayBD, this.dtNgayKT, this.cboTenBac, this.txtHeSoLuong, this.dbLuongCoBan, this.dbHSPCCV, this.dbLuong, this.dbTruCacKhoan, this.dbLuongConLai, this.dbDangPhi, this.dbLuongThucLanh, this.dbGiaoVien, this.dbNhanVienVanPhong, (LươngNhanVienInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
                }
            }
        }
        #endregion

        #region itemBoQua_Click

        private void itemBoQua_Click(object sender, EventArgs e)
        {
            if (this.listViewExQTDaoTao.Items.Count > 0)
            {
                ctrlLuongNhanVien.HienThiInfo(this.check2nam, this.check3nam, this.checkThuViec, this.checkGiaoVien, this.checkNVVanPhong, this.txtMaLuong, this.cboTenNgach, this.dtNgayBD, this.dtNgayKT, this.cboTenBac, this.txtHeSoLuong, this.dbLuongCoBan, this.dbHSPCCV, this.dbLuong, this.dbTruCacKhoan, this.dbLuongConLai, this.dbDangPhi, this.dbLuongThucLanh, this.dbGiaoVien, this.dbNhanVienVanPhong, (LươngNhanVienInfo)this.listViewExQTDaoTao.Items[this.SelectedIndex].Tag);
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
                IEnumerator ie = this.listViewExQTDaoTao.SelectedItems.GetEnumerator();
                while (ie.MoveNext())
                {
                    ListViewItem item = (ListViewItem)ie.Current;
                    listViewExQTDaoTao.Items.Remove(item);
                    if (ctrlLuongNhanVien == null)
                        ctrlLuongNhanVien = new LuongNhanVienCtrl();
                    ctrlLuongNhanVien.Xoa_Luong(item.SubItems[0].Text);
                    if (this.SelectedIndex != 0)
                    {
                        this.SelectedIndex--;
                       
                    }
                    #region CapNhatDanhDauXoa
                    LuongNhanVienData dataLuong = new LuongNhanVienData();
                    dataLuong.lay_dsLuongNhanVienDS(this.LayMaNhanVien_LuongNhanVien);
                    DataTable Table = new DataTable();
                    Table = dataLuong.lay_dsLuongNhanVienDS(this.LayMaNhanVien_LuongNhanVien);
                    bool b = true; int max = 0; int[] a = new int[100]; int k = 0;
                    while (b)
                    {
                        for (int i = 0; i < Table.Rows.Count; i++)
                        {
                            if (Table.Rows[i][0].ToString().Length == 3)
                            {
                                if ((a[i] = Convert.ToInt16(Table.Rows[i][0].ToString().Substring(2, 1))) > max)
                                {
                                    max = a[i]; k = i;
                                }
                            }
                            if (Table.Rows[i][0].ToString().Length == 4)
                            {
                                if ((a[i] = Convert.ToInt16(Table.Rows[i][0].ToString().Substring(2, 2))) > max)
                                {
                                    max = a[i]; k = i;
                                }
                            }
                            if (Table.Rows[i][0].ToString().Length == 5)
                            {
                                if ((a[i] = Convert.ToInt16(Table.Rows[i][0].ToString().Substring(2, 3))) > max)
                                {
                                    max = a[i]; k = i;
                                }
                            }
                            if (Table.Rows[i][0].ToString().Length == 6)
                            {
                                if ((a[i] = Convert.ToInt16(Table.Rows[i][0].ToString().Substring(2, 4))) > max)
                                {
                                    max = a[i]; k = i;
                                }
                            }

                        }

                        this.SelectedIndex = k;
                        string s1 = string.Concat("ML", max.ToString());
                        dataLuong.CapNhatLuongNhanVienDanhDau(1, s1);
                        b = false;
                    }
                    #endregion
                }
               
                this.ReloadData();
            }
        }
        #endregion

        private void cboTenNgach_SelectedIndexChanged(object sender, EventArgs e)
        {
            HeSoLuongNhanVienCtrl hslCtrl = new HeSoLuongNhanVienCtrl();
            if (cboTenBac.SelectedValue.ToString() == null)
                cboTenBac.SelectedIndex = 1;

            txtHeSoLuong.Text = hslCtrl.LayHeSoLuong(cboTenNgach.SelectedValue.ToString(), cboTenBac.SelectedValue.ToString());
            LươngNhanVienInfo info = new LươngNhanVienInfo();
            try
            {

                info.TenNgach = this.cboTenNgach.Text;
                info.BacLuong = int.Parse(this.cboTenBac.Text);
                info.HeSoLuong = float.Parse(this.txtHeSoLuong.Text);
                info.HeSoPCChucVu = float.Parse(this.dbHSPCCV.Text);
                info.LuongCoBan = float.Parse(this.dbLuongCoBan.Text);
                info.Luong = ((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text));
                info.TruCacKhoan = (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06"));
                info.LuongConLai = (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) - (((float.Parse(this.txtHeSoLuong.Text) + float.Parse(this.dbHSPCCV.Text)) * float.Parse(this.dbLuongCoBan.Text)) * float.Parse("0.06")));
                info.DangPhi = float.Parse(this.dbDangPhi.Text);
                dbLuong.Text = Convert.ToString(info.Luong);
                dbTruCacKhoan.Text = Convert.ToString(info.TruCacKhoan);
                dbLuongConLai.Text = Convert.ToString(info.LuongConLai);
            }
            catch
            {
                MessageBoxEx.Show("Loading");

            }



        }

        private void check2nam_CheckedChanged(object sender, EventArgs e)
        {
            if (check2nam.Checked == true)
                check3nam.Checked = false;
            if (check2nam.Checked == false)
                check3nam.Checked = true;

        }

        private void check3nam_CheckedChanged(object sender, EventArgs e)
        {
            if (check3nam.Checked == true)
                check2nam.Checked = false;
            if (check3nam.Checked == false)
                check2nam.Checked = true;
        }




    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
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
    public partial class frm_HOSOTUYENDUNG : DevComponents.DotNetBar.Office2007Form
    {
        public frm_HOSOTUYENDUNG()
        {
            InitializeComponent();
        }
        
       

        #region Property
        private HoSoTuyenDungInfo m_HoSoSelected;
        public HoSoTuyenDungInfo HoSoSelected
        {
            get { return m_HoSoSelected; }
            set { m_HoSoSelected = value; }
        }

        private string m_Open;
        public string Open
        {
            get { return m_Open; }
            set { m_Open = value; }
        }
        private string m_MAHS;
        public string LayHoSo
        {
            get { return m_MAHS; }
            set { m_MAHS = value; }
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
            this.btThemMoi.Enabled = false;           
            this.btLuuHoSoTuyenDung.Enabled = false;
            this.btXoaHSTuyenDung.Enabled = false;

           
        }
        public void PhanQuyen_Xem_Hien()
        {
            this.btThemMoi.Enabled = true;           
            this.btLuuHoSoTuyenDung.Enabled = true;
            this.btXoaHSTuyenDung.Enabled = true;
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

        #region ctrlHoSoTuyenDung
        private HoSoTuyenDungCtrl m_ctrlHoSoTuyenDung;
        public HoSoTuyenDungCtrl ctrlHoSoTuyenDung
        {
            get { return m_ctrlHoSoTuyenDung; }
            set { m_ctrlHoSoTuyenDung = value; }
        }
        #endregion

        #region CheckValid()
        private bool CheckValid()
        {
            // Kiểm Tra Mã Hồ Sơ
            if (this.txtMaHS.Text.Trim()== "" )
            {
                MessageBoxEx.Show("Bạn Chưa Nhập Mã Hồ Sơ. \n Hãy Bấm nút Thêm Mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btThemMoi.Focus();
                return false;
            }
            // Kiểm Tra Họ Tên
            if (this.txtHoTen.Text.Trim() == "" )
            {
                MessageBoxEx.Show(" Bạn Chưa nhập Họ Tên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtHoTen.Focus();
                return false;
            }
            //Kiểm tra Ngày sinh
            if (this.dtNgaySinh.Value != null)
            {
                if ((DateTime.Now.Year - this.dtNgaySinh.Value.Year) < 21 || (DateTime.Now.Year - this.dtNgaySinh.Value.Year) > 40)
                {
                    MessageBoxEx.Show("Năm sinh của nhân viên không hợp lệ. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.dtNgaySinh.Focus();
                    return false;
                }
            }
           //Kiểm tra Ngày Cấp CMND
            if (this.dtNgayCapCMND.Value != null)
            {
                if ((this.dtNgayCapCMND.Value.Year - this.dtNgaySinh.Value.Year) < 15)
                {
                    MessageBoxEx.Show("Năm Cấp CMND không hợp lệ.\nNăm cấp CMND phải lớn hơn Năm sinh 15 năm! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.dtNgayCapCMND.Focus();
                    return false;
                }
            }

            //Kiểm tra Ngày Vào Đoàn            
            if ((this.dtNgayVaoDoan.Value.Year - this.dtNgaySinh.Value.Year) < 12)
            {
                 MessageBoxEx.Show("Năm Vào Đoàn không hợp lệ.\nNăm Vào Đoàn phải lớn hơn Năm sinh 12 năm! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 this.dtNgayVaoDoan.Focus();
                 return false;
            }

            //Kiểm tra Ngày Công Đoàn            
            if ((this.dtNgayVaoCD.Value.Year - this.dtNgaySinh.Value.Year) < 15)
            {
                MessageBoxEx.Show("Năm Vào Công Đoàn không hợp lệ.\nNăm Vào Công Đoàn phải lớn hơn Năm sinh 15 năm! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtNgayVaoCD.Focus();
                return false;
            }
            //Kiểm tra Ngày Vào Đảng           
            if ((this.dtNgayVaoDang.Value.Year - this.dtNgaySinh.Value.Year) < 18)
            {
                MessageBoxEx.Show("Năm Vào Đảng không hợp lệ.\nNăm Vào Đảng phải lớn hơn Năm sinh 18 năm! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtNgayVaoDang.Focus();
                return false;
            }
            //Kiểm tra Ngày Chính Thức Vào Đảng           
            if ((this.dtNgayCTVaoDang.Value.Year - this.dtNgaySinh.Value.Year) < 18)
            {
                MessageBoxEx.Show("Năm Chính Thức Vào Đảng không hợp lệ.\nNăm Chính Thức Vào Đảng phải lớn hơn Năm sinh 18 năm! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtNgayCTVaoDang.Focus();
                return false;
            }

            //Kiểm tra Ngày Tuyển Dụng           
            if ((this.dtNgayTuyenDung.Value.Year - this.dtNgaySinh.Value.Year) < 21)
            {
                MessageBoxEx.Show("Năm Tuyển Dụng không hợp lệ.\nNăm Tuyển Dụng phải lớn hơn Năm sinh 21 năm! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtNgayTuyenDung.Focus();
                return false;
            }

            // Kiểm tra số CMND
            if (this.txtCMND.Text.Trim() != "")
            {
                if (this.txtCMND.Text.Trim().Length != 9)
                {
                    MessageBoxEx.Show("Bạn đã nhập số CMND không đúng với thực tế", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtCMND.Text = "";
                    this.txtCMND.Focus();
                    return false;
                }
                if (!Utility.IsNum(this.txtCMND.Text))
                {
                    MessageBoxEx.Show("Bạn đã nhập số CMND không đúng với thực tế", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtCMND.Text = "";
                    this.txtCMND.Focus();
                    return false;
                }
            }
            else
            {
                MessageBoxEx.Show("Chưa nhập số CMND ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCMND.Focus();
                return false;
            }
            
            // Kiểm tra số Điện Thoại Nhà
            if (this.txtDThoaiNha.Text.Trim() != "")
            {
                if (this.txtDThoaiNha.Text.Trim().Length != 10 )
                {
                    MessageBoxEx.Show("Bạn đã nhập số Điện Thoại Nhà không đúng với thực tế", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtDThoaiNha.Text = "";
                    this.txtDThoaiNha.Focus();
                    return false;
                }
                if (!Utility.IsNum(this.txtDThoaiNha.Text))
                {
                    MessageBoxEx.Show("Bạn đã nhập số Điện Thoại Nhà không đúng với thực tế", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtDThoaiNha.Text = "";
                    this.txtDThoaiNha.Focus();
                    return false;
                }
            }
            

            // Kiểm tra số Điện Thoại Di Động
            if (this.txtDThoaiDD.Text.Trim() != "")
            {
                if (this.txtDThoaiDD.Text.Trim().Length <10 || this.txtDThoaiDD.Text.Trim().Length >11)
                {
                    MessageBoxEx.Show("Bạn đã nhập số Điện Thoại Di Động không đúng với thực tế \n Phải 11 số ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtDThoaiDD.Text = "";
                    this.txtDThoaiDD.Focus();
                    return false;
                }
                if (!Utility.IsNum(this.txtDThoaiDD.Text))
                {
                    MessageBoxEx.Show("Bạn đã nhập số Điện Thoại Di Động không đúng với thực tế", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtDThoaiDD.Text = "";
                    this.txtDThoaiDD.Focus();
                    return false;
                }
            }
            
            
            // Kiểm Tra Tình Trạng Hôn Nhân
            if (this.cboTinhTrangHonNhan.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Bạn chưa chọn tình trạng Hôn nhân !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cboTinhTrangHonNhan.Focus();
                return false;
            }
            // Kiểm Tra Tình Trạng Sức Khỏe
            if (this.cboTinhTrangSucKhoe.Text.Trim() == "")
            {
                MessageBoxEx.Show("Bạn chưa chọn tình trạng Sức Khỏe !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cboTinhTrangSucKhoe.Focus();
                return false;
            }
            // Kiểm Tra Nhóm Máu
            if (this.cboNhomMau.Text.Trim() == "")
            {
                MessageBoxEx.Show("Bạn chưa chọn Nhóm Máu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cboNhomMau.Focus();
                return false;
            }

            // Kiểm Tra Chiều Cao
            if (this.txtChieuCao.Value < 50 || this.txtChieuCao.Value >250)
            {
                MessageBoxEx.Show("Bạn đã nhập Chiều Cao không đúng với thực tế. \n Chỉ nhập trong khoảng( 50 -> 250 )", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                this.txtChieuCao.Focus();
                return false;
            }

            // Kiểm Tra Chiều Cao
            if (this.txtCanNang.Value < 30 || this.txtCanNang.Value > 150)
            {
                MessageBoxEx.Show("Bạn đã nhập Cân Nặng không đúng với thực tế \n Chỉ trong khoảng( 30 -> 150 )", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.txtCanNang.Focus();
                return false;
            }

            // Kiểm Tra Hình Thức Đào Tạo
            if (this.cboHinhThucDaoTao.Text.Trim() == "")
            {
                MessageBoxEx.Show("Bạn chưa chọn Hình thức Đào Tạo !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                this.cboHinhThucDaoTao.Focus();
                return false;
            }
            // Kiểm tra số Năm Tốt Nghiệp
            //if (this.txtNamTotNghiep.Text.Trim() != "")
            //{
            //    if (this.txtNamTotNghiep.Text.Trim().Length != 4)
            //    {
            //        MessageBoxEx.Show("Bạn đã nhập Năm Tốt Nghiệp không đúng với thực tế", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        this.txtNamTotNghiep.Text = "";
            //        this.txtNamTotNghiep.Focus();
            //        return false;
            //    }
            //}
            string email = this.txtEmail.Text;
            return KiemTraEmail(email, this.txtEmail);

            //return true;
           
            

           
        }
        #endregion

        #region KiemTraEmail
        public bool KiemTraEmail(string email, TextBox textBoxXEmail)
        {
            if (email != "")
            {
                if ((!email.Contains("~")) && (!email.Contains("%")) && (!email.Contains("|")) && (!email.Contains(" ")) && (!email.Contains("^")) && (!email.Contains(":")) && (!email.Contains("`")) && (!email.Contains("&")) && (!email.Contains(";")) && (!email.Contains("!")) && (!email.Contains("*")) && (!email.Contains("\"")) && (!email.Contains("#")) && (!email.Contains("(")) && (!email.Contains("'")) && (!email.Contains("<")) && (!email.Contains(",")) && (!email.Contains(">")) && (!email.Contains("/")) && (!email.Contains("\\")) && (!email.Contains("+")) && (!email.Contains("-")) && (!email.Contains("$")) && (!email.Contains(")")) && (!email.Contains("?")) && (!email.Contains("=")) && (!email.Contains("{")) && (!email.Contains("}")) && (!email.Contains("[")) && (!email.Contains("]")))
                {
                    string[] array = email.Split('@');//Tách email bởi dấu @
                    if (array.Length > 1)
                    {
                        if (array.Length == 2)//Tách 2 mảng: mảng trước và sau dấu @
                        {
                            // Kiểm tra phần trước dấu @
                            try
                            {
                                int i = Convert.ToInt32(array[0].Substring(0, 1));
                                MessageBoxEx.Show("Nickname không được bắt đầu bằng số", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtEmail.Focus();
                                return false;
                            }
                            catch
                            {
                                // Kiểm tra phần sau dấu @
                                if (array[1].Length >= 5)
                                {
                                    if (array[1].Split('.').Length >= 2)
                                    {
                                        string[] subArrray = array[1].Split('.');
                                        foreach (string s in subArrray)
                                        {
                                            if (s.Length < 2)
                                            {
                                                MessageBoxEx.Show("Email không hợp lệ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                txtEmail.Focus();
                                                return false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBoxEx.Show("Email thiếu dấu chấm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        txtEmail.Focus();
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBoxEx.Show("Phần sau email phải có ít nhất 5 ký tự", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtEmail.Focus();
                                    return false;
                                }
                            }

                        }
                        else
                        {
                            MessageBoxEx.Show("Email không được chứa nhiều dấu @", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtEmail.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        MessageBoxEx.Show("Email không dấu @", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtEmail.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBoxEx.Show("Email không được chứa những ký tự đặc biệt", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtEmail.Focus();
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region ReadLoad_HoSoTuyenDung

        public void ReadLoad_HoSoTuyenDung()
        {


            #region HienThi Combobox

            ViTri_TuyenDungCtrl ctrlViTriTD = new ViTri_TuyenDungCtrl();
            ctrlViTriTD.HienThiComboBox(this.cboViTriTuyenDung);

            DanTocCtrl ctrlDanToc = new DanTocCtrl();
            ctrlDanToc.HienThiComboBox(this.cboDanToc);

            TonGiaoCtrl ctrlTonGiao = new TonGiaoCtrl();
            ctrlTonGiao.HienThiComboBox(this.cboTonGiao);

            QuocTichCtrl ctrlQuocTich = new QuocTichCtrl();
            ctrlQuocTich.HienThiComboBox(this.cboQuocTich);

            TrinhDo_HocVanCtrl ctrlHocVan = new TrinhDo_HocVanCtrl();
            ctrlHocVan.HienThiComboBox(this.cboHocVanPhoThong);

            TrinhDo_TinHocCtrl ctrlTinHoc = new TrinhDo_TinHocCtrl();
            ctrlTinHoc.HienThiComboBox(this.cboTrinhDoTinHoc);

            NgoaiNguCtrl ctrlNgoaiNgu = new NgoaiNguCtrl();
            ctrlNgoaiNgu.HienThiComboBox(this.cboNgoaiNguChinh);

            TrinhDo_NgoaiNguCtrl ctrlTDNgoaiNgu = new TrinhDo_NgoaiNguCtrl();
            ctrlTDNgoaiNgu.HienThiComboBox(this.cboTrinhDoNgoaiNgu);
            #endregion

            if (An_Hien == "Xem")
            {
                this.PhanQuyen_Xem_An();
            }
            else
            {
                this.PhanQuyen_Xem_Hien();
            }

            if (this.Open != "Open")
            {
                this.IsAddNew = false;

                this.txtMaHS.Text = HoSoSelected.MaHoSo;
                this.txtHoTen.Text = HoSoSelected.HoTen;
                this.txtBiDanh.Text = HoSoSelected.BiDanh;
                if (HoSoSelected.GioiTinh == 1)
                {
                    this.radNam.Checked = true;
                }
                else
                {
                    this.radNu.Checked = true;
                }
                this.dtNgaySinh.Value = HoSoSelected.NgaySinh;
                this.txtNoiSinh.Text = HoSoSelected.NoiSinh;
                this.txtCMND.Text = HoSoSelected.ChungMinh;
                this.dtNgayCapCMND.Value = HoSoSelected.NgayCapCMND;
                this.txtNoiCapCMND.Text = HoSoSelected.NoiCapCMND;
              

                this.txtQueQuan.Text = HoSoSelected.QueQuan;
                this.txtDChiThuongTru.Text = HoSoSelected.DC_ThuongTru;
                this.txtNoiOHienNay.Text = HoSoSelected.NoiOHienNay;
                this.txtDThoaiNha.Text = HoSoSelected.DienThoaiNha;
                this.txtDThoaiDD.Text = HoSoSelected.DienThoaiDiDong;
                this.txtEmail.Text = HoSoSelected.Email;
                this.cboTinhTrangHonNhan.Text = HoSoSelected.TinhTrangHonNhan;
                this.cboTinhTrangSucKhoe.Text = HoSoSelected.TinhTrangSucKhoe;
                this.cboNhomMau.Text = HoSoSelected.NhomMau;
                this.cboHinhThucDaoTao.Text = HoSoSelected.HinhThucDaoTao;
                this.txtCanNang.Text= Convert.ToString(HoSoSelected.CanNang);
                this.txtChieuCao.Text = Convert.ToString(HoSoSelected.ChieuCao);

                this.txtChucVuCD.Text = HoSoSelected.ChucVuCD;
                this.txtChucVuDang.Text = HoSoSelected.ChucVuDang;
                this.txtChucVuDoan.Text = HoSoSelected.ChucVuDoan;
                this.txtChuyenNganhDaoTao.Text = HoSoSelected.ChuyenNganhDaoTao;
                this.txtCoQuanTuyenDung.Text = HoSoSelected.CoQuanTuyenDung;
                this.txtDaTotNghiep.Text = HoSoSelected.DaTotNghiep;
                this.txtDienUuTienBanThan.Text = HoSoSelected.UuTienBanThan;
                this.txtDienUuTienGiaDinh.Text = HoSoSelected.UuTienGiaDinh;
                this.txtHinhThucTuyenDung.Text = HoSoSelected.HinhThucTuyenDung;
                this.txtKhuyetTat.Text = HoSoSelected.KhuyetTat;
                //this.txtNamTotNghiep.Text = HoSoSelected.NamTotNghiep;
                this.txtNangKhieu.Text = HoSoSelected.NangKhieu;
                this.txtNganhDaoTao.Text = HoSoSelected.NganhDaoTao;
                this.txtNgoaiNguKhac.Text = HoSoSelected.NgoaiNguKhac;
                this.txtNoiDaoTao.Text = HoSoSelected.NoiDaoTao;
                this.txtNoiVaoDang.Text = HoSoSelected.NoiVaoDang;
                this.txtNoiVaoDoan.Text = HoSoSelected.NoiVaoDoan;
                this.txtThanhPhanXuatThan.Text = HoSoSelected.ThanhPhanXuatThan;
                this.txtTrinhDoChuyenMonCaoNhat.Text = HoSoSelected.TD_ChuyenMonCaoNhat;
                this.txtTrinhDoLyLuanChinhTri.Text = HoSoSelected.TD_LyLuanChinhTri;
                this.txtTrinhDoQLNN.Text = HoSoSelected.TD_QuanLyNhaNuoc;
                this.txtTrinhDoQuanLyGiaoDuc.Text = HoSoSelected.TD_QuanLyGiaoDuc;
                this.txtTenCD.Text = HoSoSelected.TenCD;
                this.dtNgayCTVaoDang.Value = HoSoSelected.NgayCT_VaoDang;
                this.dtNgayTuyenDung.Value = HoSoSelected.NgayTuyenDung;
                this.dtNgayVaoCD.Value = HoSoSelected.NgayVaoCD;
                this.dtNgayVaoDang.Value = HoSoSelected.NgayVaoDang;
                this.dtNgayVaoDoan.Value = HoSoSelected.NgayVaoDoan;
                this.cboDanToc.Text = HoSoSelected.DanToc.TenDanToc;
                this.cboTonGiao.Text = HoSoSelected.TonGiao.TenTonGiao;
                this.cboQuocTich.Text = HoSoSelected.QuocTich.TenQuocTich;
                this.cboNgoaiNguChinh.Text = HoSoSelected.NgoaiNgu.TenNgoaiNgu;
                this.cboViTriTuyenDung.Text = HoSoSelected.ViTriTuyen.TenVTTD;
                this.cboTrinhDoNgoaiNgu.Text = HoSoSelected.TD_NgoaiNgu.TenTrinhDoNgoaiNgu;
                this.cboTrinhDoTinHoc.Text = HoSoSelected.TD_TinHoc.TenTrinhDoTinHoc;
                this.cboHocVanPhoThong.Text = HoSoSelected.HocVanPhoThong.TenHocVan;
                this.picHinhAnh.ImageLocation = HoSoSelected.HinhAnh;


              

                if (this.txtMaHS.Text == null)
                {
                    this.btXoaHSTuyenDung.Enabled = false;
                }
                else
                {
                    this.btXoaHSTuyenDung.Enabled = true;
                }


            }
            else
            {
             //   this.IsAddNew = true;
                this.txtHoTen.Focus();
            }
        }
        #endregion

        #region frm_HOSOTUYENDUNG_Load

        private void frm_HOSOTUYENDUNG_Load(object sender, EventArgs e)
        {
            this.ReadLoad_HoSoTuyenDung();

        }
        #endregion

        #region btThoatHoSoTuyenDung_Click

        private void btThoatHoSoTuyenDung_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region btThemMoi_Click


        private void btThemMoi_Click(object sender, EventArgs e)
        {
           
            {
                if (!this.IsAddNew)
                {
                   
                    this.txtMaHS.Text = null;
                    this.txtHoTen.Text = null;
                    this.txtBiDanh.Text = null;
                    this.radNam.Checked = true;
                    this.dtNgaySinh.Text = null;
                    this.txtNoiSinh.Text = null;
                    this.txtCMND.Text = null;
                    this.dtNgayCapCMND.Text = null;
                    this.txtNoiCapCMND.Text = null;
                    this.picHinhAnh.Tag = null;

                    this.cboDanToc.SelectedText = "";
                    this.cboTonGiao.SelectedText = "";
                    this.cboQuocTich.SelectedText = "";
                    this.cboNgoaiNguChinh.SelectedText = "";
                    this.cboTinhTrangHonNhan.Text = "Độc Thân";
                    this.cboTinhTrangSucKhoe.Text = "Tốt";
                    this.cboNhomMau.Text = "A";
                    this.cboHinhThucDaoTao.Text = "Chính Quy";
                    this.txtQueQuan.Text = null;
                    this.txtDChiThuongTru.Text = null;
                    this.txtNoiOHienNay.Text = null;
                    this.txtDThoaiNha.Text = null;
                    this.txtDThoaiNha.Text = null;
                    this.txtEmail.Text = null;
                    this.txtCanNang.Text = null;
                    this.txtChieuCao.Text = null;
                    this.txtChucVuCD.Text = null;
                    this.txtChucVuDang.Text = null;
                    this.txtChucVuDoan.Text = null;
                    this.txtChuyenNganhDaoTao.Text = null;
                    this.txtCoQuanTuyenDung.Text = null;
                    this.txtDaTotNghiep.Text = null;
                    this.txtDienUuTienBanThan.Text = null;
                    this.txtDienUuTienGiaDinh.Text = null;
                    this.txtHinhThucTuyenDung.Text = null;
                    this.txtKhuyetTat.Text = null;
                    //this.txtNamTotNghiep.Text = null;
                    this.txtNangKhieu.Text = null;
                    this.txtNganhDaoTao.Text = null;
                    this.txtNgoaiNguKhac.Text = null;
                    this.txtNoiDaoTao.Text = null;
                    this.txtNoiVaoDang.Text = null;
                    this.txtNoiVaoDoan.Text = null;
                    this.txtThanhPhanXuatThan.Text = null;
                    this.txtTrinhDoChuyenMonCaoNhat.Text = null;
                    this.txtTrinhDoLyLuanChinhTri.Text = null;
                    this.txtTrinhDoQLNN.Text = null;
                    this.txtTrinhDoQuanLyGiaoDuc.Text = null;
                    this.dtNgayCTVaoDang.Text = null;
                    this.dtNgayTuyenDung.Text = null;
                    this.dtNgayVaoCD.Text = null;
                    this.dtNgayVaoDang.Text = null;
                    this.dtNgayVaoDoan.Text = null;
                    this.txtCanNang.Text = null;
                    this.txtChieuCao.Text = null;

                    #region HienThiComboBox
                    ViTri_TuyenDungCtrl ctrlViTriTD = new ViTri_TuyenDungCtrl();
                    ctrlViTriTD.HienThiComboBox(this.cboViTriTuyenDung);

                    DanTocCtrl ctrlDanToc = new DanTocCtrl();
                    ctrlDanToc.HienThiComboBox(this.cboDanToc);

                    TonGiaoCtrl ctrlTonGiao = new TonGiaoCtrl();
                    ctrlTonGiao.HienThiComboBox(this.cboTonGiao);

                    QuocTichCtrl ctrlQuocTich = new QuocTichCtrl();
                    ctrlQuocTich.HienThiComboBox(this.cboQuocTich);

                    TrinhDo_HocVanCtrl ctrlHocVan = new TrinhDo_HocVanCtrl();
                    ctrlHocVan.HienThiComboBox(this.cboHocVanPhoThong);

                    TrinhDo_TinHocCtrl ctrlTinHoc = new TrinhDo_TinHocCtrl();
                    ctrlTinHoc.HienThiComboBox(this.cboTrinhDoTinHoc);

                    NgoaiNguCtrl ctrlNgoaiNgu = new NgoaiNguCtrl();
                    ctrlNgoaiNgu.HienThiComboBox(this.cboNgoaiNguChinh);

                    TrinhDo_NgoaiNguCtrl ctrlTDNgoaiNgu = new TrinhDo_NgoaiNguCtrl();
                    ctrlTDNgoaiNgu.HienThiComboBox(this.cboTrinhDoNgoaiNgu);
                    #endregion

                    this.IsAddNew = true;
                }
                if (ctrlHoSoTuyenDung == null)
                    ctrlHoSoTuyenDung = new HoSoTuyenDungCtrl();
                ctrlHoSoTuyenDung.Create(txtMaHS);
                this.txtHoTen.Focus();
            }
        }
        #endregion

        #region btLuuHoSoTuyenDung_Click
        
       
        private void btLuuHoSoTuyenDung_Click(object sender, EventArgs e)
        {
            
            if (this.CheckValid())
            {
                HoSoTuyenDungInfo info = new HoSoTuyenDungInfo();
                try
                {
                    
                    info.MaHoSo = this.txtMaHS.Text;
                    info.BiDanh = this.txtBiDanh.Text;
                                
                    info.ChungMinh = this.txtCMND.Text;
                    info.HoTen = this.txtHoTen.Text;
                    if (this.radNam.Checked == true)
                    {
                        info.GioiTinh = int.Parse("1");
                    }
                    else
                    {
                        info.GioiTinh = int.Parse("0");
                    }
                    info.NgayCapCMND = this.dtNgayCapCMND.Value;
                    info.NgaySinh = this.dtNgaySinh.Value;
                    info.NoiCapCMND = this.txtNoiCapCMND.Text;
                    info.NoiSinh = this.txtNoiSinh.Text;



                    /////////////////////////////////


                    string tenhinh;


                    tenhinh = txtMaHS.Text.ToString();
                    if (picHinhAnh.Image == null)
                    {
                        info.HinhAnh = null;

                    }
                    else
                    {
                        picHinhAnh.Image.Save(Application.StartupPath + "/image/" + tenhinh + ".jpg");
                        info.HinhAnh = "image/" + tenhinh + ".jpg";
                    }




                    //////////////////////////////////////
                    info.QueQuan = this.txtQueQuan.Text;
                    info.DC_ThuongTru = this.txtDChiThuongTru.Text;
                    info.NoiOHienNay = this.txtNoiOHienNay.Text;
                    info.DienThoaiNha = this.txtDThoaiNha.Text;
                    info.DienThoaiDiDong = this.txtDThoaiDD.Text;
                    info.Email = this.txtEmail.Text;

                    info.ChucVuCD = this.txtChucVuCD.Text;
                    info.ChucVuDang = this.txtChucVuDang.Text;
                    info.ChucVuDoan = this.txtChucVuDoan.Text;
                    info.ChuyenNganhDaoTao = this.txtChuyenNganhDaoTao.Text;
                    info.CoQuanTuyenDung = this.txtCoQuanTuyenDung.Text;
                    info.DaTotNghiep = this.txtDaTotNghiep.Text;                
                 
                    
                    info.HinhThucTuyenDung = this.txtHinhThucTuyenDung.Text;                    

                    info.KhuyetTat = this.txtKhuyetTat.Text;
                    //info.NamTotNghiep = this.txtNamTotNghiep.Text;
                    info.NangKhieu = this.txtNangKhieu.Text;
                    info.NganhDaoTao = this.txtNganhDaoTao.Text;

                    ///////////////////


                    info.NgayCT_VaoDang = this.dtNgayCTVaoDang.Value;

                    info.NgayTuyenDung = this.dtNgayTuyenDung.Value;
                    info.NgayVaoCD = this.dtNgayVaoCD.Value;
                    info.NgayVaoDang = this.dtNgayVaoDang.Value;
                    info.NgayVaoDoan = this.dtNgayVaoDoan.Value;
                  


                    /////////////
                    info.NgoaiNguKhac = this.txtNgoaiNguKhac.Text;
                    

                    info.NoiDaoTao = this.txtNoiDaoTao.Text;
                    info.NoiOHienNay = this.txtNoiOHienNay.Text;

                    info.NoiVaoDang = this.txtNoiVaoDang.Text;
                    info.NoiVaoDoan = this.txtNoiVaoDoan.Text;


                   
                    info.TD_ChuyenMonCaoNhat = this.txtTrinhDoChuyenMonCaoNhat.Text;
                    info.TD_LyLuanChinhTri = this.txtTrinhDoLyLuanChinhTri.Text;
                  
                    info.TD_QuanLyGiaoDuc = this.txtTrinhDoQuanLyGiaoDuc.Text;
                    info.TD_QuanLyNhaNuoc = this.txtTrinhDoQLNN.Text;
                    
                    info.TenCD = this.txtTenCD.Text;
                    info.ThanhPhanXuatThan = this.txtThanhPhanXuatThan.Text;
                    info.TinhTrangHonNhan = this.cboTinhTrangHonNhan.SelectedItem.ToString();
                    info.TinhTrangSucKhoe = this.cboTinhTrangSucKhoe.SelectedItem.ToString();
                    info.NhomMau = this.cboNhomMau.SelectedItem.ToString();
                    info.HinhThucDaoTao = this.cboHinhThucDaoTao.SelectedItem.ToString();


                    info.UuTienBanThan = this.txtDienUuTienBanThan.Text;
                    info.UuTienGiaDinh = this.txtDienUuTienGiaDinh.Text;
                    
                    

                   
                    DanTocCtrl ctrDT = new DanTocCtrl();
                    info.DanToc = ctrDT.GetDanToc(this.cboDanToc.SelectedValue.ToString());


                    TonGiaoCtrl ctrTG = new TonGiaoCtrl();
                    info.TonGiao = ctrTG.GetTonGiao(this.cboTonGiao.SelectedValue.ToString());


                    QuocTichCtrl ctrQT = new QuocTichCtrl();
                    info.QuocTich = ctrQT.GetQuocTich(this.cboQuocTich.SelectedValue.ToString());

                    NgoaiNguCtrl ctrlNN = new NgoaiNguCtrl();
                    info.NgoaiNgu = ctrlNN.GetNgoaiNgu(this.cboNgoaiNguChinh.SelectedValue.ToString());

                    TrinhDo_NgoaiNguCtrl ctrl_TDNgoaiNgu = new TrinhDo_NgoaiNguCtrl();
                    info.TD_NgoaiNgu = ctrl_TDNgoaiNgu.GetTrinhDoNgoaiNgu(this.cboTrinhDoNgoaiNgu.SelectedValue.ToString());

                    TrinhDo_TinHocCtrl ctrl_TDTinHoc = new TrinhDo_TinHocCtrl();
                    info.TD_TinHoc = ctrl_TDTinHoc.GetTrinhDoTinHoc(this.cboTrinhDoTinHoc.SelectedValue.ToString());

                    TrinhDo_HocVanCtrl ctrl_TDHocVan = new TrinhDo_HocVanCtrl();
                    info.HocVanPhoThong = ctrl_TDHocVan.GetTrinhDoHocVan(this.cboHocVanPhoThong.SelectedValue.ToString());


                    ViTri_TuyenDungCtrl ctrlViTriTuyenDung = new ViTri_TuyenDungCtrl();
                    info.ViTriTuyen = ctrlViTriTuyenDung.GetViTriTuyen(this.cboViTriTuyenDung.SelectedValue.ToString());

                    
                    info.Status = int.Parse("0"); //Neu la 1: Ung cu vien 0: Ho so tuyen dung
                    info.CanNang = Convert.ToDecimal(this.txtCanNang.Text);
                    info.ChieuCao = Convert.ToDecimal(this.txtChieuCao.Text);
                }
                catch { }

                if (IsAddNew)
                {
                    if (ctrlHoSoTuyenDung == null)
                        ctrlHoSoTuyenDung = new HoSoTuyenDungCtrl();
                    if (ctrlHoSoTuyenDung.Add(info))
                    {
                        this.IsAddNew = false;
                        MessageBoxEx.Show("Một Hồ Sơ Được Thêm Mới!", "Thêm thành công");
                    }
                }
                else
                {
                    if (MessageBoxEx.Show("Bạn có muốn cập nhật thông tin nhân viên này không?", "Cập Nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (ctrlHoSoTuyenDung == null)
                            ctrlHoSoTuyenDung = new HoSoTuyenDungCtrl();
                        ctrlHoSoTuyenDung.Update(info, SelectedIndex);
                    }
                   
                }
            }
        }
        #endregion

        #region linkChenHinh_LinkClicked        
        
        private void linkChenHinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Title = "Chon mot hinh anh";
            openDlg.RestoreDirectory = true;
            openDlg.Filter = "All images (*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png";
            openDlg.Multiselect = false;
            if (openDlg.ShowDialog() == DialogResult.OK)
            {              

                picHinhAnh.Image = Image.FromFile(openDlg.FileName);
               
            }
        }
        #endregion

        #region linkXoaHinh_LinkClicked        
       
        private void linkXoaHinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            picHinhAnh.Image = null;
        }
        #endregion

        #region btXoaHSTuyenDung_Click

        private void btXoaHSTuyenDung_Click(object sender, EventArgs e)
        {
            if (!IsAddNew)
            {
                if (MessageBoxEx.Show("Bạn có chắc là xóa thông tin nhân viên này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (ctrlHoSoTuyenDung == null)
                        ctrlHoSoTuyenDung = new HoSoTuyenDungCtrl();
                    ctrlHoSoTuyenDung.DeleteList(this.txtMaHS.Text);
                    this.Close();
                }
            }
            else
            {
                MessageBoxEx.Show("Không hợp lệ !","Thông Báo");
            }
        }
        #endregion

        #region btBoQua_Click        
       
        private void btBoQua_Click(object sender, EventArgs e)
        {
            this.txtMaHS.Text = null;
            this.txtHoTen.Text = null;
            this.txtBiDanh.Text = null;
            this.dtNgaySinh.Text = null;
            this.txtNoiSinh.Text = null;
            this.txtCMND.Text = null;
            this.dtNgayCapCMND.Text = null;
            this.txtNoiCapCMND.Text = null;
            this.picHinhAnh.Tag = null;

            this.cboDanToc.SelectedText = "";
            this.cboTonGiao.SelectedText = "";
            this.cboQuocTich.SelectedText = "";
            this.cboNgoaiNguChinh.SelectedText = "";
            this.txtQueQuan.Text = null;
            this.txtDChiThuongTru.Text = null;
            this.txtNoiOHienNay.Text = null;
            this.txtDThoaiNha.Text = null;
            this.txtDThoaiNha.Text = null;
            this.txtEmail.Text = null;
            this.txtCanNang.Text = null;
            this.txtChieuCao.Text = null;
            this.txtChucVuCD.Text = null;
            this.txtChucVuDang.Text = null;
            this.txtChucVuDoan.Text = null;
            this.txtChuyenNganhDaoTao.Text = null;
            this.txtCoQuanTuyenDung.Text = null;
            this.txtDaTotNghiep.Text = null;
            this.txtDienUuTienBanThan.Text = null;
            this.txtDienUuTienGiaDinh.Text = null;
            this.txtHinhThucTuyenDung.Text = null;
            this.txtKhuyetTat.Text = null;
           // this.txtNamTotNghiep.Text = null;
            this.txtNangKhieu.Text = null;
            this.txtNganhDaoTao.Text = null;
            this.txtNgoaiNguKhac.Text = null;
            this.txtNoiDaoTao.Text = null;
            this.txtNoiVaoDang.Text = null;
            this.txtNoiVaoDoan.Text = null;
            this.txtThanhPhanXuatThan.Text = null;
            this.txtTrinhDoChuyenMonCaoNhat.Text = null;
            this.txtTrinhDoLyLuanChinhTri.Text = null;
            this.txtTrinhDoQLNN.Text = null;
            this.txtTrinhDoQuanLyGiaoDuc.Text = null;
            this.dtNgayCTVaoDang.Text = null;
            this.dtNgayTuyenDung.Text = null;
            this.dtNgayVaoCD.Text = null;
            this.dtNgayVaoDang.Text = null;
            this.dtNgayVaoDoan.Text = null;

            if (this.IsAddNew)
                this.IsAddNew = false;
        }
        #endregion

        #region btDanToc_Click       
       
        private void btDanToc_Click(object sender, EventArgs e)
        {
            DanTocCtrl dantoc = new DanTocCtrl();
            TT_GDTX_ANGIANG.frm_DANTOC qh = new TT_GDTX_ANGIANG.frm_DANTOC();

            qh.ShowDialog();
            Graphics f = this.CreateGraphics();
            dantoc.HienThiComboBox(cboDanToc);

            if (qh.Index > -1)
                cboDanToc.SelectedIndex = qh.Index;
        }
        #endregion

        #region btTonGiao_Click        
       
        private void btTonGiao_Click(object sender, EventArgs e)
        {
            TonGiaoCtrl tongiao = new TonGiaoCtrl();
            TT_GDTX_ANGIANG.frm_TONGIAO qh = new TT_GDTX_ANGIANG.frm_TONGIAO();

            qh.ShowDialog();
            Graphics f = this.CreateGraphics();
            tongiao.HienThiComboBox(cboTonGiao);

            if (qh.Index > -1)
                cboTonGiao.SelectedIndex = qh.Index;
        }
        #endregion

        #region btQuocTich_Click      
       

        private void btQuocTich_Click(object sender, EventArgs e)
        {
            QuocTichCtrl quoctich = new QuocTichCtrl();
            TT_GDTX_ANGIANG.frm_QUOCTICH qh = new TT_GDTX_ANGIANG.frm_QUOCTICH();

            qh.ShowDialog();
            Graphics f = this.CreateGraphics();
            quoctich.HienThiComboBox(cboQuocTich);

            if (qh.Index > -1)
                cboQuocTich.SelectedIndex = qh.Index;
        }
        #endregion       

        #region btViTriTuyenDung_Click        
        
        private void btViTriTuyenDung_Click(object sender, EventArgs e)
        {
            ViTri_TuyenDungCtrl vitrituyen = new ViTri_TuyenDungCtrl();
            TT_GDTX_ANGIANG.frm_VITRITUYENDUNG qh = new TT_GDTX_ANGIANG.frm_VITRITUYENDUNG();

            qh.ShowDialog();
            Graphics f = this.CreateGraphics();
            vitrituyen.HienThiComboBox(cboViTriTuyenDung);

            if (qh.Index > -1)
                cboViTriTuyenDung.SelectedIndex = qh.Index;
        }
        #endregion

        #region btTrinhDoHocVan_Click        
       
        private void btTrinhDoHocVan_Click(object sender, EventArgs e)
        {
            TrinhDo_HocVanCtrl TD_hocvan = new TrinhDo_HocVanCtrl();
            TT_GDTX_ANGIANG.frm_TRINHDOHOCVAN qh = new TT_GDTX_ANGIANG.frm_TRINHDOHOCVAN();
            qh.ShowDialog();
            Graphics f = this.CreateGraphics();
            TD_hocvan.HienThiComboBox(cboHocVanPhoThong);

            if (qh.Index > -1)
                cboHocVanPhoThong.SelectedIndex = qh.Index;
        }
        #endregion

        #region btNgoaiNgu_Click        
       
        private void btNgoaiNgu_Click(object sender, EventArgs e)
        {
            NgoaiNguCtrl ngoaingu = new NgoaiNguCtrl();
            TT_GDTX_ANGIANG.frm_NGOAINGU qh = new TT_GDTX_ANGIANG.frm_NGOAINGU();
            qh.ShowDialog();
            Graphics f = this.CreateGraphics();
            ngoaingu.HienThiComboBox(cboNgoaiNguChinh);

            if (qh.Index > -1)
                cboNgoaiNguChinh.SelectedIndex = qh.Index;
        }
        #endregion

        #region btTrinhDoNgoaiNgu_Click        
       
        private void btTrinhDoNgoaiNgu_Click(object sender, EventArgs e)
        {
            TrinhDo_NgoaiNguCtrl TD_ngoaingu = new TrinhDo_NgoaiNguCtrl();
            TT_GDTX_ANGIANG.frm_TRINHDO_NGOAINGU qh = new TT_GDTX_ANGIANG.frm_TRINHDO_NGOAINGU();

            qh.ShowDialog();
            Graphics f = this.CreateGraphics();
            TD_ngoaingu.HienThiComboBox(cboTrinhDoNgoaiNgu);

            if (qh.Index > -1)
                cboTrinhDoNgoaiNgu.SelectedIndex = qh.Index;
        }
        #endregion

        #region btTrinhDoTinHoc_Click       
       

        private void btTrinhDoTinHoc_Click(object sender, EventArgs e)
        {
            TrinhDo_TinHocCtrl TD_tinhoc = new TrinhDo_TinHocCtrl();
            TT_GDTX_ANGIANG.frm_TRINHDOTINHOC qh = new TT_GDTX_ANGIANG.frm_TRINHDOTINHOC();

            qh.ShowDialog();
            Graphics f = this.CreateGraphics();
            TD_tinhoc.HienThiComboBox(cboTrinhDoTinHoc);

            if (qh.Index > -1)
                cboTrinhDoTinHoc.SelectedIndex = qh.Index;
        }
        #endregion
    }
        
        
}
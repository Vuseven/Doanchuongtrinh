using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Rendering;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Windows.Forms;
using TT_GDTX_ANGIANG.DataLayer;
using TT_GDTX_ANGIANG.BusinessObject;
using TT_GDTX_ANGIANG.Controller;

namespace TT_GDTX_ANGIANG
{
    public partial class frm_MAIN : DevComponents.DotNetBar.Office2007Form
    {
        public frm_MAIN()
        {
            InitializeComponent();
        }

        #region KhoiTao        

        frm_LIST_HOSOTUYENDUNG list_HoSo_TuyenDung = null;
       
      
        frm_DANGNHAP DangNhap = null;
        frm_LIST_NHANVIEN list_nhanvien = null;
        PhongBanInfo info_PB = new PhongBanInfo();
        BoPhanInfo info_BP = new BoPhanInfo();
        #endregion

        #region Property
        private String m_MADV;
        public String Lay_MaDonVi
        {
            get { return m_MADV; }
            set { m_MADV = value; }
        }
        private String m_Ten;
        public String Lay_Ten
        {
            get { return m_Ten; }
            set { m_Ten = value; }
        }
        private String m_NguoiDung;
        public String NguoiDung
        {
            get { return m_NguoiDung; }
            set { m_NguoiDung = value; }
        }
        private String m_User;
        public String Lay_UserName
        {
            get { return m_User; }
            set { m_User = value; }
        }
        private string m_AnHien;
        public string AnHien
        {
            get { return m_AnHien; }
            set { m_AnHien = value; }
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            DialogResult result = MessageBoxEx.Show("Bạn có muốn thoát khỏi hệ thống không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
        }
        #region frmMain_Load        
       
        private void frmMain_Load(object sender, EventArgs e)
        {
            frm_CSDL dulieu = new frm_CSDL();
            DataService dt = new DataService();
            
            ShowTreeView(treeViewHethong);
            Default();
            this.toolHienThi.Text = "Xin chào các bạn.";
            this.tool_Version.Text = "Version: 1.0";
            //this.toolSoft.Text = "Chương trình Quản lý nhân sự - Tiền lương TT GDTX An Giang.";
            this.toolNgay.Text = DateTime.Now.ToString();
            Init_ToolTip();
        }
        #endregion

        #region Hien thi TreeView
        public void ShowTreeView(TreeView treeViewHethong)
        {
            PhongBanData data_PhongBan = new PhongBanData();
            BoPhanData data_BoPhan = new BoPhanData();

            DataTable dtPhongBan = data_PhongBan.lay_dsPhongBan();
            DataTable dtBoPhan = data_BoPhan.lay_dsBoPhan();

            for (int i = 0; i < dtPhongBan.Rows.Count; i++)
            {
                treeViewHethong.Nodes[0].Nodes[1].Nodes.Add(dtPhongBan.Rows[i][1].ToString());
                treeViewHethong.Nodes[0].Nodes[1].Nodes[i].Tag = dtPhongBan.Rows[i]["MAPB"].ToString();
                treeViewHethong.Nodes[0].Nodes[1].Nodes[i].ImageIndex = 3;

                
            }
        }
        #endregion

        #region treeViewHeThong_NodeMouseClick       
       

        private void treeViewHeThong_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node == treeViewHethong.Nodes[0])
                {
                    e.Node.Toggle();

                    if (e.Node == treeViewHethong.Nodes[0].Nodes[0])
                    {
                        e.Node.Toggle();

                        if (e.Node == treeViewHethong.Nodes[0].Nodes[1])
                        {
                            e.Node.Toggle();

                            if (e.Node == treeViewHethong.Nodes[0].Nodes[1])
                            {
                                e.Node.Toggle();
                            }                           
                        }                         
                    }
                   
                }
                string temp = e.Node.Name;
               
                
                if (temp.Equals("NodeQLTD"))
                {
                    e.Node.Toggle();
                }
                if (temp.Equals("NodeHSTD"))
                {
                    if (list_HoSo_TuyenDung == null || list_HoSo_TuyenDung.IsDisposed)
                    {
                        list_HoSo_TuyenDung = new frm_LIST_HOSOTUYENDUNG();
                        list_HoSo_TuyenDung.MdiParent = this;
                        list_HoSo_TuyenDung.WindowState = FormWindowState.Maximized;
                        list_HoSo_TuyenDung.An_Hien = this.AnHien;
                        list_HoSo_TuyenDung.Show();
                    }
                    else
                    {
                        list_HoSo_TuyenDung.Activate();
                        list_HoSo_TuyenDung.ReLoad();
                    }
                }
                
                if (temp.Equals("NodeQLNS"))
                {
                    e.Node.Toggle();
                }
                if (e.Node.Text.ToString().Trim().Length != 0)
                {
                    info_PB.MaPhong = e.Node.Tag.ToString().Trim();
                    info_PB.TenPhong = e.Node.Text;
                    this.Lay_Ten = info_PB.TenPhong;
                    HienThi_NhanVien();
                }
               
               
                

            }
            catch (Exception) { }
        }
        #endregion

        #region HienThi_NhanVien()
        public void HienThi_NhanVien()
        {
            if (list_nhanvien == null || list_nhanvien.IsDisposed)
            {
                list_nhanvien = new frm_LIST_NHANVIEN();
                list_nhanvien.MdiParent = this;
                list_nhanvien.WindowState = FormWindowState.Maximized;

                list_nhanvien.Tag = info_PB.MaPhong;
                list_nhanvien.Lay_Ten = this.Lay_Ten;
                list_nhanvien.An_Hien = this.AnHien;
                list_nhanvien.Show();
            }
            else
            {
                list_nhanvien.Tag = info_PB.MaPhong;
                list_nhanvien.Lay_Ten = this.Lay_Ten;
                list_nhanvien.LoadForm();
            }
        }
        #endregion                   
                
        ///////////////////// Cài đặt Init_ToolTip///////////////////////////// 

        #region Init_ToolTip

        private void Init_ToolTip()
        {
            superTooltip1.SetSuperTooltip(this.buttonItemTopTiepNhanNhanVien, new DevComponents.DotNetBar.SuperTooltipInfo("Tiếp Nhận Nhân Viên Mới", "Mô tả: Thực hiện các chức năng thêm, xóa, sửa thông tin Nhân Viên.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopHoSoNhanVien, new DevComponents.DotNetBar.SuperTooltipInfo("Hồ sơ Nhân Viên", "Mô tả: Cho Biết lý lịch trích ngang của Nhân Viên.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopDanhSachPhongBan, new DevComponents.DotNetBar.SuperTooltipInfo("Danh Sách Phòng Ban", "Mô tả: Thực hiện các chức năng thêm, xóa, sửa Danh Sách Phòng Ban.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopDanhSachDanhMuc, new DevComponents.DotNetBar.SuperTooltipInfo("Danh Sách Danh Mục", "Mô tả: Tập trung tất cả các thông tin về danh mục dùng chung \n Hãy nhấn nút chỉ xuống.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopDanToc, new DevComponents.DotNetBar.SuperTooltipInfo("Dân Tộc", "Mô tả: Thực hiện các chức năng thêm, xóa, sửa thông tin Dân Tộc.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopTonGiao, new DevComponents.DotNetBar.SuperTooltipInfo("Tôn Giáo", "Mô tả: Thực hiện các chức năng thêm, xóa, sửa thông tin Tôn Giáo.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopQuocTich, new DevComponents.DotNetBar.SuperTooltipInfo("Quốc Tịch", "Mô tả: Thực hiện các chức năng thêm, xóa, sửa thông tin Quốc Tịch.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopNgoaiNgu, new DevComponents.DotNetBar.SuperTooltipInfo("Ngoại Ngữ", "Mô tả: Thực hiện các chức năng thêm, xóa, sửa thông tin Ngoại Ngữ.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopTrinhDoNgoaiNgu, new DevComponents.DotNetBar.SuperTooltipInfo("Trình Độ Ngoại Ngữ", "Mô tả: Thực hiện các chức năng thêm, xóa, sửa thông tin Trình Độ Ngoại Ngữ.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopTrinhDoHocVan, new DevComponents.DotNetBar.SuperTooltipInfo("Trình Độ Học Vấn", "Mô tả: Thực hiện các chức năng thêm, xóa, sửa thông tin Trình Độ Học Vấn.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopTrinhDoTinHoc, new DevComponents.DotNetBar.SuperTooltipInfo("Trình Độ Tin Học", "Mô tả: Thực hiện các chức năng thêm, xóa, sửa thông tin Trình Độ Tin Học.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopChucVu, new DevComponents.DotNetBar.SuperTooltipInfo("Chức Vụ", "Mô tả: Thực hiện các chức năng thêm, xóa, sửa thông tin Chức Vụ.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopViTriTuyenDung, new DevComponents.DotNetBar.SuperTooltipInfo("Vị Trí Tuyển Dụng", "Mô tả: Thực hiện các chức năng thêm, xóa, sửa thông tin Vị Trí Tuyển Dụng.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopBangLuongNhanVien, new DevComponents.DotNetBar.SuperTooltipInfo("Bảng Lương Nhân Viên", "Mô tả: Cho biết thông tin về lương của tất cả các Nhân Viên trong Trung Tâm.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopNgach, new DevComponents.DotNetBar.SuperTooltipInfo("Ngạch Lương", "Mô tả: Thực hiện các chức năng thêm, xóa, sửa thông tin Ngạch Lương.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopBac, new DevComponents.DotNetBar.SuperTooltipInfo("Bậc Lương", "Mô tả: Thực hiện các chức năng thêm, xóa, sửa thông tin Bậc Lương.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopHeSoLuong, new DevComponents.DotNetBar.SuperTooltipInfo("Hệ Số Lương Nhân Viên", "Mô tả: Thực hiện các chức năng thêm, xóa, sửa thông tin Hệ Số Lương Của Nhân Viên.", null, null, null, eTooltipColor.Blue));

            superTooltip1.SetSuperTooltip(this.buttonItemTopSaoLuuDuLieu, new DevComponents.DotNetBar.SuperTooltipInfo("Sao Lưu Dữ Liệu", "Mô tả: Thực hiện các chức năng Sao lưu dữ liệu tránh tình trạng mất dữ liệu trong hệ thống.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopPhucHoiDuLieu, new DevComponents.DotNetBar.SuperTooltipInfo("Phục Hồi Dữ Liệu", "Mô tả: Thực hiện các chức năng Phục hồi lại những dữ liệu đã được sao lưu.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopDangNhap, new DevComponents.DotNetBar.SuperTooltipInfo("Đăng Nhập", "Mô tả: Bạn Đăng Nhập vào hệ thống với tên đăng nhập và mật khẩu mà bạn được cấp.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopChuyenSangTaiKhoanKhac, new DevComponents.DotNetBar.SuperTooltipInfo("Chuyển Sang Tài Khoản Khác", "Mô tả: Bạn có thể chuyển sang tài khoản khác với chức năng khác nhau. \n         Tùy theo quyền hạn của bạn đối với hệ thống như thế nào.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopDoiMatKhau, new DevComponents.DotNetBar.SuperTooltipInfo("Đổi Mật Khẩu", "Mô tả: Để trách tình trạng mật khẩu của bạn bị người khác biết \n       Bạn có thể thay đổi mật khẩu với chức năng này.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopPhanQuyenNguoiDung, new DevComponents.DotNetBar.SuperTooltipInfo("Phân Quyền Người Dùng", "Mô tả: Chỉ có những người quản trị hệ thống mới có thể thực hiện chức năng này.", null, null, null, eTooltipColor.Blue));
            superTooltip1.SetSuperTooltip(this.buttonItemTopThongTinTrungTam, new DevComponents.DotNetBar.SuperTooltipInfo("Thông Tin Trung Tâm Giáo Dục Trường Xuyên", "Mô tả: Các Thông Tin Cơ Bản Về Trung Tâm Giáo Dục Thường Xuyên.", null, null, null, eTooltipColor.Blue));

        }
        #endregion




        /////////////////////////////////////////

          

      
       /// ////////////    MỚI  NHẤT NGÀY 20/3/2009    ///////////////////////////////////
     

        #region Doi mau       
       

        private void ApplicationTheme_Executed(object sender, EventArgs e)
        {
            ICommandSource source = sender as ICommandSource;
            if (source.CommandParameter is string)
            {
                eOffice2007ColorScheme colorScheme = (eOffice2007ColorScheme)Enum.Parse(typeof(eOffice2007ColorScheme), source.CommandParameter.ToString());
                // This is all that is needed to change the color table for all controls on the form
                ribbonControl1.Office2007ColorTable = colorScheme;
            }
            else if (source.CommandParameter is Color)
            {
                RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, m_BaseColorScheme, (Color)source.CommandParameter);
            }
            this.Invalidate();
        }

        #region Automatic Color Scheme creation based on the selected color table

        private bool m_ColorSelected = false;
        private eOffice2007ColorScheme m_BaseColorScheme = eOffice2007ColorScheme.Blue;
        private void buttonStyleCustom_ExpandChange(object sender, System.EventArgs e)
        {
            if (colorPickerDropDown1.Expanded)
            {
                // Remember the starting color scheme to apply if no color is selected during live-preview
                m_ColorSelected = false;
                m_BaseColorScheme = ((Office2007Renderer)GlobalManager.Renderer).ColorTable.InitialColorScheme;
            }
            else
            {
                if (!m_ColorSelected)
                {
                    ribbonControl1.Office2007ColorTable = m_BaseColorScheme;
                }
            }
        }

        private void colorPickerDropDown1_ColorPreview(object sender, DevComponents.DotNetBar.ColorPreviewEventArgs e)
        {
            
            RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(this, m_BaseColorScheme, e.Color);
        }

        private void colorPickerDropDown1_SelectedColorChanged(object sender, EventArgs e)
        {
            m_ColorSelected = true; // Indicate that color was selected for buttonStyleCustom_ExpandChange method
            colorPickerDropDown1.CommandParameter = colorPickerDropDown1.SelectedColor;
        }

        #endregion 

       
        #endregion




        /// <summary>
        /// PANEL TRÁI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region buttonItemLeftTrinhDoHocVan_Click       
       

        private void buttonItemLeftTrinhDoHocVan_Click(object sender, EventArgs e)
        {
            frm_TRINHDOHOCVAN trinhdo_HocVan = new frm_TRINHDOHOCVAN();
            trinhdo_HocVan.An_Hien = this.AnHien;
            trinhdo_HocVan.Show();
        }
        #endregion

        #region buttonItemLeftTrinhDoTinHoc_Click      
        

        private void buttonItemLeftTrinhDoTinHoc_Click(object sender, EventArgs e)
        {
            frm_TRINHDOTINHOC trinhdo_TinHoc = new frm_TRINHDOTINHOC();
            trinhdo_TinHoc.An_Hien = this.AnHien;
            trinhdo_TinHoc.Show();
        }
        #endregion


        #region buttonItemLeftTrinhDoNgoaiNgu_Click       
       
        private void buttonItemLeftTrinhDoNgoaiNgu_Click(object sender, EventArgs e)
        {
            frm_TRINHDO_NGOAINGU trinhdo_NgoaiNgu = new frm_TRINHDO_NGOAINGU();
            trinhdo_NgoaiNgu.An_Hien = this.AnHien;
            trinhdo_NgoaiNgu.Show();
        }
        #endregion


        #region buttonItemLeftNgoaiNgu_Click        
       
        private void buttonItemLeftNgoaiNgu_Click(object sender, EventArgs e)
        {
            frm_NGOAINGU ngoaingu = new frm_NGOAINGU();
            ngoaingu.An_Hien = this.AnHien;
            ngoaingu.Show();
        }
        #endregion

        #region buttonItemLeftHSLuongNV_Click        
      
        private void buttonItemLeftHSLuongNV_Click(object sender, EventArgs e)
        {
            frm_HESOLUONGNHANVIEN hesoluong_NhanVien = new frm_HESOLUONGNHANVIEN();
            hesoluong_NhanVien.An_Hien = this.AnHien;
            hesoluong_NhanVien.Show();
        }
        #endregion

        #region buttonItemLeftBacLuong_Click        
       
        private void buttonItemLeftBacLuong_Click(object sender, EventArgs e)
        {
            frm_BAC bacluong = new frm_BAC();
            bacluong.An_Hien = this.AnHien;
            bacluong.Show();
        }
        #endregion

        #region buttonItemLeftNgach_Click        
       
        private void buttonItemLeftNgach_Click(object sender, EventArgs e)
        {
            frm_NGACH ngach = new frm_NGACH();
            ngach.An_Hien = this.AnHien;
            ngach.Show();
        }
        #endregion

        #region buttonItemLeftViTriTuyenDung_Click        
      
        private void buttonItemLeftViTriTuyenDung_Click(object sender, EventArgs e)
        {
            frm_VITRITUYENDUNG vitrituyen = new frm_VITRITUYENDUNG();
            vitrituyen.An_Hien = this.AnHien;
            vitrituyen.Show();
        }
        #endregion

        #region buttonItemLeftChucVu_Click        
       
        private void buttonItemLeftChucVu_Click(object sender, EventArgs e)
        {
            frm_CHUCVU chucvu = new frm_CHUCVU();
            chucvu.An_Hien = this.AnHien;
            chucvu.Show();
        }
        #endregion

        #region buttonItemLeftQuocTich_Click        
       
        private void buttonItemLeftQuocTich_Click(object sender, EventArgs e)
        {
            frm_QUOCTICH quoctich = new frm_QUOCTICH();
            quoctich.An_Hien = this.AnHien;
            quoctich.Show();
        }
        #endregion

        #region buttonItemLeftTonGiao_Click        
       
        private void buttonItemLeftTonGiao_Click(object sender, EventArgs e)
        {

            frm_TONGIAO tongiao = new frm_TONGIAO();
            tongiao.An_Hien = this.AnHien;
            tongiao.Show();
        }
        #endregion

        #region buttonItemLeftDanToc_Click        
       
        private void buttonItemLeftDanToc_Click(object sender, EventArgs e)
        {
            frm_DANTOC dantoc = new frm_DANTOC();
            dantoc.An_Hien = this.AnHien;
            dantoc.Show();
        }
        #endregion

        #region buttonItemLeftBoPhan_Click        
       
        private void buttonItemLeftBoPhan_Click(object sender, EventArgs e)
        {
            frm_BOPHAN bophan = new frm_BOPHAN();
            bophan.An_Hien = this.AnHien;
            bophan.Show();
        }
        #endregion


        #region buttonItemLeftPhongBan_Click        
     
        private void buttonItemLeftPhongBan_Click(object sender, EventArgs e)
        {
            frm_PHONGBAN phongban = new frm_PHONGBAN();
            phongban.An_Hien = this.AnHien;
            phongban.Show();
        }
        #endregion

       
        #region buttonItemMenuThoat_Click        
       
        private void buttonItemMenuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

     

       


        #region buttonItemLeftThemHoSoTuyenDung_Click        
       
        private void buttonItemLeftThemHoSoTuyenDung_Click(object sender, EventArgs e)
        {
            frm_HOSOTUYENDUNG hoso = null;
            if (hoso == null || hoso.IsDisposed)
                hoso = new frm_HOSOTUYENDUNG();
            hoso.MdiParent = this.MdiParent;          
            hoso.Open = "Open";
            //hoso.An_Hien = this.An_Hien;
            hoso.Show();
        }
        #endregion
       

        #region buttonItemLeftThemNhanVien_Click

        private void buttonItemLeftThemNhanVien_Click(object sender, EventArgs e)
        {
            frm_NHANVIEN1 nv = null;
            if (nv == null || nv.IsDisposed)
                nv = new frm_NHANVIEN1();
            nv.MdiParent = this.MdiParent;
            
            nv.Open = "Open";
            nv.An_Hien = this.AnHien;
            nv.Show();
        }
        #endregion

        #region buttonItemLeftNguoiDung_Click       
       

        private void buttonItemLeftNguoiDung_Click(object sender, EventArgs e)
        {
            frm_NGUOIDUNG nguoidung = new frm_NGUOIDUNG();
            nguoidung.Show();
        }
        #endregion


        #region buttonItemLeftDoiMatKhau_Click        
        
        private void buttonItemLeftDoiMatKhau_Click(object sender, EventArgs e)
        {
            frm_DOIMATKHAU doimatkhau = new frm_DOIMATKHAU();
            doimatkhau.Lay_UserName = this.Lay_UserName;
            doimatkhau.Show();
        }
        #endregion


        /// <summary>
        /// PANEL TRÊN 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       

        #region buttonItemTopTiepNhanHoSo_Click

        private void buttonItemTopTiepNhanHoSo_Click(object sender, EventArgs e)
        {
            frm_HOSOTUYENDUNG hoso = null;
            if (hoso == null || hoso.IsDisposed)
                hoso = new frm_HOSOTUYENDUNG();
            hoso.MdiParent = this.MdiParent;
            hoso.Open = "Open";
            ////hoso.An_Hien = this.An_Hien;
            hoso.ShowDialog();
            Graphics f = this.CreateGraphics();
        }
        #endregion

        #region buttonItemTopThemNhanVien_Click        
       
        private void buttonItemTopThemNhanVien_Click(object sender, EventArgs e)
        {
            //frm_NHANVIEN1 nv = null;
            //if (nv == null || nv.IsDisposed)
            //    nv = new frm_NHANVIEN1();
            //nv.MdiParent = this.MdiParent;            
            //nv.Open = "Open";
            ////nv.An_Hien = this.An_Hien;
            //nv.Show();
            frm_NHANVIEN1 nv = null;
            if (nv == null || nv.IsDisposed)
                nv = new frm_NHANVIEN1();
            nv.MdiParent = this.MdiParent;
            nv.Open = "Open";
            nv.ShowDialog();
            Graphics f = this.CreateGraphics();
        }
        #endregion

        #region buttonItemTopPhongBan_Click        
       
        private void buttonItemTopPhongBan_Click(object sender, EventArgs e)
        {
            DanhSachPhongBan();
        }
        #endregion

        #region buttonItemTopBoPhan_Click        
       
        private void buttonItemTopBoPhan_Click(object sender, EventArgs e)
        {
           
        }
        #endregion

        #region buttonItemTopDanToc_Click        
        
        private void buttonItemTopDanToc_Click(object sender, EventArgs e)
        {
            DanToc();
        }
        #endregion

        #region buttonItemTopLuongNV_Click        
        
        private void buttonItemLuongNV_Click(object sender, EventArgs e)
        {
            BangLuongNhanVien();
            
        }
        #endregion

        #region buttonItemTopQuocTich_Click        
        
        private void buttonItemTopQuocTich_Click(object sender, EventArgs e)
        {
            QuocTich();

        }
        #endregion

        #region buttonItemTopNgach_Click        
       
        private void buttonItemTopNgach_Click(object sender, EventArgs e)
        {
            NgachCongChuc();
        }
        #endregion

        #region buttonItemTopBacLuong_Click        
        
        private void buttonItemTopBacLuong_Click(object sender, EventArgs e)
        {
            BacLuong();
        }
        #endregion

        #region buttonItemHeSoLuongNV_Click        
        
        private void buttonItemHeSoLuongNV_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("Loading");
            HeSoLuongNhanVien();
        }
        #endregion

        #region buttonItemTopNgoaiNgu_Click        
       
        private void buttonItemTopNgoaiNgu_Click(object sender, EventArgs e)
        {
            NgoaiNgu();
        }
        #endregion

        #region buttonItemTopTrinhDoNgoaiNgu_Click        
        
        private void buttonItemTopTrinhDoNgoaiNgu_Click(object sender, EventArgs e)
        {
            TrinhDo_NgoaiNgu();
        }
        #endregion

        #region buttonItemTopTrinhDoTinHoc_Click        
       
        private void buttonItemTopTrinhDoTinHoc_Click(object sender, EventArgs e)
        {
            TrinhDo_TinHoc();
        }
        #endregion

        #region buttonItemTrinhDoHocVan_Click        
       
        private void buttonItemTrinhDoHocVan_Click(object sender, EventArgs e)
        {
            TrinhDoHocVan();
        }
        #endregion

        #region buttonItemTopViTriTuyenDung_Click        
       
        private void buttonItemTopViTriTuyenDung_Click(object sender, EventArgs e)
        {
            ViTriTuyenDung();
        }
        #endregion

        #region buttonItemTopChucVu_Click        
       
        private void buttonItemTopChucVu_Click(object sender, EventArgs e)
        {
            ChucVu();
        }
        #endregion

        #region buttonItemTopThongKeNhanVien_Click        
       
        private void buttonItemTopThongKeNhanVien_Click(object sender, EventArgs e)
        {
            InDanhSachAllNhanVien();
        }
        #endregion

        #region buttonItemTopThongKeNhanVienTren40Tuoi_Click        
       
        private void buttonItemTopThongKeNhanVienTren40Tuoi_Click(object sender, EventArgs e)
        {
            InDanhSachNhanVienTren40Tuoi();
        }
        #endregion


        #region ctrlNhatKy
        private NhatKyCtrl m_ctrlNhatKy;
        public NhatKyCtrl ctrlNhatKy
        {
            get { return m_ctrlNhatKy; }
            set { m_ctrlNhatKy = value; }
        }
 #endregion
       

        #region frmMain_Shown        
        
        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.Dang_Nhap();
        }
        #endregion

        #region Dang_Nhap()
        public void Dang_Nhap()
        {
           
        tiep_tuc:
            if (DangNhap == null || DangNhap.IsDisposed)
                DangNhap = new frm_DANGNHAP();
            
            if (DangNhap.ShowDialog() == DialogResult.OK)
            {
                String username = DangNhap.txtTAIKHOAN.Text;
                String password = DangNhap.txtMATKHAU.Text;
                this.Lay_UserName = DangNhap.txtTAIKHOAN.Text;


               
                NguoiDungCtrl ctrl = new NguoiDungCtrl();
                int ketqua = ctrl.DangNhap(username, password);
                ////////////////////////////////

               
               
                
                ///////
                int i = ctrl.PhanQuyen;
                switch (ketqua)
                {
                    case 0:
                        MessageBoxEx.Show("Sai tên đăng nhập! Vui lòng nhập lại...", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        goto tiep_tuc;
                    case 1:
                        if (i == 1)
                        {
                            
                            this.toolHienThi.Text = "Người dùng: " + Utility.NGUOIDUNG.HoTen + " - Quyền: Administrator";
                            this.buttonItemDangNhapVoiQuyen.Text = Utility.NGUOIDUNG.HoTen;
                            m_NguoiDung = this.toolHienThi.Text;                           
                            Toan_Quyen();
                        }
                         if (i == 2)
                        {
                            this.toolHienThi.Text = "Người dùng: " + Utility.NGUOIDUNG.HoTen + " - Quyền: Chỉ xem và Tìm kiếm";
                            this.buttonItemDangNhapVoiQuyen.Text = Utility.NGUOIDUNG.HoTen;
                            Chi_Xem();
                        }

                        if (i == 3)
                        {
                            this.toolHienThi.Text = "Người dùng: " + Utility.NGUOIDUNG.HoTen + " - Quyền: Nhân Viên Nhập Liệu Phòng Tài Vụ";
                            this.buttonItemDangNhapVoiQuyen.Text = Utility.NGUOIDUNG.HoTen;
                            Toan_Quyen();
                        }

                        if (i == 4)
                        {
                            this.toolHienThi.Text = "Người dùng: " + Utility.NGUOIDUNG.HoTen + " - Quyền: Nhân Viên Nhập Liệu Phòng Tổ Chức";
                            this.buttonItemDangNhapVoiQuyen.Text = Utility.NGUOIDUNG.HoTen;
                            Chi_Xem();
                        }
                        break;
                    case 2:
                        MessageBoxEx.Show("Sai mật khẩu đăng nhập! Vui lòng nhập lại...", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        goto tiep_tuc;
                }

                NhatKyData nhatky_data = new NhatKyData();
                string ngay = System.DateTime.Now.ToString();
                nhatky_data.NhatKy(Utility.NGUOIDUNG.MaNguoiDung, DangNhap.txtTAIKHOAN.Text, Utility.NGUOIDUNG.HoTen, ngay);

                MessageBoxEx.Show("Đăng Nhập Thành Công","Chúc Mừng Bạn");
            }
        }
        #endregion

        #region Toan_Quyen()
        public void Toan_Quyen()
        {
            ////////////////////////////////////
            this.buttonItemMenuDangNhap.Enabled = false;
            this.buttonItemTopDangNhap.Enabled = false;           


            //////////////////////////////////////
            this.ribbonTabItemQuanTriHeThong.Enabled = true;
            this.ribbonTabItemQuanLyNhanSu.Enabled = true;
            this.ribbonTabItemQuanLyTuyenDung.Enabled = true;
            this.ribbonTabItemTimKiemThongKe.Enabled = true;
            this.navigationPane1.Enabled = true;
            this.buttonItemMenuChuyenTaiKhoanKhac.Enabled = true;
            this.buttonItemMenuDoiMatKhau.Enabled = true;
            this.buttonItemTopBac.Enabled = true;
           
            this.buttonItemTopChucVu.Enabled = true;
            this.buttonItemTopDanhSachUngVien.Enabled = true;
            this.buttonItemTopChuyenSangTaiKhoanKhac.Enabled = true;
            this.buttonItemTopDanToc.Enabled = true;
            this.buttonItemTopDoiMatKhau.Enabled = true;
            
            this.buttonItemTopNgach.Enabled = true;
            this.buttonItemTopNgoaiNgu.Enabled = true;
            this.buttonItemTopPhanQuyenNguoiDung.Enabled = true;
            this.buttonItemTopTiepNhanNhanVien.Enabled = true;
            this.buttonItemTopPhucHoiDuLieu.Enabled = true;
            this.buttonItemTopQuocTich.Enabled = true;
            this.buttonItemTopSaoLuuDuLieu.Enabled = true;
            //this.buttonItemTopThemNhanVien.Enabled = true;
            this.buttonItemTopThongKeHoSoTuyenDung.Enabled = true;
            this.buttonItemTopThongKeNhanVien.Enabled = true;
           
            this.buttonItemTopThongKeNhanVienTren40Tuoi.Enabled = true;
            this.buttonItemTopTiepNhanHoSo.Enabled = true;
            this.buttonItemTopTimKiemHoSoTuyenDung.Enabled = true;
            this.buttonItemTopTimKiemNhanVien.Enabled = true;
            this.buttonItemTopBangLuongNhanVien.Enabled = true;
            this.buttonItemTopTrinhDoNgoaiNgu.Enabled = true;
            this.buttonItemTopTrinhDoTinHoc.Enabled = true;
            this.buttonItemTopViTriTuyenDung.Enabled = true;
            this.buttonItemTopTrinhDoHocVan.Enabled = true;
            this.buttonItemTopHeSoLuong.Enabled = true;


            /////////////////////////////////////////////////////////

          
                  
           

            /////////////////////////////////////////////

        }
        #endregion

        #region Chi_Xem()
        public void Chi_Xem()
        {
            
            this.AnHien = "Xem";

            this.ribbonTabItemQuanTriHeThong.Enabled = true;
            this.ribbonTabItemQuanLyNhanSu.Enabled = true;
            this.ribbonTabItemQuanLyTuyenDung.Enabled = true;
            this.ribbonTabItemTimKiemThongKe.Enabled = true;
            this.navigationPane1.Enabled = true;
            this.buttonItemMenuChuyenTaiKhoanKhac.Enabled = true;
            this.buttonItemMenuDoiMatKhau.Enabled = true;
            this.buttonItemTopBac.Enabled = true;
           
            this.buttonItemTopChucVu.Enabled = true;
            this.buttonItemTopDanhSachUngVien.Enabled = false;
            this.buttonItemTopChuyenSangTaiKhoanKhac.Enabled = true;
            this.buttonItemTopDanToc.Enabled = true;
            this.buttonItemTopDoiMatKhau.Enabled = true;
            
            this.buttonItemTopNgach.Enabled = true;
            this.buttonItemTopNgoaiNgu.Enabled = true;
            this.buttonItemTopPhanQuyenNguoiDung.Enabled = false;
            //this.buttonItemTopTiepNhanNhanVien.Enabled = true;
            this.buttonItemTopPhucHoiDuLieu.Enabled = false;
            this.buttonItemTopQuocTich.Enabled = true;
            this.buttonItemTopSaoLuuDuLieu.Enabled = false;
            this.buttonItemTopTiepNhanNhanVien.Enabled = false;
            this.buttonItemTopThongKeHoSoTuyenDung.Enabled = false;
            this.buttonItemTopThongKeNhanVien.Enabled = false;           
            this.buttonItemTopThongKeNhanVienTren40Tuoi.Enabled = false;
            this.buttonItemTopTiepNhanHoSo.Enabled = false;
            this.buttonItemTopTimKiemHoSoTuyenDung.Enabled = false;
            this.buttonItemTopTimKiemNhanVien.Enabled = false;
            this.buttonItemTopBangLuongNhanVien.Enabled = true;
            this.buttonItemTopTrinhDoNgoaiNgu.Enabled = true;
            this.buttonItemTopTrinhDoTinHoc.Enabled = true;
            this.buttonItemTopViTriTuyenDung.Enabled = true;
            this.buttonItemTopTrinhDoHocVan.Enabled = true;
            this.buttonItemTopHeSoLuong.Enabled = true;

            ///////////////////////////////////////////////////////
                        
         
           
            this.buttonItemMenuDangNhap.Enabled = false;
            this.buttonItemTopDangNhap.Enabled = false;

        }
        #endregion

        #region buttonItemTopChuyenSangTaiKhoanKhac_Click        
       
        private void buttonItemTopChuyenSangTaiKhoanKhac_Click(object sender, EventArgs e)
        {
            this.Dang_Xuat();
        }
        #endregion

        #region Dang_Xuat()
        public void Dang_Xuat()
        {
            while (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
            this.AnHien = "DangXuat";
            Default();
            
           
            this.buttonItemTopDangNhap.Enabled = true;
            this.buttonItemMenuDangNhap.Enabled = true;
           
            

            this.toolHienThi.Text = "Chương trình đã logout....Bạn có quyền login với một account khác.";
        }
        #endregion

        #region Default()
        public void Default()
        {
            this.ribbonTabItemQuanTriHeThong.Enabled = false;
            this.ribbonTabItemQuanLyNhanSu.Enabled = false;
            this.ribbonTabItemQuanLyTuyenDung.Enabled = false;
            this.ribbonTabItemTimKiemThongKe.Enabled = false;
            this.navigationPane1.Enabled = false;
            ////////////////////////////////////////////

            this.buttonItemMenuChuyenTaiKhoanKhac.Enabled = false;
            this.buttonItemMenuDoiMatKhau.Enabled = false;

            //////////////////////////////////////////
            this.buttonItemTopBac.Enabled = false;
            
            this.buttonItemTopChucVu.Enabled = false;
            this.buttonItemTopDanhSachUngVien.Enabled = false;
            this.buttonItemTopChuyenSangTaiKhoanKhac.Enabled = false;
            this.buttonItemTopDanToc.Enabled = false;
            this.buttonItemTopDoiMatKhau.Enabled = false;
            
            this.buttonItemTopNgach.Enabled = false;
            this.buttonItemTopNgoaiNgu.Enabled = false;
            this.buttonItemTopPhanQuyenNguoiDung.Enabled = false;
            this.buttonItemTopTiepNhanNhanVien.Enabled = false;
            this.buttonItemTopPhucHoiDuLieu.Enabled = false;
            this.buttonItemTopQuocTich.Enabled = false;
            this.buttonItemTopSaoLuuDuLieu.Enabled = false;
            //this.buttonItemTopThemNhanVien.Enabled = false;
            this.buttonItemTopThongKeHoSoTuyenDung.Enabled = false;
            this.buttonItemTopThongKeNhanVien.Enabled = false;           
            this.buttonItemTopThongKeNhanVienTren40Tuoi.Enabled = false;
            this.buttonItemTopTiepNhanHoSo.Enabled = false;
            this.buttonItemTopTimKiemHoSoTuyenDung.Enabled = false;
            this.buttonItemTopTimKiemNhanVien.Enabled = false;
            this.buttonItemTopBangLuongNhanVien.Enabled = false;
            this.buttonItemTopTrinhDoNgoaiNgu.Enabled = false;
            this.buttonItemTopTrinhDoTinHoc.Enabled = false;
            this.buttonItemTopViTriTuyenDung.Enabled = false;
            this.buttonItemTopTrinhDoHocVan.Enabled = false;
            this.buttonItemTopHeSoLuong.Enabled = false;

            /////////////////////////////////////////////////////////////////
           
            

           
        }
        #endregion        

        #region buttonItemTopDoiMatKhau_Click        
       
        private void buttonItemTopDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau();
        }
        #endregion

        #region buttonItemTopDangNhap_Click        
       
        private void buttonItemTopDangNhap_Click(object sender, EventArgs e)
        {
            this.Dang_Nhap();
        }
        #endregion

        #region buttonItemMenuDangNhap_Click        
       
        private void buttonItemMenuDangNhap_Click(object sender, EventArgs e)
        {
            this.Dang_Nhap();
        }
        #endregion

        #region buttonItemMenuChuyenTaiKhoanKhac_Click        
       
        private void buttonItemMenuChuyenTaiKhoanKhac_Click(object sender, EventArgs e)
        {
            this.Dang_Xuat();
        }
        #endregion

        #region buttonItemLeftChuyenSangTaiKhoanKhac_Click        
        
        private void buttonItemLeftChuyenSangTaiKhoanKhac_Click(object sender, EventArgs e)
        {
            this.Dang_Xuat();
        }
        #endregion

        #region buttonItemTopPhanQuyenNguoiDung_Click        
       
        private void buttonItemTopPhanQuyenNguoiDung_Click(object sender, EventArgs e)
        {
            QuanLyNguoiDung();
            
        }
        #endregion

        #region buttonItemMenuDoiMatKhau_Click        
       
        private void buttonItemMenuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frm_DOIMATKHAU doimatkhau = new frm_DOIMATKHAU();
            doimatkhau.Lay_UserName = this.Lay_UserName;
            doimatkhau.Show();
        }
        #endregion

        #region buttonItemTopThongKeNhanVienTheoTrinhDo_Click        
       
        private void buttonItemTopThongKeNhanVienTheoTrinhDo_Click(object sender, EventArgs e)
        {
           
        }
        #endregion

        #region buttonItemTopTimKiemNhanVien_Click        
       
        private void buttonItemTopTimKiemNhanVien_Click(object sender, EventArgs e)
        {
            TraCuuNhanVien();
        }
        #endregion

        #region buttonItemTopDanhSachNhanVien_Click        
       
        private void buttonItemTopDanhSachNhanVien_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region buttonItemTopSaoLuuDuLieu_Click        
       
        private void buttonItemTopSaoLuuDuLieu_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "BAK files (*.bak)|*.bak";
            if (s.ShowDialog() == DialogResult.OK)
            {

                string sql = " backup database QLNSTL_TTGDTX_AG to disk='" + s.FileName.ToString() + "'";
                DataService dt = new DataService();
                SqlCommand cm = new SqlCommand(sql);
                dt.Load(cm);
                MessageBox.Show("Sao Lưu thành công");
            }
        }
        #endregion
        #region buttonItemTopPhucHoiDuLieu_Click        
       

        private void buttonItemTopPhucHoiDuLieu_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "BAK files (*.bak)|*.bak";
            op.Multiselect = false;
            if (op.ShowDialog() == DialogResult.OK)
            {
                string sql = " use master restore database QLNSTL_TTGDTX_AG from disk='" + op.FileName.ToString() + "' with REPLACE";
                DataService dt = new DataService();
                SqlCommand cm = new SqlCommand(sql);
                dt.Load(cm);
                MessageBox.Show("Phục hồi dữ liệu thành công");
            }

            MessageBoxEx.Show("Bạn phải khởi động lại phần mềm sau khi phục hồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        #endregion

        
        #region buttonItemTopDanhSachUngVien_Click        
       
        private void buttonItemTopDanhSachUngVien_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("Loading");
            DanhSachUngCuVien();
            //frm_LIST_HOSOTUYENDUNG list_Hosotuyendung = null;
            //if (list_Hosotuyendung == null || list_Hosotuyendung.IsDisposed)
            //{
            //    list_Hosotuyendung = new frm_LIST_HOSOTUYENDUNG();
            //    list_Hosotuyendung.MdiParent = this;
            //    list_Hosotuyendung.WindowState = FormWindowState.Maximized;
            //    list_Hosotuyendung.An_Hien = this.AnHien;
            //    list_Hosotuyendung.Show();
            //    list_Hosotuyendung.Focus();
            //}
            //else
            //{
            //    list_Hosotuyendung.Activate();
            //    list_Hosotuyendung.ReLoad();
            //}
        }
        #endregion

        #region buttonItemTopHoSoNhanVien_Click        
       
        private void buttonItemTopHoSoNhanVien_Click(object sender, EventArgs e)
        {

            MessageBoxEx.Show("Loading");
            DanhSachHoSoNhanVien();
           
        }
        #endregion

        #region buttonItemTopHDSuDung_Click        
       
        private void buttonItemTopHDSuDung_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "Help.chm");
           
        }
        #endregion

        #region buttonItemTopLienHe_Click        
       
        private void buttonItemTopLienHe_Click(object sender, EventArgs e)
        {
            TacGia();
        }
        #endregion

        private void buttonItemTopTTPhanMem_Click(object sender, EventArgs e)
        {
            ThongTinPhanMem();
            
        }

        private void buttonItemTopTonGiao_Click(object sender, EventArgs e)
        {
            TonGiao();
        }

        private void ribbonTabItemQuanLyNhanSu_Click(object sender, EventArgs e)
        {

        }

        private void buttonItemTopThongKeHoSoTuyenDung_Click(object sender, EventArgs e)
        {
            InDanhSachTrungTuyen();
        }

    }
}
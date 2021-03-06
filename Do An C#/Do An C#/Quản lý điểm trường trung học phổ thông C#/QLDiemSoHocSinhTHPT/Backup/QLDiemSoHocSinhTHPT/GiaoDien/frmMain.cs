using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLDiemSoHocSinhTHPT.Controller;
using QLDiemSoHocSinhTHPT.BusinessObject;
using QLDiemSoHocSinhTHPT.Report;

namespace QLDiemSoHocSinhTHPT.GiaoDien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        frmGiaoVien frm_GiaoVien;
        frmHocSinh frm_HocSinh;
        frmDanToc frm_DanToc;
        frmTonGiao frm_TonGiao;
        frmNgheNghiep frm_NgheNghiep;
        frmLop frm_Lop;
        frmKhoiLop frm_KhoiLop;
        frmHocKy frm_HocKy;
        frmNamHoc frm_NamHoc;
        frmMonHoc frm_MonHoc;
        frmLoaiDiem frm_LoaiDiem;
        frmKetQua frm_KetQua;
        frmHocLuc frm_HocLuc;
        frmHanhKiem frm_HanhKiem;
        frmPhanCong frm_PhanCong;
        frmPhanLop frm_PhanLop;
        frmThongTinPhanMem frm_TTPhanMem;
        frmThongTinTruong frm_TTTruong;
        frmTimHocSinh1 frm_TimHS;
        frmTimGiaoVien1 frm_TimGV;
        frmNguoiDung frm_NguoiDung;
        frmLopMonHoc frm_LopMonHoc;
        frmDangNhap frm_DangNhap;
        frmNhapDiem frm_NhapDiem;
        frmDoiMatKhau frm_DoiMatKhau;
        frmDSGiaoVien frm_DSGiaoVien;
        frmDSHocSinh_Lop frm_DSHocSinh;


        private void frmMain_Load(object sender, EventArgs e)
        {
            //this.DangNhap();
        }

        //////////////////////////////////////////////////////////
        //Menu quan ly
        private void miQLDanToc_Click(object sender, EventArgs e)
        {            
            if (this.frm_DanToc == null || this.frm_DanToc.IsDisposed)
            {
                frm_DanToc = new frmDanToc();
                frm_DanToc.MdiParent = this;
                frm_DanToc.Show();
            }
        }

        private void miQLTonGiao_Click(object sender, EventArgs e)
        {
            if (this.frm_TonGiao == null || this.frm_TonGiao.IsDisposed)
            {
                frm_TonGiao = new frmTonGiao();
                frm_TonGiao.MdiParent = this;
                frm_TonGiao.Show();
            }
        }

        private void miQLGiaoVien_Click(object sender, EventArgs e)
        {
            if (this.frm_GiaoVien == null || this.frm_GiaoVien.IsDisposed)
            {
                frm_GiaoVien = new frmGiaoVien();
                frm_GiaoVien.MdiParent = this;
                frm_GiaoVien.Show();
            }
        }

        private void miQLHocSinh_Click(object sender, EventArgs e)
        {
            if (this.frm_HocSinh == null || this.frm_HocSinh.IsDisposed)
            {
                frm_HocSinh = new frmHocSinh();
                frm_HocSinh.MdiParent = this;
                frm_HocSinh.Show();
            }
        }

        private void miQLNgheNghiep_Click(object sender, EventArgs e)
        {
            if (this.frm_NgheNghiep == null || this.frm_NgheNghiep.IsDisposed)
            {
                frm_NgheNghiep = new frmNgheNghiep();
                frm_NgheNghiep.MdiParent = this;
                frm_NgheNghiep.Show();
            }
        }

        private void miQLLop_Click(object sender, EventArgs e)
        {
            if (this.frm_Lop == null || this.frm_Lop.IsDisposed)
            {
                frm_Lop = new frmLop();
                frm_Lop.MdiParent = this;
                frm_Lop.Show();
            }
        }

        private void miQLKhoiLop_Click(object sender, EventArgs e)
        {
            if (this.frm_KhoiLop == null || this.frm_KhoiLop.IsDisposed)
            {
                frm_KhoiLop = new frmKhoiLop();
                frm_KhoiLop.MdiParent = this;
                frm_KhoiLop.Show();
            }
        }

        private void miQLHocKy_Click(object sender, EventArgs e)
        {
            if (this.frm_HocKy == null || this.frm_HocKy.IsDisposed)
            {
                frm_HocKy = new frmHocKy();
                frm_HocKy.MdiParent = this;
                frm_HocKy.Show();
            }
        }

        private void miQLNamHoc_Click(object sender, EventArgs e)
        {
            if (this.frm_NamHoc == null || this.frm_NamHoc.IsDisposed)
            {
                frm_NamHoc = new frmNamHoc();
                frm_NamHoc.MdiParent = this;
                frm_NamHoc.Show();
            }
        }

        private void miQLMonHoc_Click(object sender, EventArgs e)
        {
            if (this.frm_MonHoc == null || this.frm_MonHoc.IsDisposed)
            {
                frm_MonHoc = new frmMonHoc();
                frm_MonHoc.MdiParent = this;
                frm_MonHoc.Show();
            }
        }

        private void miQLLoaiDiem_Click(object sender, EventArgs e)
        {
            if (this.frm_LoaiDiem == null || this.frm_LoaiDiem.IsDisposed)
            {
                frm_LoaiDiem = new frmLoaiDiem();
                frm_LoaiDiem.MdiParent = this;
                frm_LoaiDiem.Show();
            }
        }

        private void miQLKetQua_Click(object sender, EventArgs e)
        {
            if (this.frm_KetQua == null || this.frm_KetQua.IsDisposed)
            {
                frm_KetQua = new frmKetQua();
                frm_KetQua.MdiParent = this;
                frm_KetQua.Show();
            }
        }

        private void miQLHocLuc_Click(object sender, EventArgs e)
        {
            if (this.frm_HocLuc == null || this.frm_HocLuc.IsDisposed)
            {
                frm_HocLuc = new frmHocLuc();
                frm_HocLuc.MdiParent = this;
                frm_HocLuc.Show();
            }
        }

        private void miQLHanhKiem_Click(object sender, EventArgs e)
        {
            if (this.frm_HanhKiem == null || this.frm_HanhKiem.IsDisposed)
            {
                frm_HanhKiem = new frmHanhKiem();
                frm_HanhKiem.MdiParent = this;
                frm_HanhKiem.Show();
            }
        }

        private void miQLLopMonHoc_Click(object sender, EventArgs e)
        {
            if (this.frm_LopMonHoc == null || this.frm_LopMonHoc.IsDisposed)
            {
                frm_LopMonHoc = new frmLopMonHoc();
                frm_LopMonHoc.MdiParent = this;
                frm_LopMonHoc.Show();
            }
        }
        ///////////////////////////////////////////////////////////////
        //Thanh Chuc nang
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            this.DangNhap();
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            //Disable Dang nhap va Enable Dang xuat
            this.miDangNhap.Enabled = true;
            this.miDangXuat.Enabled = false;
            this.btDangNhap.Enabled = true;
            this.btDangXuat.Enabled = false;
            this.tiDangNhap.Enabled = true;
            this.tiDangXuat.Enabled = false;
            
            //Hien thi mac dinh (khong co nguoi dang nhap)
            this.DefaultShow();
        }

        private void btPhanCongGiaoVien_Click(object sender, EventArgs e)
        {
            if (this.frm_PhanCong == null || this.frm_PhanCong.IsDisposed)
            {
                frm_PhanCong = new frmPhanCong();
                frm_PhanCong.MdiParent = this;
                frm_PhanCong.Show();
            }
        }

        private void btPhanLopHocSinh_Click(object sender, EventArgs e)
        {
            if (this.frm_PhanLop == null || this.frm_PhanLop.IsDisposed)
            {
                frm_PhanLop = new frmPhanLop();
                frm_PhanLop.MdiParent = this;
                frm_PhanLop.Show();
            }
        }

        private void btTiepNhanHocSinh_Click(object sender, EventArgs e)
        {
            if (this.frm_HocSinh == null || this.frm_HocSinh.IsDisposed)
            {
                frm_HocSinh = new frmHocSinh();
                frm_HocSinh.MdiParent = this;
                frm_HocSinh.Show();
            }
        }

        private void btNhapDiem_Click(object sender, EventArgs e)
        {
            if (this.frm_NhapDiem == null || this.frm_NhapDiem.IsDisposed)
            {
                frm_NhapDiem = new frmNhapDiem();
                frm_NhapDiem.MdiParent = this;
                frm_NhapDiem.Show();
            }
        }

        ////////////////////////////////////////////////////////////////////
        //Menu NghiepVu
        private void miPhanCongGiaoVien_Click(object sender, EventArgs e)
        {
            if (this.frm_PhanCong == null || this.frm_PhanCong.IsDisposed)
            {
                frm_PhanCong = new frmPhanCong();
                frm_PhanCong.MdiParent = this;
                frm_PhanCong.Show();
            }
        }

        private void miPhanLopHocSinh_Click(object sender, EventArgs e)
        {
            if (this.frm_PhanLop == null || this.frm_PhanLop.IsDisposed)
            {
                frm_PhanLop = new frmPhanLop();
                frm_PhanLop.MdiParent = this;
                frm_PhanLop.Show();
            }
        }

        private void miNhapDiem_Click(object sender, EventArgs e)
        {
            if (this.frm_NhapDiem == null || this.frm_NhapDiem.IsDisposed)
            {
                frm_NhapDiem = new frmNhapDiem();
                frm_NhapDiem.MdiParent = this;
                frm_NhapDiem.Show();
            }
        }

        ////////////////////////////////////////////////////////////////////////
        //Menu Hien Thi
        private void miChucNang_Click(object sender, EventArgs e)
        {
            ChucNang.Visible = miChucNang.Checked;
        }

        private void miStatus_Click(object sender, EventArgs e)
        {
            status.Visible = miStatus.Checked;
        }

        /////////////////////////////////////////////////////////////////////////
        // Menu Giup do
        private void miTTTruong_Click(object sender, EventArgs e)
        {
            if (this.frm_TTTruong == null || this.frm_TTTruong.IsDisposed)
            {
                frm_TTTruong = new frmThongTinTruong();
                frm_TTTruong.MdiParent = this;
                frm_TTTruong.Show();
            }
        }

        private void miTTPhanMem_Click(object sender, EventArgs e)
        {
            if (this.frm_TTPhanMem == null || this.frm_TTPhanMem.IsDisposed)
            {
                frm_TTPhanMem = new frmThongTinPhanMem();
                frm_TTPhanMem.MdiParent = this;
                frm_TTPhanMem.Show();
            }
        }

        private void miHuongDanSuDung_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "help.chm");
        }

        ///////////////////////////////////////////////////////////////////////////
        // Menu Tim kiem
        private void miTCHocSinh_Click(object sender, EventArgs e)
        {
            if (this.frm_TimHS == null || this.frm_TimHS.IsDisposed)
            {
                frm_TimHS = new frmTimHocSinh1();
                frm_TimHS.MdiParent = this;
                frm_TimHS.Show();
            }
        }

        private void miTCGiaoVien_Click(object sender, EventArgs e)
        {
            if (this.frm_TimGV == null || this.frm_TimGV.IsDisposed)
            {
                frm_TimGV = new frmTimGiaoVien1();
                frm_TimGV.MdiParent = this;
                frm_TimGV.Show();
            }
        }

        

        /////////////////////////////////////////////////////////////////////////////
        //Menu he thong
        private void miNguoiDung_Click(object sender, EventArgs e)
        {
            if (this.frm_NguoiDung == null || this.frm_NguoiDung.IsDisposed)
            {
                frm_NguoiDung = new frmNguoiDung();
                frm_NguoiDung.MdiParent = this;
                frm_NguoiDung.Show();
            }
        }

        private void miDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (this.frm_DoiMatKhau == null || this.frm_DoiMatKhau.IsDisposed)
            {
                frm_DoiMatKhau = new frmDoiMatKhau();
                frm_DoiMatKhau.MdiParent = this;
                frm_DoiMatKhau.Show();
            }
        }

        private void miDangXuat_Click(object sender, EventArgs e)
        {
            //Disable Dang nhap va Enable Dang xuat
            this.miDangNhap.Enabled = true;
            this.miDangXuat.Enabled = false;
            this.btDangNhap.Enabled = true;
            this.btDangXuat.Enabled = false;
            this.tiDangNhap.Enabled = true;
            this.tiDangXuat.Enabled = false;

            //Hien thi mac dinh (khong co nguoi dang nhap)
            this.DefaultShow();
        }

        private void miSaoLuu_Click(object sender, EventArgs e)
        {
            if (backupDialog.ShowDialog() == DialogResult.OK)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("BACKUP DATABASE " + Utilities.DatabaseName + " TO DISK = '" + backupDialog.FileName.ToString() + "'");
                DataService data = new DataService();
                //data.Load(cmd);
                data.ExecuteNonQuery(cmd);
                MessageBox.Show("Sao lưu dữ liệu thành công!", "BACKUP COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                return;
        }

        private void miPhucHoi_Click(object sender, EventArgs e)
        {
            if (restoreDialog.ShowDialog() == DialogResult.OK)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("USE master RESTORE DATABASE " + Utilities.DatabaseName + " FROM DISK = '" + restoreDialog.FileName.ToString() + "'");
                DataService data = new DataService();
                data.Load(cmd);
                MessageBox.Show("Phục hồi dữ liệu thành công!", "RESTORE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                return;
        }

        private void miDangNhap_Click(object sender, EventArgs e)
        {
            this.DangNhap();
        }

        /// <summary>
        /// Xu ly dang nhap
        /// </summary>
        public void DangNhap()
        {
        tt:
            if (frm_DangNhap == null || frm_DangNhap.IsDisposed)
            {
                frm_DangNhap = new frmDangNhap();
            }

            if (frm_DangNhap.ShowDialog() == DialogResult.OK)
            {
                switch (this.CheckLogin(frm_DangNhap.TenDangNhap, frm_DangNhap.MatKhau))
                {
                    case 0:
                        //MessageBox.Show("Đăng nhập thành công!");
                        Utilities.TTNguoiDungDangNhap = new QLDiemSoHocSinhTHPT.Controller.NguoiDungController().LayNguoiDung(frm_DangNhap.TenDangNhap);
                        break;
                    case 1:
                        MessageBox.Show("Sai mật khẩu!");
                        goto tt;
                    case 2:
                        MessageBox.Show("Sai tên đăng nhập!");
                        goto tt;
                }
            }
            else
            {
                this.DefaultShow();
            }
        }

        public void DefaultShow()
        {
            //Menu He thong
            this.miDoiMatKhau.Enabled = false;
            this.miHeThong.Enabled = false;
            this.miSaoLuu.Enabled = false;
            this.miPhucHoi.Enabled = false;

            //Menu Hien thi
            this.miHienThi.Enabled = false;
            this.miChucNang.Enabled = false;
            this.miStatus.Enabled = false;

            //Menu Quan ly
            this.miQuanLy.Enabled = false;
            this.miQLGiaoVien.Enabled = false;
            this.miQLHocSinh.Enabled = false;
            this.miQLDanToc.Enabled = false;
            this.miQLTonGiao.Enabled = false;
            this.miQLNgheNghiep.Enabled = false;
            this.miQLLop.Enabled = false;
            this.miQLKhoiLop.Enabled = false;
            this.miQLLopMonHoc.Enabled = false;
            this.miQLHocKy.Enabled = false;
            this.miQLNamHoc.Enabled = false;
            this.miQLMonHoc.Enabled = false;
            this.miQLLoaiDiem.Enabled = false;
            this.miQLKetQua.Enabled = false;
            this.miQLHocLuc.Enabled = false;
            this.miQLHanhKiem.Enabled = false;

            //Menu Nghiep vu
            this.miNghiepVu.Enabled = false;
            this.miPhanCongGiaoVien.Enabled = false;
            this.miPhanLopHocSinh.Enabled = false;
            this.miNhapDiem.Enabled = false;


            //Menu Thong ke
            this.miThongKe.Enabled = false;
            this.miDSGiaoVien.Enabled = false;
            this.miDSHocSinh.Enabled = false;
            this.miDSLop.Enabled = false;
            this.miKQHKMonHoc.Enabled = false;
            this.miKQCNMonHoc.Enabled = false;


            //Menu Tra cuu
            this.miTimKiem.Enabled = false;
            this.miTKGiaoVien.Enabled = false;
            this.miTKHocSinh.Enabled = false;


            //Menu Giup do
            this.miGiupDo.Enabled = false;
            this.miTTTruong.Enabled = false;
            this.miTTPhanMem.Enabled = false;
            this.miHuongDanSuDung.Enabled = false;


            //Thanh chuc nang
            this.btDangNhap.Enabled = true;
            this.btDangXuat.Enabled = false;
            this.btPhanCongGiaoVien.Enabled = false;
            this.btPhanLopHocSinh.Enabled = false;
            this.btNhapDiem.Enabled = false;
            this.btTiepNhanHocSinh.Enabled = false;


            //TaskPanel
            this.tiDangNhap.Enabled = true;
            this.tiDangXuat.Enabled = false;
            this.tiNguoiDung.Enabled = false;
            this.tiDoiMatKhau.Enabled = false;

            this.tiQLHocSinh.Enabled = false;
            this.tiQLGiaoVien.Enabled = false;

            this.tiPhanCongGiaoVien.Enabled = false;
            this.tiPhanLopHocSinh.Enabled = false;
            this.tiNhapDiem.Enabled = false;

            this.tiTimHocSinh.Enabled = false;
            this.tiTimGiaoVien.Enabled = false;
            

            this.statusLabel.Text = "Hiện chưa có người dùng nào đăng nhập!";
        }


        /// <summary>
        /// Kiem tra thong tin dang nhap va neu dang nhap thanh cong thi hien thi theo phan quyen
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int CheckLogin(string tendangnhap, string matkhau)
        {
            //QLDiemSoHocSinhTHPT.Controlller.UserControl ctrlUser = new QLHocSinh.Control.UserControl();
            NguoiDungController ctrlNguoiDung = new NguoiDungController();
            NguoiDungInfo infoNguoiDung = ctrlNguoiDung.LayNguoiDung(tendangnhap);
            
            //Neu tim thay username
            if (infoNguoiDung != null)
            {
                //Neu password dung
                if (infoNguoiDung.MatKhau == matkhau)
                {
                    //Gan thong tin user vua dang nahp vao bien toan cuc de tien su dung
                    Utilities.TTNguoiDungDangNhap = infoNguoiDung;

                    //Disable Dang nhap va Enable Dang xuat
                    this.miDangNhap.Enabled = false;
                    this.miDangXuat.Enabled = true;
                    this.tiDangNhap.Enabled = false;
                    this.tiDangXuat.Enabled = true;
                    this.btDangNhap.Enabled = false;
                    this.btDangXuat.Enabled = true;

                    //Hien thi theo phan quyen
                    this.AuthorityShow();
                    return 0;
                }
                else    //Password sai
                {
                    Utilities.TTNguoiDungDangNhap = null;
                    return 1;
                }
            }
            else    //Khong ton tai username
            {
                Utilities.TTNguoiDungDangNhap = null;
                return 2;
            }
        }

        /// <summary>
        /// Hien thi phan quyen
        /// </summary>
        /// <returns></returns>
        public int AuthorityShow()
        {
            //Quan tri
            if (Utilities.TTNguoiDungDangNhap.LoaiNguoiDung.MaLoai == 1)
            {
                //Menu He thong
                this.miDoiMatKhau.Enabled = true;
                this.miHeThong.Enabled = true;
                this.miSaoLuu.Enabled = true;
                this.miPhucHoi.Enabled = true;

                //Menu Hien thi
                this.miHienThi.Enabled = true;
                this.miChucNang.Enabled = true;
                this.miStatus.Enabled = true;
               
                //Menu Nghiep vu
                this.miNghiepVu.Enabled = false;
                this.miPhanCongGiaoVien.Enabled = false;
                this.miPhanLopHocSinh.Enabled = false;
                this.miNhapDiem.Enabled = false;


                //Menu Quan ly
                this.miQuanLy.Enabled = false;
                this.miQLGiaoVien.Enabled = false;
                this.miQLHocSinh.Enabled = false;
                this.miQLDanToc.Enabled = false;
                this.miQLTonGiao.Enabled = false;
                this.miQLNgheNghiep.Enabled = false;
                this.miQLLop.Enabled = false;
                this.miQLKhoiLop.Enabled = false;
                this.miQLLopMonHoc.Enabled = false;
                this.miQLHocKy.Enabled = false;
                this.miQLNamHoc.Enabled = false;
                this.miQLMonHoc.Enabled = false;
                this.miQLLoaiDiem.Enabled = false;
                this.miQLKetQua.Enabled = false;
                this.miQLHocLuc.Enabled = false;
                this.miQLHanhKiem.Enabled = false;

                //Menu Thong ke
                this.miThongKe.Enabled = false;
                this.miDSGiaoVien.Enabled = false;
                this.miDSHocSinh.Enabled = false;
                this.miDSLop.Enabled = false;
                this.miKQHKMonHoc.Enabled = false;
                this.miKQCNMonHoc.Enabled = false;


                //Menu Tra cuu
                this.miTimKiem.Enabled = false;
                this.miTKGiaoVien.Enabled = false;
                this.miTKHocSinh.Enabled = false;


                //Menu Giup do
                this.miGiupDo.Enabled = true;
                this.miTTTruong.Enabled = true;
                this.miTTPhanMem.Enabled = true;
                this.miHuongDanSuDung.Enabled = true;


                //Thanh chuc nang
                this.btDangNhap.Enabled = false;
                this.btDangXuat.Enabled = true;
                this.btPhanCongGiaoVien.Enabled = false;
                this.btPhanLopHocSinh.Enabled = false;
                this.btNhapDiem.Enabled = false;
                this.btTiepNhanHocSinh.Enabled = false;


                //TaskPanel
                this.tiDangNhap.Enabled = false;
                this.tiDangXuat.Enabled = true;
                this.tiNguoiDung.Enabled = true;
                this.tiDoiMatKhau.Enabled = true;

                this.tiQLHocSinh.Enabled = false;
                this.tiQLGiaoVien.Enabled = false;

                this.tiPhanCongGiaoVien.Enabled = false;
                this.tiPhanLopHocSinh.Enabled = false;
                this.tiNhapDiem.Enabled = false;

                this.tiTimHocSinh.Enabled = false;
                this.tiTimGiaoVien.Enabled = false;

                this.statusLabel.Text = "Tên đăng nhập: " + Utilities.TTNguoiDungDangNhap.TenNguoiDung + ".  Quyền: Quản trị";

                return 1;
            }


            //Quản lý: ban giam hieu
            if (Utilities.TTNguoiDungDangNhap.LoaiNguoiDung.MaLoai == 2)
            {
                //Menu He thong
                this.miHeThong.Enabled = true;
                this.miDoiMatKhau.Enabled = true;
                this.miSaoLuu.Enabled = false;
                this.miPhucHoi.Enabled = false;
                this.miThoat.Enabled = true;

                //Menu Hien thi
                this.miHienThi.Enabled = true;
                this.miChucNang.Enabled = true;
                this.miStatus.Enabled = true;

                //Menu Nghiep vu
                this.miNghiepVu.Enabled = true;
                this.miPhanCongGiaoVien.Enabled = true;
                this.miPhanLopHocSinh.Enabled = true;
                this.miNhapDiem.Enabled = false;


                //Menu Quan ly
                this.miQuanLy.Enabled = true;
                this.miQLGiaoVien.Enabled = true;
                this.miQLHocSinh.Enabled = true;
                this.miQLDanToc.Enabled = true;
                this.miQLTonGiao.Enabled = true;
                this.miQLNgheNghiep.Enabled = true;
                this.miQLLop.Enabled = true;
                this.miQLKhoiLop.Enabled = true;
                this.miQLLopMonHoc.Enabled = true;
                this.miQLHocKy.Enabled = true;
                this.miQLNamHoc.Enabled = true;
                this.miQLMonHoc.Enabled = true;
                this.miQLLoaiDiem.Enabled = true;
                this.miQLKetQua.Enabled = true;
                this.miQLHocLuc.Enabled = true;
                this.miQLHanhKiem.Enabled = true;

                //Menu Thong ke
                this.miThongKe.Enabled = true;
                this.miDSGiaoVien.Enabled = true;
                this.miDSHocSinh.Enabled = true;
                this.miDSLop.Enabled = true;
                this.miKQHKMonHoc.Enabled = true;
                this.miKQCNMonHoc.Enabled = true;


                //Menu Tra cuu
                this.miTimKiem.Enabled = true;
                this.miTKGiaoVien.Enabled = true;
                this.miTKHocSinh.Enabled = true;


                //Menu Giup do
                this.miGiupDo.Enabled = true;
                this.miTTTruong.Enabled = true;
                this.miTTPhanMem.Enabled = true;
                this.miHuongDanSuDung.Enabled = true;


                //Thanh chuc nang
                this.btDangNhap.Enabled = false;
                this.btDangXuat.Enabled = true;
                this.btPhanCongGiaoVien.Enabled = true;
                this.btPhanLopHocSinh.Enabled = true;
                this.btNhapDiem.Enabled = false;
                this.btTiepNhanHocSinh.Enabled = true;


                //TaskPanel
                this.tiDangNhap.Enabled = false;
                this.tiDangXuat.Enabled = true;
                this.tiNguoiDung.Enabled = true;
                this.tiDoiMatKhau.Enabled = true;

                this.tiQLHocSinh.Enabled = true;
                this.tiQLGiaoVien.Enabled = true;

                this.tiPhanCongGiaoVien.Enabled = true;
                this.tiPhanLopHocSinh.Enabled = true;
                this.tiNhapDiem.Enabled = false;

                this.tiTimHocSinh.Enabled = true;
                this.tiTimGiaoVien.Enabled = true;

                this.statusLabel.Text = "Tên đăng nhập: " + Utilities.TTNguoiDungDangNhap.TenNguoiDung + ".  Quyền: Ban giám hiệu";

                return 2;
            }

            
           
            //Giao vien
            if (Utilities.TTNguoiDungDangNhap.LoaiNguoiDung.MaLoai == 3)
            {
                //Menu He thong
                this.miDoiMatKhau.Enabled = true;
                this.miHeThong.Enabled = false;
                this.miSaoLuu.Enabled = false;
                this.miPhucHoi.Enabled = false;


                //Menu Nghiep vu
                this.miNghiepVu.Enabled = true;
                this.miPhanCongGiaoVien.Enabled = false;
                this.miPhanLopHocSinh.Enabled = false;
                this.miNhapDiem.Enabled = true;


                //Menu Quan ly
                this.miQuanLy.Enabled = false;
                this.miQLGiaoVien.Enabled = false;
                this.miQLHocSinh.Enabled = false;
                this.miQLDanToc.Enabled = false;
                this.miQLTonGiao.Enabled = false;
                this.miQLNgheNghiep.Enabled = false;
                this.miQLLop.Enabled = false;
                this.miQLKhoiLop.Enabled = false;
                this.miQLLopMonHoc.Enabled = false;
                this.miQLHocKy.Enabled = false;
                this.miQLNamHoc.Enabled = false;
                this.miQLMonHoc.Enabled = false;
                this.miQLLoaiDiem.Enabled = false;
                this.miQLKetQua.Enabled = false;
                this.miQLHocLuc.Enabled = false;
                this.miQLHanhKiem.Enabled = false;

                //Menu Thong ke
                this.miThongKe.Enabled = true;
                this.miDSGiaoVien.Enabled = true;
                this.miDSHocSinh.Enabled = true;
                this.miDSLop.Enabled = true;
                this.miKQHKMonHoc.Enabled = true;
                this.miKQCNMonHoc.Enabled = true;


                //Menu Tra cuu
                this.miTimKiem.Enabled = true;
                this.miTKGiaoVien.Enabled = true;
                this.miTKHocSinh.Enabled = true;


                //Menu Giup do
                this.miGiupDo.Enabled = true;
                this.miTTTruong.Enabled = true;
                this.miTTPhanMem.Enabled = true;
                this.miHuongDanSuDung.Enabled = true;


                //Thanh chuc nang
                this.btDangNhap.Enabled = false;
                this.btDangXuat.Enabled = true;
                this.btPhanCongGiaoVien.Enabled = false;
                this.btPhanLopHocSinh.Enabled = false;
                this.btNhapDiem.Enabled = true;
                this.btTiepNhanHocSinh.Enabled = false;


                //TaskPanel
                this.tiDangNhap.Enabled = false;
                this.tiDangXuat.Enabled = true;
                this.tiNguoiDung.Enabled = false;
                this.tiDoiMatKhau.Enabled = true;

                this.tiQLHocSinh.Enabled = false;
                this.tiQLGiaoVien.Enabled = false;

                this.tiPhanCongGiaoVien.Enabled = false;
                this.tiPhanLopHocSinh.Enabled = false;
                this.tiNhapDiem.Enabled = true;

                this.tiTimHocSinh.Enabled = true;
                this.tiTimGiaoVien.Enabled = false;

                this.statusLabel.Text = "Tên đăng nhập: " + Utilities.TTNguoiDungDangNhap.TenNguoiDung + ".  Quyền: Giáo viên";

                return 3;
            }
           
            return 0;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.DangNhap();
        }


        /// <summary>
        ////////////////////////////////////////////////
        /// Task item
        
        private void tiDangNhap_Click(object sender, EventArgs e)
        {
            this.DangNhap();
        }

        private void tiDangXuat_Click(object sender, EventArgs e)
        {
            //Disable Dang nhap va Enable Dang xuat
            this.miDangNhap.Enabled = true;
            this.miDangXuat.Enabled = false;
            this.btDangNhap.Enabled = true;
            this.btDangXuat.Enabled = false;
            this.tiDangNhap.Enabled = true;
            this.tiDangXuat.Enabled = false;

            //Hien thi mac dinh (khong co nguoi dang nhap)
            this.DefaultShow();
        }

        private void tiNguoiDung_Click(object sender, EventArgs e)
        {
            if (this.frm_NguoiDung == null || this.frm_NguoiDung.IsDisposed)
            {
                frm_NguoiDung = new frmNguoiDung();
                frm_NguoiDung.MdiParent = this;
                frm_NguoiDung.Show();
            }
        }

        private void tiDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (this.frm_DoiMatKhau == null || this.frm_DoiMatKhau.IsDisposed)
            {
                frm_DoiMatKhau = new frmDoiMatKhau();
                frm_DoiMatKhau.MdiParent = this;
                frm_DoiMatKhau.Show();
            }
        }

        private void tiQLHocSinh_Click(object sender, EventArgs e)
        {
            if (this.frm_HocSinh == null || this.frm_HocSinh.IsDisposed)
            {
                frm_HocSinh = new frmHocSinh();
                frm_HocSinh.MdiParent = this;
                frm_HocSinh.Show();
            }
        }

        private void tiQLGiaoVien_Click(object sender, EventArgs e)
        {
            if (this.frm_GiaoVien == null || this.frm_GiaoVien.IsDisposed)
            {
                frm_GiaoVien = new frmGiaoVien();
                frm_GiaoVien.MdiParent = this;
                frm_GiaoVien.Show();
            }
        }

        private void tiPhanCongGiaoVien_Click(object sender, EventArgs e)
        {
            if (this.frm_PhanCong == null || this.frm_PhanCong.IsDisposed)
            {
                frm_PhanCong = new frmPhanCong();
                frm_PhanCong.MdiParent = this;
                frm_PhanCong.Show();
            }
        }

        private void tiPhanLopHocSinh_Click(object sender, EventArgs e)
        {
            if (this.frm_PhanLop == null || this.frm_PhanLop.IsDisposed)
            {
                frm_PhanLop = new frmPhanLop();
                frm_PhanLop.MdiParent = this;
                frm_PhanLop.Show();
            }
        }

        private void tiNhapDiem_Click(object sender, EventArgs e)
        {
            if (this.frm_NhapDiem == null || this.frm_NhapDiem.IsDisposed)
            {
                frm_NhapDiem = new frmNhapDiem();
                frm_NhapDiem.MdiParent = this;
                frm_NhapDiem.Show();
            }
        }

        private void tiTimHocSinh_Click(object sender, EventArgs e)
        {
            if (this.frm_TimHS == null || this.frm_TimHS.IsDisposed)
            {
                frm_TimHS = new frmTimHocSinh1();
                frm_TimHS.MdiParent = this;
                frm_TimHS.Show();
            }
        }

        private void tiTimGiaoVien_Click(object sender, EventArgs e)
        {
            if (this.frm_TimGV == null || this.frm_TimGV.IsDisposed)
            {
                frm_TimGV = new frmTimGiaoVien1();
                frm_TimGV.MdiParent = this;
                frm_TimGV.Show();
            }
        }

        ///////////////////////////////////////////////////////////
        //Menu Thong ke

        private void miDSGiaoVien_Click(object sender, EventArgs e)
        {
            if (this.frm_DSGiaoVien == null || this.frm_DSGiaoVien.IsDisposed)
            {
                frm_DSGiaoVien = new frmDSGiaoVien();
                frm_DSGiaoVien.MdiParent = this;
                frm_DSGiaoVien.Show();
            }
        }

        private void miDSHocSinh_Click(object sender, EventArgs e)
        {
            if (this.frm_DSHocSinh == null || this.frm_DSHocSinh.IsDisposed)
            {
                frm_DSHocSinh = new frmDSHocSinh_Lop();
                frm_DSHocSinh.MdiParent = this;
                frm_DSHocSinh.Show();
            }
        }

        private void miKQHKMonHoc_Click(object sender, EventArgs e)
        {
            rptFrmKQHK_MonHoc frm_KQHK_MH = new rptFrmKQHK_MonHoc();
            frm_KQHK_MH.Show();
        }

        

        

        

        
        

    }
}
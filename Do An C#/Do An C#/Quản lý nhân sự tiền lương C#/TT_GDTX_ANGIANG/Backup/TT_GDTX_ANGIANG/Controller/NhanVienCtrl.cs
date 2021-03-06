using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using System.Data;
using TT_GDTX_ANGIANG.BusinessObject;
using TT_GDTX_ANGIANG.DataLayer;
using System.Drawing;

namespace TT_GDTX_ANGIANG.Controller
{
    public class NhanVienCtrl
    {
        #region data_NhanVien
        private NhanVienData m_dataNhanVien;
        public NhanVienData data_NhanVien
        {
            get { return m_dataNhanVien; }
            set { m_dataNhanVien = value; }
        }
        #endregion

        #region data_PhongBan
        private PhongBanData m_dataPhongBan;
        public PhongBanData data_PhongBan
        {
            get { return m_dataPhongBan; }
            set { m_dataPhongBan = value; }
        }
        #endregion

        #region property
        private int m_row;
        public int MauTin
        {
            get { return m_row; }
            set { m_row = value; }
        }
        private string m_HinhAnh;
        public string Lay_HinhAnh
        {
            get { return m_HinhAnh; }
            set { m_HinhAnh = value; }
        }
        #endregion

        #region Table
        private DataTable m_Table;
        public DataTable Table
        {
            get { return m_Table; }
            set { m_Table = value; }
        }

        #endregion

        #region Create()
        public void Create(TextBox txtMaNV)
        {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            Table = data_NhanVien.lay_dsNhanVien();
            bool b = true;
            int i = 0;
            int t = 1;
            if (Table.Rows.Count == 0)
            {
                txtMaNV.Text = "NV1";
                return;
            }
            while (b)
            {
                string s1 = string.Concat("NV", t.ToString());
                if (Table.Rows[i][0].ToString() == s1)
                {
                    t++;
                    i = 0;
                    continue;
                }
                if (i == (Table.Rows.Count - 1))
                {
                    txtMaNV.Text = s1;
                    b = false;
                }
                i++;
            }
        }
        #endregion

        #region Add()
        public bool Add(NhanVienInfo info)
        {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            Table = data_NhanVien.lay_dsNhanVien();
            DataRow row = Table.NewRow();
            ///////////

            row["HINHANH"] = info.HinhAnh;

            ///////////////////////
            row["MANV"] = info.MaNhanVien;
            row["HOTEN"] = info.HoTen;
            row["BIDANH"] = info.BiDanh;
            row["GIOITINH"] = info.GioiTinh;
            row["NGAYSINH"] = info.NgaySinh;
            row["NOISINH"] = info.NoiSinh;
            row["CMND"] = info.ChungMinh;
            row["NGAYCAPCMND"] = info.NgayCapCMND;
            row["NOICAPCMND"] = info.NoiCapCMND;




            row["PHONGBAN"] = info.PhongBan.MaPhong;

            //row["SOQD"] = info.SoQuyetDinh;
            //row["NGAYVAOCQ"] = info.NgayVaoCQ;
            // row["CHUCVU"] = info.ChucVu.MaChucVu;       






            row["DANTOCNV"] = info.DanToc.MaDanToc;
            row["TONGIAONV"] = info.TonGiao.MaTonGiao;
            row["QUOCTICHNV"] = info.QuocTich.MaQuocTich;
            row["QUEQUAN"] = info.QueQuan;
            row["DIACHITHUONGTRU"] = info.DC_ThuongTru;
            row["NOIOHIENNAY"] = info.NoiOHienNay;
            row["DIENTHOAINHA"] = info.DienThoaiNha;
            row["DIENTHOAIDD"] = info.DienThoaiDiDong;
            row["EMAIL"] = info.Email;
            row["TINHTRANGHONNHAN"] = info.TinhTrangHonNhan;
            row["THANHPHANXUATTHAN"] = info.ThanhPhanXuatThan;
            row["DIENUUTIENGIADINH"] = info.UuTienGiaDinh;
            row["DIENUUTIENBANTHAN"] = info.UuTienBanThan;
            row["NANGKHIEU"] = info.NangKhieu;
            row["TINHTRANGSUCKHOE"] = info.TinhTrangSucKhoe;
            row["NHOMMAU"] = info.NhomMau;
            row["KHUYETTAT"] = info.KhuyetTat;

            //////
            row["SOQD"] = info.SoQuyetDinh;
            row["CONGVIECDUOCGIAO"] = info.CongViecDuocGiao;
            row["CONGVIECHIENNAY"] = info.CongViecHienNay;

            //////////////////////
            row["NGAYHOPDONG"] = info.NgayHopDong;
            row["NGAYVAOCOQUAN"] = info.NgayVaoCQ;
            row["NGAYVAONGANHGIAODUC"] = info.NgayVaoNganhGiaoDuc;
            row["NGAYTUYENDUNG"] = info.NgayTuyenDung;
            row["HINHTHUCTUYENDUNG"] = info.HinhThucTuyenDung;
            row["COQUANTUYENDUNG"] = info.CoQuanTuyenDung;
            row["NGAYVAODOAN"] = info.NgayVaoDoan;
            row["NOIVAODOAN"] = info.NoiVaoDoan;
            row["CHUCVUDOAN"] = info.ChucVuDoan;
            row["NGAYVAOCONGDOAN"] = info.NgayVaoCD;
            row["NOIVAOCONGDOAN"] = info.TenCD;
            row["CHUCVUCONGDOAN"] = info.ChucVuCD;
            row["NGAYVAODANG"] = info.NgayVaoDang;
            row["NGAYCHINHTHUCVAODANG"] = info.NgayCT_VaoDang;
            row["NOIVAODANG"] = info.NoiVaoDang;
            row["CHUCVUDANG"] = info.ChucVuDang;
            row["CHUCVU"] = info.ChucVu.MaChucVu;
            row["CHIEUCAO"] = info.ChieuCao;
            row["CANNANG"] = info.CanNang;





            ////
            row["TD_HOCVANNV"] = info.HocVanPhoThong.MaHocVan;
            row["DATOTNGHIEP"] = info.DaTotNghiep;
            row["TD_CHUYENMONCAONHAT"] = info.TD_ChuyenMonCaoNhat;
            row["NGANHDAOTAO"] = info.NganhDaoTao;
            row["CHUYENNGANHDAOTAO"] = info.ChuyenNganhDaoTao;
            row["NOIDAOTAO"] = info.NoiDaoTao;
            row["HINHTHUCDAOTAO"] = info.HinhThucDaoTao;
            row["NAMTOTNGHIEP"] = info.NamTotNghiep;
            row["TD_LYLUANCHINHTRI"] = info.TD_LyLuanChinhTri;
            row["TD_QUANLYNHANUOC"] = info.TD_QuanLyNhaNuoc;
            row["TD_QUANLYGIAODUC"] = info.TD_QuanLyGiaoDuc;
            row["NGOAINGUCHINHNV"] = info.NgoaiNgu.MaNgoaiNgu;
            row["TD_NGOAINGUNV"] = info.TD_NgoaiNgu.MaTrinhDoNgoaiNgu;
            row["TD_TINHOCNV"] = info.TD_TinHoc.MaTrinhDoTinHoc;
            row["NGOAINGUKHAC"] = info.NgoaiNguKhac;
            row["STATUS"] = info.Status;

            Table.Rows.Add(row);
            if (this.data_NhanVien.Update())
            {
                return true;
            }
            else
            {
                Table.Rows.Remove(row);
                return false;
            }
        }
        #endregion

        #region Update()
        public void Update(NhanVienInfo info, int index, string manv)
        {

            try
            {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            Table = data_NhanVien.lay_MaNhanVien(manv);

                this.Table.Rows[index]["HOTEN"] = info.HoTen;
                this.Table.Rows[index]["BIDANH"] = info.BiDanh;
                this.Table.Rows[index]["GIOITINH"] = info.GioiTinh;
                this.Table.Rows[index]["NGAYSINH"] = info.NgaySinh;
                this.Table.Rows[index]["NOISINH"] = info.NoiSinh;
                this.Table.Rows[index]["CMND"] = info.ChungMinh;
                this.Table.Rows[index]["NGAYCAPCMND"] = info.NgayCapCMND;
                this.Table.Rows[index]["NOICAPCMND"] = info.NoiCapCMND;
                this.Table.Rows[index]["PHONGBAN"] = info.PhongBan.MaPhong;


                this.Table.Rows[index]["NGAYCHINHTHUCVAODANG"] = info.NgayCT_VaoDang;
                this.Table.Rows[index]["NGAYTUYENDUNG"] = info.NgayTuyenDung;
                this.Table.Rows[index]["NGAYVAOCONGDOAN"] = info.NgayVaoCD;
                this.Table.Rows[index]["NGAYVAODANG"] = info.NgayVaoDang;
                this.Table.Rows[index]["NGAYVAODOAN"] = info.NgayVaoDoan;
                this.Table.Rows[index]["NGAYHOPDONG"] = info.NgayHopDong;
                this.Table.Rows[index]["NGAYVAOCOQUAN"] = info.NgayVaoCQ;
                this.Table.Rows[index]["NGAYVAONGANHGIAODUC"] = info.NgayVaoNganhGiaoDuc;

                this.Table.Rows[index]["CHUCVU"] = info.ChucVu.MaChucVu;
                this.Table.Rows[index]["CHIEUCAO"] = info.ChieuCao;
                this.Table.Rows[index]["CANNANG"] = info.CanNang;



                this.Table.Rows[index]["TINHTRANGHONNHAN"] = info.TinhTrangHonNhan;
                this.Table.Rows[index]["TINHTRANGSUCKHOE"] = info.TinhTrangSucKhoe;
                this.Table.Rows[index]["NHOMMAU"] = info.NhomMau;
                this.Table.Rows[index]["HINHTHUCDAOTAO"] = info.HinhThucDaoTao;
                this.Table.Rows[index]["DANTOCNV"] = info.DanToc.MaDanToc;
                this.Table.Rows[index]["TONGIAONV"] = info.TonGiao.MaTonGiao;
                this.Table.Rows[index]["QUOCTICHNV"] = info.QuocTich.MaQuocTich;
                this.Table.Rows[index]["QUEQUAN"] = info.QueQuan;
                this.Table.Rows[index]["DIACHITHUONGTRU"] = info.DC_ThuongTru;
                this.Table.Rows[index]["NOIOHIENNAY"] = info.NoiOHienNay;
                this.Table.Rows[index]["DIENTHOAINHA"] = info.DienThoaiNha;
                this.Table.Rows[index]["DIENTHOAIDD"] = info.DienThoaiDiDong;
                this.Table.Rows[index]["EMAIL"] = info.Email;
                ////
                this.Table.Rows[index]["KHUYETTAT"] = info.KhuyetTat;
                this.Table.Rows[index]["HINHTHUCTUYENDUNG"] = info.HinhThucTuyenDung;
                this.Table.Rows[index]["COQUANTUYENDUNG"] = info.CoQuanTuyenDung;
                this.Table.Rows[index]["NOIVAODOAN"] = info.NoiVaoDoan;
                this.Table.Rows[index]["CHUCVUDOAN"] = info.ChucVuDoan;
                this.Table.Rows[index]["NOIVAOCONGDOAN"] = info.TenCD;
                this.Table.Rows[index]["CHUCVUCONGDOAN"] = info.ChucVuCD;
                this.Table.Rows[index]["NOIVAODANG"] = info.NoiVaoDang;
                this.Table.Rows[index]["CHUCVUDANG"] = info.ChucVuDang;
                this.Table.Rows[index]["DATOTNGHIEP"] = info.DaTotNghiep;
                this.Table.Rows[index]["TD_CHUYENMONCAONHAT"] = info.TD_ChuyenMonCaoNhat;
                this.Table.Rows[index]["NGANHDAOTAO"] = info.NganhDaoTao;
                this.Table.Rows[index]["CHUYENNGANHDAOTAO"] = info.ChuyenNganhDaoTao;
                this.Table.Rows[index]["NOIDAOTAO"] = info.NoiDaoTao;
                this.Table.Rows[index]["TD_LYLUANCHINHTRI"] = info.TD_LyLuanChinhTri;
                this.Table.Rows[index]["TD_QUANLYNHANUOC"] = info.TD_QuanLyNhaNuoc;
                this.Table.Rows[index]["TD_QUANLYGIAODUC"] = info.TD_QuanLyGiaoDuc;
                this.Table.Rows[index]["NGOAINGUKHAC"] = info.NgoaiNguKhac;
                this.Table.Rows[index]["THANHPHANXUATTHAN"] = info.ThanhPhanXuatThan;
                this.Table.Rows[index]["DIENUUTIENGIADINH"] = info.UuTienGiaDinh;
                this.Table.Rows[index]["DIENUUTIENBANTHAN"] = info.UuTienBanThan;
                this.Table.Rows[index]["NANGKHIEU"] = info.NangKhieu;
                this.Table.Rows[index]["NGOAINGUCHINHNV"] = info.NgoaiNgu.MaNgoaiNgu;
                this.Table.Rows[index]["TD_HOCVANNV"] = info.HocVanPhoThong.MaHocVan;
                this.Table.Rows[index]["TD_NGOAINGUNV"] = info.TD_NgoaiNgu.MaTrinhDoNgoaiNgu;
                this.Table.Rows[index]["TD_TINHOCNV"] = info.TD_TinHoc.MaTrinhDoTinHoc;

                /////////////////////////

                this.Table.Rows[index]["SOQD"] = info.SoQuyetDinh;
                this.Table.Rows[index]["CONGVIECDUOCGIAO"] = info.CongViecDuocGiao;
                this.Table.Rows[index]["CONGVIECHIENNAY"] = info.CongViecHienNay;

                /////////

                this.Table.Rows[index]["HINHANH"] = info.HinhAnh;


                ////////////


                this.Table.Rows[index]["STATUS"] = info.Status;

           
            this.data_NhanVien.Update();
        }
        catch
        {
            MessageBoxEx.Show("Loading");
        }
        }
        #endregion

        #region HienThi_dsNhanVien()
        public void HienThi_dsNhanVien(ListView listView, string maPH, int trangthai)
        {
            if (data_NhanVien == null)
            {
                data_NhanVien = new NhanVienData();
            }
            if (data_PhongBan == null)
            {
                data_PhongBan = new PhongBanData();
            }

            Table = data_NhanVien.lay_dsNV_PH(maPH, trangthai);
            IEnumerator ie = Table.Rows.GetEnumerator();
            listView.Items.Clear();

            while (ie.MoveNext())
            {
                DataRow row = (DataRow)ie.Current;
                NhanVienInfo info = new NhanVienInfo();

                info.MaNhanVien = row["MANV"].ToString();
                info.HoTen = row["HOTEN"].ToString();
                info.BiDanh = row["BIDANH"].ToString();
                info.NgaySinh = (DateTime)row["NGAYSINH"];
                info.GioiTinh = int.Parse(row["GIOITINH"].ToString());
                info.NoiSinh = row["NOISINH"].ToString();
                info.ChungMinh = row["CMND"].ToString();
                info.NgayCapCMND = (DateTime)row["NGAYCAPCMND"];
                info.NoiCapCMND = row["NOICAPCMND"].ToString();



                info.HinhAnh = row["HINHANH"].ToString();
                try
                {
                    PhongBanCtrl ctrlPhongBan = new PhongBanCtrl();
                    info.PhongBan = ctrlPhongBan.GetPhongBan(row["PHONGBAN"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Phòng Ban", "Thông Báo");
                }

                try
                {
                    DanTocCtrl ctrlDT = new DanTocCtrl();
                    info.DanToc = ctrlDT.GetDanToc(row["DANTOCNV"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Dân Tộc", "Thông Báo");
                }

                try
                {
                    TonGiaoCtrl ctrlTG = new TonGiaoCtrl();
                    info.TonGiao = ctrlTG.GetTonGiao(row["TONGIAONV"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Tôn Giáo", "Thông Báo");
                }

                try
                {
                    QuocTichCtrl ctrlQT = new QuocTichCtrl();
                    info.QuocTich = ctrlQT.GetQuocTich(row["QUOCTICHNV"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Quốc Tịch", "Thông Báo");
                }

                try
                {
                    NgoaiNguCtrl ctrlNN = new NgoaiNguCtrl();
                    info.NgoaiNgu = ctrlNN.GetNgoaiNgu(row["NGOAINGUCHINHNV"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngoại Ngữ", "Thông Báo");
                }

                try
                {
                    TrinhDo_NgoaiNguCtrl ctrlTD_NN = new TrinhDo_NgoaiNguCtrl();
                    info.TD_NgoaiNgu = ctrlTD_NN.GetTrinhDoNgoaiNgu(row["TD_NGOAINGUNV"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Trình Độ Ngoại Ngữ", "Thông Báo");
                }

                try
                {
                    TrinhDo_TinHocCtrl ctrlTD_TH = new TrinhDo_TinHocCtrl();
                    info.TD_TinHoc = ctrlTD_TH.GetTrinhDoTinHoc(row["TD_TINHOCNV"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Trình Độ Tin Học", "Thông Báo");
                }

                try
                {
                    TrinhDo_HocVanCtrl ctrlTD_HocVan = new TrinhDo_HocVanCtrl();
                    info.HocVanPhoThong = ctrlTD_HocVan.GetTrinhDoHocVan(row["TD_HOCVANNV"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Trình Độ Học Vấn", "Thông Báo");
                }

                try
                {
                    info.QueQuan = row["QUEQUAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Quê Quán", "Thông Báo");
                }

                try
                {
                    info.DC_ThuongTru = row["DIACHITHUONGTRU"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Địa Chỉ Thường Trú", "Thông Báo");
                }

                try
                {
                    info.NoiOHienNay = row["NOIOHIENNAY"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Nơi Ở Hiện Nay", "Thông Báo");
                }

                try
                {
                    info.DienThoaiNha = row["DIENTHOAINHA"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Điện Thoại Nhà", "Thông Báo");
                }

                try
                {
                    info.DienThoaiDiDong = row["DIENTHOAIDD"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Điện Thoại Di Động", "Thông Báo");
                }

                try
                {
                    info.Email = row["EMAIL"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Email", "Thông Báo");
                }
                try
                {
                    info.TinhTrangHonNhan = row["TINHTRANGHONNHAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Tình Trạng Hôn Nhân", "Thông Báo");
                }

                try
                {
                    info.ThanhPhanXuatThan = row["THANHPHANXUATTHAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Thành Phần Xuất Thân", "Thông Báo");
                }

                try
                {
                    info.UuTienGiaDinh = row["DIENUUTIENGIADINH"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Diện Ưu Tiên Gia Đình", "Thông Báo");
                }

                try
                {
                    info.UuTienBanThan = row["DIENUUTIENBANTHAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Diện Ưu Tiên Bản Thân", "Thông Báo");
                }

                try
                {
                    info.NangKhieu = row["NANGKHIEU"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Năng Khiếu", "Thông Báo");
                }

                try
                {
                    info.TinhTrangSucKhoe = row["TINHTRANGSUCKHOE"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Tình Trạng Sức Khỏe", "Thông Báo");
                }

                try
                {
                    info.NhomMau = row["NHOMMAU"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Nhóm Máu", "Thông Báo");
                }

                try
                {
                    info.KhuyetTat = row["KHUYETTAT"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Khuyết Tật", "Thông Báo");
                }

                try
                {
                    info.HinhThucTuyenDung = row["HINHTHUCTUYENDUNG"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Hình Thức Tuyển Dụng", "Thông Báo");
                }

                try
                {
                    info.CoQuanTuyenDung = row["COQUANTUYENDUNG"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Cơ Quan Tuyển Dụng", "Thông Báo");
                }

                try
                {
                    info.NoiVaoDang = row["NOIVAODANG"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Nơi Vào Đảng", "Thông Báo");
                }
                try
                {
                    ChucVuCtrl ctrlChucVu = new ChucVuCtrl();
                    info.ChucVu = ctrlChucVu.GetChucVu(row["CHUCVU"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Chuc Vu", "Thông Báo");
                }
                try
                {
                    info.ChucVuDang = row["CHUCVUDANG"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Chức Vụ Đảng", "Thông Báo");
                }

                try
                {
                    info.ChucVuCD = row["CHUCVUCONGDOAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Chức Vụ Công Đoàn", "Thông Báo");
                }


                ////////////tab 3
                try
                {
                    info.DaTotNghiep = row["DATOTNGHIEP"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Đã Tốt Nghiệp", "Thông Báo");
                }
                ///////
                try
                {
                    info.TD_ChuyenMonCaoNhat = row["TD_CHUYENMONCAONHAT"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Trình Độ Chuyên Môn Cao Nhất", "Thông Báo");
                }
                ///////
                try
                {
                    info.NganhDaoTao = row["NGANHDAOTAO"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngành Đào Tạo", "Thông Báo");
                }

                try
                {
                    info.ChuyenNganhDaoTao = row["CHUYENNGANHDAOTAO"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Chuyên Ngành Đào Tạo", "Thông Báo");
                }

                try
                {
                    info.NoiDaoTao = row["NOIDAOTAO"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Nơi Đào Tạo", "Thông Báo");
                }

                try
                {
                    info.HinhThucDaoTao = row["HINHTHUCDAOTAO"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Hình Thức Đào Tạo", "Thông Báo");
                }

                try
                {
                    info.NamTotNghiep = row["NAMTOTNGHIEP"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Năm Tốt Nghiệp", "Thông Báo");
                }

                try
                {
                    info.TD_LyLuanChinhTri = row["TD_LYLUANCHINHTRI"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Trình Độ Lý Luận Chính Trị", "Thông Báo");
                }

                try
                {
                    info.TD_QuanLyNhaNuoc = row["TD_QUANLYNHANUOC"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Trình Độ Quản Lý Nhà Nước", "Thông Báo");
                }
                try
                {
                    info.TD_QuanLyGiaoDuc = row["TD_QUANLYGIAODUC"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Trình Độ Quản Lý Giáo Dục", "Thông Báo");
                }

                try
                {
                    info.NgoaiNguKhac = row["NGOAINGUKHAC"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngoại Ngữ Khác", "Thông Báo");
                }


                try
                {
                    info.ChieuCao = decimal.Parse(row["CHIEUCAO"].ToString());
                }
                catch
                {
                    info.ChieuCao = decimal.Parse("0");
                }

                try
                {
                    info.CanNang = decimal.Parse(row["CANNANG"].ToString());
                }
                catch
                {
                    info.CanNang = decimal.Parse("0");
                }



                ////

                ////
                try
                {
                    info.NgayVaoDoan = (DateTime)row["NGAYVAODOAN"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày Vào Đoàn");
                }
                try
                {
                    info.NgayHopDong = (DateTime)row["NGAYHOPDONG"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày hop dong");
                }

                try
                {
                    info.NgayVaoCQ = (DateTime)row["NGAYVAOCOQUAN"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày Co Quan");
                }

                try
                {
                    info.NgayVaoNganhGiaoDuc = (DateTime)row["NGAYVAONGANHGIAODUC"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày Vao Nganh Giao Duc");
                }

                try
                {
                    info.NgayTuyenDung = (DateTime)row["NGAYTUYENDUNG"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày Tuyển Dụng");
                }

                try
                {
                    info.NgayVaoDang = (DateTime)row["NGAYVAODANG"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày Vào Đảng");
                }

                try
                {
                    info.NgayCT_VaoDang = (DateTime)row["NGAYCHINHTHUCVAODANG"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày Chính Thức Vào Đảng");
                }

                try
                {
                    info.NgayVaoCD = (DateTime)row["NGAYVAOCONGDOAN"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày Vào Công Đoàn");
                }

                try
                {
                    info.NoiVaoDoan = row["NOIVAODOAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Nơi Vào Đoàn", "Thông Báo");
                }

                try
                {
                    info.ChucVuDoan = row["CHUCVUDOAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Chức Vụ Đoàn", "Thông Báo");
                }
                ////
                ////
                ////
                try
                {
                    info.TenCD = row["NOIVAOCONGDOAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Tên Công Đoàn", "Thông Báo");
                }

                /////////////////////////////////////////////
                try
                {
                    info.SoQuyetDinh = row["SOQD"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Số Quyết Định", "Thông Báo");
                }

                try
                {
                    info.CongViecDuocGiao = row["CONGVIECDUOCGIAO"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Công Việc Được Giao", "Thông Báo");
                }

                try
                {
                    info.CongViecHienNay = row["CONGVIECHIENNAY"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Công Việc Hiện Nay", "Thông Báo");
                }





                //info.NgayVaoCQ = (DateTime)row["NGAYVAOCQ"];
                //info.SoQuyetDinh = row["SOQD"].ToString();
                //info.ChucVu = row["CHUCVU"].ToString();




                try
                {
                    info.Status = int.Parse(row["STATUS"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Tính Trạng", "Thông Báo");
                }

                //Hien thi thong tin nhan vien len ListView
                ListViewItem item = new ListViewItem();
                item.Text = info.MaNhanVien;
                item.SubItems.Add(info.HoTen);
                item.SubItems.Add(info.NgaySinh.ToShortDateString());
                if (info.GioiTinh == 1)
                {
                    item.SubItems.Add("Nam");
                }
                else
                {
                    item.SubItems.Add("Nữ");
                }
                item.SubItems.Add(info.ChungMinh);


                item.Tag = info;

                listView.Items.Add(item);
            }
        }
        #endregion

        #region HienThi_dsTinhLuongNhanVien()
        public void HienThi_dsTinhLuongNhanVien(ListView listView,  int trangthai)
        {
            if (data_NhanVien == null)
            {
                data_NhanVien = new NhanVienData();
            }
            if (data_PhongBan == null)
            {
                data_PhongBan = new PhongBanData();
            }

            Table = data_NhanVien.lay_dsTinhLuongNhanVien( trangthai);
            IEnumerator ie = Table.Rows.GetEnumerator();
            listView.Items.Clear();

            while (ie.MoveNext())
            {
                DataRow row = (DataRow)ie.Current;
                NhanVienInfo info = new NhanVienInfo();

                info.MaNhanVien = row["MANV"].ToString();
                info.HoTen = row["HOTEN"].ToString();
                info.BiDanh = row["BIDANH"].ToString();
                info.NgaySinh = (DateTime)row["NGAYSINH"];
                info.GioiTinh = int.Parse(row["GIOITINH"].ToString());
                info.NoiSinh = row["NOISINH"].ToString();
                info.ChungMinh = row["CMND"].ToString();
                info.NgayCapCMND = (DateTime)row["NGAYCAPCMND"];
                info.NoiCapCMND = row["NOICAPCMND"].ToString();



                info.HinhAnh = row["HINHANH"].ToString();
                try
                {
                    PhongBanCtrl ctrlPhongBan = new PhongBanCtrl();
                    info.PhongBan = ctrlPhongBan.GetPhongBan(row["PHONGBAN"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Phòng Ban", "Thông Báo");
                }

                try
                {
                    DanTocCtrl ctrlDT = new DanTocCtrl();
                    info.DanToc = ctrlDT.GetDanToc(row["DANTOCNV"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Dân Tộc", "Thông Báo");
                }

                try
                {
                    TonGiaoCtrl ctrlTG = new TonGiaoCtrl();
                    info.TonGiao = ctrlTG.GetTonGiao(row["TONGIAONV"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Tôn Giáo", "Thông Báo");
                }

                try
                {
                    QuocTichCtrl ctrlQT = new QuocTichCtrl();
                    info.QuocTich = ctrlQT.GetQuocTich(row["QUOCTICHNV"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Quốc Tịch", "Thông Báo");
                }

                try
                {
                    NgoaiNguCtrl ctrlNN = new NgoaiNguCtrl();
                    info.NgoaiNgu = ctrlNN.GetNgoaiNgu(row["NGOAINGUCHINHNV"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngoại Ngữ", "Thông Báo");
                }

                try
                {
                    TrinhDo_NgoaiNguCtrl ctrlTD_NN = new TrinhDo_NgoaiNguCtrl();
                    info.TD_NgoaiNgu = ctrlTD_NN.GetTrinhDoNgoaiNgu(row["TD_NGOAINGUNV"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Trình Độ Ngoại Ngữ", "Thông Báo");
                }

                try
                {
                    TrinhDo_TinHocCtrl ctrlTD_TH = new TrinhDo_TinHocCtrl();
                    info.TD_TinHoc = ctrlTD_TH.GetTrinhDoTinHoc(row["TD_TINHOCNV"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Trình Độ Tin Học", "Thông Báo");
                }

                try
                {
                    TrinhDo_HocVanCtrl ctrlTD_HocVan = new TrinhDo_HocVanCtrl();
                    info.HocVanPhoThong = ctrlTD_HocVan.GetTrinhDoHocVan(row["TD_HOCVANNV"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Trình Độ Học Vấn", "Thông Báo");
                }

                try
                {
                    info.QueQuan = row["QUEQUAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Quê Quán", "Thông Báo");
                }

                try
                {
                    info.DC_ThuongTru = row["DIACHITHUONGTRU"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Địa Chỉ Thường Trú", "Thông Báo");
                }

                try
                {
                    info.NoiOHienNay = row["NOIOHIENNAY"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Nơi Ở Hiện Nay", "Thông Báo");
                }

                try
                {
                    info.DienThoaiNha = row["DIENTHOAINHA"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Điện Thoại Nhà", "Thông Báo");
                }

                try
                {
                    info.DienThoaiDiDong = row["DIENTHOAIDD"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Điện Thoại Di Động", "Thông Báo");
                }

                try
                {
                    info.Email = row["EMAIL"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Email", "Thông Báo");
                }
                try
                {
                    info.TinhTrangHonNhan = row["TINHTRANGHONNHAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Tình Trạng Hôn Nhân", "Thông Báo");
                }

                try
                {
                    info.ThanhPhanXuatThan = row["THANHPHANXUATTHAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Thành Phần Xuất Thân", "Thông Báo");
                }

                try
                {
                    info.UuTienGiaDinh = row["DIENUUTIENGIADINH"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Diện Ưu Tiên Gia Đình", "Thông Báo");
                }

                try
                {
                    info.UuTienBanThan = row["DIENUUTIENBANTHAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Diện Ưu Tiên Bản Thân", "Thông Báo");
                }

                try
                {
                    info.NangKhieu = row["NANGKHIEU"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Năng Khiếu", "Thông Báo");
                }

                try
                {
                    info.TinhTrangSucKhoe = row["TINHTRANGSUCKHOE"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Tình Trạng Sức Khỏe", "Thông Báo");
                }

                try
                {
                    info.NhomMau = row["NHOMMAU"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Nhóm Máu", "Thông Báo");
                }

                try
                {
                    info.KhuyetTat = row["KHUYETTAT"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Khuyết Tật", "Thông Báo");
                }

                try
                {
                    info.HinhThucTuyenDung = row["HINHTHUCTUYENDUNG"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Hình Thức Tuyển Dụng", "Thông Báo");
                }

                try
                {
                    info.CoQuanTuyenDung = row["COQUANTUYENDUNG"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Cơ Quan Tuyển Dụng", "Thông Báo");
                }

                try
                {
                    info.NoiVaoDang = row["NOIVAODANG"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Nơi Vào Đảng", "Thông Báo");
                }
                try
                {
                    ChucVuCtrl ctrlChucVu = new ChucVuCtrl();
                    info.ChucVu = ctrlChucVu.GetChucVu(row["CHUCVU"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Chuc Vu", "Thông Báo");
                }
                try
                {
                    info.ChucVuDang = row["CHUCVUDANG"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Chức Vụ Đảng", "Thông Báo");
                }

                try
                {
                    info.ChucVuCD = row["CHUCVUCONGDOAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Chức Vụ Công Đoàn", "Thông Báo");
                }


                ////////////tab 3
                try
                {
                    info.DaTotNghiep = row["DATOTNGHIEP"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Đã Tốt Nghiệp", "Thông Báo");
                }
                ///////
                try
                {
                    info.TD_ChuyenMonCaoNhat = row["TD_CHUYENMONCAONHAT"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Trình Độ Chuyên Môn Cao Nhất", "Thông Báo");
                }
                ///////
                try
                {
                    info.NganhDaoTao = row["NGANHDAOTAO"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngành Đào Tạo", "Thông Báo");
                }

                try
                {
                    info.ChuyenNganhDaoTao = row["CHUYENNGANHDAOTAO"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Chuyên Ngành Đào Tạo", "Thông Báo");
                }

                try
                {
                    info.NoiDaoTao = row["NOIDAOTAO"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Nơi Đào Tạo", "Thông Báo");
                }

                try
                {
                    info.HinhThucDaoTao = row["HINHTHUCDAOTAO"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Hình Thức Đào Tạo", "Thông Báo");
                }

                try
                {
                    info.NamTotNghiep = row["NAMTOTNGHIEP"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Năm Tốt Nghiệp", "Thông Báo");
                }

                try
                {
                    info.TD_LyLuanChinhTri = row["TD_LYLUANCHINHTRI"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Trình Độ Lý Luận Chính Trị", "Thông Báo");
                }

                try
                {
                    info.TD_QuanLyNhaNuoc = row["TD_QUANLYNHANUOC"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Trình Độ Quản Lý Nhà Nước", "Thông Báo");
                }
                try
                {
                    info.TD_QuanLyGiaoDuc = row["TD_QUANLYGIAODUC"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Trình Độ Quản Lý Giáo Dục", "Thông Báo");
                }

                try
                {
                    info.NgoaiNguKhac = row["NGOAINGUKHAC"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngoại Ngữ Khác", "Thông Báo");
                }


                try
                {
                    info.ChieuCao = decimal.Parse(row["CHIEUCAO"].ToString());
                }
                catch
                {
                    info.ChieuCao = decimal.Parse("0");
                }

                try
                {
                    info.CanNang = decimal.Parse(row["CANNANG"].ToString());
                }
                catch
                {
                    info.CanNang = decimal.Parse("0");
                }



                ////

                ////
                try
                {
                    info.NgayVaoDoan = (DateTime)row["NGAYVAODOAN"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày Vào Đoàn");
                }
                try
                {
                    info.NgayHopDong = (DateTime)row["NGAYHOPDONG"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày hop dong");
                }

                try
                {
                    info.NgayVaoCQ = (DateTime)row["NGAYVAOCOQUAN"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày Co Quan");
                }

                try
                {
                    info.NgayVaoNganhGiaoDuc = (DateTime)row["NGAYVAONGANHGIAODUC"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày Vao Nganh Giao Duc");
                }

                try
                {
                    info.NgayTuyenDung = (DateTime)row["NGAYTUYENDUNG"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày Tuyển Dụng");
                }

                try
                {
                    info.NgayVaoDang = (DateTime)row["NGAYVAODANG"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày Vào Đảng");
                }

                try
                {
                    info.NgayCT_VaoDang = (DateTime)row["NGAYCHINHTHUCVAODANG"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày Chính Thức Vào Đảng");
                }

                try
                {
                    info.NgayVaoCD = (DateTime)row["NGAYVAOCONGDOAN"];
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Ngày Vào Công Đoàn");
                }

                try
                {
                    info.NoiVaoDoan = row["NOIVAODOAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Nơi Vào Đoàn", "Thông Báo");
                }

                try
                {
                    info.ChucVuDoan = row["CHUCVUDOAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Chức Vụ Đoàn", "Thông Báo");
                }
                ////
                ////
                ////
                try
                {
                    info.TenCD = row["NOIVAOCONGDOAN"].ToString();
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Tên Công Đoàn", "Thông Báo");
                }







                //info.NgayVaoCQ = (DateTime)row["NGAYVAOCQ"];
                //info.SoQuyetDinh = row["SOQD"].ToString();
                //info.ChucVu = row["CHUCVU"].ToString();




                try
                {
                    info.Status = int.Parse(row["STATUS"].ToString());
                }
                catch
                {
                    MessageBoxEx.Show("Lỗi Tính Trạng", "Thông Báo");
                }

                //Hien thi thong tin nhan vien len ListView
                ListViewItem item = new ListViewItem();
                item.Text = info.MaNhanVien;
                item.SubItems.Add(info.HoTen);
                item.SubItems.Add(info.NgaySinh.ToShortDateString());
                if (info.GioiTinh == 1)
                {
                    item.SubItems.Add("Nam");
                }
                else
                {
                    item.SubItems.Add("Nữ");
                }
                item.SubItems.Add(info.ChungMinh);
                item.SubItems.Add(info.PhongBan.TenPhong);


                item.Tag = info;

                listView.Items.Add(item);
            }
        }
        #endregion

        #region Update_NhanVien()
        public void Update_NhanVien(String manv, int trangthai)
        {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            data_NhanVien.Update_NhanVien(manv, trangthai);
        }
        #endregion

        #region HienThiInfo()
        public void HienThiInfo(PictureBox hinhanh, NhanVienInfo info)
        {
            hinhanh.ImageLocation = info.HinhAnh;
            

        }
        #endregion

        #region Delete()
        public bool Delete(int index)
        {
            this.Table.Rows[index].Delete();

            return this.data_NhanVien.Update();
        }
        #endregion

        #region DeleteList()
        public void DeleteList(String manv)
        {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            data_NhanVien.DeleteList(manv);
        }
        #endregion

        #region TimCoSo()
        public void TimCoSo(String MaNV, DataGridView dg)
        {
            int dong = dg.RowCount;
            if (dong > 0)
            {
                for (int i = 0; i < dong - 1; i++)
                {
                    if (dg.Rows[i].Cells[0].Value.ToString().ToLower() == MaNV)
                    {
                        dg.Rows[i].Selected = true;
                        dg.FirstDisplayedScrollingRowIndex = i;
                        dg.CurrentCell = dg.Rows[i].Cells[0];
                        break;
                    }
                    else if (i == dong - 2)
                        MessageBox.Show("Không tìm thấy Mã nhân viên có mã số trên. Vui lòng nhập mã khác.", "THONG BAO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        #endregion       

        #region TimNV_NghiViec()
        public int TimNV_NghiViec(String manv, int trangthai)
        {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            DataTable dt = data_NhanVien.TimNV_NghiViec(manv, trangthai);
            if (dt.Rows.Count != 0)
            {
                return 1; //Ton tai nhan vien
            }
            else
            {
                return 0; //Khong ton tai ma nhan vien nay
            }
        }
        #endregion       

        #region KiemTra_MaNhanVien(String manv)
        public int KiemTra_MaNhanVien(String manv)
        {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            DataTable temp = data_NhanVien.lay_MaNhanVien(manv);
            if (temp.Rows.Count != 0)
            {
                return 1; //Ton tai nhan vien
            }
            else
            {
                return 0; //Khong ton tai ma nhan vien nay
            }
        }
        #endregion

        #region XoaNhanVien        
        
        public void XoaNhanVien(String nv)
        {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            data_NhanVien.XoaNhanVien(nv);
        }
        #endregion


        #region ThongKe_NhanVienTheoPhongBan()
        public void ThongKe_NhanVienTheoPhongBan(ComboBox cboPhongBan, int trangthai, DataGridView dg)
        {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            DataTable tb = data_NhanVien.ThongKe_NhanVienTheoPhongBan(cboPhongBan.SelectedValue.ToString(), trangthai);
            dg.DataSource = tb;
            MauTin = tb.Rows.Count;
        }
        #endregion

        #region ThongKe_TatCaNhanVien()
        public void ThongKe_TatCaNhanVien(int trangthai, DataGridView dg)
        {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            DataTable tb = data_NhanVien.ThongKe_TatCaNhanVien(trangthai);
            dg.DataSource = tb;
            MauTin = tb.Rows.Count;
        }
        #endregion


        #region ThongKe_NhanVienTren40TuoiTheoPhongBan()
        public void ThongKe_NhanVienTren40TuoiTheoPhongBan(ComboBox cboPhongBan, int trangthai, DataGridView dg)
        {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            DataTable tb = data_NhanVien.ThongKe_NhanVienTren40TuoiTheoPhongBan(cboPhongBan.SelectedValue.ToString(), trangthai);
            dg.DataSource = tb;
            MauTin = tb.Rows.Count;
        }
        #endregion

        #region ThongKe_TatCaNhanVienTren40Tuoi()
        public void ThongKe_TatCaNhanVienTren40Tuoi(int trangthai, DataGridView dg)
        {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            DataTable tb = data_NhanVien.ThongKe_TatCaNhanVienTren40Tuoi(trangthai);
            dg.DataSource = tb;
            MauTin = tb.Rows.Count;
        }
        #endregion

        #region ThongKe_NhanVienMoiPhongBanTheoTrinhDoHocVan()
        public void ThongKe_NhanVienMoiPhongBanTheoTrinhDoHocVan(ComboBox cboPhongBan, int trangthai, ComboBox cboChonHV, ComboBox cboHocVan, DataGridView dg)
        {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            DataTable tb = data_NhanVien.ThongKe_NhanVienMoiPhongBanTheoTrinhDoHocVan(cboPhongBan.SelectedValue.ToString(), trangthai, cboChonHV.Text, cboHocVan.SelectedValue.ToString());
            dg.DataSource = tb;
            MauTin = tb.Rows.Count;
        }
        #endregion

        #region ThongKe_TatCaNhanVienTheoTrinhDoHocVan()
        public void ThongKe_TatCaNhanVienTheoTrinhDoHocVan(int trangthai, ComboBox cboChonHV, ComboBox cboHocVan, DataGridView dg)
        {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            DataTable tb = data_NhanVien.ThongKe_TatCaNhanVienTheoTrinhDoHocVan(trangthai, cboChonHV.Text, cboHocVan.SelectedValue.ToString());
            dg.DataSource = tb;
            MauTin = tb.Rows.Count;
        }
        #endregion


        #region TraCuu_NhanVien()
        public void TraCuu_NhanVien(ComboBox cboPhongBan, int trangthai,ComboBox cboChonTENNV, TextBox txtTENNV,ComboBox cboChonCMND, TextBox txtCMND, ComboBox cboChonGT, int cboGioiTinh, ComboBox cboChonHV, ComboBox cboHocVan, ComboBox cboChonTH, ComboBox cboTinHoc, ComboBox cboChonNN, ComboBox cboNgoaiNgu, ComboBox cboTD_NgoaiNgu, DataGridView dg)
        {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            DataTable tb = data_NhanVien.TraCuu_NhanVien(cboPhongBan.SelectedValue.ToString(), trangthai, cboChonTENNV.Text, txtTENNV.Text, cboChonCMND.Text, txtCMND.Text, cboChonGT.Text, cboGioiTinh, cboChonHV.Text, cboHocVan.SelectedValue.ToString(), cboChonTH.Text, cboTinHoc.SelectedValue.ToString(), cboChonNN.Text, cboNgoaiNgu.SelectedValue.ToString(), cboTD_NgoaiNgu.SelectedValue.ToString());
            dg.DataSource = tb;
            MauTin = tb.Rows.Count;
        }
        #endregion        


       
    }
}

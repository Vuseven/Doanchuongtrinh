using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace TT_GDTX_ANGIANG.BusinessObject
{
    public class HoSoTuyenDungInfo
    {
        #region Constructor
        public HoSoTuyenDungInfo()
        {
        }

        
        public HoSoTuyenDungInfo(string maHS, string hoTen, string biDanh, int gTinh, DateTime ngaySinh, string noiSinh, string cmnd, DateTime ngayCapCMND, string noiCapCMND, String hinhAnh, DanTocInfo danToc, TonGiaoInfo tonGiao, QuocTichInfo quocTich, string queQuan, String dc_thuongtru, string noiOHienNay, string dienThoaiNha, string dienThoaiDD, string email, string tinhTrangHonNhan, string thanhPhanXuatThan, string uuTienGiaDinh, string uuTienBanThan, string nangKhieu, string tinhtrangSucKhoe, string nhomMau, decimal chieuCao, decimal canNang, string khuyetTat, DateTime ngayTuyenDung, string hinhThucTuyenDung, string coQuanTuyenDung,  ViTri_TuyenDungInfo viTriTuyenDung, DateTime ngayvaoDoan, string cvDoan, DateTime ngayvaoCD, string tenCD, string cvCongDoan, DateTime ngayvaoDang, DateTime ngayCT_vaodang, string cvDang, TrinhDo_HocVanInfo hocVanPhoThong, string daTotNghiep, string td_chuyenmoncaonhat, string nganhDaoTao, string chuyenNganhDaoTao, string noiDaoTao, string hinhThucDaoTao, string namTotNghiep, string td_lyLuanChinhTri, string td_quanLyNN, string td_quanlyGD, NgoaiNguInfo ngoaiNguChinh, TrinhDo_NgoaiNguInfo td_ngoaiNgu, string ngoaiNguKhac, TrinhDo_TinHocInfo td_tinHoc, int trangThai)
        {
            MaHoSo = maHS;
            HoTen = hoTen;
            BiDanh = biDanh;
            GioiTinh = gTinh;
            NgaySinh = ngaySinh;
            NoiSinh = noiSinh;            
            ChungMinh = cmnd;
            NgayCapCMND = ngayCapCMND;
            NoiCapCMND = noiCapCMND;
            HinhAnh = hinhAnh;


            DanToc = danToc;
            TonGiao = tonGiao;
            QuocTich = quocTich;
            QueQuan = queQuan;
            DC_ThuongTru = dc_thuongtru;
            NoiOHienNay = noiOHienNay;
            DienThoaiNha = dienThoaiNha;
            DienThoaiDiDong = dienThoaiDD;
            Email = email;
            TinhTrangHonNhan = tinhTrangHonNhan;
            ThanhPhanXuatThan = thanhPhanXuatThan;
            UuTienGiaDinh = uuTienGiaDinh;
            UuTienBanThan = uuTienBanThan;
            NangKhieu = nangKhieu;
            TinhTrangSucKhoe = tinhtrangSucKhoe;
            NhomMau = nhomMau;
            ChieuCao = chieuCao;
            CanNang = canNang;
            KhuyetTat = khuyetTat;


            NgayTuyenDung = ngayTuyenDung;
            HinhThucTuyenDung = hinhThucTuyenDung;
            CoQuanTuyenDung = coQuanTuyenDung;
            
            ViTriTuyen = viTriTuyenDung;                 
            NgayVaoDoan = ngayvaoDoan;           
            ChucVuDoan = cvDoan;            
            NgayVaoCD = ngayvaoCD;
            TenCD = tenCD;
            ChucVuCD = cvCongDoan;
            NgayVaoDang = ngayvaoDang;
            NgayCT_VaoDang = ngayCT_vaodang;
            ChucVuDang = cvDang;


            HocVanPhoThong = hocVanPhoThong;
            DaTotNghiep = daTotNghiep;
            TD_ChuyenMonCaoNhat = td_chuyenmoncaonhat;
            NganhDaoTao = nganhDaoTao;
            ChuyenNganhDaoTao = chuyenNganhDaoTao;
            NoiDaoTao = noiDaoTao;
            HinhThucDaoTao = hinhThucDaoTao;
            NamTotNghiep = namTotNghiep;
            TD_LyLuanChinhTri = td_lyLuanChinhTri;
            TD_QuanLyNhaNuoc = td_quanLyNN;
            TD_QuanLyGiaoDuc = td_quanlyGD;
            NgoaiNgu = ngoaiNguChinh;
            TD_NgoaiNgu = td_ngoaiNgu;
            NgoaiNguKhac = ngoaiNguKhac;
            TD_TinHoc = td_tinHoc;

            Status = trangThai;
        }
        #endregion

        #region MAHS
        private string m_MAHS;
        public string MaHoSo
        {
            get { return m_MAHS; }
            set { m_MAHS = value; }
        }
        #endregion

        #region HOTEN
        private string m_HOTEN;
        public string HoTen
        {
            get { return m_HOTEN; }
            set { m_HOTEN = value; }
        }
        #endregion

        #region BIDANH
        private string m_BIDANH;
        public string BiDanh
        {
            get { return m_BIDANH; }
            set { m_BIDANH = value; }
        }
        #endregion

        #region GIOITINH
        private int m_GIOITINH;
        public int GioiTinh
        {
            get { return m_GIOITINH; }
            set { m_GIOITINH = value; }
        }
        #endregion

        #region NGAYSINH
        private DateTime m_NGAYSINH;
        public DateTime NgaySinh
        {
            get { return m_NGAYSINH; }
            set { m_NGAYSINH = value; }
        }
        #endregion

        #region NOISINH
        private string m_NOISINH;
        public string NoiSinh
        {
            get { return m_NOISINH; }
            set { m_NOISINH = value; }
        }
        #endregion        

        #region CMND
        private string m_CMND;
        public string ChungMinh
        {
            get { return m_CMND; }
            set { m_CMND = value; }
        }
        #endregion

        #region NGAYCAPCMND
        private DateTime m_NGAYCAPCMND;
        public DateTime NgayCapCMND
        {
            get { return m_NGAYCAPCMND; }
            set { m_NGAYCAPCMND = value; }
        }
        #endregion

        #region HINHANH
        private String m_HINHANH;
        public String HinhAnh
        {
            get { return m_HINHANH; }
            set { m_HINHANH = value; }
        }
        #endregion


        /// <summary>
        /// Hêt Top
        /// </summary>

        #region NOICAPCMND
        private string m_NOICAPCMND;
        public string NoiCapCMND
        {
            get { return m_NOICAPCMND; }
            set { m_NOICAPCMND = value; }
        }
        #endregion

        #region DANTOC
        private DanTocInfo m_DANTOC;
        public DanTocInfo DanToc
        {
            get { return m_DANTOC; }
            set { m_DANTOC = value; }
        }
        #endregion

        #region TONGIAO
        private TonGiaoInfo m_TONGIAO;
        public TonGiaoInfo TonGiao
        {
            get { return m_TONGIAO; }
            set { m_TONGIAO = value; }
        }
        #endregion

        #region QUOCTICH
        private QuocTichInfo m_QUOCTICH;
        public QuocTichInfo QuocTich
        {
            get { return m_QUOCTICH; }
            set { m_QUOCTICH = value; }
        }
        #endregion

        #region QUEQUAN
        private string m_QUEQUAN;
        public string QueQuan
        {
            get { return m_QUEQUAN; }
            set { m_QUEQUAN = value; }
        }
        #endregion

        #region DCTHUONGTRU
        private String m_DCTHUONGTRU;
        public String DC_ThuongTru
        {
            get { return m_DCTHUONGTRU; }
            set { m_DCTHUONGTRU = value; }
        }
        #endregion

        #region NOIOHIENNAY
        private string m_NOIOHIENNAY;
        public string NoiOHienNay
        {
            get { return m_NOIOHIENNAY; }
            set { m_NOIOHIENNAY = value; }
        }
        #endregion

        #region DIENTHOAINHA
        private string m_DIENTHOAINHA;
        public string DienThoaiNha
        {
            get { return m_DIENTHOAINHA; }
            set { m_DIENTHOAINHA = value; }
        }
        #endregion

        #region DIENTHOAIDD
        private string m_DIENTHOAIDD;
        public string DienThoaiDiDong
        {
            get { return m_DIENTHOAIDD; }
            set { m_DIENTHOAIDD = value; }
        }
        #endregion

        #region EMAIL
        private string m_EMAIL;
        public string Email
        {
            get { return m_EMAIL; }
            set { m_EMAIL = value; }
        }
        #endregion

        #region TINHTRANGHONNHAN
        private string m_TINHTRANGHONNHAN;
        public string TinhTrangHonNhan
        {
            get { return m_TINHTRANGHONNHAN; }
            set { m_TINHTRANGHONNHAN = value; }
        }
        #endregion

        #region TPXUATTHAN
        private string m_TPXT;
        public string ThanhPhanXuatThan
        {
            get { return m_TPXT; }
            set { m_TPXT = value; }
        }
        #endregion

        #region UUTIENGIADINH
        private string m_UUTIENGIADINH;
        public string UuTienGiaDinh
        {
            get { return m_UUTIENGIADINH; }
            set { m_UUTIENGIADINH = value; }
        }
        #endregion

        #region UUTIENBANTHAN
        private string m_UUTIENBANTHAN;
        public string UuTienBanThan
        {
            get { return m_UUTIENBANTHAN; }
            set { m_UUTIENBANTHAN = value; }
        }
        #endregion

        #region NANGKHIEU
        private string m_NANGKHIEU;
        public string NangKhieu
        {
            get { return m_NANGKHIEU; }
            set { m_NANGKHIEU = value; }
        }
        #endregion

        #region TINHTRANGSUCKHOE
        private string m_TINHTRANGSUCKHOE;
        public string TinhTrangSucKhoe
        {
            get { return m_TINHTRANGSUCKHOE; }
            set { m_TINHTRANGSUCKHOE = value; }
        }
        #endregion

        #region NHOMMAU
        private string m_NHOMMAU;
        public string NhomMau
        {
            get { return m_NHOMMAU; }
            set { m_NHOMMAU = value; }
        }
        #endregion

        #region CHIEUCAO
        private decimal m_CHIEUCAO;
        public decimal ChieuCao
        {
            get { return m_CHIEUCAO; }
            set { m_CHIEUCAO = value; }
        }
        #endregion

        #region CANNANG
        private decimal m_CANNANG;
        public decimal CanNang
        {
            get { return m_CANNANG; }
            set { m_CANNANG = value; }
        }
        #endregion

        #region KHUYETTAT
        private string m_KHUYETTAT;
        public string KhuyetTat
        {
            get { return m_KHUYETTAT; }
            set { m_KHUYETTAT = value; }
        }
        #endregion

        /// <summary>
        /// Hết tab 1
        /// </summary>


        #region NGAYTUYENDUNG
        private DateTime m_NGAYTUYENDUNG;
        public DateTime NgayTuyenDung
        {
            get { return m_NGAYTUYENDUNG; }
            set { m_NGAYTUYENDUNG = value; }
        }
        #endregion       

        #region HINHTHUCTUYENDUNG
        private string m_HINHTHUCTUYENDUNG;
        public string HinhThucTuyenDung
        {
            get { return m_HINHTHUCTUYENDUNG; }
            set { m_HINHTHUCTUYENDUNG = value; }
        }
        #endregion

        #region COQUANTUYENDUNG
        private string m_COQUANTUYENDUNG;
        public string CoQuanTuyenDung
        {
            get { return m_COQUANTUYENDUNG; }
            set { m_COQUANTUYENDUNG = value; }
        }
        #endregion

      

        #region VITRITUYEN
        private ViTri_TuyenDungInfo m_VITRITUYEN;
        public ViTri_TuyenDungInfo ViTriTuyen
        {
            get { return m_VITRITUYEN; }
            set { m_VITRITUYEN = value; }
        }
        #endregion

        #region NGAYVAODOAN
        private DateTime m_NGAYVAODOAN;
        public DateTime NgayVaoDoan
        {
            get { return m_NGAYVAODOAN; }
            set { m_NGAYVAODOAN = value; }
        }
        #endregion

        #region NOIVAODOAN
        private string m_NOIVAODOAN;
        public string NoiVaoDoan
        {
            get { return m_NOIVAODOAN; }
            set { m_NOIVAODOAN = value; }
        }
        #endregion

        #region CHUCVUDOAN
        private string m_CHUCVUDOAN;
        public string ChucVuDoan
        {
            get { return m_CHUCVUDOAN; }
            set { m_CHUCVUDOAN = value; }
        }
        #endregion

        #region NGAYVAOCD
        private DateTime m_NGAYVAOCD;
        public DateTime NgayVaoCD
        {
            get { return m_NGAYVAOCD; }
            set { m_NGAYVAOCD = value; }
        }
        #endregion

        #region TENCD
        private string m_TENCD;
        public string TenCD
        {
            get { return m_TENCD; }
            set { m_TENCD = value; }
        }
        #endregion

        #region CHUCVUCD
        private string m_CHUCVUCD;
        public string ChucVuCD
        {
            get { return m_CHUCVUCD; }
            set { m_CHUCVUCD = value; }
        }
        #endregion

        #region NGAYVAODANG
        private DateTime m_NGAYVAODANG;
        public DateTime NgayVaoDang
        {
            get { return m_NGAYVAODANG; }
            set { m_NGAYVAODANG = value; }
        }
        #endregion

        #region NGAYCT_VAODANG
        private DateTime m_NGAYCT_VAODANG;
        public DateTime NgayCT_VaoDang
        {
            get { return m_NGAYCT_VAODANG; }
            set { m_NGAYCT_VAODANG = value; }
        }
        #endregion

        #region NOIVAODANG
        private string m_NOIVAODANG;
        public string NoiVaoDang
        {
            get { return m_NOIVAODANG; }
            set { m_NOIVAODANG = value; }
        }
        #endregion

        #region CHUCVUDANG
        private string m_CHUCVUDANG;
        public string ChucVuDang
        {
            get { return m_CHUCVUDANG; }
            set { m_CHUCVUDANG = value; }
        }
        #endregion


        /// <summary>
        /// Hết Tab 2
        /// </summary>

        
        #region HOCVANPHOTHONG
        private TrinhDo_HocVanInfo m_HOCVANPHOTHONG;
        public TrinhDo_HocVanInfo HocVanPhoThong
        {
            get { return m_HOCVANPHOTHONG; }
            set { m_HOCVANPHOTHONG = value; }
        }
        #endregion

        #region DATOTNGHIEP
        private string m_DATOTNGHIEP;
        public string DaTotNghiep
        {
            get { return m_DATOTNGHIEP; }
            set { m_DATOTNGHIEP = value; }
        }
        #endregion

        #region TD_CHUYENMONCAONHAT
        private string m_TD_CHUYENMONCAONHAT;
        public string TD_ChuyenMonCaoNhat
        {
            get { return m_TD_CHUYENMONCAONHAT; }
            set { m_TD_CHUYENMONCAONHAT = value; }
        }
        #endregion

        #region NGANHDAOTAO
        private string m_NGANHDAOTAO;
        public string NganhDaoTao
        {
            get { return m_NGANHDAOTAO; }
            set { m_NGANHDAOTAO = value; }
        }
        #endregion

        #region CHUYENGANHDAOTAO
        private string m_CHUYENNGANHDAOTAO;
        public string ChuyenNganhDaoTao
        {
            get { return m_CHUYENNGANHDAOTAO; }
            set { m_CHUYENNGANHDAOTAO = value; }
        }
        #endregion

        #region NOIDAOTAO
        private string m_NOIDAOTAO;
        public string NoiDaoTao
        {
            get { return m_NOIDAOTAO; }
            set { m_NOIDAOTAO = value; }
        }
        #endregion

        #region HINHTHUCDAOTAO
        private string m_HINHTHUCDAOTAO;
        public string HinhThucDaoTao
        {
            get { return m_HINHTHUCDAOTAO; }
            set { m_HINHTHUCDAOTAO = value; }
        }
        #endregion

        #region NAMTOTNGHIEP
        private string m_NAMTOTNGHIEP;
        public string NamTotNghiep
        {
            get { return m_NAMTOTNGHIEP; }
            set { m_NAMTOTNGHIEP = value; }
        }
        #endregion

        #region TD_LYLUANCHINHTRI
        private string m_TD_LYLUANCHINHTRI;
        public string TD_LyLuanChinhTri
        {
            get { return m_TD_LYLUANCHINHTRI; }
            set { m_TD_LYLUANCHINHTRI = value; }
        }
        #endregion

        #region TD_QUANLYNHANUOC
        private string m_TD_QUANLYNHANUOC;
        public string TD_QuanLyNhaNuoc
        {
            get { return m_TD_QUANLYNHANUOC; }
            set { m_TD_QUANLYNHANUOC = value; }
        }
        #endregion

        #region TD_QUANLYGIAODUC
        private string m_TD_QUANLYGIAODUC;
        public string TD_QuanLyGiaoDuc
        {
            get { return m_TD_QUANLYGIAODUC; }
            set { m_TD_QUANLYGIAODUC = value; }
        }
        #endregion

        #region NGOAINGU
        private NgoaiNguInfo m_NGOAINGU;
        public NgoaiNguInfo NgoaiNgu
        {
            get { return m_NGOAINGU; }
            set { m_NGOAINGU = value; }
        }
        #endregion      

        #region TD_NGOAINGU
        private TrinhDo_NgoaiNguInfo m_TD_NGOAINGU;
        public TrinhDo_NgoaiNguInfo TD_NgoaiNgu
        {
            get { return m_TD_NGOAINGU; }
            set { m_TD_NGOAINGU = value; }
        }
         #endregion

        #region NGOAINGUKHAC
        private string m_NGOAINGUKHAC;
        public string NgoaiNguKhac
        {
            get { return m_NGOAINGUKHAC; }
            set { m_NGOAINGUKHAC = value; }
        }
        #endregion      
                
        #region TD_TINHOC
        private TrinhDo_TinHocInfo m_TD_TINHOC;
        public TrinhDo_TinHocInfo TD_TinHoc
        {
            get { return m_TD_TINHOC; }
            set { m_TD_TINHOC = value; }
        }
        #endregion            
                   
        #region STATUS
        private int m_STATUS;
        public int Status
        {
            get { return m_STATUS; }
            set { m_STATUS = value; }
        }
        #endregion   

            

       
                
       
    }
}

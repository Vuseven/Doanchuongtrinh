using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TT_GDTX_ANGIANG.BusinessObject;
using TT_GDTX_ANGIANG.DataLayer;
using System.Collections;
using System.Windows.Forms;

namespace TT_GDTX_ANGIANG.Controller
{
    public class KetQuaTuyenDungCtrl
    {
        #region data_KetQua
        private KetQuaTuyenDungData m_dataKetQua;
        public KetQuaTuyenDungData data_KetQua
        {
            get { return m_dataKetQua; }
            set { m_dataKetQua = value; }
        }
        #endregion

        #region data_NhanVien
        private NhanVienData m_dataNhanVien;
        public NhanVienData data_NhanVien
        {
            get { return m_dataNhanVien; }
            set { m_dataNhanVien = value; }
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

        #region Add()
        public bool Add(KetQuaTuyenDungInfo info)
        {
            if (data_KetQua == null)
                data_KetQua = new KetQuaTuyenDungData();
            Table = data_KetQua.lay_dsKetQua_TuyenDung();

            DataRow row = Table.NewRow();
            row["MAHOSO"] = info.MaHoSo;            
            row["MANHANVIEN"] = info.MaNhanVien;
            row["PHONGBAN"] = info.PhongBan;
            info.BoPhan = new BoPhanInfo();
            //if (info.BoPhan.MaBoPhan == "")
            //{
            //    row["BOPHAN"] = DBNull.Value;
            //}
            //else
            //{
            //    row["BOPHAN"] = info.BoPhan.MaBoPhan;
            //}
            row["CHUCVU"] = info.ChucVu;
            row["SOQD"] = info.SoQuyetDinh;
            row["NGAYTD"] = info.NgayTuyenDung;           
            row["STATUS"] = info.Status;

            Table.Rows.Add(row);
            if (this.data_KetQua.Update())
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
        public void Update(KetQuaTuyenDungInfo info_KetQua, string maHS)
        {
            if (data_KetQua == null)
                data_KetQua = new KetQuaTuyenDungData();
            Table = data_KetQua.TestMaHoSo(maHS);
           
            //this.Table.Rows[0]["MANHANVIEN"] = info_KetQua.MaNhanVien;
            this.Table.Rows[0]["PHONGBAN"] = info_KetQua.PhongBan;
            //info_KetQua.DonVi = new DM_DonViInfo();
            if (info_KetQua.BoPhan.MaBoPhan == "")
            {
                this.Table.Rows[0]["BOPHAN"] = DBNull.Value;
            }
            else
            {
                this.Table.Rows[0]["BOPHAN"] = info_KetQua.BoPhan;
            }
            this.Table.Rows[0]["CHUCVU"] = info_KetQua.ChucVu;
            this.Table.Rows[0]["SOQD"] = info_KetQua.SoQuyetDinh;
            this.Table.Rows[0]["NGAYTD"] = info_KetQua.NgayTuyenDung;           
            this.Table.Rows[0]["STATUS"] = info_KetQua.Status;

            this.data_KetQua.Update();
        }
        #endregion

        #region KiemTra
        public void KiemTra(string MaHoSo, TextBox txtMaNV, ComboBox cboPhongBan, ComboBox cboChucVu, TextBox txtSoQD, DateTimePicker dateNgayTD)
        {
            if (data_KetQua == null)
                data_KetQua = new KetQuaTuyenDungData();
            DataTable dt = data_KetQua.KiemTra(MaHoSo);

            DataRow row = dt.Rows[0];
           
            txtMaNV.Text = row["MANHANVIEN"].ToString();
            cboPhongBan.Text = row["TENPH"].ToString();
           
            cboChucVu.Text = row["TENCV"].ToString();
            txtSoQD.Text = row["SOQD"].ToString();
            dateNgayTD.Value = (DateTime)row["NGAYTD"];
           
        }
        #endregion

        #region HienThi
        public void HienThi(string MaHoSo)
        {
            if (data_KetQua == null)
                data_KetQua = new KetQuaTuyenDungData();
            DataTable dt = data_KetQua.HienThi(MaHoSo);

            DataRow row = dt.Rows[0];
            
        }
        #endregion

        #region TestStatus()
        public int TestStatus(string maHS, int trangthai)
        {
            if (data_KetQua == null)
                data_KetQua = new KetQuaTuyenDungData();
            DataTable temp = data_KetQua.TestStatus(maHS, trangthai);
            if (temp.Rows.Count != 0)
            {
                return 1; //Ton tai
            }
            else
            {
                return 0; //Khong ton tai
            }
        }
        #endregion

        #region TestMaHoSo()
        public int TestMaHoSo(string maHS)
        {
            if (data_KetQua == null)
                data_KetQua = new KetQuaTuyenDungData();
            DataTable temp = data_KetQua.TestMaHoSo(maHS);
            if (temp.Rows.Count != 0)
            {
                return 1; //Ton tai
            }
            else
            {
                return 0; //Khong ton tai
            }
        }
        #endregion

        #region Add_NhanVien()
        public bool Add_NhanVien(HoSoTuyenDungInfo info_HoSo, KetQuaTuyenDungInfo info_KetQua)
        {
            if (data_NhanVien == null)
                data_NhanVien = new NhanVienData();
            Table = data_NhanVien.lay_dsNhanVien();

            DataRow row = Table.NewRow();

            row["MANV"] = info_KetQua.MaNhanVien;
            row["HOTEN"] = info_HoSo.HoTen;
            row["BIDANH"] = info_HoSo.BiDanh;
            row["GIOITINH"] = info_HoSo.GioiTinh;
            row["NGAYSINH"] = info_HoSo.NgaySinh;
            row["NOISINH"] = info_HoSo.NoiSinh;
            row["CMND"] = info_HoSo.ChungMinh;
            row["NGAYCAPCMND"] = info_HoSo.NgayCapCMND;
            row["NGAYCHINHTHUCVAODANG"] = info_HoSo.NgayCT_VaoDang;
            row["NGAYVAODANG"] = info_HoSo.NgayVaoDang;
            row["NGAYTUYENDUNG"] = info_HoSo.NgayTuyenDung;
            row["NGAYVAODOAN"] = info_HoSo.NgayVaoDoan;
            row["NGAYVAOCONGDOAN"] = info_HoSo.NgayVaoCD;
            row["NOICAPCMND"] = info_HoSo.NoiCapCMND;

            row["PHONGBAN"] = info_KetQua.PhongBan;



            //info_KetQua.BoPhan = new BoPhanInfo();

           // row["BOPHAN"] = info_KetQua.BoPhan.MaBoPhan;


            //row["SOQD"] = info_KetQua.SoQuyetDinh;
            row["NGAYTUYENDUNG"] = info_KetQua.NgayTuyenDung;
            row["CHUCVU"] = info_KetQua.ChucVu.MaChucVu;

            row["HINHANH"] = info_HoSo.HinhAnh;
            row["NGAYVAOCOQUAN"] = info_KetQua.NgayTuyenDung;
            row["NGAYVAONGANHGIAODUC"] = Convert.ToDateTime(System.DateTime.Today);
            row["NGAYHOPDONG"] = Convert.ToDateTime(System.DateTime.Today);
            ////////
            row["TINHTRANGHONNHAN"] = info_HoSo.TinhTrangHonNhan;
            row["TINHTRANGSUCKHOE"] = info_HoSo.TinhTrangSucKhoe;
            row["NHOMMAU"] = info_HoSo.NhomMau;
            row["HINHTHUCDAOTAO"] = info_HoSo.HinhThucDaoTao;
            row["DANTOCNV"] = info_HoSo.DanToc.MaDanToc;
            row["TONGIAONV"] = info_HoSo.TonGiao.MaTonGiao;
            row["QUOCTICHNV"] = info_HoSo.QuocTich.MaQuocTich;
            row["NGOAINGUCHINHNV"] = info_HoSo.NgoaiNgu.MaNgoaiNgu;
            row["TD_HOCVANNV"] = info_HoSo.HocVanPhoThong.MaHocVan;
            row["TD_NGOAINGUNV"] = info_HoSo.TD_NgoaiNgu.MaTrinhDoNgoaiNgu;
            row["TD_TINHOCNV"] = info_HoSo.TD_TinHoc.MaTrinhDoTinHoc;
            row["QUEQUAN"] = info_HoSo.QueQuan;
            row["DIACHITHUONGTRU"] = info_HoSo.DC_ThuongTru;
            row["NOIOHIENNAY"] = info_HoSo.NoiOHienNay;
            row["DIENTHOAINHA"] = info_HoSo.DienThoaiNha;
            row["DIENTHOAIDD"] = info_HoSo.DienThoaiDiDong;
            row["EMAIL"] = info_HoSo.Email;
            row["THANHPHANXUATTHAN"] = info_HoSo.ThanhPhanXuatThan;
            row["DIENUUTIENGIADINH"] = info_HoSo.UuTienGiaDinh;
            row["DIENUUTIENBANTHAN"] = info_HoSo.UuTienBanThan;
            row["NANGKHIEU"] = info_HoSo.NangKhieu;
            row["KHUYETTAT"] = info_HoSo.KhuyetTat;
            row["HINHTHUCTUYENDUNG"] = info_HoSo.HinhThucTuyenDung;
            row["COQUANTUYENDUNG"] = info_HoSo.CoQuanTuyenDung;
            row["NOIVAODOAN"] = info_HoSo.NoiVaoDoan;
            row["CHUCVUDOAN"] = info_HoSo.ChucVuDoan;
            row["NOIVAOCONGDOAN"] = info_HoSo.TenCD;
            row["CHUCVUCONGDOAN"] = info_HoSo.ChucVuCD;
            row["NOIVAODANG"] = info_HoSo.NoiVaoDang;
            row["CHUCVUDANG"] = info_HoSo.ChucVuDang;
            row["DATOTNGHIEP"] = info_HoSo.DaTotNghiep;
            row["TD_CHUYENMONCAONHAT"] = info_HoSo.TD_ChuyenMonCaoNhat;
            row["NGANHDAOTAO"] = info_HoSo.NganhDaoTao;
            row["CHUYENNGANHDAOTAO"] = info_HoSo.ChuyenNganhDaoTao;
            row["NOIDAOTAO"] = info_HoSo.NoiDaoTao;
            row["NAMTOTNGHIEP"] = info_HoSo.NamTotNghiep;
            row["TD_LYLUANCHINHTRI"] = info_HoSo.TD_LyLuanChinhTri;
            row["TD_QUANLYNHANUOC"] = info_HoSo.TD_QuanLyNhaNuoc;
            row["TD_QUANLYGIAODUC"] = info_HoSo.TD_QuanLyGiaoDuc;
            row["NGOAINGUKHAC"] = info_HoSo.NgoaiNguKhac;



            //row["HINHANH"] = info_HoSo.HinhAnh;


            row["STATUS"] = int.Parse("1");

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

        #region HienThi_dsTrungTuyen()
        public void HienThi_dsTrungTuyen(ListView listView, int trangthai)
        {
            if (data_KetQua == null)
            {
                data_KetQua = new KetQuaTuyenDungData();
            }
            Table = data_KetQua.lay_dsTrungTuyen(trangthai);

            IEnumerator ie = Table.Rows.GetEnumerator();
            listView.Items.Clear();

            while (ie.MoveNext())
            {
                DataRow row = (DataRow)ie.Current;
                KetQuaTuyenDungInfo info = new KetQuaTuyenDungInfo();

                ListViewItem item = new ListViewItem();
                item.Text = row["MAHOSO"].ToString();
                item.SubItems.Add(row["HOTEN"].ToString());
                string m_gioitinh = row["GIOITINH"].ToString();
                if (m_gioitinh == "1")
                {
                    item.SubItems.Add("Nam");
                }
                else
                {
                    item.SubItems.Add("Nữ");
                }
                item.SubItems.Add(row["MANHANVIEN"].ToString());
                item.SubItems.Add(row["TENPB"].ToString());
                //item.SubItems.Add(row["TENDV"].ToString());
                item.SubItems.Add(row["TENCV"].ToString());
                item.SubItems.Add(row["NGAYTD"].ToString());              

                listView.Items.Add(item);
            }
        }
        #endregion

        #region CapNhat()
        public void CapNhat(string maHS)
        {
            if (data_KetQua == null)
                data_KetQua = new KetQuaTuyenDungData();
            Table = data_KetQua.CapNhat(maHS);
        }
        #endregion

        #region DeleteMaHS()
        public void DeleteMaHS(String mahs)
        {
            if (data_KetQua == null)
                data_KetQua = new KetQuaTuyenDungData();
            data_KetQua.DeleteMaHS(mahs);
        }
        #endregion
    }
}

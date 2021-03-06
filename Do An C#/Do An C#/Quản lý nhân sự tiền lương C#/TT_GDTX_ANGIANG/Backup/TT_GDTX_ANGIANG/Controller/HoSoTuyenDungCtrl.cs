using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using DevComponents.DotNetBar;
using TT_GDTX_ANGIANG.BusinessObject;
using TT_GDTX_ANGIANG.DataLayer;
using System.Windows.Forms;
using System.Data;

namespace TT_GDTX_ANGIANG.Controller
{
    public class HoSoTuyenDungCtrl
    {
        #region data_HoSo_TuyenDung
        private HoSoTuyenDungData m_data_HoSo_TuyenDung;
        public HoSoTuyenDungData data_HoSo_TuyenDung
        {
            get { return m_data_HoSo_TuyenDung; }
            set { m_data_HoSo_TuyenDung = value; }
        }
       
        #endregion

        #region Property
        private HoSoTuyenDungInfo m_info;
        public HoSoTuyenDungInfo Info_HoSo
        {
            get { return m_info; }
            set { m_info = value; }
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


        #region HienThi_dsHoSo_KetQuaTuyenDung()
        public void HienThi_dsHoSo_KetQuaTuyenDung(ListView listView, int trangthai)
        {
            if (data_HoSo_TuyenDung == null)
            {
                data_HoSo_TuyenDung = new HoSoTuyenDungData();
            }
            Table = data_HoSo_TuyenDung.lay_dsHoSoTD_TheoMa(trangthai);
            IEnumerator ie = Table.Rows.GetEnumerator();
            listView.Items.Clear();

            while (ie.MoveNext())
            {
                DataRow row = (DataRow)ie.Current;
                HoSoTuyenDungInfo info = new HoSoTuyenDungInfo();

                info.MaHoSo = row["MAHS"].ToString();
                info.HoTen = row["HOTEN"].ToString();
                info.BiDanh = row["BIDANH"].ToString();
                info.GioiTinh = int.Parse(row["GIOITINH"].ToString());
                info.NgaySinh = (DateTime)row["NGAYSINH"];
                info.NoiSinh = row["NOISINH"].ToString();
                info.ChungMinh = row["CMND"].ToString();
                info.NgayCapCMND = (DateTime)row["NGAYCAPCMND"];
                info.NoiCapCMND = row["NOICAPCMND"].ToString();
               



                DanTocCtrl ctrlDT = new DanTocCtrl();
                info.DanToc = ctrlDT.GetDanToc(row["DANTOC"].ToString());

                TonGiaoCtrl ctrlTG = new TonGiaoCtrl();
                info.TonGiao = ctrlTG.GetTonGiao(row["TONGIAO"].ToString());

                QuocTichCtrl ctrlQT = new QuocTichCtrl();
                info.QuocTich = ctrlQT.GetQuocTich(row["QUOCTICH"].ToString());

                NgoaiNguCtrl ctrlNN = new NgoaiNguCtrl();
                info.NgoaiNgu = ctrlNN.GetNgoaiNgu(row["NGOAINGUCHINH"].ToString());



                ViTri_TuyenDungCtrl ctrlViTri = new ViTri_TuyenDungCtrl();
                info.ViTriTuyen = ctrlViTri.GetViTriTuyen(row["VITRITUYEN"].ToString());


                TrinhDo_HocVanCtrl ctrlTD_HocVan = new TrinhDo_HocVanCtrl();
                info.HocVanPhoThong = ctrlTD_HocVan.GetTrinhDoHocVan(row["TD_HOCVAN"].ToString());

                TrinhDo_NgoaiNguCtrl ctrlTD_NN = new TrinhDo_NgoaiNguCtrl();
                info.TD_NgoaiNgu = ctrlTD_NN.GetTrinhDoNgoaiNgu(row["TD_NGOAINGU"].ToString());

                TrinhDo_TinHocCtrl ctrlTD_TH = new TrinhDo_TinHocCtrl();
                info.TD_TinHoc = ctrlTD_TH.GetTrinhDoTinHoc(row["TD_TINHOC"].ToString());

                info.TinhTrangHonNhan = row["TINHTRANGHONNHAN"].ToString();
                info.QueQuan = row["QUEQUAN"].ToString();
                info.DC_ThuongTru = row["DIACHITHUONGTRU"].ToString();
                info.NoiOHienNay = row["NOIOHIENNAY"].ToString();
                info.DienThoaiNha = row["DIENTHOAINHA"].ToString();
                info.DienThoaiDiDong = row["DIENTHOAIDD"].ToString();
                info.Email = row["EMAIL"].ToString();
                info.TinhTrangHonNhan = row["TINHTRANGHONNHAN"].ToString();
                info.ThanhPhanXuatThan = row["THANHPHANXUATTHAN"].ToString();
                info.UuTienGiaDinh = row["DIENUUTIENGIADINH"].ToString();
                info.UuTienBanThan = row["DIENUUTIENBANTHAN"].ToString();
                info.NangKhieu = row["NANGKHIEU"].ToString();
                info.TinhTrangSucKhoe = row["TINHTRANGSUCKHOE"].ToString();
                info.NhomMau = row["NHOMMAU"].ToString();
                info.KhuyetTat = row["KHUYETTAT"].ToString();
                info.HinhThucTuyenDung = row["HINHTHUCTUYENDUNG"].ToString();
                info.CoQuanTuyenDung = row["COQUANTUYENDUNG"].ToString();
                info.NoiVaoDang = row["NOIVAODANG"].ToString();
                info.ChucVuDang = row["CHUCVUDANG"].ToString();
                info.ChucVuCD = row["CHUCVUCONGDOAN"].ToString();



               
                info.DaTotNghiep = row["DATOTNGHIEP"].ToString();
                info.TD_ChuyenMonCaoNhat = row["TD_CHUYENMONCAONHAT"].ToString();
                info.NganhDaoTao = row["NGANHDAOTAO"].ToString();
                info.ChuyenNganhDaoTao = row["CHUYENNGANHDAOTAO"].ToString();
                info.NoiDaoTao = row["NOIDAOTAO"].ToString();
                info.HinhThucDaoTao = row["HINHTHUCDAOTAO"].ToString();
                info.NamTotNghiep = row["NAMTOTNGHIEP"].ToString();
                info.TD_LyLuanChinhTri = row["TD_LYLUANCHINHTRI"].ToString();
                info.TD_QuanLyNhaNuoc = row["TD_QUANLYNHANUOC"].ToString();
                info.TD_QuanLyGiaoDuc = row["TD_QUANLYGIAODUC"].ToString();
                info.NgoaiNguKhac = row["NGOAINGUKHAC"].ToString();


                info.ChieuCao = decimal.Parse(row["CHIEUCAO"].ToString());
                info.CanNang = decimal.Parse(row["CANNANG"].ToString()); 

                info.NgayTuyenDung = (DateTime)row["NGAYTUYENDUNG"];

                info.NgayVaoDoan = (DateTime)row["NGAYVAODOAN"];
                info.NoiVaoDoan = row["NOIVAODOAN"].ToString();
                info.ChucVuDoan = row["CHUCVUDOAN"].ToString();
                info.NgayVaoDang = (DateTime)row["NGAYVAODANG"];
                info.NgayCT_VaoDang = (DateTime)row["NGAYCHINHTHUCVAODANG"];
                info.NgayVaoCD = (DateTime)row["NGAYVAOCONGDOAN"];
                info.TenCD = row["NOIVAOCONGDOAN"].ToString();

                info.HinhAnh = row["HINHANH"].ToString();

                             
                info.Status = int.Parse(row["STATUS"].ToString());

                //Hien thi thong tin Ho so tuyen dung len ListView
                ListViewItem item = new ListViewItem();
                item.Text = info.MaHoSo;
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
                
                
                item.Tag = info;

                listView.Items.Add(item);
            }
        }
        #endregion      

        #region Add()
        public bool Add(HoSoTuyenDungInfo info)
        {
            if (data_HoSo_TuyenDung == null)
            {
                data_HoSo_TuyenDung = new HoSoTuyenDungData();
            }
            Table = data_HoSo_TuyenDung.lay_dsHoSo_TuyenDung();
            DataRow row = Table.NewRow();
            

            row["MAHS"] = info.MaHoSo;
            row["HOTEN"] = info.HoTen;
            row["BIDANH"] = info.BiDanh;
            row["GIOITINH"] = info.GioiTinh;
            row["NGAYSINH"] = info.NgaySinh;
            row["NOISINH"] = info.NoiSinh;
            row["CMND"] = info.ChungMinh;
            row["NGAYCAPCMND"] = info.NgayCapCMND;
            row["NGAYCHINHTHUCVAODANG"] = info.NgayCT_VaoDang;
            row["NGAYVAODANG"] = info.NgayVaoDang;  
            row["NGAYTUYENDUNG"] = info.NgayTuyenDung;
            row["NGAYVAODOAN"] = info.NgayVaoDoan;
            row["NGAYVAOCONGDOAN"] = info.NgayVaoCD;
            row["NOICAPCMND"] = info.NoiCapCMND;
           
               //row["HINHANH"] =  null;
            row["TINHTRANGHONNHAN"] = info.TinhTrangHonNhan;
            row["TINHTRANGSUCKHOE"] = info.TinhTrangSucKhoe;
            row["NHOMMAU"] = info.NhomMau;
            row["HINHTHUCDAOTAO"] = info.HinhThucDaoTao;

            ////////

            row["HINHANH"] = info.HinhAnh;

            //////////
            row["DANTOC"] = info.DanToc.MaDanToc;
            row["TONGIAO"] = info.TonGiao.MaTonGiao;
            row["QUOCTICH"] = info.QuocTich.MaQuocTich;
            row["VITRITUYEN"] = info.ViTriTuyen.MaVTTD;
            row["NGOAINGUCHINH"] = info.NgoaiNgu.MaNgoaiNgu;
            row["QUEQUAN"] = info.QueQuan;
            row["DIACHITHUONGTRU"] = info.DC_ThuongTru;
            row["NOIOHIENNAY"] = info.NoiOHienNay;
            row["DIENTHOAINHA"] = info.DienThoaiNha;
            row["DIENTHOAIDD"] = info.DienThoaiDiDong;
            row["EMAIL"] = info.Email;
            row["THANHPHANXUATTHAN"] = info.ThanhPhanXuatThan;
            row["DIENUUTIENGIADINH"] = info.UuTienGiaDinh;
            row["DIENUUTIENBANTHAN"] = info.UuTienBanThan;
            row["NANGKHIEU"] = info.NangKhieu;
            row["KHUYETTAT"] = info.KhuyetTat;
            row["HINHTHUCTUYENDUNG"] = info.HinhThucTuyenDung;
            row["COQUANTUYENDUNG"] = info.CoQuanTuyenDung;
            row["NOIVAODOAN"] = info.NoiVaoDoan;
            row["CHUCVUDOAN"] = info.ChucVuDoan;
            row["NOIVAOCONGDOAN"] = info.TenCD;
            row["CHUCVUCONGDOAN"] = info.ChucVuCD;
            row["NOIVAODANG"] = info.NoiVaoDang;
            row["CHUCVUDANG"] = info.ChucVuDang;
            row["DATOTNGHIEP"] = info.DaTotNghiep;
            row["TD_CHUYENMONCAONHAT"] = info.TD_ChuyenMonCaoNhat;
            row["NGANHDAOTAO"] = info.NganhDaoTao;
            row["CHUYENNGANHDAOTAO"] = info.ChuyenNganhDaoTao;
            row["NOIDAOTAO"] = info.NoiDaoTao;
            row["NAMTOTNGHIEP"] = info.NamTotNghiep;
            row["TD_LYLUANCHINHTRI"] = info.TD_LyLuanChinhTri;
            row["TD_QUANLYNHANUOC"] = info.TD_QuanLyNhaNuoc;
            row["TD_QUANLYGIAODUC"] = info.TD_QuanLyGiaoDuc;
            row["NGOAINGUKHAC"] = info.NgoaiNguKhac;
            row["STATUS"] = info.Status;        
            row["TD_NGOAINGU"]=info.TD_NgoaiNgu.MaTrinhDoNgoaiNgu;
            row["TD_TINHOC"] = info.TD_TinHoc.MaTrinhDoTinHoc;
            row["TD_HOCVAN"] = info.HocVanPhoThong.MaHocVan;
            row["CHIEUCAO"] = info.ChieuCao;
            row["CANNANG"] = info.CanNang; 

            


            Table.Rows.Add(row);
            if (this.data_HoSo_TuyenDung.Update())
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
        public void Update(HoSoTuyenDungInfo info, int index)
        {
            if (data_HoSo_TuyenDung == null)
            {
                data_HoSo_TuyenDung = new HoSoTuyenDungData();
            }
            Table = data_HoSo_TuyenDung.lay_dsHoSo_TuyenDung();

            //this.Table.Rows[index]["MAHS"] = info.MaHoSo;

            ////
            this.Table.Rows[index]["HINHANH"] = info.HinhAnh;



            ///////////////////
            this.Table.Rows[index]["CHIEUCAO"] = info.ChieuCao;
            this.Table.Rows[index]["CANNANG"] = info.CanNang;
            this.Table.Rows[index]["HOTEN"] = info.HoTen;
            this.Table.Rows[index]["BIDANH"] = info.BiDanh;
            this.Table.Rows[index]["GIOITINH"] = info.GioiTinh;
            this.Table.Rows[index]["NGAYSINH"] = info.NgaySinh;
            this.Table.Rows[index]["NOISINH"] = info.NoiSinh;
            this.Table.Rows[index]["CMND"] = info.ChungMinh;
            this.Table.Rows[index]["NGAYCAPCMND"] = info.NgayCapCMND;
            this.Table.Rows[index]["NGAYCHINHTHUCVAODANG"] = info.NgayCT_VaoDang;
            this.Table.Rows[index]["NGAYTUYENDUNG"] = info.NgayTuyenDung;
            this.Table.Rows[index]["NGAYVAOCONGDOAN"] = info.NgayVaoCD;
            this.Table.Rows[index]["NGAYVAODANG"] = info.NgayVaoDang;
            this.Table.Rows[index]["NGAYVAODOAN"] = info.NgayVaoDoan;
            this.Table.Rows[index]["NOICAPCMND"] = info.NoiCapCMND;
            this.Table.Rows[index]["TINHTRANGHONNHAN"] = info.TinhTrangHonNhan;
            this.Table.Rows[index]["TINHTRANGSUCKHOE"] = info.TinhTrangSucKhoe;
            this.Table.Rows[index]["NHOMMAU"] = info.NhomMau;
            this.Table.Rows[index]["HINHTHUCDAOTAO"] = info.HinhThucDaoTao;
            this.Table.Rows[index]["DANTOC"] = info.DanToc.MaDanToc;
            this.Table.Rows[index]["TONGIAO"] = info.TonGiao.MaTonGiao;
            this.Table.Rows[index]["QUOCTICH"] = info.QuocTich.MaQuocTich;
            this.Table.Rows[index]["VITRITUYEN"] = info.ViTriTuyen.MaVTTD;
            this.Table.Rows[index]["QUEQUAN"] = info.QueQuan;
            this.Table.Rows[index]["DIACHITHUONGTRU"] = info.DC_ThuongTru;
            this.Table.Rows[index]["NOIOHIENNAY"] = info.NoiOHienNay;
            this.Table.Rows[index]["DIENTHOAINHA"] = info.DienThoaiNha;
            this.Table.Rows[index]["DIENTHOAIDD"] = info.DienThoaiDiDong;
            this.Table.Rows[index]["EMAIL"] = info.Email;
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
            this.Table.Rows[index]["NGOAINGUCHINH"] = info.NgoaiNgu.MaNgoaiNgu;
            this.Table.Rows[index]["TD_NGOAINGU"] = info.TD_NgoaiNgu.MaTrinhDoNgoaiNgu;
            this.Table.Rows[index]["TD_TINHOC"] = info.TD_TinHoc.MaTrinhDoTinHoc;
            this.Table.Rows[index]["TD_HOCVAN"] = info.HocVanPhoThong.MaHocVan;

            this.Table.Rows[index]["STATUS"] = info.Status;
            


            this.data_HoSo_TuyenDung.Update();
        }
        #endregion

        #region Delete()
        public bool Delete(int index)
        {
            this.Table.Rows[index].Delete();

            return this.data_HoSo_TuyenDung.Update();
        }
        #endregion

        #region DeleteList()
        public void DeleteList(String mahs)
        {
            if (data_HoSo_TuyenDung == null)
                data_HoSo_TuyenDung = new HoSoTuyenDungData();
            data_HoSo_TuyenDung.DeleteList(mahs);
        }
        #endregion

        #region Create()
        public void Create(TextBox txtMaDV)
        {
            if (data_HoSo_TuyenDung == null)
            {
                data_HoSo_TuyenDung = new HoSoTuyenDungData();
            }
            Table = data_HoSo_TuyenDung.lay_dsHoSo_TuyenDung_total();
            bool b = true;
            int i = 0;
            int t = 1;
            if (Table.Rows.Count == 0)
            {
                txtMaDV.Text = "MHS1";
                return;
            }
            while (b)
            {
                string s1 = string.Concat("MHS", t.ToString());
                if (Table.Rows[i][0].ToString() == s1)
                {
                    t++;
                    i = 0;
                    continue;
                }
                if (i == (Table.Rows.Count - 1))
                {
                    txtMaDV.Text = s1;
                    b = false;
                }
                i++;
            }
        }
        #endregion

        #region Update_UngCuVien()
        public void Update_UngCuVien(String mahs, int trangthai)
        {
            if (data_HoSo_TuyenDung == null)
                data_HoSo_TuyenDung = new HoSoTuyenDungData();
            data_HoSo_TuyenDung.Update_UngCuVien(mahs, trangthai);
        }
        #endregion
       

        #region HienThiComboBox()
        DanTocData data_dantoc = new DanTocData();
        public void HienThiComboBoxDanToc(ComboBox cbodantoc)
        {
            //cmbDVT.DataSource = donViTinhData.LayBangDonViTinh();
            //cmbDVT.DisplayMember = "TEN_DVT";
            //cmbDVT.ValueMember = "MA_DVT";
            cbodantoc.DataSource = data_dantoc.lay_dsDanToc();
            cbodantoc.DisplayMember = "TENDT";
            cbodantoc.ValueMember = "MADT";
            
        }
        #endregion     

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using TT_GDTX_ANGIANG.BusinessObject;
using TT_GDTX_ANGIANG.DataLayer;
namespace TT_GDTX_ANGIANG.Controller
{
    public class LuongNhanVienCtrl
    {
        #region data_LuongNhanVien
        private LuongNhanVienData m_data_LuongNhanVien;
        public LuongNhanVienData data_LuongNhanVien
        {
            get { return m_data_LuongNhanVien; }
            set { m_data_LuongNhanVien = value; }
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

        #region HienThi_dsLuongNhanVien()
        public void HienThi_dsLuongNhanVien(ListView listView, string manv)
        {
            if (data_LuongNhanVien == null)
            {
                data_LuongNhanVien = new LuongNhanVienData();
            }
            Table = data_LuongNhanVien.lay_dsLuongNhanVien(manv);
            IEnumerator ie = Table.Rows.GetEnumerator();
            listView.Items.Clear();

            while (ie.MoveNext())
            {
                #region row 
                DataRow row = (DataRow)ie.Current;
                LươngNhanVienInfo info = new LươngNhanVienInfo();



                info.MaLuong = row["MALNV"].ToString();
                info.TenNgach = row["TENNGACH"].ToString();
                info.BacLuong = int.Parse(row["BACLUONG"].ToString());
                info.HeSoLuong = float.Parse(row["HESOLUONG"].ToString());
                info.LuongCoBan = float.Parse(row["LUONGCOBAN"].ToString());
                info.NgayBatDau = (DateTime)row["NGAYBD"];
                info.NgayKetThuc = (DateTime)row["NGAYKT"];
                info.HeSoPCChucVu = float.Parse(row["HSPCCHUCVU"].ToString());
                info.Luong = float.Parse(row["LUONG"].ToString());
                info.TruCacKhoan = float.Parse(row["TRUCACKHOAN"].ToString());
                info.LuongConLai = float.Parse(row["LUONGCONLAI"].ToString());
                info.DangPhi = float.Parse(row["DANGPHI"].ToString());
                info.LuongThucLanh = float.Parse(row["LUONGTHUCLANH"].ToString());
                info.GiaoVien = float.Parse(row["GIAOVIEN"].ToString());
                info.ChonGiaoVien = int.Parse(row["CHONGV"].ToString());
                info.NhanVienVanPhong = float.Parse(row["NVVANPHONG"].ToString());
                info.ChonNhanVienVanPhong = int.Parse(row["CHONNVVP"].ToString());
                info.ChonThuViec = int.Parse(row["CHONTHUVIEC"].ToString());
                info.Chon2Nam = Convert.ToInt16(row["CHON2NAM"].ToString());
                info.Chon3Nam = Convert.ToInt16(row["CHON3NAM"].ToString());

                ListViewItem item = new ListViewItem();

                item.Text = info.MaLuong;
                item.SubItems.Add(info.Luong.ToString());
                item.SubItems.Add(info.TruCacKhoan.ToString());
                item.SubItems.Add(info.LuongConLai.ToString());
                //if (info.Chon2Nam == 0)
                //{
                //    item.SubItems.Add("");
                //}
                //else
                //{
                //    item.SubItems.Add(info.Chon2Nam.ToString());
                //}
                //if (info.Chon3Nam == 0)
                //{
                //    item.SubItems.Add("");
                //}
                //else
                //{
                //    item.SubItems.Add(info.Chon3Nam.ToString());
                //}
                if (info.GiaoVien == 0)
                {
                    item.SubItems.Add("");
                }
                else
                {
                    item.SubItems.Add(info.GiaoVien.ToString());
                }
                if (info.NhanVienVanPhong == 0)
                {
                    item.SubItems.Add("");
                }
                else
                {
                    item.SubItems.Add(info.NhanVienVanPhong.ToString());
                }
                if (info.DangPhi == 0)
                {
                    item.SubItems.Add("");
                }
                else
                {
                    item.SubItems.Add(info.DangPhi.ToString());
                }

                item.SubItems.Add(info.LuongThucLanh.ToString());

                item.Tag = info;

                listView.Items.Add(item);
                #endregion
            }
        }
        #endregion

        #region HienThi_dsLuongNhanVienDS()
        public void HienThi_dsLuongNhanVienDS(ListView listView)
        {
            if (data_LuongNhanVien == null)
            {
                data_LuongNhanVien = new LuongNhanVienData();
            }
            Table = data_LuongNhanVien.lay_dsLuongNhanVienListLuong();
            IEnumerator ie = Table.Rows.GetEnumerator();
            listView.Items.Clear();

            while (ie.MoveNext())
            {
                #region row
                DataRow row = (DataRow)ie.Current;
                LươngNhanVienInfo info = new LươngNhanVienInfo();
                NhanVienInfo infonv = new NhanVienInfo();



                info.MaLuong = row["MALNV"].ToString();
                
                //info.TenNgach = row["TENNGACH"].ToString();
                //info.BacLuong = int.Parse(row["BACLUONG"].ToString());
                //info.HeSoLuong = float.Parse(row["HESOLUONG"].ToString());
                //info.LuongCoBan = float.Parse(row["LUONGCOBAN"].ToString());
                //info.NgayBatDau = (DateTime)row["NGAYBD"];
                //info.NgayKetThuc = (DateTime)row["NGAYKT"];
                //info.HeSoPCChucVu = float.Parse(row["HSPCCHUCVU"].ToString());
                info.Luong = float.Parse(row["LUONG"].ToString());
                info.TruCacKhoan = float.Parse(row["TRUCACKHOAN"].ToString());
                info.LuongConLai = float.Parse(row["LUONGCONLAI"].ToString());
                info.DangPhi = float.Parse(row["DANGPHI"].ToString());
                info.LuongThucLanh = float.Parse(row["LUONGTHUCLANH"].ToString());
                info.GiaoVien = float.Parse(row["GIAOVIEN"].ToString());
                //info.ChonGiaoVien = int.Parse(row["CHONGV"].ToString());
                info.NhanVienVanPhong = float.Parse(row["NVVANPHONG"].ToString());
                //info.ChonNhanVienVanPhong = int.Parse(row["CHONNVVP"].ToString());
                //info.ChonThuViec = int.Parse(row["CHONTHUVIEC"].ToString());
                //info.Chon2Nam = Convert.ToInt16(row["CHON2NAM"].ToString());
                //info.Chon3Nam = Convert.ToInt16(row["CHON3NAM"].ToString());

                infonv.MaNhanVien = row["MANV"].ToString();
                infonv.HoTen = row["HOTEN"].ToString();
                //infonv.NgaySinh = (DateTime)row["NGAYSINH"];
                //infonv.ChungMinh = row["CMND"].ToString();

                ListViewItem item = new ListViewItem();

                item.Text = infonv.MaNhanVien;
                //item.Text = info.MaLuong;
                item.SubItems.Add(infonv.HoTen.ToString());
                //item.SubItems.Add(infonv.NgaySinh.ToString());
                //item.SubItems.Add(infonv.ChungMinh.ToString());
                item.SubItems.Add(info.Luong.ToString());
                item.SubItems.Add(info.TruCacKhoan.ToString());
                item.SubItems.Add(info.LuongConLai.ToString());
               
                if (info.GiaoVien == 0)
                {
                    item.SubItems.Add("");
                }
                else
                {
                    item.SubItems.Add(info.GiaoVien.ToString());
                }
                if (info.NhanVienVanPhong == 0)
                {
                    item.SubItems.Add("");
                }
                else
                {
                    item.SubItems.Add(info.NhanVienVanPhong.ToString());
                }
                if (info.DangPhi == 0)
                {
                    item.SubItems.Add("");
                }
                else
                {
                    item.SubItems.Add(info.DangPhi.ToString());
                }

                item.SubItems.Add(info.LuongThucLanh.ToString());

                item.Tag = info;

                listView.Items.Add(item);
                #endregion
            }
            

          
               
               
            
        }
        #endregion

        #region HienThiInfo()
        public void HienThiInfo(CheckBox chon2nam,CheckBox chon3nam,DevComponents.DotNetBar.Controls.CheckBoxX chonThuViec, DevComponents.DotNetBar.Controls.CheckBoxX chonGiaoVien, DevComponents.DotNetBar.Controls.CheckBoxX chonNVVanPhong, TextBox txtMaLuong, ComboBox cboTenNgach, DateTimePicker dtNgayBD, DateTimePicker dtNgayKT, ComboBox cboBacLuong, TextBox txtHSLuong, DevComponents.Editors.DoubleInput txtLuongCoBan, DevComponents.Editors.DoubleInput txtHSPCChucVu, DevComponents.Editors.DoubleInput txtLuong, DevComponents.Editors.DoubleInput txtTruCacKhoan, DevComponents.Editors.DoubleInput txtLuongConLai, DevComponents.Editors.DoubleInput txtDangPhi, DevComponents.Editors.DoubleInput txtLuongThucLanh, DevComponents.Editors.DoubleInput giaoVien, DevComponents.Editors.DoubleInput nvVanPhong, LươngNhanVienInfo info)
        {

            chon2nam.Checked = info.Chon2Nam.Equals(1);
            chon3nam.Checked = info.Chon3Nam.Equals(1);
            chonThuViec.Checked = info.ChonThuViec.Equals(1);
            chonGiaoVien.Checked = info.ChonGiaoVien.Equals(1);
            chonNVVanPhong.Checked = info.ChonNhanVienVanPhong.Equals(1);
            txtMaLuong.Text = info.MaLuong;
            cboTenNgach.Text = info.TenNgach;
            dtNgayBD.Text = info.NgayBatDau.ToShortDateString();
            dtNgayKT.Text = info.NgayKetThuc.ToShortDateString();
            cboBacLuong.Text = info.BacLuong.ToString();
            txtHSLuong.Text = info.HeSoLuong.ToString();
            txtLuongCoBan.Text = info.LuongCoBan.ToString();
            txtHSPCChucVu.Text = info.HeSoPCChucVu.ToString();
            txtLuong.Text = info.Luong.ToString();
            txtTruCacKhoan.Text = info.TruCacKhoan.ToString();
            txtLuongConLai.Text = info.LuongConLai.ToString();
            txtDangPhi.Text = info.DangPhi.ToString();
            txtLuongThucLanh.Text = info.LuongThucLanh.ToString();
            giaoVien.Text = info.GiaoVien.ToString();
            nvVanPhong.Text = info.NhanVienVanPhong.ToString();

        }
        #endregion

        #region Add()
        public bool Add(LươngNhanVienInfo info)
        {
            DataRow row = Table.NewRow();
            
            row["MALNV"] = info.MaLuong;
            row["MANHANVIEN"] = info.MaNhanVien;
            row["TENNGACH"] = info.TenNgach;
            row["BACLUONG"] = info.BacLuong;
            row["HESOLUONG"] = info.HeSoLuong;
            row["LUONGCOBAN"] = info.LuongCoBan;
            row["NGAYBD"] = info.NgayBatDau;
            row["NGAYKT"] = info.NgayKetThuc;
            row["HSPCCHUCVU"] = info.HeSoPCChucVu;
            row["LUONG"] = info.Luong;
            row["TRUCACKHOAN"] = info.TruCacKhoan;
            row["LUONGCONLAI"] = info.LuongConLai;
            row["DANGPHI"] = info.DangPhi;
            row["LUONGTHUCLANH"] = info.LuongThucLanh;
            row["GIAOVIEN"] = info.GiaoVien;
            row["NVVANPHONG"] = info.NhanVienVanPhong;
            row["CHONGV"] = info.ChonGiaoVien;
            row["CHONNVVP"] = info.ChonNhanVienVanPhong;
            row["CHONTHUVIEC"] = info.ChonThuViec;
            row["CHON2NAM"] =Convert.ToInt16( info.Chon2Nam);
            row["CHON3NAM"] =Convert.ToInt16( info.Chon3Nam);

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

                    if (tb.Rows[i][1].ToString() == info.MaNhanVien)
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
            

            row["DANHDAU"] = int.Parse("1");

            Table.Rows.Add(row);
            if (this.data_LuongNhanVien.Update())
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



        #region CapNhatLuongNhanVien()
        public void CapNhatLuongNhanVien(LươngNhanVienInfo info, int index)
        {
            //this.Table.Rows[index]["MAQT"] = info.MaQuocTich; 
            #region CapNhatLuong
            this.Table.Rows[index]["TENNGACH"] = info.TenNgach;
            this.Table.Rows[index]["BACLUONG"] = info.BacLuong;
            this.Table.Rows[index]["HESOLUONG"] = info.HeSoLuong;
            this.Table.Rows[index]["LUONGCOBAN"] = info.LuongCoBan;
            this.Table.Rows[index]["NGAYBD"] = info.NgayBatDau;
            this.Table.Rows[index]["NGAYKT"] = info.NgayKetThuc;
            this.Table.Rows[index]["HSPCCHUCVU"] = info.HeSoPCChucVu;
            this.Table.Rows[index]["LUONG"] = info.Luong;
            this.Table.Rows[index]["TRUCACKHOAN"] = info.TruCacKhoan;
            this.Table.Rows[index]["LUONGCONLAI"] = info.LuongConLai;
            this.Table.Rows[index]["DANGPHI"] = info.DangPhi;
            this.Table.Rows[index]["LUONGTHUCLANH"] = info.LuongThucLanh;
            this.Table.Rows[index]["GIAOVIEN"] = info.GiaoVien;
            this.Table.Rows[index]["NVVANPHONG"] = info.NhanVienVanPhong;
            this.Table.Rows[index]["CHONGV"] = info.ChonGiaoVien;
            this.Table.Rows[index]["CHONNVVP"] = info.ChonNhanVienVanPhong;
            this.Table.Rows[index]["CHONTHUVIEC"] = info.ChonThuViec;
            this.Table.Rows[index]["CHON2NAM"] = info.Chon2Nam;
            this.Table.Rows[index]["CHON3NAM"] = info.Chon3Nam;


            this.data_LuongNhanVien.CapNhatLuongNhanVien(info);
            #endregion
        }
        #endregion

        #region Delete()
        public bool Delete(int index)
        {
            this.Table.Rows[index].Delete();

            return this.data_LuongNhanVien.Update();
        }
        #endregion

        #region Create()
        public void Create(TextBox txtMaQT)
        {
            Table = data_LuongNhanVien.lay_dsLuongNhanVien_total();
            bool b = true;
            //int i = 0;
            //int t = 1;
            int max=0;
            int[] a = new int[1000];
            if (Table.Rows.Count == 0)
            {
                txtMaQT.Text = "ML1";
                return;
            }
            while (b)
            {
                for (int i=0; i < Table.Rows.Count; i++)
                {
                    if (Table.Rows[i][0].ToString().Length == 3)
                    {
                        if ((a[i] = Convert.ToInt16(Table.Rows[i][0].ToString().Substring(2, 1))) > max)
                        {
                            max = a[i];
                        }
                    }
                    if (Table.Rows[i][0].ToString().Length == 4)
                    {
                        if ((a[i] = Convert.ToInt16(Table.Rows[i][0].ToString().Substring(2, 2))) > max)
                        {
                            max = a[i];
                        }
                    }
                    if (Table.Rows[i][0].ToString().Length == 5)
                    {
                        if ((a[i] = Convert.ToInt16(Table.Rows[i][0].ToString().Substring(2, 3))) > max)
                        {
                            max = a[i];
                        }
                    }
                    if (Table.Rows[i][0].ToString().Length == 6)
                    {
                        if ((a[i] = Convert.ToInt16(Table.Rows[i][0].ToString().Substring(2, 4))) > max)
                        {
                            max = a[i];
                        }
                    }
                   
                }
                int endmax = max + 1;
                string s1 = string.Concat("ML", endmax.ToString());
                txtMaQT.Text = s1;
                b = false;
                
            }
        }
        #endregion

        #region Xoa_Luong

        public void Xoa_Luong(String MaQTHL)
        {
            if (data_LuongNhanVien == null)
                data_LuongNhanVien = new LuongNhanVienData();
            data_LuongNhanVien.Xoa_Luong(MaQTHL);
        }
        #endregion

        #region Xoa_Luong_NhanVien

        public void Xoa_Luong_NhanVien(String MaNV)
        {
            if (data_LuongNhanVien == null)
                data_LuongNhanVien = new LuongNhanVienData();
            data_LuongNhanVien.Xoa_Luong_NhanVien(MaNV);
        }
        #endregion
    }
}

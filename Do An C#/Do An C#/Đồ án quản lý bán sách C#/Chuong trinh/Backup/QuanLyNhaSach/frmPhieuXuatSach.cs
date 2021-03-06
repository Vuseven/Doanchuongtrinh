using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using QuanLyNhaSach.Builder_layer;
using QuanLyNhaSach.Control;

namespace QuanLyNhaSach
{
    public partial class frmPhieuXuatSach : DockContent
    {
        public frmPhieuXuatSach()
        {
            InitializeComponent();
        }
        ThongTinSachInfo ttsach;
        PhieuXuatSachInfo px_info = new PhieuXuatSachInfo();
        NhanVienCtrl nv_Ctrl = new NhanVienCtrl();
        KhachHangCtrl kh_Ctrl = new KhachHangCtrl();
        PhieuXuatCtrl px_Ctrl = new PhieuXuatCtrl();
        int capnhat = 0;
        long tongtien = 0;

        public void hienstt(ListView lv)
        {
            int soitem = lv.Items.Count;
            for (int i = 0; i < soitem; i++)
                lv.Items[i].Text = (i + 1).ToString();
        }

        void hien()
        {
            txtGia.Enabled = true;
            txtSL.Enabled = true;
            txtSL.Enabled = true;
        }
        void an()
        {
            txtGia.Enabled = false;
            txtSL.Enabled = false ;
            txtSL.Enabled = false ;
        }
        private void frmPhieuXuatSach_Load(object sender, EventArgs e)
        {            
            px_Ctrl.hiethi_lv_px(lvpx);
            //ncc.Load_ncc_lenhanghoa(comboNhaCungCap);
            kh_Ctrl.HienThiCB(cbMaKH);
            nv_Ctrl.HienThiCB(cbMaNV);
            //kh.HienThi(comboKhachHang);
            txtMaPX.Text = "Mã Phiếu xuất";          
            
        }

        private void btnTim_Click(object sender, EventArgs e)
        {           
            frmChonSach chonSach = new frmChonSach();
            DialogResult rs = chonSach.ShowDialog();
            if (rs == DialogResult.OK)
            {
                ttsach = chonSach.ttSach;
                txtTenSach.Text = ttsach.TenSach;
            }
        }

        private void lvpx_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            capnhat = 1;
            txtMaPX.ReadOnly = true;
            // comboNhaCungCap.Enabled = false;
            // comboNhanVien.Enabled = false;
            txtTenSach.Text = "";
            txtGia.Text = "";
            txtSL.Text = "";
            btnSua.Enabled = true;
            IEnumerator ie = lvpx.SelectedItems.GetEnumerator();
            if (ie.MoveNext())
            {
                ListViewItem item = (ListViewItem)ie.Current;
                txtMaPX.Text = item.SubItems[1].Text;
                dtNgayLap.Text = item.SubItems[2].Text;
                cbMaNV.Text = item.SubItems[3].Text;
                cbMaKH.Text = item.SubItems[5].Text;
                txtTongTien.Text = item.SubItems[7].Text;
                tongtien = Convert.ToInt32(txtTongTien.Text);
                px_Ctrl.hiethi_lv_ctpx(lvchitiet, item.SubItems[1].Text);
            }
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            if (txtTenSach.Text == "" || txtSL.Text == "" || txtSL.Text == "" )
            {               
                MessageBox.Show("Thông tin nhập bị lỗi hãy nhập lại ");
                txtTenSach.Focus();
            }
            else
            {
                if (capnhat == 0)
                    px_Ctrl.luuphieuxuat(txtMaPX.Text, dtNgayLap.Value, cbMaNV.SelectedValue.ToString(), cbMaKH.SelectedValue.ToString(), tongtien);
                else
                {
                    px_Ctrl.capnhatphieuxuat(txtMaPX.Text, cbMaNV.Text, cbMaKH.Text, dtNgayLap.Value, tongtien);
                    px_Ctrl.xoactpx(txtMaPX.Text);
                }
                ListViewItem item = new ListViewItem();
                for (int i = 0; i < lvchitiet.Items.Count; i++)
                {
                    item = lvchitiet.Items[i];
                    ChiTietPhieuXuatSachInfo ct_Info = new ChiTietPhieuXuatSachInfo();

                    ct_Info = (ChiTietPhieuXuatSachInfo)item.Tag;
                    px_Ctrl.luuchitietphieuxuat(txtMaPX.Text, ct_Info.sach_getset.MaSach, ct_Info.dongia_getset, ct_Info.soluong_getset, ct_Info.thanhtien_getset);

                }

                txtMaPX.Text = "Mã Phiếu xuất";                
                lvchitiet.Items.Clear(); 
                txtTongTien.Text = "";
                tongtien = 0;
                capnhat = 0;
                lvpx.Items.Clear();
                px_Ctrl.hiethi_lv_px(lvpx);
                button4.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaPX.Text == "")
                MessageBox.Show("Mả phiếu xuất không được trống");
            else
            {
                px_info.MaPhieuXuatSach = txtMaPX.Text;
                px_info.khachhang_getset.MaKhachHang = cbMaKH.SelectedValue.ToString();
                px_info.nhanvien_getset.MaNhanVien = cbMaNV.SelectedValue.ToString();
                px_info.NgayLap = dtNgayLap.Value;
                //pd_info.TongTien= Convert.ToInt64(txtTongTien.Text);
                px_Ctrl.ThemPhieuXuat(px_info);
                btnThem.Enabled = false;
                lvchitiet.Enabled = true;
                lvpx.Enabled = true;
                px_Ctrl.hiethi_lv_px(lvpx);
                txtMaPX.Enabled = false;
                txtTongTien.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //ctrl.xoapb(textMaPhieuBan.Text);
            px_info.MaPhieuXuatSach = txtMaPX.Text;
            px_info.nhanvien_getset.MaNhanVien = cbMaNV.SelectedValue.ToString();
            px_info.khachhang_getset.MaKhachHang = cbMaKH.SelectedValue.ToString();
            px_info.NgayLap = dtNgayLap.Value;
            //pb.tongtien_getset = Convert.ToInt64(textTongTien.Text);
            px_Ctrl.hiethi_lv_px(lvpx);
            px_Ctrl.XoaPhieuXuat(px_info);            
            lvchitiet.Items.Clear();
            px_Ctrl.hiethi_lv_px(lvpx);
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {            
            txtMaPX.Enabled = true;
            txtMaPX.ReadOnly = false;
            cbMaKH.Enabled = true;
            cbMaNV.Enabled = true;
            txtMaPX.Text = "";
            cbMaNV.Text = "Chọn Mã Nhân Viên";
            cbMaKH.Text = "Chọn Mã Khách Hàng";
            txtTongTien.Text = "0";            
            btnThem.Enabled = true;
            lvchitiet.Enabled = false;
            lvpx.Enabled = false;
        }

        private void btnTrai_Click(object sender, EventArgs e)
        {
            if (txtTenSach.Text != "" && txtGia.Text != "" && txtSL.Text != "")
            {
                ListViewItem item = new ListViewItem();
                ChiTietPhieuXuatSachInfo ctpxinfo = new ChiTietPhieuXuatSachInfo();
                // ChiTietHDNInfo cthdninfo = new ChiTietHDNInfo();
                ctpxinfo.sach_getset = ttsach;
                // cthdninfo.Hanghoa = hh;
                ctpxinfo.dongia_getset = Convert.ToInt64(txtGia.Text);
                ctpxinfo.soluong_getset = Convert.ToInt32(txtSL.Text);
                ctpxinfo.thanhtien_getset = (long)ctpxinfo.soluong_getset * ctpxinfo.dongia_getset;

                //item.SubItems.Add(pd_info.MaPhieuDatSach);
                //item.SubItems.Add(ttsach.MaSach);
                item.SubItems.Add(ttsach.TenSach);
                item.SubItems.Add(txtGia.Text);
                item.SubItems.Add(txtSL.Text);
                item.SubItems.Add(ctpxinfo.thanhtien_getset.ToString());
                tongtien += ctpxinfo.thanhtien_getset;
                item.Tag = ctpxinfo;
                lvchitiet.Items.Add(item);               
                hienstt(lvchitiet);
                button4.Enabled = true;
            }
        }

        private void btnPhai_Click(object sender, EventArgs e)
        {
            IEnumerator ie = lvchitiet.SelectedItems.GetEnumerator();
            while (ie.MoveNext())
            {
                ListViewItem item = (ListViewItem)ie.Current;

                long temp = Convert.ToInt64(item.SubItems[4].Text);
                tongtien -= temp;
                lvchitiet.Items.Remove(item);

            }
            hienstt(lvchitiet);
            button4.Enabled = true;
        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đã chắc chắn thoát!", "QUANLYNHASACH", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            frmTimPhieuXuatSach tk = new frmTimPhieuXuatSach();
            tk.ShowDialog();
            if (tk.DialogResult == DialogResult.OK)
            {
                //-- tao moi doi tuong tra ve
                PhieuXuatSachInfo px = tk.PX;
                //--bo thong tin vao cac object                
                txtMaPX.Text = px.MaPhieuXuatSach;
                cbMaNV.Text = px.MaNhanVien;
                cbMaKH.Text = px.MaKhachHang;
                dtNgayLap.Value = px.NgayLap;
                //txtTongTien.Text= px.TongTien;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            px_info.MaPhieuXuatSach = txtMaPX.Text;
            px_info.nhanvien_getset.MaNhanVien = cbMaNV.SelectedValue.ToString();
            px_info.khachhang_getset.MaKhachHang = cbMaKH.SelectedValue.ToString();
            px_info.NgayLap = dtNgayLap.Value;
            //pd_info.TongTien= Convert.ToInt64(txtTongTien.Text);
            px_Ctrl.capnhatphieuxuat(txtMaPX.Text, cbMaNV.Text, cbMaKH.Text, dtNgayLap.Value, tongtien);
            btnThem.Enabled = false;
            lvchitiet.Enabled = true;
            lvpx.Enabled = true;
            px_Ctrl.hiethi_lv_px(lvpx);
            txtMaPX.Enabled = false;
            txtTongTien.Enabled = false;
            btnSua.Enabled = false;
        }

        

    }
}
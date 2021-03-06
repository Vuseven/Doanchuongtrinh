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
    public partial class frmPhieuDatSach : DockContent
    {
        public frmPhieuDatSach()
        {
            InitializeComponent();
        }
        ThongTinSachInfo ttsach;      
        PhieuDatSachInfo pd_info = new PhieuDatSachInfo();
        NhanVienCtrl nv_Ctrl = new NhanVienCtrl();
        NhaCungCapCtrl ncc_Ctrl = new NhaCungCapCtrl();
        PhieuDatCtrl pd_Ctrl = new PhieuDatCtrl();
        ErrorInfo err = new ErrorInfo();
        int capnhat = 0;
        long tongtien = 0;
        

        public void hienstt(ListView lv)
        {
            int soitem = lv.Items.Count;
            for (int i = 0; i < soitem; i++)
                lv.Items[i].Text = (i + 1).ToString();
        }

        private void frmPhieuDatSach_Load(object sender, EventArgs e)
        {
            pd_Ctrl.hiethi_lv_pd(lvpd);
            //ncc.Load_ncc_lenhanghoa(comboNhaCungCap);
            ncc_Ctrl.HienThiCB(cbMaNCC);
            nv_Ctrl.HienThiCB(cbMaNV);
            //kh.HienThi(comboKhachHang);
            txtMaPD.Text = "Mã Phiếu Đặt Sách";            
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

        private void lvpd_SelectedIndexChanged(object sender, EventArgs e)
        {
            capnhat = 1;
            txtMaPD.ReadOnly = true;
            // comboNhaCungCap.Enabled = false;
            // comboNhanVien.Enabled = false;
            txtTenSach.Text = "";
            txtGia.Text = "";
            txtSL.Text = "";
            btnSua.Enabled = true;

            IEnumerator ie = lvpd.SelectedItems.GetEnumerator();
            if (ie.MoveNext())
            {
                ListViewItem item = (ListViewItem)ie.Current;
                txtMaPD.Text = item.SubItems[1].Text;
                dtNgayLap.Text = item.SubItems[2].Text;
                cbMaNV.Text = item.SubItems[3].Text;
                cbMaNCC.Text = item.SubItems[5].Text;                
                txtTongTien.Text = item.SubItems[7].Text;
                tongtien = Convert.ToInt32(txtTongTien.Text);
                pd_Ctrl.hiethi_lv_ctpd(lvchitiet, item.SubItems[1].Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
                if (capnhat == 0)
                    pd_Ctrl.luuphieudat(txtMaPD.Text, dtNgayLap.Value, cbMaNV.SelectedValue.ToString(), cbMaNCC.SelectedValue.ToString(), tongtien);
                else
                {
                    pd_Ctrl.capnhatphieudat(txtMaPD.Text, cbMaNV.Text, cbMaNCC.Text, dtNgayLap.Value, tongtien);
                    pd_Ctrl.xoactpd(txtMaPD.Text);
                }
                ListViewItem item = new ListViewItem();
                for (int i = 0; i < lvchitiet.Items.Count; i++)
                {
                    item = lvchitiet.Items[i];
                    ChiTietPhieuDatSachInfo ct_Info = new ChiTietPhieuDatSachInfo();

                    ct_Info = (ChiTietPhieuDatSachInfo)item.Tag;
                    pd_Ctrl.luuchitietphieudat(txtMaPD.Text, ct_Info.sach_getset.MaSach, ct_Info.dongia_getset, ct_Info.soluong_getset, ct_Info.thanhtien_getset);

                }

                txtMaPD.Text = "Mã Phiếu Đặt Sách";                
                lvchitiet.Items.Clear();                
                txtTongTien.Text = "";
                tongtien = 0;
                capnhat = 0;
                lvpd.Items.Clear();
                pd_Ctrl.hiethi_lv_pd(lvpd);
                button4.Enabled = false;
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaPD.Text == "")
                MessageBox.Show("Mã phiếu đặt không được trống");
            else
            {
                pd_info.MaPhieuDatSach = txtMaPD.Text;
                pd_info.nhacungcap_getset.MaNhaCungCap = cbMaNCC.SelectedValue.ToString();
                pd_info.nhanvien_getset.MaNhanVien = cbMaNV.SelectedValue.ToString();
                pd_info.NgayDat = dtNgayLap.Value;
                //pd_info.TongTien= Convert.ToInt64(txtTongTien.Text);
                pd_Ctrl.ThemPhieuDat(pd_info);
                btnThem.Enabled = false;
                lvchitiet.Enabled = true;
                lvpd.Enabled = true;
                pd_Ctrl.hiethi_lv_pd(lvpd);
                txtMaPD.Enabled = false;
                txtTongTien.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //ctrl.xoapb(textMaPhieuBan.Text);
            pd_info.MaPhieuDatSach = txtMaPD.Text;
            pd_info.nhanvien_getset.MaNhanVien = cbMaNV.SelectedValue.ToString();
            pd_info.nhacungcap_getset.MaNhaCungCap = cbMaNCC.SelectedValue.ToString();
            pd_info.NgayDat = dtNgayLap.Value;
            //pb.tongtien_getset = Convert.ToInt64(textTongTien.Text);
            pd_Ctrl.XoaPhieuDat(pd_info);            
            lvchitiet.Items.Clear();
            pd_Ctrl.hiethi_lv_pd(lvpd);
          
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaPD.Enabled = true;
            txtMaPD.ReadOnly = false;            
            cbMaNCC.Enabled = true;
            cbMaNV.Enabled = true;
            txtMaPD.Text = "";
            cbMaNV.Text = "Chọn Mã Nhân Viên";
            cbMaNCC.Text = "Chọn Mã Nhà CC";
            txtTongTien.Text = "0";            
            btnThem.Enabled = true;            
            lvchitiet.Enabled = false;
            lvpd.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {            
            pd_info.MaPhieuDatSach = txtMaPD.Text;            
            pd_info.nhanvien_getset.MaNhanVien = cbMaNV.SelectedValue.ToString();
            pd_info.nhacungcap_getset.MaNhaCungCap = cbMaNCC.SelectedValue.ToString();
            pd_info.NgayDat = dtNgayLap.Value;
            //pd_info.TongTien= Convert.ToInt64(txtTongTien.Text);
            pd_Ctrl.capnhatphieudat(txtMaPD.Text,cbMaNV.Text,cbMaNCC.Text, dtNgayLap.Value, tongtien);
            btnThem.Enabled = false;
            lvchitiet.Enabled = true;
            lvpd.Enabled = true;
            pd_Ctrl.hiethi_lv_pd(lvpd);
            txtMaPD.Enabled = false;
            txtTongTien.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnTrai_Click(object sender, EventArgs e)
        {
            if (txtTenSach.Text != "" && txtGia.Text != "" && txtSL.Text != "")
            {
                ListViewItem item = new ListViewItem();
                ChiTietPhieuDatSachInfo ctpdinfo = new ChiTietPhieuDatSachInfo();
                // ChiTietHDNInfo cthdninfo = new ChiTietHDNInfo();
                ctpdinfo.sach_getset = ttsach;
                // cthdninfo.Hanghoa = hh;
                ctpdinfo.dongia_getset = Convert.ToInt64(txtGia.Text);
                ctpdinfo.soluong_getset = Convert.ToInt32(txtSL.Text);
                ctpdinfo.thanhtien_getset = (long)ctpdinfo.soluong_getset * ctpdinfo.dongia_getset;

                //item.SubItems.Add(pd_info.MaPhieuDatSach);
                //item.SubItems.Add(ttsach.MaSach);
                item.SubItems.Add(ttsach.TenSach);
                item.SubItems.Add(txtGia.Text);
                item.SubItems.Add(txtSL.Text);
                item.SubItems.Add(ctpdinfo.thanhtien_getset.ToString());
                tongtien += ctpdinfo.thanhtien_getset;
                item.Tag = ctpdinfo;
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
            frmTimPhieuDatSach tk = new frmTimPhieuDatSach();
            tk.ShowDialog();
            if (tk.DialogResult == DialogResult.OK)
            {
                //-- tao moi doi tuong tra ve
                PhieuDatSachInfo pd = tk.PD;
                //--bo thong tin vao cac object                
                txtMaPD.Text = pd.MaPhieuDatSach;
                cbMaNV.Text = pd.MaNhanVien;
                cbMaNCC.Text = pd.MaNhaCC;
                dtNgayLap.Value = pd.NgayDat;
                //txtTongTien.te = pd.TongTien;
            }
        }
   }
}
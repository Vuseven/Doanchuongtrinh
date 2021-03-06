using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using System.Collections;
using TT_GDTX_ANGIANG.BusinessObject;
using TT_GDTX_ANGIANG.Controller;


namespace TT_GDTX_ANGIANG
{
    public partial class frm_KETQUATUYENDUNG : DevComponents.DotNetBar.Office2007Form
    {
        public frm_KETQUATUYENDUNG()
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
            this.btnLuu.Enabled = false;
        }
        public void PhanQuyen_Xem_Hien()
        {
            this.btnLuu.Enabled = true;
        }
        #endregion

        #region ctrlKetQua
        private KetQuaTuyenDungCtrl m_ctrlKetQua;
        public KetQuaTuyenDungCtrl ctrlKetQua
        {
            get { return m_ctrlKetQua; }
            set { m_ctrlKetQua = value; }
        }
        #endregion

        #region ctrlNhanVien
        private NhanVienCtrl m_ctrlNhanVien;
        public NhanVienCtrl ctrlNhanVien
        {
            get { return m_ctrlNhanVien; }
            set { m_ctrlNhanVien = value; }
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

        #region ThongTinHoSo()
        private void ThongTinHoSo()
        {
            if (HoSoSelected == null)
                HoSoSelected = new HoSoTuyenDungInfo();
            this.txtMAHS.Text = HoSoSelected.MaHoSo;
            this.txtHOTEN.Text = HoSoSelected.HoTen;

            this.txtNGAYSINH.Text = HoSoSelected.NgaySinh.ToShortDateString();
            if (HoSoSelected.GioiTinh == 1)
            {
                this.txtGIOITINH.Text = "Nam";
            }
            else
            {
                this.txtGIOITINH.Text = "Nữ";
            }
            this.txtDIACHI.Text = HoSoSelected.NoiSinh;
            this.txtDIENTHOAI.Text = HoSoSelected.DienThoaiNha;
            this.txtCMND.Text = HoSoSelected.ChungMinh;
        }
        #endregion

        private void frm_KETQUATUYENDUNG_Load(object sender, EventArgs e)
        {
            #region HienThi Combobox

            PhongBanCtrl ctrlPhongBan = new PhongBanCtrl();
            ctrlPhongBan.HienThiComboBox(this.cboPHONGBAN);         

            ChucVuCtrl ctrlChucVu = new ChucVuCtrl();
            ctrlChucVu.HienThiComboBox(this.cboCHUCVU);

            #endregion

            if (An_Hien == "Xem")
            {
                this.PhanQuyen_Xem_An();
            }
            else
            {
                this.PhanQuyen_Xem_Hien();
            }
            this.chkCHAPNHAN.Checked = false;
            this.cboPHONGBAN.Enabled = false;
            this.cboDONVI.Enabled = false;
            this.txtSOQD.Enabled = false;
            this.dateNGAYVAOCQ.Enabled = false;
            this.cboCHUCVU.Enabled = false;
            this.txtGHICHU.Enabled = false;
            this.btnTaoMa.Enabled = false;
           
            this.ThongTinHoSo();


            if (this.Open == "Open")
            {
                this.IsAddNew = true;
                if (ctrlKetQua == null)
                    ctrlKetQua = new KetQuaTuyenDungCtrl();
                int kq_MaHS = ctrlKetQua.TestMaHoSo(this.LayHoSo);

                //Kiem tra ho so dang chon co trong CSDL chua (Co phong van hay chua)
                //Co roi (1): Hien thi thong tin cho nguoi dung xem
                //Chua co (0): Cho nguoi dung them thong tin phong van
                if (kq_MaHS == 1)
                {
                    int kq = ctrlKetQua.TestStatus(this.LayHoSo, 1); //0: Chua trung tuyen, 1: Trung tuyen
                    if (kq == 1)
                    {
                        //Trung Tuyen
                        this.chkCHAPNHAN.Checked = true;
                        this.chkCHAPNHAN.Enabled = false;
                       
                        this.btnLuu.Enabled = false;

                        ctrlKetQua.KiemTra(this.LayHoSo, txtMANV, cboPHONGBAN, cboCHUCVU, txtSOQD, dateNGAYVAOCQ);
                    }
                    else
                    {
                        //Chua trung tuyen
                        this.chkCHAPNHAN.Checked = false;
                        this.chkCHAPNHAN.Enabled = false;
                       
                        this.btnLuu.Enabled = false;

                        ctrlKetQua.HienThi(this.LayHoSo);
                    }
                }
                else  // Chua co phong van_Moi nhap thong tin phong van
                {
                    this.chkCHAPNHAN.Enabled = false;
                   
                    this.btnLuu.Enabled = true;
                }

            }
            else  //Cho phep nguoi dung Cap nhat thong tin phong van
            {
                if (ctrlKetQua == null)
                    ctrlKetQua = new KetQuaTuyenDungCtrl();
                int Test_MaHS = ctrlKetQua.TestMaHoSo(this.LayHoSo);
                if (Test_MaHS == 1)
                {
                    int kq = ctrlKetQua.TestStatus(this.LayHoSo, 1); //0: Chua trung tuyen, 1: Trung tuyen
                    if (kq == 1)
                    {
                        //Trung Tuyen
                        this.chkCHAPNHAN.Checked = true;
                        this.cboPHONGBAN.Enabled = true;
                        this.cboDONVI.Enabled = true;
                        this.txtSOQD.Enabled = true;
                        this.dateNGAYVAOCQ.Enabled = true;
                        this.cboCHUCVU.Enabled = true;
                        this.txtGHICHU.Enabled = true;
                        this.btnLuu.Enabled = true;


                        ctrlKetQua.KiemTra(this.LayHoSo, txtMANV, cboPHONGBAN, cboCHUCVU, txtSOQD, dateNGAYVAOCQ);
                    }
                    else
                    {
                        //Chua trung tuyen
                        this.chkCHAPNHAN.Checked = false;
                        ctrlKetQua.HienThi(this.LayHoSo);
                    }
                    this.IsAddNew = false;
                }
                else
                {
                    //Chua co thong tin Phong van
                    //MessageBox.Show("Hồ sơ này chưa được phỏng vấn! Vui lòng thêm thông tin phỏng vấn");
                    this.chkCHAPNHAN.Checked = false;
                    this.IsAddNew = true;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnTaoMa_Click(object sender, EventArgs e)
        {
            if (ctrlNhanVien == null)
                ctrlNhanVien = new NhanVienCtrl();
            ctrlNhanVien.Create(this.txtMANV);
        }
        #region chkCHAPNHAN_CheckedChanged        
        
        private void chkCHAPNHAN_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkCHAPNHAN.Checked == true)
            {
                this.cboPHONGBAN.Enabled = true;
                //this.cboDONVI.Enabled = true;
                this.txtSOQD.Enabled = true;
                this.dateNGAYVAOCQ.Enabled = true;
                this.cboCHUCVU.Enabled = true;
                
                this.btnTaoMa.Enabled = true;
            }
            else
            {
                this.cboPHONGBAN.Enabled = false;
                this.cboDONVI.Enabled = false;
                this.txtSOQD.Enabled = false;
                this.dateNGAYVAOCQ.Enabled = false;
                this.cboCHUCVU.Enabled = false;                
                this.btnTaoMa.Enabled = false;
            }
        }
        #endregion


        #region CheckValid()
        private bool CheckValid( DateTimePicker NgayVao)
        {
            if (this.txtMANV.Text.Trim() == "")
            {
                MessageBox.Show("Chưa tọa mã Nhân Viên, Hãy Nhấn nút Tạo Mã!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnTaoMa.Focus();
                return false;
            }

            if (NgayVao.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày vào cơ quan phải lớn hơn ngày hiện tại !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion
        #region btnLuu_Click
        
       
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (this.CheckValid(dateNGAYVAOCQ))
            {
                if (HoSoSelected == null)
                    HoSoSelected = new HoSoTuyenDungInfo();
                KetQuaTuyenDungInfo info_KetQua = new KetQuaTuyenDungInfo();



                if (chkCHAPNHAN.Checked == true)//Cho phep luu
                {
                    info_KetQua.MaNhanVien = this.txtMANV.Text;
                    info_KetQua.PhongBan = this.cboPHONGBAN.SelectedValue.ToString();

                    if (this.cboDONVI.Enabled)
                    {
                        BoPhanCtrl ctrlBP = new BoPhanCtrl();
                        info_KetQua = new KetQuaTuyenDungInfo();
                        info_KetQua.BoPhan = ctrlBP.GetBoPhan(this.cboDONVI.SelectedValue.ToString());
                    }
                    else
                    {
                        info_KetQua.BoPhan = new BoPhanInfo();
                        info_KetQua.BoPhan.MaBoPhan = "";
                    }
                    ChucVuCtrl ctrlCV = new ChucVuCtrl();
                    //info_KetQua = new KetQuaTuyenDungInfo();
                    info_KetQua.ChucVu = ctrlCV.GetChucVu(this.cboCHUCVU.SelectedValue.ToString());
                    info_KetQua.SoQuyetDinh = this.txtSOQD.Text;
                    info_KetQua.NgayTuyenDung = this.dateNGAYVAOCQ.Value;
                    info_KetQua.GhiChu = this.txtGHICHU.Text;
                    info_KetQua.Status = int.Parse("1");
                }
                else //Chua Trung tuyen
                {
                    info_KetQua.MaNhanVien = "";
                    info_KetQua.PhongBan = "";

                    if (this.cboDONVI.Enabled)
                    {
                        BoPhanCtrl ctrlBP = new BoPhanCtrl();
                        info_KetQua = new KetQuaTuyenDungInfo();
                        info_KetQua.BoPhan = ctrlBP.GetBoPhan(this.cboDONVI.SelectedValue.ToString());
                    }
                    else
                    {
                        info_KetQua.BoPhan = new BoPhanInfo();
                        info_KetQua.BoPhan.MaBoPhan = "";
                    }
                    info_KetQua.ChucVu = new ChucVuInfo();
                    info_KetQua.ChucVu.MaChucVu = "";
                    info_KetQua.SoQuyetDinh = "";
                    info_KetQua.NgayTuyenDung = DateTime.Now;
                    info_KetQua.Status = int.Parse("0");   //0: Chua duoc tuyen, 1: Trung tuyen
                }

                //Bat dau luu
                if (IsAddNew)
                {
                    if (ctrlKetQua == null)
                        ctrlKetQua = new KetQuaTuyenDungCtrl();
                    if (ctrlKetQua.Add(info_KetQua))
                    {
                        this.IsAddNew = false;
                        MessageBoxEx.Show("Thêm Thành Công!", "Thêm Thành Công");
                        if (this.chkCHAPNHAN.Checked == true && this.txtMANV.Text != "")
                        {
                            if (ctrlKetQua == null)
                                ctrlKetQua = new KetQuaTuyenDungCtrl();
                            ctrlKetQua.Add_NhanVien(HoSoSelected, info_KetQua);
                            MessageBoxEx.Show("Đã chuyển thông tin Ứng cử viên này sang Hồ sơ nhân viên có mã:  " + this.txtMANV.Text);
                        }
                    }
                }
                else
                {
                    if (MessageBoxEx.Show("Ban có chắc là cập nhật dòng này không?", "Cap nhat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (ctrlKetQua == null)
                            ctrlKetQua = new KetQuaTuyenDungCtrl();
                        ctrlKetQua.Update(info_KetQua, this.LayHoSo);
                        if (this.chkCHAPNHAN.Checked == true && this.txtMANV.Text != "")
                        {
                            if (ctrlKetQua == null)
                                ctrlKetQua = new KetQuaTuyenDungCtrl();
                            ctrlKetQua.Add_NhanVien(HoSoSelected, info_KetQua);
                            MessageBoxEx.Show("Đã chuyển thông tin Ứng cử viên này sang Hồ sơ nhân viên có mã:  " + this.txtMANV.Text);
                        }
                        else
                        {
                            if (MessageBoxEx.Show("Bạn có chắc chắn không chấp nhận tuyển dụng ứng cử viên này hay không ?", "Cap nhat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (ctrlNhanVien == null)
                                    ctrlNhanVien = new NhanVienCtrl();
                                ctrlNhanVien.DeleteList(this.txtMANV.Text);
                                if (ctrlKetQua == null)
                                    ctrlKetQua = new KetQuaTuyenDungCtrl();
                                ctrlKetQua.CapNhat(this.LayHoSo);
                            }
                        }
                    }
                } this.btnThoat.Enabled = true;
            }
        }
        #endregion
    }
}
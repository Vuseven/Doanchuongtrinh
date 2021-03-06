using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using QLHSTPTTHSP.Controller;

namespace QLHSTPTTHSP.PresentationLayer
{
    public partial class frmToChuyenMon : Office2007Form
    {
        ToChuyenMonCtrl toChuyenMonCtrl = new ToChuyenMonCtrl();        
        List<string> listDeleted = new List<string>();

        public frmToChuyenMon()
        {
            InitializeComponent();
            this.ColMoTa.Width = this.Width - this.ColMaToChuyenMon.Width - this.ColTenToChuyenMon.Width - 15;
            this.ColChon.FalseValue = Boolean.FalseString;
            this.ColChon.TrueValue = Boolean.TrueString;
            this.ColChon2.FalseValue = Boolean.FalseString;
            this.ColChon2.TrueValue = Boolean.TrueString;
        }

        private void frmToChuyenMon_Load(object sender, EventArgs e)
        {            
            toChuyenMonCtrl.HienThiDanhSachToChuyenMon(this.dataGridViewX_DanhSach, this.bindingNavigator);

            if (this.dataGridViewX_DanhSach.Rows.Count > 0)
                this.ChoPhepThemXoaSua(true, true, true);
            else
                this.ChoPhepThemXoaSua(true, false, false);

            toChuyenMonCtrl.HienThiDanhSachGiaoVienThuocTo(this.dataGridViewX_DanhSach, this.dataGridViewX_ThuocTo);
            toChuyenMonCtrl.HienThiDanhSachGiaoVienKhongThuocTo(this.dataGridViewX_DanhSach, this.dataGridViewX_KhongThuocTo);

            if (this.dataGridViewX_ThuocTo.Rows.Count <= 0)
            {
                this.buttonX_Bo.Enabled = false;
                this.buttonItem_Context_LoaiBo.Enabled = false;
                this.buttonItem_Context_LoaiBo_Thuoc.Enabled = false;
            }
            if (this.dataGridViewX_KhongThuocTo.Rows.Count <= 0)
            {
                this.buttonX_Them.Enabled = false;
                this.buttonItemContext_Them.Enabled = false;
                this.buttonItem_Context_ThemVao_Thuoc.Enabled = false;
            }
        }

        // <summary>
        /// Cho phép người dùng tương tác với button Thêm Xóa Sửa hay không
        /// </summary>
        private void ChoPhepThemXoaSua(bool btnThemEnabled, bool btnXoaEnabled, bool btnSuaEnabled)
        {
            this.toolStripButtonThem.Enabled = btnThemEnabled;
            this.toolStripButtonXoa.Enabled = btnXoaEnabled;
            this.toolStripButtonCapNhat.Enabled = btnSuaEnabled;
            this.buttonItemContext_Them.Enabled = btnThemEnabled;
            this.buttonItemContext_Xoa.Enabled = btnXoaEnabled;
            this.buttonItemContext_CapNhat.Enabled = btnSuaEnabled;
        }

        private void toolStripButtonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Xử lý các thao tác Thêm, Xóa, Cập nhật
        private void toolStripButtonThem_Click(object sender, EventArgs e)
        {
            this.ChoPhepThemXoaSua(false, true, true);

            DataRow row = toChuyenMonCtrl.ThemDongMoi();            
            row["ma_to_chuyen_mon"] = toChuyenMonCtrl.SinhMa();// Tự động sinh mã tổ chuyên môn
            row["ten_to_chuyen_mon"] = "";
            row["mo_ta"] = "";

            toChuyenMonCtrl.ThemToChuyenMon(row); // Insert một dòng vào csdl                      
            this.bindingNavigator.BindingSource.MoveLast();            
        }

        private void toolStripButtonXoa_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewX_DanhSach.CurrentRow != null)
            {
                string tenToChuyenMon = this.dataGridViewX_DanhSach.CurrentRow.Cells["ColTenToChuyenMon"].Value.ToString();

                if (MessageBoxEx.Show("Bạn có muốn xóa vĩnh viễn thông tin " + tenToChuyenMon + " không?\nNếu bạn xóa " + tenToChuyenMon + " có thể làm sai những dữ liệu có liên quan khác!", "Nhắc nhở", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (true)//kiểm tra xem có xóa được không?
                    {
                        listDeleted.Add(this.dataGridViewX_DanhSach.CurrentRow.Cells["ColMaToChuyenMon"].Value.ToString());

                        this.bindingNavigator.BindingSource.RemoveCurrent();
                        if (this.dataGridViewX_DanhSach.Rows.Count > 0)
                        {
                            this.ChoPhepThemXoaSua(true, true, true);
                        }
                        else
                        {
                            this.ChoPhepThemXoaSua(true, false, false);
                        }

                    }
                    else
                    {
                        //MessageBoxEx.Show("Bạn không thể xóa niên học " + this.dGVNienHoc.CurrentRow.Cells["TenNienHoc"].ToString() + " được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBoxEx.Show("Bạn chưa chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripButtonCapNhat_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewX_DanhSach.IsCurrentCellInEditMode == true) this.dataGridViewX_DanhSach.EndEdit();
            this.bindingNavigator.BindingSource.MoveNext();
            this.bindingNavigator.BindingSource.MovePrevious();
            // Kiểm tra nhập liệu có hợp lệ chưa
            if (this.HopLe())
            {                
                int soDongAnhHuong = toChuyenMonCtrl.CapNhat();// Cập nhật những thay đổi

                if (soDongAnhHuong > 0)
                {
                    MessageBoxEx.Show("Cập nhật thành công! Có " + soDongAnhHuong + " sự kiện đã được cập nhật.", "Xin chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ChoPhepThemXoaSua(true, true, true);
                    
                    if (this.listDeleted.Count > 0)
                    {
                        // Xóa từng học kỳ của niên học trong list niên học bị xóa
                        foreach (string s in this.listDeleted)
                        {
                            new ToChuyenMonCtrl().XoaChiTietToChuyenMon(s);
                        }
                    }
                }
                else
                    if (soDongAnhHuong == 0)
                    {
                        //MessageBoxEx.Show("Không dữ liệu nào được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBoxEx.Show("Cập nhật không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }
        #endregion

        private bool HopLe()
        {
            foreach (DataGridViewRow row in this.dataGridViewX_DanhSach.Rows)
            {
                if (row.Cells["ColTenToChuyenMon"].Value.ToString().Trim() == "")
                {
                    MessageBoxEx.Show("Tổ chuyên môn " + row.Cells["ColMaToChuyenMon"].Value.ToString() + " chưa có tên!", "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void frmToChuyenMon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxEx.Show("Bạn có muốn lưu lại những thay đổi không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.toolStripButtonCapNhat_Click(sender, e);
            } 
        }

        private void buttonX_Them_Click(object sender, EventArgs e)
        {                      

            if (this.KiemTraDanhDauChon(this.dataGridViewX_KhongThuocTo, "ColChon2"))
            {
                string tenGiaoVien = "";
                foreach (string str in this.DanhSachDuocChon(this.dataGridViewX_KhongThuocTo, "ColChon2", "ColTenGiaoVien2"))
                {
                    tenGiaoVien += str + ", ";
                }
                if (MessageBoxEx.Show("Bạn có muốn thêm giáo viên " + tenGiaoVien + " không?", "Nhắc nhở", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //Thao tác thêm
                    foreach (string str in this.DanhSachDuocChon(this.dataGridViewX_KhongThuocTo, "ColChon2", "ColMaGiaoVien2"))
                    {
                        if (!new ToChuyenMonCtrl().ThemGiaoVienVaoToChuyenMon(this.dataGridViewX_DanhSach.CurrentRow.Cells["ColMaToChuyenMon"].Value.ToString(), str))
                        {
                            MessageBoxEx.Show("Không thể thêm giáo viên " + str + " vào Tổ chuyên môn!", "Không thể thêm vào", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    toChuyenMonCtrl.HienThiDanhSachGiaoVienThuocTo(this.dataGridViewX_DanhSach, this.dataGridViewX_ThuocTo);
                    toChuyenMonCtrl.HienThiDanhSachGiaoVienKhongThuocTo(this.dataGridViewX_DanhSach, this.dataGridViewX_KhongThuocTo);

                    if (this.dataGridViewX_KhongThuocTo.Rows.Count <= 0)
                    {
                        this.buttonX_Them.Enabled = false;
                        this.buttonItemContext_Them.Enabled = false;
                        this.buttonItem_Context_ThemVao_Thuoc.Enabled = true;
                    }
                    else
                    {
                        this.buttonX_Them.Enabled = true;
                        this.buttonItemContext_Them.Enabled = true;
                        this.buttonItem_Context_ThemVao_Thuoc.Enabled = false;
                    }
                    this.buttonX_Bo.Enabled = true;
                    this.buttonItem_Context_LoaiBo.Enabled = true;
                    this.buttonItem_Context_LoaiBo_Thuoc.Enabled = true;
                }
            }
            else
                MessageBoxEx.Show("Bạn chưa chọn giáo viên cần thêm! \nBạn phải đánh dấu check ở đầu dòng.", "Không thể thêm vào", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonX_Bo_Click(object sender, EventArgs e)
        {
            if (this.KiemTraDanhDauChon(this.dataGridViewX_ThuocTo, "ColChon"))
            {
                string tenGiaoVien = "";
                foreach (string str in this.DanhSachDuocChon(this.dataGridViewX_ThuocTo, "ColChon", "ColTenGiaoVien"))
                {
                    tenGiaoVien += str + ", ";
                }
                if (MessageBoxEx.Show("Bạn có muốn loại bỏ giáo viên " + tenGiaoVien + " ra khỏi tổ không?", "Nhắc nhở", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //Thao tác loại bỏ
                    foreach (string str in this.DanhSachDuocChon(this.dataGridViewX_ThuocTo, "ColChon", "ColMaGiaoVien"))
                    {
                        if (!new ToChuyenMonCtrl().XoaGiaoVienKhoiToChuyenMon(this.dataGridViewX_DanhSach.CurrentRow.Cells["ColMaToChuyenMon"].Value.ToString(), str))
                        {
                            MessageBoxEx.Show("Không thể loại bỏ giáo viên " + str + " khỏi Tổ chuyên môn!", "Không thể loại bỏ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    toChuyenMonCtrl.HienThiDanhSachGiaoVienThuocTo(this.dataGridViewX_DanhSach, this.dataGridViewX_ThuocTo);
                    toChuyenMonCtrl.HienThiDanhSachGiaoVienKhongThuocTo(this.dataGridViewX_DanhSach, this.dataGridViewX_KhongThuocTo);

                    if (this.dataGridViewX_ThuocTo.Rows.Count <= 0)
                    {
                        this.buttonX_Bo.Enabled = false;
                        this.buttonItem_Context_LoaiBo.Enabled = false;
                        this.buttonItem_Context_LoaiBo_Thuoc.Enabled = false;
                    }
                    else
                    {
                        this.buttonX_Bo.Enabled = true;
                        this.buttonItem_Context_LoaiBo.Enabled = true;
                        this.buttonItem_Context_LoaiBo_Thuoc.Enabled = true;
                    }
                    this.buttonX_Them.Enabled = true;
                    this.buttonItemContext_Them.Enabled = true;
                    this.buttonItem_Context_ThemVao_Thuoc.Enabled = true;
                }
            }
            else
                MessageBoxEx.Show("Bạn chưa chọn giáo viên cần loại bỏ! \nBạn phải đánh dấu check ở đầu dòng.", "Không thể loại bỏ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
        }

        private void dataGridViewX_DanhSach_SelectionChanged(object sender, EventArgs e)
        {
            toChuyenMonCtrl.HienThiDanhSachGiaoVienThuocTo(this.dataGridViewX_DanhSach, this.dataGridViewX_ThuocTo);
            toChuyenMonCtrl.HienThiDanhSachGiaoVienKhongThuocTo(this.dataGridViewX_DanhSach, this.dataGridViewX_KhongThuocTo);

            if (this.dataGridViewX_ThuocTo.Rows.Count <= 0)
            {
                this.buttonX_Bo.Enabled = false;
                this.buttonItem_Context_LoaiBo.Enabled = false;
                this.buttonItem_Context_LoaiBo_Thuoc.Enabled = false;
            }
            else
            {
                this.buttonX_Bo.Enabled = true;
                this.buttonItem_Context_LoaiBo.Enabled = true;
                this.buttonItem_Context_LoaiBo_Thuoc.Enabled = true;
            }

            if (this.dataGridViewX_KhongThuocTo.Rows.Count <= 0)
            {
                this.buttonX_Them.Enabled = false;
                this.buttonItem_Context_ThemVao.Enabled = false;
                this.buttonItem_Context_ThemVao_Thuoc.Enabled = false;
            }
            else
            {
                this.buttonX_Them.Enabled = true;
                this.buttonItem_Context_ThemVao.Enabled = true;
                this.buttonItem_Context_ThemVao_Thuoc.Enabled = true;
            }
        }

        /// <summary>
        /// Kiểm tra xem có đánh dấu chọn (ít nhất 1 dòng) trên data grid view chưa
        /// </summary>
        /// <param name="dataGridViewX"></param>
        /// <returns>true: nếu có ít nhất 1 dòng được check. Ngược lại, false: nếu không có dòng nào được check</returns>
        private bool KiemTraDanhDauChon(DataGridViewX dataGridViewX, string tenCot)
        {
            bool ok = false;
            foreach (DataGridViewRow row in dataGridViewX.Rows)
            {
                try
                {
                    ok = ok || (Convert.ToBoolean(row.Cells[tenCot].Value).ToString() == Boolean.TrueString);
                }
                catch
                {
                    ok = ok || true;
                }
            }
            return ok;
        }

        private List<string> DanhSachDuocChon(DataGridViewX dataGridViewX, string tenCotCheck, string tenCotGiaoVien)
        {
            List<string> listChecked = new List<string>();
            foreach (DataGridViewRow row in dataGridViewX.Rows)
            {
                if (Convert.ToBoolean(row.Cells[tenCotCheck].Value).ToString() == Boolean.TrueString)
                {
                    listChecked.Add(row.Cells[tenCotGiaoVien].Value.ToString());
                }
            }
            return listChecked;
        }

        private void buttonItem_ChonTatCa_Click(object sender, EventArgs e)
        {
            this.ChonTatCa(this.dataGridViewX_KhongThuocTo, "ColChon2", true);
        }

        private void buttonItem_HuyChon_Click(object sender, EventArgs e)
        {
            this.ChonTatCa(this.dataGridViewX_KhongThuocTo, "ColChon2", false);
        }

        private void ChonTatCa(DataGridViewX dataGridViewX, string tenCotCheck, bool chonTatCa)
        {
            string TrueFalse = chonTatCa == true ? Boolean.TrueString : Boolean.FalseString;
            foreach (DataGridViewRow row in dataGridViewX.Rows)
            {
                if (Convert.ToBoolean(row.Cells[tenCotCheck].Value).ToString() != TrueFalse)
                {
                    row.Cells[tenCotCheck].Value = TrueFalse;
                }
            }
        }

        private void buttonItem_Context_ChonTatCa_Thuoc_Click(object sender, EventArgs e)
        {
            this.ChonTatCa(this.dataGridViewX_ThuocTo, "ColChon", true);
        }

        private void buttonItem_Context_HuyChon_Thuoc_Click(object sender, EventArgs e)
        {
            this.ChonTatCa(this.dataGridViewX_ThuocTo, "ColChon", false);
        }



        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLHSTPTTHSP.Initiation;
using DevComponents.DotNetBar;
using QLHSTPTTHSP.Controller;

namespace QLHSTPTTHSP.PresentationLayer
{
    public partial class frmNienHoc : Office2007Form
    {
        NienHocCtrl nienHocCtrl = new NienHocCtrl();
        bool trangThaiThemMoi = false;        
        string m_MaNienHocMoiThem = "";        
        List<string> list = new List<string>();

        public frmNienHoc()
        {
            InitializeComponent();
            this.TGBatDau.Width = this.TGKetThuc.Width = (this.Width - this.MaNienHoc.Width - this.TenNienHoc.Width - 20) / 2;            
        }

        private void frmNienHoc_Load(object sender, EventArgs e)
        {
            this.comboBoxExTenNienHoc.Items.AddRange(new string[] { "2000-2001", "2001-2002", "2002-2003", "2003-2004", "2004-2005", "2005-2006", "2006-2007", "2007-2008", "2008-2009", "2009-2010", "2010-2011", "2011-2012", "2012-2013", "2013-2014", "2014-2015", "2015-2016", "2016-2017" });                       
            
            nienHocCtrl.LayDanhSachNienHoc(this.dGVNienHoc, this.bindingNavigatorNienHoc, this.textBoxXMaNienHoc, this.comboBoxExTenNienHoc, this.dateTimeInputTGBD, this.dateTimeInputTGKT);

            if (this.dGVNienHoc.Rows.Count > 0)
                this.ChoPhepThemXoaSua(true, true, true);
            else
                this.ChoPhepThemXoaSua(true, false, false);
        }        

        private void toolStripButtonDong_Click(object sender, EventArgs e)
        {            
            this.Close();
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

        #region Xử lý các thao tác Thêm, Xóa, Cập nhật
        private void toolStripButtonThem_Click(object sender, EventArgs e)
        {            
            this.ChoPhepThemXoaSua(false, true, true);                                      

            DataRow row = nienHocCtrl.ThemDongMoi();
            row["ma_nien_hoc"] = this.textBoxXMaNienHoc.Text = this.m_MaNienHocMoiThem = nienHocCtrl.SinhMaNienHoc();// Tự động sinh mã niên học và cho hiển thị lên textboxMaNienHoc
            row["ten_nien_hoc"] = "";
            row["tg_bat_dau"] = DateTime.Today;
            row["tg_ket_thuc"] = DateTime.Today;
            nienHocCtrl.ThemNienHoc(row); // Insert một dòng vào csdl                      
            this.bindingNavigatorNienHoc.BindingSource.MoveLast();
            this.trangThaiThemMoi = true;            
        }

        private void toolStripButtonXoa_Click(object sender, EventArgs e)
        {
            if (this.dGVNienHoc.CurrentRow != null)
            {
                string tenNienHoc = this.dGVNienHoc.CurrentRow.Cells["TenNienHoc"].Value.ToString();

                if (MessageBoxEx.Show("Bạn có muốn xóa vĩnh viễn thông tin niên học " + tenNienHoc + " không?\nNếu bạn xóa niên học " + tenNienHoc + " có thể làm sai những dữ liệu có liên quan khác!", "Nhắc nhở", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (true)//kiểm tra xem có xóa được không?
                    {
                        list.Add(this.dGVNienHoc.CurrentRow.Cells["MaNienHoc"].Value.ToString());

                        this.bindingNavigatorNienHoc.BindingSource.RemoveCurrent();
                        if (this.dGVNienHoc.Rows.Count > 0)
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
            if (this.dGVNienHoc.IsCurrentCellInEditMode == true) this.dGVNienHoc.EndEdit();
            // Kiểm tra nhập liệu có hợp lệ chưa
            if (this.HopLe())
            {
                int soDongAnhHuong = nienHocCtrl.CapNhat();// Cập nhật những thay đổi
                
                if (soDongAnhHuong > 0)
                {
                    MessageBoxEx.Show("Cập nhật thành công! Có " + soDongAnhHuong + " sự kiện đã được cập nhật.", "Xin chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ChoPhepThemXoaSua(true, true, true);
                    if (this.trangThaiThemMoi)
                    {
                        // thông tin học kỳ của niên học vừa mới thêm
                        new HocKyCtrl().ThemHocKy(this.m_MaNienHocMoiThem);
                        this.trangThaiThemMoi = false;
                    }
                    if (this.list.Count > 0)
                    {
                        // Xóa từng học kỳ của niên học trong list niên học bị xóa
                        foreach (string s in list)
                        {
                            new HocKyCtrl().XoaHocKy(s);
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

        #region Bắt sự kiện trên các control

        private void comboBoxExTenNienHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bindingNavigatorNienHoc.BindingSource.EndEdit();
        }

        private void dateTimeInputTGBD_TextChanged(object sender, EventArgs e)
        {
            this.bindingNavigatorNienHoc.BindingSource.EndEdit();
        }

        private void dateTimeInputTGKT_TextChanged(object sender, EventArgs e)
        {
            this.bindingNavigatorNienHoc.BindingSource.EndEdit();
        }
        #endregion

        /// <summary>
        /// Kiểm tra tất cả các dòng xem có hợp lệ chưa?
        /// </summary>
        /// <returns></returns>
        private bool HopLe()
        {            
            foreach (DataGridViewRow row in this.dGVNienHoc.Rows)
            {
                if (!this.KiemTra(row))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra trên từng dòng xem có ngoại lệ xảy ra không?
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private bool KiemTra(DataGridViewRow row)
        {
            string maNienHoc = row.Cells["MaNienHoc"].Value.ToString();
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (row.Cells["TenNienHoc"].Value.ToString().Trim() == "")
                {
                    MessageBoxEx.Show("Niên học " + maNienHoc + " chưa có tên!", "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                try
                {
                    DateTime dateTimeTGBD = DateTime.Parse(row.Cells["TGBatDau"].Value.ToString());
                    DateTime dateTimeTGKT = DateTime.Parse(row.Cells["TGKetThuc"].Value.ToString());
                    if (dateTimeTGBD.Year <= dateTimeTGKT.Year)
                    {
                        if (dateTimeTGBD.Year == dateTimeTGKT.Year)
                        {
                            if (dateTimeTGBD.Month >= dateTimeTGKT.Month)
                            {
                                MessageBoxEx.Show("Thời gian bắt đầu niên học không thể trễ hơn Thời gian kết thúc niên học của niên học " + maNienHoc + "!", "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        MessageBoxEx.Show("Thời gian bắt đầu niên học không thể trễ hơn Thời gian kết thúc niên học của niên học " + maNienHoc + "!", "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch
                {
                    MessageBoxEx.Show("Thời gian của niên học " + maNienHoc + " không hợp lệ!", "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }                        
            }
            return true;
        }

        private void frmNienHoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxEx.Show("Bạn có muốn lưu lại những thay đổi không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.toolStripButtonCapNhat_Click(sender, e);
            }            
        }
        
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLKTX.BusinessObject;
using QLKTX.Controller;
namespace QLKTX.Dialog
{
    public partial class DiaLog_KhenThuong : Form
    {
        bool Adding = false;
        bool Updating = false;
        KhenThuongCtrl ctrl = new KhenThuongCtrl();
        public KhenThuongInfo KhenThuong =new KhenThuongInfo();
        public DiaLog_KhenThuong()
        {
            InitializeComponent();
        }

        private void DiaLog_KhenThuong_Load(object sender, EventArgs e)
        {
            ctrl.LayLenListView(listKhenThuong);            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (Adding)
            {
                Adding = false;
                btnThem.Text = "Thêm";
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnKetThuc.Visible = true;
                btnLuu_Sua.Visible = false;
                btnLuu_Them.Visible = false;

                listKhenThuong.Enabled = true;

                txtMa.Enabled = false;
                txtTen.Enabled = false;

            }
            else
            {
                Adding = true;
                btnThem.Text = "Bỏ qua";
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnKetThuc.Visible = false;
                btnLuu_Sua.Visible = false;
                btnLuu_Them.Visible = true;
                btnLuu_Them.Location = btnKetThuc.Location;

                listKhenThuong.Enabled = false;

                txtMa.Enabled = false;
                txtTen.Enabled = true;
                txtMa.Text = ctrl.LayMaLonNhat().ToString();
                txtTen.Text = "";

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Hoạt Động", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ctrl.KiemTra(txtMa, txtTen))
                {
                    KhenThuongInfo hoatdong = ctrl.ControlToInfo(txtMa, txtTen);
                    ctrl.Xoa(hoatdong);
                    ctrl.LayLenListView(listKhenThuong);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                Updating = false;
                btnSua.Text = "Sửa";
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnKetThuc.Visible = true;
                btnLuu_Sua.Visible = false;
                btnLuu_Them.Visible = false;

                listKhenThuong.Enabled = true;

                txtMa.Enabled = false;
                txtTen.Enabled = false;
            }
            else
            {
                Updating = true;
                btnSua.Text = "Bỏ qua";
                btnXoa.Enabled = false;
                btnThem.Enabled = false;
                btnKetThuc.Visible = false;
                btnLuu_Them.Visible = false;
                btnLuu_Sua.Visible = true;
                btnLuu_Sua.Location = btnKetThuc.Location;

                listKhenThuong.Enabled = false;

                txtMa.Enabled = false;
                txtTen.Enabled = true;

            }
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            if (ctrl.KiemTra(txtMa, txtTen))
            {
                KhenThuong = ctrl.ControlToInfo(txtMa, txtTen);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnLuu_Them_Click(object sender, EventArgs e)
        {
            if (ctrl.KiemTra(txtMa, txtTen))
            {
                KhenThuongInfo hoatdong = ctrl.ControlToInfo(txtMa, txtTen);
                ctrl.Them(hoatdong);
                ctrl.LayLenListView(listKhenThuong);


                Adding = false;
                btnThem.Text = "Thêm";
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnKetThuc.Visible = true;
                btnLuu_Sua.Visible = false;
                btnLuu_Them.Visible = false;

                listKhenThuong.Enabled = true;

                txtMa.Enabled = false;
                txtTen.Enabled = false;
            }
        }

        private void btnLuu_Sua_Click(object sender, EventArgs e)
        {


            if (ctrl.KiemTra(txtMa, txtTen))
            {
                KhenThuongInfo phong = ctrl.ControlToInfo(txtMa, txtTen);
                ctrl.Sua(phong);
                ctrl.LayLenListView(listKhenThuong);

                Updating = false;
                btnSua.Text = "Sửa";
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnKetThuc.Visible = true;
                btnLuu_Them.Visible = false;
                btnLuu_Sua.Visible = false;

                listKhenThuong.Enabled = true;

                txtMa.Enabled = false;
                txtTen.Enabled = false;
            }
        }

        private void listKhenThuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctrl.ListViewToControl(listKhenThuong, txtMa, txtTen);
        }

        
    }
}
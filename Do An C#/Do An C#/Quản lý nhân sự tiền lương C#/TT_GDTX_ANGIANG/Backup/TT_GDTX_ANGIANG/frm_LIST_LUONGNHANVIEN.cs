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
using TT_GDTX_ANGIANG.DataLayer;

namespace TT_GDTX_ANGIANG
{
    public partial class frm_LIST_LUONGNHANVIEN : DevComponents.DotNetBar.Office2007Form
    {
        public frm_LIST_LUONGNHANVIEN()
        {
            InitializeComponent();
        }
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
        private void frm_LIST_LUONGNHANVIEN_Load(object sender, EventArgs e)
        {

            LuongNhanVienCtrl ctrlluong = new LuongNhanVienCtrl();
            ctrlluong.HienThi_dsLuongNhanVienDS(this.listViewExLuong);
            if (this.listViewExLuong.Items.Count > 0)
            {
                              
                SelectedIndex = 0;

                this.listViewExLuong.Items[this.SelectedIndex].Selected = true;
                

            }

          }

        private void listViewExLuong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        private void listViewExLuong_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (this.listViewExLuong.Items.Count > 0)
                {
                    IEnumerator ie = this.listViewExLuong.SelectedItems.GetEnumerator();
                    if (ie.MoveNext())
                    {
                        this.listViewExLuong.Items[this.SelectedIndex].ImageIndex = -1;
                        this.listViewExLuong.Items[this.SelectedIndex].BackColor = Color.White;
                        this.listViewExLuong.Items[this.SelectedIndex].ForeColor = Color.Black;

                        ListViewItem item = (ListViewItem)ie.Current;
                        item.ImageIndex = 0;
                        item.BackColor = Color.FromArgb(100, 150, 255);
                        item.ForeColor = Color.White;

                        this.SelectedIndex = this.listViewExLuong.Items.IndexOf(item);
                        
                    }
                }
            
        }

        private void LamTuoi_toolStripButton_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("Loading");
            LuongNhanVienCtrl ctrlluong = new LuongNhanVienCtrl();
            ctrlluong.HienThi_dsLuongNhanVienDS(this.listViewExLuong);
            if (this.listViewExLuong.Items.Count > 0)
            {
                
                SelectedIndex = 0;

                this.listViewExLuong.Items[this.SelectedIndex].Selected = true;
                
            }
        }

        private void Thoat_toolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region  listView_DoubleClick

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            this.ShowDetail();
        }
        #endregion
        #region ShowDetail()
        private void ShowDetail()
        {
            IEnumerator ie = listViewExLuong.SelectedItems.GetEnumerator();
            if (ie.MoveNext())
            {
                ListViewItem li = (ListViewItem)ie.Current;
                frm_LUONGNHANVIEN frm_luong = new frm_LUONGNHANVIEN();
                

                LươngNhanVienInfo info = new LươngNhanVienInfo();
                info = (LươngNhanVienInfo)li.Tag;
                frm_luong.LuongNhanVienSelected = info;

                //frm_nhanvien.SelectedIndex = this.listView1.Items.IndexOf(li);
                frm_luong.LayMaNhanVien_LuongNhanVien = li.SubItems[0].Text;     
                
                //frm_luong.MdiParent = this.MdiParent;
                frm_luong.WindowState = FormWindowState.Normal;
                //frm_luong.An_Hien = this.An_Hien;
                frm_luong.Show();
            }
        }
         #endregion

       }
   }

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TT_GDTX_ANGIANG.Report
{
    public partial class frm_InDanhSachNhanVien_PhongBan : DevComponents.DotNetBar.Office2007Form
    {
        public frm_InDanhSachNhanVien_PhongBan()
        {
            InitializeComponent();
        }

        TT_GDTX_ANGIANG.Report.InDanhSachNhanVien_PhongBan report = new TT_GDTX_ANGIANG.Report.InDanhSachNhanVien_PhongBan();
        private void frm_InDanhSachNhanVien_PhongBan_Load(object sender, EventArgs e)
        {
            DataService dt = new DataService();
            Connect();
            

            TT_GDTX_ANGIANG.Controller.PhongBanCtrl ctrl_PhongBan = new TT_GDTX_ANGIANG.Controller.PhongBanCtrl();

            ctrl_PhongBan.HienThiComboBox(cmbPhongBan);

            DataTable y = (DataTable)cmbPhongBan.DataSource;
            cmbPhongBan.SelectedIndex = y.Rows.Count - 1;
            

            para();
            cmbPhongBan.SelectedIndexChanged += new EventHandler(cmbPhongBan_SelectedIndexChanged);          
        }

        private void Connect()
        {
            CrystalDecisions.Shared.TableLogOnInfo tliCurrent = new CrystalDecisions.Shared.TableLogOnInfo();
            foreach (CrystalDecisions.CrystalReports.Engine.Table tbCurrent in report.Database.Tables)
            {
                tliCurrent = tbCurrent.LogOnInfo;
                tliCurrent.ConnectionInfo.ServerName = TT_GDTX_ANGIANG.Properties.Settings.Default.servername;
                tliCurrent.ConnectionInfo.UserID = TT_GDTX_ANGIANG.Properties.Settings.Default.username;
                tliCurrent.ConnectionInfo.Password = TT_GDTX_ANGIANG.Properties.Settings.Default.pass;
                tliCurrent.ConnectionInfo.DatabaseName = TT_GDTX_ANGIANG.Properties.Settings.Default.databasename;
                tbCurrent.ApplyLogOnInfo(tliCurrent);
            }
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
        void para()
        {
            

            if (cmbPhongBan.SelectedValue.ToString() == "%")
            {
                report.SetParameterValue("paraMaPB", cmbPhongBan.SelectedValue.ToString());
                report.SetParameterValue("paraPhongBan", "Tất cả phòng ban");
               
            }
            else
            {

                report.SetParameterValue("paraMaPB", cmbPhongBan.SelectedValue.ToString());
                report.SetParameterValue("paraPhongBan", cmbPhongBan.Text.ToString());
               
            }
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }

        private void cmbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            para();
        }
    }
}
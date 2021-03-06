using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TT_GDTX_ANGIANG.BusinessObject;

namespace TT_GDTX_ANGIANG.DataLayer
{
    public class DanTocData
    {
       
        #region Service
        private DataService m_Service;
        public DataService Service
        {
            get { return m_Service; }
            set { m_Service = value; }
        }
        #endregion       

        #region lay_dsDanToc()        
        public DataTable lay_dsDanToc()
        {
            if (Service == null)
                Service = new DataService();
            SqlCommand cmd = new SqlCommand("Select * From DANTOC");
            Service.Load(cmd);
            return Service;
        }
        #endregion

        #region Update()       
        public bool Update()
        {
            return Service.Update();
        }
        #endregion

        #region GetDanToc()
        public DanTocInfo GetDanToc(string maDT)
        {
            if (this.Service == null)
            {
                this.Service = new DataService();
            }
            SqlCommand cmd = new SqlCommand("Select TENDT From DANTOC Where MADT = @ma");
            cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = maDT;
            this.Service.Load(cmd);

            return new DanTocInfo(maDT, this.Service.Rows[0][0].ToString());
        }
        #endregion       

        #region lay_dsNhanVienThuocDanToc
        public DataTable lay_dsNhanVienThuocDanToc(string maDT)
        {
            if (Service == null)
                Service = new DataService();
            String sql = "Select * From  HOSOTUYENDUNG, NHANVIEN Where DANTOC = @ma or DANTOCNV= @ma  ";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = maDT;
            cmd.CommandText = sql;
            Service.Load(cmd);
            return Service;
        }
        #endregion


        #region XoaDanToc

        public void XoaDanToc(String MaDT)
        {

            if (Service == null)
                Service = new DataService();
            String sql = "delete from DANTOC where MADT = @ma";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.Add("ma", SqlDbType.VarChar).Value = MaDT;
            cmd.CommandText = sql;
            Service.Load(cmd);
        }
        #endregion


        
    }
}

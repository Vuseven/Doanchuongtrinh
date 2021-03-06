using System;
using System.Collections.Generic;
using System.Text;

namespace QLDiemSoHocSinhTHPT.BusinessObject
{
    public class KhoiLopInfo
    {
        /// <summary>
        /// Mã khối lớp
        /// </summary>
        #region MaKhoiLop
        private string m_MaKhoiLop;

        public string MaKhoiLop
        {
            get { return m_MaKhoiLop; }
            set { m_MaKhoiLop = value; }
        }
        #endregion

        /// <summary>
        /// Tên khối lớp
        /// </summary>
        #region TenKhoiLop
        private string m_TenKhoiLop;

        public string TenKhoiLop
        {
            get { return m_TenKhoiLop; }
            set { m_TenKhoiLop = value; }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace QLDiemSoHocSinhTHPT.BusinessObject
{
    public class DanTocInfo
    {
        /// <summary>
        /// Mã dân tộc
        /// </summary>
        #region MaDanToc
        private int m_MaDanToc;

        public int MaDanToc
        {
            get { return m_MaDanToc; }
            set { m_MaDanToc = value; }
        }
        #endregion


        /// <summary>
        /// Tên dân tộc
        /// </summary>
        #region TenDanToc
        private string m_TenDanToc;

        public string TenDanToc
        {
            get { return m_TenDanToc; }
            set { m_TenDanToc = value; }
        }
        #endregion
    }
}

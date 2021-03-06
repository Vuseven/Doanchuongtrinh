using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DevComponents.DotNetBar;

namespace QLHSTPTTHSP.Initiation
{
    public static class XuLyChung
    {
        public static bool GhiFileXML(string tenFile, string tenServer, string tenNguoiDung, string matKhau, string tenCSDL)
        {
            
            try
            {              
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(tenFile);// Đọc nội dung tài liệu
                XmlNode root = xmlDocument.DocumentElement;
                XmlNode cauhinh = xmlDocument.CreateElement("cauhinh");
                root.AppendChild(cauhinh);

                XmlNode tenserver = xmlDocument.CreateElement("tenserver");
                tenserver.InnerText = tenServer;
                cauhinh.AppendChild(tenserver);

                XmlNode tennguoidung = xmlDocument.CreateElement("tennguoidung");
                tennguoidung.InnerText = tenNguoiDung;
                cauhinh.AppendChild(tennguoidung);

                XmlNode matkhau = xmlDocument.CreateElement("matkhau");
                matkhau.InnerText = matKhau;
                cauhinh.AppendChild(matkhau);

                XmlNode tencsdl = xmlDocument.CreateElement("tencsdl");
                tencsdl.InnerText = tenCSDL;
                cauhinh.AppendChild(tencsdl);
                xmlDocument.Save(tenFile);
            }
            catch (XmlException ex)
            {
                MessageBoxEx.Show(ex.Message + " (Vui lòng xem lại vị trí lưu tập tin KetNoi.xml)", "Lỗi lưu tập tin kết nối", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
            
            return true;
        }
    }
}

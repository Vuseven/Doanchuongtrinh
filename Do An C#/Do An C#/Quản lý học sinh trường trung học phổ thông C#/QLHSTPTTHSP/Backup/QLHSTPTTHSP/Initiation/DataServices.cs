using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Xml;
using DevComponents.DotNetBar;

namespace QLHSTPTTHSP.Initiation
{
    public class DataServices : DataTable
    {
        static string m_ConnectionString = "";
        static MySqlConnection m_MySqlConnection;
        MySqlCommand m_MySqlCommand;
        MySqlDataAdapter m_MySqlDataAdapter;

        public DataServices() { }

        /// <summary>
        /// Lấy chuỗi kết nối đến MySQL Server từ file XML
        /// </summary>
        public static string GetConnectionString(bool macDinh)
        {
            string connectionString = "";
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load("KetNoi.xml");// Đọc nội dung tài liệu
            }
            catch(XmlException ex)
            {
                MessageBoxEx.Show(ex.Message + " (Vui lòng xem lại vị trí lưu tập tin KetNoi.xml)", "Lỗi lấy tập tin kết nối", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return "";
            }
            XmlElement xmlElement = xmlDocument.DocumentElement;// Lấy nút gốc của tài liệu
            XmlNode xmlNode = macDinh == true ? xmlElement.SelectSingleNode("macdinh") : xmlElement.LastChild;
            try
            {
                connectionString = "Server=" + xmlNode.SelectSingleNode("tenserver").InnerText + ";Username=" + xmlNode.SelectSingleNode("tennguoidung").InnerText + ";Password=" + xmlNode.SelectSingleNode("matkhau").InnerText + ";Database=" + xmlNode.SelectSingleNode("tencsdl").InnerText + ";";                
            }
            catch (XmlException e)
            {
                MessageBoxEx.Show(e.Message + " (Vui lòng xem lại các thông số kết nối trong tập tin KetNoi.xml)", "Lỗi lấy chuỗi kết nối", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return connectionString;
        }
        /// <summary>
        /// Mở kết nối đến MySQL Server
        /// </summary>
        /// <returns>Kết nối thành công/thất bại</returns>
        public static bool OpenConnection(bool macDinh)
        {
            if (m_ConnectionString == "")
                m_ConnectionString = GetConnectionString(macDinh);
            try
            {
                if (m_MySqlConnection == null)
                    m_MySqlConnection = new MySqlConnection(m_ConnectionString);
                if (m_MySqlConnection.State == ConnectionState.Closed)
                    m_MySqlConnection.Open();
            }
            catch (MySqlException ex)
            {
                m_MySqlConnection.Close();
                 //2 lỗi kết nối thường gặp
                switch (ex.Number)
                {
                    case 0:
                        MessageBoxEx.Show("Không thể kết nối đến server. Vui lòng liên hệ người quản trị!", "Lỗi kết nối đến MySQL Server", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        break;
                    case 1045:
                        MessageBoxEx.Show("Tên người dùng hoặc mật khẩu không hợp lệ. Vui lòng thử lại lần nữa!", "Lỗi đăng nhập đến MySQL Server", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBoxEx.Show(ex.Message + " (Vui lòng xem lại các thông số kết nối)", "Lỗi kết nối đến MySQL Server", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        break;
                }
                return false;
            }
            return true;
        }
        /// <summary>
        /// Lấy dữ liệu với câu lệnh SELECT
        /// </summary>
        /// <param name="command"></param>
        public void Load(MySqlCommand command)
        {
            m_MySqlCommand = command;
            try
            {
                if (m_MySqlConnection == null || m_MySqlConnection.State == ConnectionState.Closed)
                {
                    if (OpenConnection(true))
                    {
                        // do nothing
                    }
                    else
                    {
                        bool bln = OpenConnection(false);
                    }
                }
                m_MySqlCommand.Connection = m_MySqlConnection;
                m_MySqlDataAdapter = new MySqlDataAdapter(m_MySqlCommand);
                
                this.Clear();
                m_MySqlDataAdapter.Fill(this);
            }
            catch (MySqlException ex)
            {
                MessageBoxEx.Show("Không thể thực thi câu lệnh này!\n" + ex.Message, "Lỗi thực thi câu lệnh", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                m_MySqlCommand.Connection.Close();
            }
        }
        /// <summary>
        /// Cập nhật CSDL và trả về kết quả có bao nhiêu dòng bị ảnh hưởng
        /// </summary>
        /// <returns></returns>
        public int ExecuteUpdate()
        {
            int result = 0;
            MySqlTransaction m_MySqlTrans = null;
            try
            {
                m_MySqlTrans = m_MySqlConnection.BeginTransaction();

                m_MySqlCommand.Connection = m_MySqlConnection;  
                m_MySqlCommand.Transaction = m_MySqlTrans;

                m_MySqlDataAdapter = new MySqlDataAdapter();
                m_MySqlDataAdapter.SelectCommand = m_MySqlCommand;

                MySqlCommandBuilder builder = new MySqlCommandBuilder(m_MySqlDataAdapter);

                result = m_MySqlDataAdapter.Update(this);
                m_MySqlTrans.Commit();
            }
            catch
            {
                if (m_MySqlTrans != null)
                    m_MySqlTrans.Rollback();
                return -1;
            }
            finally
            {
                m_MySqlCommand.Connection.Close();
            }
            return result;
        }
        /// <summary>
        /// Cập nhật CSDL bằng câu lệnh command và trả về kết quả có bao nhiêu dòng bị ảnh hưởng
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public int ExecuteUpdate(MySqlCommand command)
        {
            int result = 0;
            MySqlTransaction m_MySqlTrans = null;
            try
            {
                m_MySqlTrans = m_MySqlConnection.BeginTransaction();

                command.Connection = m_MySqlConnection;               
                command.Transaction = m_MySqlTrans;
                result = command.ExecuteNonQuery();

                this.AcceptChanges();
                m_MySqlTrans.Commit();
            }
            catch
            {
                if (m_MySqlTrans != null)
                    m_MySqlTrans.Rollback();
                throw;
            }
            finally
            {
                command.Connection.Close();
            }
            return result;
        }
         
    }
}

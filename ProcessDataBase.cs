using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ChatAppClient
{
    class NguoiDung
    {
        public static string maND;
        public string ten;
        public bool isOnline;
        public NguoiDung()
        {
            this.ten = "Khách";
            this.isOnline = false;
        }

        public NguoiDung(string hoVaTen)
        {
            this.ten = hoVaTen;
            this.isOnline = true;
        }
    }
    class ProcessDataBase
    {
        string s = @"Data Source=LAPTOP-QK9EJR95\SQLEXPRESS;Initial Catalog=ChatApp;Integrated Security=True";
        SqlConnection sqlConnect = null;
        public void KetNoiCSDL()
        {
            sqlConnect = new SqlConnection(s);
            if (sqlConnect.State != ConnectionState.Open)
                sqlConnect.Open();
        }
        void DongKetNoiCSDL()
        {
            if (sqlConnect.State != ConnectionState.Closed)
                sqlConnect.Close();
        }

        public DataTable DocBang(string sqlQuery)
        {
            DataTable t = new DataTable();
            KetNoiCSDL();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);
            sqlDataAdapter.Fill(t);
            DongKetNoiCSDL();
            sqlDataAdapter.Dispose();
            return t;
        }

        public static string MaHoaMatKhau(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        public bool XacThuc(string tenDangNhap, string password)
        {
            password = MaHoaMatKhau(password);
            KetNoiCSDL();
            SqlDataReader reader = new SqlCommand($"Select * From NguoiDung Where maND = N'{tenDangNhap}'", sqlConnect).ExecuteReader();
            while (reader.Read())
            {
                if (reader["matKhau"].ToString() == password)
                {
                    DongKetNoiCSDL();
                    return true;
                }
            }
            DongKetNoiCSDL();
            return false;
        }

        public List<string> DanhSachOnline()
        {
            List<string> danhSachOnline = new List<string>();
            KetNoiCSDL();
            SqlDataReader reader = new SqlCommand($"Select * From NguoiDung Where isOnline = 1 and maND != N'{NguoiDung.maND}'", sqlConnect).ExecuteReader();
            while (reader.Read())
            {
                danhSachOnline.Add(reader["maND"].ToString());
            }

            DongKetNoiCSDL();
            return danhSachOnline;
        }

        public NguoiDung LayThongTin(string tenDangNhap)
        {
            NguoiDung nguoiDung = new NguoiDung();
            KetNoiCSDL();
            SqlDataReader reader = new SqlCommand($"Select * From NguoiDung Where maND = N'{tenDangNhap.Trim()}'", sqlConnect).ExecuteReader();
            while (reader.Read())
            {
                NguoiDung.maND = reader["maND"].ToString();
                nguoiDung = new NguoiDung(reader["maND"].ToString());
                CapNhatDuLieu($"Update NguoiDung Set isOnline = 1 where maND=N'{NguoiDung.maND}'");
            }
            DongKetNoiCSDL();
            return nguoiDung;
        }
        public void CapNhatDuLieu(string sqlQuery)
        {
            SqlCommand cm = new SqlCommand();
            KetNoiCSDL();
            cm.Connection = sqlConnect;
            cm.CommandText = sqlQuery;
            cm.ExecuteNonQuery();
            DongKetNoiCSDL();
            cm.Dispose();
        }

        public bool KiemTraLap(string tenBang, string id, string colName)
        {
            DataTable tb = DocBang("Select * from " + tenBang + " where " + colName + " = N\'" + id + "\'");
            bool lap = tb.Rows.Count > 0;
            tb.Dispose();
            return lap;
        }
        public bool KiemTraOnline(string maND)
        {
            DataTable tb = DocBang($"Select * from NguoiDung where maND = N'{maND}' and isOnline = N'1'");
            bool lap = tb.Rows.Count > 0;
            tb.Dispose();
            return lap;
        }
    }
}

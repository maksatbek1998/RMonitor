using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Monitor.DataBase
{
    class BaseData
    {
        public MySqlConnection connection = new MySqlConnection("datasource=192.168.0.118; port=3306;Initial Catalog='rskbank';username=admin;password=1;CharSet=utf8;");
        public delegate void SendData(DataTable data);
        public event SendData del;
        public void SoursData(string s)
        {
            try
            {
                connection.Close();
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = s;
                cmd.ExecuteNonQuery();
                DataTable dta1 = new DataTable();
                MySqlDataAdapter dataadap = new MySqlDataAdapter(cmd);
                dataadap.Fill(dta1);
                del(dta1);
                connection.Close();
            }
            catch 
            {
            
            }
        }

        public string DisplayReturn(string s)
        {
            try
            {
                connection.Open();
                string sql = s, value = "";
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    value = reader[0].ToString();

                }
                connection.Close();
                return value;
            }
            catch 
            {
                return "";
            }
        }
    }
}

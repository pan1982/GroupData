using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace GroupData
{
    class DataHandling
    {

        public SqlConnection conn;
        //При инициализации делаем конструктор для получения подключения по строке
        public DataHandling()
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GroupDataConnectionString"].ConnectionString);
            }
            catch 
            {
                conn = null;
                MessageBox.Show("Не удалось установить подключение. Возможно не корректно введенны данные в строку подключения");
            }
        }
        //Определим имя таблицы в первой базе по текущему подключению
        //У нас одна таблица, поэтому получаем первый элемент
        public string GetTableName()
        {
            string TableName;
            try
            {
                conn.Open();
                DataTable table = conn.GetSchema("Tables");
                TableName = table.Rows[0].ItemArray[2].ToString();
                conn.Close();
            }
            catch 
            {

                ShowMessage("Не удалось определить таблицу в базе данных. Проверьте подключение и перезапустите программу");
                return null;
            }
            return TableName;
        }
        //Получим список колонок таблицы
        public DataTable GetColumns()
        {
            try
            {
                conn.Open();
                DataTable Columns = conn.GetSchema("Columns");
                conn.Close();
                return Columns;
            }
            catch
            {
                ShowMessage("Не удалось определить колонки в таблице базы данных. Проверьте подключение и перезапустите программу");
                return null;
            }
            
        }
        //Выполняем запрос и заполняем таблицу полученными данными
        public void GetData(string query, DataGridView table)
        {
            try
            {
                SqlDataAdapter dataadapter = new SqlDataAdapter(query, conn);
                DataTable ds = new DataTable();
                int q = dataadapter.Fill(ds);
                table.DataSource = ds;
            }
            catch 
            {
                ShowMessage("Не удалось выполнить запрос к базе данных. Проверьте подключение и перезапустите программу");
            }
        }
        private void ShowMessage(string mess)
        {
            MessageBox.Show(mess);
        }
    }
}

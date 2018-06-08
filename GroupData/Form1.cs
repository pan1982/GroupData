using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;


namespace GroupData
{
    public partial class Form1 : Form
    {

        DataHandling dh = new DataHandling();
        List<CheckBox> chkBoxList = new List<CheckBox>(); //Список чекбоксов
        List<string> columnsForSumm = new List<string>(); //Список суммируемых колонок

        public Form1()
        {
            InitializeComponent();
        }
        
        //На основании не числовых колонок создадим чекбоксы, а числовые колнки добавим в список для суммирования
        private void AddCheckBoxes()
        {
            DataTable columns = dh.GetColumns();
            int X = 0;
            CheckBox box;
            for (int i = 0; i < columns.Rows.Count; i++)
            {
                string columnName = columns.Rows[i].ItemArray[3].ToString();
                string columnType = columns.Rows[i].ItemArray[7].ToString();
                string numericTypes = "numeric, int, decimal, float, smallint, money, smallmoney";
                if (numericTypes.IndexOf(columnType) == -1)
                {
                    box = new CheckBox();
                    box.Tag = i.ToString();
                    box.Text = columnName;
                    box.Name = columnName;
                    box.AutoSize = true;
                    box.Location = new Point(X + 10, 15);
                    this.Controls.Add(box);
                    X = box.Bounds.Right;
                    chkBoxList.Add(box);
                }
                else
                {
                    columnsForSumm.Add($"SUM({columnName}) as {columnName}");
                }
            }
        }
        
        //Загрузка полной таблицы. Выполняется при открытии формы и если не отмечен ни один чекбокс.
        private void LoadFullTable()
        {
            string tableName = dh.GetTableName();

            string query = $"Select * from {tableName}";
            dh.GetData(query, MainTable);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (dh.conn != null)
            {
                AddCheckBoxes();
                LoadFullTable();
            }
        }
        //Очищаем таблицу
        private void ResetDataGridView()
        {
            MainTable.CancelEdit();
            MainTable.Columns.Clear();
            MainTable.DataSource = null;
        }
        
        //По нажатию на кнопку происходит формирование запроса и выполнение его с заполнением таблицы
        private void BGroup_Click(object sender, EventArgs e)
        {

            if (dh.conn != null)
            {
                var checkedItems = (from a in chkBoxList where a.Checked select a.Name).ToList();

                string GroupItems = String.Join(", ", checkedItems);
                string sumItems = String.Join(", ", columnsForSumm);

                ResetDataGridView();
                MainTable.AutoGenerateColumns = true;

                if (GroupItems != String.Empty)
                {
                    string tableName = dh.GetTableName();
                    string query = $"Select {GroupItems} , {sumItems} FROM {tableName} Group by {GroupItems}";

                    dh.GetData(query, MainTable);
                }
                else
                {
                    LoadFullTable();
                }
            }
        }
    
    }

}

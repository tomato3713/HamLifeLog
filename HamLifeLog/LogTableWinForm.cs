using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace HamLifeLog
{
    public partial class LogTableWinForm : Form
    {
        private string dataBaseFilePath;
        private string _sql_version;
        private DataTable dataTable;

        public LogTableWinForm(string filePath, string version)
        {
            InitializeComponent();
            dataBaseFilePath = filePath;
            _sql_version = version;
            dataTable = new DataTable();
            using (var con = new SQLiteConnection("Data Source=" + dataBaseFilePath + ";" + _sql_version))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM DXLog";
                var sda = new SQLiteDataAdapter(cmd);
                sda.Fill(dataTable);
            }
            LogTableDataGridView.DataSource = dataTable;
            LogTableDataGridView.FirstDisplayedScrollingRowIndex = LogTableDataGridView.Rows.Count - 1;

            Text = dataBaseFilePath;
        }

        public void LogTableUpdate()
        {
            using (var con = new SQLiteConnection("Data Source=" + dataBaseFilePath + ";" + _sql_version))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM DXLog";
                var sda = new SQLiteDataAdapter(cmd);
                sda.Fill(dataTable);
            }
            LogTableDataGridView.FirstDisplayedScrollingRowIndex = LogTableDataGridView.Rows.Count - 1;
            Text = dataBaseFilePath;
        }
    }
}

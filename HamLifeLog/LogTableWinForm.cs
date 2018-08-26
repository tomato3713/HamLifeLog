using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace HamLifeLog
{
    public partial class LogTableWinForm : Form
    {
        private string dataBaseFilePath;
        private string _sql_version;

        public LogTableWinForm(string filePath, string version)
        {
            InitializeComponent();
            dataBaseFilePath = filePath;
            _sql_version = version;
            var dataTable = new DataTable();
            using (var con = new SQLiteConnection("Data Source=" + dataBaseFilePath + ";" + _sql_version))
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM DXLog";
                var sda = new SQLiteDataAdapter(cmd);
                sda.Fill(dataTable);
            }
            LogTableDataGridView.DataSource = dataTable;
        }

        private void LogTableWinForm_Load(object sender, EventArgs e)
        {
        }
    }
}

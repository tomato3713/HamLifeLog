using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HamLifeLog
{
    public partial class SelectModeForm : Form
    {
        private string _mode;

        public string Mode { get => _mode; set => _mode = value; }

        public SelectModeForm(string mode)
        {
            _mode = mode;
            InitializeComponent();
        }

        private void SelectSSBButton_Click(object sender, EventArgs e)
        {
            Mode = "SSB";
            Close();
        }

        private void SelectAMButton_Click(object sender, EventArgs e)
        {
            Mode = "AM";
            Close();
        }

        private void SelectFMButton_Click(object sender, EventArgs e)
        {
            Mode = "FM";
            Close();
        }

        private void SelectCWButton_Click(object sender, EventArgs e)
        {
            Mode = "CW";
            Close();
        }
    }
}
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
        private string _mode; // return value

        public SelectModeForm()
        {
            InitializeComponent();
        }

        public string Mode { get => _mode; set => _mode = value; }
    }
}
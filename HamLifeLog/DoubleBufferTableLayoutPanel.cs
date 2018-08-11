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
    public partial class DoubleBufferTableLayoutPanel : TableLayoutPanel
    {
        public DoubleBufferTableLayoutPanel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            DoubleBuffered = true;
        }
    }
}

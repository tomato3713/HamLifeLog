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
    public partial class SelectBandForm : Form
    {
        private double _band;

        public SelectBandForm(double band)
        {
            _band = band;
            InitializeComponent();
        }

        public double Band { get => _band; set => _band = value; }

        private void Button135kHz_Click(object sender, EventArgs e)
        {
            _band = 135;
            Close();
        }

        private void Button19kHz_Click(object sender, EventArgs e)
        {
            _band = 1900;
            Close();
        }

        private void Button35MHz_Click(object sender, EventArgs e)
        {
            _band = 3500;
            Close();
        }

        private void Button7MHz_Click(object sender, EventArgs e)
        {
            _band = 7000;
            Close();
        }

        private void Button10MHz_Click(object sender, EventArgs e)
        {
            _band = 10000;
            Close();
        }

        private void Button14MHz_Click(object sender, EventArgs e)
        {
            _band = 14000;
            Close();
        }

        private void Button18MHz_Click(object sender, EventArgs e)
        {
            _band = 18000;
            Close();
        }

        private void Button21MHz_Click(object sender, EventArgs e)
        {
            _band = 21000;
            Close();
        }

        private void Button24MHz_Click(object sender, EventArgs e)
        {
            _band = 24000;
            Close();
        }

        private void Button28MHz_Click(object sender, EventArgs e)
        {
            _band = 28000;
            Close();
        }

        private void Button144MHz_Click(object sender, EventArgs e)
        {
            _band = 144000;
            Close();
        }

        private void Button50MHz_Click(object sender, EventArgs e)
        {
            _band = 50000;
            Close();
        }

        private void Button430MHz_Click(object sender, EventArgs e)
        {
            _band = 430000;
            Close();
        }

        private void Button1200MHz_Click(object sender, EventArgs e)
        {
            _band = 1200000;
            Close();
        }

        private void Button2400MHz_Click(object sender, EventArgs e)
        {
            _band = 2400000;
            Close();
        }

        private void Button5600Mhz_Click(object sender, EventArgs e)
        {
            _band = 5600000;
            Close();
        }

        private void Button10GHz_Click(object sender, EventArgs e)
        {
            _band = 10000000;
            Close();
        }

        private void Button24GHz_Click(object sender, EventArgs e)
        {
            _band = 24000000;
            Close();
        }

        private void Button47GHz_Click(object sender, EventArgs e)
        {
            _band = 47000000;
            Close();
        }

        private void Button75GHz_Click(object sender, EventArgs e)
        {
            _band = 75000000;
            Close();
        }
    }
}

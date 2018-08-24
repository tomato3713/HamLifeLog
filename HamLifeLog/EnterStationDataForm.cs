using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace HamLifeLog
{
    public partial class EnterStationDataForm : Form
    {
        public EnterStationDataForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Save Station Data to StationData.json
            StationData stationData = new StationData
            {
                Call = CallTextBox.Text,
                Name = NameTextBox.Text,
                Address1 = Address1TextBox.Text,
                Address2 = Address2TextBox.Text,
                State = StateTextBox.Text,
                City = CityTextBox.Text,
                Coutry = CountryTextBox.Text,
                JCCNum = JCCNumTextBox.Text,
                GridSquare = GridSquareTextBox.Text,
                CQZone = CQZoneTextBox.Text,
                ITUZone = ITUZoneTextBox.Text,
                Club = ClubTextBox.Text,
                EmailAddress = EmailAddressTextBox.Text
            };
#if DEBUG
            string json = JsonConvert.SerializeObject(stationData, Formatting.Indented);
            Console.WriteLine(json);
#else
            string json = JsonConvert.SerializeObject(stationData, Formatting.None);
#endif
        }
    }
    class StationData
    {
        public string Call { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Coutry { get; set; }
        public string JCCNum { get; set; }
        public string GridSquare { get; set; }
        public string CQZone { get; set; }
        public string ITUZone { get; set; }
        public string Club { get; set; }
        public string EmailAddress { get; set; }
    }
}

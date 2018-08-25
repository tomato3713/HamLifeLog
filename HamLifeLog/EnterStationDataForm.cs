using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace HamLifeLog
{
    public partial class EnterStationDataForm : Form
    {
        private string stationDataFilePath;

        public EnterStationDataForm(string fnamePath)
        {
            InitializeComponent();
            stationDataFilePath = fnamePath;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Button1_Click(sender, e);
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
            // write file
            Encoding utf8Enc = Encoding.GetEncoding("UTF-8");
            try
            {
                StreamWriter writer = new StreamWriter(stationDataFilePath, false, utf8Enc);
                writer.WriteLine(json);
                writer.Close();
            }
            catch(UnauthorizedAccessException exc)
            {
                System.Windows.Forms.MessageBox.Show("Fault to write staton data to " + stationDataFilePath  + "\n" +
                    "Error : " + exc.Message + "\n"+
                    "Not have needed authorization.");
            }
            catch(IOException exc)
            {
                System.Windows.Forms.MessageBox.Show("Fault to write staton data to " + stationDataFilePath + "\n" +
                    "Error : " + exc.Message + "\n"+
                    "May File is locked.");
            }
            finally
            {
                System.Windows.Forms.MessageBox.Show("Written Station data to " + stationDataFilePath);
            }
        }

        private void EnterStationDataForm_Load(object sender, EventArgs e)
        {
            // load stationData.json
            if (File.Exists(stationDataFilePath))
            {
                // read stationdataFile
                try
                {
                    Encoding utf8Enc = Encoding.GetEncoding("UTF-8");
                    StreamReader reader = new StreamReader(
                        stationDataFilePath, utf8Enc);
                    string json = reader.ReadToEnd();
                    reader.Close();

                    StationData stationData = JsonConvert.DeserializeObject<StationData>(json);
                    // enter textBox
                    CallTextBox.Text = stationData.Call;
                    NameTextBox.Text = stationData.Name;
                    Address1TextBox.Text = stationData.Address1;
                    Address2TextBox.Text = stationData.Address2;
                    StateTextBox.Text = stationData.State;
                    CityTextBox.Text = stationData.City;
                    CountryTextBox.Text = stationData.Coutry;
                    JCCNumTextBox.Text = stationData.JCCNum;
                    GridSquareTextBox.Text = stationData.GridSquare;
                    CQZoneTextBox.Text = stationData.CQZone;
                    ITUZoneTextBox.Text = stationData.ITUZone;
                    ClubTextBox.Text = stationData.Club;
                    EmailAddressTextBox.Text = stationData.EmailAddress;
                }
                catch (UnauthorizedAccessException exc)
                {
                    System.Windows.Forms.MessageBox.Show("Fault to read staton data to " + stationDataFilePath + "\n" +
                        "Error : " + exc.Message + "\n" +
                        "Not have needed authorization.");
                }
                catch (IOException exc)
                {
                    System.Windows.Forms.MessageBox.Show("Fault to read staton data to " + stationDataFilePath + "\n" +
                        "Error : " + exc.Message + "\n" +
                        "May File is locked.");
                }
            }
        }
    }
    public class StationData
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

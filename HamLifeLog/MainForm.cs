using System;
using System.Windows.Forms;
using SimpleBrowser;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace HamLifeLog
{
    public partial class MainForm : Form
    {
        private LogDataBindingClass _data;
        private ManipulateDataBaseClass dataBase;
        private Timer timer;
        private string stationDataFile = "stationData.json";
        private StationData stationData;

        public string StationDataFile { get => stationDataFile; set => stationDataFile = value; }
        public StationData StationData { get => stationData; set => stationData = value; }

        public MainForm()
        {
            InitializeComponent();
            dataBase = new ManipulateDataBaseClass();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // load station data
            if (File.Exists(stationDataFile)) LoadStationData();
            else
            {
                // 子フォームを表示してステーションデータを入力させる。
                Form EnterStationDataForm = new EnterStationDataForm(stationDataFile);
                // display the new form.
                EnterStationDataForm.ShowDialog();

                // read sationDataFile
                LoadStationData();
            }

            this._data = new LogDataBindingClass();

            // asign Instance to data binding source.
            this.logDataBindingClassBindingSource.DataSource = _data;

            // フォーカスをブラウザとロガーで行き来する
            browser.PreviewKeyDown += new PreviewKeyDownEventHandler(WebBrowser_PreviewKeyDown);

            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(this.Timer1_Tick);
            timer.Interval = 1000;

            timer.Start();
        }

        private void LoadStationData()
        {
            try
            {
                Encoding utf8Enc = Encoding.GetEncoding("UTF-8");
                StreamReader reader = new StreamReader(stationDataFile, utf8Enc);
                string json = reader.ReadToEnd();
                reader.Close();

                StationData stationData = JsonConvert.DeserializeObject<StationData>(json);
            }
            catch (UnauthorizedAccessException exc)
            {
                System.Windows.Forms.MessageBox.Show("Fault to read staton data to " + stationDataFile + "\n" +
                    "Error : " + exc.Message + "\n" +
                    "Not have needed authorization.");
            }
            catch (IOException exc)
            {
                System.Windows.Forms.MessageBox.Show("Fault to read staton data to " + stationDataFile + "\n" +
                    "Error : " + exc.Message + "\n" +
                    "May File is locked.");
            }
        }


        // フォーカスをブラウザとロガー間で行き来させるため
        // KeyDown event after setting IsInputKey to true
        private void WebBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    CallTextBox.Focus();
                    break;
            }

        }

        private void TextBox_mode_TextChanged(object sender, EventArgs e)
        {
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // press enter key, move focus.
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (CallTextBox.Focused) { HisSignalRSTTextBox.Focus(); }
                    else if (HisSignalRSTTextBox.Focused) { MySignalRSTTextBox.Focus(); }
                    else if (MySignalRSTTextBox.Focused) { CommentTextBox.Focus(); }
                    break;
                case Keys.F9:
                    // Add now writing Log
                    string stationPrefix = "";
                    string stationQTH = "";
                    string stationName = "";
                    string operatorName = "";
                    double band = 0.0;
                    dataBase.SetLoggingData(
                        _data.RawDate, _data.HisCallSign,
                        _data.Frequency, _data.Mode,
                        _data.HisSignalRST, _data.MySignalRST,
                        stationPrefix, stationQTH,
                        stationName, _data.Comment,
                        band, operatorName
                    );

                    dataBase.AddLog();
                    break;
            }
        }

        private void NewCreateDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.NewCreateTable();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (CallTextBox.Text != _data.HisCallSign) _data.HisCallSign = CallTextBox.Text;
            if (MySignalRSTTextBox.Text != _data.MySignalRST) _data.MySignalRST = MySignalRSTTextBox.Text;
            if (HisSignalRSTTextBox.Text != _data.HisSignalRST) _data.HisSignalRST = HisSignalRSTTextBox.Text;
            if (CommentTextBox.Text != _data.Comment) _data.Comment = CommentTextBox.Text;
            if (ShowModeTextBox.Text != _data.Mode) _data.Mode = ShowModeTextBox.Text;
            if (DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss") != _data.Date) _data.RawDate = DateTime.UtcNow;
        }

        private void CallTextBox_Enter(object sender, EventArgs e)
        {
            CallTextBox.SelectAll();
        }

        private void StationDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 子フォームを表示してステーションデータを入力させる。
            Form EnterStationDataForm = new EnterStationDataForm(stationDataFile);
            // display the new form.
            EnterStationDataForm.ShowDialog();

            // read sationDataFile
            LoadStationData();
        }
    }
}


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
        private readonly string settingDataFilePath;
        private StationData stationData;
        private readonly string _assemblyDirectoryPath;
        private readonly string stationDataFileName;

        public StationData StationData { get => stationData; set => stationData = value; }

        public MainForm()
        {
            InitializeComponent();
            string _assembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            System.IO.FileInfo _fileInfo = new System.IO.FileInfo(_assembly);
            _assemblyDirectoryPath = _fileInfo.Directory.FullName;

            settingDataFilePath = System.IO.Path.Combine(_assemblyDirectoryPath, "setting");

            if (!System.IO.Directory.Exists(settingDataFilePath))
            {
                System.IO.Directory.CreateDirectory(settingDataFilePath);
            }

            // set setting file name
            stationDataFileName = "stationData.json";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            dataBase = new ManipulateDataBaseClass(_assemblyDirectoryPath);

            // load station data if not found station data file
            string stationDataFilePath = System.IO.Path.Combine(settingDataFilePath, stationDataFileName);
            if(!System.IO.File.Exists(stationDataFilePath)) StationDataToolStripMenuItem_Click(sender, e);

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
            string stationDataFile = System.IO.Path.Combine(settingDataFilePath, stationDataFileName);
            try
            {
                Encoding utf8Enc = Encoding.GetEncoding("UTF-8");
                StreamReader reader = new StreamReader(stationDataFile, utf8Enc);
                string json = reader.ReadToEnd();
                reader.Close();

                stationData = JsonConvert.DeserializeObject<StationData>(json);
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

                    // clear logging space
                    ClearLoggingSpace();

                    break;
            }
        }

        private void ClearLoggingSpace()
        {
            _data.HisCallSign = "";
            _data.Comment = "";
            if (_data.Mode == "CW") { _data.HisSignalRST = "599"; _data.MySignalRST = "599"; }
            else { _data.HisSignalRST = "59"; _data.MySignalRST = "59"; }
            CallTextBox.Focus();
        }

        private void NewCreateDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fname = dataBase.FileName;
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = dataBase.Startup_path,
                FileName = fname,
                Filter = "SQL database ファイル|*.sqlite;*.s3db|すべてのファイル|*.*",
                ShowHelp = true,
                // CreatePrompt = true,
                OverwritePrompt = true,
            };

            // ダイアログを表示し、戻り値が [OK] の場合は、選択したファイルを表示する
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                fname = saveFileDialog.FileName;
            }

            // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
            saveFileDialog.Dispose();

            dataBase.NewCreateTable(fname);
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
            if (ShowModeLabel.Text != _data.Mode) _data.Mode = ShowModeLabel.Text;
            if (DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss") != _data.Date) _data.RawDate = DateTime.UtcNow;
        }

        private void CallTextBox_Enter(object sender, EventArgs e)
        {
            CallTextBox.SelectAll();
        }

        private void StationDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string stationDataFilePath = System.IO.Path.Combine(settingDataFilePath, stationDataFileName);
            // 子フォームを表示してステーションデータを入力させる。
            Form EnterStationDataForm = new EnterStationDataForm(stationDataFilePath);
            // display the new form.
            EnterStationDataForm.ShowDialog(this);
            // reload station data file
            LoadStationData();
        }

        private void HelpHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open help form.
            System.Windows.Forms.MessageBox.Show("未実装です");
        }

        private void OpenDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // select data base file.
            string fname = dataBase.FileName;
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = dataBase.Startup_path,
                FileName = fname,
                Filter = "SQL database ファイル|*.sqlite;*.s3db|すべてのファイル|*.*",
                ShowHelp = true,
            };

            // ダイアログを表示し、戻り値が [OK] の場合は、選択したファイルを表示する
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                fname = openFileDialog.FileName;
            }

            // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
            openFileDialog.Dispose();

            dataBase.FileName = fname;
        }

        private void ShowModeTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void ShowModeLabel_Click(object sender, EventArgs e)
        {
            // select send mode form.
            // 子フォームを表示してモードを選ぶ。
            SelectModeForm SelectModeForm = new SelectModeForm(_data.Mode);
            // display the new form.
            SelectModeForm.ShowDialog();

            _data.Mode = SelectModeForm.Mode;

            SelectModeForm.Dispose();
        }
    }
}


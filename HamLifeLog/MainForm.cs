using System;
using System.Windows.Forms;
using SimpleBrowser;

namespace HamLifeLog
{
    public partial class MainForm : Form
    {
        private LogDataBindingClass _data;
        private ManipulateDataBaseClass dataBase;
        private System.Windows.Forms.Timer timer;

        public MainForm()
        {
            InitializeComponent();
            dataBase = new ManipulateDataBaseClass();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CefSharp.Cef.Initialize();
            CefSharp.WinForms.ChromiumWebBrowser browser = new CefSharp.WinForms.ChromiumWebBrowser("http://www.google.co.jp");
            this.Controls.Add(browser);
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
            Form EnterStationDataForm = new EnterStationDataForm();
            // display the new form.
            EnterStationDataForm.Show();
        }
    }
}


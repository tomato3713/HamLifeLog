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
            /*
            this._data = new LogDataBindingClass();

            // asign Instance to data binding source.
            this.bindingsour.DataSource = _data;

            // フォーカスをブラウザとロガーで行き来する
            webBrowser.PreviewKeyDown += new PreviewKeyDownEventHandler(WebBrowser_PreviewKeyDown);

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
                    textBox_hisCallsign.Focus();
                    break;
            }

        }

        private void TextBox_mode_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // press enter key, move focus.
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    bool forward = e.Modifiers != Keys.Shift;
                    this.SelectNextControl(this.ActiveControl, forward, true, true, true);
                    e.Handled = true;
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
                        stationName, _data.Note,
                        band, operatorName
                    );

                    dataBase.AddLog();
                    break;
            }
        }

        private void FileFToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void DataBindingClassBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void DataBindingClassBindingSource_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void DataBindingClassBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (textBox_hisCallsign.Text != _data.HisCallSign) _data.HisCallSign = textBox_hisCallsign.Text;
            if (textBox_MySignalRST.Text != _data.MySignalRST) _data.MySignalRST = textBox_MySignalRST.Text;
            if (textBox_HisSignalRST.Text != _data.HisSignalRST) _data.HisSignalRST = textBox_HisSignalRST.Text;
            if (NoteTextBox.Text != _data.Note) _data.Note = NoteTextBox.Text;
            if (DateTime.UtcNow.ToString("yyyy/MM/dd HH:mm:ss") != _data.Date) _data.RawDate = DateTime.UtcNow;
            */
        }
    }
}


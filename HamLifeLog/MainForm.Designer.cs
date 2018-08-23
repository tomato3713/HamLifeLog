namespace HamLifeLog
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.doubleBufferTableLayoutPanel1 = new HamLifeLog.DoubleBufferTableLayoutPanel();
            this.MySignalRSTTextBox = new System.Windows.Forms.TextBox();
            this.logDataBindingClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.ShowDateLabel = new System.Windows.Forms.Label();
            this.LogSpaceTitleLabel = new System.Windows.Forms.Label();
            this.CallTextBox = new System.Windows.Forms.TextBox();
            this.HisSignalRSTTextBox = new System.Windows.Forms.TextBox();
            this.ShowModeTextBox = new System.Windows.Forms.TextBox();
            this.ShowBandsLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.browser = new System.Windows.Forms.WebBrowser();
            this.doubleBufferTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logDataBindingClassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // doubleBufferTableLayoutPanel1
            // 
            this.doubleBufferTableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.doubleBufferTableLayoutPanel1.ColumnCount = 5;
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.34229F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.70468F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.63423F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.63423F));
            this.doubleBufferTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.68457F));
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.MySignalRSTTextBox, 3, 1);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.CommentTextBox, 4, 1);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.ShowDateLabel, 4, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.LogSpaceTitleLabel, 0, 0);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.CallTextBox, 0, 1);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.HisSignalRSTTextBox, 2, 1);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.ShowModeTextBox, 1, 1);
            this.doubleBufferTableLayoutPanel1.Controls.Add(this.ShowBandsLabel, 1, 0);
            this.doubleBufferTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.doubleBufferTableLayoutPanel1.Location = new System.Drawing.Point(0, 306);
            this.doubleBufferTableLayoutPanel1.Name = "doubleBufferTableLayoutPanel1";
            this.doubleBufferTableLayoutPanel1.RowCount = 2;
            this.doubleBufferTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.doubleBufferTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.doubleBufferTableLayoutPanel1.Size = new System.Drawing.Size(800, 144);
            this.doubleBufferTableLayoutPanel1.TabIndex = 0;
            // 
            // MySignalRSTTextBox
            // 
            this.MySignalRSTTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MySignalRSTTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logDataBindingClassBindingSource, "MySignalRST", true));
            this.MySignalRSTTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MySignalRSTTextBox.Location = new System.Drawing.Point(386, 94);
            this.MySignalRSTTextBox.Name = "MySignalRSTTextBox";
            this.MySignalRSTTextBox.Size = new System.Drawing.Size(53, 25);
            this.MySignalRSTTextBox.TabIndex = 5;
            this.MySignalRSTTextBox.Text = "MySignalRST";
            // 
            // logDataBindingClassBindingSource
            // 
            this.logDataBindingClassBindingSource.DataSource = typeof(HamLifeLog.LogDataBindingClass);
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logDataBindingClassBindingSource, "Comment", true));
            this.CommentTextBox.Location = new System.Drawing.Point(448, 94);
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(346, 25);
            this.CommentTextBox.TabIndex = 4;
            // 
            // ShowDateLabel
            // 
            this.ShowDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowDateLabel.AutoSize = true;
            this.ShowDateLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logDataBindingClassBindingSource, "Date", true));
            this.ShowDateLabel.Location = new System.Drawing.Point(448, 27);
            this.ShowDateLabel.Name = "ShowDateLabel";
            this.ShowDateLabel.Size = new System.Drawing.Size(346, 18);
            this.ShowDateLabel.TabIndex = 1;
            this.ShowDateLabel.Text = "yyyy/mm/dd hh:mm:ss";
            // 
            // LogSpaceTitleLabel
            // 
            this.LogSpaceTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LogSpaceTitleLabel.AutoSize = true;
            this.LogSpaceTitleLabel.Location = new System.Drawing.Point(6, 27);
            this.LogSpaceTitleLabel.Name = "LogSpaceTitleLabel";
            this.LogSpaceTitleLabel.Size = new System.Drawing.Size(168, 18);
            this.LogSpaceTitleLabel.TabIndex = 0;
            this.LogSpaceTitleLabel.Text = "LoggingSpace";
            // 
            // CallTextBox
            // 
            this.CallTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CallTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CallTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logDataBindingClassBindingSource, "HisCallSign", true));
            this.CallTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CallTextBox.Location = new System.Drawing.Point(6, 94);
            this.CallTextBox.Name = "CallTextBox";
            this.CallTextBox.Size = new System.Drawing.Size(168, 25);
            this.CallTextBox.TabIndex = 3;
            this.CallTextBox.Text = "CALL";
            this.CallTextBox.Enter += new System.EventHandler(this.CallTextBox_Enter);
            // 
            // HisSignalRSTTextBox
            // 
            this.HisSignalRSTTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.HisSignalRSTTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logDataBindingClassBindingSource, "HisSignalRST", true));
            this.HisSignalRSTTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.HisSignalRSTTextBox.Location = new System.Drawing.Point(324, 94);
            this.HisSignalRSTTextBox.Name = "HisSignalRSTTextBox";
            this.HisSignalRSTTextBox.Size = new System.Drawing.Size(53, 25);
            this.HisSignalRSTTextBox.TabIndex = 4;
            this.HisSignalRSTTextBox.Text = "HisSignalRST";
            // 
            // ShowModeTextBox
            // 
            this.ShowModeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowModeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ShowModeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logDataBindingClassBindingSource, "Mode", true));
            this.ShowModeTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ShowModeTextBox.Location = new System.Drawing.Point(183, 94);
            this.ShowModeTextBox.Name = "ShowModeTextBox";
            this.ShowModeTextBox.Size = new System.Drawing.Size(132, 25);
            this.ShowModeTextBox.TabIndex = 6;
            this.ShowModeTextBox.Text = "MODE";
            // 
            // ShowBandsLabel
            // 
            this.ShowBandsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowBandsLabel.AutoSize = true;
            this.ShowBandsLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logDataBindingClassBindingSource, "Band", true));
            this.ShowBandsLabel.Location = new System.Drawing.Point(183, 27);
            this.ShowBandsLabel.Name = "ShowBandsLabel";
            this.ShowBandsLabel.Size = new System.Drawing.Size(132, 18);
            this.ShowBandsLabel.TabIndex = 7;
            this.ShowBandsLabel.Text = "Bands\r\n";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // browser
            // 
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.Location = new System.Drawing.Point(0, 0);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(800, 306);
            this.browser.TabIndex = 1;
            this.browser.Url = new System.Uri("https://www.google.co.jp", System.UriKind.Absolute);
            this.browser.WebBrowserShortcutsEnabled = false;
            this.browser.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.WebBrowser_PreviewKeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.doubleBufferTableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.doubleBufferTableLayoutPanel1.ResumeLayout(false);
            this.doubleBufferTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logDataBindingClassBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferTableLayoutPanel doubleBufferTableLayoutPanel1;
        private System.Windows.Forms.Label LogSpaceTitleLabel;
        private System.Windows.Forms.Label ShowDateLabel;
        private System.Windows.Forms.TextBox CallTextBox;
        private System.Windows.Forms.TextBox MySignalRSTTextBox;
        private System.Windows.Forms.TextBox HisSignalRSTTextBox;
        private System.Windows.Forms.TextBox ShowModeTextBox;
        private System.Windows.Forms.Label ShowBandsLabel;
        private System.Windows.Forms.BindingSource logDataBindingClassBindingSource;
        protected System.Windows.Forms.TextBox CommentTextBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.WebBrowser browser;
    }
}


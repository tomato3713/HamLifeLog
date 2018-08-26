namespace HamLifeLog
{
    partial class LogTableWinForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LogTableDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.LogTableDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // LogTableDataGridView
            // 
            this.LogTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogTableDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTableDataGridView.Location = new System.Drawing.Point(0, 0);
            this.LogTableDataGridView.Name = "LogTableDataGridView";
            this.LogTableDataGridView.RowTemplate.Height = 27;
            this.LogTableDataGridView.Size = new System.Drawing.Size(800, 450);
            this.LogTableDataGridView.TabIndex = 0;
            // 
            // LogTableWinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LogTableDataGridView);
            this.Name = "LogTableWinForm";
            this.Text = "LogTableWinForm";
            this.Load += new System.EventHandler(this.LogTableWinForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogTableDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView LogTableDataGridView;
    }
}
namespace HamLifeLog
{
    partial class SelectModeForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SelectSSBButton = new System.Windows.Forms.Button();
            this.SelectAMButton = new System.Windows.Forms.Button();
            this.SelectFMButton = new System.Windows.Forms.Button();
            this.SelectCWButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.SelectSSBButton);
            this.flowLayoutPanel1.Controls.Add(this.SelectAMButton);
            this.flowLayoutPanel1.Controls.Add(this.SelectFMButton);
            this.flowLayoutPanel1.Controls.Add(this.SelectCWButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(330, 300);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // SelectSSBButton
            // 
            this.SelectSSBButton.Location = new System.Drawing.Point(3, 3);
            this.SelectSSBButton.Name = "SelectSSBButton";
            this.SelectSSBButton.Size = new System.Drawing.Size(325, 69);
            this.SelectSSBButton.TabIndex = 0;
            this.SelectSSBButton.Text = "SSB";
            this.SelectSSBButton.UseVisualStyleBackColor = true;
            this.SelectSSBButton.Click += new System.EventHandler(this.SelectSSBButton_Click);
            // 
            // SelectAMButton
            // 
            this.SelectAMButton.Location = new System.Drawing.Point(3, 78);
            this.SelectAMButton.Name = "SelectAMButton";
            this.SelectAMButton.Size = new System.Drawing.Size(325, 69);
            this.SelectAMButton.TabIndex = 1;
            this.SelectAMButton.Text = "AM";
            this.SelectAMButton.UseVisualStyleBackColor = true;
            this.SelectAMButton.Click += new System.EventHandler(this.SelectAMButton_Click);
            // 
            // SelectFMButton
            // 
            this.SelectFMButton.Location = new System.Drawing.Point(3, 153);
            this.SelectFMButton.Name = "SelectFMButton";
            this.SelectFMButton.Size = new System.Drawing.Size(325, 69);
            this.SelectFMButton.TabIndex = 2;
            this.SelectFMButton.Text = "FM";
            this.SelectFMButton.UseVisualStyleBackColor = true;
            this.SelectFMButton.Click += new System.EventHandler(this.SelectFMButton_Click);
            // 
            // SelectCWButton
            // 
            this.SelectCWButton.Location = new System.Drawing.Point(3, 228);
            this.SelectCWButton.Name = "SelectCWButton";
            this.SelectCWButton.Size = new System.Drawing.Size(325, 69);
            this.SelectCWButton.TabIndex = 3;
            this.SelectCWButton.Text = "CW";
            this.SelectCWButton.UseMnemonic = false;
            this.SelectCWButton.UseVisualStyleBackColor = true;
            this.SelectCWButton.Click += new System.EventHandler(this.SelectCWButton_Click);
            // 
            // SelectModeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 300);
            this.Controls.Add(this.flowLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "SelectModeForm";
            this.Text = "Select Mode";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button SelectSSBButton;
        private System.Windows.Forms.Button SelectAMButton;
        private System.Windows.Forms.Button SelectFMButton;
        private System.Windows.Forms.Button SelectCWButton;
    }
}
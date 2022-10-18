namespace Xgf.Gui {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.activeLinksBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.wholeInfoLabel = new System.Windows.Forms.Label();
            this.openWebButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.startStopButton = new System.Windows.Forms.Button();
            this.seedInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.spanTrackBar = new System.Windows.Forms.TrackBar();
            this.spanLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seedInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spanTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active Link(s)";
            // 
            // activeLinksBox
            // 
            this.activeLinksBox.FormattingEnabled = true;
            this.activeLinksBox.Location = new System.Drawing.Point(12, 27);
            this.activeLinksBox.Name = "activeLinksBox";
            this.activeLinksBox.Size = new System.Drawing.Size(231, 202);
            this.activeLinksBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.infoLabel);
            this.groupBox1.Controls.Add(this.wholeInfoLabel);
            this.groupBox1.Location = new System.Drawing.Point(249, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 111);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informations";
            // 
            // infoLabel
            // 
            this.infoLabel.Location = new System.Drawing.Point(6, 34);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(211, 74);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "nothing to show now";
            // 
            // wholeInfoLabel
            // 
            this.wholeInfoLabel.AutoSize = true;
            this.wholeInfoLabel.Location = new System.Drawing.Point(6, 19);
            this.wholeInfoLabel.Name = "wholeInfoLabel";
            this.wholeInfoLabel.Size = new System.Drawing.Size(95, 15);
            this.wholeInfoLabel.TabIndex = 0;
            this.wholeInfoLabel.Text = "0 file(s), 0 byte(s)";
            // 
            // openWebButton
            // 
            this.openWebButton.Location = new System.Drawing.Point(249, 163);
            this.openWebButton.Name = "openWebButton";
            this.openWebButton.Size = new System.Drawing.Size(223, 40);
            this.openWebButton.TabIndex = 3;
            this.openWebButton.Text = "View at gigafile.nu";
            this.openWebButton.UseVisualStyleBackColor = true;
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(249, 207);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(223, 40);
            this.downloadButton.TabIndex = 3;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            // 
            // startStopButton
            // 
            this.startStopButton.Location = new System.Drawing.Point(249, 129);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(52, 28);
            this.startStopButton.TabIndex = 4;
            this.startStopButton.Text = "Start";
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
            // 
            // seedInput
            // 
            this.seedInput.Location = new System.Drawing.Point(351, 131);
            this.seedInput.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.seedInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seedInput.Name = "seedInput";
            this.seedInput.Size = new System.Drawing.Size(121, 23);
            this.seedInput.TabIndex = 5;
            this.seedInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Seed :";
            // 
            // spanTrackBar
            // 
            this.spanTrackBar.Location = new System.Drawing.Point(90, 230);
            this.spanTrackBar.Maximum = 100000;
            this.spanTrackBar.Minimum = 1;
            this.spanTrackBar.Name = "spanTrackBar";
            this.spanTrackBar.Size = new System.Drawing.Size(153, 45);
            this.spanTrackBar.TabIndex = 7;
            this.spanTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.spanTrackBar.Value = 1;
            // 
            // spanLabel
            // 
            this.spanLabel.AutoSize = true;
            this.spanLabel.Location = new System.Drawing.Point(12, 232);
            this.spanLabel.Name = "spanLabel";
            this.spanLabel.Size = new System.Drawing.Size(57, 15);
            this.spanLabel.TabIndex = 8;
            this.spanLabel.Text = "Span: 100";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.spanLabel);
            this.Controls.Add(this.spanTrackBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seedInput);
            this.Controls.Add(this.startStopButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.openWebButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.activeLinksBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "XGF-Explorer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seedInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spanTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private CheckedListBox activeLinksBox;
        private GroupBox groupBox1;
        private Label wholeInfoLabel;
        private Button openWebButton;
        private Button downloadButton;
        private Label infoLabel;
        private Button startStopButton;
        private NumericUpDown seedInput;
        private Label label2;
        private TrackBar spanTrackBar;
        private Label spanLabel;
    }
}
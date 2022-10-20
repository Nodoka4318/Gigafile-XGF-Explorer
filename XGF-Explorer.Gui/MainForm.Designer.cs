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
            this.infoLabel = new System.Windows.Forms.TextBox();
            this.foundFileLabel = new System.Windows.Forms.Label();
            this.searchedLabel = new System.Windows.Forms.Label();
            this.openWebButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.startStopButton = new System.Windows.Forms.Button();
            this.seedInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.spanTrackBar = new System.Windows.Forms.TrackBar();
            this.spanLabel = new System.Windows.Forms.Label();
            this.seedGenButton = new System.Windows.Forms.Button();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.selectNoneButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
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
            this.activeLinksBox.Size = new System.Drawing.Size(231, 220);
            this.activeLinksBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.infoLabel);
            this.groupBox1.Controls.Add(this.foundFileLabel);
            this.groupBox1.Controls.Add(this.searchedLabel);
            this.groupBox1.Location = new System.Drawing.Point(249, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 161);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // infoLabel
            // 
            this.infoLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.infoLabel.Location = new System.Drawing.Point(6, 52);
            this.infoLabel.Multiline = true;
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.ReadOnly = true;
            this.infoLabel.Size = new System.Drawing.Size(211, 103);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "nothing selected";
            // 
            // foundFileLabel
            // 
            this.foundFileLabel.AutoSize = true;
            this.foundFileLabel.Location = new System.Drawing.Point(6, 34);
            this.foundFileLabel.Name = "foundFileLabel";
            this.foundFileLabel.Size = new System.Drawing.Size(95, 15);
            this.foundFileLabel.TabIndex = 0;
            this.foundFileLabel.Text = "0 file(s), 0 byte(s)";
            // 
            // searchedLabel
            // 
            this.searchedLabel.AutoSize = true;
            this.searchedLabel.Location = new System.Drawing.Point(6, 19);
            this.searchedLabel.Name = "searchedLabel";
            this.searchedLabel.Size = new System.Drawing.Size(63, 15);
            this.searchedLabel.TabIndex = 0;
            this.searchedLabel.Text = "0 searched";
            // 
            // openWebButton
            // 
            this.openWebButton.Enabled = false;
            this.openWebButton.Location = new System.Drawing.Point(249, 213);
            this.openWebButton.Name = "openWebButton";
            this.openWebButton.Size = new System.Drawing.Size(223, 40);
            this.openWebButton.TabIndex = 3;
            this.openWebButton.Text = "View at gigafile.nu";
            this.openWebButton.UseVisualStyleBackColor = true;
            this.openWebButton.Click += new System.EventHandler(this.openWebButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Enabled = false;
            this.downloadButton.Location = new System.Drawing.Point(249, 259);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(223, 40);
            this.downloadButton.TabIndex = 3;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            // 
            // startStopButton
            // 
            this.startStopButton.ForeColor = System.Drawing.Color.Green;
            this.startStopButton.Location = new System.Drawing.Point(249, 179);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(52, 28);
            this.startStopButton.TabIndex = 4;
            this.startStopButton.Text = "Run";
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
            // 
            // seedInput
            // 
            this.seedInput.Location = new System.Drawing.Point(351, 181);
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
            this.seedInput.Size = new System.Drawing.Size(90, 23);
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
            this.label2.Location = new System.Drawing.Point(307, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Seed :";
            // 
            // spanTrackBar
            // 
            this.spanTrackBar.Location = new System.Drawing.Point(81, 284);
            this.spanTrackBar.Maximum = 10000;
            this.spanTrackBar.Minimum = 1;
            this.spanTrackBar.Name = "spanTrackBar";
            this.spanTrackBar.Size = new System.Drawing.Size(162, 45);
            this.spanTrackBar.TabIndex = 7;
            this.spanTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.spanTrackBar.Value = 1000;
            this.spanTrackBar.Scroll += new System.EventHandler(this.spanTrackBar_Scroll);
            // 
            // spanLabel
            // 
            this.spanLabel.AutoSize = true;
            this.spanLabel.Location = new System.Drawing.Point(12, 287);
            this.spanLabel.Name = "spanLabel";
            this.spanLabel.Size = new System.Drawing.Size(63, 15);
            this.spanLabel.TabIndex = 8;
            this.spanLabel.Text = "Span: 1000";
            // 
            // seedGenButton
            // 
            this.seedGenButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seedGenButton.Location = new System.Drawing.Point(447, 179);
            this.seedGenButton.Name = "seedGenButton";
            this.seedGenButton.Size = new System.Drawing.Size(25, 28);
            this.seedGenButton.TabIndex = 4;
            this.seedGenButton.Text = "A";
            this.seedGenButton.UseVisualStyleBackColor = true;
            this.seedGenButton.Click += new System.EventHandler(this.seedGenButton_Click);
            // 
            // selectAllButton
            // 
            this.selectAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.selectAllButton.Font = new System.Drawing.Font("Yu Gothic UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectAllButton.Location = new System.Drawing.Point(12, 253);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(64, 23);
            this.selectAllButton.TabIndex = 9;
            this.selectAllButton.Text = "Select all";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // selectNoneButton
            // 
            this.selectNoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.selectNoneButton.Font = new System.Drawing.Font("Yu Gothic UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectNoneButton.Location = new System.Drawing.Point(82, 253);
            this.selectNoneButton.Name = "selectNoneButton";
            this.selectNoneButton.Size = new System.Drawing.Size(64, 23);
            this.selectNoneButton.TabIndex = 9;
            this.selectNoneButton.Text = "Select none";
            this.selectNoneButton.UseVisualStyleBackColor = true;
            this.selectNoneButton.Click += new System.EventHandler(this.selectNoneButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(152, 253);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(91, 23);
            this.exportButton.TabIndex = 10;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.selectNoneButton);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.spanLabel);
            this.Controls.Add(this.spanTrackBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seedInput);
            this.Controls.Add(this.seedGenButton);
            this.Controls.Add(this.startStopButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.openWebButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.activeLinksBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 350);
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
        private Label searchedLabel;
        private Button openWebButton;
        private Button downloadButton;
        private Button startStopButton;
        private NumericUpDown seedInput;
        private Label label2;
        private TrackBar spanTrackBar;
        private Label spanLabel;
        private Button seedGenButton;
        private Label foundFileLabel;
        private Button selectAllButton;
        private Button selectNoneButton;
        private Button exportButton;
        private TextBox infoLabel;
    }
}
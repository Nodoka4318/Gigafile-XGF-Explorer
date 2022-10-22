using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xgf.Gui {
    public partial class DownloadProgressDialog : Form {
        public bool Cancelled => _cancelled;
        public event EventHandler OnCancelButtonClicked;

        private bool _cancelled = false;
        private long _currentFileSizeToDownload = 0;

        public DownloadProgressDialog(int amount) {
            InitializeComponent();
            UpdateMessage();
            progressBar2.Maximum = amount;
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            _cancelled = true;
            OnCancelButtonClicked(this, EventArgs.Empty);
        }

        private void UpdateMessage() =>
            messageLabel.Text = $"Downloading..\n{progressBar1.Value} % of {_currentFileSizeToDownload} byte(s) \n{progressBar2.Value} of {progressBar2.Maximum} file(s)";

        public void IncrementProgressBar1(int progress, long totalFileSize) {
            progressBar1.Increment(progress);
            _currentFileSizeToDownload = totalFileSize;
            UpdateMessage();
        }
        public void IncrementProgressBar2() {
            progressBar2.PerformStep();
            UpdateMessage();
        }

        public void ResetProgressBar1() {
            progressBar1.Value = 0;
            progressBar1.Update();
            UpdateMessage();
        }
    }
}

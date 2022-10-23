using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xgf.Gui {
    public partial class Downloader : Form {
        public bool Cancelled => _cancelled;

        private bool _cancelled = false;
        private long _currentFileSizeToDownload = 0;
        private BackgroundWorker? _worker;
        private List<Gigafile> _files;
        private string _dir;
        private int _failed;

        public Downloader(List<Gigafile> files, string directory) {
            InitializeComponent();

            _worker = new BackgroundWorker();
            _worker.DoWork += _worker_DoWork;
            _worker.WorkerReportsProgress = true;
            _worker.ProgressChanged += _worker_ProgressChanged;
            _worker.RunWorkerCompleted += _worker2_RunWorkerCompleted;
            _worker.WorkerSupportsCancellation = true;

            Shown += Downloader_Shown;

            UpdateMessage();
            progressBar2.Maximum = files.Count;
            _dir = directory;
            _files = files;
        }

        private void _worker2_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e) {
            if (Cancelled)
                MessageBox.Show($"Cancelled.", "Xgf");
            else
                MessageBox.Show($"Success: {_files.Count - _failed} file(s)\nFailed: {_failed} files(s)\n\nSaved at {_dir} .", "Xgf");
            Close();
        }

        private void Downloader_Shown(object? sender, EventArgs e) {
            Run();
        }

        private void _worker_ProgressChanged(object? sender, ProgressChangedEventArgs e) {
            if ((long)e.UserState == -1l) {
                IncrementProgressBar2();
                ResetProgressBar1();
            } else {
                IncrementProgressBar1(e.ProgressPercentage, (long)e.UserState);
            }
        }

        public void Run() {
            _worker.RunWorkerAsync();
        }

        private void _worker_DoWork(object? sender, DoWorkEventArgs e) {
            _failed = 0;
            for (int i = 0; i < _files.Count; i++) {
                var file = _files[i];
                if (file.FileName == "failed to get filename (password required?)") {
                    _failed++;
                    _worker.ReportProgress((int)Math.Floor((double)i * 100 / (double)_files.Count), -1l);
                    continue;
                }

                var req = (HttpWebRequest)WebRequest.Create(file.DownloadUri);
                req.CookieContainer = new CookieContainer();
                req.CookieContainer.Add(Gigafile.GetCookieCollectionFromUri(new Uri(file.RedirectedUri)).Result);
                var response = req.GetResponse();
                var list = new List<byte>();
                var stream = response.GetResponseStream();

                using (var fs = new FileStream($@"{_dir}\{file.FileName}", FileMode.Create, FileAccess.Write)) {
                    byte[] data = new byte[1024];
                    int received = 0;
                    while (true) {
                        var size = stream.Read(data, 0, data.Length);
                        if (size == 0) {
                            break;
                        }
                        fs.Write(data, 0, size);

                        if (Cancelled) {
                            return;
                        }

                        received++;
                        // Console.WriteLine((double)fs.Length * 100d / (double)file.FileSize);
                        _worker.ReportProgress((int)((double)fs.Length * 100d / (double)file.FileSize), file.FileSize);
                    }
                }

                _worker.ReportProgress((int)Math.Floor((double)i * 100d / (double)_files.Count), -1l);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            _cancelled = true;
            _worker.CancelAsync();
        }

        private void UpdateMessage() {
            messageLabel1.Text = $"{progressBar1.Value} % of {_currentFileSizeToDownload} byte(s)";
            messageLabel2.Text = $"{Math.Min(progressBar2.Value + 1, progressBar2.Maximum)} of {progressBar2.Maximum} file(s)";
        }

        public void IncrementProgressBar1(int progress, long totalFileSize) {
            // progressBar1.Increment(progress - progressBar1.Value);
            progressBar1.Value = progress > progressBar1.Maximum ? progressBar1.Maximum : progress;
            _currentFileSizeToDownload = totalFileSize;
            UpdateMessage();
        }
        public void IncrementProgressBar2() {
            // progressBar2.PerformStep();
            progressBar2.Value = progressBar2.Value >= progressBar2.Maximum ? progressBar2.Maximum : progressBar2.Value + 1;
            UpdateMessage();
        }

        public void ResetProgressBar1() {
            progressBar1.Value = 0;
            UpdateMessage();
        }
    }
}

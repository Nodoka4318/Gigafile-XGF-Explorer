using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace Xgf.Gui {
    public partial class MainForm : Form {
        public int Seed => (int)seedInput.Value;

        private System.Windows.Forms.Timer _ticker;
        private List<string> _selected;

        public MainForm() {
            InitializeComponent();
            _ticker = new System.Windows.Forms.Timer() {
                Interval = 1000,
            };
            _selected = new List<string>();
            _ticker.Tick += _ticker_Tick;
            activeLinksBox.ItemCheck += ActiveLinksBox_ItemCheck;
            seedInput.ValueChanged += SeedInput_ValueChanged;

            seedInput.Value = Environment.TickCount;
        }

        private void SeedInput_ValueChanged(object? sender, EventArgs e) {
            Program.explorer.Seed = Seed;
        }

        private void ActiveLinksBox_ItemCheck(object? sender, ItemCheckEventArgs e) {
            BeginInvoke(new Action(CheckActiveLinksBox));
        }

        private void CheckActiveLinksBox() {
            var items = activeLinksBox.CheckedItems;
            _selected.Clear();

            foreach (var item in items) {
                _selected.Add(item.ToString());
            }

            if (items.Count <= 0) {
                infoLabel.Text = $"nothing selected";
                downloadButton.Enabled = false;
                openWebButton.Enabled = false;
            } else {
                var files = GetSelectedFiles();

                if (items.Count == 1) {
                    infoLabel.Text = $"Filename: {files[0].FileName}\r\nSize: {files[0].FileSize}\r\nCode: {files[0].Code}\r\nServer: {files[0].Server}\r\nId: {files[0].FileId}";
                    downloadButton.Enabled = true;
                    openWebButton.Enabled = true;
                    downloadButton.Text = "Download";
                } else {
                    infoLabel.Text = $"{items.Count} files selected\r\n{files.Sum(f => f.FileSize)} byte(s)";
                    downloadButton.Enabled = true;
                    openWebButton.Enabled = false;
                    downloadButton.Text = "Download all";
                }
            }
        }

        private List<Gigafile> GetSelectedFiles() =>
            Program.explorer.ValidFiles.Where(f => _selected.Contains(f.FileNameWithCode)).ToList();

        private void _ticker_Tick(object? sender, EventArgs e) {
            CheckUpdate();
        }

        private void startStopButton_Click(object sender, EventArgs e) {
            if (!Program.searching) {
                startStopButton.Text = "Pause";
                startStopButton.ForeColor = Color.Red;
                Text = "XGF-Explorer (Running)";
                _ticker.Enabled = true;
            } else {
                startStopButton.Text = "Run";
                startStopButton.ForeColor = Color.Green;
                Text = "XGF-Explorer";
                _ticker.Enabled = false;
            }
            Program.searching = !Program.searching;
        }

        private void seedGenButton_Click(object sender, EventArgs e) {
            seedInput.Value = Environment.TickCount;
            Program.explorer.Seed = Seed;
        }

        private void spanTrackBar_Scroll(object sender, EventArgs e) {
            spanLabel.Text = $"Span: {spanTrackBar.Value.ToString()}";
            _ticker.Interval = spanTrackBar.Value;
            Program.interval = spanTrackBar.Value;
        }

        private void CheckUpdate() {
            if (Program.explorer.Updated) {
                searchedLabel.Text = $"{Program.explorer.Searched} searched";
                foundFileLabel.Text = $"{Program.explorer.ValidFiles.Count()} file(s), {Program.explorer.ValidFiles.Sum(f => f.FileSize)} byte(s)";

                if (Program.explorer.HasNewFile)
                    activeLinksBox.Items.AddRange(Program.explorer.NewFiles);
            }
        }

        private void openWebButton_Click(object sender, EventArgs e) {
            Process.Start(new ProcessStartInfo() {
                FileName = GetSelectedFiles()[0].RedirectedUri,
                UseShellExecute = true,
            });
        }

        private void selectAllButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < activeLinksBox.Items.Count; i++) {
                activeLinksBox.SetItemChecked(i, true);
                CheckActiveLinksBox();
            }
        }

        private void selectNoneButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < activeLinksBox.Items.Count; i++) {
                activeLinksBox.SetItemChecked(i, false);
                CheckActiveLinksBox();
            }
        }

        private void exportButton_Click(object sender, EventArgs e) {
            var jsonStr = JsonFileItem.BuildJsonString(Program.explorer.ValidFiles);

            using (var dlg = new SaveFileDialog() {
                Title = "Export",
                Filter = "Json files(*.json)| *.json | All files(*.*) | *.*",
                FileName = DateTime.Now.ToString("yyyyMMdd-HH-mm-ss")
            }) {
                if (dlg.ShowDialog() == DialogResult.OK) {
                    File.WriteAllTextAsync(dlg.FileName, jsonStr);
                }
            }
        }

        static DownloadProgressDialog progDlg;

        private async void downloadButton_Click(object sender, EventArgs e) {
            var files = GetSelectedFiles();
            int failed = 0;
            string dir = "";

            using (var dlg = new FolderBrowserDialog()) {
                if (dlg.ShowDialog() == DialogResult.OK)
                    dir = dlg.SelectedPath;
                else
                    return;
            }

            Enabled = false;

            progDlg = new DownloadProgressDialog(files.Count);
            progDlg.Show();

            await Task.Run(async () => {
                foreach (var file in files) {
                    progDlg.ResetProgressBar1();
                    if (file.FileName == "failed to get filename (password required?)") {
                        failed++;
                        progDlg.IncrementProgressBar2();
                        continue;
                    }

                    var req = (HttpWebRequest)WebRequest.Create(file.DownloadUri);
                    req.CookieContainer = new CookieContainer();
                    req.CookieContainer.Add(await Gigafile.GetCookieCollectionFromUri(new Uri(file.RedirectedUri)));
                    var response = await req.GetResponseAsync();
                    var list = new List<byte>();
                    var stream = response.GetResponseStream();

                    using (var fs = new FileStream($@"{dir}\{file.FileName}", FileMode.Create, FileAccess.Write)) {
                        byte[] data = new byte[1024];
                        int received = 0;
                        while (true) {
                            var size = stream.Read(data, 0, data.Length);
                            if (size == 0) {
                                break;
                            }
                            fs.Write(data, 0, size);

                            received++;
                            progDlg.IncrementProgressBar1((int)Math.Floor((double)received * 100d / (double)data.Length), file.FileSize);
                        }
                    }

                    progDlg.IncrementProgressBar2();
                }
            });

            MessageBox.Show($"Success: {files.Count - failed} file(s)\nFailed: {failed} files(s)\n\nSaved at {dir}");
            progDlg.Dispose();

            Enabled = true;
        }
    }
}
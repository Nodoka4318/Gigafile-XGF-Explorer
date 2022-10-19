using System.Diagnostics;

namespace Xgf.Gui {
    public partial class MainForm : Form {
        private System.Windows.Forms.Timer _ticker;

        public MainForm() {
            InitializeComponent();
            _ticker = new System.Windows.Forms.Timer() {
                Interval = 1000,
            };
            _ticker.Tick += _ticker_Tick;

            seedInput.Value = Environment.TickCount;
        }

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
                activeLinksBox.Items.AddRange(Program.explorer.NewFiles);
            }
        }

        private void openWebButton_Click(object sender, EventArgs e) {
            Process.Start(new ProcessStartInfo() {
                 FileName = "https://example.com",
                 UseShellExecute = true,
            });
        }
    }
}
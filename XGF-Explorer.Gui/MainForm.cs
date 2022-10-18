namespace Xgf.Gui {
    public partial class MainForm : Form {

        public MainForm() {
            InitializeComponent();
        }

        private void startStopButton_Click(object sender, EventArgs e) {
            Program.searching = !Program.searching;
        }
    }
}
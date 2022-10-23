using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xgf.Gui {
    internal class Program {
        internal static Explorer explorer;
        internal static bool searching = false;
        internal static int interval = 1000;

        static bool exited;
        static MainForm form;

        static string DataPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Xgf-Explorer";
        static string LogPath = $@"{DataPath}\latest.log";

        [STAThread]
        public static void Main(string[] args) {
            if (!Directory.Exists(DataPath))
                Directory.CreateDirectory(DataPath);

            if (File.Exists(LogPath))
                File.Delete(LogPath);

            explorer = new Explorer(LogPath);
            form = new MainForm();
            explorer.Seed = form.Seed;

            Task.Run(Search);
            Application.Run(form);

            exited = true;
            var m = MessageBox.Show("Do you want to save logs?", "Xgf", MessageBoxButtons.YesNo);
            if (m == DialogResult.Yes) { 
                using (var dlg = new SaveFileDialog() {
                    Title = "Save logs",
                    Filter = "Text files(*.txt)| *.txt | All files(*.*) | *.*",
                    FileName = DateTime.Now.ToString("yyyyMMdd-HH-mm-ss")
                }) {
                    if (dlg.ShowDialog() == DialogResult.OK) {
                        File.Copy(LogPath, dlg.FileName, true);
                    }
                }
            }
        }

        private static void Search() {
            for (; ; ) {
                while (searching) {
                    explorer.SearchOneAsync();
                    Thread.Sleep(interval);
                }

                if (exited)
                    break;
            }
        }
    }
}

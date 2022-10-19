using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xgf.Gui {
    internal class Program {
        internal static Explorer explorer = new Explorer();
        internal static bool searching = false;
        internal static int interval = 1000;
        static MainForm form = new MainForm();

        [STAThread]
        public static void Main(string[] args) {
            Task.Run(Search);
            Application.Run(form);            
        }

        private static void Search() {
            for (; ; ) {
                while (searching) {
                    explorer.SearchOneAsync();
                    Thread.Sleep(interval);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xgf.Gui {
    internal class Program {
        internal static Explorer explorer = new Explorer();
        internal static bool searching = false;
        internal static int interval = 100;
        static MainForm form = new MainForm();

        public static void Main(string[] args) {
            Application.Run(form);

            for (; ; ) {
                while (searching) {
                    explorer.SearchOneAsync();
                    Thread.Sleep(interval);
                }
            }
        }
    }
}

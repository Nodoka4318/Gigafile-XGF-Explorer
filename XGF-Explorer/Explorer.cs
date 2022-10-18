using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xgf {
    public class Explorer {
        public List<Gigafile> ValidFiles => _validFiles;
        public List<string> InvalidCodes => _invalidCodes;
        public bool Updated { 
            get {
                var cur = _updated;
                _updated = false;
                return cur;
            } 
        }

        public StreamWriter logOut;

        private List<string> _searchedCodes;
        private List<Gigafile> _validFiles;
        private List<string> _invalidCodes;
        private bool _updated = false;

        private static Explorer _explorer = new Explorer();
        const string AddressBase = "https://xgf.nu/";

        public Explorer() {
            _searchedCodes = new List<string>();
            _validFiles = new List<Gigafile>();
            _invalidCodes = new List<string>();
        }

        public async Task SearchOneAsync(int seed = 0) {
            string code = "0";
            while (code == "0" || _searchedCodes.Contains(code)) {
                code = GenerateRandomCode(seed);
            }

            _searchedCodes.Add(code);

            var gfile = new Gigafile(AddressBase + code);
            var isExists = await gfile.IsFileExists();
            Log("INFO", $"Searching '{code}'.");

            if (isExists) {
                await gfile.GetFileName();
                _validFiles.Add(gfile);
                Log("VALID", $"Found '{gfile.FileName}' at '{code}'. FileSize: {gfile.FileSize}", ConsoleColor.Green);
            } else {
                _invalidCodes.Add(code);
                Log("INVALID", $"'{code}' is invalid.", ConsoleColor.Red);
            }
            _updated = true;
        }

        public static Explorer GetExplorer() {
            return _explorer;
        }

        private static string GenerateRandomCode(int seed) {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var rnd = new Random(seed == 0 ? Environment.TickCount : seed);
            string code = "";
            for (int i = 0; i < 4; i++) {
                code += chars[rnd.Next(chars.Length)];
            }
            return code;
        }

        private void Log(string flag, string message = "", ConsoleColor color = ConsoleColor.Gray) {
            Console.ForegroundColor = color;
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")} {flag}] {message}");
        }
    }
}

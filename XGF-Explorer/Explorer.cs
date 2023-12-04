using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xgf {
    public class Explorer {
        public List<Gigafile> ValidFiles => _validFiles;
        public List<string> InvalidCodes => _invalidCodes;
        public int Searched => _searchedCodes.Count();
        public bool Updated { 
            get {
                var cur = _updated;
                _updated = false;
                return cur;
            } 
        }
        public string[] NewFiles {
            get {
                var cur = _newFiles.ToArray();
                _newFiles.Clear();
                return cur;
            }
        }
        public bool HasNewFile => _newFiles.Count() > 0;
        public int Seed { get => _seed; set { _seed = value; _lastSeed = -1; } }

        public StreamWriter logOut;

        private List<string> _searchedCodes;
        private List<Gigafile> _validFiles;
        private List<string> _invalidCodes;
        private bool _updated = false;
        private List<string> _newFiles;
        private int _lastSeed = -1;
        private int _seed = 0;
        private string _logPath;

        private static Explorer _explorer = new Explorer();
        const string AddressBase = "https://xgf.nu/";

        public Explorer(string logOutPath = "") {
            _searchedCodes = new List<string>();
            _validFiles = new List<Gigafile>();
            _invalidCodes = new List<string>();
            _newFiles = new List<string>();
            _logPath = logOutPath;

            if (_logPath != "") {
                logOut = new StreamWriter(_logPath, true, Encoding.UTF8);
                logOut.AutoFlush = true;
            }
        }

        public async Task SearchOneAsync() {
            string code = "0";
            while (code == "0" || _searchedCodes.Contains(code)) {
                if (_lastSeed != -1) {
                    var newSeed = new Random(_lastSeed).Next();
                    code = GenerateRandomCode(newSeed);
                    _lastSeed = newSeed;
                } else {
                    code = GenerateRandomCode(_seed);
                    _lastSeed = _seed;
                }
                // Log("DEBUG", _lastSeed.ToString(), ConsoleColor.Cyan);
            }

            _searchedCodes.Add(code);

            Log("INFO", $"Searching '{code}'.");
            var gfile = new Gigafile(AddressBase + code);
            var isExists = await gfile.IsFileExists();
            
            if (isExists) {
                await gfile.GetFileName();
                _validFiles.Add(gfile);
                _newFiles.Add(gfile.FileNameWithCode);
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
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var rnd = new Random(seed == -1 ? Environment.TickCount : seed);
            string code = "";
            for (int i = 0; i < 5; i++) {
                code += chars[rnd.Next(chars.Length)];
            }
            return code;
        }

        private void Log(string flag, string message = "", ConsoleColor color = ConsoleColor.Gray) {
            Console.ForegroundColor = color;            
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")} {flag}] {message}");
            if (_logPath != "")
                logOut.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")} {flag}] {message}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}

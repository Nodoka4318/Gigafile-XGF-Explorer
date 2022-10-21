using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Xgf.Gui {
    internal class JsonFileItem {
        public string Code { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string Url { get; set; }

        public static string BuildJsonString(List<Gigafile> files) {
            string jsonStr = "{";
            for (int i = 0; i < files.Count; i++) {
                var file = files[i];

                var item = new JsonFileItem() {
                    Code = file.Code,
                    FileName = file.FileName,
                    FileSize = file.FileSize,
                    Url = file.RedirectedUri
                };
                var itemJson = JsonSerializer.Serialize(item, new JsonSerializerOptions() {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    WriteIndented = true 
                });
                itemJson = itemJson.Insert(0, $"\"{i}\": ");
                itemJson = String.Join("\n", itemJson.Split("\r\n").Select(s => s.Insert(0, "    ")));

                jsonStr += $"\n{itemJson},";
            }
            jsonStr = jsonStr.Remove(jsonStr.Length - 1);
            jsonStr += "\n}";

            return jsonStr;
        }
    }
}

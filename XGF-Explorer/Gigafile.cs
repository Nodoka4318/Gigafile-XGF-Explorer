using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Web;

namespace Xgf {
    public class Gigafile {
        public string Uri => _uri.ToString();
        public string RedirectedUri => _redirectedUri.ToString();
        public string FileName => _fileName;
        public string Code => _uri.ToString().Split("/")[3];
        public string FileId => _redirectedUri.ToString().Split('/')[3];
        public long FileSize => _fileSize;
        public string FileNameWithCode => $"{_fileName} ({Code})"; // リストボックス参照用
        public string Server => _redirectedUri.ToString().Substring(8, 2).Replace(".", "");
        public string DownloadUri => _dlUri;

        private Uri _uri;
        private Uri _redirectedUri;
        private bool _isFileExists;
        private bool _isRedirectedUriSet = false;
        private string _fileName = "failed to get filename (password required?)";
        private long _fileSize;
        private string _dlUri = "";
        private bool _disposed = false;

        const string DefaultGigafileAddress = "https://gigafile.nu/";

        public Gigafile(string uri) {
            _uri = new Uri(uri);

            if (uri.Contains("gigafile.nu")) {
                _redirectedUri = _uri;
                _isFileExists = true;
                _isRedirectedUriSet = true;
            }
        }

        public async Task<Uri> GetRedirectedAddress() {
            if (!_isRedirectedUriSet) {
                using (var client = new HttpClient()) {
                    HttpResponseMessage response = await client.GetAsync(_uri);
                    _redirectedUri = response.RequestMessage.RequestUri;
                    _isFileExists = IsFileExists(_redirectedUri.ToString());
                    _isRedirectedUriSet = true;
                }
            }
            return _redirectedUri;
        }

        public bool IsFileExists(string redirectedAddr) {
            var redirectedUri = new Uri(redirectedAddr);
            var defaultPageUri = new Uri(DefaultGigafileAddress);
            return !(redirectedUri == _uri || redirectedUri == defaultPageUri);
        }

        public async Task<bool> IsFileExists() {
            if (!_isRedirectedUriSet)
                _redirectedUri = await GetRedirectedAddress();
            return IsFileExists(_redirectedUri.ToString());
        }

        public async Task<Stream> DownloadFileStream() {
            if (!_isRedirectedUriSet)
                await GetRedirectedAddress();
            if (!_isFileExists)
                throw new InvalidOperationException($"File does not exist at {_uri.ToString()} .");

            var cookies = await GetCookieCollectionFromUri(_redirectedUri);
            var uriDirs = _redirectedUri.ToString().Replace("https://", "").Split("/");
            var downloadUri = $"https://{uriDirs[0]}/download.php?file={uriDirs[1]}&dlnotify=0";

            var req = (HttpWebRequest)WebRequest.Create(downloadUri);
            req.CookieContainer = new CookieContainer();
            req.CookieContainer.Add(cookies);
            var res = await req.GetResponseAsync();

            string cd = res.Headers.Get("Content-Disposition");
            if (!String.IsNullOrEmpty(cd)) {
                Regex re = new Regex(@".*[filename*=UTF]-[8]''(?<filename>.*)");
                Match m = re.Match(cd);
                if (m.Success) {
                    _fileName = HttpUtility.UrlDecode(m.Groups["filename"].Value);
                } else {
                    re = new Regex(@".*[filename=](?<filename>.*)");
                    m = re.Match(cd);
                    if (m.Success) {
                        _fileName = m.Groups["filename"].Value;
                    }
                }
                _dlUri = downloadUri;
            } else { // ネスト頭悪すぎて草
                uriDirs = _redirectedUri.ToString().Replace("https://", "").Split("/");
                downloadUri = $"https://{uriDirs[0]}/dl_zip.php?file={uriDirs[1]}&dlnotify=0";

                req = (HttpWebRequest)WebRequest.Create(downloadUri);
                req.CookieContainer = new CookieContainer();
                req.CookieContainer.Add(cookies);
                res = await req.GetResponseAsync();

                cd = res.Headers.Get("Content-Disposition");
                if (!String.IsNullOrEmpty(cd)) {
                    Regex re = new Regex(@".*[filename*=UTF]-[8]''(?<filename>.*)");
                    Match m = re.Match(cd);
                    if (m.Success) {
                        _fileName = HttpUtility.UrlDecode(m.Groups["filename"].Value);
                    } else {
                        re = new Regex(@".*[filename=](?<filename>.*)");
                        m = re.Match(cd);
                        if (m.Success) {
                            _fileName = m.Groups["filename"].Value;
                        }
                    }
                }
                _dlUri = downloadUri;
            }

            if (long.TryParse(res.Headers.Get("Content-Length"), out long ContentLength)) {
                _fileSize = ContentLength;
            }

            return res.GetResponseStream();
        }

        public async Task<string> GetFileName() {
            if (!_isRedirectedUriSet)
                await GetRedirectedAddress();
            if (!_isFileExists)
                throw new InvalidOperationException($"File does not exist at {_uri.ToString()} .");

            var cookies = await GetCookieCollectionFromUri(_redirectedUri);
            var uriDirs = _redirectedUri.ToString().Replace("https://", "").Split("/");
            var downloadUri = $"https://{uriDirs[0]}/download.php?file={uriDirs[1]}&dlnotify=0";

            var req = (HttpWebRequest)WebRequest.Create(downloadUri);
            req.CookieContainer = new CookieContainer();
            req.CookieContainer.Add(cookies);
            req.Method = "HEAD";
            var res = await req.GetResponseAsync();

            string cd = res.Headers.Get("Content-Disposition");
            if (!String.IsNullOrEmpty(cd)) {
                Regex re = new Regex(@".*[filename*=UTF]-[8]''(?<filename>.*)");
                Match m = re.Match(cd);
                if (m.Success) {
                    _fileName = HttpUtility.UrlDecode(m.Groups["filename"].Value);
                } else {
                    re = new Regex(@".*[filename=](?<filename>.*)");
                    m = re.Match(cd);
                    if (m.Success) {
                        _fileName = m.Groups["filename"].Value;
                    }
                }
                _dlUri = downloadUri;
            } else {
                downloadUri = $"https://{uriDirs[0]}/dl_zip.php?file={uriDirs[1]}&dlnotify=0";

                req = (HttpWebRequest)WebRequest.Create(downloadUri);
                req.CookieContainer = new CookieContainer();
                req.CookieContainer.Add(cookies);
                req.Method = "HEAD";
                res = await req.GetResponseAsync();

                cd = res.Headers.Get("Content-Disposition");
                if (!String.IsNullOrEmpty(cd)) {
                    Regex re = new Regex(@".*[filename*=UTF]-[8]''(?<filename>.*)");
                    Match m = re.Match(cd);
                    if (m.Success) {
                        _fileName = HttpUtility.UrlDecode(m.Groups["filename"].Value);
                    } else {
                        re = new Regex(@".*[filename=](?<filename>.*)");
                        m = re.Match(cd);
                        if (m.Success) {
                            _fileName = m.Groups["filename"].Value;
                        }
                    }
                }
                _dlUri = downloadUri;
            }

            if (long.TryParse(res.Headers.Get("Content-Length"), out long ContentLength)) {
                _fileSize = ContentLength;
            }

            return _fileName;
        }

        public async Task DownloadAndSaveFileAt(string directory) {
            var dataStream = await DownloadFileStream();

            using (var fs = new FileStream($@"{directory}\{_fileName}", FileMode.Create, FileAccess.Write)) {
                byte[] data = new byte[1024];
                while (true) {
                    var size = dataStream.Read(data, 0, data.Length);
                    if (size == 0) {
                        break;
                    }
                    fs.Write(data, 0, size);
                }
            }
            dataStream.Close();
        }

        public async static Task<CookieCollection> GetCookieCollectionFromUri(Uri uri) {
            var cc = new CookieContainer();
            var req = (HttpWebRequest)WebRequest.Create(uri);
            req.CookieContainer = new CookieContainer();
            await req.GetResponseAsync();
            return req.CookieContainer.GetCookies(uri);
        }
    }
}

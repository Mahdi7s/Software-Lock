using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using SabaMediaLock.Utilities;
using TS7S.Base;
using TS7S.Base.Encryption;
using TS7S.Base.Threading;

namespace SabaMediaLock.Wrapper
{
    internal class WebServer
    {
        public void BeginListening(string prefix, string filesDirectory)
        {            
            if (!HttpListener.IsSupported)
                throw new Exception("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");

            if(string.IsNullOrEmpty(filesDirectory))
                throw new ArgumentNullException("filesDirectory");
            if(string.IsNullOrEmpty(prefix))
                throw new ArgumentNullException("prefix");

            ThreadHelper.RunAsync(() =>
            {
                HttpListener listener = new HttpListener();
                listener.Prefixes.Add(prefix);
                listener.Start();

                while (true)
                {
                    var context = listener.GetContext();
                    var request = context.Request;
                    var response = context.Response;
                    var output = response.OutputStream;

                    
                    var url = request.Url.AbsolutePath;
                    var password = ExtractPassword(url);

                    if (password != InternalShares.ServerPassword.ToBase32())
                    {
                        response.StatusCode = 404; //not found
                        using (var writer = new StreamWriter(output))
                        {
                            writer.Write("You can't access this address.");
                            writer.Flush();
                        }
                        output.Close();
                        return;
                    }

                    var filePath = Path.Combine(filesDirectory, Path.GetFileName(url));
                    //response.SendChunked

                    if (!File.Exists(filePath))
                    {
                        response.StatusCode = 404; //not found
                        using (var writer = new StreamWriter(output))
                        {
                            writer.Write("File Not Exists!");
                            writer.Flush();
                        }
                        output.Close();
                        continue;
                    }

                    FileEncryptor fEn = new FileEncryptor(LockSetteings.Settings.Password);
                    var buffer = fEn.EncryptOrDecryptFile(fEn.GetCryptoTransform(CryptoAlgorithm.AES, false), filePath);
                    response.ContentLength64 = buffer.Length;
                   output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
            });
        }

        private string ExtractPassword(string url)
        {
            var retval = string.Empty;

            var regPattern = @"/ps=(.*?)/datasofme";
            var match = Regex.Match(url, regPattern);
            if (match.Success)
            {
                retval = match.Value.Substring(4, match.Value.Length - 14);
                //retval = HttpUtility.UrlDecode(retval);
                //retval = retval.FromBase32();
            }

            return retval;
        }        
    }
}

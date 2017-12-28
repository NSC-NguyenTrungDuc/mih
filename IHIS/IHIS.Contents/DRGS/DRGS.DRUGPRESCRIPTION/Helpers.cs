using System;
using System.Collections.Generic;
using System.Text;
using EO.WebBrowser;
using Newtonsoft.Json;
using System.IO;
using IHIS.Framework;

namespace IHIS.DRGS
{
    public static class Helpers
    {
        /// <summary>
        /// Serialize an object to JSON string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string SerializeObject(object data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            return JsonConvert.SerializeObject(data, settings);
        }

        /// <summary>
        /// Executes a JS code on current active webview
        /// </summary>
        /// <param name="webView"></param>
        /// <param name="script"></param>
        /// <returns></returns>
        public static object ExecuteScript(WebView webView, string script)
        {
            object retObj = new object();

            ScriptCall sc = webView.QueueScriptCall(script);
            sc.WaitOne();

            if (sc.IsDone())
            {
                retObj = sc.Result;
            }

            if (sc.Exception != null && sc.Exception.Message != string.Empty)
            {
                Service.WriteLog("Execute JS error. Message: " + sc.Exception.Message);
            }

            return retObj;
        }

        /// <summary>
        /// Create and save a html file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public static void SaveFileHtml(string path, string data)
        {
            path = path.Replace("file:///", "").Replace(@"/", @"\");
            // Delete the file if it exists.
            if (File.Exists(path))
            {
                // Note that no lock is put on the
                // file and the possibility exists
                // that another process could do
                // something with it between
                // the calls to Exists and Delete.
                File.Delete(path);
            }

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(data);
                }
            }
        }
    }
}

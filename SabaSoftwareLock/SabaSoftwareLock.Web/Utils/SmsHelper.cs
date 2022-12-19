using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace SabaSoftwareLock.Web
{
    public class SmsHelper
    {
        private readonly string _userName;
        private readonly string _password;
        private readonly string _smsPostAddress;

        private readonly NameValueCollection _valuesToPost = new NameValueCollection();

        public SmsHelper(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            _userName = userName; _password = password;
            _smsPostAddress = string.Format("http://sms.bahavand.com/webservice/{0}/index.php", _userName);

            _valuesToPost["username"] = _userName;
            _valuesToPost["password"] = _password;
        }

        public void SendSms(string fromNumber, string toNumber, string message)
        {
            if(string.IsNullOrEmpty(toNumber))
                throw new ArgumentNullException("toNumber");
            if(string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message");
            if (string.IsNullOrEmpty(fromNumber))
                throw new ArgumentNullException("fromNumber");

            _valuesToPost["method"] = "quickSend";
            _valuesToPost["from"] = fromNumber;
            _valuesToPost["to"] = toNumber;
            _valuesToPost["message"] = message;

            var client = new WebClient();
            var res = client.UploadValues(_smsPostAddress, "POST", _valuesToPost);
        }

        public SmsModel[] GetNewMessages()
        {
            _valuesToPost["method"] = "getNewMessages";

            var client = new WebClient();

            var jsonArrResult = client.UploadValues(_smsPostAddress, "POST", _valuesToPost);
            var jsonArrStr = Encoding.UTF8.GetString(jsonArrResult);

            Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(new Exception(string.Format("new messages: \r\n{0}", jsonArrStr))));

            var jsSerializer = new JavaScriptSerializer();
            SmsModel[] retval = jsSerializer.Deserialize(jsonArrStr, typeof(SmsModel[])) as SmsModel[];

            return retval;
        }
    }

    public class SmsModel
    {
        public string id { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string timestamp { get; set; }
        public string message { get; set; }
    }
}

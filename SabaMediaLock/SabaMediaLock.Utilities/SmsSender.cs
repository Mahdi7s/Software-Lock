using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

namespace SabaMediaLock.Utilities
{
    public class SmsSender
    {
        private readonly string _userName;
        private readonly string _password;
        private readonly string _fromNum;
        private readonly string _smsPostAddress;

        private readonly NameValueCollection _valuesToPost = new NameValueCollection();

        public SmsSender(string userName, string password, string fromNumber)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(fromNumber))
                throw new ArgumentNullException("fromNumber");

            _userName = userName; _password = password; _fromNum = fromNumber;
            _smsPostAddress = string.Format("http://sms.bahavand.com/webservice/{0}/index.php", _userName);

            _valuesToPost["username"] = _userName;
            _valuesToPost["password"] = _password;
            _valuesToPost["method"] = "quickSend";
            _valuesToPost["from"] = _fromNum;
        }

        public void Send(string toNumber, string message)
        {
            if(string.IsNullOrEmpty(toNumber))
                throw new ArgumentNullException("toNumber");
            if(string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message");

            _valuesToPost["to"] = toNumber;
            _valuesToPost["message"] = message;

            var client = new WebClient();
            var res = client.UploadValues(_smsPostAddress, "POST", _valuesToPost);
        }
    }
}

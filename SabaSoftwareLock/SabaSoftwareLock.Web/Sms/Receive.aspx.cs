using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using SabaSoftwareLock.DataModel;
using SabaSoftwareLock.Web.Utils;
using SoftwareSerial.Server;

namespace SabaSoftwareLock.Web.Sms
{
    public partial class Receive : System.Web.UI.Page
    {
        private readonly LockService _lockService = new LockService();
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                var from = ConfigurationSettings.AppSettings["fromNumber"];
                var pass = ConfigurationSettings.AppSettings["smsPassword"];
                var user = ConfigurationSettings.AppSettings["smsUserName"];

                try
                {
                    var Ssender = new SmsHelper(user, pass);
                    var newMessages = Ssender.GetNewMessages();

                    if (newMessages == null || newMessages.Length <= 0) return;

                    var msgToLog = newMessages.Aggregate("New Messages: \r\n", (curr, n) => curr += n.message + "\r\n");

                    newMessages = newMessages.Where(x => !string.IsNullOrWhiteSpace(x.from) && !string.IsNullOrWhiteSpace(x.timestamp)).GroupBy(x => x.from).Select(x => x.OrderBy(xo => TimestampConverter.ToDateTime(double.Parse(xo.timestamp))).Last()).ToArray();

                    foreach (var msg in newMessages)
                    {
                        string packageSerial = string.Empty, tempSerial = string.Empty, softShortName = string.Empty;
                        if (TryExtract(msg.message, ref packageSerial, ref tempSerial, ref softShortName))
                        {
                            string enablingSerial = string.Empty;
                            if (ValidateSerial(packageSerial, tempSerial, softShortName, ref enablingSerial))
                            {
                                if (msg.from.Length > 11)
                                    msg.from = msg.from.Replace("+98", "0");

                                Ssender.SendSms(from, msg.from, enablingSerial);
                                msgToLog += string.Format("Send sms[ from: {0} - to: {1} - text: {2} ] \r\n", from, msg.from, enablingSerial);
                            }
                            else//(s)he sent an invalid sms
                            {
                                if (_unitOfWork.SmsReportRep.AddInvalids(msg.from) <= 3)
                                {
                                    Ssender.SendSms(from, msg.from, "سریال موقتی که برای فعال سازی ارسال کرده اید نادرست می باشد. با دقت بیشتر پیامک را دوباره ارسال کنید.");
                                }
                            }
                        }
                    }

                    Elmah.ErrorLog.GetDefault(Context).Log(new Elmah.Error(new Exception(msgToLog)));
                }
                catch (Exception ex)
                {
                    Elmah.ErrorLog.GetDefault(Context).Log(new Elmah.Error(ex));
                }
            }
        }

        private bool ValidateSerial(string packageSerial, string tempSerial, string softShortName, ref string enablingSerial)
        {
            var validationCon = _lockService.Validate(softShortName, packageSerial, tempSerial);
            if (validationCon.Validation == SoftwareSerial.Model.UserSerialValidationResult.IsValid)
            {
                enablingSerial = validationCon.EnablingSerial;
                return true;
            }
            return false;
        }

        private bool TryExtract(string message, ref string packageSerial, ref string tempSerial, ref string softShortName)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                var splites = message.Split('#');
                if (splites.Length == 3 && !splites.Any(x => string.IsNullOrWhiteSpace(x)))
                {
                    packageSerial = splites[0]; tempSerial = splites[1]; softShortName = splites[2];

                    return true;
                }
            }
            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SabaMediaLock.Wrapper.Models
{
    public static class Shares
    {
        public static bool IsPrevEnabled { get; set; }
        public static bool IsNextEnabled { get; set; }
        public static bool IsFinishEnabled { get; set; }

        public static void ResetButtonEnables(bool enabled = true)
        {
            IsFinishEnabled = IsNextEnabled = IsPrevEnabled = enabled;
        }

        public static Action<bool, string> InternetActivationCallback { get; set; }
        public static Action<bool, string> SmsActivationCallback { get; set; }
        public static Action<bool, string> TelephoneActivationCallback { get; set; }

        public static Telerik.WinControls.UI.RadWizard Wizard { get; set; }
    }
}

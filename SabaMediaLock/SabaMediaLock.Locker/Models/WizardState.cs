using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SabaMediaLock.Locker.Models
{
    public static class WizardState
    {
        public static bool IsPrevEnabled { get; set; }
        public static bool IsNextEnabled { get; set; }
        public static bool IsFinishEnabled { get; set; }

        public static void ResetButtonEnables(bool enabled = true)
        {
            IsFinishEnabled = IsNextEnabled = IsPrevEnabled = enabled;
        }
    }
}

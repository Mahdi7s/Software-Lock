using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SabaMediaLock.Utilities.Localizations
{
    public class RadMessageBoxLoc : RadMessageLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadMessageStringID.CancelButton: return "لغو";
                case RadMessageStringID.OKButton: return "بله";
                case RadMessageStringID.NoButton: return "خیر";
                case RadMessageStringID.YesButton: return "بله";
            }
            var themeName ="TelerikMetroBlue";
            RadMessageBox.ThemeName = themeName;            
            ThemeResolutionService.ApplyThemeToControlTree(RadMessageBox.Instance, themeName);

            return base.GetLocalizedString(id);
        }
    }
}

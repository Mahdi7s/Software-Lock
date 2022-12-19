using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SabaMediaLock.Contracts;
using SabaMediaLock.Utilities;

namespace SabaMediaLock.Wrapper
{
    public static class StyleHelper
    {
        public static void StyleIt(FormItem item, Control control)
        {
            switch (item.ItemType)
            {
                case ItemType.Form:
                    switch (item.PropertyName)
                    {
                        case "پس زمینه":
                            control.BackgroundImage = FileUtils.LoadImage(item.PropertyValue);
                            break;
                    }
                    break;
                case ItemType.Text:
                    switch (item.PropertyName)
                    {
                        case "متن":
                            control.Text = item.PropertyValue;
                            break;
                    }
                    break;
            }
        }
    }
}

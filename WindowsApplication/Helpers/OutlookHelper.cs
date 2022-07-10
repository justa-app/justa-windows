using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using WindowsApplication.AutomationHandlers;

namespace WindowsApplication.Helpers
{
    static class OutlookHelper
    {

        public static OutlookFocusHandler HandleOutlookFocuse(object src, ref OutlookFocusHandler? outlookFocusHandler, ref Action<string> _textAction)
        {
            AutomationElement? sourceElement;
            try
            {
                sourceElement = src as AutomationElement;
                if (sourceElement == null)
                {
                    outlookFocusHandler = null;
                    return outlookFocusHandler;
                }

                if (sourceElement.Current.ProcessId == Process.GetCurrentProcess().Id)
                    return outlookFocusHandler;

                if (outlookFocusHandler != null && outlookFocusHandler.sourceElement == sourceElement)
                    return outlookFocusHandler;

                if (OutlookFocusHandler.IsFocused(sourceElement))
                {
                    OutlookFocusHandler focusHandler = new OutlookFocusHandler(sourceElement, _textAction);
                    if (outlookFocusHandler != null)
                        outlookFocusHandler.OnLostFocus();

                    outlookFocusHandler = focusHandler;

                    if (focusHandler != null)
                        focusHandler.OnFocus();
                }
                else
                {
                    if (outlookFocusHandler != null)
                        outlookFocusHandler.OnLostFocus();
                    outlookFocusHandler = null;
                }
            }
            catch (ElementNotAvailableException)
            {
                return outlookFocusHandler;
            }

            return outlookFocusHandler;

        }
    }
}

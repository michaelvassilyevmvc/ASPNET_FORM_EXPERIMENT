using System;
using System.Web.UI;
using WebFormApp.Main;

namespace WebFormApp.Extension
{
    public static class Extension
    {
        public static void ShowToastr(this Page page, string message, string title = "", ToasterMessageType type = ToasterMessageType.Info, int timeoutValue = 2000)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",ToasterMessage.Text(message, title, type, timeoutValue), addScriptTags: true);
        }

        public static void ShowToaster(this DevExpress.Web.ASPxCallbackPanel panel, string message, string title = "", ToasterMessageType type = ToasterMessageType.Info, int timeoutValue = 2000)
        {
            panel.JSProperties["cpPanelMessage"] = ToasterMessage.Text(message, title, type, timeoutValue);
        }
    }
}

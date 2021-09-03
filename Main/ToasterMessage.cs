using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFormApp.Main
{
    public static class ToasterMessage
    {
        public static string Text(string message, string title, ToasterMessageType type = ToasterMessageType.Info, int timeoutValue = 2000)
        {
            string typeMessageStr = "";
            switch (type)
            {
                case ToasterMessageType.Success:
                    typeMessageStr = "success";
                    break;
                case ToasterMessageType.Info:
                    typeMessageStr = "info";
                    break;
                case ToasterMessageType.Warning:
                    typeMessageStr = "warning";
                    break;
                case ToasterMessageType.Error:
                    typeMessageStr = "error";
                    break;
                default:
                    typeMessageStr = "success";
                    break;
            }

            return $"toastr.options.timeOut={timeoutValue};toastr.options.closeButton=true;toastr['{typeMessageStr}']('{message}','{title}')";
        }
    }
}

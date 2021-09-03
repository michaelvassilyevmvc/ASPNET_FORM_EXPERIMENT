using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormApp.Extension;
using WebFormApp.Main;

namespace WebFormApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void dsClients_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            try
            {
                e.Command.Parameters["@RegionID"].Value = cbRegions.SelectedItem?.Value ?? 0;

                if(cbRegions.SelectedItem == null)
                {
                    this.Page.ShowToastr("Не доступен список регионов", "Ошибка", ToasterMessageType.Error);
                }
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                this.Page.ShowToastr("Не доступен список регионов", "Ошибка", ToasterMessageType.Error);
            }
            catch(Exception ex)
            {
                this.Page.ShowToastr(ex.Message, "Ошибка", ToasterMessageType.Error);
            }
        }

        protected void cbPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            DevExpress.Web.ASPxCallbackPanel cbpnl = sender as DevExpress.Web.ASPxCallbackPanel;
            
            switch (e.Parameter)
            {
                case "RegionChange": 
                    cbFirms.DataBind(); 
                    cbFirms.SelectedIndex = 0;
                    cbpnl.ShowToaster($"{cbRegions.SelectedItem.Text}", "Вы выбрали", ToasterMessageType.Success);
                    break;
            }
        }
    }
}
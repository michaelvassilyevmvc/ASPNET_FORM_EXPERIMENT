<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormApp._Default" %>

<%@ Register Assembly="DevExpress.Web.v19.2, Version=19.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <dx:ASPxCallbackPanel ID="cbPanel" ClientInstanceName="cbPanel" runat="server" OnCallback="cbPanel_Callback">
        <ClientSideEvents EndCallback="function(s,e){if(s.cpPanelMessage){eval(s.cpPanelMessage); delete s.cpPanelMessage;}}" />
        <PanelCollection>
            <dx:PanelContent>

                <div class="container">
                    <div class="row" style="margin-top: 20px;">
                        <dx:ASPxComboBox
                            ID="cbRegions" ClientInstanceName="cbRegions" SelectedIndex="0"
                            runat="server" DataSourceID="dsRegions" ValueField="ID" TextField="Name" Theme="Material" Width="300" AutoPostBack="false">
                            <ClientSideEvents SelectedIndexChanged="function(s,e){ cbPanel.PerformCallback('RegionChange'); }" />
                        </dx:ASPxComboBox>
                        <br />
                        <dx:ASPxComboBox SelectedIndex="0" 
                            ID="cbFirms" ClientInstanceName="cbFirms" runat="server" DataSourceID="dsClients" ValueField="ID" TextField="Name" Theme="Material" ItemStyle-Wrap="True" Width="800px">
                        </dx:ASPxComboBox>
                    </div>
                </div>

                <asp:SqlDataSource ID="dsRegions" runat="server" ConnectionString='<%$ ConnectionStrings:MFKSConnectionString %>'
                    SelectCommand="SELECT [ID], [NameRus] as Name FROM [Regions] WHERE ParentID = 0"></asp:SqlDataSource>

                <asp:SqlDataSource
                    ID="dsClients"
                    runat="server"
                    ConnectionString="<%$ ConnectionStrings:MFKSConnectionString %>"
                    SelectCommand="SELECT F.ID, 
	F.NameRus AS Name, 
	(CASE WHEN F.ID IN (0, 1) THEN (F.ID - 10)
      WHEN F.ID IN (0,100000000) THEN (F.ID - 100000010)
		ELSE 1
	END) AS SortOrder 
	from dbo.GetAllChildFirmIDs(@RegionID) as C
inner join dbo.Firms as F on C.ID = F.ID ORDER BY SortOrder, Name"
                    OnSelecting="dsClients_Selecting">
                    <SelectParameters>
                        <asp:Parameter Name="RegionID" />
                    </SelectParameters>
                </asp:SqlDataSource>



            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxCallbackPanel>

    
    
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/ExtSurat.Master" AutoEventWireup="true" CodeBehind="frmReportDisposition.aspx.cs" Inherits="ExtSurat.frmReportDisposition" %>
<%@ Register assembly="Telerik.ReportViewer.WebForms, Version=6.2.13.109, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" namespace="Telerik.ReportViewer.WebForms" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:FormPanel runat="server" ID="pnlMain" MonitorResize="true" MonitorValid="true" Title="Laporan Disposisi">
        <TopBar>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>                    
                            <ext:ToolbarSpacer />
                            <ext:ToolbarSpacer />
                            <ext:ToolbarSpacer />
                            <ext:ToolbarSpacer />
                            <ext:ToolbarSeparator />
                            <ext:ToolbarSeparator />
                            <ext:Label ID="lblFrom" runat="server" Text="From" />
                            <ext:ToolbarSeparator />
                            <ext:DateField runat="server" ID="dfFrom" Width="90" AllowBlank="true" />
                            <ext:ToolbarSeparator />
                            <ext:Label ID="lblTo" runat="server" Text="To" />
                            <ext:ToolbarSeparator />
                            <ext:DateField runat="server" ID="dfTo" Width="90" AllowBlank="false" />
                            <ext:ToolbarSeparator />
                            <ext:ToolbarSeparator />
                            <ext:Label Text="Nomor Surat" runat="server" ID="lblNomorSurat" />
                            <ext:ToolbarSeparator />
                            <ext:TextField runat="server" ID="txtNomorSurat" EmptyText="Nomor Surat" Width="150" AllowBlank="true" />
                            <ext:ToolbarSeparator />                                                       
                            <ext:Button runat="server" ID="btnSearch" Icon="Zoom" ToolTip="Search" FormBind="true">
                                <Listeners>
                                    <Click Handler="Ext.net.DirectMethods.btnSearch_Click();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Items>                
            </ext:Toolbar>
        </TopBar>
        <Items>
        </Items>
        <Listeners>
            <ClientValidation Handler="#{btnSearch}.setDisabled(!valid);" />
        </Listeners>
    </ext:FormPanel>
    <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="600px" 
        ParametersAreaVisible="False" ShowParametersButton="False" 
        ShowZoomSelect="True" Width="100%"></telerik:ReportViewer>
</asp:Content>

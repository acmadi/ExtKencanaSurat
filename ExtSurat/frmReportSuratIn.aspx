<%@ Page Title="" Language="C#" MasterPageFile="~/TwitterBootstrap.Master" AutoEventWireup="true" CodeBehind="frmReportSuratIn.aspx.cs" Inherits="ExtSurat.frmReportSurat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:FormPanel runat="server" ID="pnlMain" MonitorResize="true" MonitorValid="true" Title="Laporan Surat Masuk/Keluar">
        <TopBar>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Toolbar ID="Toolbar2" runat="server">
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
                            <%--<ext:ToolbarSeparator />  
                            <ext:Label ID="lblTypeInbox" runat="server" Text="Surat Masuk" />
                            <ext:ToolbarSeparator />--%>
                            <%--<ext:Checkbox ID="chkInbox" runat="server" Checked="true" />
                            <ext:ToolbarSeparator />
                            <ext:Label ID="lblTypeOutbox" runat="server" Text="Surat Keluar" />
                            <ext:ToolbarSeparator />
                            <ext:Checkbox ID="chkOutbox" runat="server" Checked="true" />--%>
                            <%--<ext:FormLayout runat="server">
                                <Anchors>
                                    <ext:Anchor Horizontal="20%">
                                        <ext:RadioGroup ID="RadioGroup1" runat="server" FieldLabel="Jenis Laporan">
                                            <Items>
                                                <ext:Radio runat="server" ID="rdInbox" BoxLabel="Surat Masuk" Checked="true" />
                                                <ext:Radio runat="server" ID="rdOutbox" BoxLabel="Surat Keluar" />
                                            </Items>
                                        </ext:RadioGroup>
                                    </ext:Anchor>
                                </Anchors>
                            </ext:FormLayout>--%>
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
</asp:Content>

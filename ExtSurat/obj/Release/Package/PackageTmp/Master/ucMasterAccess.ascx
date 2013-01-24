<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMasterAccess.ascx.cs" Inherits="ExtSurat.Master.ucMasterAccess" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<ext:Panel ID="Panel2" runat="server" Title="Master Access">
    <TopBar>
        <ext:Toolbar ID="Toolbar2" runat="server">
            <Items>
                <ext:ButtonGroup ID="ButtonGroup2" runat="server" Title="Letter" Layout="TableLayout">
                    <LayoutConfig>
                        <ext:TableLayoutConfig Columns="2" />
                    </LayoutConfig>
                    <Items>
                        <ext:Button runat="server" ID="Button1" Text="Letter In" Scale="Large" Shadow="true" />
                        <ext:Button runat="server" ID="Button2" Text="Letter Out" Scale="Large" Shadow="true" />
                    </Items>
                </ext:ButtonGroup>
            </Items>
        </ext:Toolbar>
    </TopBar>
</ext:Panel>

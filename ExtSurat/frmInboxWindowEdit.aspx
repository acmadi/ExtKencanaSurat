﻿<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="frmInboxWindowEdit.aspx.cs" Inherits="ExtSurat.frmInboxWindowEdit" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Scripts/extjs/resources/css/xtheme-Kencana.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />        
        <ext:FormPanel runat="server" ID="frmPanelMain" AutoHeight="true" Padding="2" DefaultAnchor="0">
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button runat="server" ID="btnSave" Text="SAVE" Icon="Disk">
                            <Listeners>
                                <Click Handler="#{DirectMethods}.SaveData();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnCancel" Text="CANCEL" Icon="Cancel">
                            <Listeners>
                                <Click Handler="parentAutoLoadControl.close();" Delay="1" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Items>
                <ext:TextField ID="txtMasukId" runat="server" FieldLabel="ID Surat" AnchorHorizontal="-20" ReadOnly="true" Enabled="false" />                
                <ext:TextField ID="txtNomorSurat" runat="server" FieldLabel="Format Penomoran" AnchorHorizontal="-20" ReadOnly="true" />
                <ext:TextField ID="txtNomorSuratKencana" runat="server" FieldLabel="Nomor Surat Internal" AnchorHorizontal="-20" ReadOnly="true" />
                <ext:TextField ID="txtNomorSuratAsli" runat="server" FieldLabel="Nomor Surat Asal" AnchorHorizontal="-20" />
                <ext:TextField ID="txtJudul" runat="server" FieldLabel="Tittle Surat" AnchorHorizontal="-20" />
                <ext:DateField ID="dfTanggal" runat="server" FieldLabel="Tanggal" AnchorHorizontal="-20" />
                <ext:TextField ID="txtDari" runat="server" FieldLabel="Dari" AnchorHorizontal="-20" />
                <ext:TextField ID="txtKeterangan" runat="server" FieldLabel="Keterangan" AnchorHorizontal="-20" />
            </Items>
        </ext:FormPanel>  
        <%--<ext:Panel runat="server" ID="pnlMainInput" Height="600">
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button runat="server" ID="btnSave" Text="SAVE" Icon="Disk">
                            <Listeners>
                                <Click Handler="#{DirectMethods}.SaveData();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnCancel" Text="CANCEL" Icon="Cancel">
                            <Listeners>
                                <Click Handler="parentAutoLoadControl.close();" Delay="1" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Items>
                <ext:TextField ID="txtMasukId" runat="server" FieldLabel="ID Surat" AnchorHorizontal="-20" ReadOnly="true" Enabled="false" />
                <ext:TextField ID="txtNomorSurat" runat="server" FieldLabel="ID Surat" AnchorHorizontal="-20" />
                <ext:TextField ID="txtNomorSuratKencana" runat="server" FieldLabel="Nomor Surat Internal" AnchorHorizontal="-20" />
                <ext:TextField ID="txtNomorSuratAsli" runat="server" FieldLabel="Nomor Surat Asal" AnchorHorizontal="-20" />
                <ext:TextField ID="txtJudul" runat="server" FieldLabel="Tittle Surat" AnchorHorizontal="-20" />
                <ext:DateField ID="dfTanggal" runat="server" FieldLabel="Tanggal" AnchorHorizontal="-20" />
                <ext:TextField ID="txtDari" runat="server" FieldLabel="Dari" AnchorHorizontal="-20" />
                <ext:TextField ID="txtKeterangan" runat="server" FieldLabel="Keterangan" AnchorHorizontal="-20" />
            </Items>
        </ext:Panel>--%>
    </div>
    </form>
</body>
</html>

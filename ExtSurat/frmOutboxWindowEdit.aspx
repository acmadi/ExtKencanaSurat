﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOutboxWindowEdit.aspx.cs" Inherits="ExtSurat.frmOutboxWindowEdit" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var EnableEdit = function () {            
            if (isEditable.Checked) {
                txtIdSuratMasuk.SetDisabled(false);
                txtIdSuratMasukExtended.SetDisabled(false);
            }
        };
        </script>
        <link rel="stylesheet" type="text/css" href="Scripts/extjs/resources/css/xtheme-Kencana.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" /> 
        <ext:Store
        ID="storeFormatSurat"
        runat="server"
        OnReadData="storeFormatSurat_RefreshData" >        
        <Reader>
            <ext:JsonReader runat="server">                
                <Fields>
                    <ext:RecordField Name="format" />
                    <ext:RecordField Name="Keterangan" />                    
                </Fields>
            </ext:JsonReader>
        </Reader>
        </ext:Store>               
        <ext:FormPanel runat="server" ID="frmPanelMain" AutoHeight="true" Padding="2" DefaultAnchor="0" MonitorValid="true">
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button runat="server" ID="btnSave" Text="SAVE" Icon="Disk" FormBind="true" ClientIDMode="Inherit">
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
                <ext:TextField ID="txtKeluarId" runat="server" FieldLabel="ID Surat" AnchorHorizontal="-20" ReadOnly="true" Enabled="false" AllowBlank="false" />                
                <%--<ext:TextField ID="txtPenomoranSurat" runat="server" FieldLabel="ID Penomoran" AnchorHorizontal="-20" AllowBlank="false" />--%>
                <%--<ext:ComboBox ID="cmbFormatPenomoran" runat="server" FieldLabel="Format Penomoran" AnchorHorizontal="-20" AllowBlank="false" StoreID="storeFormatSurat" DisplayField="Keterangan" ValueField="format" />--%>
                <%--<ext:TextField ID="txtNomorSuratKencana" runat="server" FieldLabel="Nomor Surat" AnchorHorizontal="-20" AllowBlank="false" ReadOnly="true" />--%>
                <ext:CompositeField ID="CompositeField1" runat="server" FieldLabel="Nomor Surat" AnchorHorizontal="-20">
                    <Items>
                        <ext:TextField ID="txtNomorSuratKencana" runat="server" Width="200" Disabled = "true" AllowBlank="false" />
                        <ext:DisplayField ID="DisplayField1" runat="server" Text="Extended Number" />
                        <ext:TextField ID="txtIdSuratMasukExtended" runat="server" Width="20" MaxLength="1" Disabled="true" AllowBlank="true">
                            <CustomConfig>
                                <ext:ConfigItem Name="autoCreate" Value="{tag : 'input', type : 'text', maxlength : 1, autocomplete : 'off' }" />
                            </CustomConfig>
                        </ext:TextField>
                        <ext:DisplayField ID="DisplayField2" runat="server" Text="Enable nomor surat" />
                        <ext:Checkbox ID="isEditable" runat="server">
                            <Listeners>
                                <Check Handler="#{txtIdSuratMasukExtended}.setDisabled(!checked);" />
                            </Listeners>
                        </ext:Checkbox>
                    </Items>
                </ext:CompositeField>
                <ext:TextField ID="txtKepada" runat="server" FieldLabel="Penerima" AnchorHorizontal="-20" AllowBlank="false" />
                <ext:TextField ID="txtJudul" runat="server" FieldLabel="Tittle Surat" AnchorHorizontal="-20" AllowBlank="false" />                                
                <ext:TextField ID="txtKeterangan" runat="server" FieldLabel="Keterangan" AnchorHorizontal="-20" AllowBlank="false" />
                <ext:DateField ID="dfTanggal" runat="server" FieldLabel="Tanggal" AnchorHorizontal="-20" AllowBlank="false" />
            </Items>
            <Listeners>
                <ClientValidation Handler="#{btnSave}.setDisabled(!valid);" />
            </Listeners>
        </ext:FormPanel>
    </div>
    </form>
</body>
</html>

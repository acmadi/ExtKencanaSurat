<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUserWindowEdit.aspx.cs" Inherits="ExtSurat.frmUserWindowEdit" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>      
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Store runat="server" ID="Store1">          
            <Reader>
                <ext:JsonReader IDProperty="Value">
                    <Fields>
                        <ext:RecordField Name="Text" />
                        <ext:RecordField Name="Value" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>

        <ext:FormPanel runat="server" ID="frmPanelMain" AutoHeight="true" Padding="2" DefaultAnchor="0" MonitorValid="true">
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:Button runat="server" ID="btnSave" ClientIDMode="Inherit" Text="SAVE" Icon="Disk" FormBind="true">
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
                <ext:TextField ID="txtUserId" runat="server" FieldLabel="ID User" AnchorHorizontal="-20" AllowBlank="true" ReadOnly="true" Enabled="false" />
                <ext:TextField ID="txtPassword" runat="server" FieldLabel="Password" AnchorHorizontal="-20" AllowBlank="false" InputType="Password" />
                <ext:TextField ID="txtPasswordConfirm" runat="server" FieldLabel="Confirm Password" AnchorHorizontal="-20" AllowBlank="false" InputType="Password" />
                <ext:ComboBox ID="cmbLevel" runat="server" FieldLabel="Level User" AnchorHorizontal="-20" AllowBlank="false" StoreID="Store1" DisplayField="Text" ValueField="Value" />
                <ext:TextField ID="txtNama" runat="server" FieldLabel="Nama" AnchorHorizontal="-20" AllowBlank="false" />
                <ext:TextField ID="txtJabatan" runat="server" FieldLabel="Jabatan" AnchorHorizontal="-20" AllowBlank="false" />
                <ext:TextField ID="txtBagian" runat="server" FieldLabel="Divisi/Bagian" AnchorHorizontal="-20" AllowBlank="false" />                                
                <ext:TextField ID="txtLokasi" runat="server" FieldLabel="Lokasi" AnchorHorizontal="-20" AllowBlank="false" />
                <ext:Checkbox ID="chkAktif" runat="server" FieldLabel="Aktif" AnchorHorizontal="-20" />
                <%--<ext:DateField ID="dfTanggal" runat="server" FieldLabel="Tanggal" AnchorHorizontal="-20" AllowBlank="false" >
                    <Listeners>
                        <Select Handler="#{DirectMethods}.dfTanggal_Select();" />
                    </Listeners>
                </ext:DateField>--%>
            </Items>
            <Listeners>
                <ClientValidation Handler="#{btnSave}.setDisabled(!valid);" />
            </Listeners>
        </ext:FormPanel>
    </div>
    </form>
</body>
</html>

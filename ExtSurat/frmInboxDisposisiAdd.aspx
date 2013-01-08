<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInboxDisposisiAdd.aspx.cs" Inherits="ExtSurat.frmInboxDisposisiAdd" %>
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
    </div>    
        <ext:FormPanel runat="server" Title="Add new Disposition" ID="pnlMain" Padding="5" MonitorValid="true">
            <Items>
                <ext:Label ID="Label1" runat="server" Text="SEKRETARIAT RSCM KENCANA" Width="600"/>
                <ext:TextField runat="server" FieldLabel="No Surat" ID="txtSuratNo" Enabled="false" ReadOnly="true" Width="400"/>                
                <ext:TextField runat="server" FieldLabel="Agenda No." Width="400" ID="txtAgendaNo" AllowBlank="false" />
                <ext:DateField runat="server" FieldLabel="Tanggal" Width="300" ID="dfTanggal" AllowBlank="false" />  
                            <ext:RadioGroup ID="radiogroup" runat="server" FieldLabel="Sifat Surat" AnchorHorizontal="50">
                                <Items>
                                    <ext:Radio ID="rdoBiasa" runat="server" BoxLabel="Biasa" Checked="true" />
                                    <ext:Radio ID="rdoSegera" runat="server" BoxLabel="Segera" />
                                    <ext:Radio ID="rdoPenting" runat="server" BoxLabel="Penting" />
                                    <ext:Radio ID="rdoRahasia" runat="server" BoxLabel="Rahasia" />  
                                </Items>
                            </ext:RadioGroup>                        
                <ext:TextArea runat="server" FieldLabel="Perihal" ID="txtPerihal" AnchorHorizontal="50" Width="600" Height="51" AllowBlank="false"  />
                <ext:TextArea runat="server" FieldLabel="Asal Surat" ID="txtAsalSurat" AnchorHorizontal="50" Width="600" Height="51" AllowBlank="false" />
                <ext:TextArea runat="server" FieldLabel="Diteruskan Ke" ID="txtDiteruskanKe" AnchorHorizontal="50" Width="600" Height="51" AllowBlank="false" />
                <ext:TextArea runat="server" FieldLabel="Tanggapan/Catatan" ID="txtCatatan" AnchorHorizontal="50" Width="600" Height="136" AllowBlank="false" />
            </Items>
            <Listeners>
                <ClientValidation Handler="#{btnSave}.setDisabled(!valid);" />
            </Listeners>
        </ext:FormPanel>
        <ext:Panel runat="server" ID="pnlButton" Padding="8">
            <Items>
                <ext:Button runat="server" ID="btnSave" Text="SAVE" >
                    <Listeners>
                        <Render Handler="this.el.center(pnlButton.body);" />
                        <Click Handler="#{DirectMethods}.btnSave_Click();" />
                    </Listeners>
                </ext:Button>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>

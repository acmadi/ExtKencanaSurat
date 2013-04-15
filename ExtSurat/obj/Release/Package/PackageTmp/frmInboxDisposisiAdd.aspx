<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInboxDisposisiAdd.aspx.cs" Inherits="ExtSurat.frmInboxDisposisiAdd" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Scripts/extjs/resources/css/xtheme-Kencana.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ext:ResourceManager ID="ResourceManager1" runat="server" /> 
    </div>    
        <ext:FormPanel runat="server" Title="Add new Disposition" ID="pnlMain" Padding="5" MonitorValid="true" MonitorResize="true">
            <Items>
                <ext:Label ID="Label1" runat="server" Text="SEKRETARIAT RSCM KENCANA" AnchorHorizontal="100%" Flex="1"/>
                <ext:TextField runat="server" FieldLabel="No Surat" ID="txtSuratNo" Enabled="false" ReadOnly="true" AnchorHorizontal="100%" Flex="1" />                
                <ext:TextField runat="server" FieldLabel="Agenda No." AnchorHorizontal="100%" Flex="1" ID="txtAgendaNo" AllowBlank="false" />
                <ext:DateField runat="server" FieldLabel="Tanggal" Width="300" ID="dfTanggal" AllowBlank="false" />  
                            <ext:RadioGroup ID="radiogroup" runat="server" FieldLabel="Sifat Surat" AnchorHorizontal="100%" Flex="1">
                                <Items>
                                    <ext:Radio ID="rdoBiasa" runat="server" BoxLabel="Biasa" Checked="true" Flex="1" />
                                    <ext:Radio ID="rdoSegera" runat="server" BoxLabel="Segera" Flex="1" />
                                    <ext:Radio ID="rdoPenting" runat="server" BoxLabel="Penting" Flex="1" />
                                    <ext:Radio ID="rdoRahasia" runat="server" BoxLabel="Rahasia" Flex="1" />  
                                </Items>
                            </ext:RadioGroup>                        
                <ext:HtmlEditor runat="server" FieldLabel="Perihal" ID="txtPerihal" AnchorHorizontal="100%" Flex="1" Height="80" AllowBlank="true"  
                    EnableAlignments="false" EnableColors="false" EnableLinks="false" EnableLists="false" EnableSourceEdit="false" EnableTheming="false"
                    EnableFontSize="false" EnableFont="false" EnableFormat="false" >
                        <Listeners>
                            <Initialize Handler="Ext.DomHelper.applyStyles(this.getEditorBody(), {'background-position' : 'top right', 'margin':'0px', padding:'0px'});" />                            
                        </Listeners>
                    </ext:HtmlEditor>
                <ext:HtmlEditor runat="server" FieldLabel="Asal Surat" ID="txtAsalSurat" AnchorHorizontal="100%" Flex="1" Height="80" AllowBlank="false" 
                    EnableAlignments="false" EnableColors="false" EnableLinks="false" EnableLists="false" EnableSourceEdit="false" EnableTheming="false"
                    EnableFontSize="false" EnableFont="false" EnableFormat="false">
                        <Listeners>
                            <Initialize Handler="Ext.DomHelper.applyStyles(this.getEditorBody(), {'background-position' : 'top right', 'margin':'0px', padding:'0px'});" />
                        </Listeners>
                    </ext:HtmlEditor>
                <ext:HtmlEditor runat="server" FieldLabel="Diteruskan Ke" ID="txtDiteruskanKe" AnchorHorizontal="100%" Flex="1" Height="80" AllowBlank="false" 
                    EnableAlignments="false" EnableColors="false" EnableLinks="false" EnableLists="false" EnableSourceEdit="false" EnableTheming="false"
                    EnableFontSize="false" EnableFont="false" EnableFormat="false">
                        <Listeners>
                            <Initialize Handler="Ext.DomHelper.applyStyles(this.getEditorBody(), {'background-position' : 'top right', 'margin':'0px', padding:'0px'});" />
                        </Listeners>
                    </ext:HtmlEditor>          
                <ext:HtmlEditor runat="server" FieldLabel="Catatan" ID="txtHtmlCatatan" AnchorHorizontal="100%" Flex="1" Height="100" AllowBlank="false"
                    EnableAlignments="false" EnableColors="false" EnableLinks="false" EnableLists="false" EnableSourceEdit="false" EnableTheming="false"
                    EnableFontSize="false" EnableFont="false" EnableFormat="false">
                        <Listeners>
                            <Initialize Handler="Ext.DomHelper.applyStyles(this.getEditorBody(), {'background-position' : 'top right', 'margin':'0px', padding:'0px'});" />
                        </Listeners>
                    </ext:HtmlEditor>
            </Items>
            <Listeners>
                <ClientValidation Handler="#{btnSave}.setDisabled(!valid);" />
            </Listeners>
        </ext:FormPanel>
        <ext:Panel runat="server" ID="pnlButton" Padding="8">
            <Items>                
                <ext:Button runat="server" ID="btnSave" Text="SAVE" Icon="Disk" >
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

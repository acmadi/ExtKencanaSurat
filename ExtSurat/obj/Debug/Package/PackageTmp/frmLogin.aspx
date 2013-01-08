<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="ExtSurat.frmLogin" %>
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
        <ext:Viewport runat="server" Layout="HBoxLayout"> 
            <LayoutConfig>
                <ext:HBoxLayoutConfig Pack="Center" Align="Stretch" />
            </LayoutConfig>
            <Items>
                <ext:Container runat="server" Layout="VBoxLayout">
                    <LayoutConfig>
                        <ext:VBoxLayoutConfig Pack="Center" />
                    </LayoutConfig>
                    <Items>
                        <ext:Panel runat="server" ID="pnlLogin" Title="RSCM KENCANA'S LETTER APLICATION LOGIN PAGE" Height =" 120" Width="320">                
                            <Items>
                                <ext:TextField runat="server" ID="txtUser" FieldLabel="Username" AnchorHorizontal="20" Width="270"/>
                                <ext:TextField runat="server" ID="txtPassword" FieldLabel="Password" AnchorHorizontal="20" Width="270" InputType="Password"/>
                                <ext:Button runat="server" ID="btnLogin" Text="LOGIN" X="25" >
                                    <Listeners>
                                        <Click Handler="#{DirectMethods}.btnLogin_Click();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Panel>  
                    </Items>
                </ext:Container>            
            </Items>       
        </ext:Viewport>
    </div>
    </form>
</body>
</html>

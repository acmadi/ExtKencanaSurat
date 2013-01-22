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
        <ext:ResourceManager ID="ResourceManager1" runat="server">
            <Listeners>
                <WindowResize Handler="btnLogin.el.center(pnlButton.body);" Buffer="20" /> 
            </Listeners>
        </ext:ResourceManager>
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
                        <ext:Panel runat="server" ID="pnlLogin" Title="RSCM KENCANA'S LETTER APLICATION LOGIN PAGE" Height =" 90" Width="320" Padding="5">                
                            <Items>
                                <ext:TextField runat="server" ID="txtUser" FieldLabel="Username" AnchorHorizontal="20" Width="270"/>
                                <ext:TextField runat="server" ID="txtPassword" FieldLabel="Password" AnchorHorizontal="20" Width="270" InputType="Password"/>                                
                            </Items>
                        </ext:Panel>  
                        <ext:Panel runat="server" ID="pnlButton" Height="35" Width="320">                                                        
                            <Items>   
                                <ext:Button runat="server" ID="btnLogin" Text="LOGIN" >
                                    <Listeners>
                                        <Click Handler="#{DirectMethods}.btnLogin_Click();" />
                                        <Render Handler="this.el.center(pnlButton.body);" />
                                    </Listeners>
                                </ext:Button>                                                          
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Container>            
            </Items>       
        </ext:Viewport>
        <ext:KeyMap runat="server" Target="={Ext.isGecko ? Ext.getDoc() : Ext.getBody()}">
            <ext:KeyBinding StopEvent="false">
                <Keys>
                    <ext:Key Code="ENTER" />                    
                </Keys>
                <Listeners>
                    <Event Handler="#{btnLogin}.fireEvent('click')" />
                </Listeners>
            </ext:KeyBinding>
        </ext:KeyMap>
    </div>
    </form>
</body>
</html>

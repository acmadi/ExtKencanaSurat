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
        <ext:Panel runat="server" Title="SEKRETARIAT RSCM KENCANA">
            <Items>
                <ext:TextField runat="server" FieldLabel="Agenda No." AnchorHorizontal="30" Width="300" />
                <ext:DateField runat="server" FieldLabel="Tanggal" AnchorHorizontal="30" Width="300" />
                
            </Items>
        </ext:Panel>
    </form>
</body>
</html>

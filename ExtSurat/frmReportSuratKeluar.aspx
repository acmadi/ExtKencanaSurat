<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmReportSuratKeluar.aspx.cs" Inherits="ExtSurat.frmReportSuratKeluar" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register assembly="Telerik.ReportViewer.WebForms, Version=6.2.13.109, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" namespace="Telerik.ReportViewer.WebForms" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <div>
        <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="580px" 
            ParametersAreaVisible="False" ShowParametersButton="False" 
            ShowZoomSelect="True" Width="100%">
        </telerik:ReportViewer>
    </div>
    </form>
</body>
</html>

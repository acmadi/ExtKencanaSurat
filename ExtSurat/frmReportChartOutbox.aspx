<%@ Page Title="" Language="C#" MasterPageFile="~/ExtSurat.Master" AutoEventWireup="true" CodeBehind="frmReportChartOutbox.aspx.cs" Inherits="ExtSurat.frmReportChartOutbox" %>
<%@ Register assembly="Telerik.ReportViewer.WebForms, Version=6.2.13.109, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" namespace="Telerik.ReportViewer.WebForms" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="700px" 
        Width="100%"></telerik:ReportViewer>
</asp:Content>

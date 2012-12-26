<%@ Page Title="" Language="C#" MasterPageFile="~/ExtSurat.Master" AutoEventWireup="true" CodeBehind="frmOutbox.aspx.cs" Inherits="ExtSurat.frmOutbox" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .add32 
        {
            background-image : url(Images/add_user-32.png) !important;
        }
        .group32 
        {
            background-image : url(Images/group_access-32.jpg) !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ext:Store 
        ID="storeOutbox"
        runat="server"
        OnReadData="storeOutbox_RefreshData" 
        Buffered="true">
        <Reader>
            <ext:JsonReader>
                <Fields>
                    <ext:RecordField Name="keluarid" />
                    <ext:RecordField Name="userid" />
                    <ext:RecordField Name="nomor" />
                    <ext:RecordField Name="noasal" />
                    <ext:RecordField Name="kepada" />
                    <ext:RecordField Name="judul" />
                    <ext:RecordField Name="keterangan" />
                    <ext:RecordField Name="tanggal" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>

    <ext:GridPanel runat="server" ID="gpInbox" ClientIDMode="Inherit" Height="600" StoreID="storeOutbox" AutoExpandColumn="judul" >
        <TopBar>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button runat="server" ID="btnAddSuratKeluar" Icon="EmailAdd">
                        <Listeners>
                            
                        </Listeners>
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </TopBar>
        <ColumnModel ID="ColumnModel1" runat="server">
            <Columns>
                <ext:Column ColumnID="IdSuratMasuk" Header="ID" DataIndex="masukid" Width="40" />
                <ext:Column ColumnID="IdUser" Header="ID User" DataIndex="userid" Width="80" />
                <ext:Column ColumnID="Nomor" Header="Nomor Surat" DataIndex="nomor" Width="100" />
                <ext:Column ColumnID="NomorAsli" Header="Nomor Asli Surat" DataIndex="noasal" Width="100" />
                <ext:Column ColumnID="Penerima" Header="Penerima" DataIndex="kepada" Width="200" />
                <ext:Column ColumnID="Judul" Header="Judul" DataIndex="judul" />
                <ext:Column ColumnID="Keterangan" Header="Keterangan" DataIndex="keterangan" Width="250" />
                <ext:DateColumn ColumnID="Tanggal" Header="Tanggal" DataIndex="tanggal" Width="90" />
            </Columns>
        </ColumnModel>
        <SelectionModel>
            <ext:RowSelectionModel ID="RowSelectionModel1" SingleSelect="true" runat="server" />
        </SelectionModel>
        <LoadMask ShowMask="true" />
    </ext:GridPanel>
</asp:Content>
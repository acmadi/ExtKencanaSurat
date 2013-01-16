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
                    <ext:RecordField Name="nomorid" />
                    <ext:RecordField Name="nomor" />
                    <ext:RecordField Name="kepada" />
                    <ext:RecordField Name="judul" />
                    <ext:RecordField Name="keterangan" />
                    <ext:RecordField Name="tanggal" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>

    <ext:GridPanel runat="server" ID="gpOutbox" ClientIDMode="Inherit" Height="600" StoreID="storeOutbox" AutoExpandColumn="judul" Title="Surat Keluar">
        <TopBar>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button runat="server" ID="btnAddSuratKeluar" Icon="EmailAdd">
                        <Listeners>
                            <Click Handler="Ext.net.DirectMethods.EditSurat('new');" />   
                        </Listeners>
                    </ext:Button>
                    <ext:ToolbarSpacer />
                    <ext:ToolbarSpacer />
                    <ext:ToolbarSpacer />
                    <ext:ToolbarSpacer />
                    <ext:ToolbarSeparator />
                    <ext:ToolbarSeparator />
                    <ext:Label ID="Label1" runat="server" Text="From" />
                    <ext:ToolbarSeparator />
                    <ext:DateField runat="server" ID="dfFrom" Width="90" />
                    <ext:ToolbarSeparator />
                    <ext:Label runat="server" Text="To" />
                    <ext:ToolbarSeparator />
                    <ext:DateField runat="server" ID="dfTo" Width="90" />
                    <ext:ToolbarSeparator />
                    <ext:ToolbarSeparator />
                    <ext:Label Text="Nomor Surat" runat="server" ID="lblNomorSurat" />
                    <ext:ToolbarSeparator />
                    <ext:TextField runat="server" ID="txtNomorSurat" EmptyText="Nomor Surat" Width="150" />
                    <ext:ToolbarSeparator />
                    <ext:ToolbarSeparator />
                    <ext:Label Text="Penerima" runat="server" />
                    <ext:ToolbarSeparator />
                    <ext:TextField runat="server" ID="txtPenerima" EmptyText="Penerima Surat" Width="150" />
                    <ext:ToolbarSeparator />
                    <ext:ToolbarSeparator />
                    <ext:Label Text="Judul" runat="server" />
                    <ext:ToolbarSeparator />
                    <ext:TextField runat="server" ID="txtJudul" EmptyText="Judul Surat" Width="150" />
                    <ext:ToolbarSeparator />
                    <ext:ToolbarSeparator />
                     <ext:Label ID="Label2" Text="Keterangan" runat="server" />
                    <ext:ToolbarSeparator />
                    <ext:TextField runat="server" ID="txtKeterangan" EmptyText="Ket. Surat" Width="150" />
                    <ext:ToolbarSeparator />
                    <ext:ToolbarSeparator />
                    <ext:Button runat="server" ID="btnSearch" Icon="Zoom" ToolTip="Search">
                        <Listeners>
                            <Click Handler="Ext.net.DirectMethods.btnSearch_Click();" />
                        </Listeners>
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </TopBar>
        <ColumnModel runat="server">
            <Columns>
                <ext:CommandColumn runat="server" Width="25" Header="Edit">
                    <Commands>
                        <ext:GridCommand Icon="EmailEdit" CommandName="Edit">   
                            <ToolTip Text="Edit Surat" />
                        </ext:GridCommand>
                    </Commands>
                </ext:CommandColumn>
                <ext:Column ColumnID="IdSuratKeluar" Header="ID" DataIndex="keluarid" Width="40" />
                <ext:Column ColumnID="IdUser" Header="ID User" DataIndex="userid" Width="80" />                
                <ext:Column ColumnID="NomorAsli" Header="Nomor Surat" DataIndex="nomor" Width="200" />
                <ext:Column ColumnID="Penerima" Header="Penerima" DataIndex="kepada" Width="200" />
                <ext:Column ColumnID="Judul" Header="Judul" DataIndex="judul" Width="300" />
                <ext:Column ColumnID="Keterangan" Header="Keterangan" DataIndex="keterangan" Width="300" />
                <ext:DateColumn ColumnID="Tanggal" Header="Tanggal" DataIndex="tanggal" Width="100" />
            </Columns>
        </ColumnModel>
        <SelectionModel>
            <ext:RowSelectionModel ID="RowSelectionModel1" SingleSelect="true" runat="server" />
        </SelectionModel>
        <LoadMask ShowMask="true" />
        <Listeners>
            <Command Handler="Ext.net.DirectMethods.EditSurat(record.data.keluarid);" />
        </Listeners>
    </ext:GridPanel>

    <ext:TaskManager runat="server" ID="taskManager1" Enabled="true">
        <Tasks>
            <ext:Task TaskID="taskEdit" Interval="2000">
                <Listeners>
                    <Update Handler="Ext.net.DirectMethods.Refresh_Grid();" />
                </Listeners>
            </ext:Task>
        </Tasks>
    </ext:TaskManager>
</asp:Content>
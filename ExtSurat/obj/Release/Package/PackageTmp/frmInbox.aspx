<%@ Page Title="" Language="C#" MasterPageFile="~/ExtSurat.Master" AutoEventWireup="true" CodeBehind="frmInbox.aspx.cs" Inherits="ExtSurat.frmInbox" %>
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
    <script type="text/javascript">
        var RowCommand = function (cmd, record) {
            switch (cmd) {
                case "Edit":
                    //            The real application calls a directmethod here
                    Ext.net.DirectMethods.EditSurat("Edit", record.data.masukid);
                    break;
                case "Disposition":
                    Ext.net.DirectMethods.EditSurat("Disposition", record.data.masukid);
                    break;
            }
        };
    </script>

    <ext:Store 
        ID="storeInbox"
        runat="server"
        OnReadData="storeInbox_RefreshData" 
        Buffered="true">
        <Reader>
            <ext:JsonReader>
                <Fields>
                    <ext:RecordField Name="masukid" />
                    <ext:RecordField Name="userid" />
                    <ext:RecordField Name="nomor" />
                    <ext:RecordField Name="noasal" />
                    <ext:RecordField Name="dari" />
                    <ext:RecordField Name="judul" />
                    <ext:RecordField Name="keterangan" />
                    <ext:RecordField Name="tanggal" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:GridPanel runat="server" ID="gpInbox" ClientIDMode="Inherit" Height="600" StoreID="storeInbox" AutoExpandColumn="judul" >
        <TopBar>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Button runat="server" ID="btnAddSuratMasuk" Icon="EmailAdd">
                        <Listeners>
                            <Click Handler="Ext.net.DirectMethods.EditSurat('New', 'new');" />
                        </Listeners>
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </TopBar>        
        <ColumnModel runat="server">
            <Columns>
                <ext:CommandColumn runat="server" Width="70" Header="Edit">
                    <Commands>
                        <ext:GridCommand Icon="EmailEdit" CommandName="Edit">   
                            <ToolTip Text="Edit Surat" />
                        </ext:GridCommand>
                        <ext:CommandSeparator />
                        <ext:GridCommand Icon="EmailAttach" CommandName="Disposition">
                            <ToolTip Text="Add Disposition" />
                        </ext:GridCommand>
                    </Commands>
                </ext:CommandColumn>
                <ext:Column ColumnID="IdSuratMasuk" Header="ID" DataIndex="masukid" Width="40" Hidden="true" />
                <ext:Column ColumnID="IdUser" Header="ID User" DataIndex="userid" Width="80" />
                <ext:Column ColumnID="Nomor" Header="Nomor Surat" DataIndex="nomor" Width="200" />
                <ext:Column ColumnID="NomorAsli" Header="Nomor Asli Surat" DataIndex="noasal" Width="200" />
                <ext:Column ColumnID="Dari" Header="Pengirim" DataIndex="dari" Width="200" />
                <ext:Column ColumnID="Judul" Header="Judul" DataIndex="judul" Width="300" />
                <ext:Column ColumnID="Keterangan" Header="Keterangan" DataIndex="keterangan" Width="300" />
                <ext:DateColumn ColumnID="Tanggal" Header="Tanggal" DataIndex="tanggal" Width="100" />
            </Columns>
        </ColumnModel>
        <SelectionModel>
            <ext:RowSelectionModel SingleSelect="true" runat="server" />
        </SelectionModel>
        <LoadMask ShowMask="true" />
        <Listeners>
            <%--<Command Handler="Ext.net.DirectMethods.EditSurat(command, record.data.masukid);" />--%>
            <Command Fn="RowCommand" />
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
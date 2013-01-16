<%@ Page Title="" Language="C#" MasterPageFile="~/ExtSurat.Master" AutoEventWireup="true" CodeBehind="frmMasterUser.aspx.cs" Inherits="ExtSurat.frmMasterUser" %>
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
        ID="storeUser"
        runat="server"
        OnReadData="storeUser_RefreshData" 
        Buffered="true">
        <Reader>
            <ext:JsonReader>
                <Fields>
                    <ext:RecordField Name="userid" />
                    <ext:RecordField Name="nama" />
                    <ext:RecordField Name="jabatan" />
                    <ext:RecordField Name="divisi" />
                    <ext:RecordField Name="level" />
                    <ext:RecordField Name="aktif" />
                    <ext:RecordField Name="keterangan" />
                    <ext:RecordField Name="tanggal" Type="Date" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:GridPanel runat="server" ID="gpUser" ClientIDMode="Inherit" Height="600" StoreID="storeUser" AutoExpandColumn="nama" >
        <TopBar>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button runat="server" ID="btnAddUser" Icon="UserAdd">
                        <Listeners>
                            <Click Handler="Ext.net.DirectMethods.EditUser('New', 'new');" />
                        </Listeners>
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </TopBar>        
        <ColumnModel ID="ColumnModel1" runat="server">
            <Columns>
                <ext:CommandColumn runat="server" Width="70" Header="Edit">
                    <Commands>
                        <ext:GridCommand Icon="UserEdit" CommandName="Edit">   
                            <ToolTip Text="Edit User" />
                        </ext:GridCommand>
                        <ext:CommandSeparator />
                        <ext:GridCommand Icon="UserDelete" CommandName="Delete">
                            <ToolTip Text="Add User" />
                        </ext:GridCommand>
                    </Commands>
                </ext:CommandColumn>
                <ext:Column ColumnID="IdUser" Header="Login User" DataIndex="userid" Width="40" />                
                <ext:Column ColumnID="Nama" Header="Nama User" DataIndex="nama" Width="200" />
                <ext:Column ColumnID="Jabatan" Header="Jabatan" DataIndex="jabatan" Width="200" />
                <ext:Column ColumnID="Dari" Header="Pengirim" DataIndex="dari" Width="200" />
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

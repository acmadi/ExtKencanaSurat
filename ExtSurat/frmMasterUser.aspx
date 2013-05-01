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
<ext:ResourceManager ID="ResourceManager1" runat="server" />   
    <script type="text/javascript">
        var RowCommand = function (cmd, record) {
            switch (cmd) {
                case "Edit":
                    //The real application calls a directmethod here
                    Ext.net.DirectMethods.EditUser("Edit", record.data.userid);
                    break;
                case "Delete":
                    Ext.net.DirectMethods.EditUser("Delete", record.data.userid);
                    break;
                default:
                    Ext.net.DirectMethods.EditUser("New", "new");
                    break;
            }
        };
    </script>

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
                    <ext:Button runat="server" ID="btnAddUser" Icon="UserAdd" ToolTip="Add User">                        
                        <Listeners>
                            <Click Fn="RowCommand" />
                        </Listeners>
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </TopBar>        
        <ColumnModel ID="ColumnModel1" runat="server">
            <Columns>
                <ext:CommandColumn runat="server" Width="80" Header="Add/Edit">
                    <Commands>
                        <ext:GridCommand Icon="UserEdit" CommandName="Edit">   
                            <ToolTip Text="Edit User" />
                        </ext:GridCommand>
                        <ext:CommandSeparator />
                        <ext:GridCommand Icon="UserDelete" CommandName="Delete">
                            <ToolTip Text="Delete User" />
                        </ext:GridCommand>
                    </Commands>
                </ext:CommandColumn>
                <ext:Column ColumnID="IdUser" Header="Login User" DataIndex="userid" Width="100" />                
                <ext:Column ColumnID="Nama" Header="Nama User" DataIndex="nama" Width="200" />
                <ext:Column ColumnID="Jabatan" Header="Jabatan" DataIndex="jabatan" Width="200" />
                <ext:Column ColumnID="Divisi" Header="Divisi" DataIndex="divisi" Width="200" />
                <ext:Column ColumnID="Level" Header="Level" DataIndex="level" Width="60" />
                <ext:Column ColumnID="Aktif" Header="Aktif" DataIndex="aktif" Width="60" />                
            </Columns>
        </ColumnModel>
        <SelectionModel>
            <ext:RowSelectionModel ID="RowSelectionModel1" SingleSelect="true" runat="server" />
        </SelectionModel>
        <LoadMask ShowMask="true" />
        <Listeners>            
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

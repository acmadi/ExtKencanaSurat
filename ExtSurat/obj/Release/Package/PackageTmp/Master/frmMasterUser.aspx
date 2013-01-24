<%@ Page Title="" Language="C#" MasterPageFile="~/ExtSurat.Master" AutoEventWireup="true" CodeBehind="frmMasterUser.aspx.cs" Inherits="ExtSurat.Master.frmMasterUser" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
    <style>
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
        ID="storeMasterUser"
        runat="server"
        OnReadData="storeMasterUser_RefreshData" 
        Buffered="true">      
        <Model>        
            <ext:Model ID="Model1" runat="server">
                <Fields>
                    <ext:ModelField Name="userid" />
                    <ext:ModelField Name="nama" />
                    <ext:ModelField Name="jabatan" />
                    <ext:ModelField Name="divisi" />
                    <ext:ModelField Name="lokasi" />
                    <ext:ModelField Name="level" />                    
                </Fields>
            </ext:Model>
        </Model>
</ext:Store>

    <ext:GridPanel
        ID="gpUser"
        runat="server"
        StoreID="storeMasterUser"
        Title="List of Users" 
        Height="500">
        <%--<View>
            <ext:GridView ID="gdvUser" runat="server" ForceFit="true" LoadMask="true" LoadingText="Please wait loading students data....." />            
        </View>--%>
        <ColumnModel ID="ColumnModel1" runat="server">
            <Columns>   
                <ext:CommandColumn ID="CommandColumn1" runat="server" Width="80" Header="Edit" >
                    <Commands>
                        <ext:GridCommand Icon="NoteEdit" CommandName="EditUser">                            
                            <ToolTip Text="Edit Data User" />
                        </ext:GridCommand>
                    </Commands>   
                    <Listeners>
                        <Command Handler="#{DirectMethods}.EditDataUser(record.data.userid);" />
                    </Listeners>                 
                </ext:CommandColumn>     
                <ext:Column ID="Column1" runat="server" Header="User ID" DataIndex="userid" Width="80" />
                <ext:Column ID="Column2" runat="server" Header="Name" DataIndex="nama" Width="200" />
                <ext:Column ID="Column3" runat="server" Header="Job Role" DataIndex="Jabatan" Width="100" />
                <ext:Column ID="Column4" runat="server" Header="Division" DataIndex="divisi" Width="100" />
                <ext:Column ID="Column5" runat="server" Header="Location" DataIndex="lokasi" Width="100" />
                <ext:Column ID="Column6" runat="server" Header="Level" DataIndex="level" Width="100" />                
            </Columns>
        </ColumnModel>
        <SelectionModel>
            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" Mode="Single">                
            </ext:RowSelectionModel>            
        </SelectionModel>  
        <TopBar>        
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnReload" runat="server" >
                        <Listeners>
                            <Click Handler="#{DirectMethods}.Reload();" />
                        </Listeners>
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </TopBar>
    </ext:GridPanel>   
</asp:Content>

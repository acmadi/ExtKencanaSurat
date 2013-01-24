<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMasterUser.ascx.cs" Inherits="ExtSurat.Master.ucMasterUser" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<%--<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.storeMasterUser.DataSource = GetUserDatatable();
            this.storeMasterUser.DataBind();
        }
    }

    public DataTable GetUserDatatable()
    {
        DataTable dt = new DataTable();
        UserQuery uQ = new UserQuery();
        uQ.Select(uQ.Userid, uQ.Nama, uQ.Jabatan, uQ.Divisi, uQ.Lokasi, uQ.Level);        
        dt = uQ.LoadDataTable(); 
        return dt;
    }

    [DirectMethod]
    public void Reload()
    {
        this.storeMasterUser.DataSource = this.GetUserDatatable();
        this.storeMasterUser.DataBind();
    }
</script>--%>

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
        <ColumnModel runat="server">
            <Columns>   
                <ext:CommandColumn runat="server" Width="80" Header="Edit" >
                    <Commands>
                        <ext:GridCommand Icon="NoteEdit" CommandName="EditUser">                            
                            <ToolTip Text="Edit Data User" />
                        </ext:GridCommand>
                    </Commands>   
                    <Listeners>
                        <Command Handler="#{DirectMethods}.EditDataUser(record.data.userid);" />
                    </Listeners>                 
                </ext:CommandColumn>     
                <ext:Column runat="server" Header="User ID" DataIndex="userid" Width="80" />
                <ext:Column runat="server" Header="Name" DataIndex="nama" Width="200" />
                <ext:Column runat="server" Header="Job Role" DataIndex="Jabatan" Width="100" />
                <ext:Column runat="server" Header="Division" DataIndex="divisi" Width="100" />
                <ext:Column runat="server" Header="Location" DataIndex="lokasi" Width="100" />
                <ext:Column runat="server" Header="Level" DataIndex="level" Width="100" />                
            </Columns>
        </ColumnModel>
        <SelectionModel>
            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" Mode="Single">                
            </ext:RowSelectionModel>            
        </SelectionModel>  
        <TopBar>        
            <ext:Toolbar runat="server">
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

    <%--<ext:TaskManager runat="server" ID="tm1" Enabled="true">
        <Tasks>
            <ext:Task 
                TaskID="servertimer" 
                Interval="2000">                
                <Listeners>                    
                    <Update Handler="Ext.net.DirectMethods.Refresh_Grid();" />                    
                </Listeners>
            </ext:Task>
        </Tasks>
    </ext:TaskManager>--%>
<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false"
    CodeFile="dailyworkload_new.aspx.vb" Inherits="dailyworkload_new" Title ="AccessTek [ Back Office - Admin ]" Theme="BoboLayout" %>

<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="js/dailyworkload_new.js?101"></script>
    <asp:ScriptManager EnablePageMethods="true" runat="server"></asp:ScriptManager>

    <table border="0" cellspacing="0" cellpadding="0" width="100%">

        <tr>
            <td class="searchTools">
                <asp:CheckBox ID="chkBaklog" runat="server" AutoPostBack="True" ForeColor="Black" Text="Backlog" />&nbsp;
                <ew:CalendarPopup ID="CPMain" runat="server" SelectedDate="2006-12-13" VisibleDate="2006-12-13" CalendarLocation="Bottom" Width="103px">
                    <cleardatestyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" forecolor="Black" />
                </ew:CalendarPopup>
                <input type="button" id="btnView" value="View" />

                <%--<input type="button" id="btnDownload" value="download" />--%>
            </td>
        </tr>
        
        <tr>
            <td>
                <div style="float:left;width:65px;"><input type="button" value="Expand" id="btnExpand" /></div>
                <div style="float:left;width:30px;"><input style="width:30px;" type="image" src="../Icon/download2.png" title="Download All" id="btnDownloadWorkloadDics" /></div>
            </td>
        </tr>

        <tr>
            <td>
                <table id="tblDictatorsWorkload" class="tblDictators" style="color:black;font-size:12px;"></table>
            </td>
        </tr>

        <tr>
            <td class="heading" style="height: 25px">
                    
                    <div style="float:left;width:65px;">&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Font-Size="10pt" Text="Backlog" Visible="False"></asp:Label></div>
                    <div style="float:left;width:30px;"><input style="width:30px;" type="image" src="../Icon/download2.png"  title="Download All" id="btnDownloadWorkloadPendingDics" /></div>
            </td>
        </tr>
        <tr>
            <td>
                <table id="tblDictatorsWorkloadPending" class="tblDictators" style="color:black;font-size:12px;"></table>
            </td>
        </tr>
    </table>
    <style type="text/css">
        .tblDictators th{
            font-size:11px;
            background-color:#D7D7D7;
        }

        .tblDictators td{
            font-size:11px;
        }
        #loading {
            left: 50%;
            position: fixed;
            top: 50%;
        }
    </style>
</asp:Content>

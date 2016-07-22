<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="search.aspx.vb" Inherits="fo_search" Title =" AccessTek [ Back Office - Employee ]" Theme="default" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table border="0" cellspacing="0" cellpadding="0" width="980px">
        <tr>
            <td colspan="2" style ="background-image:url(../images/BOadminHeadingBG.jpg); width :980; height :66;"><table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
            <tr><td align="left" class="headingLrg"><br style="line-height:20px;"/><strong>Dictator Workload</strong></td></tr>
         </table></td>
        </tr>
        <tr>
            <td valign="bottom" align="right">&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td class="tdspace" height="2px;">
            </td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="15"></td>
        </tr>
        
        <tr>
            <td align="center">
            <table align="center" width="500" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td style="height: 218px">
	<fieldset>
	<legend><font class="blackSubtext"><strong> Search Criteria&nbsp;</strong></font></legend>
	<table width="450" align="center" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td colspan="3"><img src="../images/spacer.gif" height="6"></td>
	
  </tr>
        <tr>
            <td class="boProfileright">
                            <asp:Label ID="Label4" runat="server" ForeColor="ControlText" Height="10px"
                                Text="Patient Name"></asp:Label></td>
            <td class="divide">
            </td>
            <td class="boProfileleft">
                                    <asp:TextBox ID="txtserPatientName" runat="server" Width="250px" CssClass="fieldbdr"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="boProfileright">
                <asp:Label ID="Label6" runat="server" ForeColor="ControlText" Height="10px" Text="Dictator"></asp:Label></td>
            <td class="divide">
            </td>
            <td class="boProfileleft">
                <asp:DropDownList ID="cmbdictaror" runat="server" Width="250px" Style="position: notset;" Height="18px">
                </asp:DropDownList></td>
        </tr>
  <tr>
                        <td class="boProfileright">
                                <asp:Label ID="Label5" runat="server" Style="position: notset; top: 474px" Text="Location"
                                    ForeColor="ControlText" Height="10px"></asp:Label></td>
                        <td class="divide">
                            <td class="boProfileleft">
                                <asp:DropDownList ID="cmbserLocation" runat="server" Width="250px" Style="position: notset;" Height="18px">
                                </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="boProfileright">
                                <asp:Label ID="Label2" runat="server" Style="position: notset;" Text="From" ForeColor="ControlText" Height="10px"></asp:Label></td>
                        <td >
                        </td>
                        <td class="boProfileleft" >
                            <ew:CalendarPopup ID="CPFrom" runat="server" Width="150px" style="position: notset; top: 0px" Nullable="True">
                              <cleardatestyle backcolor="#ECECEC" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" forecolor="Black" />
                             </ew:CalendarPopup>
                        </td>
                    </tr>
                    <tr>
                        <td class="boProfileright">
                                <asp:Label ID="Label3" runat="server" Style="position: notset;" Text="To Date" ForeColor="ControlText" Height="10px"></asp:Label></td>
                        <td class="divide" style="height: 20px">
                        </td>
                        <td class="boProfileleft">
                            <ew:CalendarPopup ID="CPTo" runat="server" Width="150px" style="position: notset;" Nullable="True">
                            <cleardatestyle backcolor="#ECECEC" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"  forecolor="Black" />
                          </ew:CalendarPopup>
                        </td>
                    </tr>
        <tr>
            <td class="boProfileright">
            </td>
            <td class="divide" style="height: 20px">
            </td>
            <td class="boProfileleft">
                <asp:CheckBox ID="chkTag" runat="server" Text="Tag" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="chkIncomplete" runat="server" Text="Urgent" /></td>
        </tr>
  <tr>
    <td colspan="3"><img src="../images/spacer.gif" height="6"></td>
  </tr>
</table>

	</fieldset>
	</td>
  </tr>
</table>    
            </td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="3"></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnSearch" runat="server" Text="Search" Height="20px" Width="65px" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Reset" Height="20px" Width="65px" /></td>
        </tr>
        <tr>
            
        </tr>
        <tr>
        <td><img src="../images/spacer.gif" height="5" /></td>
        </tr>
    </table>
</asp:Content>

<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="transcriptionconventions.aspx.vb" Inherits="BO_transcriptionconventions" Theme="BOboLayout" Title ="AccessTek [ Back Office - Admin ]" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="980" border="0" cellspacing="0" cellpadding="0">
    <tr>
            <td style ="background-image:url(../images/BOadminHeadingBG.jpg); width :980; height :66;"><table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
            <tr><td align="left" class="headingLrg"><br style="line-height:20px;"/><strong>Transcription Conventions</strong></td></tr>
         </table></td>
        </tr>
       <tr>
            <td class="upload">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Names="Verdana" Font-Size="8pt"></asp:Label>
                <asp:DropDownList ID="ddlFo" runat="server" DataTextField="FullName" DataValueField="foId" Width="200px">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlTrans" runat="server" Width="118px">
                    <asp:ListItem Value="1">Transcription</asp:ListItem>
                    <asp:ListItem Value="0">Dictations</asp:ListItem>
                </asp:DropDownList>&nbsp;<asp:Button ID="btnCheck" runat="server" Text="Check" />&nbsp;
               </td>
        </tr>
        <tr><td class="tdspace" height="2"></td></tr>
        <tr>
        <tr>
	        <td><img src="../images/spacer.gif" height="15"/></td>
         </tr>
            <td>
            <table align="center" width="500" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td>
	<fieldset>
	<legend><font class="blackSubtext"><strong>Sample Transcription Name:-&nbsp;</strong></font></legend>
	<table width="450" align="center" border="0" cellspacing="0" cellpadding="0">
  <tr>
	<td><img src="../images/spacer.gif" height="6"/></td>
  </tr>
     <tr>
        <td><asp:TextBox ID="txtTrans" runat="server" CssClass="fieldbdr" ReadOnly="True" Width="435px" BorderStyle="None"></asp:TextBox></td>
     </tr>
  <%--<tr>
    <td align="left" valign="middle" colspan="2">
                <input id="txtDis" readonly="readonly" type="text" style="width: 448px" class="fieldbdr" /></td>
  </tr>--%>
       <tr>
        <td><img src="../images/spacer.gif" height="6"/></td>
     </tr>
</table>

	</fieldset>
	</td>
  </tr>
</table>
            </td>
        <tr>
        <td style="height: 10px"><img src="../images/spacer.gif" height="10"/></td>
     </tr>
        <tr>
            <td>
            <table align="center" width="500" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td>
	<fieldset>
	<legend style="width: 101px"><font class="blackSubtext"><strong>Select Options:-</strong></font></legend>
	<table width="450" align="center" border="0" cellspacing="0" cellpadding="0">
	    <tr>
	        <td><img src="../images/spacer.gif" height="6"/></td>
        </tr>
        <tr>
            <td style="height: 10px"><asp:CheckBox ID="cbxFoID" runat="server" Text="Front Office ID" CssClass="boProfileleftMedium" /></td>
        </tr>
        <tr>
            <td><asp:CheckBox ID="CbxDrId" runat="server" Text="Dictator ID" CssClass="boProfileleftMedium" /></td>
        </tr>
        <tr>
            <td><asp:CheckBox ID="CbxAdNAme" runat="server" Text="Dictation Name" CssClass="boProfileleftMedium" /></td>
        </tr>
        <tr>
            <td><asp:CheckBox ID="cbxPLastName" runat="server" Text="Patient Last Name" CssClass="boProfileleftMedium" Visible="False" /></td>
        </tr>
        <tr>
            <td><asp:CheckBox ID="cbxPFirstName" runat="server" Text="Patient First Name" CssClass="boProfileleftMedium" Visible="False" /></td>
        </tr>
        <tr>
            <td><asp:CheckBox ID="cbxDate" runat="server" Text="Dictation Date" CssClass="boProfileleftMedium" /></td>
        </tr>
        <tr>
            <td><asp:CheckBox ID="cbxTimeStamp" runat="server" Text="Time Stamp" CssClass="boProfileleftMedium" /></td>
        </tr>
        <tr>
	        <td><img src="../images/spacer.gif" height="6"/></td>
        </tr>
</table>

	</fieldset>
	</td>
  </tr>
</table>
            </td>
        </tr>
       
        <tr>
            <td>
                <img src="../images/spacer.gif" height="3"></td>
        </tr>
        <tr>
            <td align="center" style="height: 24px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Path"></asp:Label>
                <asp:TextBox ID="txtPath" runat="server" Width="352px"></asp:TextBox><asp:Button ID="bntSubmit" runat="server" Text="Submit" /></td>
        </tr>
        <tr>
            <td>
                <img src="../images/spacer.gif" height="5"></td>
        </tr>
    </table>
</asp:Content>
        


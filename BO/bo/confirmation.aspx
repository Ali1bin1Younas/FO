<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false"
    CodeFile="confirmation.aspx.vb" Inherits="MD_confirmation" Title ="AccessTek [ Back Office - Admin ]" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <table width="980" border="0" cellspacing="0" cellpadding="0">
   <tr>
            <td style ="background-image:url(../images/BOadminHeadingBG.jpg); width :980; height :66;"><table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
            <tr><td align="left" class="headingLrg"><br style="line-height:20px;"/><strong>Change Password</strong></td></tr>
         </table></td>
        </tr>
        <tr>
        <td align="center" colspan="3">
            <img src="../images/spacer.gif" height="20" /></td>
        </tr>
        <tr>
            <td align="center" colspan="3" valign="middle">
                <asp:Label ID="lblConfirmationMessage" runat="server" ForeColor="Black"
                                                Font-Size="8pt" Font-Names="Verdana"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">
                <img src="../images/spacer.gif" height="3" /></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnDone" runat="server" Text="Done" Height="20px" Width="65px" /></td>
        </tr>
        <tr>
            <td colspan="3">
                <img src="../images/spacer.gif" height="5" /></td>
        </tr>
    </table>
</asp:Content>

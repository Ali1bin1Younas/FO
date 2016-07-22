<%@ Page Language="VB" MasterPageFile="~/Emp/MasterPage.master"AutoEventWireup="false"
    CodeFile="confirmation.aspx.vb" Inherits="MD_confirmation" Title =" AccessTek [ Back Office - Employee ]" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="980" cellspacing="0" cellpadding="0" border="0">
    <tr><td style="background-image:url(../images/BOEmpBanner.jpg); width:980; height:66;"><table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
            <tr><td align="left"><asp:Label ID="lblCompleteName" runat="server" CssClass="empName"></asp:Label><br style="line-height:10px;"/><br style="line-height:3px;"/><asp:Label ID="heading" runat="server" CssClass="empTitle">Change Password</asp:Label></td></tr>
         </table></td>
    </tr>
        
        <tr>
        <td align="center" >
            <img src="../images/spacer.gif" height="20" /></td>
        </tr>
        <tr>
            <td align="center" valign="middle">
                <asp:Label ID="lblConfirmationMessage" runat="server" ForeColor="Black" Font-Size="8pt" Font-Names="Verdana"></asp:Label></td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="3" /></td>
        </tr>
        <tr>
            <td align="center"><asp:Button ID="btnDone" runat="server" Text="Done" Height="25px" Width="65px" /></td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="5" /></td>
        </tr>
    </table>
</asp:Content>

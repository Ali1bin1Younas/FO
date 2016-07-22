<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="changepassword.aspx.vb" Inherits="BO_changeadminpassword" Title ="AccessTek [ Back Office - Admin ]" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="3">
                <img src="../images/spacer.gif" height="20"/></td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="lblMessage" runat="server" Font-Size="8pt" ForeColor="Black" Font-Names="Verdana"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <table align="center" width="500" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td >
                            <fieldset>
                                <legend><font class="blackSubtext"><strong>Login Information&nbsp;</strong></font></legend>
                                <table width="450" align="center" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="3">
                                            <img src="../images/spacer.gif" height="6"></td>
                                    </tr>
                                    <tr>
                                        <td class="profileright">
                                            <asp:Label ID="Label1" runat="server" Text="Old Password" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="profileleft">
                                            <asp:TextBox ID="txtOldPassword" CssClass="fieldbdr" runat="server" TextMode="Password" Height="18px" Width="150px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="profileright">
                                            <asp:Label ID="Label2" runat="server" Text="New Password" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="profileleft">
                                            <asp:TextBox ID="txtNewPassword" CssClass="fieldbdr" runat="server" TextMode="Password" Height="18px" Width="150px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="profileright">
                                            <asp:Label ID="Label3" runat="server" Text="Confirm Password" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="profileleft">
                                            <asp:TextBox ID="txtConfirmPassword" CssClass="fieldbdr" runat="server" TextMode="Password" Height="18px" Width="150px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <img src="../images/spacer.gif" height="6"></td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <img src="../images/spacer.gif" height="3"></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="60px" />&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Cancel" Width="60px" CausesValidation="false" /></td>
         </tr>
        <tr>
            <td align="center">
                <img src="../images/spacer.gif" height="5"></td>
        </tr>
    </table>
</asp:Content>



<%@ Page Language="VB" MasterPageFile="~/Emp/MasterPage.master" AutoEventWireup="false"
    CodeFile="emppassword.aspx.vb" Inherits="frontofficepassword" Title =" AccessTek [ Back Office - Employee ]" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="100%" cellpadding="0" cellspacing="0" border ="0">
       <tr>
        <td style="background-image:url(../images/BOEmpBanner.jpg); width:100%; height:66;">
            <table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblCompleteName" runat="server" CssClass="empName">
                        </asp:Label>
                        
                        <br style="line-height:10px;"/>
                        <br style="line-height:3px;"/>
                        
                        <asp:Label ID="heading" runat="server" CssClass="empTitle">
                            Change Password
                        </asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    
       <%-- <tr>
            <td colspan="3">
                <img src="../images/changePassword.jpg" alt="" width="770" height="66" /></td>
        </tr>--%>
        
        <tr>
            <td>
                <img src="../images/spacer.gif" height="20"/>
            </td>
        </tr>
        
        <tr>
            <td align="center">
                <asp:Label ID="lblMessage" runat="server" Font-Size="8pt" ForeColor="Black" Font-Names="Verdana">
                </asp:Label>
            </td>
        </tr>
        
        <tr>
            <td>
                <center>
                <table align="center" width="500" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <fieldset>
                                <legend><font class="blackSubtext"><strong>Login Information&nbsp;</strong></font></legend>
                                <table width="450" align="center" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="3">
                                            <img src="../images/spacer.gif" height="6">
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="profilerightPwd">
                                            <asp:Label ID="Label1" runat="server" Text="Old Password" Height="12px">
                                            </asp:Label>
                                        </td>
                                        
                                        <td class="divide">
                                        </td>
                                        
                                        <td class="profileleftPwd">
                                            <asp:TextBox ID="txtOldPassword" CssClass="fieldbdr" runat="server" TextMode="Password" Height="18px" Width="150px">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="profilerightPwd">
                                            <asp:Label ID="Label2" runat="server" Text="New Password" Height="12px">
                                            </asp:Label>
                                        </td>
                                        
                                        <td class="divide">
                                        </td>
                                        
                                        <td class="profileleftPwd">
                                            <asp:TextBox ID="txtNewPassword" CssClass="fieldbdr" runat="server" TextMode="Password" Height="18px" Width="150px">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="profilerightPwd">
                                            <asp:Label ID="Label3" runat="server" Text="Confirm Password" Height="12px">
                                            </asp:Label>
                                        </td>
                                        
                                        <td class="divide">
                                        </td>
                                        
                                        <td class="profileleftPwd">
                                            <asp:TextBox ID="txtConfirmPassword" CssClass="fieldbdr" runat="server" TextMode="Password" Height="18px" Width="150px">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="3">
                                            <img src="../images/spacer.gif" height="6">
                                        </td>
                                    </tr>
                                    
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
                </center>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <img src="../images/spacer.gif" height="3"></td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Button ID="Button1" runat="server" Text="Save" Width="65px" Height="25px" />
                <asp:Button ID="Button2" runat="server" Text="Cancel" Width="65px" Height="25px"
                    CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <img src="../images/spacer.gif" height="5"></td>
        </tr>
    </table>
</asp:Content>

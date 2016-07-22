<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false"
    CodeFile="companyupdate.aspx.vb" Inherits="companyupdate" Theme="BOboLayout" Title ="AccessTek [ Back Office - Admin ]" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        
        <tr>
            <td class="pageLink">
                <a href="company.aspx">Add company</a>| <a class="pageLink" href="companymain.aspx">Back</a>
            </td>
        </tr>
        <tr>
            <td class="tdspace">
            </td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="15" /></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table align="center" width="500" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <fieldset>
                                <legend><font class="blackSubtext"><strong>Company Detail&nbsp;</strong></font></legend>
                                <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="3"><img src="../images/spacer.gif" height="6" /></td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label3" runat="server" Text="Company ID" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtcomID" runat="server" CssClass="fieldBdr" Width="110px" Enabled="False" Height="18px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="boProfileright">
                                            Company Name
                                        </td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtcomName" runat="server" CssClass="fieldBdr" Height="18px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label21" runat="server" Text="Company Enable" Height="12px"></asp:Label>
                                        </td>
                                        <td class="divide"></td>
                                        <td class="boProfileleft">
                                            <asp:DropDownList ID="cmbcomEnable" runat="server" Width="155px" Height="22px">
                                                <asp:ListItem Text="True" Value="True" />
                                                <asp:ListItem Text="False" Value="False" /> 
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="3"><img src="../images/spacer.gif" height="6" /></td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="10" /></td>
        </tr>
       
       
                </table>
            </td>
        </tr>
        <tr>
            <td class="btnCenter">
                <br style="line-height: 4px;" />
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="61px" />&nbsp;<asp:Button
                    ID="btnCancel" runat="server" Text="Cancel" Width="61px" CausesValidation="false" /></td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="5" /></td>
        </tr>
    </table>
</asp:Content>

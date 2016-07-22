<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false"
    CodeFile="company.aspx.vb" Inherits="company" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="pageLink"><a href="companymain.aspx">Back</a></td>
        </tr>
        <tr>
            <td class="tdspace">
            </td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="15px" /></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="False" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></asp:Label></td>
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
                                            <font style="color:Red">*</font>&nbsp;Company Name
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
            <td><img src="../images/spacer.gif" height="3px" /></td>
        </tr>
        <tr>
            <td class="btnCenter" style="height: 26px">
                <br style="line-height: 3px;"/>
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="61px" />&nbsp;<asp:Button
                    ID="btnCancel" runat="server" Text="Cancel" Width="61px" CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="5px" /></td>
        </tr>
    </table>
</asp:Content>

<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false"
    CodeFile="employeechangepassword.aspx.vb" Inherits="changepassword" Theme="BOboLayout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width:100%; border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="pageLink"><a href="employeemain.aspx">Back</a></td>
        </tr>
        <tr>
            <td class="tdspace" style="height: 2px"></td>
        </tr>
        <tr><td><img src="../images/spacer.gif" height="15" alt="" />&nbsp;</td></tr>
        
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="60%" align="Center">
                    <tr>
                        <td colspan="2" class="leftCol">
                            <asp:Label runat="server" ID="lblError" ForeColor="Blue"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="boProfileright" style="width: 118px">
                            <asp:Label runat="server" ID="lblNewPassword" Text="New Password"></asp:Label><span style="color: #ff0000"> * </span>&nbsp;
                        </td>
                        <td class="boProfileleft">
                            <asp:TextBox runat="server" ID="txtNewPassword" TextMode="Password" CssClass="fieldbdr" Width="298px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="boProfileright" style="width: 118px" >
                            <asp:Label runat="server" ID="lblConPassword" Text="Confirm Password"></asp:Label><span style="color: #ff0000"> * </span>&nbsp;
                        </td>
                        <td class="boProfileleft">
                            <asp:TextBox runat="server" ID="txtConPassword" TextMode="Password" CssClass="fieldbdr" Width="295px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  align="center" colspan="2"  class="boProfileright" style="height: 25px">
                            </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="60%" align="center">
                    <tr>
                        <td align="center">
                            <asp:Button runat="server" ID="btnUpdate" Text="Update" CssClass="btnText" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword"
                                Display="None" ErrorMessage="Please enter new password"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConPassword"
                                Display="None" ErrorMessage="Please enter confirm password"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword"
                                ControlToValidate="txtConPassword" ErrorMessage="Password does not match" Display="None"></asp:CompareValidator>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="MistyRose"
                                ShowMessageBox="True" ShowSummary="False" />
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
       
    </table>
</asp:Content>

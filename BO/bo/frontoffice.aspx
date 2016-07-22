<%@ Page Language="VB" MasterPageFile ="~/bo/master.master" AutoEventWireup="false" CodeFile="frontoffice.aspx.vb" Inherits="fronoffice" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            
  <table width="770" cellpadding="0" cellspacing="0" border="0">
            
<tr>
    <td colspan="4"><img src="../images/addDictator.jpg" alt="" width="770" height="66" /></td>
    </tr>
    <tr>
    <td colspan="4" align="right" class="tdPageLinkText">&nbsp;<a class="pageLink" href="clientmain.aspx"></a></td>
    </tr>
            <tr>
                <td style="height: 30px; width: 380px;" class="profileleft">
        <asp:Label ID="lblfoID" runat="server" Text="Front Office ID" Width="150px"></asp:Label></td>
                <td class="divide" style="height: 30px">
                </td>
                <td class="profileright">
        <asp:TextBox ID="txtfoID" runat="server" CssClass="fieldbdr" MaxLength="4" Width="87px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfoID"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="profileleft" style="width: 380px">
        <asp:Label ID="lblfoName" runat="server" Text="Name" Width="87px"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Style="z-index: 100; left: 0px; position: absolute;
                        top: 0px" Text="Name" Width="87px"></asp:Label>
                </td>
                <td class="divide">
                </td>
                <td class="profileright">
        <asp:TextBox ID="txtfoName" runat="server" CssClass="fieldbdr"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfoName"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
            </tr>
                   <tr>
                       <td class="profileleft" style="width: 380px">
                           <asp:Label ID="Label9" runat="server" Text="Date" Width="87px"></asp:Label></td>
                       <td class="divide">
                       </td>
                       <td class="profileright">
                           <ew:calendarpopup id="CPFOCreated" runat="server"></ew:calendarpopup>
                       </td>
                   </tr>
                   <tr>
                       <td class="profileleft" style="width: 380px">
                           <asp:Label ID="Label7" runat="server" Text="Password" Width="87px"></asp:Label></td>
                       <td class="divide">
                       </td>
                       <td class="profileright">
                           <asp:TextBox ID="txtfoPassword" runat="server" CssClass="fieldbdr"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtfoPassword"
                               ErrorMessage="*"></asp:RequiredFieldValidator></td>
                   </tr>
                   <tr>
                       <td class="profileleft" style="width: 380px">
                           <asp:Label ID="Label8" runat="server" Text="Re Type Password" Width="114px"></asp:Label></td>
                       <td class="divide">
                       </td>
                       <td class="profileright">
                           <asp:TextBox ID="txtfoReTypePassword" runat="server" CssClass="fieldbdr"></asp:TextBox>
                           <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtfoPassword"
                               ControlToValidate="txtfoReTypePassword" ErrorMessage="Password Not Match"></asp:CompareValidator></td>
                   </tr>
            <tr>
                <td class="profileleft" style="width: 380px">
        <asp:Label ID="lblAddress" runat="server" Text="Address1" Width="87px"></asp:Label></td>
                <td class="divide">
                </td>
                <td class="profileright">
        <asp:TextBox ID="txtfoAddress" runat="server" CssClass="fieldbdr"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtfoAddress"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
            </tr>
                   <tr>
                       <td class="profileleft" style="width: 380px">
                           <asp:Label ID="Label2" runat="server" Text="Address2" Width="87px"></asp:Label></td>
                       <td class="divide">
                       </td>
                       <td class="profileright">
                           <asp:TextBox ID="txtfoAddress2" runat="server" CssClass="fieldbdr"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td class="profileleft" style="width: 380px">
                           <asp:Label ID="Label3" runat="server" Text="City" Width="87px"></asp:Label></td>
                       <td class="divide">
                       </td>
                       <td class="profileright">
                           <asp:TextBox ID="txtfoCity" runat="server" CssClass="fieldbdr"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtfoCity"
                               ErrorMessage="*"></asp:RequiredFieldValidator></td>
                   </tr>
            <tr>
                <td class="profileleft" style="width: 380px">
        <asp:Label ID="lblState" runat="server" Text="State" Width="87px"></asp:Label></td>
                <td class="divide">
                </td>
                <td class="profileright">
        <asp:TextBox ID="txtfoState" runat="server" CssClass="fieldbdr"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfoState"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="profileleft" style="width: 380px">
        <asp:Label ID="lblZip" runat="server" Text="Zip" Width="87px"></asp:Label></td>
                <td class="divide">
                </td>
                <td class="profileright">
        <asp:TextBox ID="txtfoZip" runat="server" CssClass="fieldbdr"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtfoZip"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
            </tr>
                   <tr>
                       <td class="profileleft" style="width: 380px">
                           <asp:Label ID="Label4" runat="server" Text="Country" Width="87px"></asp:Label></td>
                       <td class="divide">
                       </td>
                       <td class="profileright">
                           <asp:DropDownList ID="cmbfoCountry" runat="server" Height="20px" Width="153px">
                               <asp:ListItem>United States</asp:ListItem>
                               <asp:ListItem>UK</asp:ListItem>
                               <asp:ListItem>Pakistan</asp:ListItem>
                           </asp:DropDownList></td>
                   </tr>
            <tr>
                <td class="profileleft" style="width: 380px">
        <asp:Label ID="lblPhoneNo" runat="server" Text="Phone No" Width="87px"></asp:Label></td>
                <td class="divide">
                </td>
                <td class="profileright">
        <asp:TextBox ID="txtfoPhoneNo" runat="server" CssClass="fieldbdr"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtfoPhoneNo"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="profileleft" style="width: 380px">
        <asp:Label ID="lblFaxNo" runat="server" Text="Fax No" Width="87px"></asp:Label></td>
                <td class="divide">
                </td>
                <td class="profileright">
        <asp:TextBox ID="txtfoFaxNo" runat="server" CssClass="fieldbdr"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtfoFaxNo"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="profileleft" style="width: 380px">
        <asp:Label ID="lblEmail" runat="server" Text="Email" Width="87px"></asp:Label></td>
                <td class="divide">
                </td>
                <td class="profileright">
        <asp:TextBox ID="txtfoEmail" runat="server" CssClass="fieldbdr"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtfoEmail"
                        ErrorMessage="wrong format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
            </tr>
                   <tr>
                       <td class="profileleft" style="width: 380px">
        <asp:Label ID="lblURL" runat="server" Text="URL" Width="87px"></asp:Label></td>
                       <td class="divide">
                       </td>
                       <td class="profileright">
        <asp:TextBox ID="txtfoURL" runat="server" CssClass="fieldbdr"></asp:TextBox></td>
                   </tr>
            <tr>
                <td class="profileleft" style="width: 380px">
        <asp:Label ID="lblContactPersonName" runat="server" Text="Contact Person Name" Width="165px"></asp:Label></td>
                <td class="divide">
                </td>
                <td class="profileright">
        <asp:TextBox ID="txtfoContactPersonName" runat="server" CssClass="fieldbdr"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtfoContactPersonName"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
            </tr>
                   <tr>
                       <td class="profileleft" style="width: 380px">
        <asp:Label ID="Label1" runat="server" Text="Contact Person Address" Width="177px"></asp:Label></td>
                       <td class="divide">
                       </td>
                       <td class="profileright">
        <asp:TextBox ID="txtfoContactPersonAddress" runat="server" CssClass="fieldbdr"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtfoContactPersonAddress"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
                   </tr>
            <tr>
                <td class="profileleft" style="width: 380px">
        <asp:Label ID="lblContactPersonPhoneNo" runat="server" Text="ContactPerson Phone  No" Width="199px"></asp:Label></td>
                <td class="divide">
                </td>
                <td class="profileright">
        <asp:TextBox ID="txtfoContactPersonPhoneNo" runat="server" CssClass="fieldbdr"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtfoContactPersonPhoneNo"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="profileleft" style="width: 380px">
        <asp:Label ID="lblContactPersonCellNo" runat="server" Text="Contact Person Cell No" Width="169px"></asp:Label></td>
                <td class="divide">
                </td>
                <td class="profileright">
        <asp:TextBox ID="txtfoContactPersonCellNo" runat="server" CssClass="fieldbdr"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtfoContactPersonCellNo"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="profileleft" style="width: 380px">
        <asp:Label ID="lblContactPersonEmail" runat="server" Text="Contact Person Email" Width="177px"></asp:Label></td>
                <td class="divide">
                </td>
                <td class="profileright">
        <asp:TextBox ID="txtfoContactPersonEmail" runat="server" CssClass="fieldbdr"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtfoContactPersonEmail"
                        ErrorMessage="wrong format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td class="profileleft" style="width: 380px">
        <asp:Label ID="lblContactPersonPagerNo" runat="server" Text="Contact Person Pager No" Width="177px"></asp:Label></td>
                <td class="divide">
                </td>
                <td class="profileright">
        <asp:TextBox ID="txtfoContactPersonPagerNo" runat="server" CssClass="fieldbdr"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtfoContactPersonPagerNo"
                        ErrorMessage="*"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="height: 30px" colspan="3">
                </td>
            </tr>
                   <tr>
                       <td class="btnCenter" colspan="3">
        
        <asp:Button ID="btnSave" runat="server" Style="z-index: 100; left: 471px; position: notset;
            top: 557px" Text="Save" Width="60px" Height="24px" />&nbsp;<asp:Button ID="btnCancel" runat="server" Style="z-index: 103; left: 541px; position: notset;
            top: 555px" Text="Cancel"  CausesValidation ="false "/></td>
                   </tr>
                   <tr>
                       <td class="profileright" colspan="3">
                       </td>
                   </tr>
        </table>
    
    
</asp:Content>

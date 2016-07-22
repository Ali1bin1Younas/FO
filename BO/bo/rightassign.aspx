<%@ Page Language="VB"  MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="rightassign.aspx.vb" Inherits="rightassign" %>
<asp:Content  ID ="Content1" ContentPlaceHolderID ="ContentPlaceHolder1" runat ="server" >


       
   <table width="770" border="0" cellspacing="0" cellpadding="0">
    <tr>
        
    <td colspan="5"><img src="../images/employeeRights.jpg" alt="" width="770" height="66" /></td>
    </tr>
    <tr>
        
    <td class="tdPageLinkText" colspan="5" align="right">&nbsp; <a class="pageLink" href="employeemain.aspx">Back</a>&nbsp;</td>
    </tr>
            <tr>
               
                <td class="tdspace" colspan="5" style="height: 2px"></td></tr> 
       <tr>
           <td style="height: 30px">
           </td>
           <td class="profileright" style="width: 437px; height: 30px">
               <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Employee ID:" Width="104px"></asp:Label>
               <asp:Label ID="lblEmployeeID" runat="server" Text="Label" Width="142px"></asp:Label></td>
           <td style="height: 30px">
           </td>
           <td style="width: 2px; height: 30px">
           </td>
           <td style="height: 30px">
           </td>
       </tr>
       <tr>
           <td style="height: 30px">
           </td>
           <td class="profileright" style="width: 437px; height: 30px">
               <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Employee Name:" Width="105px"></asp:Label>
               <asp:Label ID="lblEmployeeName" runat="server" Text="Label" Width="183px"></asp:Label></td>
           <td style="height: 30px">
           </td>
           <td style="width: 2px; height: 30px">
           </td>
           <td style="height: 30px">
           </td>
       </tr>

            <tr>
                <td style="height: 30px"><img src="../images/spacer.gif" width="50" height="10">
                        </td>
                <td style="width: 437px; height: 30px" class="profileright"><br style="line-height:10px;"/>
                    <asp:CheckBox ID="AD" runat="server" Text="Admin" ForeColor="Black" /></td>
                <td style="height: 30px"><img src="../images/spacer.gif" width="50" height="10">
                </td>
                <td style="width: 2px; height: 30px"><br style="line-height:10px;"/>
                    <asp:LinkButton ID="lnkAD" runat="server" CssClass="pageLink">LinkButton</asp:LinkButton>
                    
                </td>
                <td style="height: 30px"><br style="line-height:10px;"/>
                   <img src="../images/spacer.gif" width="50" height="10">
                    
                    </td>
            </tr>
       <tr>
           <td style="height: 20px">
               <img src="../images/spacer.gif" width="50" height="10"></td>
           <td class="profileright" style="height: 20px; width: 437px;">
               <asp:CheckBox ID="MT" runat="server" Text="Medical Transcriptor" ForeColor="Black" /></td>
           <td style="height: 20px">
               <img src="../images/spacer.gif" width="50" height="10"></td>
           <td style="width: 2px; height: 20px">
               <asp:LinkButton ID="lnkMT" runat="server" CssClass="pageLink">LinkButton</asp:LinkButton></td>
           <td style="height: 20px">
               <img src="../images/spacer.gif" width="50" height="10"></td>
       </tr>
       <tr>
           <td style="height: 21px">
               <img src="../images/spacer.gif" width="50" height="10"></td>
           <td class="profileright" style="height: 21px; width: 437px;">
                    <asp:CheckBox ID="PR" runat="server" Text="Proof Reader" Width="143px" ForeColor="Black" /></td>
           <td style="height: 21px">
               <img src="../images/spacer.gif" width="50" height="10"></td>
           <td style="width: 2px; height: 21px">
                    <asp:LinkButton ID="lnkPR" runat="server" CssClass="pageLink">LinkButton</asp:LinkButton></td>
           <td style="height: 21px">
               <img src="../images/spacer.gif" width="50" height="10"></td>
       </tr>
            <tr>
                <td style="height: 21px"><img src="../images/spacer.gif" width="50" height="10">
                </td>
                <td class="profileright" style="height: 21px; width: 437px;">
                    <asp:CheckBox ID="FR" runat="server" Text="Formator" ForeColor="Black" /></td>
                <td style="height: 21px"><img src="../images/spacer.gif" width="50" height="10">
                    
                </td>
                <td style="width: 2px; height: 21px;">
                    <asp:LinkButton ID="lnkFR" runat="server" CssClass="pageLink">LinkButton</asp:LinkButton></td>
                <td style="height: 21px"><img src="../images/spacer.gif" width="50" height="10">
                    </td>
            </tr>
       <tr>
           <td style="height: 21px">
           </td>
           <td class="profileright" style="height: 21px; width: 437px;">
           </td>
           <td style="height: 21px">
           </td>
           <td style="width: 2px; height: 21px">
           </td>
           <td style="height: 21px">
           </td>
       </tr>
            <tr>
               
               
                <td class="tdspace" colspan="5"></td></tr> 

            <tr>
                
                <td style="text-align: center; height: 23px;" colspan="5"><br style="line-height:3px;">
                    &nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Height="20px" Width="56px" />
                    <asp:Button ID="btnShow" runat="server" Text="Cancel" Height="20px" Width="56px" /></td>
            </tr>
            <tr><td colspan="5"><img src="../images/spacer.gif" height="10px"></td></tr>
        </table>
        </asp:Content>
      

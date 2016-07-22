<%@ Page Language="VB"  MasterPageFile ="~/BO/master.master" AutoEventWireup="false" CodeFile="roles.aspx.vb" Inherits="roles" Theme="BOboLayout" Title ="AccessTek [ Back Office - Admin ]" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
      
       <table width="980" border="0" cellspacing="0" cellpadding="0">
    <tr>
            <td style ="background-image:url(../images/BOadminHeadingBG.jpg); width :980; height :66;"><table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
            <tr><td align="left" class="headingLrg"><br style="line-height:20px;"/><strong>Employee Rights</strong></td></tr>
         </table></td>
        </tr>
    
    <tr>
     <td class="tdPageLinkText"><a class="pageLink" href="employeemain.aspx">Back</a>&nbsp;&nbsp;</td>
    </tr>
    <tr>
    <td class="tdspace" style="height: 2px"></td>
    </tr>
     
           <tr><td><img src="../images/spacer.gif" height="15" alt="" />&nbsp;</td></tr>
           <tr>
               <td><table width="980" border="0" cellpadding="0" cellspacing="0"><tr><td rowspan="2"><img src="../images/spacer.gif" width="25" /></td><td class="locationLabel"><asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Black"
            Text="Employee ID:" Height="12px"></asp:Label></td><td height="20" valign="middle" align="left" class="boProfileLeft"><asp:Label ID="lblEmployeeID" runat="server"
                Font-Size="11px" ForeColor="Black" Text="Label" CssClass="locationText" Width="110px" Height="18px"></asp:Label></td><td rowspan="2"><img src="../images/spacer.gif" width="180" height="1" /></td></tr><tr><td class="locationLabel"><asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Black"
                       Text="Employee Name:" Height="12px" Width="95px"></asp:Label></td><td height="20" valign="middle" align="left" class="boProfileLeft"><asp:Label ID="lblEmployeeName" CssClass="locationText" runat="server"
                           Font-Size="11px" ForeColor="Black" Text="Label" Width="270px" Height="18px"></asp:Label></td></tr></table>
               </td>
           </tr>
           <tr><td><img src="../images/spacer.gif" height="15" alt="" /></td></tr>
    <tr>
    <td>
        <asp:GridView ID="grdRoles" SkinId="gridviewSkin" runat="server" AutoGenerateColumns="False" GridLines="None" Width="695px">
            <Columns>
                <asp:TemplateField HeaderText="Roles" HeaderStyle-CssClass ="gridHeadingCenter">
                         <ItemTemplate>
                    <asp:CheckBox ID="chkRoles" runat="server" Checked='<%#getEnableDisable1(Eval("empEnable").ToString)%>' Enabled="true" />
                    <asp:HiddenField ID="rolID" Value='<%#Eval("rolID") %>' runat="server" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="50px" />
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass ="gridHeadingLeft">
                         <ItemTemplate>
                    <%#getDescription(Eval("rolDescription"))%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="left" CssClass ="tdspacingLeft" Width="880px"/>
                    <HeaderStyle HorizontalAlign="left" Width="880px"/>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Enable" HeaderStyle-CssClass ="gridHeadingCenter">
                    <ItemTemplate>
                   <a href= "rolesenable.aspx?empID=<%#Eval("empID")%>&rolID=<%#Eval("rolID")%>&valED=<%#getEnableDisable1(Eval("empEnable").ToString)%>"><img src="<%#getEnableDisable(Eval("empEnable").toString())%>" border="0" alt="Enable/Disable" /></a>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="50px"/>
                    <HeaderStyle HorizontalAlign="Center" Width="50px"/> 
                </asp:TemplateField>
            </Columns>
          
        </asp:GridView>
</td>
</tr>
<tr><td class="tdspace" style="height: 2px;"></td></tr> 
<tr><td><img src="../images/spacer.gif" height="4" /></td></tr>
    <tr><td align="center"><asp:Button ID="btnSave" runat="server" Text="Save" Width="64px" Height="24px" />&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="64px" Height="24px" /></td></tr>  
    <tr><td><img src="../images/spacer.gif" height="6" /></td></tr>         
     </table>
</asp:Content>




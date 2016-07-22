<%@ Page Language="VB"  MasterPageFile ="~/BO/master.master" AutoEventWireup="false" CodeFile="employeemain.aspx.vb" Inherits="employeemain" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
 <table width="100%" border="0" cellspacing="0" cellpadding="0">
   <tr>
    <td class="pageLink">
        <font color="black">Status</font>&nbsp;
            <asp:DropDownList ID="cmbStatus" runat="server" Width="140px" Height="19px">
                <asp:ListItem Text="Active" Value="True" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Inactive" Value="False"></asp:ListItem>
                <asp:ListItem Text="All" Value="all"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnStatus" Text="View" Width="60px" runat="server" />
      </td>
   </tr>
   
    <tr>
        <td class="pageLink">
            <a href="employee.aspx">Add Employee</a>
        </td>
    </tr>
    <tr>
       <td class="pageLink">
        </td> 
    </tr>
    <tr>
    <td>
        <asp:GridView ID="grdEmployee" SkinId="gridviewSkin" runat="server" DataKeyNames="empID,empEnable" AutoGenerateColumns="False" PageSize="1" GridLines="None">
            <Columns>
                <asp:TemplateField HeaderText="#">
                    <ItemTemplate>
                    <%#iCounter%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="ID/Login ID">
                    <HeaderStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="80px" />
                    <ItemTemplate>
                        <%#Eval("empID")%><br /><font color="blue"><%#Eval("empLoginID")%></font>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="80px" Height="36px" CssClass="tdspacingLeft"/>
                </asp:TemplateField>
                
                <%--<asp:BoundField DataField="empID" HeaderText="ID" >
                    <ItemStyle HorizontalAlign="center" Width="80px" />
                    <HeaderStyle HorizontalAlign="center" CssClass="gridHeadingCenter" Width="80px" />
                </asp:BoundField>
                
                <asp:BoundField DataField="empLoginID" HeaderText="Login ID" >
                    <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="140px" />
                    <HeaderStyle HorizontalAlign="center" CssClass="gridHeadingCenter" Width="140px" />
                </asp:BoundField>--%>
                
                <asp:TemplateField HeaderText="Name/Designation">
                    <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="290px" />
                    <HeaderStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="390px" />
                    <ItemTemplate>
                        <%#Eval("empFirstName")%>&nbsp;<%#Eval("empLastName")%><br /><font color="blue"><%#Eval("empDesignation")%></font>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
                <asp:TemplateField HeaderText="Company/Department">
                    <ItemTemplate>
                        <%#Eval("comName")%><br /><font color="blue"><%#Eval("depName")%></font>
                        
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="80px" Height="36px" />
                </asp:TemplateField>
                
                
                 <asp:TemplateField HeaderText="Type">
                    <ItemTemplate>
                        <%#Eval("etpName")%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="80px" Height="36px" />
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Phone/Email">
                    <ItemTemplate>
                        <%#Eval("empPhone")%><br /><font color="blue"><%#Eval("empEMail")%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="80px" Height="36px" />
                </asp:TemplateField>
                
                
                <asp:TemplateField HeaderText="Options" HeaderStyle-CssClass="gridHeadingCenter" ItemStyle-CssClass="grid4Ico">
                  <ItemTemplate>
                      <a title ="view employee details" href ="employeeview.aspx?empID=<%#DataBinder.Eval(Container.DataItem,"empID") %>"><asp:Image ImageUrl="~/icon/Nview.gif" Runat="server" ID="Image1"></asp:Image></a>
                      <a title ="Edit employee details" href="employeeupdate.aspx?empID=<%# DataBinder.Eval(Container.DataItem, "empID") %>"><asp:Image ImageUrl="~/icon/edit.gif" Runat="server" ID="Image2"></asp:Image></a> 
                      <a title ="Assign roles to employee" href="employeeroles.aspx?empID=<%# DataBinder.Eval(Container.DataItem, "empID")%>" ><asp:Image ImageUrl="~/icon/Nlock.gif" Runat="server" ID="Image4"></asp:Image></a>
                      <a title="Change employee password" href="employeechangepassword.aspx?empId=<%#DataBinder.Eval(Container.DataItem,"empID") %>"><asp:Image ImageUrl="~/icon/password-icon.png" Runat="server" ID="imgPwd" Width="18px" Height="18px"></asp:Image></a>
                      <asp:ImageButton ToolTip="Enable/Disable employee" ID="ImageButtonED" AlternateText="Enable/Disable employee" text="Enable/Disable employee" runat="server" ImageUrl=<%#getEnableDisable(Eval("empEnable").toString())%>/>
                      <%--<a  title ="Enable/Disable employee" href="enabledisable.aspx?tbl=boEmployee&colEnable=empEnable&colPrimary=empID &idGeneral=<%# DataBinder.Eval(Container.DataItem, "empID") %>&rdPage=employeemain.aspx&valED=<%# DataBinder.Eval(Container.DataItem, "empEnable") %>") onclick="return confirmEnableDisable();"><img src="<%#getEnableDisable(Eval("empEnable").toString())%>" border="0" alt="Enable/Disable" /></a>--%>
                    </ItemTemplate>
                   <%-- <ItemStyle HorizontalAlign="Left" Width="110px" />
                    <HeaderStyle HorizontalAlign="Center" Width="110px" />--%>
                </asp:TemplateField>
                
               <%-- <asp:TemplateField>
                <ItemTemplate >
                   <a title ="Edit" href="employeeupdate.aspx?empID=<%# DataBinder.Eval(Container.DataItem, "empID") %>"><asp:Image ImageUrl="~/Icon/edit.gif" Runat="server" ID="Image2"></asp:Image></a> 
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" />
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                 </asp:TemplateField>--%>
                
               <%-- <asp:TemplateField>
                        <ItemTemplate>
                               <a  title ="Enable/Disable" href="enabledisable.aspx?tbl=boEmployee&colEnable=empEnable&colPrimary=empID &idGeneral=<%# DataBinder.Eval(Container.DataItem, "empID") %>&rdPage=employeemain.aspx&valED=<%# DataBinder.Eval(Container.DataItem, "empEnable") %>") onclick="return confirmEnableDisable();"><img src="<%#getEnableDisable(Eval("empEnable").toString())%>" border="0" alt="Enable/Disable" /></a>
                        </ItemTemplate> 
                    <ItemStyle HorizontalAlign="Left" Width="45px" />
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                </asp:TemplateField>--%>
                
            <%--<asp:TemplateField>
                        <ItemTemplate>
                               <a title ="Rights" href="roles.aspx?empID=<%# DataBinder.Eval(Container.DataItem, "empID")%>" ><asp:Image ImageUrl="~/Icon/Nlock.gif" Runat="server" ID="Image4"></asp:Image></a>
                        </ItemTemplate> 
                    <ItemStyle HorizontalAlign="Left" Width="45px" />
                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                </asp:TemplateField>--%>
            
            </Columns>
          </asp:GridView>
        
 </td>
</tr>
<%--<tr><td class="tdspace"></td></tr> --%>
<%--<tr><td><img src="../images/spacer.gif" height="10" /></td></tr>--%>           
     </table>
 
</asp:Content>




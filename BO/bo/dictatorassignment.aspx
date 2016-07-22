<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="dictatorassignment.aspx.vb" Inherits="dictatorassignment" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>

<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellspacing="0" cellpadding="0" width ="100%">
        <tr>
            <td class="searchTools">
                <asp:DropDownList ID="cmbMT" runat="server" Width="140px" Height="19px"></asp:DropDownList>
                <asp:DropDownList ID="cmbQC" runat="server" Width="139px" Height="19px"></asp:DropDownList>
                <asp:DropDownList ID="cmbPR" runat="server" Width="139px" Height="19px"></asp:DropDownList>
                <asp:DropDownList ID="cmbFR" runat="server" Width="139px" Height="19px"></asp:DropDownList>
                <asp:Button ID="btnAssign" runat="server" Text="Assign" Width="60px" />
            </td>   
        </tr>
     
       
    <tr>
    <td>
        <asp:GridView ID="grdUnassigned" SkinId="gridviewSkin" runat="server" AutoGenerateColumns="False" GridLines="None" Width="770px" DataKeyNames="foID,drID">
                 
            <Columns>
                <asp:TemplateField HeaderText="All">
                    <ItemStyle HorizontalAlign="Center" Width="40px" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    <HeaderTemplate>
                <asp:CheckBox runat="server" ID="HeaderLevelCheckBox" />
            </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="drCheck" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="gridHeadingCenter">
                    <ItemStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="tdSpacingleft" Width="80px" />
                    <ItemTemplate>
                       <%# Eval("foID")%>-<%# Eval("drID") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="gridHeadingLeft">
                    
                    <ItemStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="239px" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="239px" />
                    <ItemTemplate>
                       <%#Eval("drLastName")%>,&nbsp;<%#Eval("drFirstName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MT" HeaderStyle-CssClass="gridHeadingLeft">
                    <ItemStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="140px" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="140px" />
                    <ItemTemplate>
                        <p>
                            -</p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QC" HeaderStyle-CssClass="gridHeadingLeft">
                    <ItemStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="140px" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="140px" />
                    <ItemTemplate>
                        <p>
                            -</p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PR" HeaderStyle-CssClass="gridHeadingLeft">
                    <ItemStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="140px" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="140px" />
                    <ItemTemplate>
                        <p>
                            -</p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FR" HeaderStyle-CssClass="gridHeadingLeft">
                    <ItemStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="140px" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="140px" />
                    <ItemTemplate>
                        <p>
                            -</p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                <ItemTemplate>
                &nbsp;&nbsp;
                 </ItemTemplate>
                    <ItemStyle Width="61px" HorizontalAlign ="Center" Wrap="False" />
                    <HeaderStyle Width ="61px" HorizontalAlign ="Center" />
                </asp:TemplateField>
            </Columns>
            
        </asp:GridView>
        </td>
        </tr> 
      
      
     <tr><td><asp:GridView ID="grdAssigned" SkinId="gridviewSkin" runat="server" AutoGenerateColumns="False" GridLines="None" Width="770px" DataKeyNames="foID,drID">
         <Columns>
             <asp:TemplateField HeaderText="#" HeaderStyle-CssClass="gridHeadingCenter">
                
                 <ItemStyle HorizontalAlign="Center" Width="40px" Wrap="False" />
                 <ItemTemplate>
                <%#getCounter() %>
                 </ItemTemplate>
                 <HeaderStyle HorizontalAlign="Center" Width="40px" />
             </asp:TemplateField>
             <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="gridHeadingCenter">
                <ItemStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="tdSpacingleft" Width="80px" />
                    <ItemTemplate>
                       <%# Eval("foID")%>-<%# Eval("drID") %>
                    </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="gridHeadingLeft">
                 <ItemStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="239px" Wrap="False" />
                 <HeaderStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="239px" />
                 <ItemTemplate>
                     <%#Eval("drLastName")%>,&nbsp;<%#Eval("drFirstName")%>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="MT" HeaderStyle-CssClass="gridHeadingLeft">
                 <ItemStyle HorizontalAlign="Left" Width="140px" Wrap="False" />
                 <HeaderStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="140px" />
                 <ItemTemplate>
                        <asp:CheckBox ID="AssChkMT" runat="server" />
                       <%#getEmployeeName(Eval("drID"), Eval("foID"),"MT")%>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="QC" HeaderStyle-CssClass="gridHeadingLeft">
                 <ItemStyle HorizontalAlign="Left" Width="140px" Wrap="False" />
                 <HeaderStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="140px" />
                 <ItemTemplate>
                 <asp:CheckBox ID="AssChkQC" runat="server" />
                  <%#getEmployeeName(Eval("drID"), Eval("foID"),"QC")%>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="PR" HeaderStyle-CssClass="gridHeadingLeft">
                 <ItemStyle HorizontalAlign="Left" Width="140px" Wrap="False" />
                 <HeaderStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="140px" />
                 <ItemTemplate>
                    <asp:CheckBox ID="AssChkPR" runat="server"/>
                    <%#getEmployeeName(Eval("drID"), Eval("foID"), "PR")%>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="FR" HeaderStyle-CssClass="gridHeadingLeft">
                 <ItemStyle HorizontalAlign="Left" Width="140px" Wrap="False" />
                 <HeaderStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="140px" />
                 <ItemTemplate>
                 <asp:CheckBox ID="AssChkFR" runat="server" />
                  <%#getEmployeeName(Eval("drID"), Eval("foID"), "FR")%>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField>
                  <ItemTemplate>
                     <a class ="blackLink" href ="dictatorassignmentdelete.aspx?foID=<%#Eval("foID")%>&drID=<%#Eval("drID") %>" onclick="return confirmUnassignment();">Unassign</a>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" Width="61px" Wrap="False" />
                 <HeaderStyle HorizontalAlign="Center" Width="61px" />
             </asp:TemplateField>
         </Columns>
       
     </asp:GridView></td></tr>
    <tr><td class="tdspace"></td></tr> 
<%--<tr><td><img src="../images/spacer.gif" height="10" /></td></tr> 
--%>     
     
     </table>

</asp:Content>


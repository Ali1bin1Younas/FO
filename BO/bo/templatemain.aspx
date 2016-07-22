<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="templatemain.aspx.vb" Inherits="templatemain" Title ="AccessTek [ Back Office - Admin ]" Theme ="BOboLayout" %>

<%--<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls"
    TagPrefix="DBWC" %>--%>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
  <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="emp.asmx" />
            </Services>
  </asp:ScriptManager>
          
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
    <tr>
        <td class="searchTools">
            <asp:Label ID="lblDictator" runat="server" Font-Size="11px" ForeColor="Black" Text="Dictator"></asp:Label>
            <asp:DropDownList ID="cmbDictator" runat="server"></asp:DropDownList>
            <asp:Button ID="btnView" runat="server" Text="View" Width="60px" />
        </td>
    </tr>
    <tr>
        <td class="searchTools">
            <asp:Label ID="Label1" runat="server" Font-Size="11px" ForeColor="Black" Text="Browse new Template File"></asp:Label>
            <asp:FileUpload id="upTemplate" runat="server" />
            <asp:Button ID="btnAddTemplate" runat="server" Text="Add" Width="60px" />
        </td>
    </tr>
     <tr>
     <td align="right"></td>
     </tr>
       <tr><td>
           <asp:GridView ID="grdTemplates" SkinId="gridviewSkin" OnRowCommand="grdTemplates_RowCommand" runat="server" AutoGenerateColumns="False" GridLines="None" PageSize="1" DataKeyNames="foID,drID,temTempName,temID,temEnable">
               <Columns>
                   <asp:TemplateField HeaderText="#">
                       <ItemTemplate>
                           <%#iCounter+1%>
                       </ItemTemplate>
                       <ItemStyle Width="40px" HorizontalAlign ="Center" />
                       <HeaderStyle Width="40px" CssClass="gridHeadingCenter" />
                   </asp:TemplateField>
                   
                   
                   <asp:TemplateField HeaderText="" Visible="false">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkTemplate" runat="server" Width ="12" Height ="12" />
                            <asp:Label ID="lblDicID" runat="server" Width="31px" Visible="false" Text='<%#Eval("temID")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                        <HeaderStyle HorizontalAlign="Center" Width="40px" CssClass="gridHeadingCenter" />
                   </asp:TemplateField>
                   
                   
                   <asp:BoundField DataField="temActualName" HeaderText="Name" >
                       <ItemStyle Width="680px" HorizontalAlign ="Left" CssClass ="tdspacingLeft" />
                       <HeaderStyle Width="680px" CssClass="gridHeadingLeft" />
                   </asp:BoundField>
                   
                   
                   <asp:BoundField DataField="temDate" HeaderText="Date" >
                       <ItemStyle Width="210px" HorizontalAlign ="Center" />
                       <HeaderStyle Width="210px" CssClass="gridHeadingCenter" />
                   </asp:BoundField>
                   
                   <asp:BoundField DataField="temID" HeaderText="ID" >
                       <ItemStyle Width="210px" HorizontalAlign ="Center" />
                       <HeaderStyle Width="210px" CssClass="gridHeadingCenter" />
                   </asp:BoundField>
                   
                   
                   <asp:TemplateField HeaderText="View">
                       <ItemTemplate>
                           <%--<asp:ImageButton ToolTip="Enable/Disable employee" ID="ImageButtonED" AlternateText="Enable/Disable employee" text="Enable/Disable employee" runat="server" ImageUrl=<%#getEnableDisable(Eval("temEnable").toString())%>/>--%>
                           <a title ="view template" href ="../data/<%#Eval("foID")%><%#Eval("drID")%>/templates/<%#Eval("temTempName")%>"><asp:Image ImageUrl="~/icon/nview.gif" Runat="server" ID="Image1"></asp:Image></a>
                           <%--<asp:ImageButton ToolTip="Set as default" ID="ImageButtonDefault" AlternateText="Set As Default" text="Set As Default" runat="server" ImageUrl=<%#getEnableDisable(Eval("temDefault").toString())%>/>--%>
                       </ItemTemplate>
                       <ItemStyle Width="70px" HorizontalAlign ="Center" />
                       <HeaderStyle Width="70px" CssClass="gridHeadingCenter" />
                   </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="Set As Default">
                       <ItemTemplate>
                           <asp:ImageButton ToolTip="Set as default" ID="ImageButtonDefault" OnClick="setDefault_Click" AlternateText="Set As Default" text="Set As Default" runat="server" ImageUrl=<%#getCU(Eval("temDefault").toString())%>/>
                       </ItemTemplate>
                       <ItemStyle Width="110px" HorizontalAlign ="Center" />
                       <HeaderStyle Width="110px" CssClass="gridHeadingCenter" />
                   </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="Enable">
                       <ItemTemplate>
                            <asp:ImageButton ToolTip="Enable/Disable template" ID="ButtonED" OnClick="setEnableDisable_Click"   runat="server" ImageUrl=<%#getEnableDisable(Eval("temEnable").toString())%>/>
                       
                           <%--<a title ="Enable/Disable template" href="enabledisable.aspx?tbl=boTemplates&colEnable=temEnable&colPrimary=temID&idGeneral=<%# DataBinder.Eval(Container.DataItem, "temID") %>&rdPage=templatemain.aspx&valED=<%# DataBinder.Eval(Container.DataItem, "temEnable") %>") onclick="return confirmEnableDisable();"><img src="<%#getEnableDisable(Eval("temEnable").toString())%>" border="0" alt="Enable/Disable" /></a>--%>
                       </ItemTemplate>
                       <ItemStyle Width="70px" HorizontalAlign="Center" />
                       <HeaderStyle Width="70px" CssClass="gridHeadingCenter" />
                   </asp:TemplateField>
               </Columns>
               
           </asp:GridView>
       </td>
       </tr> 
     
     </table>

</asp:Content>


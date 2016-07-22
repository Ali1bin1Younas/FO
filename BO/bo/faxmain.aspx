<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="faxmain.aspx.vb" Inherits="faxmain" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>

<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls"
    TagPrefix="DBWC" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellspacing="0" cellpadding="0" width ="980">
       <tr>
            <td style ="background-image:url(../images/BOadminHeadingBG.jpg); width :980; height :66;"><table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
            <tr><td align="left" class="headingLrg"><br style="line-height:20px;"/><strong>Faxes</strong></td></tr>
         </table></td>
        </tr>
    <tr>
    
    <td class="upload">
        <asp:Label ID="lblDictator" runat="server" Font-Size="11px" ForeColor="Black" Text="Dictator"></asp:Label>
        <asp:DropDownList ID="cmbDictator" runat="server" AutoPostBack="True" Width="270px">
            <asp:ListItem>All Faxes...</asp:ListItem>
        </asp:DropDownList>
        &nbsp;
        </td>
    </tr>
     
       
    <tr>
        <td><asp:GridView ID="grdTemplates" SkinId="gridviewSkin" runat="server" AutoGenerateColumns="False"
               GridLines="None" PageSize="1">
               <%--<FooterStyle BackColor="#CCCCCC" ForeColor="Black" />--%>
               <Columns>
                   <asp:TemplateField HeaderText="#" HeaderStyle-CssClass="gridHeadingCenter">
                       <ItemTemplate>
                           <%#iCounter%>
                       </ItemTemplate>
                       <ItemStyle Width="40px" HorizontalAlign="center" />
                       <HeaderStyle Width="40px" HorizontalAlign="center" />
                   </asp:TemplateField>
                   
                   <asp:BoundField DataField="faxActualName" HeaderText="Name" HeaderStyle-CssClass="gridHeadingLeft">
                   <ItemStyle Width="700px" CssClass="tdSpacingleft" HorizontalAlign="Left" />
                   <HeaderStyle Width="700px" CssClass="tdSpacingleft" HorizontalAlign="Left" />
                   </asp:BoundField >
                   <asp:TemplateField HeaderText="Date" HeaderStyle-CssClass="gridHeadingCenter">
                       <ItemTemplate>
                      <p> <%#Convert.ToDateTime(Eval("faxDate")).ToString("MM/dd/yyyy") %> </p>
                       </ItemTemplate>
                        <ItemStyle Width="150px" HorizontalAlign="center" />
                       <HeaderStyle Width="150px" HorizontalAlign="center" />
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="gridHeadingCenter">
                       <ItemTemplate>
                       <a href ="#" class ="blackLink">View</a>
                       </ItemTemplate>
                        <ItemStyle Width="90px" HorizontalAlign="center" />
                       <HeaderStyle Width="90px" HorizontalAlign="center" />
                   </asp:TemplateField>
               </Columns>
              
           </asp:GridView>
       </td></tr> 
    
    <tr><td class="tdspace"></td></tr> 
<%--<tr><td colspan="2" style="height: 10px"><img src="../images/spacer.gif" height="10" /></td></tr>--%> 
     
  </table>

</asp:Content>


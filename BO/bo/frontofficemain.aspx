<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="frontofficemain.aspx.vb" Inherits="frontofficemain" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <table width="770" border="0" cellspacing="0" cellpadding="0">
    <tr>
    <td colspan="4"><img src="../images/addDictator.jpg" alt="" width="770" height="66" /></td>
    </tr>
    <tr>
    <td colspan="4" align="right" class="tdPageLinkText" style="height: 13px">&nbsp;&nbsp;<a class="pageLink" href="frontoffice.aspx">Add</a></td>
    </tr>
    <tr>
    <td>
        <asp:GridView ID="grdFrontOffice" runat="server" AutoGenerateColumns="False" Height="15px" Width="100%" BorderStyle="None" PageSize="1" GridLines="None" CellPadding="3" Font-Size="11px" Font-Names="Verdana">
            <Columns>
                <asp:TemplateField HeaderText="#">
                    
                    <ItemTemplate>
                        <%#iCounter%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                </asp:TemplateField>
                <asp:BoundField DataField="foID" HeaderText="ID" >
                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                    <HeaderStyle HorizontalAlign="Left" Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="foName" HeaderText="Name" >
                    <ItemStyle HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" Width="500px" />
                </asp:BoundField>
                <asp:BoundField DataField="foPhoneNo" HeaderText="Phone No" >
                    <ItemStyle HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" Width="250px" />
                </asp:BoundField>
                <asp:BoundField DataField="foState" HeaderText="State" >
                    <ItemStyle HorizontalAlign="Left" />
                    <HeaderStyle HorizontalAlign="Left" Width="250px" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" Width="45px" />
                    <ItemTemplate>
                      <a title="View" href ="frontofficeview.aspx?foID=<%#DataBinder.Eval(Container.DataItem,"foID") %>"><asp:Image ImageUrl="~/Icon/Nview.gif" Runat="server" ID="Image1"></asp:Image></a>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="45px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Options">
                
                <ItemTemplate >
                
                <a title="Edit" href="frontofficeupdate.aspx?foID=<%# DataBinder.Eval(Container.DataItem, "foID") %>"><asp:Image ImageUrl="~/Icon/edit.gif" Runat="server" ID="Image1"></asp:Image></a> 
                                
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="45px" />
                    <HeaderStyle HorizontalAlign="Center" Width="45px" />
                                               
                </asp:TemplateField>
                 <asp:TemplateField>
                        <ItemTemplate>
                               <a href="enabledisable.aspx?tbl=mmoFO&colEnable=foEnable&colPrimary=foID &idGeneral=<%# DataBinder.Eval(Container.DataItem, "foID") %>&rdPage=frontofficemain.aspx&valED=<%# DataBinder.Eval(Container.DataItem, "foEnable") %>") onclick="return confirmEnableDisable();"> <img src="<%#getEnableDisable(Eval("foEnable").toString())%>" border="0" alt="Enable/Disable" /></a>
                        </ItemTemplate> 
                    <ItemStyle HorizontalAlign="Center" Width="45px" />
                     <HeaderStyle HorizontalAlign="Center" Width="45px" />
                </asp:TemplateField>
            </Columns>
          <RowStyle BorderStyle="None" BorderWidth="0px" BackColor="WhiteSmoke" ForeColor="Black" Width="18px" />
          <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
          <SelectedRowStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Left" />
          <HeaderStyle BackColor="#D7D7D7" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" Height="20px" />
          <AlternatingRowStyle BackColor="#ECECEC" />
        </asp:GridView>
       
   </td>
</tr>           
     </table>
 
</asp:Content>












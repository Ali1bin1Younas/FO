<%@ Page Language="VB"  MasterPageFile ="~/BO/master.master" AutoEventWireup="false" CodeFile="companymain.aspx.vb" Inherits="companymain" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
 <table width="100%" border="0" cellspacing="0" cellpadding="0">
   
    <tr>
        <td class="pageLink"><a href="company.aspx">Add Company</a></td>
    </tr>
    <tr>
    <td>
        <asp:GridView ID="grdEmployee" SkinId="gridviewSkin" runat="server" AutoGenerateColumns="False" PageSize="1" GridLines="None">
            <Columns>
            
                <asp:TemplateField HeaderText="#">
                    <ItemTemplate>
                    <%#iCounter%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                </asp:TemplateField>
                
                
                <asp:BoundField DataField="comID" HeaderText="Company ID" >
                    <ItemStyle HorizontalAlign="center" Width="80px" />
                    <HeaderStyle HorizontalAlign="center" CssClass="gridHeadingCenter" Width="80px" />
                </asp:BoundField>
                
                
                <asp:BoundField DataField="comName" HeaderText="Company Name" >
                    <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="140px" />
                    <HeaderStyle HorizontalAlign="center" CssClass="gridHeadingCenter" Width="140px" />
                </asp:BoundField>
                
                
                <asp:BoundField DataField="comEnable" HeaderText="Enable/Disable" >
                    <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="160px" />
                    <HeaderStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="160px" />
                </asp:BoundField>
                
                
                <asp:TemplateField HeaderText="Options" HeaderStyle-CssClass="gridHeadingCenter" ItemStyle-CssClass="grid4Ico">
                  <ItemTemplate>
                      <a title ="view company details" href ="companyview.aspx?comID=<%#DataBinder.Eval(Container.DataItem,"comID") %>"><asp:Image ImageUrl="~/icon/Nview.gif" Runat="server" ID="Image1"></asp:Image></a>
                      <a title ="Edit company details" href="companyupdate.aspx?comID=<%# DataBinder.Eval(Container.DataItem, "comID") %>"><asp:Image ImageUrl="~/icon/edit.gif" Runat="server" ID="Image2"></asp:Image></a> 
                      <a  title ="Enable/Disable company" href="enabledisable.aspx?tbl=boCompany&colEnable=comEnable&colPrimary=comID &idGeneral=<%# DataBinder.Eval(Container.DataItem, "comID") %>&rdPage=companymain.aspx&valED=<%# DataBinder.Eval(Container.DataItem, "comEnable") %>") onclick="return confirmEnableDisable();"><img src="<%#getEnableDisable(Eval("comEnable").toString())%>" border="0" alt="Enable/Disable" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
          </asp:GridView>
        
 </td>
</tr>
          
</table>
 
</asp:Content>




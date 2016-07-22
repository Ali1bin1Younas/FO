<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="viewfax.aspx.vb" Inherits="MMO_viewfax"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="770" border="0" cellspacing="0" cellpadding="0">
    <tr>
    <td colspan="4"><img src="../images/addDictator.jpg" alt="" width="770" height="66" /></td>
    </tr>
    <tr>
    <td colspan="4" align="right" class="tdPageLinkText" style="height: 13px">&nbsp;&nbsp;<a class="pageLink" href="dailyworkload.aspx">Back</a></td>
    </tr>
    <tr>
    <td>
        <asp:GridView ID="grdFax" runat="server" AutoGenerateColumns="False" Width="100%" BorderStyle="None" PageSize="1" GridLines="None" CellPadding="3" Font-Size="11px" Font-Names="Verdana">
          <RowStyle BorderStyle="None" BorderWidth="0px" BackColor="WhiteSmoke" ForeColor="Black" Width="18px" />
          <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
          <SelectedRowStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Left" />
          <HeaderStyle BackColor="#D7D7D7" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" Height="20px" />
          <AlternatingRowStyle BackColor="#ECECEC" />
            <Columns>
                <asp:BoundField DataField="drID" HeaderText="Dictator ID" />
                <asp:BoundField DataField="faxActualName" HeaderText="Fax Name" />
                <asp:BoundField DataField="faxDate" HeaderText="Date" />
            </Columns>
        </asp:GridView>
       
   </td>
</tr>           
     </table>


</asp:Content>


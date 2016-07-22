<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="frontofficeview.aspx.vb" Inherits="frontofficeview" %>

<asp:Content  ID ="Content1" ContentPlaceHolderID ="ContentPlaceHolder1" runat ="server" >

<table border="0" width="770" cellspacing="0" cellpadding="0">
   <tr>
    <td colspan="4"><img src="../images/addDictator.jpg" alt="" width="770" height="66" /></td>
    </tr>
    <tr>
    <td colspan="4" align="right" class="tdPageLinkText">&nbsp;&nbsp;<a class="pageLink" href="frontofficemain.aspx">Back</a></td>
    </tr>
        
        <tr>
            <td class="dvgrid">
            </td>
           <td>
        <asp:DetailsView ID="dvFrontOffice" runat="server" Height="35px" Width="100%" CssClass="dvcolumn" GridLines="None">
            <EditRowStyle HorizontalAlign="Left" />
            <RowStyle CssClass="dvcolumn" />
        </asp:DetailsView>
            </td>
            <td class="dvgrid">
            </td> 
        </tr>
      <tr>
    <td colspan="4" style="height: 30px; width: 770px;">
    </td>
    </tr>  
    </table>
    </asp:Content>
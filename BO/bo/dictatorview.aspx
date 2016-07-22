<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="dictatorview.aspx.vb" Inherits="dictatorview" %>

<asp:Content  ID ="Content1" ContentPlaceHolderID ="ContentPlaceHolder1" runat ="server" >

   <table width="100%" border="0" cellspacing="0" cellpadding="0">
     
    <tr>
    <td class="pageLink" align="right"><a href="dictatormain.aspx">Back</a></td>
    </tr>
<tr><td class="tdspace"></td></tr> 

    <tr>
        <td><img src="../images/spacer.gif" height="15" /></td>
    </tr>
       <tr>
           <td align="center"><table align="center" width="650" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td>
	<fieldset>
	<legend><font class="blackSubtext"><strong>Dictator Information&nbsp;</strong></font></legend>
	<table width="550" align="center" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><img src="../images/spacer.gif" height="6" /></td>
	
  </tr>
  <tr>
    <td style="padding:10px;"><asp:DetailsView ID="dvEmployee" runat="server" Width="100%" CssClass="dvcolumn" GridLines="None">
            <EditRowStyle HorizontalAlign="Left" />
            <RowStyle CssClass="dvcolumn" />
        </asp:DetailsView>
            </td>
  </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="6" /></td>
        </tr>
</table>

	</fieldset>
	</td>
  </tr>
</table>
           </td>
       </tr>
       <tr>
    <td><img src="../images/spacer.gif" height="15" /></td>
	
  </tr> 
       </table>
    </asp:Content>
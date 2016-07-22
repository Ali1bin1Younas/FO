<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="companyview.aspx.vb" Inherits="companyview" Title ="AccessTek [ Back Office - Admin ]" %>

<asp:Content  ID ="Content1" ContentPlaceHolderID ="ContentPlaceHolder1" runat ="server" >

   <table width="100%" border="0" cellspacing="0" cellpadding="0">
    
    <tr>
    <td class="pageLink"><a href="companymain.aspx">Back</a></td>
    </tr>
<tr><td class="tdspace"></td></tr> 

    <tr>
        <td><img src="../images/spacer.gif" height="15" /></td>
    </tr>
       <tr>
           <td align="center">
           <table align="center" width="570" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td>
	<fieldset>
	<legend><font class="blackSubtext"><strong>Company Detail&nbsp;</strong></font></legend>
	<table width="400" align="center" border="0" cellspacing="0" cellpadding="0">
	
          <tr>
            <td>
                <img src="../images/spacer.gif" height="6" />
            </td>
          </tr>
          
          
          <tr>
            <td style="width:15px;"></td>
            <td>
                <asp:Label Text="Company ID" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="comID" runat="server"></asp:Label>
            </td>
          </tr>
          
          
              <tr>
                <td><img src="../images/spacer.gif" height="16" /></td>
              </tr>
          
          
          <tr>
            <td style="width:15px;"></td>
            <td>
                <asp:Label Text="Company Name" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="comName" runat="server"></asp:Label>
            </td>
          </tr>
          
          
                  <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>

          <tr>
            <td style="width:15px;"></td>
            <td>
                <asp:Label Text="Enable" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="comEnable" runat="server"></asp:Label>
            </td>
          </tr>
          
                <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>
          
    </table>

	</fieldset>
	</td>
  </tr>
  
  <tr>
    <td><img src="../images/spacer.gif" height="16" /></td>
  </tr>
  
  
  
        
    <tr>
    <td><img src="../images/spacer.gif" height="10" /></td>
    </tr>  
    </table>
    </asp:Content>
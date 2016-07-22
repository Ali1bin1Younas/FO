<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="employeeview.aspx.vb" Inherits="employeeview" Title ="AccessTek [ Back Office - Admin ]" %>

<asp:Content  ID ="Content1" ContentPlaceHolderID ="ContentPlaceHolder1" runat ="server" >

   <table width="100%" border="0" cellspacing="0" cellpadding="0">
    
    <tr>
    <td class="pageLink"><a href="employeemain.aspx">Back</a></td>
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
	<fieldset style="padding:10px;">
	<legend><font class="blackSubtext"><strong>Employee Information&nbsp;</strong></font></legend>
	<table width="300" align="center" border="0" cellspacing="0" cellpadding="0">
	
          <tr>
            <td>
                <img src="../images/spacer.gif" height="6" />
            </td>
          </tr>
          
          
          <tr>
            <td>
                <asp:Label Text="Employee ID" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empID" runat="server"></asp:Label>
            </td>
          </tr>
          
          
              <tr>
                <td><img src="../images/spacer.gif" height="16" /></td>
              </tr>
          
          
          <tr>
            <td>
                <asp:Label Text="Login ID" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empLoginID" runat="server"></asp:Label>
            </td>
          </tr>
          
          
                  <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>

          <tr>
            <td>
                <asp:Label Text="Password" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empPassword" runat="server"></asp:Label>
            </td>
          </tr>
          
                <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>

          <tr>
            <td>
                <asp:Label Text="Enable" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empEnable" runat="server"></asp:Label>
            </td>
          </tr>
          
    </table>

	</fieldset>
	</td>
  </tr>
  
  <tr>
    <td><img src="../images/spacer.gif" height="16" /></td>
  </tr>
  
  
  <tr>
    <td>
	<fieldset style="padding:10px;">
	<legend><font class="blackSubtext"><strong>Official Detail&nbsp;</strong></font></legend>
	<table width="300" align="center" border="0" cellspacing="0" cellpadding="0">
	        
              <tr>
                <td><img src="../images/spacer.gif" height="10" /></td>
              </tr>
              
           <tr>
            <td style="width:222px;">
                <asp:Label Text="Joining Date" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empJoiningDate" runat="server"></asp:Label>
            </td>
           </tr>
          
              <tr>
                <td><img src="../images/spacer.gif" height="16" /></td>
              </tr>

          <tr>
            <td>
                <asp:Label Text="Designation" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empDesignation" runat="server"></asp:Label>
            </td>
          </tr>
          
              <tr>
                <td><img src="../images/spacer.gif" height="16" /></td>
              </tr>

          <tr>
            <td>
                <asp:Label ID="Label5" Text="Department" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="depName" runat="server"></asp:Label>
            </td>
          </tr>
                    <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>
           <tr>
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
            <td>
                <asp:Label ID="Label2" Text="Employee Type" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="etpName" runat="server"></asp:Label>
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
    <td>
	<fieldset style="padding:10px;">
	<legend><font class="blackSubtext"><strong>Personal Detail&nbsp;</strong></font></legend>
	<table width="300" align="center" border="0" cellspacing="0" cellpadding="0">
	    
	              <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>
	
	     
              
           <tr>
            <td>
                <asp:Label ID="Label1" Text="Prefix" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empPrefix" runat="server"></asp:Label>
            </td>
          </tr>
          
          <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>
              <tr>
            <td style="width:222px;">
                <asp:Label ID="Label6" Text="Gender" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empGender" runat="server"></asp:Label>
            </td>
          </tr>
          
                  
                  <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>
           <tr>
            <td>
                <asp:Label ID="Label3" Text="First Name" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empFirstName" runat="server"></asp:Label>
            </td>
          </tr>
          
          <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>
              
           <tr>
            <td>
                <asp:Label ID="Label4" Text="Last Name" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empLastName" runat="server"></asp:Label>
            </td>
          </tr>
          
                  <tr>
                    <td><img src="../images/spacer.gif" height="10" /></td>
                  </tr>
              
           <tr>
            <td>
                <asp:Label Text="Date of Birth" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empDOB" runat="server"></asp:Label>
            </td>
          </tr>
          
          <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>
              
           <tr>
            <td>
                <asp:Label ID="Label8" Text="NIC #" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empNIC" runat="server"></asp:Label>
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
    <td>
	<fieldset style="padding:10px;">
	<legend><font class="blackSubtext"><strong>Contact Detail&nbsp;</strong></font></legend>
	<table width="300" align="center" border="0" cellspacing="0" cellpadding="0">
	        
              <tr>
                <td><img src="../images/spacer.gif" height="16" /></td>
              </tr>
              
           <tr>
            <td style="width:222px;">
                <asp:Label ID="Label11" Text="Address" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empAddress" runat="server"></asp:Label>
            </td>
          </tr>
          
          <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>
              
           <tr>
            <td>
                <asp:Label ID="Label12" Text="Address 2" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empAddress2" runat="server"></asp:Label>
            </td>
          </tr>
          
                  <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>
                  
                  
          <tr>
            <td>
                <asp:Label ID="Label13" Text="City" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empCity" runat="server"></asp:Label>
            </td>
          </tr>
          
          <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>
              
           <tr>
            <td>
                <asp:Label ID="Label14" Text="State" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empState" runat="server"></asp:Label>
            </td>
          </tr>
          
          <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>
              
           <tr>
            <td>
                <asp:Label ID="Label15" Text="ZIP Code" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empZip" runat="server"></asp:Label>
            </td>
          </tr>
                        
                        <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>
                    
           <tr>
            <td>
                <asp:Label ID="Label16" Text="Country" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empCountry" runat="server"></asp:Label>
            </td>
          </tr>
	                <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>
          <tr>
            <td>
                <asp:Label Text="Phone #" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empPhone" runat="server"></asp:Label>
            </td>
          </tr>
          
          <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>
              
           <tr>
            <td>
                <asp:Label ID="Label9" Text="Cell #" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empCell" runat="server"></asp:Label>
            </td>
          </tr>
          
          <tr>
                    <td><img src="../images/spacer.gif" height="16" /></td>
                  </tr>
              
           <tr>
            <td>
                <asp:Label ID="Label10" Text="Email" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="empEMail" runat="server"></asp:Label>
            </td>
          </tr>
          
              <tr>
                <td><img src="../images/spacer.gif" height="16" /></td>
              </tr>
          
    </table>

	</fieldset>
	</td>
  </tr>
</table>
           </td>
       </tr>
        
    <tr>
    <td><img src="../images/spacer.gif" height="10" /></td>
    </tr>  
    </table>
    </asp:Content>
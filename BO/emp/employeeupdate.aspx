<%@ Page Language="VB" MasterPageFile="~/Emp/MasterPage.master" AutoEventWireup="false"
    CodeFile="employeeupdate.aspx.vb" Inherits="employeeupdate" Title =" AccessTek [ Back Office - Employee ]" Theme="default" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="background-image:url(../images/BOEmpBanner.jpg); width:100%; height:66;">
                <table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                    <td align="left">
                        <asp:Label ID="lblCompleteName" runat="server" CssClass="empName">
                        </asp:Label>
                        
                        <br style="line-height:10px;"/>
                        <br style="line-height:3px;"/>
                        
                        <asp:Label ID="heading" runat="server" CssClass="empTitle">
                            Edit Profile
                        </asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
        <tr>
            <td class="tdPageLinkText" align="right">
                <%--<a class="pageLink" href="hospitalmain.aspx">Back</a>&nbsp;&nbsp;--%></td>
        </tr>
        <tr>
            <td class="tdspace">
            </td>
        </tr>
        <tr>
            <td>
                <img src="../images/spacer.gif" height="15" />
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="#404040">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <center>
                <table align="center" width="500" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <fieldset>
                                <legend>
                                    <font class="blackSubtext"><strong>Login Information&nbsp;</strong></font>
                                </legend>
                                
                                <table width="450" align="center" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="3">
                                            <img src="../images/spacer.gif" height="6" />
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label3" runat="server" Text="Emp ID" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempID" runat="server" CssClass="fieldbdr" Width="110px" Enabled="False" Height="18px"></asp:TextBox>
                                            </td>
                                    </tr>
                                   <%--<tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label17" runat="server" Text="Password" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempPassword" runat="server" CssClass="fieldBdr" Height="18px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label18" runat="server" Text="Re Type Password" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempRetypePassword" runat="server" CssClass="fieldBdr" Height="18px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"><img src="../images/spacer.gif" height="6" /></td>
                                    </tr>--%>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
                </center>
            </td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="10" /></td>
        </tr>
        <tr>
            <td>
                <center>
                <table align="center" width="500" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <fieldset>
                                <legend><font class="blackSubtext"><strong>Personal Information&nbsp;</strong></font></legend>
                                <table width="450" align="center" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="3"><img src="../images/spacer.gif" height="6" /></td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <asp:Label ID="Label13" runat="server" Text="Prefix" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:DropDownList ID="cmbempPrefix" runat="server" Width="60px" Height="18px">
                                                <asp:ListItem>Mr.</asp:ListItem>
                                                <asp:ListItem>Ms.</asp:ListItem>
                                                <asp:ListItem>Mrs.</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label5" runat="server" Text="First Name" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                            &nbsp;
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempFirstName" runat="server" CssClass="fieldbdr" Height="18px" Width="120px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label7" runat="server" Text="Last Name" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                            &nbsp;</td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempLastName" runat="server" CssClass="fieldbdr" Height="18px" Width="180px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="boProfileright">
                                            <asp:Label ID="Label9" runat="server" Text="Gender" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        
                                        <td class="boProfileleft">
                                            <asp:DropDownList ID="cmbempGender" runat="server" Width="80px" Height="18px">
                                                <asp:ListItem>Male</asp:ListItem>
                                                <asp:ListItem>Female</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="boProfileright" style="height: 25px">
                                            <asp:Label ID="Label19" runat="server" Text="DOB" Height="12px"></asp:Label></td>
                                        <td class="divide" style="height: 25px">
                                        </td>
                                        <td class="boProfileleft" style="height: 25px">
                                            <ew:CalendarPopup ID="CPDOB" runat="server" Width="140px">
                                                <selecteddatestyle backcolor="Yellow" font-names="Verdana,Helvetica,Tahoma,Arial"
                                                    font-size="XX-Small" forecolor="Black" />
                                                <weekendstyle backcolor="LightGray" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                                                    forecolor="Black" />
                                                <gototodaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                                                    forecolor="Black" />
                                                <dayheaderstyle backcolor="Orange" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                                                    forecolor="Black" />
                                                <monthheaderstyle backcolor="Yellow" font-names="Verdana,Helvetica,Tahoma,Arial"
                                                    font-size="XX-Small" forecolor="Black" />
                                                <weekdaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                                                    forecolor="Black" />
                                                <holidaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                                                    forecolor="Black" />
                                                <offmonthstyle backcolor="AntiqueWhite" font-names="Verdana,Helvetica,Tahoma,Arial"
                                                    font-size="XX-Small" forecolor="Gray" />
                                                <cleardatestyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                                                    forecolor="Black" />
                                                <todaydaystyle backcolor="LightGoldenrodYellow" font-names="Verdana,Helvetica,Tahoma,Arial"
                                                    font-size="XX-Small" forecolor="Black" />
                                            </ew:CalendarPopup>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label20" runat="server" Text="NIC" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempNIC" runat="server" CssClass="fieldbdr" Height="18px" Width="140px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"><img src="../images/spacer.gif" height="6" /></td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
                </center>
            </td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="10" /></td>
        </tr>
        <tr>
            <td>
                <center>
                <table align="center" width="500" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <fieldset>
                                <legend><font class="blackSubtext"><strong> Information&nbsp;</strong></font></legend>
                                <table width="450" align="center" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="3"><img src="../images/spacer.gif" height="6" /></td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label4" runat="server" Text="Address" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempAddress" runat="server" CssClass="fieldbdr" Height="18px" Width="240px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <asp:Label ID="Label6" runat="server" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempAddress2" runat="server" CssClass="fieldbdr" Height="18px" Width="240px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                           <font style="color:Red">*</font>&nbsp; <asp:Label ID="Label8" runat="server" Text="City" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempCity" runat="server" CssClass="fieldbdr" Height="18px" Width="140px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label11" runat="server" Text="State" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempState" runat="server" CssClass="fieldbdr" Height="18px" Width="140px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label15" runat="server" Text="Zip" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempZip" runat="server" CssClass="fieldbdr" Height="18px" Width="90px" Wrap="False"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label12" runat="server" Text="County" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:DropDownList ID="cmbempCountry" runat="server" Width="155px" Height="22px">
                                                <asp:ListItem>United States</asp:ListItem>
                                                <asp:ListItem>UK</asp:ListItem>
                                                <asp:ListItem>Pakistan</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label14" runat="server" Text="Phone #" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempPhoneNo" runat="server" CssClass="fieldbdr" Height="18px" Width="140px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label1" runat="server" Text="Cell #" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempCellNo" runat="server" CssClass="fieldbdr" Height="18px" Width="140px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label16" runat="server" Text="EMail" Height="12px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempEMail" runat="server" CssClass="fieldbdr" Height="18px" Width="200px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtempEMail"
                                                ErrorMessage="wrong format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"><img src="../images/spacer.gif" height="6" /></td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
                </center>
            </td>
        </tr>
       
<%--  <tr>
    <td>
	<fieldset>
	<legend><font class="blackSubtext"><strong>Personal Information&nbsp;</strong></font></legend>
	<table width="450" align="center" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td colspan="3"><img src="../images/spacer.gif" height="6" /></td>
  </tr>
  <tr>
            <td class="boProfileright">
                <asp:Label ID="Label10" runat="server" Text="Joining Date" Height="12px"></asp:Label></td>
            <td class="divide">
                &nbsp;</td>
            <td class="boProfileleft">
                <ew:CalendarPopup ID="CPempJoiningDate" runat="server" Width="140px">
                    <selecteddatestyle backcolor="Yellow" font-names="Verdana,Helvetica,Tahoma,Arial"
                        font-size="XX-Small" forecolor="Black" />
                    <weekendstyle backcolor="LightGray" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black" />
                    <gototodaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black" />
                    <dayheaderstyle backcolor="Orange" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black" />
                    <monthheaderstyle backcolor="Yellow" font-names="Verdana,Helvetica,Tahoma,Arial"
                        font-size="XX-Small" forecolor="Black" />
                    <weekdaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black" />
                    <holidaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black" />
                    <offmonthstyle backcolor="AntiqueWhite" font-names="Verdana,Helvetica,Tahoma,Arial"
                        font-size="XX-Small" forecolor="Gray" />
                    <cleardatestyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black" />
                    <todaydaystyle backcolor="LightGoldenrodYellow" font-names="Verdana,Helvetica,Tahoma,Arial"
                        font-size="XX-Small" forecolor="Black" />
                </ew:CalendarPopup>
            </td>
        </tr>
        <tr>
            <td class="boProfileright">
                <asp:Label ID="Label21" runat="server" Text="Date Time" Height="12px"></asp:Label></td>
            <td class="divide">
            </td>
            <td class="boProfileleft">
                <ew:CalendarPopup ID="CPDateTime" runat="server" Width="140px">
                    <selecteddatestyle backcolor="Yellow" font-names="Verdana,Helvetica,Tahoma,Arial"
                        font-size="XX-Small" forecolor="Black" />
                    <weekendstyle backcolor="LightGray" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black" />
                    <gototodaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black" />
                    <dayheaderstyle backcolor="Orange" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black" />
                    <monthheaderstyle backcolor="Yellow" font-names="Verdana,Helvetica,Tahoma,Arial"
                        font-size="XX-Small" forecolor="Black" />
                    <weekdaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black" />
                    <holidaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black" />
                    <offmonthstyle backcolor="AntiqueWhite" font-names="Verdana,Helvetica,Tahoma,Arial"
                        font-size="XX-Small" forecolor="Gray" />
                    <cleardatestyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black" />
                    <todaydaystyle backcolor="LightGoldenrodYellow" font-names="Verdana,Helvetica,Tahoma,Arial"
                        font-size="XX-Small" forecolor="Black" />
                </ew:CalendarPopup>
            </td>
        </tr>
  <tr>
    <td colspan="3"><img src="../images/spacer.gif" height="6" /></td>
  </tr>
</table>

	</fieldset>
	</td>
  </tr>
</table>
            </td>
        </tr>--%>
      <%-- <tr>
            <td>
               <asp:Table ID="Table1" runat="server" SkinId="tblView" >
                    <asp:TableRow runat="server" SkinId="headingRow" Height="18px">
                        <asp:TableCell runat="server">123</asp:TableCell>
                        <asp:TableCell runat="server">123</asp:TableCell>
                        <asp:TableCell runat="server">123</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server" SkinId="allRow">
                        <asp:TableCell runat="server">963</asp:TableCell>
                        <asp:TableCell runat="server">852</asp:TableCell>
                        <asp:TableCell runat="server">987</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </td>
        </tr>--%>
         <tr>
            <td><img src="../images/spacer.gif" height="3" /></td>
        </tr>
        <tr>
            <td class="btnCenter"><asp:Button ID="btnSave" runat="server" Text="Save" Width="61px" />&nbsp;<asp:Button
                    ID="btnCancel" runat="server" Text="Cancel" Width="61px" CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="5" /></td>
        </tr>
    </table>
</asp:Content>

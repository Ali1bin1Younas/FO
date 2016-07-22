<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false"
    CodeFile="employee.aspx.vb" Inherits="employee" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <script>
        function myFunction() {

            var x = document.getElementById("txtempID");

            document.getElementById("<%=htxtempID.ClientID %>").value = x.value;
         
        }
</script>
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="pageLink"><a href="employeemain.aspx">Back</a></td>
        </tr>
        <tr>
            <td class="tdspace">
            </td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="15px" /></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="False" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td align="center">
                <table align="center" width="500" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <fieldset>
                                <legend><font class="blackSubtext"><strong>Login Detail&nbsp;</strong></font></legend>
                                <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="3"><img src="../images/spacer.gif" height="6px" /></td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label3" runat="server" Text="Emp ID" Height="10px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <%--<asp:TextBox ID="txtempID" runat="server" CssClass="fieldBdr" Width="100px" Height="18px"></asp:TextBox>--%>
                                            
                                            <input type="text" id="txtempID" onblur="myFunction()" />
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label2" runat="server" Text="Login ID" Height="10px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempLoginID" runat="server" CssClass="fieldBdr" Height="18px"></asp:TextBox>
                                        </td>
                                            
                                    </tr>
                                    
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label17" runat="server" Text="Password" Height="10px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempPassword" runat="server" CssClass="fieldBdr" Height="18px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label18" runat="server" Text="Re Type Password" Height="10px"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempRetypePassword" runat="server" CssClass="fieldBdr" Height="18px"></asp:TextBox>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td colspan="3"><img src="../images/spacer.gif" height="6px" /></td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center"><img src="../images/spacer.gif" height="10px" /></td>
        </tr>
        <tr>
            <td align="center">
                <table align="center" width="500" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <fieldset>
	<legend><font class="blackSubtext"><strong>Official Detail&nbsp;</strong></font></legend>
	<table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td colspan="3"><img src="../images/spacer.gif" height="6px" /></td>
  </tr>
  <tr>
                <td class="boProfileRight">
                     <font style="color:Red">*</font>&nbsp; <asp:Label ID="Label10" runat="server" Text="Joining Date"></asp:Label></td>
                <td class="divide">
                    &nbsp;</td>
                <td class="boProfileleft">
                    <ew:CalendarPopup ID="CPempJoiningDate" runat="server">
                        <SelectedDateStyle BackColor="Yellow" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                            Font-Size="XX-Small" ForeColor="Black" />
                        <WeekendStyle BackColor="LightGray" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                            ForeColor="Black" />
                        <GoToTodayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                            ForeColor="Black" />
                        <DayHeaderStyle BackColor="Orange" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                            ForeColor="Black" />
                        <MonthHeaderStyle BackColor="Yellow" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                            Font-Size="XX-Small" ForeColor="Black" />
                        <WeekdayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                            ForeColor="Black" />
                        <HolidayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                            ForeColor="Black" />
                        <OffMonthStyle BackColor="AntiqueWhite" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                            Font-Size="XX-Small" ForeColor="Gray" />
                        <ClearDateStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                            ForeColor="Black" />
                        <TodayDayStyle BackColor="LightGoldenrodYellow" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                            Font-Size="XX-Small" ForeColor="Black" />
                    </ew:CalendarPopup>
                </td>
            </tr>
             <tr>
            <td class="boProfileright">
               <font style="color:Red">*</font>&nbsp; <asp:Label ID="lblDesignation" runat="server" Text="Designation" Height="12px"></asp:Label>
            </td>
            <td class="divide">
            </td>
            <td class="boProfileleft">
                <asp:TextBox ID="txtempDesignation" runat="server" CssClass="fieldBdr" Height="18px" Width="140px"></asp:TextBox>
            </td>
        </tr>
        
        
        <tr>
            <td class="boProfileright">
                <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label21" runat="server" Text="Department" Height="12px"></asp:Label>
            </td>
            <td class="divide"></td>
            <td class="boProfileleft">
                <asp:DropDownList ID="cmbDepartment" runat="server" Width="155px" Height="22px">
                    
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td class="boProfileright">
                <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label22" runat="server" Text="Company" Height="12px"></asp:Label>
            </td>
            <td class="divide"></td>
            <td class="boProfileleft">
                <asp:DropDownList ID="cmbcom" runat="server" Width="155px" Height="22px">
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td class="boProfileright">
                <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label23" runat="server" Text="Employee Type" Height="12px"></asp:Label>
            </td>
            <td class="divide"></td>
            <td class="boProfileleft">
                <asp:DropDownList ID="cmbempType" runat="server" Width="155px" Height="22px">
                </asp:DropDownList>
            </td>
        </tr>
  <tr>
    <td colspan="3"><img src="../images/spacer.gif" height="6px" /></td>
  </tr>
</table>

	</fieldset>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="10px" /></td>
        </tr>
        <tr>
            <td align="center">
                <table align="center" width="500" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                             <fieldset>
                                <legend><font class="blackSubtext"><strong>Personal Detail&nbsp;</strong></font></legend>
                                <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="3"><img src="../images/spacer.gif" height="6px" /></td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label9" runat="server" Text="Gender"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:DropDownList ID="cmbempGender" runat="server" Width="70px" Height="16px">
                                                <asp:ListItem>Male</asp:ListItem>
                                                <asp:ListItem>Female</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label13" runat="server" Text="Prefix"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:DropDownList ID="cmbempPrefix" runat="server" Width="50px" Height="16px">
                                                <asp:ListItem>Mr.</asp:ListItem>
                                                <asp:ListItem>Ms.</asp:ListItem>
                                                <asp:ListItem>Mrs.</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label5" runat="server" Text="First Name"></asp:Label></td>
                                        <td class="divide">
                                            &nbsp;
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempFirstName" runat="server" CssClass="fieldBdr" Height="18px" Width="120px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label7" runat="server" Text="Last Name"></asp:Label></td>
                                        <td class="divide">
                                            &nbsp;</td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempLastName" runat="server" CssClass="fieldBdr" Height="18px" Width="190px"></asp:TextBox>
                                            </td>
                                    </tr>
                                     <tr>
                                        <td class="boProfileright">
                                            <asp:Label ID="Label19" runat="server" Text="DOB"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <ew:CalendarPopup ID="CPDOB" runat="server" Width="110px">
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
                                            <asp:Label ID="Label20" runat="server" Text="NIC"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempNIC" runat="server" CssClass="fieldBdr" Height="18px" Width="140px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"><img src="../images/spacer.gif" height="6px" /></td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="10px" /></td>
        </tr>
        <tr>
            <td align="center">
            <table align="center" width="500" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td>
	    <fieldset>
                                <legend><font class="blackSubtext"><strong>Contact Detail&nbsp;</strong></font></legend>
                                <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="3"><img src="../images/spacer.gif" height="6px" /></td>
                                    </tr>
                                   
                                    <tr>
                                        <td class="boProfileright">
                                            <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempAddress" runat="server" CssClass="fieldBdr" Height="18px" Width="240px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <asp:Label ID="Label6" runat="server"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempAddress2" runat="server" CssClass="fieldBdr" Height="18px" Width="240px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label8" runat="server" Text="City"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempCity" runat="server" CssClass="fieldBdr" Height="18px" Width="140px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <asp:Label ID="Label11" runat="server" Text="State"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempState" runat="server" CssClass="fieldBdr" Height="18px" Width="140px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <asp:Label ID="Label15" runat="server" Text="Zip"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempZip" runat="server" CssClass="fieldBdr" Height="18px" Width="90px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label12" runat="server" Text="County"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:DropDownList ID="cmbempCountry" runat="server" Width="155px" Height="18px">
                                                <asp:ListItem>United States</asp:ListItem>
                                                <asp:ListItem>UK</asp:ListItem>
                                                <asp:ListItem>Pakistan</asp:ListItem>
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label14" runat="server" Text="Phone #"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempPhoneNo" runat="server" CssClass="fieldBdr" Height="18px" Width="140px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label1" runat="server" Text="Cell #"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempCellNo" runat="server" CssClass="fieldBdr" Height="18px" Width="140px"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td class="boProfileright">
                                            <font style="color:Red">*</font>&nbsp;<asp:Label ID="Label16" runat="server" Text="EMail"></asp:Label></td>
                                        <td class="divide">
                                        </td>
                                        <td class="boProfileleft">
                                            <asp:TextBox ID="txtempEMail" runat="server" CssClass="fieldBdr" Height="18px" Width="200px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtempEMail"
                                                ErrorMessage="wrong format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"><img src="../images/spacer.gif" height="6px" /></td>
                                    </tr>
                                </table>
                            </fieldset>
	</td>
  </tr>
</table>
            </td>
        </tr>
       
        <tr>
            <td><img src="../images/spacer.gif" height="3px" /></td>
        </tr>
        <tr>
            <td class="btnCenter" style="height: 26px">
                <br style="line-height: 3px;"/>
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="61px" />&nbsp;<asp:Button
                    ID="btnCancel" runat="server" Text="Cancel" Width="61px" CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td><img src="../images/spacer.gif" height="5px" /></td>
        </tr>
    </table>
    
    <asp:HiddenField ID="htxtempID" runat="server" />
</asp:Content>

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="bologin.aspx.vb" Inherits="bologin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Back Office Login Region</title>
<link rel="stylesheet" href="style/ATekStyle.css" type="text/css">
<link rel="stylesheet" href="style/BOStyle.css" type="text/css">
</head>
<body style="text-align:center;">
<center>
<form id="form2" runat="server">
  <table width="770" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td class="logindate"><%= system.DateTime.Now.ToLongDateString.ToString %> &nbsp;&nbsp;</td>
    </tr>
    <tr>
      <td><table width="770" border="0" cellspacing="0" cellpadding="0">
          <!---  LOGO+MENU TABLE ---->
          <tr>
            <td><img src="images/logoSITE.jpg" width="152" height="37" /></td>
            <td><img src="images/spacer.gif" width="3" height="1" /></td>
            <td class="tdalignRight"><img src="images/BOtopBar.jpg" width="614" height="37" /></td>
          </tr>
        </table>
        <!---  END of LOGO+MENU TABLE ----></td>
    </tr>
    <tr>
      <td style="padding:30px; text-align:left;"><img src="images/BOloginpageHeading.jpg" width="195" height="24" /></td>
    </tr>
    <tr>
      <td><table width="770" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><img src="images/spacer.gif" width="59" height="1" /></td>
            <td valign="top"><table width="311" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><img src="images/BOAdLoginTop.jpg" width="311" height="12" /></td>
                </tr>
                <tr>
                  <td bgcolor="#EFF0F2" align="center"><table width="230" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td colspan="3" class="alinLeft"><br style="line-height:10px;">
                          <img src="images/adminLoginHeading.jpg" width="153" height="16" /><br style="line-height:15px;">
                          <img src="images/spacer.gif" height="25"/></td>
                      </tr>
                      <tr>
                        <td class="loginpasswordText">Login</td>
                        <td class="divide">&nbsp;</td>
                        <td class="alinLeft" style="height: 22px"><asp:TextBox ID="txtboID" runat="server" cssclass="txtfieldStyle" ></asp:TextBox>
                        </td>
                      </tr>
                      <tr>
                        <td class="loginpasswordText">Password</td>
                        <td class="divide">&nbsp;</td>
                        <td class="alinLeft" ><asp:TextBox ID="txtboPassword" runat="server" CssClass="txtfieldStyle" TextMode="Password" Width="149px">test</asp:TextBox></td>
                      </tr>
                      <tr>
                        <td colspan="3" class="tdalignRight" ><a class="forgotpasswordLink" herf="">forgot Password</a>&nbsp;</td>
                      </tr>
                      <tr>
                        <td colspan="3" class="alinRight"><br style="line-height:10px;" />
                          <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="~/images/BOLoginButton.gif" Style="z-index: 100; left: 308px; position: notset; top: 329px" OnClick="btnLogin_Click" />&nbsp;</td>
                      </tr>
                      <tr>
                      <td colspan="3" height="20" class="alinRight"><asp:Label ID="lblMessage" runat="server" Width="180"></asp:Label></td>
                      </tr>
                    </table>
                    <span class="alinRight"></span> </td>
                </tr>
                <tr>
                  <td><img src="images/BOAdLoginBottom.jpg" width="311" height="12" /></td>
                </tr>
              </table></td>
            <td><img src="images/spacer.gif" width="30" height="1" /></td>
            <td><table width="311" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><img src="images/BOEmpLoginTop.jpg" width="311" height="12" /></td>
                </tr>
                <tr>
                  <td bgcolor="#EAEFF2" align="center"><table width="230" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td colspan="3" class="alinLeft"><br style="line-height:10px;">
                          <img src="images/empLoginHeading.jpg" width="198" height="16" /><br style="line-height:15px;">
                          <img src="images/spacer.gif" height="25"/></td>
                      </tr>
                      <tr>
                        <td class="loginpasswordText">Login</td>
                        <td class="divide">&nbsp;</td>
                        <td><asp:TextBox ID="txtUserID" runat="server" cssclass="txtfieldStyle" ></asp:TextBox></td>
                      </tr>
                      <tr>
                        <td class="loginpasswordText">Password</td>
                        <td class="divide">&nbsp;</td>
                        <td><asp:TextBox ID="txtPassword" runat="server" cssclass="txtfieldStyle" TextMode="Password" Width="149px">test</asp:TextBox></td>
                      </tr>
                      <tr>
                        <td colspan="3" class="tdalignRight"><a class="forgotpasswordLink" herf="">forgot Password</a>&nbsp;</td>
                      </tr>
                      <tr>
                        <td colspan="3" class="alinRight"><br style="line-height:10px;" />
                          <asp:ImageButton ID="btnEmpLogin" runat="server" ImageUrl="~/images/BOLoginButton.gif" Style="position: notset; top: 329px" />&nbsp;</td>
                      </tr>
                      <tr>
                      <td colspan="3" height="20" class="alinRight"><asp:Label ID="lblMsgClientLogin" runat="server" Width="180"></asp:Label></td>
                      </tr>
                    </table>
                    <span class="alinRight"></span></td>
                </tr>
                <tr>
                  <td><img src="images/BOEmpLoginBottom.jpg" width="311" height="12" /></td>
                </tr>
              </table></td>
            <td><img src="images/spacer.gif" width="59" height="1" /></td>
          </tr>
        </table>
        <p>&nbsp;</p></td>
    </tr>
    <tr>
      <td><table width="770" border="0" cellspacing="0" cellpadding="0">
          <!-- Body Main Table --->
          <tr>
            <td><img src="images/spacer.gif" width="1" height="1" /></td>
            <td><img src="images/spacer.gif" width="3" height="1" /><img src="images/spacer.gif" width="3" height="1" />
              <!-- End Right Table (body) --></td>
            <td><img src="images/spacer.gif" width="1" height="1" /></td>
          </tr>
        </table>
        <!-- END Body Main Table ---></td>
    </tr>
    <tr>
      <td><img src="images/spacer.gif" width="1" height="5" /></td>
    </tr>
    <tr>
      <td class="footerBackground" valign="top"><br style="line-height:5px;"/>
        <font class="copyright">Copyright &copy; 1995-2006 accesstek. All Rights Reserved.</font></td>
    </tr>
  </table>
</form>
</center>
</body>
</html>

<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="progressreport.aspx.vb" Inherits="dailyprogress" Title ="AccessTek [ Back Office - Admin ]" Theme="BoboLayout"  %>

<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls"
    TagPrefix="DBWC" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellspacing="0" cellpadding="0" width ="100%">
    <tr>
    <td class="heading">
        <asp:Label ID="Label1" runat="server" Font-Size="11pt" Visible="False"></asp:Label>
    </td>   
    <td class="searchTools">
        <asp:CheckBox ID="chkBaklog" runat="server" Font-Size="11px" ForeColor="Black" Text=" Backlog" Visible="false" />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="black" Font-Names="Verdana" Font-Size="11px" Text="Account"></asp:Label>
        <asp:DropDownList ID="ddlAccount" runat="server" DataTextField="dicAccountName" >
        </asp:DropDownList>
        
        <asp:DropDownList ID="ddlStatus" runat="server">
            <asp:ListItem>All Statuses</asp:ListItem>
            <asp:ListItem Value="0">New</asp:ListItem>
            <asp:ListItem Value="1">Processing</asp:ListItem>
            <asp:ListItem Value="2">Complete</asp:ListItem>
            <asp:ListItem Value="3">Gathered</asp:ListItem>
            <asp:ListItem Value="4">Uploaded</asp:ListItem>
            <asp:ListItem Value="6">--------------</asp:ListItem>
            <asp:ListItem Value="5">Outstanding</asp:ListItem>
        </asp:DropDownList>
        
        <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="black" Font-Names="Verdana" Font-Size="11px" Text="From: "></asp:Label>
        <ew:CalendarPopup ID="cpFrom" runat="server" SelectedDate="2006-12-13" VisibleDate="2006-12-13" CalendarLocation="Bottom" Width="103px" Text="To">
            <ClearDateStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" ForeColor="Black" />
        </ew:CalendarPopup>
        
        <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="black" Font-Names="Verdana" Font-Size="11px" Text="To: "></asp:Label>
        <ew:CalendarPopup ID="cpTo" runat="server" SelectedDate="2006-12-13" VisibleDate="2006-12-13" CalendarLocation="Bottom" Width="103px" Text="To">
            <ClearDateStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" ForeColor="Black" />
        </ew:CalendarPopup>
        <asp:Button ID="btnView" runat="server" Text="View" Width="60px" />
        </td>
    </tr>
    <tr>
        <td class ="tdspace" height="2px" colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2"><img src="../images/spacer.gif" height ="5" /></td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="630">
                <tr>
                    <td>
                        <fieldset>
                            <legend><font class="blackSubtext"><strong>Status&nbsp;</strong></font></legend>
                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="562" style="color:Black;">
                                <tr>
                                    <td colspan="4">
                                        <img height="6" src="../images/spacer.gif" /></td>
                                </tr>
                                <tr align="center">
                                    <td style="font-size: 8pt; vertical-align: top; font-family: Verdana">
                                        Not Available&nbsp; =&nbsp;
                                        <img height="13" src="../images/NotAvailable.gif" style="vertical-align: middle" width="13" /></td>
                                    <td style="font-size: 8pt; vertical-align: top; font-family: Verdana">
                                        Available&nbsp; =&nbsp;
                                        <img height="13" src="../images/Available.gif" style="vertical-align: middle" width="13" /></td>
                                    <td style="font-size: 8pt; vertical-align: top; font-family: Verdana">
                                        Processing&nbsp; =&nbsp;
                                        <img height="13" src="../images/Processing.gif" style="vertical-align: middle" width="13" /></td>
                                    <td style="font-size: 8pt; vertical-align: top; font-family: Verdana">
                                        Complete&nbsp; =&nbsp;
                                        <img height="13" src="../images/Complete.gif" style="vertical-align: middle" width="13" /></td>
                                    <td style="font-size: 8pt; vertical-align: top; font-family: Verdana">
                                        Error&nbsp; =&nbsp;
                                        <img height="13" src="../images/Error.gif" style="vertical-align: middle" width="13" /></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <img height="6" src="../images/spacer.gif" /></td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2"><img src="../images/spacer.gif" height ="10" /></td>
    </tr>
     
       
    <tr>
    <td colspan=2>
       <dbwc:hierargrid id="dgDailyWorkLoad" SkinId="gridviewSkin1" runat="server" loadcontrolmode="UserControl"
            templatedatamode="Table" AutoGenerateColumns="False" GridLines="None" ShowFooter="True">
                     
        <Columns>
            <asp:TemplateColumn HeaderText="#">
                <ItemStyle Width="63px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                <ItemTemplate>
                    <%#getCounter()%>
                </ItemTemplate>

                <HeaderStyle Width="63px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
            </asp:TemplateColumn>


            <asp:TemplateColumn HeaderText="Account Name">
            <ItemStyle Width="400px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
            <ItemTemplate>
                <%#Eval("dicAccountName")%>
            </ItemTemplate>
            <HeaderStyle Width="400px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
            </asp:TemplateColumn>


            <asp:TemplateColumn HeaderText="Dictators">
            <ItemStyle Width="100px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
            <ItemTemplate>
                <%#Eval("Dictators")%>
            </ItemTemplate>

            <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
            <EditItemTemplate>
                <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.drFirstName") %>'></asp:TextBox>
            </EditItemTemplate>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="OutStanding Dictations">
                <ItemStyle Width="167px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                <FooterStyle Width="167px" BackColor="#ECECEC" ForeColor="Black" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></FooterStyle>
                <FooterTemplate>
                    <%#Format(intTOutstandingDictations, "000")%>
                </FooterTemplate>
                <ItemTemplate>
                    <%#Eval("outStanding")%>
                </ItemTemplate>
                <HeaderStyle Width="167px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="OutStanding Minutes">
                <ItemStyle Width="218px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

                <FooterStyle Width="218px" BackColor="#ECECEC" Height="18px" ForeColor="Black" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></FooterStyle>
                <FooterTemplate>
                    <%#getmin(intTOutstandingMinutes)%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(intTOutstandingDictations, "000")%>]
                </FooterTemplate>
                <ItemTemplate>
                    <%#getmin(Eval("OutStandingMinute"))%>
                </ItemTemplate>

                <HeaderStyle Width="218px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
            </asp:TemplateColumn>


            <asp:TemplateColumn HeaderText="Total Dictations">
                <ItemStyle Width="218px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

                <FooterStyle Width="218px" BackColor="#ECECEC" Height="18px" ForeColor="Black" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></FooterStyle>
                <FooterTemplate>
                    <%#intTDictations%>
                </FooterTemplate>
                <ItemTemplate>
                    <%#Eval("totalDictations")%>
                </ItemTemplate>

                <HeaderStyle Width="218px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="Total Minutes">
                <ItemStyle Width="140px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

                <FooterStyle Width="140px" BackColor="#ECECEC" Height="18px" ForeColor="Black" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></FooterStyle>
                <FooterTemplate>
                    <%#getmin(intTMinutes)%>
                </FooterTemplate>
                <ItemTemplate>
                    <%#getmin(Eval("TotalMinutes"))%>
                </ItemTemplate>

                <HeaderStyle Width="140px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
            </asp:TemplateColumn>

</Columns>

        </dbwc:hierargrid>
        </td>
        </tr> 
    <%----------------------------------------------------------------------------%> 
    <tr>
    
    <td class="heading" colspan =2>
        &nbsp;<asp:Label ID="lblBacklog" runat="server" Font-Size="11pt" Text="Backlog" Visible="False"></asp:Label></td>
    </tr>
    
    <tr>
        <td colspan="2">
            <dbwc:hierargrid id="dgDailyWorkloadPending" SkinId="gridviewSkin1" runat="server" loadcontrolmode="UserControl"
            templatedatamode="Table" AutoGenerateColumns="False" GridLines="None" ShowFooter="True">
        
                <Columns>
                
                    <asp:TemplateColumn HeaderText="#">
                        <ItemStyle Width="40px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                        <ItemTemplate>
                            <%#getCounter1()%>
                        </ItemTemplate>

                        <HeaderStyle Width="40px" CssClass="gridHeadingCenter" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                    </asp:TemplateColumn>
                    
                    
                    <asp:TemplateColumn HeaderText="ID">
                        <ItemStyle Width="90px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                        <ItemTemplate>
                            <%#Eval("foId")%>-<%#Eval("drID")%>
                        </ItemTemplate>

                        <HeaderStyle Width="90px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
                    </asp:TemplateColumn>
                    
                    
                    <asp:TemplateColumn HeaderText="Name">
                        <ItemStyle Width="491px" CssClass="tdspacingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                        <ItemTemplate>
                            <%#Eval("drLastName") %>,&nbsp;<%#Eval("drFirstName")%> &nbsp;<%#Eval("drMiddleName") %>
                        </ItemTemplate>

                        <HeaderStyle Width="491px" CssClass="gridHeadingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.drFirstName") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateColumn>
                    
                    
                    <asp:TemplateColumn HeaderText="Total">
                        <ItemStyle Width="127px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                        <FooterStyle BackColor="#ECECEC" Width="127px" Height="18px" ForeColor="Black" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></FooterStyle>
                        <FooterTemplate>
                            <%#getmin(intTBMinutes)%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(intTBDictations, "000")%>]
                        </FooterTemplate>
                        <ItemTemplate>
                            <%#getmin(Eval("TotalMinutes"))%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("TotalDictation"), "000")%>]
                        </ItemTemplate>
                        <HeaderStyle Width="127px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
                    </asp:TemplateColumn>


                    <asp:TemplateColumn HeaderText="Outstanding">
                        <ItemStyle Width="180px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

                        <FooterStyle BackColor="#ECECEC" Width="180px" Height="18px" ForeColor="Black" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></FooterStyle>
                        <FooterTemplate>
                            <%#getmin(intTBMinutes)%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(intTBDictations, "000")%>]   
                        </FooterTemplate>
                        <ItemTemplate>
                            <%#getmin(Eval("TotalMinutes"))%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("TotalDictation"), "000")%>]
                        </ItemTemplate>

                        <HeaderStyle Width="180px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
                    </asp:TemplateColumn>

                </Columns>
            </DBWC:hierargrid>
        </td>
    </tr>
        
</table>

</asp:Content>


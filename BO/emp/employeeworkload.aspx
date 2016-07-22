<%@ Page Language="VB" MasterPageFile="~/EMP/masterPage.master" AutoEventWireup="false"
    CodeFile="employeeworkload.aspx.vb" Inherits="BO_employeeworkload" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>

<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls"
    TagPrefix="DBWC" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="background-image:url(../images/BOEmpBanner.jpg); width:980; height:66;">
                <table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblCompleteName" runat="server" CssClass="empName" Width="288px">
                            </asp:Label>
                            
                            <br style="line-height:10px;"/>
                            <br style="line-height:3px;"/>
                            
                            <asp:Label ID="heading" runat="server" CssClass="empTitle">
                                Employee Work Load
                            </asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr>
            <td class="searchTools">
                <%--<asp:DropDownList runat="Server" ID="ddlEmp" DataTextField="rolDescription" DataValueField="rolID"></asp:DropDownList>--%>
                <ew:CalendarPopup runat="server" ID="CPDate" CalendarLocation="Bottom" Culture="English (United Kingdom)">
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
                <ew:CalendarPopup runat="server" ID="CPTo" CalendarLocation="Bottom" 
                    Culture="English (United Kingdom)">
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
                <asp:Button runat="server" Text="Search" ID="btnSearch" Width="60px" />
                </td>
        </tr>
        <tr>
            <td>
                <DBWC:HierarGrid ID="EmpWorkload" SkinId="gridviewSkincolor" AutoGenerateColumns="False" runat="server"
                    LoadControlMode="UserControl" TemplateDataMode="Table" GridLines="None" ShowFooter="True">
                    <columns>
                        <asp:TemplateColumn HeaderText="#">
                            <ItemStyle Width="40px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></ItemStyle>
                            <ItemTemplate>
                                <%#iCounter%>
                            </ItemTemplate>

                            <HeaderStyle Width="40px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>
                        
                        
                        <asp:TemplateColumn HeaderText="Role">
                            <ItemStyle Width="270px" CssClass="tdspacingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></ItemStyle>
                            <ItemTemplate>
                                <%#Eval("rolID")%>:&nbsp;<%#Eval("rolDescription")%>
                            </ItemTemplate>

                            <HeaderStyle Width="270px" CssClass="gridHeadingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>
                        
                        
                        <asp:TemplateColumn HeaderText="Total">
                            <ItemStyle Width="130px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></ItemStyle>
                            <ItemTemplate>
                                <%#GF.GetMin((Eval("Minutes")))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("Dictations"), "000")%>]
                            </ItemTemplate>
                            
                            <FooterStyle BackColor="#ECECEC" Width="130px" Height="18px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                            <FooterTemplate>
                                <%#GF.GetMin(intPNOMDaily)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(intTDictationD, "000")%>]
                            </FooterTemplate>
                            <HeaderStyle Width="130px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>
                        
                        
                        <asp:TemplateColumn HeaderText="Done">
                            <ItemStyle Width="130px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></ItemStyle>

                            <FooterStyle BackColor="#ECECEC" Width="130px" Height="18px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                            <FooterTemplate>
                                <%#GF.GetMin(doneM)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(done, "000")%>]
                            </FooterTemplate>
                            <ItemTemplate>
                                <%#GF.GetMin((Eval("doneMinutes")))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("doneDictations"), "000")%>]
                            </ItemTemplate>

                            <HeaderStyle Width="130px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="Available">
                            <ItemStyle Width="130px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></ItemStyle>

                            <FooterStyle BackColor="#ECECEC" Width="130px" Height="18px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                            <FooterTemplate>
                                <%#GF.GetMin(availM)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(avail, "000")%>]
                            </FooterTemplate>
                            <ItemTemplate>
                                <%#GF.GetMin((Eval("availMinutes")))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("availDictations"), "000")%>]
                            </ItemTemplate>

                            <HeaderStyle Width="130px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="Outstanding">
                            <ItemStyle Width="130px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></ItemStyle>

                            <FooterStyle BackColor="#ECECEC" Width="130px" Height="18px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                            <FooterTemplate>
                                <%#GF.GetMin(outM)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(out, "000")%>]
                            </FooterTemplate>
                            <ItemTemplate>
                                <%#GF.GetMin((Eval("outMinutes")))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("outDictations"), "000")%>]
                            </ItemTemplate>

                            <HeaderStyle Width="130px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>
                        
                        <asp:TemplateColumn HeaderText="Templates">
                            <ItemStyle Width="271px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></ItemStyle>

                            <FooterStyle BackColor="#ECECEC" Width="271px" Height="18px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                            <ItemTemplate>
                                -
                            </ItemTemplate>

                            <HeaderStyle Width="271px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>
                        
                    </columns>
                </DBWC:HierarGrid>
            </td>
        </tr>
    </table>
</asp:Content>

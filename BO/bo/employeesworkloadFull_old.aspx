<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="employeesworkloadFull_old.aspx.vb" Inherits="BO_employeeworkloadFull_old" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>

<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="searchTools">
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
                     TemplateDataMode="Table" GridLines="None" ShowFooter="True">
                    <columns>
                        <asp:TemplateColumn HeaderText="#">
                            <ItemStyle Width="40px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></ItemStyle>
                            <ItemTemplate>
                                <%#iCounter%>
                            </ItemTemplate>

                            <HeaderStyle Width="40px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>
                        
                        
                        <asp:TemplateColumn HeaderText="Name">
                            <ItemStyle Width="370px" CssClass="tdspacingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></ItemStyle>
                            <ItemTemplate>
                                <%#Eval("empFirstName")%>&nbsp;<%#Eval("empLastName")%>
                            </ItemTemplate>

                            <HeaderStyle Width="370px" CssClass="gridHeadingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>
                        
                        
                        <asp:TemplateColumn HeaderText="Total">
                            <ItemStyle Width="170px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></ItemStyle>
                            <ItemTemplate>
                                <%#GF.GetMin((Eval("Minutes")))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("Dictations"), "000")%>]
                            </ItemTemplate>
                            
                            <%--<FooterStyle BackColor="#ECECEC" Width="170px" Height="18px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                            <FooterTemplate>
                                <%#GF.GetMin(intPNOMDaily)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(intTDictationD, "000")%>]
                            </FooterTemplate>--%>
                            <HeaderStyle Width="170px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>
                        
                        
                        <asp:TemplateColumn HeaderText="Done">
                            <ItemStyle Width="170px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></ItemStyle>

                            <%--<FooterStyle BackColor="#ECECEC" Width="170px" Height="18px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                            <FooterTemplate>
                                <%#GF.GetMin(doneM)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(done, "000")%>]
                            </FooterTemplate>--%>
                            <ItemTemplate>
                                <%#GF.GetMin((Eval("doneMinutes")))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("doneDictations"), "000")%>]
                            </ItemTemplate>

                            <HeaderStyle Width="170px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>


                        <asp:TemplateColumn HeaderText="Available">
                            <ItemStyle Width="170px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></ItemStyle>

                            <%--<FooterStyle BackColor="#ECECEC" Width="170px" Height="18px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                            <FooterTemplate>
                                <%#GF.GetMin(availM)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(avail, "000")%>]
                            </FooterTemplate>--%>
                            <ItemTemplate>
                                <%#GF.GetMin((Eval("availMinutes")))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("availDictations"), "000")%>]
                            </ItemTemplate>

                            <HeaderStyle Width="170px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>


                        <asp:TemplateColumn HeaderText="Outstanding">
                            <ItemStyle Width="170px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></ItemStyle>

                            <%--<FooterStyle BackColor="#ECECEC" Width="170px" Height="18px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                            <FooterTemplate>
                                <%#GF.GetMin(outM)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(out, "000")%>]
                            </FooterTemplate>--%>
                            <ItemTemplate>
                                <%#GF.GetMin((Eval("outMinutes")))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("outDictations"), "000")%>]
                            </ItemTemplate>

                            <HeaderStyle Width="170px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>
                        
                    </columns>
                </DBWC:HierarGrid>
            </td>
        </tr>
    </table>
</asp:Content>

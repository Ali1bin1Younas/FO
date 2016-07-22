<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="employeesworkloadFull.aspx.vb" Inherits="BO_employeeworkloadFull" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>

<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="searchTools">
                <input id="btnExpand" type="button" value="Expand" onclick="expand_all();" style="float:left;"/>

                <asp:Label ID="Label1" Text="Arrange By: " runat="server"></asp:Label>
                <asp:DropDownList runat="server" Width="180px" ID="ddlDateType">
                    <asp:ListItem Value="">Dictation Date</asp:ListItem>
                    <asp:ListItem Value="1" Selected="True">Workload Date</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
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
                        
                        
                        <asp:TemplateColumn HeaderText="Capacity">
                            <ItemStyle Width="34px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></ItemStyle>
                            <ItemTemplate>
                                <%#Eval("rolCapacity")%>
                            </ItemTemplate>

                            <HeaderStyle Width="34px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>


                        <asp:TemplateColumn HeaderText="Name">
                            <ItemStyle Width="670px" CssClass="tdspacingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></ItemStyle>
                            <ItemTemplate>
                                <%#CheckCapcity(Eval("rolCapacity"), GF.GetMin((Eval("Minutes"))), "0", Eval("empFirstName"), Eval("empLastName"))%>
                            </ItemTemplate>

                            <HeaderStyle Width="399px" CssClass="gridHeadingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="Specialty">
                            <HeaderStyle Width="166px" CssClass="gridHeadingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>

                        
                        <asp:TemplateColumn HeaderText="Total">
                            <ItemStyle Width="110px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></ItemStyle>
                            <ItemTemplate>
                                <%#CheckCapcity(Eval("rolCapacity"), GF.GetMin((Eval("Minutes"))), "1", "", "")%>&nbsp;&nbsp;[<%#Format(Eval("Dictations"), "000")%>]
                            </ItemTemplate>
                            
                            <%--<FooterStyle BackColor="#ECECEC" Width="170px" Height="18px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                            <FooterTemplate>
                                <%#GF.GetMin(intPNOMDaily)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(intTDictationD, "000")%>]
                            </FooterTemplate>--%>
                            <HeaderStyle Width="110px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>
                        
                        
                        <asp:TemplateColumn HeaderText="Done">
                            <ItemStyle Width="110px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></ItemStyle>

                            <%--<FooterStyle BackColor="#ECECEC" Width="170px" Height="18px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                            <FooterTemplate>
                                <%#GF.GetMin(doneM)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(done, "000")%>]
                            </FooterTemplate>--%>
                            <ItemTemplate>
                                <%#GF.GetMin((Eval("doneMinutes")))%>&nbsp;&nbsp;[<%#Format(Eval("doneDictations"), "000")%>]
                            </ItemTemplate>

                            <HeaderStyle Width="110px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>


                        <asp:TemplateColumn HeaderText="Available">
                            <ItemStyle Width="110px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></ItemStyle>
                            <ItemTemplate>
                               <%#check_availability(Eval("availMinutes"), Eval("outMinutes"))%>&nbsp;&nbsp;[<%#Format(Eval("availDictations"), "000")%>]
                            </ItemTemplate>

                            <HeaderStyle Width="110px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>


                        <asp:TemplateColumn HeaderText="Outstanding">
                            <ItemStyle Width="110px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></ItemStyle>

                            <%--<FooterStyle BackColor="#ECECEC" Width="170px" Height="18px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                            <FooterTemplate>
                                <%#GF.GetMin(outM)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(out, "000")%>]
                            </FooterTemplate>--%>
                            <ItemTemplate>
                                <%#GF.GetMin((Eval("outMinutes")))%>&nbsp;&nbsp;[<%#Format(Eval("outDictations"), "000")%>
                            </ItemTemplate>

                            <HeaderStyle Width="110px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>
                        

                        <asp:TemplateColumn HeaderText="% Done">
                            <ItemStyle Width="70px" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></ItemStyle>
                            <ItemTemplate>
                                <%#getPerDone(Eval("Minutes"), Eval("doneMinutes"))%>
                            </ItemTemplate>

                            <HeaderStyle Width="70px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>

                    </columns>
                </DBWC:HierarGrid>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        var objList = [];
        var is_expand = 0;
        function expand_all() {
            try {
                var tbl = document.getElementById("ctl00_ContentPlaceHolder1_EmpWorkload");
                var i = 1;
                for (i ; i < tbl.rows.length - 1; i++) {
                    var imglist = tbl.rows[i].cells.item(0).getElementsByTagName("img");
                    $.each(imglist, function (index, img) {
                        HierarGrid_toggleRow(img);
                    });
                }
                if (is_expand == 0) {
                    is_expand = 1;
                    $('#btnExpand').val('Collapse');
                } else {
                    is_expand = 0;
                    $('#btnExpand').val('Expand');
                }
            } catch (e) { alert(e.message); }
        }
    </script>
</asp:Content>

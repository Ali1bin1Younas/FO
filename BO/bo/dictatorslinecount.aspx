<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="dictatorslinecount.aspx.vb" Inherits="BO_dictatorlinecount" Title ="AccessTek [ Back Office - Admin ]" Theme="BoboLayout" %>
<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellspacing="0" cellpadding="0" width ="100%">
        <tr>
            <td class="searchTools">
                <asp:DropDownList ID="ddlDictator" runat="server" DataTextField="drName" DataValueField="drId" ></asp:DropDownList>
                <ew:calendarpopup id="cpFrom" runat="server" calendarlocation="Bottom" selecteddate="2006-12-13"
                    visibledate="2006-12-13" width="103px">
                <SelectedDateStyle BackColor="Yellow" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                    Font-Size="XX-Small" ForeColor="Black"  />
                <WeekendStyle BackColor="LightGray" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                    ForeColor="Black"  />
                <GoToTodayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                    ForeColor="Black"  />
                <DayHeaderStyle BackColor="Orange" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                    ForeColor="Black"  />
                <MonthHeaderStyle BackColor="Yellow" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                    Font-Size="XX-Small" ForeColor="Black"  />
                <WeekdayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                    ForeColor="Black"  />
                <HolidayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                    ForeColor="Black"  />
                <OffMonthStyle BackColor="AntiqueWhite" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                    Font-Size="XX-Small" ForeColor="Gray"  />
                <cleardatestyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                            forecolor="Black"  />
                <TodayDayStyle BackColor="LightGoldenrodYellow" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                    Font-Size="XX-Small" ForeColor="Black"  />
            </ew:calendarpopup>
                <ew:CalendarPopup ID="cpTo" runat="server" CalendarLocation="Bottom" SelectedDate="2006-12-13"
                    VisibleDate="2006-12-13" Width="103px">
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
                <asp:Label ID="lblChar" runat="server" Font-Bold="True" Text="Char/Line" Width="79px" Font-Names="verdana" Font-Size="8pt"></asp:Label>
                <asp:TextBox ID="txtChar" runat="server" Width="81px">65</asp:TextBox>
                <asp:Button ID="btnSubmit" runat="server" Text="View" width="60px"/>
                </td>
        </tr>
    <tr> <td>
    <DBWC:HierarGrid ID="gridDictator" runat="server" AutoGenerateColumns="False" GridLines="None"
        LoadControlMode="UserControl" ShowFooter="True" SkinID="gridviewSkin1" TemplateDataMode="Table">
        <Columns>
            <asp:TemplateColumn HeaderText="#">
                <ItemStyle Width="40px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                <ItemTemplate>
                    <%#RowCounter%>
                </ItemTemplate>

                <HeaderStyle Width="40px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="Dictator Name">
            <ItemStyle Width="376px" CssClass="tdspacingLeft" Wrap="False" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
            <ItemTemplate>
                <%#Eval("drName")%>
            </ItemTemplate>

            <HeaderStyle Width="250px" CssClass="gridHeadingLeft" Wrap="False" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="Dictations">
            <ItemStyle Width="100px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

            <FooterStyle Width="100px" height="18px" BackColor="#ECECEC" ForeColor="Black" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></FooterStyle>
            <FooterTemplate>
                <%#T_dictations %>
            </FooterTemplate>
            <ItemTemplate>
                <%#Eval("Dictations")%>
            </ItemTemplate>

            <HeaderStyle Width="100px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="Minutes">
            <ItemStyle Width="100px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

            <FooterStyle Width="100px" height="18px" BackColor="#ECECEC" ForeColor="Black" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></FooterStyle>
            <FooterTemplate>    
                <%#GF.GetMin((T_minutes))%>
            </FooterTemplate>
            <ItemTemplate>
                <%#GF.GetMin(Eval("Minutes"))%>
            </ItemTemplate>

            <HeaderStyle Width="100px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="Transcriptions">
            <ItemStyle Width="110px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

            <FooterStyle Width="110px" height="18px" BackColor="#ECECEC" ForeColor="Black" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></FooterStyle>
            <FooterTemplate>
                <%#T_transcription%>
            </FooterTemplate>
            <ItemTemplate>
                <%#Eval("Transcriptions")%>
            </ItemTemplate>

            <HeaderStyle Width="110px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="Lines">
            <ItemStyle Width="60px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

            <FooterStyle Width="60px" height="18px" BackColor="#ECECEC" ForeColor="Black" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></FooterStyle>
            <FooterTemplate>
                <%#T_lines%>        
            </FooterTemplate>
            <ItemTemplate>
                <%#Eval("Lines")%>        
            </ItemTemplate>

            <HeaderStyle Width="60px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="Lines / Minute">
            <ItemStyle Width="130px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
            <ItemTemplate>
                <%#Line_Per_Minutes(Eval("Minutes"), Eval("Lines"))%>  
            </ItemTemplate>

            <HeaderStyle Width="130px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="Lines / Transcription">
            <ItemStyle Width="170px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
            <ItemTemplate>       
                <%#Line_Per_Transcriptions(Eval("Transcriptions"), Eval("Lines"))%> 
            </ItemTemplate>

            <HeaderStyle Width="170px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
            </asp:TemplateColumn>
    </Columns>
   </DBWC:HierarGrid></td></tr>
    </table>
</asp:Content>


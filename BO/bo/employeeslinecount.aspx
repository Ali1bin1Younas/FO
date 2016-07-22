<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="employeeslinecount.aspx.vb" Inherits="BO_employeelinecount_check" Title ="AccessTek [ Back Office - Admin ]" Theme="BoboLayout" %>

<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellspacing="0" cellpadding="0" width ="100%">
        <tr>
            <td class="searchTools">
                <asp:DropDownList ID="ddlEmployee" runat="server" DataTextField="EmpName" DataValueField="empId"></asp:DropDownList>
                <asp:DropDownList ID="ddlEmployeeRole" runat="server" DataTextField="rolDescription" DataValueField="rolID"></asp:DropDownList>
                <ew:CalendarPopup ID="cpFrom" runat="server" SelectedDate="2006-12-13" VisibleDate="2006-12-13" CalendarLocation="Bottom" Width="103px">
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
                <cleardatestyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                            forecolor="Black" />
                <TodayDayStyle BackColor="LightGoldenrodYellow" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                    Font-Size="XX-Small" ForeColor="Black" />
            </ew:CalendarPopup>
                <ew:CalendarPopup ID="cpTo" runat="server" SelectedDate="2006-12-13" VisibleDate="2006-12-13" CalendarLocation="Bottom"
                        Width="103px">
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
                    <cleardatestyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                            forecolor="Black" />
                    <TodayDayStyle BackColor="LightGoldenrodYellow" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                        Font-Size="XX-Small" ForeColor="Black" />
                </ew:CalendarPopup>
                <asp:Label ID="lblChar" runat="server" Font-Bold="True" Text="Char/Line" Font-Names="verdana" Font-Size="8pt"></asp:Label>
                <asp:TextBox ID="txtChar" runat="server" Width="81px">65</asp:TextBox>
                <asp:Button ID="btnSubmit" runat="server" Text="View" Width="60px" />
            </td>
        </tr>

       <tr>
        <td>
    <DBWC:hierargrid id="gridEmployee" SkinId="gridviewSkin1" runat="server" loadcontrolmode="UserControl"
templatedatamode="Table" AutoGenerateColumns="False" GridLines="None" ShowFooter="True" Width="100%"> 
        <Columns>
            <asp:TemplateColumn HeaderText="#">
                <ItemStyle HorizontalAlign="Center" CssClass="" Width="30px" />
                <HeaderStyle HorizontalAlign="Center" CssClass="" Width="30px" />
                <ItemTemplate>
                    <%#getCounterDaily()%>
                </ItemTemplate>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="Employee Name">
                <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft"/>
                <HeaderStyle HorizontalAlign="Left" CssClass="tdspacingLeft" />
                <ItemTemplate>
                    <%#Eval("empFirst")%>,&nbsp;<%#Eval("empLast")%>
                </ItemTemplate>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="Dictations">
                <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft"/>
                <HeaderStyle HorizontalAlign="Left" CssClass="tdspacingLeft" />
                <FooterTemplate>
                    <%#T_dictations %>
                </FooterTemplate>
                <ItemTemplate>
                    <%#Eval("Dictations")%>    
                </ItemTemplate>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="Minutes">
                <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft"/>
                <HeaderStyle HorizontalAlign="Left" CssClass="tdspacingLeft" />
                <FooterTemplate>
                    <%#getmin(T_minutes)%>
                </FooterTemplate>
                <ItemTemplate>
                    <%#getmin(Eval("Minutes"))%>
                </ItemTemplate>
            </asp:TemplateColumn>
      
      
            <asp:TemplateColumn HeaderText="Transcriptions">
                <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft"/>
                <HeaderStyle HorizontalAlign="Left" CssClass="tdspacingLeft" />
                <FooterTemplate>
                    <%#T_transcription%>
                </FooterTemplate>
                <ItemTemplate>
                    <%#Eval("Transcriptions")%>           
                </ItemTemplate>
            </asp:TemplateColumn>
        
        
            <asp:TemplateColumn HeaderText="Lines">
                <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft"/>
                <HeaderStyle HorizontalAlign="Left" CssClass="tdspacingLeft" />
                <FooterTemplate>
                    <%#T_lines%>
                </FooterTemplate>
                <ItemTemplate>
                    <%#Eval("Lines")%>
                </ItemTemplate>
            </asp:TemplateColumn>
            
            
           <asp:TemplateColumn HeaderText="Line Per Minutes">
               <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft"/>
                <HeaderStyle HorizontalAlign="Left" CssClass="tdspacingLeft" />
               <ItemTemplate>
                <%#Line_Per_Minutes(Eval("Minutes"), Eval("Lines"))%>
               </ItemTemplate>
           </asp:TemplateColumn>
                
                
           <asp:TemplateColumn HeaderText="Line Per Transcriptions">
                <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft"/>
                <HeaderStyle HorizontalAlign="Left" CssClass="tdspacingLeft" /> 
                <ItemTemplate>
                    <%#Line_Per_Transcriptions(Eval("Transcriptions"), Eval("Lines"))%>
                </ItemTemplate>
           </asp:TemplateColumn>
        
        </Columns>


</DBWC:hierargrid></td>
        </tr>
        <%--<tr>
            <td class="tdspace" colspan="2">
            </td>
        </tr>--%>
        <tr>
            <td>
                <img src="../images/spacer.gif" height="10" /></td>
        </tr>
    </table>
</asp:Content>

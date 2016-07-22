<%@ Page Language="VB" MasterPageFile ="~/BO/master.master" AutoEventWireup="false" CodeFile="teamupdate.aspx.vb" Inherits="teamupdate" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <table width="770" border="0" cellspacing="0" cellpadding="0">
   <tr>
    <td colspan="4"><img src="../images/addEmployee.jpg" alt="" width="770" height="66" /></td>
    </tr>
    <tr>
    <td class="tdPageLinkText" align="right" colspan="4" style="height: 13px">&nbsp;&nbsp;&nbsp;<a class="pageLink"
            href="teammain.aspx">Back</a>&nbsp;&nbsp;</td>
    </tr>
    <tr><td class="tdspace" colspan="4"></td></tr>
    <tr>
        <td class="profile" colspan="4" style="width: 770px; height: 30px;">
        </td>
    </tr>
            <tr>
                <td class="profileleft" style="height: 30px">
                    <asp:Label ID="Label5" runat="server" Text="Team Name" Width="133px"></asp:Label></td>
                <td class="divide" style="height: 30px">
                    &nbsp;
                </td>
                <td class="profileright" style="height: 30px">
                    <asp:TextBox ID="txtTeamName" runat="server" CssClass="bee1" Enabled="False"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="profileleft">
                    <asp:Label ID="Label19" runat="server" Text="Date Created" Width="133px"></asp:Label></td>
                <td class="divide">
                </td>
                <td class="profileright">
                    <ew:CalendarPopup ID="CPTeamCreated" runat="server">
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
                <td class="profileleft" style="height: 30px" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr><td class="tdspace" colspan="3"></td></tr>
            <tr>
                <td class="btnCenter" colspan="3" style="height: 26px"><br style="line-height:3px;">
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="61px" />&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="61px"  CausesValidation ="false"/>
                </td>
            </tr>
    <tr>
        <td class="profileright" colspan="3">
        </td>
    </tr>
        </table>
</asp:Content>
   
<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="datelinecount.aspx.vb" Inherits="BO_datelinecount" Theme="default" %>
<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td><asp:Label runat="Server" Visible="False" ID="lblError" CssClass="loginpasswordText"></asp:Label></td>
    </tr>
    <tr>
        <td class="searchTools">
            <asp:DropDownList runat="Server" ID="ddlDictator"></asp:DropDownList>
            <ew:CalendarPopup runat="Server" ID="cpFrom" Text="From:" CssClass="loginpasswordText">
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
            <ew:CalendarPopup runat="Server" ID="cpTo" Text="To:" CssClass="loginpasswordText">
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
&nbsp;<asp:Label runat="Server"  ID="lblInfo" Text="Char/Line" CssClass="loginpasswordText"></asp:Label>
<asp:TextBox runat="server" ID="txtLine" Text="65"></asp:TextBox>
<asp:Button runat="Server"  Id="btnView" Text="View" Width="60px" />
</td>
</tr>
<tr>
<td>
<DBWC:HierarGrid runat="Server" SkinId="GridView" ID="GridDate" AutoGenerateColumns="False" 
TemplateDataMode="Table" LoadControlMode="UserControl" ShowFooter="true">
    <Columns>
        <asp:TemplateColumn HeaderText="#">
            <ItemStyle width="45px" horizontalalign="Center" />
            <ItemTemplate>
                <%#rCount %>
            </ItemTemplate>
            <HeaderStyle width="45px" horizontalalign="Center" />
        </asp:TemplateColumn>
        
        
        <asp:TemplateColumn HeaderText="Date">
            <ItemStyle width="255px" horizontalalign="Center" />
            <ItemTemplate>
                <%#Format(Eval("dicDate"), "dd/MM/yyyy")%>
            </ItemTemplate>
            <HeaderStyle width="255px" horizontalalign="Center" />
        </asp:TemplateColumn>
        
        
        <asp:TemplateColumn HeaderText="Dictations">
        <ItemStyle width="120px" horizontalalign="Center" />
        <FooterStyle width="120px" horizontalalign="Center"/>
       <FooterTemplate>
        <%#tDictations%>
        
</FooterTemplate>
        <ItemTemplate>
        <%#Eval("TotalDic")%>
        
</ItemTemplate>
        <HeaderStyle width="120px" horizontalalign="Center" />
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="Minutes">
         <ItemStyle width="120px" horizontalalign="Center" />
        <FooterStyle width="120px" horizontalalign="Center"/>
        <FooterTemplate>
        <%#GF.GetMin(tMinutes)%>
        
</FooterTemplate>
        <ItemTemplate>
        <%#GF.GetMin(Eval("dicLength"))%>
        
</ItemTemplate>
        <HeaderStyle width="120px" horizontalalign="Center" />
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="Transcriptions">
        <ItemStyle width="120px" horizontalalign="Center" />
        <FooterStyle width="120px" horizontalalign="Center" />
        <FooterTemplate>
       <%#tTranscriptions%>
        
</FooterTemplate>
        <ItemTemplate>
        <%#Eval("TotalTra")%>     
        
</ItemTemplate>
        <HeaderStyle width="120px" horizontalalign="Center" />
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="Lines">
        <ItemStyle width="120px" horizontalalign="Center" />
        <FooterStyle width="120px" horizontalalign="Center" />
        <FooterTemplate>
        <%#tLines%>
        
</FooterTemplate>
        <ItemTemplate>
        <%#Eval("Lines") %>
        
</ItemTemplate>
        <HeaderStyle width="120px" horizontalalign="Center" />
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="Lines / Minute">
        <ItemStyle width="150px" horizontalalign="Center" />
        <FooterStyle width="150px" horizontalalign="Center" />
        <FooterTemplate>
        <%#Line_Per_Minutes(tMinutes, tLines)%>
        
</FooterTemplate>
        <ItemTemplate>
        <%#Line_Per_Minutes(Eval("dicLength"), Eval("Lines"))%>
        
</ItemTemplate>
        <HeaderStyle width="150px" horizontalalign="Center" />
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="Lines / Transcription">
        <ItemStyle width="160px" horizontalalign="Center" />
        <FooterStyle width="160px" horizontalalign="Center" />
        <FooterTemplate>
        <%#Lines_Per_Transcriptions(tTranscriptions,tLines)%>
        
</FooterTemplate>
        <ItemTemplate>
        <%#Lines_Per_Transcriptions(Eval("TotalTra"), Eval("Lines"))%>
        
</ItemTemplate>
        <HeaderStyle width="160px" horizontalalign="Center" />
        </asp:TemplateColumn>
        </Columns>
</DBWC:HierarGrid>
</td>
</tr>
</table>
</asp:Content>


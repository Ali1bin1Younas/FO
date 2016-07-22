<%@ Page Language="VB" MasterPageFile="~/Emp/MasterPage.master"  AutoEventWireup="false" CodeFile="workhistory.aspx.vb" Inherits="BO_workhistory" Title =" AccessTek [ Back Office - Employee ]" Theme ="default" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table width="100%" cellpadding="0" cellspacing="0" border ="0">
       <tr>
        <td style="background-image:url(../images/BOEmpBanner.jpg); width:980; height:66;">
            <table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblCompleteName" runat="server" CssClass="empName">
                        </asp:Label>
                        
                        <br style="line-height:10px;"/>
                        <br style="line-height:3px;"/>
                        
                        <asp:Label ID="heading" runat="server" CssClass="empTitle">
                            Work History
                        </asp:Label>
                    </td>
                </tr>
         </table></td>
    </tr>
        <tr>
            <td width="100%" height="35" valign="middle" align="right">
               
                <ew:CalendarPopup ID="cpFrom" runat="server" SelectedDate="2006-12-13"
                    VisibleDate="2006-12-13" CalendarLocation="Bottom" Width="103px" Text="From">
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
             
             <ew:CalendarPopup ID="cpTo" runat="server" SelectedDate="2006-12-13"
            VisibleDate="2006-12-13" CalendarLocation="Bottom" Width="103px" Text="To">
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
                <ClearDateStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" ForeColor="Black" />
                 <TodayDayStyle BackColor="LightGoldenrodYellow" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                     Font-Size="XX-Small" ForeColor="Black" />
                 </ew:CalendarPopup>
                 
                 <asp:Button ID="btnSubmit" runat="server" Text="View" Width="64px" />&nbsp;
                </td>
        </tr>
        
    </table>
    <asp:GridView ID="GridView1" SkinId="gridviewSkin" runat="server" GridLines ="None" AutoGenerateColumns="False" ShowFooter="True">
        <Columns>
        
            <asp:TemplateField HeaderText="#" HeaderStyle-CssClass ="gridHeadingCenter">
                <ItemTemplate>
                    <%#getCounter()%>
                </ItemTemplate>
                
                <ItemStyle Width="50px" HorizontalAlign="Center" />
                <HeaderStyle Width="50px" />
            </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText="MT" HeaderStyle-CssClass ="gridHeadingCenter">
                <ItemTemplate>
                    <%#Format(Eval("dicDate"), "dd-MM-yyyy")%>
                </ItemTemplate>
                
                <ItemStyle Width="165px" HorizontalAlign="Center" />
                <HeaderStyle Width="165px" />
            </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText="MT" HeaderStyle-CssClass ="gridHeadingCenter">
                <ItemTemplate>
                    <%#IIf(Eval("MT_doneMinutes") = 0, "-", getmin(Eval("MT_doneMinutes")))%> &nbsp;&nbsp;&nbsp;&nbsp;<%#IIf(Eval("MT_doneMinutes") <> 0, Format(Eval("MT_doneDictations"), "[000]"), "")%>
                </ItemTemplate>
                
                <FooterTemplate>
                    <%#getmin(intT_MT_min)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(intT_MT_dic, "000")%>]
                </FooterTemplate>
                
                <FooterStyle Width="165px" BackColor="#ECECEC" Height ="18" Font-Bold ="true" HorizontalAlign ="center" />
                <ItemStyle Width="165px" HorizontalAlign="Center" />
                <HeaderStyle Width="165px" />
            </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText="QC" HeaderStyle-CssClass ="gridHeadingCenter">
                <ItemTemplate>
                    <%#IIf(Eval("QC_doneMinutes") = 0, "-", getmin(Eval("QC_doneMinutes")))%>&nbsp;&nbsp;&nbsp;&nbsp;<%#IIf(Eval("QC_doneMinutes") = 0, "", Format(Eval("QC_doneDictations"), "[000]"))%>
                </ItemTemplate>
                
                <FooterTemplate>
                    <%#getmin(intT_QC_min)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(intT_QC_dic, "000")%>]
                </FooterTemplate>
                
                <FooterStyle Width="230" BackColor="#ECECEC" Height ="18" Font-Bold ="true" HorizontalAlign ="center" />
                <ItemStyle Width="230px" HorizontalAlign="Center" />
                <HeaderStyle Width="230px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="PR" HeaderStyle-CssClass ="gridHeadingCenter">
                <ItemTemplate>
                    <%#IIf(Eval("PR_doneMinutes") = 0, "-", getmin(Eval("PR_doneMinutes")))%>&nbsp;&nbsp;&nbsp;&nbsp;<%#IIf(Eval("PR_doneMinutes") = 0, "", Format(Eval("PR_doneDictations"), "[000]"))%>
                </ItemTemplate>
                
                <FooterTemplate>
                    <%#getmin(intT_PR_min)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(intT_PR_dic, "000")%>]
                </FooterTemplate>
                
                <FooterStyle Width="230" BackColor="#ECECEC" Height ="18" Font-Bold ="true" HorizontalAlign ="center" />
                <ItemStyle Width="230px" HorizontalAlign="Center" />
                <HeaderStyle Width="230px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="FR" HeaderStyle-CssClass ="gridHeadingCenter">
                <ItemTemplate>
                    <%#IIf(Eval("FR_doneMinutes") = 0, "-", getmin(Eval("FR_doneMinutes")))%>&nbsp;&nbsp;&nbsp;&nbsp;<%#IIf(Eval("FR_doneMinutes") = 0, "", Format(Eval("FR_doneDictations"), "[000]"))%>
                </ItemTemplate>
                
                <FooterTemplate>
                    <%#getmin(intT_FR_min)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(intT_FR_dic, "000")%>]
                </FooterTemplate>
                
                <FooterStyle Width="230" BackColor="#ECECEC" Height ="18" Font-Bold ="true" HorizontalAlign ="center" />
                <ItemStyle Width="230px" HorizontalAlign="Center" />
                <HeaderStyle Width="230px" />
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="Total" HeaderStyle-CssClass ="gridHeadingCenter">
                <ItemTemplate>
                    <%#IIf(Eval("Minutes") = 0, "-", getmin(Eval("Minutes")))%>&nbsp;&nbsp;&nbsp;&nbsp;<%#IIf(Eval("Minutes") = 0, "", Format(Eval("Dictations"), "[000]"))%>
                </ItemTemplate>
                
                <FooterTemplate>
                    <%#getmin(intT_min)%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(intT_dic, "000")%>]
                </FooterTemplate>
                
                <FooterStyle Width="230" BackColor="#ECECEC" Height ="18" Font-Bold ="true" HorizontalAlign ="center" />
                <ItemStyle Width="230px" HorizontalAlign="Center" />
                <HeaderStyle Width="230px" />
            </asp:TemplateField>
            
            
        </Columns>
    </asp:GridView>
    
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="dictationassignment.aspx.vb" Inherits="dictationassignment" Title ="AccessTek [ Back Office - Admin ]" Theme ="default"  %>

<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls"
    TagPrefix="DBWC" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
<!--

function IMG1_onclick() {

}
// -->
</script>
   
<table border="0" cellspacing="0" cellpadding="0" width ="100%">
      
    <tr>
        <td align="right" class="searchTools">
            <asp:CheckBox ID="chkBacklog" runat="server" Font-Size="11px" ForeColor="Black" Text=" Backlog" />
            
            <asp:DropDownList ID="ddlEmployeeRoll" runat="server" AutoPostBack="True" Width="102px">
                <asp:ListItem Value="1">MT</asp:ListItem>
                <asp:ListItem Value="2">QC</asp:ListItem>
                <asp:ListItem Value="4" Selected="true">PR</asp:ListItem>
                <asp:ListItem Value="5">FR</asp:ListItem>
            </asp:DropDownList>&nbsp;
            
            <asp:DropDownList ID="cmbMainPR" runat="server" Width="137px"></asp:DropDownList>&nbsp;
            <ew:CalendarPopup ID="CPMain" runat="server" CalendarLocation="Bottom" Width="119px" UpperBoundDate="9999-12-31">
                <ClearDateStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" ForeColor="Black" />
            </ew:CalendarPopup>
            
            <asp:Button ID="btnSearch" runat="server" Text="View" Width="60px" />
        </td>
        
    </tr>
    
    <tr>
    <td>
        <dbwc:hierargrid id="dgPRMain" SkinId="GridView" runat="server" loadcontrolmode="UserControl" templatedatamode="Table" AutoGenerateColumns="False" GridLines="None" ShowFooter="true">
             <Columns>
                <asp:TemplateColumn HeaderText="#">
                    <ItemStyle Width="55px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                    <ItemTemplate>
                    <%#Counter%>
                    </ItemTemplate>
                    <HeaderStyle Width="55px" CssClass="gridHeadingCenter" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                </asp:TemplateColumn>
                
                
                <asp:BoundColumn DataField="empID" HeaderText="ID">
                    <ItemStyle Width="110px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                    <HeaderStyle Width="110px" CssClass="gridHeadingCenter" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
                </asp:BoundColumn>
                
                
                <asp:TemplateColumn HeaderText="Name">
                    <ItemStyle Width="538px" HorizontalAlign="Left" CssClass="tdspacingLeft" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                    <ItemTemplate>
                        <%#getEmpFullName(Eval("empID"))%>
                    </ItemTemplate>
                    <HeaderStyle Width="538px" CssClass="gridHeadingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                </asp:TemplateColumn>
                
                
                <asp:TemplateColumn HeaderText="Total Work Load">
                <ItemStyle Width="194px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                <FooterStyle BackColor="#ECECEC" height="18" Width="193px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></FooterStyle>
                <FooterTemplate>
                <%#getmin(GrandMinutes)%>      [<%#Format(GrandDictation, "000")%>]
                </FooterTemplate>
                <ItemTemplate>
                <%#getmin(Eval("dicLength")) %>     [<%#Format(Eval("Dictations"), "000")%>]
                </ItemTemplate>
                <HeaderStyle Width="193px" CssClass="gridHeadingCenter" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Outstanding">
                <ItemStyle Width="194px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                <FooterStyle BackColor="#ECECEC" height="18" Width="194px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></FooterStyle>
                <FooterTemplate>
                <%#getmin(Me.GrandOutMinutes)%>      [<%#Format(Me.GrandOutDictation, "000")%>]
                </FooterTemplate>
                <ItemTemplate>
                <%#getmin(Eval("OutdicLength")) %>     [<%#Format(Eval("OutDictations"), "000")%>]
                </ItemTemplate>
                <HeaderStyle Width="194px" CssClass="gridHeadingCenter" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                </asp:TemplateColumn>
                </Columns>
                        </dbwc:hierargrid></td>
                        </tr> 
                        <tr><td style="height: 27px">&nbsp;&nbsp;<asp:Label ID="lblBacklog" runat="server" CssClass="heading" Font-Bold="True" Font-Size="11pt" Text="Backlog" Visible="False"></asp:Label></td></tr>
                        <tr>
                        <%--backlog grid--%>
                            <td>
                                <dbwc:hierargrid id="dgMainBacklog" SkinId="GridView" runat="server" loadcontrolmode="UserControl"
                            templatedatamode="Table" AutoGenerateColumns="False" GridLines="None" ShowFooter="true">
                                   
                                    <Columns>
                <asp:BoundColumn DataField="empID" HeaderText="ID">
                <ItemStyle Width="125px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

                <HeaderStyle Width="125px" CssClass="gridHeadingCenter" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderText="Name">
                <ItemStyle Width="445px" HorizontalAlign="Left" CssClass="tdspacingLeft" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                <ItemTemplate>
                <%#getEmpFullName(Eval("empID"))%>
                </ItemTemplate>
                <HeaderStyle Width="445px" CssClass="gridHeadingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Total Work Load">
                <ItemStyle Width="195px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                <FooterStyle BackColor="#ECECEC" height="18" Width="195px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="false" VerticalAlign="Middle"></FooterStyle>
                <FooterTemplate>
                <%#getmin(me.GrandMinutes)%>      [<%#Format(me.GrandDictation, "000")%>]
                </FooterTemplate>    
                <ItemTemplate>
                <%#getmin(Eval("dicLength")) %>     [<%#Format(Eval("Dictations"), "000")%>]
                </ItemTemplate>
                <HeaderStyle Width="195px" CssClass="gridHeadingCenter" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Outstanding">
                <ItemStyle Width="194px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                <FooterStyle BackColor="#ECECEC" height="18" Width="194px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="false" VerticalAlign="Middle"></FooterStyle>
                <FooterTemplate>
                <%#getmin(Me.GrandOutMinutes)%>      [<%#Format(Me.GrandOutDictation, "000")%>]
                </FooterTemplate>  
                <ItemTemplate>
                <%#getmin(Eval("OutdicLength")) %>   [<%#Format(Eval("OutDictations"), "000")%>]
                </ItemTemplate>
                <HeaderStyle Width="194px" CssClass="gridHeadingCenter" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                </asp:TemplateColumn>
</Columns>
                </dbwc:hierargrid></td>
        </tr>
        <%--<tr><td class="tdspace" colspan="2"></td></tr>
<tr><td colspan="2"><img src="../images/spacer.gif" height="10" /></td></tr>--%> 
</table>

</asp:Content>


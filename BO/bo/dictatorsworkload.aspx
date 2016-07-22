<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false"
    CodeFile="dictatorsworkload.aspx.vb" Inherits="dictatorworkload" Title ="AccessTek [ Back Office - Admin ]" Theme="BoboLayout" %>
<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
           <td>
                <asp:Label ID="Label1" runat="server" Font-Size="11pt" Visible="False"></asp:Label>
           </td>
            <td class="searchTools">
                <ew:CalendarPopup ID="cpFrom" runat="server" SelectedDate="2006-12-13" VisibleDate="2006-12-13" CalendarLocation="Bottom" Width="103px" Text="From">
                    <selecteddatestyle backcolor="Yellow" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" forecolor="Black"></selecteddatestyle>
                    <weekendstyle backcolor="LightGray" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" forecolor="Black"></weekendstyle>
                    <gototodaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" forecolor="Black"></gototodaystyle>
                    <dayheaderstyle backcolor="Orange" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" forecolor="Black" />
                    <monthheaderstyle backcolor="Yellow" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" forecolor="Black"></monthheaderstyle>
                    <weekdaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" forecolor="Black"></weekdaystyle>
                    <holidaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" forecolor="Black"></holidaystyle>
                    <offmonthstyle backcolor="AntiqueWhite" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" forecolor="Gray"></offmonthstyle>
                
                    <cleardatestyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" forecolor="Black" />
                    <todaydaystyle backcolor="LightGoldenrodYellow" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" forecolor="Black" />
                </ew:CalendarPopup>
                <ew:CalendarPopup ID="cpTo" runat="server" SelectedDate="2006-12-13" VisibleDate="2006-12-13" CalendarLocation="Bottom"
                        Width="103px" Text="To">
                    <selecteddatestyle backcolor="Yellow" font-names="Verdana,Helvetica,Tahoma,Arial"
                        font-size="XX-Small" forecolor="Black"></selecteddatestyle>
                    <weekendstyle backcolor="LightGray" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black"></weekendstyle>
                    <gototodaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black"></gototodaystyle>
                    <dayheaderstyle backcolor="Orange" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black" />
                    <monthheaderstyle backcolor="Yellow" font-names="Verdana,Helvetica,Tahoma,Arial"
                        font-size="XX-Small" forecolor="Black"></monthheaderstyle>
                    <weekdaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black"></weekdaystyle>
                    <holidaystyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"
                        forecolor="Black"></holidaystyle>
                    <offmonthstyle backcolor="AntiqueWhite" font-names="Verdana,Helvetica,Tahoma,Arial"
                        font-size="XX-Small" forecolor="Gray"></offmonthstyle>
                   
                    <cleardatestyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" forecolor="Black" />
                    <todaydaystyle backcolor="LightGoldenrodYellow" font-names="Verdana,Helvetica,Tahoma,Arial"
                        font-size="XX-Small" forecolor="Black" />
                    
                </ew:CalendarPopup>
                <asp:Button ID="btnView" runat="server" Text="View" Width="60px" />
            </td>
        </tr>
<tr>
            <td colspan="2">
<DBWC:hierargrid id="dgDailyWorkLoad" SkinId="gridviewSkin1" runat="server" loadcontrolmode="UserControl"
templatedatamode="Table" AutoGenerateColumns="False" GridLines="None" ShowFooter="True">
    <FooterStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
        Font-Underline="False" />
 <columns>
 
    <asp:TemplateColumn HeaderText="#">
        <ItemStyle Width="40px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
        <ItemTemplate>
            <%#getCounter()%>
        </ItemTemplate>
        <HeaderStyle Width="40px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
        <EditItemTemplate>
            <asp:TextBox runat="server"></asp:TextBox>
        </EditItemTemplate>
        
    </asp:TemplateColumn>
    
    
    <asp:BoundColumn DataField="drCID" HeaderText="ID">
        <ItemStyle Width="90px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

        <FooterStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></FooterStyle>

        <HeaderStyle Width="90px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
    </asp:BoundColumn>
    
    
    <asp:TemplateColumn HeaderText="Name">
        <ItemStyle Width="446px" CssClass="tdspacingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
        <ItemTemplate>
            <%#Eval("drLastName")%>,&nbsp;<%#Eval("drFirstName")%>&nbsp;<%#Eval("drMiddleName")%>
        </ItemTemplate>

        <HeaderStyle Width="446px" CssClass="gridHeadingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
        <EditItemTemplate>
            <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.drLastName") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateColumn>
    
    
<asp:TemplateColumn HeaderText="Minutes">
<ItemStyle Width="90px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

<FooterStyle Width="90px" BackColor="#ECECEC" Height="18px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
<FooterTemplate>
<%#getMin(intTMinutes)%> 
</FooterTemplate>
<ItemTemplate>
 <%--<%#getmin(Eval("TotalMinutes"))%>--%>
 <asp:Label runat="server" Text='<%# getmin(Eval("TotalMinutes")) %>'></asp:Label>
</ItemTemplate>

<HeaderStyle Width="90px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Dictations">
<ItemStyle Width="80px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

<FooterStyle Width="80px" BackColor="#ECECEC" Height="18px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
<FooterTemplate>
<%#intDicDaily%>
</FooterTemplate>
<ItemTemplate>
<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TotalDictation") %>'></asp:Label>
</ItemTemplate>

<HeaderStyle Width="80px" CssClass="gridHeadingCenter" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Done">
<ItemStyle Width="50px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

<FooterStyle Width="50px" BackColor="#ECECEC" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
<FooterTemplate>
<%--count of done Dictation is place here--%>
            <%#intDone%>
            
</FooterTemplate>
<ItemTemplate>
 <asp:Label runat="server" Text='<%#Eval("doneDictations") %>'></asp:Label>
</ItemTemplate>

<HeaderStyle Width="50px" CssClass="gridHeadingCenter" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Done Minutes">
<ItemStyle Width="105px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

<FooterStyle Width="105px" BackColor="#ECECEC" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
<FooterTemplate>
                <%#getMin(intDoneM)%>
<%--count of done dictations minutes is place here--%>
</FooterTemplate>
<ItemTemplate>
 <asp:Label runat="server" Text='<%#getMin(Eval("doneMinutes")) %>'></asp:Label>
</ItemTemplate>

<HeaderStyle Width="105px" CssClass="gridHeadingCenter" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Outstanding">
<ItemStyle Width="80px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

<FooterStyle Width="80px" BackColor="#ECECEC" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
<FooterTemplate>
                <%#intOut%>
<%--count of outstandin dictations is place here--%>
</FooterTemplate>
<ItemTemplate>
 <asp:Label runat="server" Text='<%#Eval("outDictations") %>'></asp:Label>
</ItemTemplate>

<HeaderStyle Width="80px" CssClass="gridHeadingCenter" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Out Minutes">
<ItemStyle Width="105px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

<FooterStyle Width="105px" BackColor="#ECECEC" HorizontalAlign="Center" Font-Italic="False" Font-Size="8pt" Font-Names="verdana" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
<FooterTemplate>
                <%#getMin(intOutM)%>
</FooterTemplate>
<ItemTemplate>
 <asp:Label runat="server" Text='<%#getMin(Eval("outMinutes")) %>'></asp:Label>
</ItemTemplate>

<HeaderStyle Width="105px" CssClass="gridHeadingCenter" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
</asp:TemplateColumn>
</columns>
 </DBWC:hierargrid></td>
  </tr>
   <%--<tr>
   <td class="tdspace" colspan="2" style="height: 2px">
</td>
</tr>--%>

        <%--<tr>
            <td class="tdspace" colspan="2">
            </td>
        </tr>--%>
       
    </table>
</asp:Content>

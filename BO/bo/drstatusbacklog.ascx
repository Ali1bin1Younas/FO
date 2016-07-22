<%@ Control Language="VB" AutoEventWireup="false" CodeFile="drstatusbacklog.ascx.vb" Inherits="drstatusbacklog" %>
<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls"
    TagPrefix="DBWC" %>
<table border ="0" width="100%" cellpadding="0" cellspacing="0">
<tr><td style="width:20px; height: 100%;" ></td><td align="right" style=" vertical-align:top; height:100%; width:100%;">

<dbwc:hierargrid id="grdAssigned" SkinId="gridviewSkSmall" runat="server" autogeneratecolumns="False" gridlines="None" loadcontrolmode="UserControl" templatedatamode="Table" ShowHeader="False">
                
    <Columns>
            <asp:TemplateColumn HeaderText="Dr. ID">
                <ItemStyle Width="102px" CssClass="tdspacingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                <ItemTemplate>
                    <p> <%#Eval("foId") %>-&nbsp;<%#Eval("drId")%></p>
                </ItemTemplate>

                <HeaderStyle Width="102px" CssClass="gridHeadingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                </asp:TemplateColumn>
                
                
                <asp:TemplateColumn HeaderText="Name">
                <ItemStyle Width="447px" CssClass="tdspacingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                <ItemTemplate>
                    <P> <%#Eval("drLastName") %>,&nbsp;<%#Eval("drFirstName") %></P>
                </ItemTemplate>

            <HeaderStyle Width="447px" CssClass="gridHeadingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Minutes">
            <ItemStyle Width="196px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
            <ItemTemplate>
            <%#getmin(Eval("dicLength"))%>    [<%#Format(Eval("DicTations"),"000")%>]
            </ItemTemplate>

            <HeaderStyle Width="196px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Out Minutes">
            <ItemStyle Width="195px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
            <ItemTemplate>
            <%#getmin(Eval("OutdicLength"))%>    [<%#Format(Eval("OutDicTations"),"000")%>]
            </ItemTemplate>

            <HeaderStyle Width="195px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
            </asp:TemplateColumn>
</Columns>
            </DBWC:HierarGrid></td>
    </tr>
</table>


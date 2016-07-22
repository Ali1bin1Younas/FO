<%@ Control Language="VB" AutoEventWireup="false" CodeFile="drstatus.ascx.vb" Inherits="drstatus" %>
<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls"
    TagPrefix="DBWC" %>
<table border ="0" width="100%" cellpadding="0" cellspacing="0">
<tr><td style="width:20px; height: 100%;" ></td><td align="right" style=" vertical-align:top; height:100%; width:100%">
    <dbwc:hierargrid id="grdCurrent" SkinId="gridviewSkSmall" runat="server" autogeneratecolumns="False" gridlines="None"
        loadcontrolmode="UserControl" templatedatamode="Table" ShowHeader="false" >

<Columns>
    <asp:TemplateColumn HeaderText="#">
        <ItemStyle Width="54px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
        <itemtemplate>
            <p> <%#Counter%></p>
        </itemtemplate>
        <HeaderStyle Width="54px" CssClass="gridHeadingCenter" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
        
    </asp:TemplateColumn>
    
    
    <asp:TemplateColumn HeaderText="Dr. ID">
        <ItemStyle Width="105px" CssClass="tdspacingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
        <itemtemplate>
            <p> <%#Eval("foId")%>-&nbsp;<%#Eval("drId")%></p>
        </itemtemplate>
        <HeaderStyle Width="105px" HorizontalAlign="Left" CssClass="gridHeadingLeft" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
        
    </asp:TemplateColumn>
    
    
    <asp:TemplateColumn HeaderText="Name">
        <ItemStyle Width="538px" CssClass="tdspacingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
        <itemtemplate>
            <p> <%#Eval("drLastName") %>,&nbsp;<%#Eval("drFirstName") %></p>
        </itemtemplate>
        <HeaderStyle Width="538px" HorizontalAlign="Left" CssClass="gridHeadingLeft" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
            
    </asp:TemplateColumn>
    
    
    <asp:TemplateColumn HeaderText="Minutes">
        <ItemStyle Width="194px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
        <ItemTemplate>
            <%#getmin(Eval("dicLength"))%>     [<%#Format(Eval("DicTations"),"000")%>]
        </ItemTemplate>
        <HeaderStyle Width="194px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
    </asp:TemplateColumn>


    <asp:TemplateColumn HeaderText="Out Minutes">
        <ItemStyle Width="193px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
        <ItemTemplate>
            <%#getmin(Eval("OutdicLength"))%>     [<%#Format(Eval("OutDicTations"),"000")%>]
        </ItemTemplate>
        <HeaderStyle Width="193px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
    </asp:TemplateColumn>


</Columns>
</dbwc:hierargrid>
  </td></tr>
</table>


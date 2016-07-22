<%@ Control Language="VB" AutoEventWireup="false" CodeFile="dictatorlinecountdatewise.ascx.vb" Inherits="BO_dictatorlinecountdatewise" %>
<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC" %>

<table border ="0" width="100%" cellpadding="0" cellspacing="0" ><tr></td><td align="left" width="100%" >
<DBWC:HierarGrid ID="gridDictator" runat="server" AutoGenerateColumns="False" GridLines="None"
    LoadControlMode="UserControl" SkinID="gridviewSkinSmaller" TemplateDataMode="Table">
    <Columns>
        <asp:TemplateColumn HeaderText="#">
            <ItemStyle Width="40px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
            <ItemTemplate>
                <%#RowCount%>     
            </ItemTemplate>

            <HeaderStyle Width="40px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
        </asp:TemplateColumn>
        
        
        <asp:BoundColumn DataField="DicDate" HeaderText="Date">
            <ItemStyle Width="381px" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

            <HeaderStyle Width="381px" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
            </asp:BoundColumn>
                <asp:BoundColumn DataField="Dictations" HeaderText="Dictations">
            <ItemStyle Width="100px" Wrap="False" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

            <HeaderStyle Width="100px" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
        </asp:BoundColumn>
        
        
        <asp:TemplateColumn HeaderText="Minutes">
            <ItemStyle Width="100px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
            <ItemTemplate>
                <%#GF.GetMin(Eval("Minutes"))%>
            </ItemTemplate>

            <HeaderStyle Width="100px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
        </asp:TemplateColumn>
        
        
        <asp:BoundColumn DataField="Transcriptions" HeaderText="Transcriptions">
            <ItemStyle Width="110px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

            <HeaderStyle Width="110px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
        </asp:BoundColumn>
        
        
        <asp:BoundColumn DataField="Lines" HeaderText="Lines">
            <ItemStyle Width="60px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

            <HeaderStyle Width="60px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
        </asp:BoundColumn>
        
        
        <asp:TemplateColumn HeaderText="Lines / Minute">
            <ItemStyle Width="130px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
            <ItemTemplate>
                <%#Line_Per_Minutes(Eval("Minutes"), Eval("Lines"))%>
            </ItemTemplate>

            <HeaderStyle Width="130px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
        </asp:TemplateColumn>
        
        
        <asp:TemplateColumn HeaderText="Lines / Transcription">
        <ItemStyle Width="169px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
        <ItemTemplate>
            <%#Line_Per_Transcriptions(Eval("Transcriptions"), Eval("Lines"))%>
        </ItemTemplate>

        <HeaderStyle Width="169px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
        </asp:TemplateColumn>
        
</Columns>
</DBWC:HierarGrid>
</td></tr></table>
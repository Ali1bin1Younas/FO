<%@ Control Language="VB" AutoEventWireup="false" CodeFile="dictatorlinecounttranscriptionswise.ascx.vb" Inherits="BO_dictatorlinecounttranscriptionswise" %>

<table border ="0" width="100%" cellpadding="0" cellspacing="0" ><tr><td align="left" style="width:100%;" >
<asp:GridView ID="gvDictator" runat="server" AutoGenerateColumns="False" SkinID="gridviewSkinSmaller">
    <Columns>
        <asp:TemplateField HeaderText="#">
            <ItemTemplate>
                <%#RowCount%>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="30px" />
            <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        
        <%--<asp:BoundField DataField="dicDate" HeaderText="Date" >
            <ItemStyle Width="104px" HorizontalAlign="Center" />
            <HeaderStyle Width="104px" HorizontalAlign="Center" />
        </asp:BoundField>--%>
        
        <asp:BoundField DataField="traName" HeaderText="Name" >
            <ItemStyle Width="250px" HorizontalAlign="Left"/>
            <HeaderStyle Width="250px" HorizontalAlign="Left" />
        </asp:BoundField>
            
            
        <asp:TemplateField HeaderText="Minutes">
            <ItemStyle Width="50px" HorizontalAlign="Center" />
            <HeaderStyle Width="50px" HorizontalAlign="Center" />
            <ItemTemplate>
                <%#GF.GetMin(Eval("dicLength")) %>
            </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="-">
            <ItemStyle Width="50px" HorizontalAlign="Center" />
            <HeaderStyle Width="50px" HorizontalAlign="Center" />
        </asp:TemplateField>
        
        
        <asp:BoundField DataField="Lines" HeaderText="Lines" >
            <ItemStyle HorizontalAlign="Center"  Width="20px" />
            <HeaderStyle Width="20px" HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Lines / Minute">
        <ItemStyle HorizontalAlign="center" Width="70px" />
        <HeaderStyle HorizontalAlign="center" width="70px"/>
        <ItemTemplate>
        <%#Line_Per_Minutes(Eval("dicLength"), Eval("Lines"))%>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Lines / Transcription">
        <ItemStyle HorizontalAlign="center" Width="60px" VerticalAlign="middle" />
        <HeaderStyle HorizontalAlign="center" Width="60px" VerticalAlign="middle" />
        <ItemTemplate>
        <%#Lines_Per_Transcriptions(Eval("Transcriptions"), Eval("Lines"))%>
        </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</td><td style="width:334px;">&nbsp;</td></tr></table>

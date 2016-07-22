<%@ Control Language="VB" AutoEventWireup="false" CodeFile="datelinecountdate.ascx.vb" Inherits="BO_datelinecountdate" %>
<asp:GridView ID="GridView1" SkinId="gridviewSkinSmlr" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="#">
            <ItemTemplate>
                <%#rCount %>
            </ItemTemplate>
            <ItemStyle width="32px" horizontalalign="center" />
            <HeaderStyle width="32px" horizontalalign="center" />
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
                <%#Eval("traName")%>
            </ItemTemplate>
            <ItemStyle width="380px" horizontalalign="left" />
            <HeaderStyle width="380px" horizontalalign="left" />
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Minutes">
            <ItemTemplate>
                <%#GF.GetMin(Eval("dicLength"))%>
            </ItemTemplate>
            <ItemStyle width="90px" horizontalalign="center" />
            <HeaderStyle width="90px" horizontalalign="center" />
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Lines">
            <ItemTemplate>
                <%#Eval("Lines") %>
            </ItemTemplate>
            <ItemStyle width="92px" horizontalalign="center" />
            <HeaderStyle width="92px" horizontalalign="center" />
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Lines / Minute">
            <ItemTemplate>
                <%#Line_Per_Minutes(Eval("dicLength"), Eval("Lines"))%>
            </ItemTemplate>
            <ItemStyle width="114px" horizontalalign="center" />
            <HeaderStyle width="114px" horizontalalign="center" />
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Lines / Transcription">
            <ItemTemplate>
                <%#Lines_Per_Transcriptions(Eval("Transcriptions"),Eval("Lines"))%>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="123px" />
            <HeaderStyle HorizontalAlign="center" Width="123px" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>

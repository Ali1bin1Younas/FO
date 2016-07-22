<%@ Control Language="VB" AutoEventWireup="false" CodeFile="datelinecount.ascx.vb" Inherits="BO_datelinecount" %>
<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<DBWC:HierarGrid runat="Server" SkinId="gridviewSkin1S1" ID="GridDr" AutoGenerateColumns="False" 
TemplateDataMode="Table" LoadControlMode="UserControl">
    <Columns>
        <asp:TemplateColumn HeaderText="#">
            <ItemTemplate>
                <%#rCount %>
            </ItemTemplate>
            <ItemStyle width="44px" horizontalalign="center" />
            <HeaderStyle width="44px" horizontalalign="center" />
        </asp:TemplateColumn>
        
        
        <asp:TemplateColumn HeaderText="Id">
            <ItemTemplate>
                <%#Eval("drId")%>
            </ItemTemplate>
            <ItemStyle width="100px" horizontalalign="center" />
            <HeaderStyle width="100px" horizontalalign="center" />
        </asp:TemplateColumn>
        
        
        <asp:TemplateColumn HeaderText="Name">
            <ItemTemplate>
                <%#Eval("drName")%>
            </ItemTemplate>
            <ItemStyle width="154px" horizontalalign="center" />
            <HeaderStyle width="154px" horizontalalign="center" />
        </asp:TemplateColumn>
        
        
        <asp:TemplateColumn HeaderText="Dictations">
            <ItemTemplate>
                <%#Eval("Dictations")%>
            </ItemTemplate>
            <ItemStyle width="120px" horizontalalign="center" />
            <HeaderStyle width="120px" horizontalalign="center" />
        </asp:TemplateColumn>
        
        
        <asp:TemplateColumn HeaderText="Minutes">
            <ItemTemplate>
                <%#GF.GetMin(Eval("dicLength"))%>
            </ItemTemplate>
            <ItemStyle width="120px" horizontalalign="center" />
            <HeaderStyle width="120px" horizontalalign="center" />
        </asp:TemplateColumn>
        
        
        <asp:TemplateColumn HeaderText="Transcriptions">
            <ItemTemplate>
                <%#Eval("Transcriptions") %>
            </ItemTemplate>
            <ItemStyle width="120px" horizontalalign="center" />
            <HeaderStyle width="120px" horizontalalign="center" />
        </asp:TemplateColumn>
        
        
        <asp:TemplateColumn HeaderText="Lines">
            <ItemTemplate>
                <%#Eval("Lines")%>
            </ItemTemplate>
            <ItemStyle width="120px" horizontalalign="center" />
            <HeaderStyle width="120px" horizontalalign="center" />
        </asp:TemplateColumn>
        
        
        <asp:TemplateColumn HeaderText="Lines / Minute">
            <ItemTemplate>
                <%#Line_Per_Minutes(Eval("dicLength"), Eval("Lines"))%>
            </ItemTemplate>
            <ItemStyle width="149px" horizontalalign="center" />
            <HeaderStyle width="149px" horizontalalign="center" />
        </asp:TemplateColumn>
        
        
        <asp:TemplateColumn HeaderText="Lines / Transcription">
            <ItemTemplate>
                <%#Lines_Per_Transcriptions(Eval("Transcriptions"), Eval("Lines"))%>
            </ItemTemplate>
            <ItemStyle width="160px" horizontalalign="center" />
            <HeaderStyle width="160px" horizontalalign="center" />
        </asp:TemplateColumn>
    </Columns>
</DBWC:HierarGrid>
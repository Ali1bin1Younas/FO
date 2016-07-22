<%@ Control Language="VB" AutoEventWireup="false" CodeFile="employeedictator.ascx.vb" Inherits="BO_employeedictator" %>
<table border ="0" width="100%" cellpadding="0" cellspacing="0">

<tr><td style="width:20px; height: 100%;" ></td><td align="right" style=" vertical-align:top; height:100%; width: 960px;">
<asp:GridView ID="gvDictator" runat="server" AutoGenerateColumns="False" SkinId="gridviewSkinSmall" ShowHeader="False">
    <Columns>
        <asp:TemplateField HeaderText="#">
            <ItemTemplate>
                <%#iCounter %>
            </ItemTemplate>
            <ItemStyle Width="44px" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle Width="44px" CssClass="gridHeadingCenter" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Dr. ID">
            <ItemTemplate>
                <%#Eval("foID")%>-<%#Eval("drID") %>
            </ItemTemplate>
            <ItemStyle Width="90px" CssClass="tdspacingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
            <HeaderStyle Width="90px" CssClass="gridHeadingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
                <%#Eval("drLastName") %>, <%#Eval("drFirstName") %> <%#Eval("drMiddleName") %>
            </ItemTemplate>
            <ItemStyle Width="278px" CssClass="tdspacingLeft" HorizontalAlign="Left" />
            <HeaderStyle Width="278px" CssClass="gridHeadingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Total">
            <ItemTemplate>
                <%#GF.GetMin(Eval("dicLength")) %>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("DicTations"), "000") %>]
            </ItemTemplate>
            <ItemStyle Width="171px" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle Width="171px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Done">
            <ItemTemplate>
                <%#GF.GetMin(Eval("DonedicLength"))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("DoneDictations"), "000") %>]
            </ItemTemplate>
            <ItemStyle Width="171px" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle Width="171px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"/>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Done">
            <ItemTemplate>
                <%#GF.GetMin(Eval("availdicLength"))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("availDictations"), "000")%>]
            </ItemTemplate>
            <ItemStyle Width="171px" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle Width="171px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"/>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Outstanding">
            <ItemTemplate>
                <%#GF.GetMin(Eval("OutdicLength"))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("OutDicTations"),"000") %>]
            </ItemTemplate>
            <HeaderStyle Width="170px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle Width="171px" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        
    </Columns>
</asp:GridView>
</td></tr></table>

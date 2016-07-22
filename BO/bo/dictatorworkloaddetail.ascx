<%@ Control Language="VB" AutoEventWireup="false" CodeFile="dictatorworkloaddetail.ascx.vb" Inherits="dictatorworkloaddetail" %>
<table border ="0" width="100%" cellpadding="0" cellspacing="0" ><tr><td style="width:20px;"></td><td align="left" width="700px" >
    <asp:GridView ID="grdDailyProgress" SkinId="gridviewSkinSmall" runat="server" AutoGenerateColumns="False" PageSize="1" GridLines="None">
            <Columns>
                <asp:BoundField DataField="#" HeaderText="#" >
                    <ItemStyle HorizontalAlign="Center" Width="35px" />
                    <HeaderStyle HorizontalAlign="Center" Width="35px" />
                </asp:BoundField>
                
                
                <%--<asp:TemplateField HeaderText="-">
                    <ItemStyle HorizontalAlign="Center" Width="86px" />
                    <HeaderStyle HorizontalAlign="Center" Width="86px" />
                </asp:TemplateField>--%>
                
                
                <asp:BoundField DataField="dicActualName" HeaderText="Name" >
                    <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="720px" />
                    <HeaderStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="720px" />
                </asp:BoundField>
                
                
                <asp:TemplateField HeaderText="Minutes">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# getmin(eval("dicLength")) %>' ID="Minute"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="160px" HorizontalAlign = "Center" />
                    <HeaderStyle Width="160px" HorizontalAlign = "Center" />
                </asp:TemplateField>
                
                
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <p><%#Convert.ToDateTime(Eval("dicDate")).ToString("dd/MM/yyyy")%> </p>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="168px" />
                    <HeaderStyle HorizontalAlign="Center" Width="168px" />
                </asp:TemplateField>
                
            </Columns>
          
        </asp:GridView>
</td></tr></table>

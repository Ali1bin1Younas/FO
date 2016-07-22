<%@ Control Language="VB" AutoEventWireup="false" CodeFile="dailydictationdetail.ascx.vb" Inherits="dailydictationdetail" %>
<table border ="0" width="100%" cellpadding="0" cellspacing="0" ><tr><td align="left" width="800px" >
    <asp:GridView ID="grdDailyProgress" SkinId="gridviewSkinSmall" runat="server" AutoGenerateColumns="False" PageSize="1" GridLines="None">
            <Columns>
                <asp:BoundField DataField="#" HeaderText="#" >
                    <ItemStyle HorizontalAlign="Center" Width="33px" />
                    <HeaderStyle HorizontalAlign="Center" Width="33px" />
                </asp:BoundField>

                <asp:BoundField DataField="dicActualName" HeaderText="Name" >
                    <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="250px" />
                    <HeaderStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="250px" />
                </asp:BoundField>

                <asp:BoundField DataField="dicAccountName" HeaderText="Account" >
                    <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="142px" />
                    <HeaderStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="142px" />
                </asp:BoundField>


                <asp:TemplateField HeaderText="Minutes">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# getmin(eval("dicLength")) %>' ID="Minute"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="98px" HorizontalAlign = "Center" />
                    <HeaderStyle Width="98px" HorizontalAlign = "Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Date"> 
                    <ItemTemplate>
                        <p><%#Convert.ToDateTime(Eval("dicDate")).ToString("dd/MM/yyyy")%> </p>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="98px" />
                    <HeaderStyle HorizontalAlign="Center" Width="98px" />
                </asp:TemplateField>
                
            </Columns>
          
        </asp:GridView>
</td></tr></table>

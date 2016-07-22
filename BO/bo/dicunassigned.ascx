<%@ Control Language="VB" AutoEventWireup="false" CodeFile="dicunassigned.ascx.vb" Inherits="dicunassigned" %>
<table border =0 width="100%"><tr><td Height="100%" >
    <asp:GridView ID="grdAssigned1" runat="server" AutoGenerateColumns="False" border="0"
        BorderStyle="None" BorderWidth="0px" Font-Names="Verdana" Font-Size="11px" GridLines="Horizontal"
        Height="20px" ShowFooter="True" Width="100%">
        <FooterStyle BackColor="Transparent" ForeColor="Black" Height="20px" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chkAssign" runat="server" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="30px" />
                <HeaderStyle HorizontalAlign="Center" Width="30px" />
            </asp:TemplateField>
            <asp:BoundField DataField="dicID" HeaderText="DIC ID" >
                <ItemStyle HorizontalAlign="Left" Width="200px" />
                <HeaderStyle HorizontalAlign="Left" Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="dicActualName" HeaderText="Name" >
                <ItemStyle HorizontalAlign="Left" Width="300px" />
                <HeaderStyle HorizontalAlign="Left" Width="300px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Date">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dicDate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("dicDate", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="300px" />
                <HeaderStyle HorizontalAlign="Left" Width="300px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MT">
                <ItemStyle HorizontalAlign="Left" Width="100px" />
                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                <ItemTemplate>
                    <p>-</p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="QC">
                <ItemStyle HorizontalAlign="Left" Width="100px" />
                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                <ItemTemplate>
                    <p>-</p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PR">
                <ItemStyle HorizontalAlign="Left" Width="100px" />
                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                <ItemTemplate>
                    <p>-</p>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FR">
                <ItemStyle HorizontalAlign="Left" Width="100px" />
                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                <ItemTemplate>
                    <p>-</p>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle BackColor="WhiteSmoke" BorderStyle="None" BorderWidth="0px" ForeColor="Black"
            Height="18px" />
        <SelectedRowStyle BackColor="WhiteSmoke" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Left" />
        <HeaderStyle BackColor="Silver" Font-Bold="True" Font-Size="Smaller" ForeColor="#1E1E1E"
            Height="20px" />
        <AlternatingRowStyle BackColor="#ECECEC" />
    </asp:GridView>
    <asp:LinkButton ID="btnAssign" runat="server">Assign</asp:LinkButton>
    &nbsp;&nbsp;</td></tr></table>

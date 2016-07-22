<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test.aspx.vb" Inherits="BO_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<asp:GridView ID="GridView1" runat="server" Width="714px" AutoGenerateColumns="False" Height="143px" DataKeyNames="rolID">
            <Columns>
                <asp:TemplateField HeaderText="Proof Reading">
                         <ItemTemplate>
                    <asp:CheckBox ID="chkRoles" runat="server" Checked='<%#getEnableDisable1(Eval("empEnable").ToString)%>' Enabled="true" />
                    <asp:HiddenField ID="rolID" Value='<%#Eval("rolID") %>' runat=server />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
                <asp:BoundField DataField="rolDescription" HeaderText="Description" />
                <asp:TemplateField HeaderText="Enable">
                    <ItemTemplate>
                   <a href= "#"> <%#getEnableDisable(Eval("empEnable").ToString)%></a>
                    
                    </ItemTemplate>
                    
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        &nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Save" Width="56px" /></div>
    </form>
</body>
</html>

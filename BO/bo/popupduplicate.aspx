<%@ Page Language="VB" AutoEventWireup="false" CodeFile="popupduplicate.aspx.vb" Inherits="BO_popupchangeminutes" Theme="BOboLayout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form runat="server">
    <div>
        <asp:GridView ID="gvDictation" SkinId="grdviewSkinPopup" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="dicID" >
            <Columns>
                <asp:BoundField DataField="dicID" HeaderText="ID" >
                    <ItemStyle Width="50px" Wrap="False" HorizontalAlign="Center" />
                </asp:BoundField>
                
                <asp:TemplateField HeaderText="Date">
                    <ItemStyle HorizontalAlign="center" Width="70px" />
                    <ItemTemplate>
                        <%#Convert.ToDateTime(Eval("dicDate")).ToString("dd/MM/yyyy")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="drID" HeaderText="Dictator" >
                    <ItemStyle Width="100px" Wrap="False" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="dicActualName" HeaderText="Dictation" >
                    <ItemStyle Width="100px" Wrap="False" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Minutes">
                    <ItemTemplate>
                        <%#getMin(Eval("dicLength"))%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>    
    </div>
    <%--<div><asp:Button ID="btnCancle" runat="server" Text="Cancle" /></div>--%>
        
    </form>
</body>
</html>

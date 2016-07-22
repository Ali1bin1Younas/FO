<%@ Page Language="VB" AutoEventWireup="false" CodeFile="popupchangeminutes.aspx.vb" Inherits="BO_popupchangeminutes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset runat="server" style="width: 247px; height: 124px">
    <legend runat="server" id="ChangeMinutes" style="width: 86px">Dictation Tools Change&nbsp;
        Minutes:-</legend>
    <table>
        <tr>
                            <td colspan="2" style="height: 21px">
                                <asp:Label ID="lblError" runat="server" Width="240px"></asp:Label></td>
        </tr>
        <tr>
                            <td style="width: 106px; height: 21px;">
                                <asp:Label ID="Label1" runat="server" Text="Minutes:"></asp:Label></td>
                            <td style="width: 196px; height: 21px;">
                                <asp:Label ID="lblMinutes" runat="server" Width="108px"></asp:Label></td>
        </tr>
        <tr>
                            <td style="width: 106px">
                                <asp:Label ID="Label3" runat="server" Text="Change In Seconds:" Width="127px"></asp:Label></td>
                            <td style="width: 196px">
                                <asp:TextBox ID="txtSeconds" runat="server" Width="103px"></asp:TextBox></td>
        </tr>
        <tr>
                            <td colspan="2" style="height: 1px">
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp;&nbsp; 
                                <asp:Button ID="btnChange" runat="server" Text="Change" />
                                <asp:Button ID="btnCancle" runat="server" Text="Cancle" /></td>
        </tr>
                    </table>
     </fieldset>
  </div>
    </form>
</body>
</html>

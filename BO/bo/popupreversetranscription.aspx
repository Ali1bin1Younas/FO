<%@ Page Language="VB" AutoEventWireup="false" CodeFile="popupreversetranscription.aspx.vb" Inherits="BO_popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Reverse transcription</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family:Verdana; font-size:12px;">
        &nbsp;<asp:Label ID="lblError" runat="server" Height="25px" Width="355px" ForeColor="Red"></asp:Label>
        <table style="width: 350px; height: 110px;">
            <tr>
                <td colspan="2" style="width:100%" align="center">
    <fieldset style="width: 100%; height:100%">
    <legend>Reverse transcription</legend>
        &nbsp;
        <br />
        <table>
            <tr>
                <td style="width:25%"  align="right">
                    <asp:RadioButton ID="rbMT" runat="server" GroupName="A" Height="20px" Width="76px" Enabled="false" />
                </td>
                <td style="width:75%" align="left">
                    <asp:Label ID="lblMT" runat="server" Width="165px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:25%"  align="right">
                    <asp:RadioButton ID="rbQC" runat="server" GroupName="A" Height="20px" Width="76px" Enabled="false" />
                </td>
                <td style="width:75%" align="left">
                    <asp:Label ID="lblQC" runat="server" Width="162px">QC: -</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:25%"  align="right">
                    <asp:RadioButton ID="rbPR" runat="server" GroupName="A" Height="20px" Width="76px" Enabled="false" />
                </td>
                <td style="width:75%" align="left">
                    <asp:Label ID="lblPR" runat="server" Width="156px">PR: -</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:25%"  align="right">
                    <asp:RadioButton ID="rbFR" runat="server" GroupName="A" Height="20px" Width="76px" Enabled="false" />
                </td>
                <td style="width:75%" align="left">
                    <asp:Label ID="lblFR" runat="server" Width="156px">FR: -</asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <br />
                    <asp:Button ID="btnOk" runat="server" Text="Reverse" Width="80px" />
                    <asp:Button ID="btnCancle" runat="server" Text="Cancel" Width="80px" />
                </td>
            </tr>
        </table>
    </fieldset>
        </td>
            </tr>
        </table>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    </div>
    </form>
</body>
</html>

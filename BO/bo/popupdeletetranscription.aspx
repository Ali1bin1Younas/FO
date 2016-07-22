<%@ Page Language="VB" AutoEventWireup="false" CodeFile="popupdeletetranscription.aspx.vb" Inherits="BO_deletetranscription" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Delete Transcription </title>
</head>
<body>
    <form id="DeleteTranscription" runat="server">
    <div>
        &nbsp;<asp:Label ID="lblError" runat="server" Height="25px" Width="355px"></asp:Label><span
            style="font-size: 10pt"> </span>
        <table style="font-size: 10pt; width: 354px; height: 104px">
            <tr>
                <td align="center" colspan="2" style="width: 318px; height: 190px">
                    &nbsp;<fieldset style="width: 267px; height: 176px">
                        <legend style="width: 80px" title="Revirse">Transcription <span style="font-size: 10pt">
                            <span style="font-size: 12pt">Rev</span>eres</span></legend>&nbsp;
                        <br />
                        <table>
                            <tr>
                                <td align="left" style="width: 100px">
                                    &nbsp;<asp:Label ID="lblID" runat="server" Text="ID" Width="25px"></asp:Label></td>
                                <td align="left" style="width: 89px">
                    <asp:Label ID="id" runat="server" Width="145px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 100px">
                                    &nbsp;<asp:Label ID="lblName" runat="server" Text="Dictation Name:" Width="99px"></asp:Label></td>
                                <td align="left" style="width: 89px">
                    <asp:Label ID="DName" runat="server" Width="147px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 100px">
                    <asp:Label ID="Label7" runat="server" Text="Transcription Name:" Width="124px"></asp:Label></td>
                                <td align="left" style="width: 89px">
                    <asp:Label ID="TName" runat="server" Width="146px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 100px">
                                    &nbsp;<asp:Label ID="lblDate" runat="server" Text="Date" Width="60px"></asp:Label></td>
                                <td align="left" style="width: 89px">
                    <asp:Label ID="lDate" runat="server" Width="146px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" />&nbsp;
                    <asp:Button ID="btnCancle" runat="server" Text="Cancle" /></td>
                            </tr>
                        </table>
                    </fieldset>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        &nbsp;<br />
        <br />
        <br />
        <br />
    </div>
    </form>
</body>
</html>

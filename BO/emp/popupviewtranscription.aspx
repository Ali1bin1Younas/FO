<%@ Page Language="VB" AutoEventWireup="false" CodeFile="popupviewtranscription.aspx.vb" Inherits="BO_popviewtranscription" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>View Transcription Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0" border="0" style=" font-family:Verdana; font-size:11px;">
            <tr style="height:20px;">
                <td runat="server" id="traID"></td>
                <td runat="server" id="traUrgent"></td>
            </tr>
            <tr style="height:20px;">
                <td runat="server" id="traSubject"></td>
                <td runat="server" id="traDear"></td>
            </tr>
            <tr style="height:20px;">
                <td runat="server" id="traPatientNo"></td>
                <td runat="server" id="traNHSNo"></td>
            </tr>
            <tr style="height:20px;">
                <td runat="server" id="traClinicDate"></td>
                <td runat="server" id="traDOB"></td>
            </tr>
            <tr style="height:20px;">
                <td runat="server" id="traNTS"></td>
                <td runat="server" id="traNTD"></td>
            </tr>
            <tr style="height:20px;">
                <td runat="server" id="traRecipientAddress"></td>
                <td runat="server" id="traFooterBlock"></td>
            </tr>
            <tr style="height:20px;">
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr style="height:20px;">
                <td><a runat="server" id="docLink" title ="View" href ="#"><b>View Document</b></a></td>
            </tr>
        </table>
     </form>
</body>
</html>

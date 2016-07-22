<%@ Page Language="VB" AutoEventWireup="false" CodeFile="popreplacetranscription.aspx.vb" Inherits="BO_popreplacetranscription" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Replace Transcription Document Page</title>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="lblError" runat="server" Height="42px" Width="571px"></asp:Label><br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <fieldset style="width: 495px; height: 323px">
            <legend style="width: 97px" title="Revirse">
            Replace Transcription Document.&nbsp; 
            </legend>
            <br />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            &nbsp; &nbsp; &nbsp;&nbsp;<br />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:FileUpload ID="fuReplace" runat="server" Height="22px" Width="365px" /><br />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;
            <input id="cbLine_Count" style="width: 16px" type="checkbox"  value="LineCount" onclick="cbRe_Upload.checked=this.checked" name="linecount" runat="server" />
            <asp:Label ID="lblLineCount" runat="server" Text="Line Count" Width="145px"></asp:Label><br />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <input id="cbRe_Upload" style="width: 16px" type="checkbox" value="ReUpload" onclick="cbLine_Count.checked=false" name="reupload" runat="server"/>
            <asp:Label ID="lblReUpload" runat="server" Text="Re Upload" Width="145px"></asp:Label><br />
            <br />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            &nbsp; &nbsp; &nbsp;<asp:Button ID="btnReplace"
                runat="server" Height="24px" Text="Replace" Width="58px" />&nbsp;
            <asp:Button ID="btnCancle"
                runat="server" Height="24px" Text="Cancle" Width="58px" />
                </fieldset>
    
    </div>
    </form>
</body>
</html>

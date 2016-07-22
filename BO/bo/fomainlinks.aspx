<%@ Page Language="VB" AutoEventWireup="false" CodeFile="fomainlinks.aspx.vb" Inherits="FO_fomainlinks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp; &nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/FO/clientmain.aspx"
            Style="z-index: 100; left: 369px; position: absolute; top: 124px">client</asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/FO/frontofficemain.aspx"
            Style="z-index: 101; left: 369px; position: absolute; top: 194px">Front Office</asp:LinkButton>
        <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/FO/employeemain.aspx"
            Style="z-index: 102; left: 369px; position: absolute; top: 244px">Employee</asp:LinkButton>
        <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/FO/specialtymain.aspx"
            Style="z-index: 103; left: 369px; position: absolute; top: 295px">Specialty</asp:LinkButton>
        <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/FO/hospitalmain.aspx"
            Style="z-index: 104; left: 369px; position: absolute; top: 349px">Hospital</asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton6" runat="server" Style="z-index: 105; left: 522px;
            position: absolute; top: 255px" PostBackUrl="~/FO/dailyprogress1.aspx">Progress Report</asp:LinkButton>
        <asp:LinkButton ID="LinkButton7" runat="server" PostBackUrl="~/FO/dailyworkload.aspx"
            Style="z-index: 106; left: 523px; position: absolute; top: 187px">Work Load</asp:LinkButton>
        <asp:LinkButton ID="LinkButton8" runat="server" PostBackUrl="~/FO/prdictations.aspx"
            Style="z-index: 109; left: 649px; position: absolute; top: 254px">PR Dictations</asp:LinkButton>
        <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl="~/FO/prassignment.aspx"
            Style="z-index: 108; left: 646px; position: absolute; top: 185px">PR Assign </asp:LinkButton>
    
    </div>
    </form>
</body>
</html>

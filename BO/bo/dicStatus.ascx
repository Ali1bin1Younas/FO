<%@ Control Language="VB" AutoEventWireup="false" CodeFile="dicStatus.ascx.vb" Inherits="dicStatus" %>
<table border ="0" width="100%" cellpadding="0" cellspacing="0">
<tr><td colspan="2" align = "right">
    <asp:DropDownList ID="ddlMT" runat="server">
    </asp:DropDownList>
    <asp:DropDownList ID="ddlQC" runat="server">
    </asp:DropDownList>
    <asp:DropDownList ID="ddlPR" runat="server">
    </asp:DropDownList>
    <asp:DropDownList ID="ddlFR" runat="server">
    </asp:DropDownList>
    <asp:LinkButton ID="btnAssign" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Smaller" ForeColor="#0000C0" PostBackUrl='<%#PostBackUrl() %>'>Assign</asp:LinkButton>&nbsp;&nbsp;</td></tr>
<tr><td style="width:40px; height: 100%;" ></td><td align="right" style=" vertical-align:top; height:100%; width: 940px;">
    <asp:GridView ID="grdDictation" SkinId="gridviewSkSmaller" runat="server" AutoGenerateColumns="False"  GridLines="None" DataKeyNames="dicID">
<Columns>

<asp:BoundField DataField="#" HeaderText="#">
<ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="40px" CssClass="gridHeadingCenter" HorizontalAlign="Center"></HeaderStyle>
</asp:BoundField>
<asp:BoundField DataField="dicActualName" HeaderText="Dictation Name">
<ItemStyle Width="220px" CssClass="tdspacingLeft" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="220px" CssClass="gridHeadingLeft" HorizontalAlign="Left"></HeaderStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Min.">
<ItemStyle Width="75px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="75px" CssClass="gridHeadingCenter" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
                    <%#getMin(Eval("dicLength"))%>
              
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="MT">
<ItemStyle Width="113px" CssClass="tdspacingLeft" HorizontalAlign="Left"></ItemStyle>
<HeaderStyle Width="113px" CssClass="gridHeadingLeft" HorizontalAlign="Left"></HeaderStyle>
            <HeaderTemplate>
               <asp:Image ID="ImgMT" runat="server" ImageUrl="~/images/tag1.gif" />
                <asp:CheckBox runat="server" ID="chkMT"  onClick="CheckAllCheckboxes(this.name,this.checked)" />
            </HeaderTemplate>
<ItemTemplate>
               <asp:Image ID="IImgMT" runat="server" ImageUrl='<%#tagImage(eval("dicID"),"MT")%>' />
                <asp:CheckBox ID="chkMT" runat="server" Enabled='<%#m_bMTStatus%>'/>
                 <%--<%#getEmployeeName(Eval("dicID"), "MT")%>--%>
               <asp:Label ID="lblMT" runat="server" Text='<%#m_sMTName%> ' ForeColor='<%#m_cMTColor%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
        

<asp:TemplateField HeaderText="QC">
<ItemStyle Width="112px" CssClass="tdspacingLeft" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="112px" CssClass="gridHeadingLeft" HorizontalAlign="Left"></HeaderStyle>
<HeaderTemplate>
                <asp:Image ID="ImgQC" runat="server" ImageUrl="~/images/tag1.gif" />
                <asp:CheckBox runat="server" ID="chkQC" onClick="CheckAllCheckboxes(this.name,this.checked)" />
            </HeaderTemplate>
<ItemTemplate>
                <asp:Image ID="IImgQC" runat="server" ImageUrl='<%#tagImage(eval("dicID"),"QC")%>' />
                 <asp:CheckBox ID="chkQC" runat="server" Enabled='<%#m_bQCStatus%>' />
                 <%--<%#getEmployeeName(Eval("dicID"), "QC")%>--%>
                 <asp:Label ID="lblQC" runat="server" Text='<%#m_sQCName%>' ForeColor='<%#m_cQCColor%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="PR">
<ItemStyle Width="112px" CssClass="tdspacingLeft" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="112px" CssClass="gridHeadingLeft" HorizontalAlign="Left"></HeaderStyle>
<HeaderTemplate>
                <asp:Image ID="ImgPR" runat="server" ImageUrl="~/images/tag1.gif" />
                <asp:CheckBox runat="server" ID="chkPR"  onClick="CheckAllCheckboxes(this.name,this.checked)" />
            </HeaderTemplate>
<ItemTemplate>
                  <asp:Image ID="IImgPR" runat="server" ImageUrl='<%#tagImage(eval("dicID"),"PR")%>' />
                  <asp:CheckBox ID="chkPR" runat="server" Enabled='<%#m_bPRStatus%>'  />
                 <%-- <%#getEmployeeName(Eval("dicID"), "PR")%>--%>
    <asp:Label ID="lblPR" runat="server" Text='<%#m_sPRName%>' ForeColor='<%#m_cPRColor%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="FR">
<ItemStyle Width="112px" CssClass="tdspacingLeft" HorizontalAlign="Left"></ItemStyle>

<HeaderStyle Width="112px" CssClass="gridHeadingLeft" HorizontalAlign="Left"></HeaderStyle>
<HeaderTemplate>
                <asp:Image ID="ImgFR" runat="server" ImageUrl="~/images/tag1.gif" />
                <asp:CheckBox runat="server" ID="chkFR"  onClick="CheckAllCheckboxes(this.name,this.checked)" />
            </HeaderTemplate>
<ItemTemplate>
                <asp:Image ID="IImgFR" runat="server" ImageUrl='<%#tagImage(eval("dicID"),"FR")%>' />
                <asp:CheckBox ID="chkFR" runat="server" Enabled='<%#m_bFRStatus%>'  />
               <%-- <%#getEmployeeName(Eval("dicID"), "FR")%>--%>  
               <asp:Label ID="lblFR" runat="server" Text='<%#m_sFRName%>' ForeColor='<%#m_cFRColor%>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
        <asp:BoundField DataField="dicStatus" HeaderText="DictationStatus" Visible="False" />
<asp:TemplateField HeaderText="Date">
<ItemStyle Width="80px" HorizontalAlign="Center"></ItemStyle>

<HeaderStyle Width="80px" CssClass="gridHeadingCenter" HorizontalAlign="Center"></HeaderStyle>
<ItemTemplate>
                  <%#getDate(Eval("dicDate"))%>
                
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView><td></tr>
      </table>

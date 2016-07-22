<%@ Control Language="VB" AutoEventWireup="false" CodeFile="dicstatusbacklog.ascx.vb" Inherits="dicstatusbacklog" %>
<table border ="0" width="100%" cellpadding="0" cellspacing="0">

<tr><td style="width:40px; height: 100%;" ></td><td align="right" style=" vertical-align:top; height:100%; width: 940px;">
    <asp:GridView ID="grdAssigned1" SkinId="gridviewSkSmaller" runat="server" AutoGenerateColumns="False" GridLines="None" DataKeyNames="foId,drId,empID" BorderColor="Salmon">
        <Columns>
            <asp:BoundField DataField="#" HeaderText="#">
                <ItemStyle HorizontalAlign="Center" Width="30px" />
                <HeaderStyle CssClass ="gridHeadingCenter" HorizontalAlign="Center" Width="30px" />
            </asp:BoundField>
            <asp:BoundField DataField="dicID" HeaderText=" ID" >
                <ItemStyle HorizontalAlign="Center" Width="50px" />
                <HeaderStyle CssClass ="gridHeadingCenter" HorizontalAlign="Center" Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="dicActualName" HeaderText="Name" >
                <ItemStyle HorizontalAlign="Left" CssClass ="tdspacingLeft" Width="200px" />
                <HeaderStyle HorizontalAlign="Left" CssClass ="gridHeadingLeft" Width="200px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Min.">
            <ItemStyle Width="72px" HorizontalAlign="Center"></ItemStyle>
                <HeaderStyle Width="72px" CssClass="gridHeadingCenter" HorizontalAlign="Center"></HeaderStyle>
                <ItemTemplate>
                    <%#getMin(Eval("dicLength"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date">
                
                <ItemStyle HorizontalAlign="Center" Width="90px" />
                <HeaderStyle HorizontalAlign="Center" CssClass ="gridHeadingCenter" Width="90px" />
                <ItemTemplate>
                  <%#getDate(Eval("dicDate"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AllMT">
                <ItemStyle HorizontalAlign="Center" Width="16px" />
                <HeaderStyle HorizontalAlign="Center" Width="16px" />
                <HeaderTemplate>
                <%--<input type="checkbox" id="MTH" onclick="checkMt('<%#Eval("foId") %>')" />--%>
               <asp:Checkbox runat="server" id="AssChkMT" onclick="CheckAllCheckboxes(this.name,this.checked)" />
               <%--<asp:Label runat="server" id="lblMT" Text='123' />--%>
                </HeaderTemplate>
                <ItemTemplate>
              <asp:CheckBox runat="server" ID="AssChkMT"  />
               <%--<input type="checkbox" id="AssChkMT" name="<%#m_chkName%>"  onclick="alert(this.ClientID)"/>--%>
                
                </ItemTemplate>
                <FooterTemplate>
                
                </footerTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MT">
                <ItemStyle HorizontalAlign="Left" CssClass ="tdspacingLeft" Width="107px" />
                <HeaderStyle HorizontalAlign="Left" CssClass ="gridHeadingLeft" Width="107px" />
                <ItemTemplate>
                 <%#getMTEmpID(Eval("dicID"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AllQC">
                <ItemStyle HorizontalAlign="Center" Width="16px" />
                <HeaderStyle HorizontalAlign="Center" Width="16px" />
                <HeaderTemplate>
                <asp:CheckBox runat="server" ID="AssChkQC" onclick="CheckAllCheckboxes(this.name,this.checked)" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="AssChkQC" runat="server"  />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="QC">
                <ItemStyle HorizontalAlign="Left" CssClass ="tdspacingLeft" Width="107px" />
                <HeaderStyle HorizontalAlign="Left" CssClass ="gridHeadingLeft" Width="107px" />
                <ItemTemplate>
                 <%#getQCEmpID(Eval("dicID"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AllPR">
                <ItemStyle HorizontalAlign="Center" Width="16px" />
                <HeaderStyle HorizontalAlign="Center" Width="16px" />
                <HeaderTemplate>
                <asp:CheckBox runat="server" ID="AssChkPR"  onclick="CheckAllCheckboxes(this.name,this.checked)" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="AssChkPR" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PR">
                <ItemStyle HorizontalAlign="Left" CssClass ="tdspacingLeft" Width="107px" />
                <HeaderStyle HorizontalAlign="Left" CssClass ="gridHeadingLeft" Width="107px" />
                <ItemTemplate>
                  <%#getPREmpID(Eval("dicID"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AllFR">
                <ItemStyle HorizontalAlign="Center" Width="16px" />
                <HeaderStyle HorizontalAlign="Center" Width="16px" />
                <HeaderTemplate>
                <asp:CheckBox runat="server" ID="AssChkFR" onclick="CheckAllCheckboxes(this.name,this.checked)" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="AssChkFR" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FR">
                <ItemStyle HorizontalAlign="Left" CssClass ="tdspacingLeft" Width="107px" />
                <HeaderStyle HorizontalAlign="Left" CssClass ="gridHeadingLeft" Width="107px" />
                <ItemTemplate>
                <%#getFREmpID(Eval("dicID"))%>  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField Visible = "False">
                <ItemStyle HorizontalAlign="Left" Width="1px" />
                <HeaderStyle HorizontalAlign="Left" Width="1px" />
                <ItemTemplate>
                  
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="dicStatus" Visible = "False">
                <ItemStyle HorizontalAlign="Left" Width="1px" />
                <HeaderStyle HorizontalAlign="Left" Width="1px" />
            </asp:BoundField>
        </Columns>
        
    </asp:GridView></td></tr>
   
      </table>

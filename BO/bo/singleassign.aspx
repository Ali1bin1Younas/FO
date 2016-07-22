<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false"
    CodeFile="singleassign.aspx.vb" Inherits="BO_singleassign" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="980" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td style="background-image: url(../images/BOadminHeadingBG.jpg); width: 980; height: 66;">
                <table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left" class="headingLrg">
                            <br style="line-height: 20px;" />
                            <strong>Assign Dictation Team</strong></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="upload">
                <asp:CheckBox ID="chkBacklog" runat="server" Font-Size="11px" ForeColor="Black" Text="Backlog"
                    Visible="False" /><ew:calendarpopup id="CPMain" runat="server" calendarlocation="Bottom"
                        selecteddate="2006-12-01" upperbounddate="9999-12-31" visibledate="2006-12-01"
                        width="119px">
                        <cleardatestyle backcolor="White" font-size="XX-Small" forecolor="Black" font-names="Verdana,Helvetica,Tahoma,Arial" />
                    </ew:calendarpopup>
                <asp:Button ID="btnSearch" runat="server" Text="Search" />&nbsp;
            </td>
        </tr>
        <tr>
            <td class="upload">
                <asp:DropDownList ID="ddlMT" runat="server" Width="100px">
                </asp:DropDownList><asp:DropDownList ID="ddlQC" runat="server" Width="100px">
                </asp:DropDownList><asp:DropDownList ID="ddlPR" runat="server" Width="100px">
                </asp:DropDownList><asp:DropDownList ID="ddlFR" runat="server" Width="100px">
                </asp:DropDownList>
                <asp:Button ID="btnAssign" runat="server" Text="Assign" />&nbsp;
            </td>
        </tr>
        <tr>
        <td>
    <asp:GridView ID="grdcurrent" runat="server" AutoGenerateColumns="False" DataKeyNames="foID,drID"
        SkinID="gridviewSkin" ShowHeader="false" ShowFooter="False">
        <Columns>
            <asp:TemplateField HeaderText="Work Load Detial">
                <ItemTemplate>
                <table width="980" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-color:#bad6ff; font-weight: bold">
                        <td align="center" style="font-family: Verdana; font-size:10pt; height:30px;
                            width: 40px; color: black;">
                            <%#Counter %>
                        </td>
                        <td align="left" style="font-family: Verdana; font-size:10pt; padding-left:5px;
                            width: 260px; color: black; height:30px;">
                            <%#Eval("drID")%>&nbsp;-&nbsp;
                            <%#Eval("drLastName") %>
                            ,
                            <%#Eval("drFirstName") %>
                        </td>
                        <td width="680" style="font-family: Verdana; font-size:10pt;color: black; padding-left:5px; height:30px;">
                            <%#GF.GetMin(Eval("dicLength"))%>
                            &nbsp;[<%#Format(Eval("DicTations"),"000")%>]</td>
                       </tr>
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="GridView1" runat="server" OnRowCreated="GridView1_RowCreated" DataKeyNames="dicID"
                                AutoGenerateColumns="false" SkinId="gridviewSkin" ShowFooter="False" ShowHeader="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="#" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="center" Width="40px" />
                                        <ItemTemplate>
                                            <%#InCounter%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="gridHeadingLeft">
                                        <ItemStyle Width="260px" CssClass="tdspacingLeft" />
                                        <ItemTemplate>
                                            <%#Eval("dicActualName")%><br /><span style="color:Blue;"><%#Eval("dicAccountName")%></span> 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Minutes" HeaderStyle-CssClass="gridHeadingCenter">
                                        <ItemStyle HorizontalAlign="center" Width="100px" />
                                        <ItemTemplate>
                                            <%#GF.GetMin(Eval("dicLength"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MT" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Size="7pt" HeaderStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>
                                            <asp:CheckBox runat="server" ID="chkMT" onClick="CheckAllCheckboxes(this.name,this.checked)" />
                                            <asp:Label runat="Server" ID="lblMTH" Text="MT" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle Width="120px" />
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkMT" Enabled="<%#m_bMTStatus %>" />
                                            <asp:Label ID="lblMT" runat="server" Text="<%#m_sMTName%> " ForeColor='<%#m_cMTColor%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="QC" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Size="7pt" HeaderStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>
                                            <asp:CheckBox runat="server" ID="chkQC" onClick="CheckAllCheckboxes(this.name,this.checked)" />
                                            <asp:Label runat="Server" ID="lblQCH" Text="QC" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle Width="120px" />
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkQC" Enabled="<%#m_bQCStatus %>" />
                                            <asp:Label ID="lblQC" runat="server" Text='<%#m_sQCName%>' ForeColor='<%#m_cQCColor%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PR" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Size="7pt" HeaderStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>
                                            <asp:CheckBox runat="server" ID="chkPR" onClick="CheckAllCheckboxes(this.name,this.checked)" />
                                            <asp:Label runat="Server" ID="lblPRH" Text="PR" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle Width="120px" />
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkPR" Enabled="<%#m_bPRStatus%>" />
                                            <asp:Label ID="lblPR" runat="server" Text='<%#m_sPRName%>' ForeColor='<%#m_cPRColor%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FR" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Size="7pt" HeaderStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>
                                            <asp:CheckBox runat="server" ID="chkFR" onClick="CheckAllCheckboxes(this.name,this.checked)" />
                                            <asp:Label runat="Server" ID="lblFRH" Text="FR" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle Width="120px" />
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkFR" Enabled="<%#m_bFRStatus %>" />
                                            <asp:Label ID="lblFR" runat="server" Text='<%#m_sFRName%>' ForeColor='<%#m_cFRColor%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date" HeaderStyle-CssClass="gridHeadingCenter">
                                        <ItemStyle HorizontalAlign="center" Width="100px" />
                                        <ItemTemplate>
                                            <%#Format(Eval("dicDate"), "dd/MM/yyyy")%>
                                            </td> </tr>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </td></tr></table>
</asp:Content>

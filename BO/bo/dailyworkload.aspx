<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false"
    CodeFile="dailyworkload.aspx.vb" Inherits="dailyworkload" Title ="AccessTek [ Back Office - Admin ]" Theme="BoboLayout" %>

<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <%--<tr>
            <td colspan="2" style ="background-image:url(../images/BOadminHeadingBG.jpg); width:1150px;">
                <table width="100%" align="right" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left" class="headingLrg">
                            <strong>Daily Work Load</strong>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>
        <tr>
            <td class="searchTools">
                <asp:CheckBox ID="chkBaklog" runat="server" AutoPostBack="True" ForeColor="Black" Text="Backlog" />&nbsp;
                <ew:CalendarPopup ID="CPMain" runat="server" AutoPostBack="True" SelectedDate="2006-12-13" VisibleDate="2006-12-13" CalendarLocation="Bottom" Width="103px">
                    <cleardatestyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" forecolor="Black" />
                </ew:CalendarPopup>
            </td>
        </tr>
        
        <tr>
            <td>
                <DBWC:hierargrid id="dgDailyWorkLoad" SkinId="gridviewSkin1" runat="server" loadcontrolmode="UserControl"
                templatedatamode="Table" AutoGenerateColumns="False" GridLines="None" ShowFooter="True">
                 <columns>
                 
                <asp:TemplateColumn HeaderText="#">
                <ItemStyle Width="33px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                <ItemTemplate>
                <%#getCounter1() %>
                </ItemTemplate>
                <HeaderStyle Width="33px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                <EditItemTemplate>
                <asp:TextBox runat="server"></asp:TextBox>
                </EditItemTemplate>
                </asp:TemplateColumn>


                <asp:BoundColumn DataField="drDifficulty" HeaderText="Difficulty">
                    <ItemStyle Width="120px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

                    <FooterStyle HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></FooterStyle>

                    <HeaderStyle Width="120px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                </asp:BoundColumn>


                <asp:BoundColumn DataField="drID" HeaderText="ID">
                    <ItemStyle Width="120px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                    <FooterStyle HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></FooterStyle>
                    <HeaderStyle Width="120px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                </asp:BoundColumn>

                <asp:TemplateColumn HeaderText="Name">
                    <ItemStyle Width="321px" CssClass="tdspacingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                    <ItemTemplate>
                        <%#Eval("drLastName")%>,&nbsp;<%#Eval("drFirstName")%>&nbsp;<%#Eval("drMiddleName")%>
                    </ItemTemplate>
                    <HeaderStyle Width="321px" CssClass="tdspacingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.drFirstName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>


                <asp:TemplateColumn HeaderText="MT Done">
                    <ItemStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                    <ItemTemplate>
                        <%#getMin(Eval("MTdoneMins"))%>
                    </ItemTemplate>
                    <HeaderStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
                </asp:TemplateColumn>


                <asp:TemplateColumn HeaderText="QC Done">
                    <ItemStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                    <ItemTemplate>
                        <%#getMin(Eval("QCdoneMins"))%>
                    </ItemTemplate>
                    <HeaderStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
                </asp:TemplateColumn>


                <asp:TemplateColumn HeaderText="PR Done">
                    <ItemStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                    <ItemTemplate>
                        <%#getMin(Eval("PRdoneMins"))%>
                    </ItemTemplate>
                    <HeaderStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
                </asp:TemplateColumn>

                
                <asp:TemplateColumn HeaderText="FR Done">
                    <ItemStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                    <ItemTemplate>
                        <%#getMin(Eval("FRdoneMins"))%>
                    </ItemTemplate>
                    <HeaderStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
                </asp:TemplateColumn>


                <asp:TemplateColumn HeaderText="Minutes">
                    <ItemStyle Width="122px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

                    <FooterStyle BackColor="#ECECEC" height="18" Width="122px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                    <FooterTemplate>
                        <%#getmin(intNOMDaily)%>
                    </FooterTemplate>
                    <ItemTemplate>
                         <%--<%#getmin(Eval("TotalMinutes"))%>--%>
                         <asp:Label ID="Label1" runat="server" Text='<%# getmin(Eval("TotalMinutes")) %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="122px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Dictations">
                    <ItemStyle Width="124px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                    <FooterStyle BackColor="#ECECEC" height="18" Width="122px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                    <FooterTemplate>
                        <%#intNODDaily%>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TotalDictation") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="122px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                </asp:TemplateColumn>

 
                </columns>
                 </DBWC:hierargrid>
            </td>
        </tr>
                   <%--<tr>
                   <td class="tdspace" colspan="2" style="height: 2px">
                </td>
                </tr>--%>
        <tr>
            <td class="heading" style="height: 25px">
        &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Font-Size="11pt" Text="Backlog" Visible="False"></asp:Label></td>
                </tr>
                <tr>
                <td>
                    <DBWC:hierargrid id="dgDailyWorkloadPending" SkinId="gridviewSkin1" runat="server" loadcontrolmode="UserControl" templatedatamode="Table" AutoGenerateColumns="False" GridLines="None" ShowFooter="True">
                            <columns>
                                <asp:TemplateColumn HeaderText="#">
                                    <ItemStyle Width="40px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                                    <ItemTemplate>
                                        <%#getcounter() %>
                                    </ItemTemplate>

                                    <HeaderStyle Width="40px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>

                                <asp:BoundColumn DataField="drDifficulty" HeaderText="Difficulty">
                                <ItemStyle Width="120px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                                <FooterStyle HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></FooterStyle>
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                                </asp:BoundColumn>

                                <asp:BoundColumn DataField="drID" HeaderText="ID">
                                <ItemStyle Width="120px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                                <HeaderStyle Width="120px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                                </asp:BoundColumn>

                                <asp:TemplateColumn HeaderText="Name">
                                    <ItemStyle Width="320px" CssClass="tdspacingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                                        <ItemTemplate>
                                            <%#Eval("drLastName") %>,&nbsp;<%#Eval("drFirstName")%>&nbsp<%#Eval("drMiddleName") %>
                                        </ItemTemplate>
                                    <HeaderStyle Width="320px" CssClass="tdspacingLeft" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.drFirstName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>


                                <asp:TemplateColumn HeaderText="MT Done">
                                    <ItemStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                                    <ItemTemplate>
                                        <%#getMin(Eval("MTdoneMins"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
                                </asp:TemplateColumn>


                                <asp:TemplateColumn HeaderText="QC Done">
                                    <ItemStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                                    <ItemTemplate>
                                        <%#getMin(Eval("QCdoneMins"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
                                </asp:TemplateColumn>


                                <asp:TemplateColumn HeaderText="PR Done">
                                    <ItemStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                                    <ItemTemplate>
                                        <%#getMin(Eval("PRdoneMins"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
                                </asp:TemplateColumn>

                
                                <asp:TemplateColumn HeaderText="FR Done">
                                    <ItemStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                                    <ItemTemplate>
                                        <%#getMin(Eval("FRdoneMins"))%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="120px" CssClass="tdspacingLeft" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
                                </asp:TemplateColumn>


                                <asp:TemplateColumn HeaderText="Minutes">
                                    <ItemStyle Width="120px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

                                    <FooterStyle BackColor="#ECECEC" height="18" Width="120px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                                    <FooterTemplate>
                                        <%#getmin(intPNOMDaily)%>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# getmin(Eval("TotalMinutes")) %>'></asp:Label>
                                    <%--<%#getmin(Eval("TotalMinutes"))%>--%>
                                    </ItemTemplate>

                                    <HeaderStyle Width="120px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TotalMinutes") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>


                                <asp:TemplateColumn HeaderText="Dictations">
                                    <ItemStyle Width="122px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>

                                    <FooterStyle BackColor="#ECECEC" height="18" Width="122px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                                    <FooterTemplate>
                                        <%#intPNODDaily%>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TotalDictation") %>'></asp:Label>
                                    </ItemTemplate>

                                    <HeaderStyle Width="122px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TotalDictation") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>

                            </columns>
                        </DBWC:hierargrid>
                </td>
            </tr>
        </table>
</asp:Content>

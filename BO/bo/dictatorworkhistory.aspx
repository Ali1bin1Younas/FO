<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="dictatorworkhistory.aspx.vb" Inherits="BO_dictatorworkhistory" Title ="AccessTek [ Back Office - Admin ]" Theme="BoboLayout" %>
<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
        <td class="searchTools">
            <asp:DropDownList ID="ddlDictator" runat="server" DataTextField="Name" DataValueField="UId"></asp:DropDownList>
            <ew:calendarpopup id="cpFrom" runat="server" calendarlocation="Bottom" selecteddate="2006-12-13" visibledate="2006-12-13" width="103px"> <SELECTEDDATESTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKENDSTYLE BackColor="LightGray" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><GOTOTODAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><DAYHEADERSTYLE BackColor="Orange" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><MONTHHEADERSTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><HOLIDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><OFFMONTHSTYLE BackColor="AntiqueWhite" ForeColor="Gray" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><CLEARDATESTYLE forecolor="Black" font-size="XX-Small" font-names="Verdana,Helvetica,Tahoma,Arial" backcolor="White" /><TODAYDAYSTYLE BackColor="LightGoldenrodYellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /></ew:calendarpopup>
            <ew:calendarpopup id="cpTo" runat="server" calendarlocation="Bottom" selecteddate="2006-12-13" visibledate="2006-12-13" width="103px">
                <SELECTEDDATESTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" />
                <WEEKENDSTYLE BackColor="LightGray" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" />
                <GOTOTODAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" />
                <DAYHEADERSTYLE BackColor="Orange" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" />
                <MONTHHEADERSTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" />
                <WEEKDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" />
                <HOLIDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" />
                <OFFMONTHSTYLE BackColor="AntiqueWhite" ForeColor="Gray" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" />
                <CLEARDATESTYLE forecolor="Black" font-size="XX-Small" font-names="Verdana,Helvetica,Tahoma,Arial" backcolor="White" />
                <TODAYDAYSTYLE BackColor="LightGoldenrodYellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" />
            </ew:CalendarPopup>
            <asp:Button ID="btnView" runat="server" Text="View" Width="60px" />
            </td>
        </tr>
        <tr>
            <td>
                <DBWC:HierarGrid  runat="server" ID="gdDictatorWorkHistory" AutoGenerateColumns="False" SkinId="gridviewSkin1" TemplateDataMode="table" ShowFooter="true">
                    <Columns>
                        <asp:TemplateColumn HeaderText="#">
                            <ItemStyle Width="35px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#getCounter()%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        
                        <asp:TemplateColumn HeaderText="Date">
                            <ItemStyle Width="726px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                            <ItemTemplate>
                                <p><%#Convert.ToDateTime(Eval("dicDate")).ToString("dd/MM/yyyy")%> </p>
                            </ItemTemplate>
                            <HeaderStyle Width="726px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>
                         
                        
                        <asp:TemplateColumn HeaderText="Minutes">
                            <ItemStyle Width="160px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                            <FooterStyle BackColor="#ECECEC" height="18px" Width="120px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                            <FooterTemplate>
                                <%#getMin(IntMinutes)%> 
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#getMin(Eval("TotalMinutes"))%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="160px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn> 
                       
                        
                       <asp:TemplateColumn HeaderText="Dictations">
                            <ItemStyle Width="170px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" VerticalAlign="Middle"></ItemStyle>
                            <FooterStyle BackColor="#ECECEC" height="18px" Width="120px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></FooterStyle>
                            <FooterTemplate>
                                <%#IntDictation%> 
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("TotalDictation")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="170px" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        </asp:TemplateColumn>     
                                
                    </Columns>
    </DBWC:HierarGrid>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:40px;height:30px;">
                <asp:Label ID="lblHeading" runat="server" Width="100px"></asp:Label>
                <asp:Label ID="LblData" runat="server" Width="100px"></asp:Label>
            </td>
        </tr>
    </table>
    
    
    
</asp:Content>


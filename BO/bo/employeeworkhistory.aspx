<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="employeeworkhistory.aspx.vb" Inherits="BO_employeeworkhistory" Title ="AccessTek [ Back Office - Admin ]" Theme="BoboLayout" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" cellpadding="0" cellspacing="0" border ="0">
       
        <tr>
            <td class="searchTools">
                <asp:DropDownList ID="ddlEmployee" runat="server" DataTextField="EmployeeName" DataValueField="empID"></asp:DropDownList>
                <asp:DropDownList ID="ddlEmployeeRole" runat="server" DataTextField="rolDescription" DataValueField="rolID"></asp:DropDownList>
                <asp:DropDownList ID="ddlInfo" runat="server">
                    <asp:ListItem Value="DD">Dictation Date</asp:ListItem>
                    <asp:ListItem Value="TD">Transcription Date</asp:ListItem>
                </asp:DropDownList>
                <ew:CalendarPopup ID="cpFrom" runat="server" SelectedDate="2006-12-13" VisibleDate="2006-12-13" CalendarLocation="Bottom" Width="75px" Text="From">
                    <ClearDateStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" ForeColor="Black" />
                </ew:CalendarPopup>
                <ew:CalendarPopup ID="cpTo" runat="server" SelectedDate="2006-12-13" VisibleDate="2006-12-13" CalendarLocation="Bottom" Width="75px" Text="To">
                    <ClearDateStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" ForeColor="Black" />
                </ew:CalendarPopup>
                <asp:Button ID="btnSubmit" runat="server" Text="View" Width="60px" />&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" SkinId="gridviewSkin" runat="server" GridLines ="None" AutoGenerateColumns="False" ShowFooter="True">
        <Columns>
        <asp:TemplateField HeaderText="#" HeaderStyle-CssClass ="gridHeadingCenter">
        <ItemTemplate>
        <%#iCount%>
        </ItemTemplate>
            <ItemStyle Width="40px" HorizontalAlign="Center" />
            <HeaderStyle Width="40px" HorizontalAlign="Center" />
        </asp:TemplateField>
           <asp:BoundField HeaderText="Date" HeaderStyle-CssClass ="gridHeadingCenter" DataField="dicDate">
           <ItemStyle Width="200px" HorizontalAlign="Center" />
            <HeaderStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Dictators" HeaderStyle-CssClass ="gridHeadingCenter" DataField="Dictators" >
            <ItemStyle Width="180px" HorizontalAlign="Center" />
            <HeaderStyle Width="180px" HorizontalAlign="Center" />
        </asp:BoundField>
            <asp:TemplateField HeaderText="Dictations" HeaderStyle-CssClass ="gridHeadingCenter">
            <ItemTemplate>
            <%#Eval("Dictations")%>
            </ItemTemplate>
            <FooterTemplate>
            <%#intTDictations%>
            </FooterTemplate>
            <FooterStyle Width="180px" BackColor="#ECECEC" Height ="18" Font-Bold ="true" HorizontalAlign ="center" />
            <ItemStyle Width="180px" HorizontalAlign="Center" />
            <HeaderStyle Width="180px" HorizontalAlign="Center" />
        </asp:TemplateField>
            <asp:TemplateField HeaderText="Minutes" HeaderStyle-CssClass ="gridHeadingCenter">
            <ItemTemplate>
            <%#getmin(Eval("Minutes"))%>
            </ItemTemplate>
            <FooterTemplate>
            <%#getmin(inttminutes)%>
            </FooterTemplate>
            <FooterStyle Width="200px" BackColor="#ECECEC" Height ="18" Font-Bold ="true" HorizontalAlign ="center" />
            <ItemStyle Width="200px" HorizontalAlign="Center" />
            <HeaderStyle Width="200px" HorizontalAlign="Center" />
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Transcriptions" HeaderStyle-CssClass ="gridHeadingCenter">
            <ItemTemplate>
            <%#Eval("Transcriptions")%>
            </ItemTemplate>
            <FooterTemplate>
            <%#intTTranscriptions%>
            </FooterTemplate>
            <FooterStyle Width="180px" BackColor="#ECECEC" Height ="18" Font-Bold ="true" HorizontalAlign ="center" />
            <ItemStyle Width="180px" HorizontalAlign="Center" />
            <HeaderStyle Width="180px" HorizontalAlign="Center" />
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblHeading" runat="server" Width="158px"></asp:Label>
                <asp:Label ID="LblData" runat="server" Width="158px"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>


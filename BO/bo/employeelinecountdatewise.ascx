<%@Language="VB" AutoEventWireup="false" CodeFile="employeelinecountdatewise.ascx.vb" Inherits="BO_employeelinecountdatewise" %>
<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC" %>
<table>
<tr>
<td style="width:100%">
<DBWC:hierargrid id="gridEmployee" SkinId="gridviewSkin1" runat="server" loadcontrolmode="UserControl"
templatedatamode="Table" AutoGenerateColumns="False" GridLines="None" ShowFooter="True" Width="100%"> 
        <Columns>
            
            <asp:TemplateColumn HeaderText="#">
                <ItemStyle HorizontalAlign="Center" CssClass="" Width="39px" />
                <HeaderStyle HorizontalAlign="Center" CssClass="" Width="39px" />
                <ItemTemplate>
                <%#RowCount%>
                </ItemTemplate>
            </asp:TemplateColumn>
            
            
            <asp:BoundColumn DataField="DicDate" HeaderText="Date">
                <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="193px" />
                <HeaderStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="193px" />
            </asp:BoundColumn>
            
            
            <asp:BoundColumn DataField="Dictations" HeaderText="Dictations">
                <ItemStyle HorizontalAlign="Left" CssClass="" Width="111px" />
                <HeaderStyle HorizontalAlign="Left" CssClass="" Width="111px" />
            </asp:BoundColumn>
            
            
            <asp:TemplateColumn HeaderText="Minutes">
                <ItemStyle HorizontalAlign="Left" CssClass="" Width="85px" />
                <HeaderStyle HorizontalAlign="Left" CssClass="" Width="85px" />
                <ItemTemplate>
                    <%#getmin(Eval("Minutes"))%>
                </ItemTemplate>
            </asp:TemplateColumn>
            
            
            <asp:BoundColumn DataField="Transcriptions" HeaderText="Transcriptions">
                <ItemStyle HorizontalAlign="Left" CssClass="" Width="161px" />
                <HeaderStyle HorizontalAlign="Left" CssClass="" Width="161px" />
            </asp:BoundColumn>
            
            
            <asp:BoundColumn DataField="Lines" HeaderText="Lines">
                <ItemStyle HorizontalAlign="Left" CssClass="" Width="60px" />
                <HeaderStyle HorizontalAlign="Left" CssClass="" Width="60px" />
            </asp:BoundColumn>
            
            
            <asp:TemplateColumn HeaderText="Line Per Minutes">
                <ItemStyle HorizontalAlign="Left" CssClass="" Width="183px" />
                <HeaderStyle HorizontalAlign="Left" CssClass="" Width="183px" />
               <ItemTemplate>
                <%#Line_Per_Minutes(Eval("Minutes"), Eval("Lines"))%>
               </ItemTemplate>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="Line Per Transcriptions">
                <ItemStyle HorizontalAlign="Left" CssClass="" Width="255px" />
                <HeaderStyle HorizontalAlign="Left" CssClass="" Width="255px" />
                <ItemTemplate>
                    <%#Line_Per_Transcriptions(Eval("Transcriptions"), Eval("Lines"))%>
                </ItemTemplate>
            </asp:TemplateColumn>
            
        </Columns>
</DBWC:hierargrid>
</td>
</tr>
</table>
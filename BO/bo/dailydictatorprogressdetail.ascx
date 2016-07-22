<%@ Control Language="VB" AutoEventWireup="false" CodeFile="dailydictatorprogressdetail.ascx.vb" Inherits="dailydictatorprogressdetail"%>
<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC"%>

<table border="0" width="100%" cellpadding="0" cellspacing="0"  >
    <tr>
        <td align="right" valign="top" style="width: 20px; height: 100%;">
        </td>
        <td align="right" style="height: 100%; width:100%;" >

            <dbwc:hierargrid ID="grdDailyProgress" SkinId="gridviewSkin1Small" runat="server" TemplateDataMode="Table" AutoGenerateColumns="False" BorderStyle="None" GridLines="None">
                <Columns>
                
                    <asp:TemplateColumn HeaderText="#">
                        <ItemStyle Width="42px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                        <ItemTemplate>
                           <%#rIndex%>          
                        </ItemTemplate>

                        <HeaderStyle Width="42px" CssClass="gridheadingCenter" HorizontalAlign="Center"></HeaderStyle>
                    </asp:TemplateColumn>
                        
                        
                    <asp:TemplateColumn HeaderText="Dictator Name">
                        <ItemStyle Width="325px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                        <ItemTemplate>
                           <%#Eval("drFirstName")%> , <%#Eval("drLastName")%>           
                        </ItemTemplate>

                        <HeaderStyle Width="325px" CssClass="gridheadingCenter" HorizontalAlign="Center"></HeaderStyle>
                    </asp:TemplateColumn>
                    
                        
                    <asp:BoundColumn DataField="DrID" HeaderText="Dictator ID">
                        <ItemStyle Width="90px" CssClass="tdspacingLeft" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

                        <HeaderStyle Width="90px" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                    </asp:BoundColumn>
                    
                    
                    <asp:TemplateColumn HeaderText="OutStanding Dictations">
                        <ItemStyle Width="148px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                        <ItemTemplate>
                            <p><%#Eval("OutstandingDictations")%> </p>                
                        </ItemTemplate>

                        <HeaderStyle Width="148px" CssClass="gridheadingCenter" HorizontalAlign="Center"></HeaderStyle>
                    </asp:TemplateColumn>
                    

                    <asp:TemplateColumn HeaderText="OutStanding Minutes">
                        <ItemStyle Width="185px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                        <ItemTemplate>
                            <p><%#getmin(Eval("OutstandingMinutes"))%> </p>                
                        </ItemTemplate>

                        <HeaderStyle Width="185px" CssClass="gridheadingCenter" HorizontalAlign="Center"></HeaderStyle>
                    </asp:TemplateColumn>
                    
                    
                    <asp:TemplateColumn HeaderText="Total Dictations">
                        <ItemStyle Width="181px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                        <ItemTemplate>
                            <p><%#Eval("TotalDictation")%> </p>                
                        </ItemTemplate>

                        <HeaderStyle Width="181px" CssClass="gridheadingCenter" HorizontalAlign="Center"></HeaderStyle>
                    </asp:TemplateColumn>
                    

                    <asp:TemplateColumn HeaderText="Total Minutes">
                        <ItemStyle Width="117px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                        <ItemTemplate>
                            <p><%#getmin(Eval("TotalMinutes"))%> </p>                
                        </ItemTemplate>

                        <HeaderStyle Width="117px" CssClass="gridheadingCenter" HorizontalAlign="Center"></HeaderStyle>
                    </asp:TemplateColumn>
                    
                </Columns>
        </dbwc:hierargrid>
    
    </td>
</tr>
</table>

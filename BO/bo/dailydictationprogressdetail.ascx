<%@ Control Language="VB" AutoEventWireup="false" CodeFile="dailydictationprogressdetail.ascx.vb" Inherits="dailydictationprogressdetail"%>
<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC"%>
<table border="0" width="100%" cellpadding="0" cellspacing="0"  >
<tr><td align="right" valign="top" style="width: 20px; height: 100%;"></td>
<td align="right" style="height: 100%; width:100%;" >

    <dbwc:hierargrid ID="grdDailyProgress" SkinId="gridviewSkin1Small" runat="server" autogeneratecolumns="False" loadcontrolmode="UserControl" TemplateDataMode="Table" BorderStyle="None" GridLines="None">
        <Columns>
            <asp:TemplateColumn HeaderText="#">
                <ItemStyle Width="42px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                <ItemTemplate>
                   <%#rIndex%>                
                </ItemTemplate>

                <HeaderStyle Width="42px" CssClass="gridheadingCenter" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateColumn>
                
                
            <asp:TemplateColumn HeaderText="Urgent">
                <ItemStyle Width="80px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                <ItemTemplate>
                   <asp:ImageButton ToolTip="Urgent" ID="ImageButtonDU" Enabled="false" runat="server" ImageUrl=<%#getImage(Eval("dicUrgent").toString())%>/>                
                </ItemTemplate>

                <HeaderStyle Width="80px" CssClass="gridheadingCenter" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateColumn>
            
                
            <asp:BoundColumn DataField="dicActualName" HeaderText="Name">
                <ItemStyle Width="159px" CssClass="tdspacingLeft" Wrap="False" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

                <HeaderStyle Width="159px" CssClass="gridheadingLeft" HorizontalAlign="Left"></HeaderStyle>
            </asp:BoundColumn>
            


            <asp:TemplateColumn HeaderText="Minutes">
                <ItemStyle Width="80px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                <ItemTemplate>
                    <p><%#getmin(Eval("dicLength"))%> </p>       
                </ItemTemplate>

                <HeaderStyle Width="80px" CssClass="gridheadingCenter" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateColumn>


            <asp:TemplateColumn HeaderText="Date">
                <ItemStyle Width="95px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                <ItemTemplate>
                    <p><%#Convert.ToDateTime(Eval("dicDate")).ToString("dd/MM/yyyy")%> </p>              
                </ItemTemplate>

                <HeaderStyle Width="95px" CssClass="gridheadingCenter" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="MT">
                <ItemStyle Width="130px" CssClass="tdspacingLeft" Wrap="False" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                <ItemTemplate>
                    <img alt="MT" src='<%#getLayerDetail(Eval("dicID"), "MT")%>' border=0/>
                    <%#m_sLayerEmployee%>                
                </ItemTemplate>

                <HeaderStyle Width="130px" CssClass="gridheadingLeft" HorizontalAlign="Left"></HeaderStyle>
            </asp:TemplateColumn>


            <asp:TemplateColumn HeaderText="QC">
                <ItemStyle Width="120px" CssClass="tdspacingLeft" Wrap="False" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                <ItemTemplate>
                    <img alt="MT" src='<%#getLayerDetail(Eval("dicID"), "QC")%>' border=0/>
                    <%#m_sLayerEmployee%>                 
                </ItemTemplate>

                <HeaderStyle Width="120px" CssClass="gridheadingLeft" HorizontalAlign="Left"></HeaderStyle>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="PR">
                <ItemStyle Width="120px" CssClass="tdspacingLeft" Wrap="False" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                <ItemTemplate>
                    <img alt="MT" src='<%#getLayerDetail(Eval("dicID"), "PR")%>' border=0/>
                    <%#m_sLayerEmployee%>   
                </ItemTemplate>

                <HeaderStyle Width="120px" CssClass="gridheadingLeft" HorizontalAlign="Left"></HeaderStyle>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="FR">
                <ItemStyle Width="120px" CssClass="tdspacingLeft" Wrap="False" HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                <ItemTemplate>
                    <img alt="MT" src='<%#getLayerDetail(Eval("dicID"), "FR")%>' border=0/>
                    <%#m_sLayerEmployee%>   
                </ItemTemplate>

                <HeaderStyle Width="120px" CssClass="gridheadingLeft" HorizontalAlign="Left"></HeaderStyle>
            </asp:TemplateColumn>
            
            
            <asp:TemplateColumn HeaderText="Status">
                <ItemStyle Width="118px" Wrap="False" HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>
                <ItemTemplate>
                    <%#getStatus(Eval("dicStatus"))%>           
                </ItemTemplate>

                <HeaderStyle Width="118px" CssClass="gridheadingCenter" HorizontalAlign="Center"></HeaderStyle>
            </asp:TemplateColumn>
            
        </Columns>
    </dbwc:hierargrid>
    
</td>
</tr>
</table>

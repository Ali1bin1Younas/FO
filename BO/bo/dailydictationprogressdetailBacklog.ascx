<%@ Control Language="VB" AutoEventWireup="false" CodeFile="dailydictationprogressdetailBacklog.ascx.vb" Inherits="dailydictationdetail"%>
<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC"%>
<table border="0" width="100%" cellpadding="0" cellspacing="0"  >
<tr><td align="right" valign="top" style="width: 20px; height: 100%;"></td>
<td align="right" style="height: 100%; width: 750px;" >
<dbwc:hierargrid ID="grdDailyProgress" SkinId="gridviewSkin1Small" runat="server" AutoGenerateColumns="False" BorderStyle="None" GridLines="None">
            <Columns>
                <asp:BoundColumn DataField="#" HeaderText="#" >
                    <ItemStyle HorizontalAlign="Center" Width="35px" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="gridheadingCenter" Width="35px" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="dicActualName" HeaderText="Name" >
                    <ItemStyle CssClass="tdspacingLeft" HorizontalAlign="Left" Width="165px" />
                    <HeaderStyle CssClass="gridheadingLeft" HorizontalAlign="Left" Width="165px" />
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderText="Date">
                    
                    <ItemTemplate>
                    <p><%#Convert.ToDateTime(Eval("dicDate")).ToString("MM/dd/yyyy")%> </p>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" Width="80px" />
                    <HeaderStyle HorizontalAlign="center" CssClass="gridheadingCenter" Width="80px" />
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="MT">
                     <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="110px" />
                     <HeaderStyle CssClass="gridheadingLeft" HorizontalAlign="Left" Width="110px" />                    
                    <ItemTemplate>
                    <img alt="MT" src='<%#getLayerDetail(Eval("dicID"), "MT")%>' border=0/>
                    <%#m_sLayerEmployee%>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="QC">
                        <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="110px" />
                     <HeaderStyle CssClass="gridheadingLeft" HorizontalAlign="Left" Width="110px" />
                    <ItemTemplate>
                    <img alt="MT" src='<%#getLayerDetail(Eval("dicID"), "QC")%>' border=0/>
                    <%#m_sLayerEmployee%>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="PR">
                    <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="110px" />
                     <HeaderStyle CssClass="gridheadingLeft" HorizontalAlign="Left" Width="110px" />
                    <ItemTemplate>
                    <img alt="MT" src='<%#getLayerDetail(Eval("dicID"), "PR")%>' border=0/>
                    <%#m_sLayerEmployee%>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="FR">
                    <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="110px" />
                     <HeaderStyle CssClass="gridheadingLeft" HorizontalAlign="Left" Width="110px" />
                    <ItemTemplate>
                    <img alt="MT" src='<%#getLayerDetail(Eval("dicID"), "FR")%>' border=0/>
                    <%#m_sLayerEmployee%>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Status">
                    <ItemStyle HorizontalAlign="center" Width="60px" />
                    <HeaderStyle HorizontalAlign="center" CssClass="gridheadingCenter" Width="60px" />
                    <ItemTemplate>
                        <%#getStatus(Eval("dicStatus"))%>
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
         </dbwc:hierargrid>
</td></tr></table>

<%@ Control Language="VB" AutoEventWireup="false" CodeFile="employeesworkloadFullDetail.ascx.vb" Inherits="BO_employeesworkloadFullDetail" %>
<%@ Register Assembly="DBauer.Web.UI.WebControls.HierarGrid" Namespace="DBauer.Web.UI.WebControls" TagPrefix="DBWC" %> 

<table border ="0" width="100%" cellpadding="0" cellspacing="0">

    <tr>
        <td style="width:20px; height: 100%;" >
        </td>
        <td align="right" style=" vertical-align:top; height:100%; width:100%;">
        
            <DBWC:HierarGrid ID="gvDictator" runat="server" AutoGenerateColumns="False" TemplateDataMode="Table" SkinId="gridviewSkinSmaller" ShowHeader="False">
                <Columns>
                    <asp:TemplateColumn HeaderText="#">
                        <ItemTemplate>
                            <%#iCounter %>
                        </ItemTemplate>
                        <ItemStyle Width="39px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle Width="39px" CssClass="gridHeadingCenter" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateColumn>
                    
                    
                    <asp:TemplateColumn HeaderText="Capacity">
                        <ItemTemplate>
                            <%#Eval("rolCapacity")%>
                        </ItemTemplate>
                        <ItemStyle Width="46px" HorizontalAlign="Center" />
                        <HeaderStyle Width="46px" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateColumn>


                    <asp:TemplateColumn HeaderText="Employee ID">
                        <ItemTemplate>
                            <%#UCase(Eval("empID"))%>
                        </ItemTemplate>
                        <ItemStyle Width="65px" CssClass="tdspacingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
                        <HeaderStyle Width="65px" CssClass="gridHeadingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:TemplateColumn>
                    
                    
                    <asp:TemplateColumn HeaderText="Roll">
                        <ItemTemplate>
                            <%#Eval("rolID")%>
                        </ItemTemplate>
                        <ItemStyle Width="440px" CssClass="tdspacingLeft" HorizontalAlign="Left" />
                        <HeaderStyle Width="440px" CssClass="gridHeadingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:TemplateColumn>
                    
                    
                    <asp:TemplateColumn HeaderText="Total">
                        <ItemTemplate>
                            <%#GF.GetMin(Eval("Minutes"))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("Dictations"), "000")%>]
                        </ItemTemplate>
                        <ItemStyle Width="110px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle Width="110px" CssClass="gridHeadingCenter" Font-Bold="True"  HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateColumn>
                    
                    
                    <asp:TemplateColumn HeaderText="Done">
                        <ItemTemplate>
                            <%#GF.GetMin(Eval("doneMinutes"))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("DoneDictations"), "000") %>]
                        </ItemTemplate>
                        <ItemStyle Width="110px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle Width="110px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"/>
                    </asp:TemplateColumn>
                    
                    
                    <asp:TemplateColumn HeaderText="Available">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblAvailMins" ><%#GF.GetMin(Eval("availMinutes"))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("availDictations"), "000")%>]</asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="110px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle Width="110px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"/>
                    </asp:TemplateColumn>
                    
                    
                    <asp:TemplateColumn HeaderText="Outstanding">
                        <ItemTemplate>
                            <%#GF.GetMin(Eval("OutMinutes"))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("OutDictations"), "000")%>]
                        </ItemTemplate>
                        <HeaderStyle Width="110px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle Width="110px" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateColumn>
                    

                    <asp:TemplateColumn HeaderText="">
                        <ItemTemplate>
                        </ItemTemplate>
                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                        <HeaderStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateColumn>

                </Columns>
</DBWC:HierarGrid>
</td></tr></table>

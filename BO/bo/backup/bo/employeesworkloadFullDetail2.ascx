<%@ Control Language="VB" AutoEventWireup="false" CodeFile="employeesworkloadFullDetail2.ascx.vb" Inherits="BO_employeesworkloadFullDetail2" %>
<style type="text/css">
    .lblLeftAlign {
        text-align:left;
        width:auto;
        float:left;
    }
</style>
<table border ="0" width="100%" cellpadding="0" cellspacing="0">

    <tr>
        <td style="width:20px; height: 100%;" >
        </td>
        
        <td align="right" style=" vertical-align:top; height:100%; width: 100%;">
        
            <asp:GridView ID="gvDictator2" runat="server" AutoGenerateColumns="False" SkinId="gridviewSkinSmall" ShowHeader="False">
                <Columns>
                
                    <asp:TemplateField HeaderText="#">
                        <ItemTemplate>
                            <%#iCounter %>
                        </ItemTemplate>
                        <ItemStyle Width="58px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle Width="58px" CssClass="gridHeadingCenter" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="Employee ID">
                        <ItemTemplate>
                            <%#Eval("drID")%>
                        </ItemTemplate>
                        <ItemStyle Width="40px" CssClass="tdspacingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
                        <HeaderStyle Width="40px" CssClass="gridHeadingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="Roll">
                        <ItemTemplate>
                          <asp:Label runat="server" CssClass="lblLeftAlign"> <%#IIf(Eval("drDifficulty") = "", "","(" & Eval("drDifficulty") &")")%>&nbsp;<%#Eval("drLastName")%>, <%#Eval("drFirstName")%></asp:Label> <%#get_mt_qc_pr_fr(Eval("drID"), Eval("empID"))%> 
                        </ItemTemplate>
                        <ItemStyle Width="399px" CssClass="tdspacingLeft" HorizontalAlign="Left" />
                        <HeaderStyle Width="399px" CssClass="gridHeadingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Employee ID">
                        <ItemTemplate>
                            <%#Eval("drSpecialty")%>
                        </ItemTemplate>
                        <ItemStyle Width="110px" CssClass="tdspacingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
                        <HeaderStyle Width="110px" CssClass="gridHeadingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <%#GF.GetMin(Eval("DicLength"))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("DicTations"), "000")%>]
                        </ItemTemplate>
                        <ItemStyle Width="110px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle Width="110px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>


                    
                    
                    <asp:TemplateField HeaderText="Done">
                        <ItemTemplate>
                            <%#GF.GetMin(Eval("donedicLength"))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("DoneDictations"), "000") %>]
                        </ItemTemplate>
                        <ItemStyle Width="110px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle Width="110px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"/>
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="Available">
                        <ItemTemplate>
                            <%#GF.GetMin(Eval("availdicLength"))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("availDictations"), "000")%>]
                        </ItemTemplate>
                        <ItemStyle Width="110px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle Width="110px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"/>
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="Outstanding">
                        <ItemTemplate>
                            <%#GF.GetMin(Eval("OutdicLength"))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("OutDicTations"), "000")%>]
                        </ItemTemplate>
                        <HeaderStyle Width="110px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle Width="110px" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                        </ItemTemplate>
                        <HeaderStyle Width="70px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
            
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>

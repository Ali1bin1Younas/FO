<%@ Control Language="VB" AutoEventWireup="false" CodeFile="employeesworkloadFullDetail2.ascx.vb" Inherits="BO_employeesworkloadFullDetail2" %>
<style type="text/css">
    .lblLeftAlign {
        text-align:left;
        width:auto;
        float:left;
        height: 100%;
        position: relative;
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
                        <ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle Width="20px" CssClass="gridHeadingCenter" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="Employee ID">
                        <ItemTemplate>
                            <%#Eval("drID")%>
                        </ItemTemplate>
                        <ItemStyle Width="33px" CssClass="tdspacingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
                        <HeaderStyle Width="33px" CssClass="gridHeadingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="Roll">
                        <ItemTemplate>
                          <asp:Label runat="server" CssClass="lblLeftAlign" ><span style="position: absolute;top: 30%;width: 130px;"> <%#IIf(Eval("drDifficulty") = "", "","(" & Eval("drDifficulty") &")")%>&nbsp;<%#Eval("drLastName")%>, <%#Eval("drFirstName")%></span></asp:Label> <%#get_mt_qc_pr_fr(Eval("drID"), Eval("empID"), Eval("rolID"))%> 
                        </ItemTemplate>
                        <ItemStyle Width="392px" CssClass="tdspacingLeft" HorizontalAlign="Left" />
                        <HeaderStyle Width="392px" CssClass="gridHeadingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Employee ID">
                        <ItemTemplate>
                            <%#Eval("drSpecialty")%>
                        </ItemTemplate>
                        <ItemStyle Width="105px" CssClass="tdspacingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
                        <HeaderStyle Width="105px" CssClass="gridHeadingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <%#GF.GetMin(Eval("DicLength"))%>&nbsp;&nbsp;[<%#Format(Eval("DicTations"), "000")%>]
                        </ItemTemplate>
                        <ItemStyle Width="99px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle Width="99px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>


                    
                    
                    <asp:TemplateField HeaderText="Done">
                        <ItemTemplate>
                            <%#GF.GetMin(Eval("donedicLength"))%>&nbsp;&nbsp;[<%#Format(Eval("DoneDictations"), "000") %>]
                        </ItemTemplate>
                        <ItemStyle Width="97px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle Width="97px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"/>
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="Available">
                        <ItemTemplate>
                            <%#GF.GetMin(Eval("availdicLength"))%>&nbsp;&nbsp;[<%#Format(Eval("availDictations"), "000")%>]
                        </ItemTemplate>
                        <ItemStyle Width="98px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle Width="98px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"/>
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="Outstanding">
                        <ItemTemplate>
                            <%#GF.GetMin(Eval("OutdicLength"))%>&nbsp;&nbsp;[<%#Format(Eval("OutDicTations"), "000")%>]
                        </ItemTemplate>
                        <HeaderStyle Width="95px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle Width="95px" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                        </ItemTemplate>
                        <HeaderStyle Width="48px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle Width="48px" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
            
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>

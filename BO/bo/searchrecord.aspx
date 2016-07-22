<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="searchrecord.aspx.vb" Inherits="FO_searchrecord" Title =" AccessTek [ Back Office - Employee ]" Theme="BOboLayout"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="980" cellpadding="0" cellspacing="0" border="0">
         <tr>
            <td style ="background-image:url(../images/BOadminHeadingBG.jpg); width :980; height :66;"><table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
            <tr><td align="left" class="headingLrg"><br style="line-height:20px;"/><strong>Search Results</strong></td></tr>
         </table></td>
        </tr>
         <tr>
            <td class="tdPageLinkText" align="right">
                <a class="pageLink" href="search.aspx">Back</a>&nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td class="tdspace" style="height: 2px"></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Verdana" Font-Size="8pt"
                    ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="height: 19px">
                &nbsp;&nbsp;<asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="11px" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdMain" SkinId="gridviewSkin" runat="server" AutoGenerateColumns="False" BorderStyle="None" GridLines="None" PageSize="1" DataKeyNames="drID,dicID,traID,foID,traName" >
                   
                    <Columns>
                        <asp:TemplateField >
                            <%--<HeaderStyle HorizontalAlign="Center" />
                            <HeaderTemplate   >
                            
                             <asp:CheckBox ID="chkheadder" runat="server"  />
                            </HeaderTemplate>--%>
                            <ItemTemplate>
                                <%--<asp:CheckBox ID="chk1" runat="server" />--%>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%#tagImage(eval("traTag")) %>' />
                            </ItemTemplate>
                            <ItemStyle Width="20px" HorizontalAlign="Center" />
                            <HeaderStyle Width="20px" CssClass ="gridHeadingCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="#" HeaderStyle-CssClass="gridHeadingCenter">
                            <ItemTemplate>
                                <p>
                                    <% =getCounter()%>
                                </p>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                            <HeaderStyle Width="40px" CssClass="gridHeadingCenter" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID">
                        <ItemTemplate >
                          <%#Eval("foID") %> - <%#Eval("drID") %> 
                        </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" Width="90px" />
                      <HeaderStyle Width="90px" CssClass="gridHeadingCenter" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="dicActualName" HeaderText="Dictation Name" HeaderStyle-CssClass="gridHeadingLeft">
                        <HeaderStyle Width="380px" HorizontalAlign="Left" CssClass="tdspacingLeft" />
                            <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="380px"/>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Patient Name" HeaderStyle-CssClass="gridHeadingLeft">
                        <HeaderStyle HorizontalAlign="Left" Width="245px" />
                            <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="245px" />
                            <ItemTemplate>
                                <%# Eval("traPatLastName")%>,
                                
                                <%# EVal("traPatFirstName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="locDescription" HeaderText="Location" HeaderStyle-CssClass="gridHeadingCenter">
                            <HeaderStyle HorizontalAlign="Center" Width="85px" />
                            <ItemStyle HorizontalAlign="Left" CssClass="tdspacingLeft" Width="85px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Date" HeaderStyle-CssClass="gridHeadingCenter">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("dicDate") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("dicDate", "{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="90px" />
                            <HeaderStyle Width="90px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="gridHeadingCenter">
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                        <HeaderStyle Width="30px"/>
                        <ItemTemplate >
                          <asp:ImageButton ID="ImageButtonStatus" runat="server" ImageUrl="~/images/view.gif" CommandName ="View" />
                        </ItemTemplate>
                        
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
        <td class="tdspace" height="2"></td>
        </tr>
        <tr>
        <td><img src="../images/spacer.gif" height="3"/></td>
        </tr>
       <%-- <tr>--%>
            <%--<td align="right" style="padding-right:25px; vertical-align:middle;">--%>
              <%--  <asp:ImageButton  ID="sendmail" runat="server" ImageUrl="~/images/email.gif" ToolTip="Send Mail" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
              <%--  <asp:ImageButton  ID="btnResend" runat="server" ImageUrl="~/images/resend.gif" ToolTip="Resend" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                <%--<asp:ImageButton ID="ImageButtonDownall" runat="server"  ImageUrl="~/images/downloadall.gif" ToolTip="Download All" />--%>
               <%-- </td>--%>
        <%--</tr>--%>
        <tr>
        <td><img src="../images/spacer.gif" height="5" /></td>
        </tr>
    </table>
</asp:Content>



<%@ Page Language="VB" MasterPageFile="~/bo/master.master" AutoEventWireup="false" CodeFile="boMacros.aspx.vb" Inherits="bo_boMacros" Theme="BOboLayout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table width="100%" cellspacing="0" border="0" cellpadding="0">
        <tr>
            <td align="left">
                <fieldset style="width:100%; float:left;">
                <legend>Marcos</legend>
                    <table width="100%" cellspacing="0" border="0" cellpadding="0">
                        <tr>
                            <td>
                                <div style="padding:10px; text-align:right;">
                                    <asp:FileUpload runat="server" ID="btn_select_macro" ToolTip="Select Macro file"/>
                                    <asp:Button runat="server" ID="btn_upload_macro" ToolTip="Upload Macro file" Text="Upload"/>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lbl_error" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView runat="server" ID="gv_macros" skinID="gridviewSkin" AutoGenerateColumns="false" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField HeaderText="#" HeaderStyle-CssClass="gridheadingCenter">
                                            <ItemTemplate>
                                                <%#rowCount %>
                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Macro Name" HeaderStyle-CssClass="gridheadingCenter">
                                            <ItemTemplate>
                                                <%#Eval("mcName")%>
                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Left" Width="450px" CssClass="tdspacingLeft"/>
                                            <HeaderStyle HorizontalAlign="Left" Width="450px" CssClass="tdspacingLeft"/>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="option" HeaderStyle-CssClass="gridheadingCenter">
                                            <ItemTemplate>
                                                <%--<img runat="server" id="img_mcDefault" />--%>
                                                <asp:ImageButton runat="Server" ID="img_mcDefault" Height="16px" Width="16px" OnClick="btnDelTran_Click" CommandName="Changestatus" CommandArgument='<%# Eval("mcID") %>'></asp:ImageButton>
                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>

</asp:Content>

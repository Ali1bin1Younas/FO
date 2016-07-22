<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="dictationtools.aspx.vb" Inherits="BO_dictationtools" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">
        ////////// Checkboxes Check/Uncheck  ///////////

        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        //If the header checkbox is checked
                        inputList[i].checked = true;
                    }
                    else {
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="searchTools">
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="font-family:Verdana; font-size:12px;">
                <tr>
                    <td>Keyword</td>
                    <td>Account</td>
                    <td>Dictator</td>
                    <td>Employee</td>
                    <td>From</td>
                    <td>To</td>
                    <td>Status</td>
                    <td>Sorting</td>
                    <td></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="txtDictation" runat="server" Width="94px"></asp:TextBox></td>
                    <td><asp:DropDownList ID="ddlLocation" runat="server" Height="18px" Width="190px"></asp:DropDownList></td>
                    <td><asp:DropDownList ID="ddlDictator" runat="server" DataTextField="DictatorName" DataValueField="UId" Height="18px" Width="200px"></asp:DropDownList></td>
                    <td><asp:DropDownList ID="ddlEmployee" runat="server" Height="18px" Width="190px"></asp:DropDownList></td>
                    <td><ew:calendarpopup id="CPFrom" runat="server" Text="" nullable="True" Width="60px"><CLEARDATESTYLE forecolor="Black" font-size="XX-Small" font-names="Verdana,Helvetica,Tahoma,Arial" backcolor="#ECECEC" /><SELECTEDDATESTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKENDSTYLE BackColor="LightGray" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><GOTOTODAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><DAYHEADERSTYLE BackColor="Orange" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><MONTHHEADERSTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><HOLIDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><OFFMONTHSTYLE BackColor="AntiqueWhite" ForeColor="Gray" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><TODAYDAYSTYLE BackColor="LightGoldenrodYellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /></ew:calendarpopup></td>
                    <td><ew:calendarpopup id="CpTo" runat="server" Text="" nullable="True" width="60px"><CLEARDATESTYLE forecolor="Black" font-size="XX-Small" font-names="Verdana,Helvetica,Tahoma,Arial" backcolor="#ECECEC" /><SELECTEDDATESTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKENDSTYLE BackColor="LightGray" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><GOTOTODAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><DAYHEADERSTYLE BackColor="Orange" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><MONTHHEADERSTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><HOLIDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><OFFMONTHSTYLE BackColor="AntiqueWhite" ForeColor="Gray" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><TODAYDAYSTYLE BackColor="LightGoldenrodYellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /></ew:calendarpopup></td>
                    <td><asp:DropDownList ID="ddlStatus" runat="server" Height="18px"></asp:DropDownList></td>
                    <td><asp:DropDownList ID="ddlSorting" runat="server" Height="18px"></asp:DropDownList></td>
                    <td align="right"><asp:Button ID="btnSearch" runat="server" Text="View" Width="70px" /></td>
                </tr>
            </table>
            </td>
        </tr>
        <tr>
            <td class="searchTools">
                <% If gvDictation.Rows.Count > 0 Then%>
                    <%--<asp:Button ID="btnReupload1" runat="server" Text="Re-Upload" Width="80px" ToolTip="Reupload or clear dictation" />
                    <asp:Button ID="btnReset1" runat="server" Text="Reset" Width="70px" ToolTip="Reset dictation to its orginal status" />
                    <asp:Button ID="btnDelete1" runat ="server" Text="Delete" Width="70px" ToolTip="Mark dictation as deleted" />--%>
                    <asp:Button ID="btnRestore1" runat ="server" Text="Restore" Width="70px" ToolTip="Restore deleted dictations" />
                    <asp:Button ID="btnPurge1" runat ="server" Text="Purge" Width="70px" ToolTip="Purge deleted dictations" />
                <%End If%>
            </td>
        </tr>
        <tr>
    <td>
    <asp:GridView ID="gvDictation" SkinId="gridviewSkin" runat="server" AutoGenerateColumns="False" Width="1000px" DataKeyNames="dicId,dicActualName,dicLength,dicEnable,dicDuplicateCheck">
        <Columns>
            <asp:TemplateField HeaderText="#">
            <ItemTemplate>
            <%#Row_Counter %>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="30px" />
            <HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="gridHeadingCenter" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="">
                <headerTemplate>
                    <asp:CheckBox runat="server" ID="chkTransAll" onclick="checkAll(this);" />
                </headerTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkDictation" runat="server" Width ="12" Height ="12" />
                    <asp:Label ID="lblDicID" runat="server" Width="31px" Visible="false" Text='<%#Eval("dicID")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="30px" />
                <HeaderStyle HorizontalAlign="Center" Width="30px" CssClass="gridHeadingCenter" />
            </asp:TemplateField>
            

            <asp:TemplateField HeaderText="Dictator ID">
                <ItemTemplate>
                <%#Eval("foId")%>-<%#Eval("drId")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="80px" />
                <HeaderStyle HorizontalAlign="Center" Width="80px" CssClass="gridHeadingCenter" />
            </asp:TemplateField>

            <asp:BoundField DataField="dicAccountName" HeaderText="Account" >
                <ItemStyle Width="150px" Wrap="False" CssClass="tdspacingLeft" />
                <HeaderStyle Width="150px" CssClass="gridHeadingLeft" />
            </asp:BoundField>

            <asp:TemplateField HeaderText="Date" HeaderStyle-CssClass="gridHeadingCenter">
                <ItemStyle HorizontalAlign="center" Width="80px" />
                <ItemTemplate>
                    <%#Convert.ToDateTime(Eval("dicDate")).ToString("dd/MM/yyyy")%>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:BoundField DataField="dicActualName" HeaderText="Dictation Name" >
                <ItemStyle Width="140px" Wrap="False" CssClass="tdspacingLeft" />
                <HeaderStyle Width="140px" CssClass="gridHeadingLeft" />
            </asp:BoundField>


           <asp:TemplateField HeaderText="Minutes">
                <ItemTemplate>
                    <%#getMin(Eval("dicLength"))%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="60px" />
                <HeaderStyle HorizontalAlign="Center" Width="60px" CssClass="gridHeadingCenter" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="MT">
            <ItemTemplate>
            <asp:Label runat="server" ID="lblMt" Text='<%#m_sMTName %>' ForeColor='<%#m_cMTColor %>'/>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="80px" CssClass="tdspacingLeft" />
             <HeaderStyle HorizontalAlign="Left"  Width="80px" CssClass="gridHeadingLeft" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="QC">
            <ItemTemplate>
            
            <asp:Label runat="server" ID="lblQc" Text='<%#m_sQCName %>' ForeColor='<%#m_cQCColor %>'/>
            
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="80px" CssClass="tdspacingLeft" />
                <HeaderStyle HorizontalAlign="Left" Width="80px" CssClass="gridHeadingLeft" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="PR">
            <ItemTemplate>
            
            <asp:Label runat="server" ID="lblPr" Text='<%#m_sPRName %>' ForeColor='<%#m_cPRColor %>'/>
            
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="80px" CssClass="tdspacingLeft" />
                <HeaderStyle HorizontalAlign="Left" Width="80px" CssClass="gridHeadingLeft" />
            
            </asp:TemplateField>


            <asp:TemplateField HeaderText="FR">
                <ItemTemplate>
            
                <asp:Label runat="server" ID="lblFr" Text='<%#m_sFRName %>' ForeColor='<%#m_cFRColor %>'/>
            
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="80px" CssClass="tdspacingLeft" />
                    <HeaderStyle HorizontalAlign="Left" Width="80px" CssClass="gridHeadingLeft" />
            </asp:TemplateField>


            <%--<asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <%#Status(Eval("dicStatus"))%>
                    <asp:Label ID="lblDicStatus" runat="server" Width="31px" Visible="false" Text='<%#Status(Eval("dicStatus"))%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80px" HorizontalAlign="Center" />
                <HeaderStyle Width="80px" CssClass="gridHeadingCenter" />
            </asp:TemplateField>         
            <asp:TemplateField HeaderText="Reupload">
            <ItemTemplate>
            <asp:CheckBox ID="cbReupload" runat="server" Width ="12" Height ="12" />
                
            </ItemTemplate>
            
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete">
            <ItemTemplate>
            <asp:CheckBox ID="cbDelete" runat="server" Width ="12" Height ="12" />
            <asp:Label ID="lblDicId1" runat="server" Width="31px" Visible="False" Text='<%#Eval("dicId")%>'></asp:Label>
            </ItemTemplate>
            
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Options">
                <ItemTemplate>
                    <asp:ImageButton runat="server" ID="ChangeMin" Width="22" ToolTip="Change dictation minutes" ImageUrl="~/images/change-minutes.png" />
                    <asp:ImageButton runat="server" ID="btnDuplicate" Width="18" ToolTip="It may be a duplicate dictation" ImageUrl="~/images/duplicate.png" Visible="false" />
                    <asp:ImageButton runat="server" ID="imgDummy" Width="18" ImageUrl="~/images/dummy.jpg" Visible="false" />
                    <asp:ImageButton runat="server" ID="btnDuplicateCheck" Width="18" ToolTip="It may be a duplicate dictation" ImageUrl="~/images/duplicate-check.png" Visible="false" />
                </ItemTemplate>
                <ItemStyle Width="60px" HorizontalAlign="Center" />
                <HeaderStyle Width="60px" CssClass="gridHeadingCenter" />
            </asp:TemplateField>--%>
            
        </Columns>
    </asp:GridView>
    
    </td>
    </tr>
    <tr>
        <td align="right" style="padding-right:5px; height:50px; vertical-align:middle;">
            <% If gvDictation.Rows.Count > 0 Then%>
                    <%--<asp:Button ID="btnReupload" runat="server" Text="Re-Upload" Width="80px" ToolTip="Reupload or clear dictation" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset" Width="70px" ToolTip="Reset dictation to its orginal status" />
                    <asp:Button ID="btnDelete" runat ="server" Text="Delete" Width="70px" ToolTip="Mark dictation as deleted" />--%>
                    <asp:Button ID="btnRestore" runat ="server" Text="Restore" Width="70px" ToolTip="Restore deleted dictations" />
                    <asp:Button ID="btnPurge" runat ="server" Text="Purge" Width="70px" ToolTip="Purge deleted dictations" />
                <%End If%>
        </td>
    </tr>
    </table>
</asp:Content>


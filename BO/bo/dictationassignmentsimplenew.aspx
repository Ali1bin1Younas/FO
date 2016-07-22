<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="dictationassignmentsimplenew.aspx.vb" Inherits="BO_singleassign2" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="js/dictationAssignmentSimpleNew.js"></script>
    <style type="text/css">
        .roles_styling {
            border-top-left-radius: 40px;
            border-top-right-radius:40px;
            border-bottom-left-radius: 40px;
            border-bottom-right-radius:40px;
            background-color:white;font-size:12px;text-align:center; color:#b9bcc0;
            padding:5px;vertical-align:middle;
            border:1px solid #b9bcc0;
            margin:5px;
        }

        .roles_styling_enable {
            border-top-left-radius: 40px;
            border-top-right-radius:40px;
            border-bottom-left-radius: 40px;
            border-bottom-right-radius:40px;
            background-color:white;font-size:12px;text-align:center; color:#b9bcc0;
            padding:5px;vertical-align:middle;
            border:1px solid #02ceff;
            color:#02ceff;
            cursor:pointer;
            fill:#02ceff;
            margin:5px;
        }
        

        .roleAlignment {
            width:106px;
            background-color:transparent !important;
        }

        .roleAlignment > span> input[type=button] {
            color:black;
            
            font-family:Verdana;
        }
        .display-non {
            display:none;
        }
        #overlay
        {
            position: absolute;
            left: 0;
            top: 0;
            bottom: 0;
            right: 0;
            background: #fff;
            opacity: 0.8;
            filter: alpha(opacity=80);
        }
        
    #loading {
        left: 50%;
        position: fixed;
        top: 50%;
    }

    .tdSpacingRightOptions {
        padding-right:25px;
    }

</style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

    <table width="100%" border="0" cellspacing="0" cellpadding="0" onkeydown="return (event.keyCode!=13)">
        <tr>
            <td class="searchTools" style="padding-right:13px;">
                <asp:CheckBox ID="chkShowAll" runat="server" Font-Size="11px" ForeColor="Black" Text="Show All" Visible="true" />&nbsp;
                <ew:calendarpopup id="CPMain" runat="server" calendarlocation="Bottom" upperbounddate="9999-12-31" width="119px" Nullable="True">
                        <cleardatestyle backcolor="White" font-size="XX-Small" forecolor="Black" font-names="Verdana,Helvetica,Tahoma,Arial" />
                </ew:calendarpopup>
                <asp:Button ID="btnSearch" runat="server" Text="Search" style="width:80px;"/>
            </td>
        </tr>

        <tr>
        <td>
        <asp:GridView ID="grdcurrent" runat="server" AutoGenerateColumns="False" DataKeyNames="foID,drID" SkinID="gridviewSkin" ShowHeader="false" ShowFooter="False">
        <Columns>
            <asp:TemplateField HeaderText="Work Load Detail">
                <ItemTemplate>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr style="background-color:#bad6ff;">
                        <td align="left" style="width:35%;">
                            <table id="tblDictatorDetail">
                                <tr style="background-color:#bad6ff; font-weight: bold">
                                    <td align="center" style="font-family: Verdana; font-size:10pt; height:30px; width: 30px; color: black;">
                                        <label id="lblCounter"><%#Counter %></label>
                                    </td>

                                    <td align="left" style="font-family: Verdana; font-size:10pt; padding-left:5px; width: 230px; color: black; height:30px;">
                                        <label id="lblDrID"><%#Eval("drID")%></label>&nbsp;-&nbsp;
                                        <label id="lblDrName"><%#Eval("drLastName") %>, <%#Eval("drFirstName") %></label>
                                    </td>

                                    <td style="font-family: Verdana; font-size:10pt;color: black; padding-left:5px; height:30px;">
                                        <label id="lblTotalOutDicLength"><%#GF.GetMin(Eval("outDicLength"))%></label>
                                        &nbsp;[<label id="lblTotalOutDics" class="lblTotalOutDics"><%#Format(Eval("outDicTations"), "000")%></label>]
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:55%; text-align:right;" align="right">
                            <table id="tblList">
                                <tr>
                                    <td id="tdLoading">

                                    </td>
                                    <td class="roleAlignment" style="vertical-align:middle;">
                                        <ew:calendarpopup id="CPDateMT" runat="server" Visible="true" calendarlocation="Bottom" ClearDateStyle-CssClass="display-non" upperbounddate="9999-12-31" width="71px" Nullable="True" Text="MT">
                                            <cleardatestyle backcolor="White" font-size="XX-Small" forecolor="Black" font-names="Verdana,Helvetica,Tahoma,Arial" />
                                        </ew:calendarpopup>

                                        <asp:DropDownList ID="ddlMT" runat="server" Visible="true" Width="102px"></asp:DropDownList>
                                    </td>
                                    <td class="roleAlignment" >
                                        <ew:calendarpopup id="CPDateQC" runat="server" Visible="true" calendarlocation="Bottom" ClearDateStyle-CssClass="display-non" upperbounddate="9999-12-31" width="71px" Nullable="True" Text="QC">
                                            <cleardatestyle backcolor="White" font-size="XX-Small" forecolor="Black" font-names="Verdana,Helvetica,Tahoma,Arial" />
                                        </ew:calendarpopup>

                                        <asp:DropDownList ID="ddlQC" runat="server" Visible="true" Width="102px"></asp:DropDownList>
                                        
                                    </td>
                                    <td class="roleAlignment" >
                                        <ew:calendarpopup id="CPDatePR" runat="server" Visible="true" calendarlocation="Bottom" ClearDateStyle-CssClass="display-non" upperbounddate="9999-12-31" width="71px" Nullable="True" Text="PR">
                                            <cleardatestyle backcolor="White" font-size="XX-Small" forecolor="Black" font-names="Verdana,Helvetica,Tahoma,Arial" />
                                        </ew:calendarpopup>

                                        <asp:DropDownList ID="ddlPR" runat="server" Visible="true" Width="100px"></asp:DropDownList>
                                    </td>
                                    <td  class="roleAlignment" >
                                        <ew:calendarpopup id="CPDateFR" runat="server" Visible="true" calendarlocation="Bottom" ClearDateStyle-CssClass="display-non" upperbounddate="9999-12-31" width="71px" Nullable="True" Text="FR">
                                            <cleardatestyle backcolor="White" font-size="XX-Small" forecolor="Black" font-names="Verdana,Helvetica,Tahoma,Arial" />
                                        </ew:calendarpopup>

                                        <asp:DropDownList ID="ddlFR" runat="server" Visible="true" Width="100px"></asp:DropDownList>
                                    </td>
                                    <td class="roleAlignment" style="text-align:center; vertical-align:middle;">
                                        <input type="button" id="btnAssign" onclick="assignDictation_click(this)" value="Assign" style="width:80px;"/>
                                    </td>
                                    <td style="text-align:right; padding-right:10px; vertical-align:middle; width:150px;">
                                        <input type="button" id="btnDel" title="Mark Dictation as Deleted" onClick="btn_mark_dictation_delete(this);" value="Delete" style="width:80px;"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="GridView1" runat="server" OnRowCreated="GridView1_RowCreated" OnRowCommand="GridView1_RowCommand" DataKeyNames="dicID,dicActualName,dicLength,dicDuplicateCheck"
                                AutoGenerateColumns="false" SkinId="gridviewSkin" ShowFooter="False" ShowHeader="true">
                                <Columns>
                                
                                    <asp:TemplateField HeaderText="#" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="center" Width="30px" />
                                        <ItemTemplate>
                                            <label id="lblCounter"><%#InCounter%></label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="center">
                                        <HeaderTemplate>
                                            <asp:CheckBox runat="server" ID="chkDicH" onClick="checkAllDics(this,this.checked)" />
                                        </HeaderTemplate>
                                        <ItemStyle Width="30px" />
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkDic" onClick="setHeaderCheck(this,this.checked)"/>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="gridHeadingLeft">
                                        <ItemStyle CssClass="tdspacingLeft" />
                                        <ItemTemplate>
                                            <label id="lblDicActualName"><%#Eval("dicActualName")%></label><br /><label id="lblDicAccountName"><span style="color:Blue;"><%#Eval("dicAccountName")%></span></label> 
                                        </ItemTemplate>
                                        <ItemStyle Width="305px"/>
                                    </asp:TemplateField>
                                    
                                    
                                    <asp:TemplateField HeaderText="Minutes" HeaderStyle-CssClass="gridHeadingCenter">
                                        <ItemStyle HorizontalAlign="center" Width="70px" />
                                        <ItemTemplate>
                                           <label id="lblDicLength"> <%#GF.GetMin(Eval("dicLength"))%></label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="MT" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Size="7pt" HeaderStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>
                                            <asp:CheckBox runat="server" ID="chkMT" onClick="checkAll(this,this.checked)" />
                                            <asp:Label runat="Server" ID="lblMTH" Text="MT" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle Width="107px" />
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkMT" onClick="setHeaderCheck(this,this.checked)" Enabled="<%#m_bMTStatus%>" />
                                            <asp:Label ID="lblMT" runat="server" Text='<%#m_sMTName%>' ForeColor='<%#m_cMTColor%>'></asp:Label>
                                            <br />&nbsp&nbsp&nbsp<asp:Label id="lblMTDate" style="color:#808080;font-size:9px;" runat="server" Text='<%#IIf(m_sMTName = "-", "", getWorloadDate(Eval("dicID"), "MT"))%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="QC" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Size="7pt" HeaderStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>
                                            <asp:CheckBox runat="server" ID="chkQCH" onClick="checkAll(this,this.checked)" />
                                            <asp:Label runat="Server" ID="lblQCH" Text="QC" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle Width="107px" />
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkQC" onClick="setHeaderCheck(this,this.checked)" Enabled="<%#m_bQCStatus %>" />
                                            <asp:Label ID="lblQC" runat="server" Text='<%#m_sQCName%>' ForeColor='<%#m_cQCColor%>'></asp:Label>
                                            <br />&nbsp&nbsp&nbsp<asp:Label ID="lblQCDate" runat="server" style="color:#808080;font-size:9px;"><%#IIf(m_sQCName = "-", "",getWorloadDate(Eval("dicID"), "QC"))%></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="PR" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Size="7pt" HeaderStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>
                                            <asp:CheckBox runat="server" ID="chkPRH" onClick="checkAll(this,this.checked)" />
                                            <asp:Label runat="Server" ID="lblPRH" Text="PR" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle Width="107px" />
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkPR" onClick="setHeaderCheck(this,this.checked)" Enabled="<%#m_bPRStatus%>" />
                                            <asp:Label ID="lblPR" runat="server" Text='<%#m_sPRName%>' ForeColor='<%#m_cPRColor%>'></asp:Label>
                                            <br />&nbsp&nbsp&nbsp<asp:Label ID="lblPRDate" runat="server" style="color:#808080;font-size:9px;"><%# IIf(m_sPRName = "-", "",getWorloadDate(Eval("dicID"), "PR"))%></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="FR" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Size="7pt" HeaderStyle-VerticalAlign="Middle">
                                        <HeaderTemplate>
                                            <asp:CheckBox runat="server" ID="chkFRH" onClick="checkAll(this,this.checked)" />
                                            <asp:Label runat="Server" ID="lblFRH" Text="FR" Font-Bold="true"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle Width="107px" />
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkFR" onClick="setHeaderCheck(this,this.checked)" Enabled="<%#m_bFRStatus %>" />
                                            <asp:Label ID="lblFR" runat="server" Text='<%#m_sFRName%>' ForeColor='<%#m_cFRColor%>'></asp:Label>
                                            <br />&nbsp&nbsp&nbsp<asp:Label ID="lblFRDate" runat="server" style="color:#808080;font-size:9px;"><%#IIf(m_sFRName = "-", "",getWorloadDate(Eval("dicID"), "FR"))%></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Date" HeaderStyle-CssClass="gridHeadingCenter">
                                        <ItemStyle HorizontalAlign="center" Width="100px" />
                                        <ItemTemplate>
                                            <%#Format(Eval("dicDate"), "dd/MM/yyyy")%>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    
                                    <asp:TemplateField HeaderText="Options" HeaderStyle-CssClass="gridHeadingCenter">
                                        <ItemStyle Width="130px" HorizontalAlign="right" CssClass="tdSpacingRightOptions"/>
                                        <ItemTemplate>
                                            
                                            <a  id="btnDuplicate" title="Duplicate dictation" <%#IIf(dicID_val = false, "style='display:none;'","")%> onClick="btn_duplicate(this,<%#Eval("dicID") %>);" ><img alt="Duplicate" id="img_btDuplicate<%#Eval("dicID") %>" <%#IIf(Eval("dicDuplicateCheck") = False, "src='../images/duplicate.png'", "src='../images/duplicate-check.png'")%> /></a>
                                            <asp:ImageButton runat="server" ID="btnDuplicateCheck" Enabled="false" Width="18" ToolTip="Duplicate dictation" ImageUrl="~/images/duplicate-check.png" Visible="false" />

                                            <a id="ChangeMin" style="cursor:pointer;" title="Change Minutes" OnClick="btn_change_minutes(this,<%#Eval("dicID") %>);" ><img alt="Change Minutes" style="width:16px;" src="../images/change-minutes.png" /></a>

                                            <a id="btnReset" style="cursor:pointer;" title="Reset Dictation" OnClick="btn_reset(this,<%#Eval("drID") %>,<%#Eval("dicID") %>);" ><img alt="Reset Dictation" src="../images/replaceTranscription.gif" /></a>
                                            <a id="btnReUpload" style="cursor:pointer;" title="Reupload Dictation" OnClick="btn_reupload(this,<%#Eval("drID") %>,<%#Eval("dicID") %>);" ><img alt="Reupload Dictation" src="../images/reverse.gif" /></a>
                                            
                                            <a style="cursor:pointer;" id="btnView" title="View Transcriptions" onclick="btn_view_transcriptions(this,<%#Eval("dicID") %>);" ><img src="../images/view.gif" alt="View Transcriptions" /></a>
                                                

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                            </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </td></tr></table>

    <div onkeydown="return (event.keyCode!=13)" style="width:550px; position:fixed; background-color:transparent; left:30%; top:28%; visibility:hidden; z-index:999999;" class="divTbl" id="divTbl">
        <table id="tblLogMain" class="tblLogMain" style="vertical-align:top; background-color:white; color:#1b2432; font-size:12px; height:auto; width:100%;" cellpadding="0" cellspacing="0">
            <tr>
                <th colspan="4">
                    <h2>Transcriptions</h2>
                </th>
            </tr>
            <tr><td colspan="2"  class="tdspace" style="margin-top:10px; font-size:14px;"></td></tr>
            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td class="leftAlignSpace">Client ID: <label id="lblViewTransCliID"></label></td>
                <td class="leftAlignSpace leftAlign">Client Name: <label id="lblViewTransCliName"></label></td>
            </tr>
            <tr><td colspan="2"  style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>
            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td colspan="2" class="leftAlignSpace">Account: <label id="lblViewTransHosName"></label></td>
            </tr>
            <tr><td colspan="2" style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>
            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td class="leftAlignSpace">Dic Name: <label id="lblViewTransDicName"></label></td>
                <%--<td class="leftAlignSpace">Tra. Uploaded: <label id="lblDicMMUploadDate"></label></td>--%>
            </tr>
            <tr><td colspan="2"  style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>
            <tr>
                <td colspan="2"  width="550px" style="padding-top:10px;">
                    <table id="tblLogs" class="tblLogs" style="width:100%;">
                        
                    </table>
                </td>
            </tr>
            <tr><td colspan="4"  style="background-color:#BAD6FF;height:10px;"><label style="margin-top:10px;"></label></td></tr>
        </table>
    </div>

    <div onkeydown="return (event.keyCode!=13)" style="width:550px; position:fixed; background-color:transparent; left:30%; top:28%; visibility:hidden; z-index:999999;" class="divTbl" id="divDuplicate">
        <table id="tblDuplicate" class="tblLogMain" style="vertical-align:top; background-color:white; color:#1b2432; font-size:12px; height:auto; width:100%;" cellpadding="0" cellspacing="0">
            <tr>
                <th colspan="4">
                    <h2>Duplicate Dictation Check</h2>
                </th>
            </tr>
            <tr><td colspan="2"  class="tdspace" style="margin-top:10px; font-size:14px;"></td></tr>
            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td class="leftAlignSpace">Client ID: <label id="lblDupCliID"></label></td>
                <td class="leftAlignSpace leftAlign">Client Name: <label id="lblDupCliName"></label></td>
            </tr>
            <tr><td colspan="2"  style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>
            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td colspan="2" class="leftAlignSpace">Account: <label id="lblDupHosName"></label></td>
            </tr>
            <tr><td colspan="2" style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>
            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td class="leftAlignSpace">Dic ID: <label id="lblDupDicID"></label></td>
                <td class="leftAlignSpace">Dic Name: <label id="lblDupDicName"></label></td>
            </tr>
            <tr><td colspan="2"  style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>
            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td class="leftAlignSpace">Dic Length: <label id="lblDupDicLength"></label></td>
                <td class="leftAlignSpace">Dic Date: <label id="lblDupDicDate"></label></td>
            </tr>
            <tr><td colspan="2"  style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>
            <tr style="line-height:20px;font-size:14px; text-align:center;">
                <td colspan="2" style="padding-top:10px;" class="dic_min_last_row">
                    <input type="button" onClick="btn_duplicate_check_save();" id="btn_check" value="Mark Checked" style="width:100px;"/>
                    <p><label id="lblDupError" style="color:red;font-size:12px; padding-top:5px; display:none;">There was an unexpected error while marking the dictation as checked.</label></p>
                </td>
            </tr>
            <tr><td colspan="4"  style="background-color:#BAD6FF;height:10px;"><label style="margin-top:10px;"></label></td></tr>
        </table>
    </div>

    <div onkeydown="return (event.keyCode!=13)" style="width:350px; position:fixed; background-color:transparent; left:35%; top:28%; visibility:hidden; z-index:999999;" class="divTbl" id="divChangeDictationMinutes">
        <form action="GET" id="change_minutes_form" onsubmit="return (event.keyCode!=13);">
        <table id="Table1" class="tblLogMain" style="vertical-align:top; background-color:white; color:#1b2432; font-size:12px; height:auto; width:100%;" cellpadding="0" cellspacing="0">
            <tr>
                <th colspan="4">
                    <h2>Change Dictation Minutes</h2>
                </th>
            </tr>
            
            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td class="leftAlignSpace">Client ID: <label style="font-size:12px;" id="lblChangeMinCliID"></label></td>
                <td class="leftAlignSpace">Client Name: <label style="font-size:12px;" id="lblChangeMinCliName"></label></td>
            </tr>

            <tr><td colspan="2"  style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>

            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td colspan="2" class="leftAlignSpace">Account: <label style="font-size:12px; color:black !important;" id="lblChangeMinDicAccountName"></label></td>
            </tr>

            <tr><td colspan="2"  style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>

            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td colspan="2" class="leftAlignSpace">Dictation: <label style="font-size:12px;" id="lblChangeMinDicName"></label></td>
            </tr>

            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td colspan="2" class="leftAlignSpace" style="padding-bottom:10px;">
                    Minutes in Seconds: <input type="text" id="txtChangedDicMintes" style="width:80px;"/> 
                </td>
            </tr>

            <tr style="line-height:20px;font-size:14px; text-align:center;">
                <td colspan="2" class="leftAlignSpace dic_min_last_row">
                    <input type="button" onClick="btn_Change_dic_minutes_save();" id="btnChangedDicMintes" value="Save" style="width:80px;"/>
                </td>
            </tr>

            <tr><td colspan="2"  style="background-color:#BAD6FF;height:10px; width:270px;"><label style="margin-top:10px;"></label></td></tr>

        </table>
    </form>
    </div>

<style type="text/css">
    .dic_min_last_row {
        padding-bottom:20px;
    }
    .tblLogs {
    border-collapse: separate;
    border:none;
    }
    .tblLogs
        {
            display:block;
            height:auto;
            width:100%;
            background-color:white;
            padding-left: -10px;
            }
            
        .tblLogs td
        {
            background-color: #ECECEC;
            color: black;
            font-family: Verdana;
            line-height: 100%;
            vertical-align: middle;
            margin:0px;
            padding:0px;
            border:none;
        }

        .tblLogMain td table th
        {
            background-color: #D7D7D7;
            color: black;
            font-family: Verdana;
            vertical-align: middle;
            height:30px;
            font-size:13px;
            border:none;
            margin:0px;
            padding:0px;
            border-collapse: separate;
        }

        .tblLogMain th
        {
            text-align:left;
            font-size:10px;
            font-family: Verdana;
            font-weight: bold;
            height:50px;

            background-color: #353c47;
            border-top-left-radius: 7px;
            border-top-right-radius: 7px;
            color: white;
            padding: 10px;
        }
    .tblLogMain {
        background-color: #353c47;
        border-top-left-radius: 7px;
        border-top-right-radius: 7px;
    }



    .tblLogMain td { 
       padding-left: 10px;
    }
    @media screen and (-webkit-min-device-pixel-ratio:0)
    {
    .tblLogs{width:475px !important;}
    }

</style>
</asp:Content>

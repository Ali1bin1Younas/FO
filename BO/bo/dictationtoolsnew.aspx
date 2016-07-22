<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="dictationtoolsnew.aspx.vb" Inherits="BO_dictationtools" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="js/jquerylibrary.js"></script>
<style type="text/css">
    .tblborder td {
        border-collapse: collapse;
        border: 1px solid white;
        padding: 0px 0px 0px 2px;
        text-align: center;
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
    #ctl00_ContentPlaceHolder1_CPFrom_outer {
        background-color:white !important;
    }
    #ctl00_ContentPlaceHolder1_CpTo_outer {
        background-color:white !important;
    }
</style>
    

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
                </tr>
                <tr>
                    <td style="width:95px;"><asp:TextBox ID="txtDictation" runat="server" Width="94px"></asp:TextBox></td>
                    <td style="width:181px;"><asp:DropDownList ID="ddlLocation" runat="server" Height="18px" Width="180px"></asp:DropDownList></td>
                    <td style="width:181px;"><asp:DropDownList ID="ddlDictator" runat="server" DataTextField="DictatorName" DataValueField="UId" Height="18px" Width="180px"></asp:DropDownList></td>
                    <td style="width:181px;"><asp:DropDownList ID="ddlEmployee" runat="server" Height="18px" Width="180px"></asp:DropDownList></td>
                    <td style="width:85px;"><ew:calendarpopup id="CPFrom" runat="server" Text=":" nullable="True" BackColor="White" Width="60px"><CLEARDATESTYLE forecolor="Black" font-size="XX-Small" font-names="Verdana,Helvetica,Tahoma,Arial" backcolor="#FFFFFF" /><SELECTEDDATESTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKENDSTYLE BackColor="LightGray" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><GOTOTODAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><DAYHEADERSTYLE BackColor="Orange" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><MONTHHEADERSTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><HOLIDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><OFFMONTHSTYLE BackColor="AntiqueWhite" ForeColor="Gray" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><TODAYDAYSTYLE BackColor="LightGoldenrodYellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /></ew:calendarpopup></td>
                    <td style="width:85px;"><ew:calendarpopup id="CpTo" runat="server" Text=":" nullable="True" BackColor="White" width="60px"><CLEARDATESTYLE forecolor="Black" font-size="XX-Small" font-names="Verdana,Helvetica,Tahoma,Arial" backcolor="#FFFFFF" /><SELECTEDDATESTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKENDSTYLE BackColor="LightGray" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><GOTOTODAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><DAYHEADERSTYLE BackColor="Orange" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><MONTHHEADERSTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><HOLIDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><OFFMONTHSTYLE BackColor="AntiqueWhite" ForeColor="Gray" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><TODAYDAYSTYLE BackColor="LightGoldenrodYellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /></ew:calendarpopup></td>
                    <td style="width:61px;"><asp:DropDownList ID="ddlStatus" runat="server" Height="18px"></asp:DropDownList></td>
                    <td style="width:181px;"><asp:DropDownList ID="ddlSorting" runat="server" Height="18px"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="8" style="text-align:right;padding-right: 8px;">
                        <span><input type="button" id="Button1" onclick="Restore_Dictations_click('1')" title="Restore Deleted dictations" value="Restore" style="width:70px;"/></span>
                        <span style="padding-right:32px"><input type="button" id="Button2" onclick="Restore_Dictations_click('2')" title="Purge deleted dictations" value="Purge" style="width:70px;"/></span>
                        <span><input type="button" value="View" style="width:70px;margin-right:7px;" onclick="btn_view_dictations_tools();" /></span>
                    </td>
                </tr>
            </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding:5px;">
                <label id="response_on_btn_click" style="visibility:hidden;" >

                </label>
                <%--<input type="button" id="btnRestore" onclick="Restore_Dictations_click('1')" title="Restore Deleted dictations" value="Restore" style="width:70px;"/>
                <input type="button" id="purge" onclick="Restore_Dictations_click('2')" title="Purge deleted dictations" value="Purge" style="width:70px;"/>--%>
            </td>

        </tr>
        
        <tr>
             <td style="font-family:Verdana; font-size:9pt;">
                 <table id="tblDetails" cellpadding="0" cellspacing="0" width="100%" class="tblborder">
            <tbody   style="color:green;"">
            </tbody>
                     </table>
             </td>

         </tr>    
        
    
    </table>
    <script type="text/javascript">

        function Restore_Dictations_click(response)
        {
            
            var dicIDs = "";
            if (confirm("Are you sure you want to change Dictator of selected files") == true) {

                
                var tbl = document.getElementById("tblDetails");
                var inputList = tbl.rows[0].cells.item(1).getElementsByTagName("input");
                //var idArr = $("#tblDetails input:checkbox").map(function (i, el) { return $(el).attr("id"); }).get();
                //alert(idArr);
                if (inputList.length > 0) {
                    for (var i = 1; i < tbl.rows.length; i++) {
                        var inputList = tbl.rows[i].cells.item(1).getElementsByTagName("input");

                        if (inputList[0].type == "checkbox" && inputList[0].checked == true) {
                            if (dicIDs == "") {
                                dicIDs = "'" + inputList[0].id + "'";
                            } else {
                                dicIDs = dicIDs + ",'" + inputList[0].id + "'";
                            }
                        }
                    }
                    if (response == '1') {
                        PageMethods.restore_dictations(dicIDs, onsuccessfunction)
                    }
                    else {
                        PageMethods.purge_dictations(dicIDs, onsuccessfunction)
                    }
                }
                
                }

                else {
                    return false ;
                }
            

        }
        function onsuccessfunction(res)
        {
            if (res == true )
            {
                var tbl = document.getElementById("tblDetails");
                var inputList = tbl.rows[0].cells.item(1).getElementsByTagName("input");
                if (inputList.length > 0)
                {
                    for(var i = 1;i < tbl.rows.length; i++)
                    {
                        
                        var inputList = tbl.rows[i].cells.item(1).getElementsByTagName("input");
                        if (inputList[0].type == "checkbox" && inputList[0].checked == true)
                        {
                            
                            var singlerow = inputList[0].parentNode.parentNode;
                            //var jqueryObject = jQuery(singlerow);
                             $(singlerow).remove();
                        }
                        
                        
                    }
                    for (var i = 1; i < tbl.rows.length; i++) {
                        var count = "";
                        count = tbl.rows[i].cells.item(0).getElementsByClassName("count");
                        count[0].innerHTML = i;
                    }     
                }
            }
            else 
            {
               
                
            }
        }


        function btn_view_dictations_tools() {
            try {
                overloader_wait();

                var olddatefrom = $('#ctl00_ContentPlaceHolder1_CPFrom').val();
                var olddateto = $('#ctl00_ContentPlaceHolder1_CpTo').val();
                var oldsd = olddateto.split("/");
                var splitdate = olddatefrom.split("/");
                var _selecteddatefrom = splitdate[1] + "/" + splitdate[0] + "/" + splitdate[2];
                var _selecteddateto = oldsd[1] + "/" + oldsd[0] + "/" + oldsd[2];
                PageMethods.Load_Transcriptions($('#<%=ddlDictator.ClientID%>').val(), $('#<%=ddlLocation.ClientID%>').val(), $('#<%=ddlEmployee.ClientID%>').val(), $('#<%=ddlSorting.ClientID%>').val(), _selecteddatefrom, _selecteddateto, $('#ctl00_ContentPlaceHolder1_txtDictation').val(), $('#<%=ddlStatus.ClientID%>').val(), onSuccess_btn_view_Client_Information)
            }
            catch (e) {
                alert(e.message);
                $("#overlay_view_back").remove();
                hide_overylay_wait();
            }
        }

        function onSuccess_btn_view_Client_Information(res) {
            $("#tblDetails").empty();
            var headerrow = "<thead style='background-color:#D7D7D7; color:#1E1E1E; font-weight:bold;'><tr style='border:solid 1px #000000;height:25px;'>";
            var num = "&nbsp;&nbsp; #&nbsp;&nbsp;&nbsp;  ";
            headerrow += "<td  style='text-align:center;width:40px;'>" + num + "</td>";
            var checkbox = "<input type='checkbox' id='select-all' onclick='return checkAllDicss(this,this.checked)'>";
            headerrow += "<td style='text-align:center;width:40px;'>" + checkbox + "</td>";
            var DictatorID = "Dictator ID";
            headerrow += "<td style='text-align:center;width:60px;'>" + DictatorID + "</td>";
            var Date = "Date";
            headerrow += "<td style='width:90px;'>" + Date + "</td>";
            var Dname = "Dication Name";
            headerrow += "<td style='width:140px;text-align:left;'>" + Dname + "</td>";
            var Minutes = "Minutes";
            headerrow += "<td style='width:70px;'>" + Minutes + "</td>";
            var AccountName = "Account";
            headerrow += "<td style='width:170px;text-align:left;'>" + AccountName + "</td>";
            var MT = "MT";
            headerrow += "<td style='width:80px;text-align:center;'>" + MT + "</td>";
            var QC = "QC";
            headerrow += "<td style='width:80px;text-align:center;'>" + QC + "</td>";
            var PR = "PR";
            headerrow += "<td style='width:80px;text-align:center;'>" + PR + "</td>";
            var FR = "FR"
            headerrow += "<td style='width:80px;text-align:center;'>" + FR + "</td>";
            headerrow += "</tr></thead>";
            $("#tblDetails").append(headerrow);
            for (var i = 0; i < res.length; i++) {
                var MT = res[i].mt.split(":");
                var MTname = MT[0];
                var mtdicstatus = MT[1];
                var qc = res[i].qc.split(":");
                var qcname = qc[0];
                var qcdicstatus = qc[1];
                var pr = res[i].pr.split(":");
                var prname = pr[0];
                var prdicstatus = pr[1];
                var fr = res[i].fr.split(":");
                var frname = fr[0];
                var frdicstatus = fr[1];
                var mtcolor = "",
                    qccolor = "",
                    prcolor = "",
                    frcolor = "",
                    bckcolor = "";
                if (i % 2 === 0) {
                    bakcolor = "background-color:#ECECEC";
                }
                else {
                    bakcolor = "background-color: #ECECEC";
                }
                var txt = "<tr style='color:#1E1E1E;" + bakcolor + ";font-family:Verdana;font-size:11px;text-decoration:none;height:25px;'>";
                var count = i + 1;
                txt += "<td style='width:40px;'><span class='count'>" + count + "</span></td>";
                var checkbox = "<input type='checkbox' id=" + res[i].dicId + " style='width:12px;height:12px;'>";
                txt += "<td style='width:40px;'>" + checkbox + "</td>"
                txt += "<td style='width:60px;' >" + res[i].drId + "</td>";
                txt += "<td  style='width:90px;' >" + res[i].dicDate + "</td>";
                txt += "<td style='width:140px;text-align:left;'>" + res[i].dicActualName + "</td>";
                txt += "<td  style='width:70px;' >" + get_mins(res[i].dicLength) + "</td>";
                txt += "<td style='width:170px;text-align:left;'>" + res[i].dicAccountName + "</td>";
                switch (mtdicstatus) {
                    case '0':
                        mtcolor = "#808080";
                        break;
                    case '1':
                        mtcolor = "#F4BA00";
                        break;
                    case '2':
                        mtcolor = "#7627FC";
                        break;
                    case '3':
                        mtcolor = "#00DB00";
                        break;
                    default:
                        mtcolor = "#F64244";
                }
                switch (qcdicstatus) {
                    case '0':
                        qccolor = "#808080";
                        break;
                    case '1':
                        qccolor = "#F4BA00";
                        break;
                    case '2':
                        qccolor = "#7627FC";
                        break;
                    case '3':
                        qccolor = "#00DB00";
                        break;
                    default:
                        qccolor = "#F64244";
                }
                switch (prdicstatus) {
                    case '0':
                        prcolor = "#808080";
                        break;
                    case '1':
                        prcolor = "#F4BA00";
                        break;
                    case '2':
                        prcolor = "#7627FC";
                        break;
                    case '3':
                        prcolor = "#00DB00";
                        break;
                    default:
                        prcolor = "#F64244";
                }
                switch (frdicstatus) {
                    case '0':
                        frcolor = "#808080";
                        break;
                    case '1':
                        frcolor = "#F4BA00";
                        break;
                    case '2':
                        frcolor = "#7627FC";
                        break;
                    case '3':
                        frcolor = "#00DB00";
                        break;
                    default:
                        frcolor = "#F64244";
                }
                if (MTname.length > 0 && MTname == "Skip S") {
                    txt += "<td  style='width:80px;color:" + mtcolor + "' > - </td>";
                }
                else if (MTname.length > 0) {
                    txt += "<td  style='width:80px;color:"+ mtcolor +"' > " + MTname + " </td>";
                }
                else {
                    txt += "<td  style='width:80px;color:"+ mtcolor +"' > - </td>";
                }

                if (qcname.length > 0 && qcname == "Skip S") {
                    txt += "<td  style='width:80px;color:" + qccolor + "' > - </td>";
                }
                else if (qcname.length > 0) {
                    txt += "<td  style='width:80px;color:" + qccolor + "' > " + qcname + " </td>";
                }
                else {
                    txt += "<td  style='width:80px;color:" + qccolor + "' > - </td>";
                }

                if (prname.length > 0 && prname == "Skip S") {
                    txt += "<td  style='width:80px;color:" + prcolor + "' > - </td>";
                }
                else if (prname.length > 0) {
                    txt += "<td  style='width:80px;color:" + prcolor + "' > " + prname + " </td>";
                }
                else {
                    txt += "<td  style='width:80px;color:" + prcolor + "' > - </td>";
                }

                if (frname.length > 0 && frname == "Skip S") {
                    txt += "<td  style='width:80px;color:" + frcolor + "' > - </td>";
                }
                else if (frname.length > 0) {
                    txt += "<td  style='width:80px;color:" + frcolor + "' > " + frname + " </td>";
                }
                else {
                    txt += "<td  style='width:80px;color:" + frcolor + "' > - </td>";
                }
                txt += "</tr>";

                $("#tblDetails").append(txt);
            }
            $("#overlay_view_back").remove();
            hide_overylay_wait();
        }
        function checkAllDicss(objRef, is_check) {
            try {
                
                var GridView = objRef.parentNode.parentNode.parentNode.parentNode;
                //var chkHead = GridView.rows[0].cells.item(1).getElementsByTagName("input")[0];

                //if (chkHead.type == "checkbox") {
                    for (var i = 1; i < GridView.rows.length; i++) {
                        var chkbox = GridView.rows[i].cells.item(objRef.parentNode.cellIndex).getElementsByTagName("input")[0];
                        chkbox.checked = is_check;
                    }
                //}
            } catch (e) {
                alert(e.message);
            }
        }
        function get_mins(Seconds) {
            try {
                var min, min2;
                min = parseInt(Seconds) / 60;
                min2 = parseInt(Seconds) % 60;
                var arr = min.toString().split(".");

                if (min2 < 10 && min2 != 0) {
                    min2 = "0" + min2;
                }

                if (min2 != 0) {
                    if (min < 10) {
                        min = "00" + arr[0] + ":" + min2;
                    } else if (min < 99) {
                        min = "0" + arr[0] + ":" + min2;
                        min = arr[0] + ":" + min2;
                    } else {
                        min = arr[0] + ":" + min2;
                    }
                } else {
                    if (min < 10) {
                        min = "00" + arr[0] + ":" + "00";
                    } else if (min < 99) {
                        min = "0" + arr[0] + ":" + "00";
                    } else {
                        min = arr[0] + ":" + "00";
                    }
                }
                return min;
            } catch (e) { return "undefined"; }
        }
        ////////////////////////////////////////////////////
        /////////////////////////   Overlay   /////////////
        //////////////////////////////////////////////////
        var MainOver = '<div id="overlay" class="overlay" style="height:100%; width:100%;">' +
                    '<div><img id="loading" src="../Icon/ajax-loader.gif"><div>' +
                    '</div>';
        var overlay_view = '<div id="overlay" onClick="btn_hide_overylay_view();" class="overlay" style="height:100%; width:100%;">' +
                    '<div><div>' +
                    '</div>';
        var overlay_view_back = '<div id="overlay_view_back" onClick="btn_hide_overylay_View_back();" class="overlay_view_back" style="height:100%; width:100%;">' +
                    '<div><div>' +
                    '</div>';

        function btn_hide_overylay_View_back() {
            $('#divTbl').css('visibility', 'hidden');
            $("#overlay_view_back").remove();


        }

        function overloader_view_back() {
            try {
                var docHeight = $(document).height();
                $("body").append(overlay_view_back);
                $("#overlay_view_back")
                .height(docHeight)
                .css({
                    'opacity': 0.4,
                    'position': 'absolute',
                    'background-color': 'black',
                    'width': '100%',
                    'z-index': 4000,
                    'top': 0
                });
            } catch (e) {
                alert(e.message);
                $("#overlay").remove();
            }
        }


        function overloader_wait() {
            try {
                var docHeight = $(document).height();
                $("body").append(MainOver);
                $("#overlay")
                .height(docHeight)
                .css({
                    'opacity': 0.8,
                    'position': 'absolute',
                    'background-color': 'white',
                    'width': '100%',
                    'z-index': 5000,
                    'top': 0
                });
            } catch (e) {
                alert(e.message);
                $("#overlay").remove();
            }
        }
        function hide_overylay_wait() {
            $("#overlay").remove();
        }

        function overloader_view() {
            try {
                var docHeight = $(document).height();
                $(".mainBody").append(overlay_view);
                $("#overlay")
                .height(docHeight)
                .css({
                    'opacity': 0.4,
                    'position': 'absolute',
                    'background-color': 'black',
                    'width': '100%',
                    'z-index': 9999,
                    'top': 0
                });
            } catch (e) {
                $("#overlay").remove();
                alert(e.message);

            }

        }
     </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
</asp:Content>


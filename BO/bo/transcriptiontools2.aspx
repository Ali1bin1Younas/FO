
<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="transcriptiontools2.aspx.vb" Inherits="BO_transcriptiontools2" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <style type="text/css">
    .tblborder td {
        border-collapse: collapse;
        border: 1px solid white;
        padding: 0px 0px 0px 2px;
        text-align: center;
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
      vertical-align:top;
      width:100px;
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
        background-color:#ffffff !important;
     }
     #ctl00_ContentPlaceHolder1_CpTo_outer {
        background-color:#ffffff !important;
     }
</style>  
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="searchTools">
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="font-family:Verdana; font-size:12px;padding-bottom:5px;">
                <tr>
                    <td>Keyword</td>
                    <td>Dictator</td>
                    <td>Account</td>
                    <td>From</td>
                    <td>To</td>
                    <td>Sorting</td>
                    <td></td>
                </tr>
                <tr>
                    <td><input id="txtDictation" type="text" style="width:94px;" /></td>
                    <td><asp:DropDownList ID="ddlDictator" runat="server" DataTextField="DictatorName" DataValueField="UId" Height="18px"></asp:DropDownList></td>
                    <td><asp:DropDownList ID="ddlLocation" runat="server" Height="18px"></asp:DropDownList></td>
                    <td><ew:calendarpopup id="CPFrom" runat="server" nullable="True" Width="72px"><CLEARDATESTYLE forecolor="Black" font-size="XX-Small" font-names="Verdana,Helvetica,Tahoma,Arial" backcolor="#ECECEC" /><SELECTEDDATESTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKENDSTYLE BackColor="LightGray" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><GOTOTODAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><DAYHEADERSTYLE BackColor="Orange" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><MONTHHEADERSTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><HOLIDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><OFFMONTHSTYLE BackColor="AntiqueWhite" ForeColor="Gray" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><TODAYDAYSTYLE BackColor="LightGoldenrodYellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /></ew:calendarpopup></td>
                    <td><ew:calendarpopup id="CpTo" runat="server" nullable="True" width="72px"><CLEARDATESTYLE forecolor="Black" font-size="XX-Small" font-names="Verdana,Helvetica,Tahoma,Arial" backcolor="#ECECEC" /><SELECTEDDATESTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKENDSTYLE BackColor="LightGray" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><GOTOTODAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><DAYHEADERSTYLE BackColor="Orange" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><MONTHHEADERSTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><HOLIDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><OFFMONTHSTYLE BackColor="AntiqueWhite" ForeColor="Gray" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><TODAYDAYSTYLE BackColor="LightGoldenrodYellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /></ew:calendarpopup></td>
                    <td><asp:DropDownList ID="ddlSorting" runat="server" Height="18px"></asp:DropDownList></td>
                    <td align="right"><input type="button" value="View" style="width:70px;" onclick="btn_view_transcirptions_tools();" /></td>
                </tr>
            </table>
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
        <tr>    
        <td>
    </td>
    </tr>
    </table>

    <div onkeydown="return (event.keyCode!=13)" style="width:550px; position:fixed; background-color:transparent; left:30%; top:28%; visibility:hidden; z-index:999999;" class="divTbl" id="divTbl">
        <table id="tblLogMain" class="tblLogMain" style="vertical-align:top; background-color:white; color:#1b2432; font-size:12px; height:auto; width:100%;" cellpadding="0" cellspacing="0">
            <tr>
                <th colspan="4">
                    <h2>Transcription Details</h2>
                </th>
            </tr>
            <tr><td colspan="2"  style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>
            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td class="leftAlignSpace"><span style="font-weight:bold;">Document #:</span> <label id="lblViewDocno"></label></td>
                <td class="leftAlignSpace"><span style="font-weight:bold;">Urgent :</span> <input type="CheckBox" id="chkurgent"  disabled></td>
                
                
            </tr>
            <tr><td colspan="2" style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>
            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td class="leftAlignSpace"><span style="font-weight:bold">Subject:</span> <label id="lblViewSubject" style="text-overflow:ellipsis;"></label></td>
                <td class="leftAlignSpace"><span style="font-weight:bold">Dear:</span> <label id="lblViewDear"></label></td>
                
                
                <%--<td class="leftAlignSpace">Tra. Uploaded: <label id="lblDicMMUploadDate"></label></td>--%>
            </tr>
            <tr><td colspan="2"  style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>
            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td class="leftAlignSpace"><span style="font-weight:bold">Patient #:</span><label id="lblViewTranPatientNo"></label></td>
                <td class="leftAlignSpace"><span style="font-weight:bold">NHS :</span> <label id="lblViewNHS" style="text-overflow:ellipsis;"></label></td>
                
                <%--<td class="leftAlignSpace">Tra. Uploaded: <label id="lblDicMMUploadDate"></label></td>--%>
            </tr>
            <tr><td colspan="2"  style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>
            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td class="leftAlignSpace"><span style="font-weight:bold">ClinicDate:</span> <label id="lblViewClientDate"></label></td>
                <td class="leftAlignSpace"><span style="font-weight:bold">Date of Birth:</span> <label id="lblViewDateofbirth"></label></td>
                
                
            </tr>
            <tr><td colspan="2"  style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>
            <tr>
                <tr class="leftAlign" style="line-height:15px;font-size:14px;">
                    <td class="leftAlignSpace" "><span style="font-weight:bold">Notes to Secretary:</span><label id="lblViewNTS" style="text-overflow:ellipsis;width:200px;"></label></td>
                    <td class="leftAlignSpace"><span style="font-weight:bold">Note to Dictator:</span><label id="lblViewNTD" style="text-overflow:ellipsis;width:200px;"></label></td>
                
                
            </tr>
            <tr><td colspan="2"  style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>
            <tr class="leftAlign" style="line-height:15px;font-size:14px;">
                <td class="leftAlignSpace"><span style="font-weight:bold">Recipient Address :</span> <label id="lblViewRA" style="text-overflow:ellipsis;"></label></td>
                <td class="leftAlignSpace"><span style="font-weight:bold">Footer Block :</span> <label id="lblViewFB" style="text-overflow:ellipsis;"></label></td>
               
            </tr>
            <tr><td colspan="2"  style="margin-bottom:10px;background-color:black;height:1px; width:270px;"></td></tr>
            <tr class="leftAlign" style="line-height:15px;font-size:14px;">
                <td class="leftAlignSpace" style="line-height: 1.9";><span style="font-weight:bold">View Documents :</span></td><td style="line-height: 1.9";> <label id="lblViewDocuments" style="text-overflow:ellipsis;"></label></td>
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
    <script type="text/javascript">
        function btn_view_transcirptions_tools()
        {
            try
            {
                overloader_wait();
                var olddatefrom = $('#ctl00_ContentPlaceHolder1_CPFrom').val();
                var olddateto = $('#ctl00_ContentPlaceHolder1_CpTo').val();
                var oldsd = olddateto.split("/");
                var splitdate = olddatefrom.split("/");
                var _selecteddatefrom = splitdate[0] + "/" + splitdate[1] + "/" + splitdate[2];
                var _selecteddateto = oldsd[0] + "/" + oldsd[1] + "/" + oldsd[2];
                PageMethods.Load_grid_Transcription($('#<%=ddlDictator.ClientID%>').val(), $('#<%=ddlLocation.ClientID%>').val(), $('#<%=ddlSorting.ClientID%>').val(), _selecteddatefrom, _selecteddateto, $('#txtDictation').val(), onSuccess_btn_view_Client_Information)
            }
            catch(e)
            {
                alert(e.message);
                $("#overlay_view_back").remove();
                hide_overylay_wait();
            }
        }

        function onSuccess_btn_view_Client_Information(res) {
            $("#tblDetails").empty();
            var headerrow = "<thead style='background-color:#D7D7D7; color:#1E1E1E; font-weight:bold; height:25px;'><tr style='border:solid 1px #000000'>";
            var num = "&nbsp;&nbsp; # &nbsp;&nbsp;&nbsp;  ";
            headerrow += "<td  style='text-align:center;width:40px;'>" + num + "</td>";
            var CliID = "ID";
            headerrow += "<td style='text-align:center;width:90px;'>" + CliID + "</td>";
            var Name = "Name";
            headerrow += "<td style='width:150px;text-align:left;'>" + Name + "</td>";
            var accountName = "Account";
            headerrow += "<td style='width:150px;text-align:left;'>" + accountName + "</td>";
            var Date = "Date";
            headerrow += "<td style='width:80px;'>" + Date + "</td>";
            var patientName = "Patient Name";
            headerrow += "<td style='width:120px;'>" + patientName + "</td>";
            var MT = "MT";
            headerrow += "<td style='width:90px;'>" + MT + "</td>";
            var QC = "QC";
            headerrow += "<td style='width:90px;'>" + QC + "</td>";
            var PR = "PR";
            headerrow += "<td style='width:90px;'>" + PR + "</td>";
            var FR = "FR"
            headerrow += "<td style='width:90px;'>" + FR + "</td>";
            var Options = "Options";
            headerrow += "<td style='width:130px;'>" + Options + "</td>";
            headerrow += "</tr></thead>";
            $("#tblDetails").append(headerrow);
            for (var i = 0; i < res.length; i++) {
                var MT = res[i].mt.split(":"),
                    MTname = MT[0],
                    mtdicstatus = MT[1],
                    qc = res[i].qc.split(":"),
                    qcname = qc[0],
                    qcdicstatus = qc[1],
                    pr = res[i].pr.split(":"),
                    prname = pr[0],
                    prdicstatus = pr[1],
                    fr = res[i].fr.split(":"),
                    frname = fr[0],
                    frdicstatus = fr[1],
                    mtcolor = "",
                    qccolor = "",
                    prcolor = "",
                    frcolor = "",
                    bckcolor = "";
                var bckcolor = ""
                if (i % 2 === 0) {
                    bakcolor = "background-color:#ECECEC";
                }
                else {
                    bakcolor = "background-color: #ECECEC";
                }
                var txt = "<tr style='color:#1E1E1E;" + bakcolor + ";font-family:Verdana;font-size:11px;text-decoration:none;height:25px;'>";
                var count = i + 1;
                txt += "<td style='padding-left:1px;width:40px;'>" + count + "</td>";
                txt += "<td style='width:90px;' >"+ res[i].drID + "</td>";
                txt += "<td style='width:150px;text-align:left;'>" + res[i].dicActualName + "</td>";
                txt += "<td style='width:150px;text-align:left;'>" + res[i].dicAccountName + "</td>";
                txt += "<td  style='width:80px;' >" + res[i].dicDate + "</td>";
                if (res[i].lName.length > 0 && res[i].fName.length > 0 && res[i].traPatientNo.length > 0)
                {
                    txt += "<td style='width:120px;'>" + res[i].lName + "," + res[i].fName + "/" + res[i].traPatientNo + "</td>";
                }
                else if (res[i].lName.length > 0 || res[i].fName.length > 0 || res[i].traPatientNo.length < 0)
                {
                    txt += "<td style='width:120px;'>" + res[i].lName + "," + res[i].fName + "</td>";
                }
                else if (res[i].lName.length < 0 || res[i].fName.length < 0 || res[i].traPatientNo.length > 0)
                {
                    txt += "<td style='width:120px;'>" + res[i].traPatientNo + "</td>";
                }
                else if (res[i].lName.length > 0 || res[i].fName.length < 0 || res[i].traPatientNo.length < 0)
                {
                    txt += "<td style='width:120px;'>" + res[i].lName + "</td>";
                }
                else if (res[i].lName.length < 0 || res[i].fName.length > 0 || res[i].traPatientNo.length < 0) {
                    txt += "<td style='width:120px;'>" + +res[i].fName + "</td>";
                }
                else
                {
                    txt += "<td style='width:120px;'>" + "-" + "</td>";
                }
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
                    txt += "<td  style='width:90px;color:" + mtcolor + "' > - </td>";
                }
                else if (MTname.length > 0) {
                    txt += "<td  style='width:90px;color:" + mtcolor + "' > " + MTname + " </td>";
                }
                else {
                    txt += "<td  style='width:90px;color:" + mtcolor + "' > - </td>";
                }

                if (qcname.length > 0 && qcname == "Skip S") {
                    txt += "<td  style='width:90px;color:" + qccolor + "' > - </td>";
                }
                else if (qcname.length > 0) {
                    txt += "<td  style='width:90px;color:" + qccolor + "' > " + qcname + " </td>";
                }
                else {
                    txt += "<td  style='width:90px;color:" + qccolor + "' > - </td>";
                }

                if (prname.length > 0 && prname == "Skip S") {
                    txt += "<td  style='width:90px;color:" + prcolor + "' > - </td>";
                }
                else if (prname.length > 0) {
                    txt += "<td  style='width:90px;color:" + prcolor + "' > " + prname + " </td>";
                }
                else {
                    txt += "<td  style='width:90px;color:" + prcolor + "' > - </td>";
                }

                if (frname.length > 0 && frname == "Skip S") {
                    txt += "<td  style='width:90px;color:" + frcolor + "' > - </td>";
                }
                else if (frname.length > 0) {
                    txt += "<td  style='width:90px;color:" + frcolor + "' > " + frname + " </td>";
                }
                else {
                    txt += "<td  style='width:90px;color:" + frcolor + "' > - </td>";
                }
                txt += "<td style='width:130px;'><a style='cursor:pointer;' title='View Transcriptions' onClick='btn_view_transcriptions_details(" + res[i].traID + ");'><img src='../images/transcriptions.gif' alt='View Transcriptions'/></a></td>"
                txt += "</tr>";

                $("#tblDetails").append(txt);
            }
            $("#overlay_view_back").remove();
            hide_overylay_wait();
        }

        ////////////////////////////////////////////////////////////////////////      
        /////////////////////////   PopUpTranscriptions Details   /////////////
        //////////////////////////////////////////////////////////////////////

        function btn_view_transcriptions_details(dicID) {
            try {
                overloader_wait();
                var dicID = dicID;
                PageMethods.get_trans_details(dicID, OnSuccess_btn_view_transcriptions);
            } catch (e) { alert(e.message); }
        }

        function OnSuccess_btn_view_transcriptions(res) {
            $("#overlay_view_back").remove();
            hide_overylay_wait();
            overloader_view_back()
           
            try {
                if (window.DOMParser) {
                    parser = new DOMParser();
                    xmlDoc = parser.parseFromString(res, "text/xml");
                }
                else // Internet Explorer
                {
                    xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
                    xmlDoc.async = false;
                    xmlDoc.loadXML(res);
                }

                var xml = $(xmlDoc);
                var html = "";
                var traCount = 1;
                if (xml.find("trans")) {
                    var dicsXml = xml.find("trans");
                    if (dicsXml.length > 0) {
                        dicsXml.each(function () {
                            var temXml = $(this);
                            $('#lblViewTranPatientNo').html(temXml.find("traPatientNo").text());
                            $('#lblViewClientDate').html(temXml.find("traCDate").text());
                            $('#lblViewNTS').html(temXml.find("traNTS").text()).attr("title", temXml.find("traNTS").text());
                            $('#lblViewSubject').html(temXml.find("traSubject").text()).attr("title", temXml.find("traSubject").text());
                            $('#lblViewDear').html(temXml.find("traDear").text());
                            $('#lblViewNHS').html(temXml.find("traNHSno").text()).attr("title", temXml.find("traNHSno").text());
                            $('#lblViewRA').html(temXml.find("traRecipientAddress").text()).attr("title", temXml.find("traRecipientAddress").text());
                            $('#lblViewDateofbirth').html(temXml.find("traDoB").text());
                            if (temXml.find("traIncomplete").val() == 0) {

                            }
                            else {
                                $('#chkurgent').attr("checked", "checked"); s
                            }
                            $('#lblViewNTD').html(temXml.find("traNTD").text()).attr("title", temXml.find("traNTD").text());
                            $('#lblViewFB').html(temXml.find("traFooterBlock").text()).attr("title", temXml.find("traFooterBlock").text());
                            $('#lblViewDocno').html(temXml.find("traID").text()); 
                            $('#lblViewDocuments').html(temXml.find("traDoc_mt_qc_pr_fr").text());
                        });
                        
                    } else {
                        html += '<tr class="addedRows" style="padding:10px;">';
                        html += '<td colspan="4" style="width:100%;text-align:center;"> No Details Found For This.</td>';
                        html += '</tr>';
                    }
                }
                $('#tblLogs').append(html);
                html = "";
                $('#divTbl').css('visibility', 'visible');
            } catch (e) {
                $("#overlay_view_back").remove();
                hide_overylay_wait();
                alert(e.message);

            }
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


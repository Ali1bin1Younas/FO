
var g_current_role = "";
var g_current_Grid = "";
var g_current_dictator_detail_Grid = "";
var g_current_main_Grid = "";
var row = null;

var g_role_count = 0;
var g_selected_dicID = 0;
var g_selected_traID = 0;
var chk_MT = false;
var chk_QC = false;
var chk_PR = false;
var chk_FR = false;

var is_roles_list_loaded = false;
var MainOver = '<div id="overlay" class="overlay" style="height:100%; width:100%;">' +
                    '<div><img id="loading" src="../Icon/ajax-loader.gif"><div>' +
                    '</div>';

var overlay_view = '<div id="overlay" onClick="btn_hide_overylay_view();" class="overlay" style="height:100%; width:100%;">' +
                    '<div><div>' +
                    '</div>';

var confirm_popup = '<div class="confirm">' +
                      '<h1>Confirm your action</h1>' +
                      '<p>Are you sure that you want Apply this operation on Dictation(s)?</p>' +
                      '<button>Cancel</button>' +
                      '<button autofocus>Confirm</button>' +
                    '</div>'
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////   Assign Teams to Dictations   ///////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function assignDictation_click(objRef) {
    try {
        var GridView = objRef.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
        var inputList = GridView.getElementsByTagName("input");
        var selectList = GridView.getElementsByTagName("select");
        var GridDics = GridView.getElementsByTagName("table");

        g_current_dictator_detail_Grid = GridDics[1];
        g_current_Grid = GridDics[3];
        g_current_main_Grid = GridView;

        overloader_wait();

        var dicIDs_MT = getAllTra_Ids(GridDics[3], 4);
        var dicIDs_QC = getAllTra_Ids(GridDics[3], 5);
        var dicIDs_PR = getAllTra_Ids(GridDics[3], 6);
        var dicIDs_FR = getAllTra_Ids(GridDics[3], 7);
        //for (var j = 4; j < 8; j++) {
          //  var chk_IDs = getAllTra_Ids(GridDics[3], j);
          //  if (chk_IDs != "") { dicIDs = chk_IDs; break; }
        //}

        if (dicIDs_MT != "" || dicIDs_QC != "" || dicIDs_PR != "" || dicIDs_FR != "") {
            // NOTE : if the arrangement of buttons in the front end is to be changes, then the indexes of the elemnet below must be chages accordingly........
            chk_MT = g_current_Grid.rows[0].cells.item(4).getElementsByTagName("input")[0].checked;
            chk_QC = g_current_Grid.rows[0].cells.item(5).getElementsByTagName("input")[0].checked;
            chk_PR = g_current_Grid.rows[0].cells.item(6).getElementsByTagName("input")[0].checked;
            chk_FR = g_current_Grid.rows[0].cells.item(7).getElementsByTagName("input")[0].checked;

            var roleDateMT = inputList[0].value;
            var roleDateQC = inputList[2].value;
            var roleDatePR = inputList[4].value;
            var roleDateFR = inputList[6].value;

            var empIDMT = selectList[0].value;
            var empIDQC = selectList[1].value;
            var empIDPR = selectList[2].value;
            var empIDFR = selectList[3].value;

            var drID = g_current_dictator_detail_Grid.getElementsByTagName("label")[1].innerHTML;
            var CPMainDate = $('#ctl00_ContentPlaceHolder1_CPMain').val();
            ////////
            PageMethods.Assign_roles_to_dictations(drID, CPMainDate, dicIDs_MT, dicIDs_QC, dicIDs_PR, dicIDs_FR, chk_MT, chk_QC, chk_PR, chk_FR, empIDMT, empIDQC, empIDPR, empIDFR, roleDateMT, roleDateQC, roleDatePR, roleDateFR, OnSuccess_Assign_roles_to_dictations);
        } else {
            $("#overlay").remove();
        }

        if (dicIDs_MT == "" && dicIDs_QC == "" && dicIDs_PR == "" && dicIDs_FR == "") {
            alert('Please select Dictations First');
        }
    } catch (e) {
        alert("Assign Role, "+e.message);
        $("#overlay").remove();
    }
}

function OnSuccess_Assign_roles_to_dictations(res) {
   
            refresh_dic_row(res);
            $("#overlay").remove();
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////    Reupload Dictation    /////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function btn_reupload(objRef, drID, dicID) {
    try {
        var r = confirm("Are you sure you want to Reupload this Dictation file?");
        if (!r) { return; }

        var GridView = objRef.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
        var GridDics = GridView.getElementsByTagName("table");
        g_current_Grid = GridDics[3];
        g_current_dictator_detail_Grid = GridDics[1];
        row = objRef.parentNode.parentNode;

        overloader_wait();

        PageMethods.reupload_dictation(dicID, OnSuccess_btn_reupload);
    } catch (e) {
        alert(e.message);
    }
}
function OnSuccess_btn_reupload(res) {
    try {
        resp = res.split(",");
        $("#overlay").remove();

        if (resp[0] == "1") {
            row.style.backgroundColor = "#C2F69B";
            window.setTimeout(function () {
                row.style.backgroundColor = "#ECECEC";
            }, 3000);
            refresh_dic_row(resp[1]); 
        } else if (resp[0] == "0") {
            row.style.backgroundColor = "#ffd5d5";
            window.setTimeout(function () {
                row.style.backgroundColor = "#ECECEC";
            }, 3000);
        } else {
            alert(resp[1]);
            row.style.backgroundColor = "#ffd5d5";
            window.setTimeout(function () {
                row.style.backgroundColor = "#ECECEC";
            }, 3000);
        }

    } catch (e) { alert(e.message); }
}

function btn_refresh(objRef, drID, dicID) {
    try {

        var GridView = objRef.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
        var GridDics = GridView.getElementsByTagName("table");
        g_current_Grid = GridDics[3];
        g_current_dictator_detail_Grid = GridDics[1];
        row = objRef.parentNode.parentNode;

        overloader_wait();

        PageMethods.refresh_dictation(dicID, OnSuccess_btn_refresh);
    } catch (e) {
        alert(e.message);
    }
}
function OnSuccess_btn_refresh(res) {
    try {
        resp = res.split(",");
        $("#overlay").remove();

        if (resp[0] == "1") {
            row.style.backgroundColor = "#C2F69B";
            window.setTimeout(function () {
                row.style.backgroundColor = "#ECECEC";
            }, 3000);
            refresh_dic_row(resp[1]);
        } else if (resp[0] == "0") {
            row.style.backgroundColor = "#ffd5d5";
            window.setTimeout(function () {
                row.style.backgroundColor = "#ECECEC";
            }, 3000);
        } else {
            alert(resp[1]);
            row.style.backgroundColor = "#ffd5d5";
            window.setTimeout(function () {
                row.style.backgroundColor = "#ECECEC";
            }, 3000);
        }

    } catch (e) { alert(e.message); }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////   Reset Dictation    ///////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function btn_reset(objRef, drID, dicID) {
    try {
        var r = confirm("Are you sure you want to Reset this Dictation file?");
        if (!r) { return; }

        var GridView = objRef.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
        var GridDics = GridView.getElementsByTagName("table");

        g_current_dictator_detail_Grid = GridDics[1];
        g_current_Grid = GridDics[3];
        g_current_main_Grid = GridView;

        row = objRef.parentNode.parentNode;
        overloader_wait();

        PageMethods.reset_dictation(dicID, OnSuccess_btn_reset);
    } catch (e) {
        alert(e.message);
        $("#overlay").remove();
    }
}

function OnSuccess_btn_reset(res) {
    try {
        resp = res.split(",");
        $("#overlay").remove();

        if (resp[0] == "1") {
            row.style.backgroundColor = "#C2F69B";
            window.setTimeout(function () {
                row.style.backgroundColor = "#ECECEC";
            }, 3000);
            refresh_dic_row(resp[1]);
        } else if (resp[0] == "0") {
            row.style.backgroundColor = "#ffd5d5";
            row.queue(function () {
                window.setTimeout(function () {
                    row.style.backgroundColor = "#ECECEC";
                }, 3000);
            });
        } else {
            alert(resp[1]);
            row.style.backgroundColor = "#ffd5d5";
            row.queue(function () {
                window.setTimeout(function () {
                    row.style.backgroundColor = "#ECECEC";
                }, 3000);
            });
        }

    } catch (e) { alert(e.message); }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////   Delete Dictation    //////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function btn_mark_dictation_delete(objRef) {
    try {
        var dicIDs = get_all_chkDics_ids(objRef);
        if(dicIDs == ""){alert("Please select a Dictation to Delete.");return;}
        var r = confirm("Are you sure you want to Delete this Dictation file?");
        if (!r) { return; }

        var GridView = objRef.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
        var GridDics = GridView.getElementsByTagName("table");
        g_current_Grid = GridDics[3];
        g_current_dictator_detail_Grid = GridDics[1];

        overloader_wait();

        PageMethods.delete_dictation(dicIDs, OnSuccess_btn_delete);
    } catch (e) {
        alert(e.message);
        $("#overlay").remove();
    }
}

function OnSuccess_btn_delete(res) {
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
        var lbl_indexes = "";
        var lbl_count = 1;

        if (xml.find("dics")) {
            var dicsXml = xml.find("dics");
            if (dicsXml.length > 0) {
                dicsXml.each(function () {
                    var temXml = $(this);
                    lbl_count = parseInt(lbl_count);

                    for (var index = 1; index < g_current_Grid.rows.length; index++) {
                        
                        var rowChkID = g_current_Grid.rows[index].cells.item(1).getElementsByTagName("input")[0].id.split("_");

                        if (temXml.find("dicEnable").text().trim() == "false" && temXml.find("dicID").text().trim() == rowChkID[rowChkID.length - 1]) {
                            g_current_Grid.rows[index].cells.item(1).getElementsByTagName("input")[0].checked = false;
                            setHeaderCheck(g_current_Grid.rows[index].cells.item(1).getElementsByTagName("input")[0], false);
                            g_current_Grid.rows[index].style.backgroundColor = "#C2F69B";
                        }
                    }
 
                    $("#overlay").remove();
                });

                setTimeout(function () {
                   
                    dicsXml.each(function () {
                        var temXml = $(this);
                        var deleting_dic_length;
                        var deleting_dic;
                        for (var index = 1; index < g_current_Grid.rows.length; index++) {
                            var rowChkID = g_current_Grid.rows[index].cells.item(1).getElementsByTagName("input")[0].id.split("_");
                            if (temXml.find("dicEnable").text().trim() == "false" && temXml.find("dicID").text().trim() == rowChkID[rowChkID.length - 1]) {
                                deleting_dic_length = g_current_Grid.rows[index].cells.item(3).getElementsByTagName("label")[0].innerHTML.split(":");
                                g_current_Grid.deleteRow(index);

                                var total_dic_length = g_current_dictator_detail_Grid.getElementsByTagName("label")[3].innerHTML.split(":");
                                var deleting_dic = g_current_dictator_detail_Grid.getElementsByTagName("label")[4].innerHTML;
                                g_current_dictator_detail_Grid.getElementsByTagName("label")[3].innerHTML = pad(parseInt(total_dic_length[0]) - parseInt(deleting_dic_length[0]),3) + ':' + pad(parseInt(total_dic_length[1]) - parseInt(deleting_dic_length[1]),2);
                                g_current_dictator_detail_Grid.getElementsByTagName("label")[4].innerHTML = pad(parseInt(deleting_dic) - 1, 3);
                            }
                        }
                        if (lbl_count == parseInt(dicsXml.length)) {
                            for (var index = 1; index < g_current_Grid.rows.length; index++) {
                                g_current_Grid.rows[index].cells.item(0).getElementsByTagName("label")[0].innerHTML = index;
                            }
                        }

                        lbl_count++;
                    });

                }, 4000);
            }
        }
    } catch (e) {
        alert(e.message);
        $("#overlay").remove();
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////   Change Dictation Minutes   ////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function btn_change_minutes(objRef, dicID) {
    try {
        overloader_view();
        var GridView = objRef.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
        var GridDics = GridView.getElementsByTagName("table");
        g_current_Grid = GridDics[3];
        g_current_dictator_detail_Grid = GridDics[1];
        g_selected_dicID = dicID;
        row = objRef.parentNode.parentNode;

        $('#lblChangeMinCliID').html(g_current_dictator_detail_Grid.getElementsByTagName("label")[1].innerHTML);
        $('#lblChangeMinCliName').html(g_current_dictator_detail_Grid.getElementsByTagName("label")[2].innerHTML);

        $('#lblChangeMinDicName').html(row.cells.item(2).getElementsByTagName("label")[0].innerHTML);
        $('#lblChangeMinDicAccountName').html(row.cells.item(2).getElementsByTagName("label")[1].innerHTML);

        $('#divChangeDictationMinutes').css('visibility', 'visible');

        $("#txtChangedDicMintes").focus();
    } catch (e) { alert(e.message); }
}

var is_running = false;
function btn_Change_dic_minutes_save() {
    try {
        if (is_running) {
            return;
        }

        if (!allnumeric($('#txtChangedDicMintes').val())) {
            alert("Enter numeric value please");
            return;
        }
        is_running = true;
        PageMethods.Change_dic_minutes_save(g_selected_dicID, $('#txtChangedDicMintes').val(), OnSuccess_btn_Change_dic_minutes_save);
    } catch (e) {
        alert(e.message);
    }
    
}

function OnSuccess_btn_Change_dic_minutes_save(res) {
    try {
        var sec = $('#txtChangedDicMintes').val();
        $("#overlay").remove();
        $('#divChangeDictationMinutes').css('visibility', 'hidden');
        is_running = false;

        if (res == "1") {
            row.style.backgroundColor = "#C2F69B";
            g_current_Grid.rows[row.rowIndex].cells.item(3).getElementsByTagName("label")[0].innerHTML = get_mins(sec);
            $('#txtChangedDicMintes').val("");
        } else if (res == "-1") { row.style.backgroundColor = "#ffd5d5"; } else { alert(res); row.style.backgroundColor = "#ffd5d5"; }
    } catch (e) { alert(e.message); }
}


function btn_Change_dic_minutes_save_enter(e) {
    try {
        if (e.keyCode == 13) {
            btn_Change_dic_minutes_save();
        }
    } catch (e) { alert(e.message); }
}

$('#change_minutes_form').submit(function () {
    return false;
});

$(function () {
$('#btnChangedDicMintes').bind('keydown', function (e) { //on keydown for all textboxes  
if (e.keyCode == 13) //if this is enter key  
    e.preventDefault();
});
});

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////   Duplicate Dictation   /////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function btn_duplicate(objRef,dicID) {
    try {
        overloader_view();
        $('#lblDupError').css('display', 'none');

        var GridView = objRef.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
        var GridDics = GridView.getElementsByTagName("table");
        g_current_Grid = GridDics[3];
        g_current_dictator_detail_Grid = GridDics[1];
        row = objRef.parentNode.parentNode;

        g_selected_dicID = dicID;

        $('#lblDupCliID').html(g_current_dictator_detail_Grid.getElementsByTagName("label")[1].innerHTML);
        $('#lblDupCliName').html(g_current_dictator_detail_Grid.getElementsByTagName("label")[2].innerHTML);

        $('#lblDupDicID').html(g_selected_dicID);
        $('#lblDupDicName').html(row.cells.item(2).getElementsByTagName("label")[0].innerHTML);

        $('#lblDupHosName').html(row.cells.item(2).getElementsByTagName("label")[1].innerHTML);

        $('#lblDupDicLength').html(row.cells.item(3).getElementsByTagName("label")[0].innerHTML);
        $('#lblDupDicDate').html(row.cells.item(8).innerHTML);


        $("#tblLogs").find("tr").remove();
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
            html = '<tr>';
            html += '<th style="width:30px;text-align:center;">#</th>';
            html += '<th style="width:75px;text-align:center;">ID</th>';
            html += '<th style="text-align:left;width:235px;padding-left:5px;">Patien Name</th>';
            html += '<th style="text-align:center;width:175px;">Options</th>';
            html += '</tr>';

            var traCount = 1;
            if (xml.find("trans")) {
                var dicsXml = xml.find("trans");
                if (dicsXml.length > 0) {
                    html = '<tr>';
                    html += '<th style="width:30px;text-align:center;">#</th>';
                    html += '<th style="width:75px;text-align:center;">ID</th>';
                    html += '<th style="text-align:left;width:235px;padding-left:5px;">Patien Name</th>';
                    html += '<th style="text-align:center;width:140px;">Options</th>';
                    html += '</tr>';
                    dicsXml.each(function () {
                        var temXml = $(this);
                        html += '<tr class="addedRows" style="position:relative;padding:10px;" id="tr' + temXml.find("traID").text() + '">';
                        html += '<td style="width:30px;text-align:center;">' + traCount++ + '</td>';
                        html += '<td style="width:75px;text-align:center;">' + temXml.find("foID").text() + '-' + temXml.find("drID").text() + '</td>';
                        html += '<td class="centerAlign" style="width:235px;">' + temXml.find("traPatFirstName").text() + ',' + temXml.find("traPatLastName").text() + '/' + temXml.find("traPatientNo").text() + '</td>';
                        html += '<td style="width:140px; text-align:center;" id="td' + temXml.find("traID").text() + '"> <a href="javascript:;" title="View Document" onClick="btn_open_transcription_Click(this,' + temXml.find("traID").text() + ');"><img src="../images/transcriptions.gif"/></a> <a id="btnRev" href="javascript:;" title="Reverse" onClick="btn_reverse_transcription_Click(this,' + temXml.find("traID").text() + ',' + temXml.find("dicID").text() + ');"><img alt="Reverse" src="../images/reverse.gif"/></a> <a href="javascript:;" title="Delete" onClick="btn_delete_transcription_Click(this,' + temXml.find("dicID").text() + ',' + temXml.find("traID").text() + ');"><img src="../images/deleteTranscription.gif"/></a> </td>';
                        html += '</tr>';
                    });
                    html += '<tr><td colspan="4" style="padding-bottom:10px; background-color:white;"></td></tr>';
                } else {
                    html += '<tr class="addedRows" style="padding:10px;">';
                    html += '<td colspan="4" style="width:100%;text-align:center;"> No Transcriptions for this File has been Created yet.</td>';
                    html += '</tr>';
                }
            } 
            $('#tblLogs').append(html);
            html = "";


        $('#divDuplicate').css('visibility', 'visible');
    } catch (e) { alert(e.message); }
    
}

function btn_duplicate_check_save() {
    try {
        PageMethods.mark_duplicate_checked(g_selected_dicID, OnSuccess_btn_duplicate_check_save);
    } catch (e) { alert(e.message); }
}
function OnSuccess_btn_duplicate_check_save(res) {
    if (res == "1") {
        btn_hide_overylay_view();
        $('#img_btDuplicate' + g_selected_dicID).attr('src', '../images/duplicate-check.png');
        $('#lblDupError').css('display', 'none');
    } else {
        $('#lblDupError').css('display','block');
    }
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////   Transcriptions        ///////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////   View Transcriptions   ///////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function btn_view_transcriptions(objRef, dicID) {
    try {
        overloader_wait();

        var GridView = objRef.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
        var GridDics = GridView.getElementsByTagName("table");
        g_current_Grid = GridDics[3];
        g_current_dictator_detail_Grid = GridDics[1];
        g_selected_dicID = dicID;
        row = objRef.parentNode.parentNode;

        PageMethods.get_dic_trans(g_selected_dicID, OnSuccess_btn_view_transcriptions);
    } catch (e) { alert(e.message); }
}

function OnSuccess_btn_view_transcriptions(res) {
    btn_hide_overylay_view();

    overloader_view();
    $('#lblViewTransCliID').html(g_current_dictator_detail_Grid.getElementsByTagName("label")[1].innerHTML);
    $('#lblViewTransCliName').html(g_current_dictator_detail_Grid.getElementsByTagName("label")[2].innerHTML);

    $('#lblViewTransDicName').html(row.cells.item(2).getElementsByTagName("label")[0].innerHTML);
    $('#lblViewTransHosName').html(row.cells.item(2).getElementsByTagName("label")[1].innerHTML);

    $('#divTbl').css('visibility', 'visible');

    $("#tblLogs").find("tr").remove();
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
        html = '<tr>';
        html += '<th style="width:30px;text-align:center;">#</th>';
        html += '<th style="width:75px;text-align:center;">ID</th>';
        html += '<th style="text-align:left;width:235px;padding-left:5px;">Patien Name</th>';
        html += '<th style="text-align:center;width:175px;">Options</th>';
        html += '</tr>';

        var traCount = 1;
        if (xml.find("trans")) {
            var dicsXml = xml.find("trans");
            if (dicsXml.length > 0) {
                html = '<tr>';
                html += '<th style="width:30px;text-align:center;">#</th>';
                html += '<th style="width:75px;text-align:center;">ID</th>';
                html += '<th style="text-align:left;width:235px;padding-left:5px;">Patien Name</th>';
                html += '<th style="text-align:center;width:140px;">Options</th>';
                html += '</tr>';
                dicsXml.each(function () {
                    var temXml = $(this);
                    html += '<tr class="addedRows" style="position:relative;padding:10px;" id="tr' + temXml.find("traID").text() + '">';
                    html += '<td style="width:30px;text-align:center;">' + traCount++ + '</td>';
                    html += '<td style="width:75px;text-align:center;">' + temXml.find("foID").text() + '-' + temXml.find("drID").text() + '</td>';
                    html += '<td class="centerAlign" style="width:235px;">' + temXml.find("traPatFirstName").text() + ',' + temXml.find("traPatLastName").text() + '/' + temXml.find("traPatientNo").text() + '</td>';
                    html += '<td style="width:140px; text-align:center;" id="td' + temXml.find("traID").text() + '"> <a href="javascript:;" title="View Document" onClick="btn_open_transcription_Click(this,' + temXml.find("traID").text() + ');"><img src="../images/transcriptions.gif"/></a> <a id="btnRev" href="javascript:;" title="Reverse" onClick="btn_reverse_transcription_Click(this,' + temXml.find("traID").text() + ',' + temXml.find("dicID").text() + ');"><img alt="Reverse" src="../images/reverse.gif"/></a> <a href="javascript:;" title="Delete" onClick="btn_delete_transcription_Click(this,' + temXml.find("dicID").text() + ',' + temXml.find("traID").text() + ');"><img src="../images/deleteTranscription.gif"/></a> </td>';
                    html += '</tr>';
                });
                html += '<tr><td colspan="4" style="padding-bottom:10px; background-color:white;"></td></tr>';
            } else {
                html += '<tr class="addedRows" style="padding:10px;">';
                html += '<td colspan="4" style="width:100%;text-align:center;"> No Transcriptions for this File has been Created yet.</td>';
                html += '</tr>';
            }
        } 
        $('#tblLogs').append(html);
        html = "";
    } catch (e) { alert(e.message);}
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////  Reverse Transcription   /////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function btn_reverse_transcription_Click(objRef,traID,dicID) {
    try {
        g_selected_traID = traID;
        g_selected_dicID = dicID;
        $('.addedDiv').remove();
        $('.DivNoRow').remove();
        PageMethods.reverse_trascription(traID, dicID, OnSuccess_btn_reverse_transcription_Click);
    } catch (e) { alert(e.message); }
}

function OnSuccess_btn_reverse_transcription_Click(res) {
    try {
        var str_msg = 'No Documnet.';
        var html_empty = '<div class="DivNoRow" style="display:none;width:170px; background-color:white;position:absolute;z-index:99999;right:-111px;border-top-left-radius: 7px;border-top-right-radius: 7px;padding:10px;"><div style="text-align:left;"><span style="color:red;font-weight:bold;font-size:11px;">' + str_msg + '</span> <span onClick="javascript:this.parentNode.parentNode.style.visibility = &quot;hidden&quot;;" style="text-align:right;float:right;cursor:pointer;color:black;font-weight:bold;"><i>X</i></span><div>';
        if (res == "0") {
            $('#td' + g_selected_traID).after(html_empty);
            var p = $('div.DivNoRow');
            p.slideDown("slow").fadeOut(2500);
            p.queue(function () {
                p.remove();
                p = null;
            });
        } else if (res != "" && res != "0") {
            var html = '<div class="addedDiv" style="display:none;width:170px; background-color:white;position:absolute;z-index:99999;right:-111px;border-top-left-radius: 7px;border-top-right-radius: 7px;padding:10px;"><div style="text-align:left;"><span style="color:red;font-size:11px;">' + res + '</span> <span onClick="javascript:this.parentNode.parentNode.style.visibility = &quot;hidden&quot;;" style="text-align:right;float:right;cursor:pointer;color:#b9bcc0;font-weight:bold;">X</span><div>';
            $('#td' + g_selected_traID).after(html);
            $('div.addedDiv').slideDown("slow");
        } else if(res == ""){
            $('#td' + g_selected_traID).after(html_empty);
            var p = $('div.DivNoRow');
            p.slideDown("slow").fadeOut(2500);
            p.queue(function () {
                p.remove();
                p = null;
            });
        }
    } catch (e) {
        alert(e.message);
    }
}

function btn_reverse_tra_role(dicID, traID, roleID) {
    try {
        var r = confirm("Are you sure you want to Reverse the Transcription?");
        if (!r) { return; }

        PageMethods.reverse_tra_role_save(dicID, traID, roleID, OnSuccess_btn_reverse_tra_role);

    } catch (e) { alert(e.message); }
}
function OnSuccess_btn_reverse_tra_role(res) {
    try {
        var resp = res.split(",");
        if (resp[0] == "1") {
            $('div.addedDiv').slideUp("slow").fadeOut(2500);
            $('#tr' + g_selected_traID + ' td')
            var p = $('#tr' + g_selected_traID).css("background-color", "#C2F69B");
            p.show(1500);
            p.queue(function () {
                p.find('td').css("background-color", "#C2F69B");
                p = null;
            });
            refresh_dic_row(resp[1]);
        } else if (resp[0] == "0") { $('#tr' + g_selected_traID + ' td').css('background-color', '#ffd5d5'); } else { $('#tr' + g_selected_traID + ' td').css('background-color', '#ffd5d5'); alert(res); }
    } catch (e) { alert(e.message); }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////   Open Transcriptions   ///////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function btn_open_transcription_Click(objRef, traID) {
    try {
        g_selected_traID = traID;
        $('.addedDiv').remove();
        $('.DivNoRow').remove();
        PageMethods.get_transcriptions_roles_files(traID, OnSuccess_btn_open_transcription_Click);

    } catch (e) { alert(e.message); }
}

function OnSuccess_btn_open_transcription_Click(res_open_doc) {
    try {
        if (res_open_doc != "0" && res_open_doc != "") {
            var html = '<div class="addedDiv" style="display:none;width:170px; background-color:white;position:absolute;z-index:99999;right:-111px;border-top-left-radius: 7px;border-top-right-radius: 7px;padding:10px;"><div style="text-align:left;"><span style="color:red;font-size:11px;">' + res_open_doc + '</span> <span onClick="javascript:this.parentNode.parentNode.style.visibility = &quot;hidden&quot;;" style="text-align:right;float:right;cursor:pointer;color:#b9bcc0;font-weight:bold;">X</span><div>';
            $('#td' + g_selected_traID).after(html);
            $('div.addedDiv').slideDown("slow");
        } else if (res_open_doc == "0") {
            var str_msg = 'No Documnet.';
            var html_empty_doc = '<div class="DivNoRow" style="display:none;width:300px; background-color:white;position:absolute;z-index:99999;right:-227px;border-top-left-radius: 7px;border-top-right-radius: 7px;padding:10px;"><div style="text-align:left;"><span style="color:red;font-weight:bold;font-size:11px;">' + str_msg + '</span> <span onClick="javascript:this.parentNode.parentNode.style.visibility = &quot;hidden&quot;;" style="text-align:right;float:right;cursor:pointer;color:black;font-weight:bold;"><i>X</i></span><div>';
            $('#td' + g_selected_traID).after(html_empty_doc);
            var p = $('div.DivNoRow');
            p.slideDown("slow").fadeOut(2500);
            p.queue(function () {
                p.remove();
                p = null;
            });
        } else if (res_open_doc == "") {
            var str_msg = 'No Documnet.';
            var html_empty_doc = '<div class="DivNoRow" style="display:none;width:300px; background-color:white;position:absolute;z-index:99999;right:-227px;border-top-left-radius: 7px;border-top-right-radius: 7px;padding:10px;"><div style="text-align:left;"><span style="color:red;font-weight:bold;font-size:11px;">' + str_msg + '</span> <span onClick="javascript:this.parentNode.parentNode.style.visibility = &quot;hidden&quot;;" style="text-align:right;float:right;cursor:pointer;color:black;font-weight:bold;"><i>X</i></span><div>';
            $('#td' + g_selected_traID).after(html_empty_doc);
            var p = $('div.DivNoRow');
            p.slideDown("slow").fadeOut(2500);
            p.queue(function () {
                p.remove();
                p = null;
            });

        }
    } catch (e) {
        alert(e.message);
    }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////   Delete Transcription   //////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function btn_delete_transcription_Click(objRef, dicID, traID) {
    try {
        var r = confirm("Are you sure you want to Delete the Transcription?");
        if (!r) { return; }

        g_selected_traID = traID;
        PageMethods.delete_transcription_file(dicID, traID, OnSuccess_btn_delete_transcription_Click);

    } catch (e) { alert(e.message); }
}

function OnSuccess_btn_delete_transcription_Click(res) {
    try {
        var resp = res.split(",");
        var str_msg = 'The Dictaiton File have been Uploaded.';
        if (resp[0] == "1") {
            var p = $('#tr' + g_selected_traID + ' td').css("background-color", "#C2F69B");
            p.fadeOut(2500);
            p.queue(function () {
                p.remove()
                p = null;
            });
            refresh_dic_row(resp[1]);
        } else if (resp[0] == "0") {
            $('#tr' + g_selected_traID).css("background-color", "#ffd5d5");
        }
    } catch (e) {
        alert(e.message);
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////   Refresh Dictations List   //////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function refresh_dic_row(res) {
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

        if (xml.find("dics")) {
            var dicsXml = xml.find("dics");
            if (dicsXml.length > 0) {
                dicsXml.each(function () {
                    var temXml = $(this);
                    if (temXml.find("empID").text() != "") {
                        var emp_name = temXml.find("empName").text().trim();
                        var dic_date = temXml.find("dicDT").text().trim();
                        if (temXml.find("empID").text().trim() == "0") {
                            emp_name = "-";
                            dic_date = "";
                        }
                    }

                    try {
                        if (temXml.find("rolID").text().trim() == "MT") {
                            for (var index = 1; index < g_current_Grid.rows.length; index++) {
                                var val = g_current_Grid.rows[index].cells.item(1).getElementsByTagName("input")[0].id.split("_");
                                var dicID_chk = val[val.length - 1];
                                if (dicID_chk == temXml.find("dicID").text().trim()) {
                                    var chkboxMT = g_current_Grid.rows[index].cells.item(4).getElementsByTagName("input")[0];
                                    if (chkboxMT.type != "checkbox") { return; }
                                    if (g_current_Grid.rows[index].cells.item(4).getElementsByTagName("span").length > 2) {
                                        g_current_Grid.rows[index].cells.item(4).getElementsByTagName("input")[0].checked = false;
                                        $('#' + g_current_Grid.rows[index].cells.item(4).getElementsByTagName("span")[1].id).html(emp_name);
                                        $('#' + g_current_Grid.rows[index].cells.item(4).getElementsByTagName("span")[2].id).html(dic_date);
                                        //setHeaderCheck(g_current_Grid.rows[index].cells.item(4).getElementsByTagName("input")[0], false);

                                        if (temXml.find("diclStatus").text().trim() == 0) {
                                            g_current_Grid.rows[index].cells.item(4).getElementsByTagName("span")[1].style.color = "#808080";
                                        } else if (temXml.find("diclStatus").text().trim() == 1) {
                                            g_current_Grid.rows[index].cells.item(4).getElementsByTagName("span")[1].style.color = "#F5B40E";
                                        } else if (temXml.find("diclStatus").text().trim() == 2) {
                                            g_current_Grid.rows[index].cells.item(4).getElementsByTagName("span")[1].style.color = "#4F9DEC";
                                        } else if (temXml.find("diclStatus").text().trim() == 3) {
                                            g_current_Grid.rows[index].cells.item(4).getElementsByTagName("span")[1].style.color = "#90C140";
                                        } else {
                                            g_current_Grid.rows[index].cells.item(4).getElementsByTagName("span")[1].style.color = "#F64244";
                                        }
                                    } else {
                                        g_current_Grid.rows[index].cells.item(4).getElementsByTagName("input")[0].checked = false;
                                        $('#' + g_current_Grid.rows[index].cells.item(4).getElementsByTagName("span")[0].id).html(emp_name);
                                        $('#' + g_current_Grid.rows[index].cells.item(4).getElementsByTagName("span")[1].id).html(dic_date);
                                        setHeaderCheck(g_current_Grid.rows[index].cells.item(4).getElementsByTagName("input")[0], false);

                                        if (temXml.find("diclStatus").text().trim() == 0) {
                                            g_current_Grid.rows[index].cells.item(4).getElementsByTagName("span")[0].style.color = "#808080";
                                        } else if (temXml.find("diclStatus").text().trim() == 1) {
                                            g_current_Grid.rows[index].cells.item(4).getElementsByTagName("span")[0].style.color = "#F5B40E";
                                        } else if (temXml.find("diclStatus").text().trim() == 2) {
                                            g_current_Grid.rows[index].cells.item(4).getElementsByTagName("span")[0].style.color = "#4F9DEC";
                                        } else if (temXml.find("diclStatus").text().trim() == 3) {
                                            g_current_Grid.rows[index].cells.item(4).getElementsByTagName("span")[0].style.color = "#90C140";
                                        } else {
                                            g_current_Grid.rows[index].cells.item(4).getElementsByTagName("span")[0].style.color = "#F64244";
                                        }
                                    }
                                    if (temXml.find("diclStatus").text().trim() < 2) {
                                        chkboxMT.disabled = false;
                                    } else {
                                        chkboxMT.disabled = true;
                                    }
                                }
                            }
                        }
                    } catch (e) { alert("MT, " + e.message); }

                    try {
                        if (temXml.find("rolID").text().trim() == "QC") {
                            for (var index = 1; index < g_current_Grid.rows.length; index++) {
                                var val = g_current_Grid.rows[index].cells.item(1).getElementsByTagName("input")[0].id.split("_");
                                var dicID_chk = val[val.length - 1];
                                if (dicID_chk == temXml.find("dicID").text().trim()) {
                                    var chkboxQC = g_current_Grid.rows[index].cells.item(5).getElementsByTagName("input")[0];
                                    if (chkboxQC.type != "checkbox") { return; }
                                    if (g_current_Grid.rows[index].cells.item(5).getElementsByTagName("span").length > 2) {
                                        g_current_Grid.rows[index].cells.item(5).getElementsByTagName("input")[0].checked = false;
                                        $('#' + g_current_Grid.rows[index].cells.item(5).getElementsByTagName("span")[1].id).html(emp_name);
                                        $('#' + g_current_Grid.rows[index].cells.item(5).getElementsByTagName("span")[2].id).html(dic_date);
                                        //setHeaderCheck(g_current_Grid.rows[index].cells.item(5).getElementsByTagName("input")[0], false);

                                        if (temXml.find("diclStatus").text().trim() == 0) {
                                            g_current_Grid.rows[index].cells.item(5).getElementsByTagName("span")[1].style.color = "#808080";
                                        } else if (temXml.find("diclStatus").text().trim() == 1) {
                                            g_current_Grid.rows[index].cells.item(5).getElementsByTagName("span")[1].style.color = "#F5B40E";
                                        } else if (temXml.find("diclStatus").text().trim() == 2) {
                                            g_current_Grid.rows[index].cells.item(5).getElementsByTagName("span")[1].style.color = "#4F9DEC";
                                        } else if (temXml.find("diclStatus").text().trim() == 3) {
                                            g_current_Grid.rows[index].cells.item(5).getElementsByTagName("span")[1].style.color = "#90C140";
                                        } else {
                                            g_current_Grid.rows[index].cells.item(5).getElementsByTagName("span")[1].style.color = "#F64244";
                                        }
                                    } else {
                                        g_current_Grid.rows[index].cells.item(5).getElementsByTagName("input")[0].checked = false;
                                        $('#' + g_current_Grid.rows[index].cells.item(5).getElementsByTagName("span")[0].id).html(emp_name);
                                        $('#' + g_current_Grid.rows[index].cells.item(5).getElementsByTagName("span")[1].id).html(dic_date);
                                        setHeaderCheck(g_current_Grid.rows[index].cells.item(5).getElementsByTagName("input")[0], false);

                                        if (temXml.find("diclStatus").text().trim() == 0) {
                                            g_current_Grid.rows[index].cells.item(5).getElementsByTagName("span")[0].style.color = "#808080";
                                        } else if (temXml.find("diclStatus").text().trim() == 1) {
                                            g_current_Grid.rows[index].cells.item(5).getElementsByTagName("span")[0].style.color = "#F5B40E";
                                        } else if (temXml.find("diclStatus").text().trim() == 2) {
                                            g_current_Grid.rows[index].cells.item(5).getElementsByTagName("span")[0].style.color = "#4F9DEC";
                                        } else if (temXml.find("diclStatus").text().trim() == 3) {
                                            g_current_Grid.rows[index].cells.item(5).getElementsByTagName("span")[0].style.color = "#90C140";
                                        } else {
                                            g_current_Grid.rows[index].cells.item(5).getElementsByTagName("span")[0].style.color = "#F64244";
                                        }
                                    }
                                    if (temXml.find("diclStatus").text().trim() < 2) {
                                        chkboxQC.disabled = false;
                                    } else {
                                        chkboxQC.disabled = true;
                                    }
                                }
                            }
                        }
                    } catch (e) { alert("QC, " + e.message); }

                    try {
                        if (temXml.find("rolID").text().trim() == "PR") {
                            for (var index = 1; index < g_current_Grid.rows.length; index++) {
                                var val = g_current_Grid.rows[index].cells.item(1).getElementsByTagName("input")[0].id.split("_");
                                var dicID_chk = val[val.length - 1];
                                if (dicID_chk == temXml.find("dicID").text().trim()) {
                                    var chkboxPR = g_current_Grid.rows[index].cells.item(6).getElementsByTagName("input")[0];
                                    if (chkboxPR.type != "checkbox") { return; }
                                    if (g_current_Grid.rows[index].cells.item(6).getElementsByTagName("span").length > 2) {
                                        g_current_Grid.rows[index].cells.item(6).getElementsByTagName("input")[0].checked = false;
                                        $('#' + g_current_Grid.rows[index].cells.item(6).getElementsByTagName("span")[1].id).html(emp_name);
                                        $('#' + g_current_Grid.rows[index].cells.item(6).getElementsByTagName("span")[2].id).html(dic_date);
                                        //setHeaderCheck(g_current_Grid.rows[index].cells.item(6).getElementsByTagName("input")[0], false);

                                        if (temXml.find("diclStatus").text().trim() == 0) {
                                            g_current_Grid.rows[index].cells.item(6).getElementsByTagName("span")[1].style.color = "#808080";
                                        } else if (temXml.find("diclStatus").text().trim() == 1) {
                                            g_current_Grid.rows[index].cells.item(6).getElementsByTagName("span")[1].style.color = "#F5B40E";
                                        } else if (temXml.find("diclStatus").text().trim() == 2) {
                                            g_current_Grid.rows[index].cells.item(6).getElementsByTagName("span")[1].style.color = "#4F9DEC";
                                        } else if (temXml.find("diclStatus").text().trim() == 3) {
                                            g_current_Grid.rows[index].cells.item(6).getElementsByTagName("span")[1].style.color = "#90C140";
                                        } else {
                                            g_current_Grid.rows[index].cells.item(6).getElementsByTagName("span")[1].style.color = "#F64244";
                                        }
                                    } else {
                                        g_current_Grid.rows[index].cells.item(6).getElementsByTagName("input")[0].checked = false;
                                        $('#' + g_current_Grid.rows[index].cells.item(6).getElementsByTagName("span")[0].id).html(emp_name);
                                        $('#' + g_current_Grid.rows[index].cells.item(6).getElementsByTagName("span")[1].id).html(dic_date);
                                        setHeaderCheck(g_current_Grid.rows[index].cells.item(6).getElementsByTagName("input")[0], false);

                                        if (temXml.find("diclStatus").text().trim() == 0) {
                                            g_current_Grid.rows[index].cells.item(6).getElementsByTagName("span")[0].style.color = "#808080";
                                        } else if (temXml.find("diclStatus").text().trim() == 1) {
                                            g_current_Grid.rows[index].cells.item(6).getElementsByTagName("span")[0].style.color = "#F5B40E";
                                        } else if (temXml.find("diclStatus").text().trim() == 2) {
                                            g_current_Grid.rows[index].cells.item(6).getElementsByTagName("span")[0].style.color = "#4F9DEC";
                                        } else if (temXml.find("diclStatus").text().trim() == 3) {
                                            g_current_Grid.rows[index].cells.item(6).getElementsByTagName("span")[0].style.color = "#90C140";
                                        } else {
                                            g_current_Grid.rows[index].cells.item(6).getElementsByTagName("span")[0].style.color = "#F64244";
                                        }
                                    }
                                    if (temXml.find("diclStatus").text().trim() < 2) {
                                        chkboxPR.disabled = false;
                                    } else {
                                        chkboxPR.disabled = true;
                                    }
                                }
                            }
                        }
                    } catch (e) { alert("PR, " + e.message); }

                    try {
                        if (temXml.find("rolID").text().trim() == "FR") {
                            for (var index = 1; index < g_current_Grid.rows.length; index++) {
                                var val = g_current_Grid.rows[index].cells.item(1).getElementsByTagName("input")[0].id.split("_");
                                var dicID_chk = val[val.length - 1];
                                if (dicID_chk == temXml.find("dicID").text().trim()) {
                                    var chkboxFR = g_current_Grid.rows[index].cells.item(7).getElementsByTagName("input")[0];
                                    if (chkboxFR.type != "checkbox") { return; }
                                    if (g_current_Grid.rows[index].cells.item(7).getElementsByTagName("span").length > 2) {
                                        g_current_Grid.rows[index].cells.item(7).getElementsByTagName("input")[0].checked = false;
                                        $('#' + g_current_Grid.rows[index].cells.item(7).getElementsByTagName("span")[1].id).html(emp_name);
                                        $('#' + g_current_Grid.rows[index].cells.item(7).getElementsByTagName("span")[2].id).html(dic_date);
                                        //setHeaderCheck(g_current_Grid.rows[index].cells.item(7).getElementsByTagName("input")[0], false);

                                        if (temXml.find("diclStatus").text().trim() == 0) {
                                            g_current_Grid.rows[index].cells.item(7).getElementsByTagName("span")[1].style.color = "#808080";
                                        } else if (temXml.find("diclStatus").text().trim() == 1) {
                                            g_current_Grid.rows[index].cells.item(7).getElementsByTagName("span")[1].style.color = "#F5B40E";
                                        } else if (temXml.find("diclStatus").text().trim() == 2) {
                                            g_current_Grid.rows[index].cells.item(7).getElementsByTagName("span")[1].style.color = "#4F9DEC";
                                        } else if (temXml.find("diclStatus").text().trim() == 3) {
                                            g_current_Grid.rows[index].cells.item(7).getElementsByTagName("span")[1].style.color = "#90C140";
                                        } else {
                                            g_current_Grid.rows[index].cells.item(7).getElementsByTagName("span")[1].style.color = "#F64244";
                                        }
                                    } else {
                                        g_current_Grid.rows[index].cells.item(7).getElementsByTagName("input")[0].checked = false;
                                        $('#' + g_current_Grid.rows[index].cells.item(7).getElementsByTagName("span")[0].id).html(emp_name);
                                        $('#' + g_current_Grid.rows[index].cells.item(7).getElementsByTagName("span")[1].id).html(dic_date);
                                        setHeaderCheck(g_current_Grid.rows[index].cells.item(7).getElementsByTagName("input")[0], false);

                                        if (temXml.find("diclStatus").text().trim() == 0) {
                                            g_current_Grid.rows[index].cells.item(7).getElementsByTagName("span")[0].style.color = "#808080";
                                        } else if (temXml.find("diclStatus").text().trim() == 1) {
                                            g_current_Grid.rows[index].cells.item(7).getElementsByTagName("span")[0].style.color = "#F5B40E";
                                        } else if (temXml.find("diclStatus").text().trim() == 2) {
                                            g_current_Grid.rows[index].cells.item(7).getElementsByTagName("span")[0].style.color = "#4F9DEC";
                                        } else if (temXml.find("diclStatus").text().trim() == 3) {
                                            g_current_Grid.rows[index].cells.item(7).getElementsByTagName("span")[0].style.color = "#90C140";
                                        } else {
                                            g_current_Grid.rows[index].cells.item(7).getElementsByTagName("span")[0].style.color = "#F64244";
                                        }
                                    }
                                    if (temXml.find("diclStatus").text().trim() < 2) {
                                        chkboxFR.disabled = false;
                                    } else {
                                        chkboxFR.disabled = true;
                                    }
                                }
                            }
                        }
                    } catch (e) { alert("FR, " + e.message); }

                });
            }
        }
    } catch (e) {
        alert("Reloading, " + e.message);
    }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////   Helper Functions   /////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    function getAllTra_Ids(objGrid, index) {
        try {
            var traIds = "";
            var inputList = objGrid.rows[0].cells.item(index).getElementsByTagName("input");
            if (inputList[0].type == "checkbox" && inputList[0].checked == true) {
                for (var i = 1; i < objGrid.rows.length; i++) {
                    var inputList = objGrid.rows[i].cells.item(index).getElementsByTagName("input");

                    if (inputList[0].type == "checkbox" && inputList[0].checked == true) {
                        if (traIds == "") {
                            traIds = "'" + inputList[0].id.split("_")[inputList[0].id.split("_").length - 1] + "'";
                        } else {
                            traIds = traIds + ",'" + inputList[0].id.split("_")[inputList[0].id.split("_").length - 1] + "'";
                        }
                    }
                }
            }
            return traIds;
        }catch(e){
            alert(e.message);
        }
    }


    function get_all_checked_ids(objGrid, index) {
        try {
            var traIds = "";
            var inputList = objGrid.rows[0].cells.item(index).getElementsByTagName("input");
            if (inputList[0].type == "checkbox" && inputList[0].checked == true) {
                for (var i = 1; i < objGrid.rows.length; i++) {
                    var inputList = objGrid.rows[i].cells.item(index).getElementsByTagName("input");

                    if (inputList[0].type == "checkbox" && inputList[0].checked == true) {
                        if (traIds == "") {
                            traIds = "'" + inputList[0].id.split("_")[inputList[0].id.split("_").length - 1] + "'";
                        } else {
                            traIds = traIds + ",'" + inputList[0].id.split("_")[inputList[0].id.split("_").length - 1] + "'";
                        }
                    }
                }
            }
            return traIds;
        } catch (e) {
            alert(e.message);
        }
    }


    function get_all_chkDics_ids(objRef) {
        try {
            var chkDicsIds = "";
            var objGridMain = objRef.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode;
            var GridDics = objGridMain.getElementsByTagName("table")[3];
            var inputList = GridDics.rows[0].cells.item(1).getElementsByTagName("input")[0];

            if (inputList.type == "checkbox" && inputList.checked == true) {
                for (var i = 1; i < GridDics.rows.length; i++) {
                    var inputList = GridDics.rows[i].cells.item(1).getElementsByTagName("input");

                    if (inputList[0].type == "checkbox" && inputList[0].checked == true) {
                        if (chkDicsIds == "") {
                            chkDicsIds = "'" + inputList[0].id.split("_")[inputList[0].id.split("_").length - 1] + "'";
                        } else {
                            chkDicsIds = chkDicsIds + ",'" + inputList[0].id.split("_")[inputList[0].id.split("_").length - 1] + "'";
                        }
                    }
                }
            }
            return chkDicsIds;
        } catch (e) {
            alert(e.message);
        }
    }


    function checkAll(objRef, is_check) {
        try {
            var GridView = objRef.parentNode.parentNode.parentNode.parentNode;
            var chkHead = GridView.rows[0].cells.item(4).getElementsByTagName("input")[0];

            if (chkHead.type == "checkbox") {
                for (var i = 1; i < GridView.rows.length; i++) {
                    var chkbox = GridView.rows[i].cells.item(objRef.parentNode.cellIndex).getElementsByTagName("input")[0];
                    if (!chkbox.disabled) {
                        chkbox.checked = is_check;
                    }
                }
            }
        } catch (e) {
            alert(e.message);
            $("#overlay").remove();

        }
    }


    function checkAllDics(objRef, is_check) {
        try {
            var GridView = objRef.parentNode.parentNode.parentNode.parentNode;
            var chkHead = GridView.rows[0].cells.item(1).getElementsByTagName("input")[0];

            if (chkHead.type == "checkbox") {
                for (var i = 1; i < GridView.rows.length; i++) {
                    var chkbox = GridView.rows[i].cells.item(objRef.parentNode.cellIndex).getElementsByTagName("input")[0];
                    chkbox.checked = is_check;
                }
            }
        } catch (e) {
            alert(e.message);
        }
    }


    function setHeaderCheck(objRef, is_check) {
        try {
            var GridView = objRef.parentNode.parentNode.parentNode.parentNode;
            var chkHead = GridView.rows[0].cells.item(objRef.parentNode.cellIndex).getElementsByTagName("input")[0];
            if (!is_check) {
                var chk = false;
                for (var i = 1; i < GridView.rows.length; i++) {
                    var chkbox = GridView.rows[i].cells.item(objRef.parentNode.cellIndex).getElementsByTagName("input")[0];
                    if (chkbox.checked) { chk = true; break; }
                }

                if (!chk) {
                    chkHead.checked = is_check;
                }
            } else {
                chkHead.checked = is_check;
            }
        
        } catch (e) {
            var GridView = objRef.parentNode.parentNode.parentNode.parentNode.parentNode;
            var chkHead = GridView.rows[0].cells.item(objRef.parentNode.parentNode.cellIndex).getElementsByTagName("input")[0];
            if (!is_check) {
                var chk = false;
                for (var i = 1; i < GridView.rows.length; i++) {
                    var chkbox = GridView.rows[i].cells.item(objRef.parentNode.parentNode.cellIndex).getElementsByTagName("input")[0];
                    if (chkbox.checked) { chk = true; break; }
                }

                if (!chk) {
                    chkHead.checked = is_check;
                }
            } else {
                chkHead.checked = is_check;
            }
        }
    
    }


    function overloader_view() {
        try {
            var docHeight = $(document).height();
            $("body").append(overlay_view);
            $("#overlay")
            .height(docHeight)
            .css({
                'opacity': 0.4,
                'position': 'absolute',
                'background-color': 'black',
                'width': '100%',
                'z-index': 5000
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
                'z-index': 5000
            });
        } catch (e) {
            alert(e.message);
            $("#overlay").remove();
        }
    }


    function pad(str, max) {
        str = str.toString();
        return str.length < max ? pad("0" + str, max) : str;
    }


    function allnumeric(str) {
        var re = /^[0-9]+$/;
        if (str.match(re)) {
            return true;
        }
        else {
            return false;
        }
    }

    function get_mins(Seconds) {
        var min, min2;
        min = Seconds / 60;
        min2 = Seconds % 60;
        var arr = min.toString().split(".");

        if(min2 < 10 && min2 != 0){
            min2 = "0" + min2;
        }

        if(min2 != 0){
            if(min < 10){
                min = "00" + arr[0] + ":" + min2;
            }else if( min < 99){
                min = "0" + arr[0] + ":" + min2;
                Else
                min = arr[0] + ":" + min2;
            }
        }else{
            if( min < 10){
                min = "00" + arr[0] + ":" + "00";
            }else if(min < 99){
                min = "0" + arr[0] + ":" + "00";
            }else{
                min = arr[0] + ":" + "00";
            }
        }
        return min;
    }

    function btn_hide_overylay_view() {
        $('#divTbl').css('visibility', 'hidden');
        $('#divChangeDictationMinutes').css('visibility', 'hidden');
        $('#divDuplicate').css('visibility', 'hidden');
        
        $("#overlay").remove();
    }

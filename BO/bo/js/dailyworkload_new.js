var g_selectedDate = "";
var g_selectedDatePending = "";
var g_selectedRow = null;
var g_objRef = null;
var g_isExpand = 0;

$(document).ready(function () {

    $(window).load(function () {
        overloader_wait();
        $("#tblDictatorsWorkload").find("tr").remove();
        $("#tblDictatorsWorkloadPending").find("tr").remove();

        loadDictatorsDailyworkload();
        if ($('#ctl00_ContentPlaceHolder1_chkBaklog').attr('checked')) {
            loadDictatorsDailyworkloadPending();
        }
    });

    //$('#btnDownload').click(function () {
    //    PageMethods.btnDownloadAll_Click("'699861','699863','699864','699865'", onSuccessDownloadAll);
    //});

    //function onSuccessDownloadAll(res) {
    //    window.open('../dictationsZipPath.aspx?fileName='+res);
    //}

    $("#btnView").click(function () {
        overloader_wait();
        $("#tblDictatorsWorkload").find("tr").remove();
        $("#tblDictatorsWorkloadPending").find("tr").remove();

        loadDictatorsDailyworkload();
        if ($('#ctl00_ContentPlaceHolder1_chkBaklog').attr('checked')) {
            loadDictatorsDailyworkloadPending();
        }
    });

    $("#btnExpand").click(function () {
        if (g_isExpand == 0) {
            $('.tblDictationsLoader').css('display', 'block');
            $('.img_getDr').attr('src', '../icon/downArrow.png');
            $('#btnExpand').val('Collapse');
            g_isExpand = 1;
        } else {
            $('.tblDictationsLoader').css('display', 'none');
            $('.img_getDr').attr('src', '../icon/rightArrow.png');
            g_isExpand = 0;
            $('#btnExpand').val('Expand');
        }
    });


    function loadDictatorsDailyworkload() {
        try {
            g_selectedDate = $('#ctl00_ContentPlaceHolder1_CPMain').val();
            if (g_selectedDate != "")
                PageMethods.loadDailyworkload(g_selectedDate, onSuccess_loadDictatorsDailyworkload);
        } catch (e) { alert(e.message); hide_overylay_wait(); }
    }

    function onSuccess_loadDictatorsDailyworkload(res) {
        try {
            if (res == null) { $('#btnDownloadWorkloadDics').css("display", "none"); return };
            var dr_html = "";
            dr_html = '<tr style="height:22px;"><th style="width:25px;"></th><th style="width:33px;">#</th><th style="width:33px;"></th><th style="width:85px;">Difficulty</th><th style="width:85px;">ID</th><th style="width:217px;">Name</th><th style="width:105px;">Minutes</th><th style="width:105px;">Dictations</th><th style="width:105px;border-left:1px solid #000;">MT Done</th><th style="width:105px;">QC Done</th><th style="width:105px;">PR Done</th><th style="width:105px;">FR Done</th></tr>';
            $('#tblDictatorsWorkload').append(dr_html);
            var DictatorList = {};
            DictatorList = res;
            var rowCount = 1;
            var totalDictations = 0;
            var totalMinutes = 0;
            var totalMTdoneMins = 0;
            var totalQCdoneMins = 0;
            var totalPRdoneMins = 0;
            var totalFRdoneMins = 0;

            if (DictatorList.length > 0) {
                $.each(DictatorList, function (index, dr) {
                    var row_color = "";
                    if (index % 2 == 0)
                        row_color = "background-color:#ECECEC;";
                    else
                        row_color = "background-color:#ECECEC;";

                    dr_html = '<tr style="height:25px;' + row_color + '" id="tr_' + dr.drID.trim() + '">' +
                                '<td style="text-align:center;vertical-align:middle;"><img id="img_' + dr.drID.trim() + '" class="img_getDr" style="cursor:pointer;" src="../icon/rightArrow.png" onclick="getDictator_dictations(this,' + dr.drID.trim() + ',' + dr.foID.trim() + ',false,&quot &quot)" /></td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + rowCount + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;"><input style="width:20px;" type="image" src="../Icon/download1.png" title="Download Dictations" onclick="download_dr_dics(this,' + dr.drID.trim() + ',' + dr.foID.trim() + ')"></td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + dr.drDifficulty + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + dr.drID + '</td>' +
                                '<td style="text-align:left;vertical-align:middle;padding-left:5px;">' + dr.drLastName + ', ' + dr.drFirstName + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + get_mins(dr.totalMinutes) + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + dr.totalDictations + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;border-left:1px solid #000;' + get_done_color(dr.totalMinutes, dr.MTdoneMins) + '">' + get_mins(dr.MTdoneMins) + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;' + get_done_color(dr.totalMinutes, dr.QCdoneMins) + '">' + get_mins(dr.QCdoneMins) + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;' + get_done_color(dr.totalMinutes, dr.PRdoneMins) + '">' + get_mins(dr.PRdoneMins) + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;' + get_done_color(dr.totalMinutes, dr.FRdoneMins) + '">' + get_mins(dr.FRdoneMins) + '</td>' +
                            '</tr>';
                    $('#tblDictatorsWorkload').append(dr_html);
                    rowCount = rowCount + 1;
                    totalDictations = totalDictations + parseInt(dr.totalDictations);
                    totalMinutes = parseFloat(totalMinutes) + parseFloat(dr.totalMinutes);
                    totalMTdoneMins = parseFloat(totalMTdoneMins) + parseFloat(dr.MTdoneMins);
                    totalQCdoneMins = parseFloat(totalQCdoneMins) + parseFloat(dr.QCdoneMins);
                    totalPRdoneMins = parseFloat(totalPRdoneMins) + parseFloat(dr.PRdoneMins);
                    totalFRdoneMins = parseFloat(totalFRdoneMins) + parseFloat(dr.FRdoneMins);

                    onSuccess_getDictator_dictations(dr.listDications, dr.drID.trim(), '');
                });

                dr_html = '<tr style="font-weight:bold;">' +
                                '<td style="text-align:center;vertical-align:middle;"></td>' +
                                '<td style="text-align:center;vertical-align:middle;"></td>' +
                                '<td style="text-align:center;vertical-align:middle;"></td>' +
                                '<td style="text-align:center;vertical-align:middle;"></td>' +
                                '<td style="text-align:center;vertical-align:middle;"></td>' +
                                '<td style="text-align:left;vertical-align:middle;padding-left:5px;"></td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + get_mins(totalMinutes) + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + totalDictations + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + get_mins(totalMTdoneMins) + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + get_mins(totalQCdoneMins) + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + get_mins(totalPRdoneMins) + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + get_mins(totalFRdoneMins) + '</td>' +
                            '</tr>';
                $('#tblDictatorsWorkload').append(dr_html);

                var sap_html = '<td id="tdSpace_saparator" class="tdspace" colspan="2" style="width:100%; height: 2px;background-color:#000;"></td>';
                $('#tr_saparator').append(sap_html);
                $('#tdSpace_saparator').css("display", "block");
                $('#btnDownloadWorkloadDics').css("display", "block");
            } else {
                $('#btnDownloadWorkloadDics').css("display", "none");
                $('#tdSpace_saparator').css("display", "none");
            }
        } catch (e) { alert(e.message);}
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////     Download Dictations Complete     ///////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    $('#btnDownloadWorkloadDics').click(function () {
        try {
            var dicIDs = get_complete_table_chkDics_ids(document.getElementById("tblDictatorsWorkload"));
            if (dicIDs != "" && dicIDs != null)
                PageMethods.btnDownloadAll_Click(dicIDs, onSuccessDownloadWorkloadDicsComplete);
        } catch (e) { alert("Error getting dictations list to download."); }
    });

    $('#btnDownloadWorkloadPendingDics').click(function () {
        try {
            var dicIDs = get_complete_table_chkDics_ids(document.getElementById("tblDictatorsWorkloadPending"));
            if (dicIDs != "" && dicIDs != null)
                PageMethods.btnDownloadAll_Click(dicIDs, onSuccessDownloadWorkloadDicsComplete);
        } catch (e) { alert("Error getting dictations list to download."); }
    });

    function onSuccessDownloadWorkloadDicsComplete(res) {
        try {
            if (res != "0" && res != "-1") {
                window.open('../dictationsZipPath.aspx?fileName=' + res);
            }
        } catch (e) { alert(e.message); }
    }

});

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////     Download Dictations     ////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function download_dr_dics(objRef, drID, foID) {
    try {
        var objRow = document.getElementById($(objRef).closest('tr').next('tr').attr('id'));
        var objTable = objRow.getElementsByClassName("tblDictationsLoader");

        PageMethods.btnDownloadAll_Click(get_all_chkDics_ids(objTable[0]), onSuccessDownloadAll(drID,foID));
    } catch (e) { alert(e.message); }
}

function onSuccessDownloadAll(drID,foID) {
    return function (res) {
        if (res != "0" && res != "-1") {
            window.open('../dictationsZipPath.aspx?fileName=' + res);
        }
    }
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////     workload Pending     ///////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function loadDictatorsDailyworkloadPending() {
    g_selectedDatePending = $('#ctl00_ContentPlaceHolder1_CPMain').val();
    if(g_selectedDatePending != "")
        PageMethods.loadPendingWorkload(g_selectedDatePending, onSuccess_loadDictatorsDailyworkloadPending);
}
function onSuccess_loadDictatorsDailyworkloadPending(res) {
    try {
        hide_overylay_wait();
        if (res == null) { $('#btnDownloadWorkloadPendingDics').css("display", "none"); return };
        var dr_html = "";
        dr_html = '<tr style="height:22px;"><th style="width:25px;"></th><th style="width:33px;">#</th><th style="width:33px;"></th><th style="width:85px;">Difficulty</th><th style="width:85px;">ID</th><th style="width:217px;">Name</th><th style="width:105px;">Minutes</th><th style="width:105px;">Dictations</th><th style="width:105px;border-left:1px solid #000;">MT Done</th><th style="width:105px;">QC Done</th><th style="width:105px;">PR Done</th><th style="width:105px;">FR Done</th></tr>';
        $('#tblDictatorsWorkloadPending').append(dr_html);
        var DictatorList = {};
        DictatorList = res;
        var rowCount = 1;
        var totalDictations = 0;
        var totalMinutes = 0;
        var totalMTdoneMins = 0;
        var totalQCdoneMins = 0;
        var totalPRdoneMins = 0;
        var totalFRdoneMins = 0;

        if (DictatorList.length > 0) {
            $.each(DictatorList, function (index, dr) {
                var row_color = "";
                if (index % 2 == 0)
                    row_color = "background-color:#ECECEC;";
                else
                    row_color = "background-color:#ECECEC;";

                dr_html = '<tr style="height:25px;' + row_color + '" id="trP_' + dr.drID.trim() + '">' +
                            '<td style="text-align:center;vertical-align:middle;"><img id="imgP_' + dr.drID.trim() + '" class="img_getDr" style="cursor:pointer;" src="../icon/rightArrow.png" onclick="getDictator_dictations(this,' + dr.drID.trim() + ',' + dr.foID.trim() + ',true,&quot P &quot)" /></td>' +
                            '<td style="text-align:center;vertical-align:middle;">' + rowCount + '</td>' +
                            '<td style="text-align:center;vertical-align:middle;"><input style="width:20px;" type="image" src="../Icon/download1.png" title="Download Dictations" onclick="download_dr_dics(this,' + dr.drID.trim() + ',' + dr.foID.trim() + ')"></td>' +
                            '<td style="text-align:center;vertical-align:middle;">' + dr.drDifficulty + '</td>' +
                            '<td style="text-align:center;vertical-align:middle;">' + dr.drID + '</td>' +
                            '<td style="text-align:left;vertical-align:middle;padding-left:5px;">' + dr.drLastName + ', ' + dr.drFirstName + '</td>' +
                            '<td style="text-align:center;vertical-align:middle;">' + get_mins(dr.totalMinutes) + '</td>' +
                            '<td style="text-align:center;vertical-align:middle;">' + dr.totalDictations + '</td>' +
                            '<td style="text-align:center;vertical-align:middle;border-left:1px solid #000;' + get_done_color(dr.totalMinutes, dr.MTdoneMins) + '">' + get_mins(dr.MTdoneMins) + '</td>' +
                            '<td style="text-align:center;vertical-align:middle;' + get_done_color(dr.totalMinutes, dr.QCdoneMins) + '">' + get_mins(dr.QCdoneMins) + '</td>' +
                            '<td style="text-align:center;vertical-align:middle;' + get_done_color(dr.totalMinutes, dr.PRdoneMins) + '">' + get_mins(dr.PRdoneMins) + '</td>' +
                            '<td style="text-align:center;vertical-align:middle;' + get_done_color(dr.totalMinutes, dr.FRdoneMins) + '">' + get_mins(dr.FRdoneMins) + '</td>' +
                        '</tr>';
                $('#tblDictatorsWorkloadPending').append(dr_html);
                rowCount = rowCount + 1;
                totalDictations = totalDictations + parseInt(dr.totalDictations);
                totalMinutes = parseFloat(totalMinutes) + parseFloat(dr.totalMinutes);
                totalMTdoneMins = parseFloat(totalMTdoneMins) + parseFloat(dr.MTdoneMins);
                totalQCdoneMins = parseFloat(totalQCdoneMins) + parseFloat(dr.QCdoneMins);
                totalPRdoneMins = parseFloat(totalPRdoneMins) + parseFloat(dr.PRdoneMins);
                totalFRdoneMins = parseFloat(totalFRdoneMins) + parseFloat(dr.FRdoneMins);

                onSuccess_getDictator_dictations(dr.listDications, dr.drID.trim(), 'P');
            });
            dr_html = '<tr style="font-weight:bold;">' +
                                '<td style="text-align:center;vertical-align:middle;"></td>' +
                                '<td style="text-align:center;vertical-align:middle;"></td>' +
                                '<td style="text-align:center;vertical-align:middle;"></td>' +
                                '<td style="text-align:center;vertical-align:middle;"></td>' +
                                '<td style="text-align:center;vertical-align:middle;"></td>' +
                                '<td style="text-align:left;vertical-align:middle;padding-left:5px;"></td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + get_mins(totalMinutes) + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + totalDictations + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + get_mins(totalMTdoneMins) + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + get_mins(totalQCdoneMins) + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + get_mins(totalPRdoneMins) + '</td>' +
                                '<td style="text-align:center;vertical-align:middle;">' + get_mins(totalFRdoneMins) + '</td>' +
                            '</tr>';
            $('#tblDictatorsWorkloadPending').append(dr_html);
            $('#btnDownloadWorkloadPendingDics').css("display", "block");
        } else {
            $('#btnDownloadWorkloadPendingDics').css("display", "none");
        }
    } catch (e) { alert(e.message); }
}

function get_done_color(totalMins,mins) {
    if (mins == totalMins)
        return "color:#00DB00;";
    else
        return "color:red;";
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////     Get Dictations     /////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function getDictator_dictations(objRef, drID, foID, isPending,prefix) {
    try {
        if ($('#tblDictaions_tr' + prefix.trim() + '_' + drID).hasClass("active")) {
            $('#tblDictaions_tr' + prefix.trim() + '_' + drID).css('display', 'none');
            $('#tblDictaions_tr' + prefix.trim() + '_' + drID).removeClass("active");
            $('#img' + prefix.trim() + '_' + drID).attr('src', '../icon/rightArrow.png');
            return;
        } else {
            $('#tblDictaions_tr' + prefix.trim() + '_' + drID).css('display', 'block');
            $('#tblDictaions_tr' + prefix.trim() + '_' + drID).addClass("active");
            $('#img' + prefix.trim() + '_' + drID).attr('src', '../icon/downArrow.png');
        }
    } catch (e) { alert(e.message); hide_overylay_wait();}
}

function onSuccess_getDictator_dictations(res, drID, prefix) {
    try {
        hide_overylay_wait();
        if (res == null) { alert('No Record Found.'); return };
        var dictationList = {};
        dictationList = res;
        var dr_html = "";
        dr_html = '<tr id="trDictations_tr' + prefix + '_' + drID + '" class="trDictations"><td colspan="12"><table class="tblDictationsLoader" id="tblDictaions_tr' + prefix + '_' + drID + '" style="padding-left:10px;">';
        dr_html += '<tr style="height:22px;"><th style="width:48px;">#</th><th style="width:33px;" class="dics_head_checkbox"><input type="checkbox" onclick="checkAll(this,this.checked)" id="head_' + drID + '" checked/></th><th style="width:48px;"></th><th style="width:341px;">Name</th><th style="width:415px;">Account</th><th style="width:105px;">Minutes</th><th style="width:105px;">Date</th></tr>';
        var rowCount = 1;
        if (dictationList.length > 0) {

            $.each(dictationList, function (index, dic) {
                var row_color = "";
                if (index % 2 == 0)
                    row_color = 'background-color:#DDEBF9;';
                else
                    row_color = 'background-color:#DDEBF9;';

                dr_html += '<tr style="' + row_color + '" id="dicRow_'+ dic.dicID +'">' +
                            '<td style="text-align:center;vertical-align:middle;">' + rowCount + '</td>' +
                            '<td style="text-align:center;vertical-align:middle;"><input type="checkbox" id="'+ dic.dicID +'" checked/></td>' +
                            '<td style="text-align:center;vertical-align:middle;"><a href="../data/' + dic.foID + dic.drID + '/Dictations/' + dic.dicTempName + '" target="_blank"><img height="25px" src="../icon/play.png" /></a></td>' +
                            '<td style="text-align:left;vertical-align:middle;padding-left:5px;">' + dic.dicActualName + '</td>' +
                            '<td style="text-align:center;vertical-align:middle;">' + dic.dicAccountName + '</td>' +
                            '<td style="text-align:center;vertical-align:middle;">' + get_mins(dic.dicLength) + '</td>' +
                            '<td style="text-align:center;vertical-align:middle;">' + dic.dicDate + '</td>' +
                        '</tr>';
                rowCount = rowCount + 1;
            });
            dr_html += '</table></td></tr>';
            $(dr_html).insertAfter('#tr' + prefix + '_' + drID);
            $('#tblDictaions_tr' + prefix + '_' + drID).css('display', 'none');
        }
    } catch (e) { alert(e.message); hide_overylay_wait();}

}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////     Helping Functions     //////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
                min =  arr[0] + ":" + min2;
                min = "0" + arr[0] + ":" + min2;
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


function get_all_chkDics_ids(objRefTable) {
    try {
        var chkDicsIds = "";
        var head_row_chkboxes = objRefTable.getElementsByClassName("dics_head_checkbox")[0];

        for (var i = 1; i < objRefTable.rows.length; i++) {
            var inputList = objRefTable.rows[i].cells.item(head_row_chkboxes.cellIndex).getElementsByTagName("input");

            if (inputList[0].type == "checkbox" && inputList[0].checked == true) {
                if (chkDicsIds == "") {
                    chkDicsIds = "'" + inputList[0].id + "'";
                } else {
                    chkDicsIds = chkDicsIds + ",'" + inputList[0].id + "'";
                }
            }
        }
        return chkDicsIds;
    } catch (e) {
        alert(e.message);
    }
}

function get_complete_table_chkDics_ids(objRefTable) {
    try {
        var chkDicsIds = "";

        for (var j = 1; j < objRefTable.rows.length; j++) {
            
            if (objRefTable.rows[j].className == "trDictations") {
                var objRefTable2 = objRefTable.rows[j].getElementsByClassName("tblDictationsLoader")[0];
                
                var head_row_chkboxes = objRefTable2.getElementsByClassName("dics_head_checkbox")[0];

                for (var i = 1; i < objRefTable2.rows.length; i++) {
                    var inputList = objRefTable2.rows[i].cells.item(head_row_chkboxes.cellIndex).getElementsByTagName("input");

                    if (inputList[0].type == "checkbox" && inputList[0].checked == true) {
                        if (chkDicsIds == "") {
                            chkDicsIds = "'" + inputList[0].id + "'";
                        } else {
                            chkDicsIds = chkDicsIds + ",'" + inputList[0].id + "'";
                        }
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
        var GridView = document.getElementById($(objRef).closest('table').attr('id'));
        if (objRef.type == "checkbox") {
            for (var i = 1; i < GridView.rows.length; i++) {
                var chkbox = GridView.rows[i].cells.item(objRef.parentNode.cellIndex).getElementsByTagName("input")[0];
                if (!chkbox.disabled) {
                    chkbox.checked = is_check;
                }
            }
        }
    } catch (e) {
        alert(e.message);
    }
}


var MainOver = '<div id="overlay" class="overlay" style="height:100%; width:100%;">' +
                    '<div><img id="loading" src="../Icon/ajax-loader.gif"><div>' +
                    '</div>';

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
            'top': 0,
        });
    } catch (e) {
        alert(e.message);
        $("#overlay").remove();
    }
}

function hide_overylay_wait() {
    $("#overlay").remove();
}
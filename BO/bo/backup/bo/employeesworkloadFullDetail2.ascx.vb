Imports MTBMS.DAL
Imports System.Data

Partial Class BO_employeesworkloadFullDetail2
    Inherits System.Web.UI.UserControl
    Protected iCounter As Int16
    Private _frcolor As String

    Private Property frcolor As String
        Get
            Return _frcolor
        End Get
        Set(value As String)
            _frcolor = value
        End Set
    End Property

    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        Dim dgi As DataGridItem = CType(Me.BindingContainer, DataGridItem)
        If (Not (TypeOf dgi.DataItem Is Data.DataSet)) Then
            Throw New ArgumentException("Please change the TemplateDataMode attribute to 'Table' in the HierarGrid declaration")
        End If
        Dim ds As Data.DataSet = CType(dgi.DataItem, Data.DataSet)
        If ds.Tables("workloaddictator").Rows.Count > 0 Then
            Me.gvDictator2.DataSource = ds
            Me.gvDictator2.DataMember = "workloaddictator"
            Me.gvDictator2.DataBind()
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        iCounter = 0
    End Sub

    Protected Sub gvDictator2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDictator2.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            iCounter = 0
        Else
            iCounter += 1
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.BackColor = Drawing.Color.LightCyan
        End If
    End Sub
    Protected Function get_mt_qc_pr_fr(ByVal drId As String, ByVal empID As String) As String
        Try
            Dim MTnames As String = ""
            Dim mtcolor As String = "#808080"
            Dim QCname As String = ""
            Dim qccolor As String = "#808080"
            Dim PRname As String = ""
            Dim prcolor As String = "#808080"
            Dim mt_qc_pr_div As String = ""
            Dim qcdiv As String = "<div style='float:left;width:65px;  vertical-align:top; text-align:left;'>"
            Dim mtdiv As String = "<div style='float:left;width:65px; padding: 0 0 0 8px; vertical-align:top; text-align:left;'>"
            Dim prdiv As String = "<div style='float:left;width:65px; padding: 0 0 0 8px; vertical-align:top; text-align:left;'>"
            Dim Con As New DBTaskBO
            Dim ds As DataSet
            Dim getemployeedetails As String = "select distinct(boE.empID),(boE.empFirstName +' '+ SUBSTRING(boE.empLastName, 1, 1)) as empName,bDL.rolID,bDL.diclStatus " _
                                & "from boDictation bD " _
                                & "inner join boDictationLayers bDL on bDL.dicID = bD.dicID " _
                                & "inner join boEmployee boE on boE.empID = bDL.empID " _
                                & "where bD.dicID IN (select bD.dicID from boDictation bD " _
                                & "inner join boDictationLayers bDL on bDL.dicID = bD.dicID " _
                                & "where bDL.diclWorkloadDate BETWEEN '" & Format(CType(Session("CPDateFrom").ToString(), Date), "MM/dd/yyyy") & "' AND '" & Format(CType(Session("CPDateTo").ToString(), Date), "MM/dd/yyyy") & "' and drID = '" & drId & "' and bdL.empID = '" & empID & "') and boE.empID != '0' "

            ds = Con.getDataSet(getemployeedetails)
            For Each dr As DataRow In ds.Tables(0).Rows
                Select Case dr("rolID").ToString().Trim()
                    Case "MT"

                        If dr("diclStatus") > 0 Then
                            Select Case dr("diclStatus")
                                Case 0
                                    mtcolor = "color:#808080"
                                Case 1
                                    mtcolor = "color:#F4BA00"
                                Case 2
                                    mtcolor = "color:#7627FC"
                                Case 2
                                    mtcolor = "color:#00804F"
                                Case Else
                                    mtcolor = "color:#F64244"
                            End Select

                        End If
                        If MTnames = "" Then
                            MTnames = "<span style='text-align:right;font-weight:bold;'> " & dr("rolID") & "</span>"
                            MTnames += "</br> <span style=" & mtcolor & "> " & dr("empName") & "   </span>"
                        Else
                            MTnames += "</br> <span style=" & mtcolor & "> " & dr("empName") & " </span>"
                        End If

                    Case "QC"

                        If dr("diclStatus") > 0 Then
                            Select Case dr("diclStatus")
                                Case 0
                                    qccolor = "color:#808080"
                                Case 1
                                    qccolor = "color:#F4BA00"
                                Case 2
                                    qccolor = "color:#7627FC"
                                Case 2
                                    qccolor = "color:#00804F"
                                Case Else
                                    qccolor = "color:#F64244"
                            End Select

                        End If
                        If QCname = "" Then
                            QCname = "<span style='text-align:right;font-weight:bold;'> " & dr("rolID") & "</span>"
                            QCname += "</br> <span style=" & qccolor & "> " & dr("empName") & "   </span>"
                        Else
                            QCname += "</br> <span style=" & qccolor & "> " & dr("empName") & " </span>"
                        End If

                    Case "PR"

                        If dr("diclStatus") > 0 Then
                            Select Case dr("diclStatus")
                                Case 0
                                    prcolor = "color:#808080"
                                Case 1
                                    prcolor = "color:#F4BA00"
                                Case 2
                                    prcolor = "color:#7627FC"
                                Case 2
                                    prcolor = "color:#00804F"
                                Case Else
                                    prcolor = "color:#F64244"
                            End Select

                        End If
                        If PRname = "" Then
                            PRname = "<span style='text-align:right;font-weight:bold;'> " & dr("rolID") & "</span>"
                            PRname += "</br> <span style=" & prcolor & "> " & dr("empName") & "   </span>"
                        Else
                            PRname += "</br> <span style=" & prcolor & "> " & dr("empName") & " </span>"
                        End If


                    Case "FR"

                        Select Case dr("diclStatus")
                            Case 0
                                frcolor = "color:#808080"
                            Case 1
                                frcolor = "color:#F4BA00"
                            Case 2
                                frcolor = "color:#7627FC"
                            Case 2
                                frcolor = "color:#00804F"
                            Case Else
                                frcolor = "color:#F64244"
                        End Select

                End Select
            Next
            mtdiv += MTnames & "</div>"
            qcdiv += QCname & "</div>"
            prdiv += PRname & "</div>"
            If MTnames.Length > 0 Or QCname.Length > 0 Or PRname.Length > 0 Then
                mt_qc_pr_div = "<div style='float:right;width:240px; vertical-align:top; text-align:left;'>"
                mt_qc_pr_div += mtdiv
                mt_qc_pr_div += qcdiv
                mt_qc_pr_div += prdiv & "</div>"
            Else
                mt_qc_pr_div = "<div style='float:right;width:240px; vertical-align:top; text-align:left;'>"
                mt_qc_pr_div += mtdiv
                mt_qc_pr_div += qcdiv
                mt_qc_pr_div += prdiv & "</div>"
            End If
            
            Return mt_qc_pr_div
            ds.Dispose()
            ds = Nothing

            Con.objConnection.Close()
            Con = Nothing
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    'Protected Function get_name(drID As String, ByVal roleID As String) As String
    '    Try

    '        Dim datatype As String = ""
    '        Dim MTnames As String = ""
    '        If Session("ddlDataType") = "Dictation Date" Then
    '            datatype = "AND bD.boDictation"
    '        Else
    '            datatype = "AND bDL.diclWorkloadDate"
    '        End If
    '        Dim dbo As New DBTaskBO
    '        Dim dt As New DataSet
    '        Dim query As String
    '        query = "select distinct(bE.empID) as empID, (bE.empFirstName +' '+ bE.empLastName) as empName, " _
    '             & "IsNull(COUNT(case(bDL.diclStatus) when 0 then 1 when 1 then 1 when 2 then 1 else null end), 0) as doneDictations " _
    '             & "from boDictationLayers bDL " _
    '             & "inner join boDictation bD on bD.dicID = bDL.dicID " _
    '             & "inner join boEmployee bE on bE.empID = bDL.empID " _
    '             & "where bD.drID = '" & drID & "' " & datatype & " BETWEEN '" & Format(CType(Session("CPDateFrom").ToString(), Date), "MM/dd/yyyy") & "' AND '" & Format(CType(Session("CPDateTo").ToString(), Date), "MM/dd/yyyy") & "' and rolID = '" & roleID & "' " _
    '             & "group by bE.empID, bE.empFirstName, bE.empLastName"
    '        dt = dbo.getDataSet(query)
    '        Dim nameClause As String = ""
    '        nameClause = "<div style='float:right;width:120px; vertical-align:top; text-align:left;'>"
    '        For Each dtr As DataRow In dt.Tables(0).Rows

    '            If dtr("doneDictations") > 0 Then
    '                If MTnames = "" Then
    '                    MTnames = "<span style='color:Red' > " & dtr("empName") & "   </span>"
    '                Else
    '                    MTnames += "</br> <span style='color:Red'> " & dtr("empName") & " </span>"
    '                End If
    '            Else
    '                If MTnames = "" Then
    '                    MTnames = "<span style='color:Green' > " & dtr("empName") & "   </span>"
    '                Else
    '                    MTnames += "</br> <span style='color:Green'> " & dtr("empName") & " </span>"
    '                End If
    '            End If
    '        Next
    '        nameClause += MTnames & "</div>"
    '        Return nameClause
    '    Catch ex As Exception
    '        Return ex.Message
    '    End Try
    'End Function
End Class

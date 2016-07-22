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
    Protected Function get_mt_qc_pr_fr(ByVal drId As String, ByVal empID As String, ByVal rolID As String) As String
        Try
            Dim MTnames As String = ""
            Dim mtcolor As String = "color:#808080"
            Dim QCname As String = ""
            Dim qccolor As String = "color:#808080"
            Dim PRname As String = ""
            Dim prcolor As String = "color:#808080"
            Dim mt_qc_pr_div As String = ""

            Dim qcdiv As String = "<div style='float:left;width:85px;  vertical-align:top; text-align:left;'>"
            Dim mtdiv As String = "<div style='float:left;width:85px; padding: 0 0 0 8px; vertical-align:top; text-align:left;'>"
            Dim prdiv As String = "<div style='float:left;width:85px; padding: 0 0 0 7px; vertical-align:top; text-align:left;'>"
            Dim Con As New DBTaskBO
            Dim ds As DataSet
            '        Dim getemployeedetails As String = "Select bDL.rolID,bDL.empID,(bE.empFirstName +' '+ SUBSTRING(bE.empLastName, 1, 1)) as empName,COUNT(bD.dicID) AS TotalDics,IsNull(COUNT(case(bDL.diclStatus) when 1 then 1 else null end), 0) as yellow,IsNull(COUNT(case(bDL.diclStatus) when 2 then 1 else null end), 0) as blue,IsNull(COUNT(case(bDL.diclStatus) when 3 then 1 else null end), 0) as Green " _
            '                                            & "from boDictation bD " _
            '                                            & "inner join boDictationLayers bDL on bDL.dicID = bD.dicID " _
            '                                            & "inner join boEmployee bE on bE.empID = bDL.empID " _
            '                                            & "where bDL.diclWorkloadDate BETWEEN '" & Format(CType(Session("CPDateFrom").ToString(), Date), "MM/dd/yyyy") & "' AND '" & Format(CType(Session("CPDateTo").ToString(), Date), "MM/dd/yyyy") & "'   and drID = '" & drId & "' and bdL.empID = '" & empID & "' Group by bDL.empID,bE.empFirstName,bE.empLastName,bDL.rolID  "
            Dim getemployeedetails As String = "Select bDL.rolID,bDL.empID,(bE.empFirstName +' '+ SUBSTRING(bE.empLastName, 1, 1)) as empName,COUNT(bDL.dicID) AS TotalDics,IsNull(COUNT(case(bDL.diclStatus) when 1 then 1 else null end), 0) as yellow,IsNull(COUNT(case(bDL.diclStatus) when 2 then 1 else null end), 0) as blue,IsNull(COUNT(case(bDL.diclStatus) when 3 then 1 else null end), 0) as Green " _
                                                        & "from boDictationLayers bDL " _
                                                        & "inner join boEmployee bE on bE.empID = bDL.empID " _
                                                        & "where bDL.dicID in ( select bD.dicID from boDictation bD " _
                                                        & "inner join boDictationLayers bDL on bDL.dicID = bD.dicID where bDL.diclWorkloadDate BETWEEN '" & Format(CType(Session("CPDateFrom").ToString(), Date), "MM/dd/yyyy") & "' AND '" & Format(CType(Session("CPDateTo").ToString(), Date), "MM/dd/yyyy") & "'   and drID = '" & drId & "' and bdL.empID = '" & empID & "' ) Group by bDL.empID,bE.empFirstName,bE.empLastName,bDL.rolID  "



            ds = Con.getDataSet(getemployeedetails)
            For Each dr As DataRow In ds.Tables(0).Rows

                Select Case dr("rolID").ToString().Trim()

                    Case "MT"

                        If dr("yellow") > 0 Then
                            mtcolor = "color:#F4BA00"

                        End If
                        If dr("blue") > 0 Then
                            mtcolor = "color:#7627FC"
                        End If
                        If dr("green") > 0 And dr("green") = dr("TotalDics") Then
                            mtcolor = "color:#00804F"
                        End If
                        If MTnames = "" Then
                            MTnames = "<span style='text-align:right;font-weight:bold;'> " & dr("rolID") & "</span></hr>"
                            MTnames += "</br> <span style=" & mtcolor & "> " & dr("empName") & "   </span>"
                        Else
                            MTnames += "</br> <span style=" & mtcolor & "> " & dr("empName") & " </span>"
                        End If


                    Case "QC"

                        If dr("yellow") > 0 Then
                            qccolor = "color:#F4BA00"

                        End If
                        If dr("blue") > 0 Then
                            qccolor = "color:#7627FC"
                        End If
                        If dr("green") > 0 And dr("green") = dr("TotalDics") Then
                            qccolor = "color:#00804F"
                        End If

                        If QCname = "" Then
                            QCname = "<span style='text-align:right;font-weight:bold;'> " & dr("rolID") & "</span></hr>"
                            QCname += "</br> <span style=" & qccolor & "> " & dr("empName") & "   </span>"
                        Else
                            QCname += "</br> <span style=" & qccolor & "> " & dr("empName") & " </span>"
                        End If



                    Case "PR"

                        If dr("yellow") > 0 Then
                            prcolor = "color:#F4BA00"

                        End If
                        If dr("blue") > 0 Then
                            prcolor = "color:#7627FC"
                        End If
                        If dr("green") > 0 And dr("green") = dr("TotalDics") Then
                            prcolor = "color:#00804F"
                        End If

                        If PRname = "" Then
                            PRname = "<span style='text-align:right;font-weight:bold;'> " & dr("rolID") & "</span></hr>"
                            PRname += "</br> <span style=" & prcolor & "> " & dr("empName") & "   </span>"
                        Else
                            PRname += "</br> <span style=" & prcolor & "> " & dr("empName") & " </span>"
                        End If




                    Case "FR"



                End Select

            Next
            mtdiv += MTnames & "</div>"
            qcdiv += QCname & "</div>"
            prdiv += PRname & "</div>"
            If MTnames.Length > 0 Or QCname.Length > 0 Or PRname.Length > 0 Then
                mt_qc_pr_div = "<div style='float:right;width:270px; vertical-align:top; text-align:left;'>"
                mt_qc_pr_div += mtdiv
                mt_qc_pr_div += qcdiv
                mt_qc_pr_div += prdiv & "</div>"
            Else
                mt_qc_pr_div = "<div style='float:right;width:270px; vertical-align:top; text-align:left;'>"
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
    'Protected Function get_mt_qc_pr_fr(ByVal drId As String, ByVal empID As String, ByVal rolID As String) As String
    '    Try
    '        Dim MTnames As String = ""
    '        Dim mtcolor As String = ""
    '        Dim QCname As String = ""
    '        Dim qccolor As String = ""
    '        Dim PRname As String = ""
    '        Dim prcolor As String = ""
    '        Dim mt_qc_pr_div As String = ""

    '        Dim qcdiv As String = "<div style='float:left;width:85px;  vertical-align:top; text-align:left;'>"
    '        Dim mtdiv As String = "<div style='float:left;width:85px; padding: 0 0 0 8px; vertical-align:top; text-align:left;'>"
    '        Dim prdiv As String = "<div style='float:left;width:85px; padding: 0 0 0 7px; vertical-align:top; text-align:left;'>"
    '        Dim Con As New DBTaskBO
    '        Dim ds As DataSet
    '        Dim getemployeedetails As String = "select distinct(boE.empID),(boE.empFirstName +' '+ SUBSTRING(boE.empLastName, 1, 1)) as empName,bDL.rolID,bDL.diclStatus " _
    '                            & "from boDictationLayers bDL " _
    '                            & "inner join boEmployee boE on boE.empID = bDL.empID " _
    '                            & "where bDL.dicID IN (select bD.dicID from boDictation bD " _
    '                            & "inner join boDictationLayers bDL on bDL.dicID = bD.dicID " _
    '                            & "where bDL.diclWorkloadDate BETWEEN '" & Format(CType(Session("CPDateFrom").ToString(), Date), "MM/dd/yyyy") & "' AND '" & Format(CType(Session("CPDateTo").ToString(), Date), "MM/dd/yyyy") & "' and bDL.rolID='" & rolID & "'  and drID = '" & drId & "' and bdL.empID = '" & empID & "') and boE.empID != '0' "

    '        ds = Con.getDataSet(getemployeedetails)
    '        For Each dr As DataRow In ds.Tables(0).Rows

    '            Select Case dr("rolID").ToString().Trim()

    '                Case "MT"


    '                    Select Case dr("diclStatus")
    '                        Case 0
    '                            mtcolor = "color:#808080"
    '                        Case 1
    '                            mtcolor = "color:#F4BA00"
    '                        Case 2
    '                            mtcolor = "color:#7627FC"
    '                        Case 3
    '                            mtcolor = "color:#00804F"
    '                        Case Else
    '                            mtcolor = "color:#F64244"
    '                    End Select
    '                    If MTnames = "" Then
    '                        MTnames = "<span style='text-align:right;font-weight:bold;'> " & dr("rolID") & "</span></hr>"
    '                        MTnames += "</br> <span style=" & mtcolor & "> " & dr("empName") & "   </span>"
    '                    Else
    '                        MTnames += "</br> <span style=" & mtcolor & "> " & dr("empName") & " </span>"
    '                    End If



    '                Case "QC"

    '                    Select Case dr("diclStatus")
    '                        Case 0
    '                            qccolor = "color:#808080"
    '                        Case 1
    '                            qccolor = "color:#F4BA00"
    '                        Case 2
    '                            qccolor = "color:#7627FC"
    '                        Case 3
    '                            qccolor = "color:#00804F"
    '                        Case Else
    '                            qccolor = "color:#F64244"
    '                    End Select

    '                    If QCname = "" Then
    '                        QCname = "<span style='text-align:right;font-weight:bold;'> " & dr("rolID") & "</span></hr>"
    '                        QCname += "</br> <span style=" & qccolor & "> " & dr("empName") & "   </span>"
    '                    Else
    '                        QCname += "</br> <span style=" & qccolor & "> " & dr("empName") & " </span>"
    '                    End If



    '                Case "PR"


    '                    Select Case dr("diclStatus")
    '                        Case 0
    '                            prcolor = "color:#808080"
    '                        Case 1
    '                            prcolor = "color:#F4BA00"
    '                        Case 2
    '                            prcolor = "color:#7627FC"
    '                        Case 3
    '                            prcolor = "color:#00804F"
    '                        Case Else
    '                            prcolor = "color:#F64244"
    '                    End Select

    '                    If PRname = "" Then
    '                        PRname = "<span style='text-align:right;font-weight:bold;'> " & dr("rolID") & "</span></hr>"
    '                        PRname += "</br> <span style=" & prcolor & "> " & dr("empName") & "   </span>"
    '                    Else
    '                        PRname += "</br> <span style=" & prcolor & "> " & dr("empName") & " </span>"
    '                    End If




    '                Case "FR"

    '                    Select Case dr("diclStatus")
    '                        Case 0
    '                            frcolor = "color:#808080"
    '                        Case 1
    '                            frcolor = "color:#F4BA00"
    '                        Case 2
    '                            frcolor = "color:#7627FC"
    '                        Case 3
    '                            frcolor = "color:#00804F"
    '                        Case Else
    '                            frcolor = "color:#F64244"
    '                    End Select



    '            End Select

    '        Next
    '        mtdiv += MTnames & "</div>"
    '        qcdiv += QCname & "</div>"
    '        prdiv += PRname & "</div>"
    '        If MTnames.Length > 0 Or QCname.Length > 0 Or PRname.Length > 0 Then
    '            mt_qc_pr_div = "<div style='float:right;width:270px; vertical-align:top; text-align:left;'>"
    '            mt_qc_pr_div += mtdiv
    '            mt_qc_pr_div += qcdiv
    '            mt_qc_pr_div += prdiv & "</div>"
    '        Else
    '            mt_qc_pr_div = "<div style='float:right;width:270px; vertical-align:top; text-align:left;'>"
    '            mt_qc_pr_div += mtdiv
    '            mt_qc_pr_div += qcdiv
    '            mt_qc_pr_div += prdiv & "</div>"
    '        End If

    '        Return mt_qc_pr_div
    '        ds.Dispose()
    '        ds = Nothing

    '        Con.objConnection.Close()
    '        Con = Nothing
    '    Catch ex As Exception
    '        Return ex.Message
    '    End Try
    'End Function

End Class

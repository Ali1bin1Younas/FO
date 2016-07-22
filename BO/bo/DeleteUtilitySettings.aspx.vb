
Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Imports System.IO
Imports System.Web.Services

Partial Class DeleteUtilitySettings
    Inherits System.Web.UI.Page
    Protected iCounter As Int16

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        iCounter = 0
        Try
            If Not Page.IsPostBack Then
                ' LoadGrid()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadGrid()
        Try

            Dim Con As New DBTaskBO
            Dim Query As String = "Select * From boCompany ORDER BY comID"
            Dim ds As DataSet
            ds = Con.getDataSet(Query)
            'grdEmployee.DataSource = ds
            'grdEmployee.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Protected Function getEnableDisable(ByVal ED As String) As String

        If ED.ToString = "True" Then
            Return "../Icon/Ngood.gif".Trim
        Else
            Return "../Icon/cancel.gif".Trim
        End If

    End Function

    'Protected Sub grdEmployee_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEmployee.RowCreated
    '    If e.Row.RowIndex > 0 Then iCounter += 1
    'End Sub


    Protected Sub showsubfolder(sender As Object, e As EventArgs)


    End Sub

    Public Sub SaveDailyTimer(sender As Object, e As System.EventArgs)

        If txtdailytimer.Text.ToString() <> "" Then
            Dim query As String = ""
            Try

                Dim ad As New DBTaskBO
                If h_schID_timer1.Value <> "" Then
                    query = "insert into schedulerfolders(schtype,schtime,fid) values ('1','" & txtdailytimer.Text.Trim & "','" & hchkboxid.Value & "')"
                Else
                    query = "update schedulerfolders set schtype='1', schtime='" & txtdailytimer.Text.Trim & "',fid='" & hchkboxid.Value & "' where scheduleid=" & h_schID_timer1.Value
                End If
                ad.saveData(query)

            Catch ex As Exception

            End Try

        End If
    End Sub

    Public Sub SaveweeklyTimer(sender As Object, e As System.EventArgs)

        If Textbox2.Text.ToString() <> "" AndAlso Not ddlweekly.SelectedValue Is Nothing Then
            Try

                Dim ad As New DBTaskBO
                Dim query As String = "insert into schedulerfolders(schtype,schday,schdate,schtime,fid) values ('2','" & ddlweekly.SelectedValue & "','" & Now.ToString() & "','" & Textbox2.Text.Trim & "','" & hchkboxid.Value & "')"
                ad.saveData(query)

            Catch ex As Exception


            End Try

        End If
    End Sub

    Public Sub SavefornightTimer(sender As Object, e As System.EventArgs)

        If TextBox7.Text <> "" AndAlso Not ddlfortnight.SelectedValue Is Nothing Then
            Try

                Dim ad As New DBTaskBO



                Dim query As String = "insert into schedulerfolders(schtype,schday,schdate,schtime,fid) values ('3','" & ddlfortnight.SelectedValue & "','" & Now.ToString() & "','" & TextBox7.Text.Trim & "','" & hchkboxid.Value & "')"



                ad.saveData(query)

            Catch ex As Exception


            End Try

        End If
    End Sub

    Public Sub SaveMonthlyTimer(sender As Object, e As System.EventArgs)

        If TxtBox8.Text <> "" AndAlso TextBox9.Text <> "" Then
            Try
                Dim ad As New DBTaskBO
                Dim query As String = "insert into schedulerfolders(schtype,schday,schdate,schtime,fid) values ('4',null,'" & TextBox9.Text.Trim & "','" & TxtBox8.Text.Trim & "','" & hchkboxid.Value & "')"
                ad.saveData(query)

            Catch ex As Exception

            End Try

        End If
    End Sub

    <WebMethod> _
    Public Shared Function get_schedule(ByVal fID As String, ByVal schType As Integer) As String()
        Dim vals(7) As String
        Try
            Dim objDB As New DBTaskBO
            Dim dsVals As DataSet
            Dim qry As String = "select scheduleid, schtype, isNull(schday, '') schday, isNull(schdate, '1/1/1999') schdate, isNull(schtime,'0') schtime, fid from schedulerfolders where schType='" & schType & "' and fid='" & fID & "'"
            dsVals = objDB.getDataSet(qry)
            If dsVals.Tables(0).Rows.Count > 0 Then
                For Each dr As DataRow In dsVals.Tables(0).Rows
                    vals(0) = "1"
                    vals(1) = dr("scheduleid").ToString()
                    vals(2) = dr("schtype").ToString()
                    vals(3) = dr("schday").ToString()
                    vals(4) = dr("schdate").ToString()
                    vals(5) = dr("schtime").ToString()
                    vals(6) = dr("fid").ToString()
                Next
            Else
                vals(0) = "0"
                vals(1) = "No Schedule found"
                vals(2) = schType
            End If
            
            Return vals
        Catch ex As Exception
            vals(0) = "-1"
            vals(1) = ex.Message.ToString()
            vals(2) = schType
            Return vals
        End Try

    End Function

End Class

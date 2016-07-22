Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class rightassign
    Inherits System.Web.UI.Page
    Dim eempID As String
    Dim empFullName As String
    Private Sub deleteRecord()
        Try
            Dim Con As New DBTaskBO
            Con.saveData("delete from boEmployeeRoles Where empID='" & eempID & "'")
        Catch ex As Exception
        End Try

    End Sub
    Private Sub showRightsChecks()
        Dim Con As New DBTaskBO
        'Dim dr As SqlDataReader
        'dr = Con.getDataReader("Select * From boEmployeeRoles WHERE empID='" & eempID & "'")
        Dim ds As DataSet
        ds = Con.getDataSet("Select * From boEmployeeRoles WHERE empID='" & eempID & "'")
        Me.AD.Checked = False
        Me.PR.Checked = False
        Me.FR.Checked = False
        Me.MT.Checked = False
        'While dr.Read
        '    Dim rID As String = dr("rolID")
        '    Select Case rID
        '        Case "AD"
        '            Me.AD.Checked = True
        '        Case "PR"
        '            Me.PR.Checked = True
        '        Case "FR"
        '            Me.FR.Checked = True
        '        Case "MT"
        '            Me.MT.Checked = True
        '            Exit Select
        '    End Select
        'End While

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim rID As String = dr("rolID")
            Select Case rID
                Case "AD"
                    Me.AD.Checked = True
                Case "PR"
                    Me.PR.Checked = True
                Case "FR"
                    Me.FR.Checked = True
                Case "MT"
                    Me.MT.Checked = True
                    Exit Select
            End Select
        Next
        ds.dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing
    End Sub
    Private Sub saveRecord()
        Dim Con As New DBTaskBO
        If AD.Checked = True Then
            Con.saveData("insert into boEmployeeRoles values('" & eempID & "' ,'AD',1)")
        End If
        If FR.Checked = True Then
            Con.saveData("insert into boEmployeeRoles values('" & eempID & "','FR',1)")
        End If
        If PR.Checked = True Then
            Con.saveData("insert into boEmployeeRoles values('" & eempID & "','PR',1)")
        End If
        If MT.Checked = True Then
            Con.saveData("insert into boEmployeeRoles values('" & eempID & "','MT',1)")
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        eempID = Request.QueryString("empID")
        lblEmployeeID.Text = eempID.ToString
        lblEmployeeName.Text = getEmployeeName(eempID)

        If Not Page.IsPostBack Then
            showRightsChecks()
            showRightsLinks()
        End If
    End Sub

    Private Function getEmployeeName(ByVal strName As String) As String
        Dim Con As New DBTaskBO
        'Dim dr As SqlDataReader
        'dr = Con.getDataReader("Select * From boEmployee WHERE empID='" & strName & "'")
        Dim ds As DataSet
        ds = Con.getDataSet("Select * From boEmployee WHERE empID='" & strName & "'")
        'If dr.Read Then
        '    empFullName = dr("empLastName") + ", " + dr("empFirstName")
        'End If
        If ds.tables(0).rows.count > 0 Then
            empFullName = ds.tables(0).rows(0).item("empLastName") + ", " + ds.tables(0).rows(0).item("empFirstName")
        End If
        ds.dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing
        Return empFullName
    End Function
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        deleteRecord()
        saveRecord()
        Response.Redirect("employeemain.aspx")
    End Sub
    Private Sub showRightsLinks()
        Dim Con As New DBTaskBO
        'Dim dr As SqlDataReader
        'dr = Con.getDataReader("Select * From boEmployeeRoles WHERE empID='" & eempID & "'")
        Dim ds As DataSet
        ds = Con.getDataSet("Select * From boEmployeeRoles WHERE empID='" & eempID & "'")
        Me.lnkAD.Visible = False
        Me.lnkPR.Visible = False
        Me.lnkFR.Visible = False
        Me.lnkMT.Visible = False
        'While dr.Read
        '    Dim a1 As String = dr("rolID")
        '    Dim a2 As Boolean = dr("empEnable")
        '    Select Case a1
        '        Case "PR"
        '            If a2 = True Then
        '                Me.lnkPR.Text = "Enable"
        '                Me.lnkPR.Visible = True
        '            Else
        '                Me.lnkPR.Text = "Disable"
        '                Me.lnkPR.Visible = True
        '            End If
        '        Case "AD"
        '            If a2 = True Then
        '                Me.lnkAD.Text = "Enable"
        '                Me.lnkAD.Visible = True
        '            Else
        '                Me.lnkAD.Text = "Disable"
        '                Me.lnkAD.Visible = True
        '            End If

        '        Case "FR"
        '            If a2 = True Then
        '                Me.lnkFR.Text = "Enable"
        '                Me.lnkFR.Visible = True
        '            Else
        '                Me.lnkFR.Text = "Disable"
        '                Me.lnkFR.Visible = True
        '            End If
        '        Case "MT"
        '            If a2 = True Then
        '                Me.lnkMT.Text = "Enable"
        '                Me.lnkMT.Visible = True
        '            Else
        '                Me.lnkMT.Text = "Disable"
        '                Me.lnkMT.Visible = True
        '            End If
        '    End Select
        'End While

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim a1 As String = dr("rolID")
            Dim a2 As Boolean = dr("empEnable")
            Select Case a1
                Case "PR"
                    If a2 = True Then
                        Me.lnkPR.Text = "Enable"
                        Me.lnkPR.Visible = True
                    Else
                        Me.lnkPR.Text = "Disable"
                        Me.lnkPR.Visible = True
                    End If
                Case "AD"
                    If a2 = True Then
                        Me.lnkAD.Text = "Enable"
                        Me.lnkAD.Visible = True
                    Else
                        Me.lnkAD.Text = "Disable"
                        Me.lnkAD.Visible = True
                    End If

                Case "FR"
                    If a2 = True Then
                        Me.lnkFR.Text = "Enable"
                        Me.lnkFR.Visible = True
                    Else
                        Me.lnkFR.Text = "Disable"
                        Me.lnkFR.Visible = True
                    End If
                Case "MT"
                    If a2 = True Then
                        Me.lnkMT.Text = "Enable"
                        Me.lnkMT.Visible = True
                    Else
                        Me.lnkMT.Text = "Disable"
                        Me.lnkMT.Visible = True
                    End If
            End Select
        Next
        ds.dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing

    End Sub
    Protected Sub lnkFR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFR.Click
        Dim Con As New DBTaskBO
        'Dim dr As SqlDataReader
        'dr = Con.getDataReader("Select * From boEmployeeRoles WHERE empID='" & eempID & "'")

        Dim ds As DataSet
        ds = Con.getDataSet("Select * From boEmployeeRoles WHERE empID='" & eempID & "'")
        Dim Query As String
        'While dr.Read
        '    Dim a1 As String = dr("rolID")
        '    Dim a2 As Boolean = dr("empEnable")
        '    If a1 = "FR" And a2 = True Then
        '        Query = "Update boEmployeeRoles set empEnable='0' where empID='" & eempID & "' and rolID='" & a1 & "'"
        '        Con.deleteDataValues(Query)
        '        Me.lnkFR.Text = "Enable"
        '    ElseIf a1 = "FR" And a2 = False Then
        '        Query = "Update boEmployeeRoles set empEnable='1' where empID='" & eempID & "' and rolID='" & a1 & "'"
        '        Con.deleteDataValues(Query)
        '        Me.lnkFR.Text = "Disable"
        '    End If
        'End While

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim a1 As String = dr("rolID")
            Dim a2 As Boolean = dr("empEnable")
            If a1 = "FR" And a2 = True Then
                Query = "Update boEmployeeRoles set empEnable='0' where empID='" & eempID & "' and rolID='" & a1 & "'"
                Con.deleteDataValues(Query)
                Me.lnkFR.Text = "Enable"
            ElseIf a1 = "FR" And a2 = False Then
                Query = "Update boEmployeeRoles set empEnable='1' where empID='" & eempID & "' and rolID='" & a1 & "'"
                Con.deleteDataValues(Query)
                Me.lnkFR.Text = "Disable"
            End If
        Next
        ds.dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing

        Response.Redirect("rightassign.aspx?empID=" & eempID & "")
    End Sub
    Protected Sub lnkAD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAD.Click
        Dim Con As New DBTaskBO
        'Dim dr As SqlDataReader
        'dr = Con.getDataReader("Select * From boEmployeeRoles WHERE empID='" & eempID & "'")
        Dim Query As String
        Dim ds As DataSet
        ds = Con.getDataSet("Select * From boEmployeeRoles WHERE empID='" & eempID & "'")
        'While dr.Read
        '    Dim a1 As String = dr("rolID")
        '    Dim a2 As Boolean = dr("empEnable")

        '    If a1 = "AD" And a2 = True Then
        '        Query = "Update boEmployeeRoles set empEnable='0' where empID='" & eempID & "' and  rolID='" & a1 & "'"
        '        Con.deleteDataValues(Query)
        '        Me.lnkAD.Text = "Enable"
        '    ElseIf a1 = "AD" And a2 = False Then

        '        Query = "Update boEmployeeRoles set empEnable='1' where empID='" & eempID & "' and rolID='" & a1 & "'"
        '        Con.deleteDataValues(Query)
        '        Me.lnkAD.Text = "Disable"
        '    End If
        'End While


        For Each dr As DataRow In ds.Tables(0).Rows
            Dim a1 As String = dr("rolID")
            Dim a2 As Boolean = dr("empEnable")

            If a1 = "AD" And a2 = True Then
                Query = "Update boEmployeeRoles set empEnable='0' where empID='" & eempID & "' and  rolID='" & a1 & "'"
                Con.deleteDataValues(Query)
                Me.lnkAD.Text = "Enable"
            ElseIf a1 = "AD" And a2 = False Then

                Query = "Update boEmployeeRoles set empEnable='1' where empID='" & eempID & "' and rolID='" & a1 & "'"
                Con.deleteDataValues(Query)
                Me.lnkAD.Text = "Disable"
            End If
        Next
        ds.dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing

        Response.Redirect("rightassign.aspx?empID=" & eempID & "")
    End Sub
    Protected Sub lnkPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPR.Click
        Dim Con As New DBTaskBO
        'Dim dr As SqlDataReader
        'dr = Con.getDataReader("Select * From boEmployeeRoles WHERE empID='" & eempID & "'")
        Dim Query As String
        'While dr.Read
        '    Dim a1 As String = dr("rolID")
        '    Dim a2 As Boolean = dr("empEnable")
        '    If a1 = "PR" And a2 = True Then
        '        Query = "Update boEmployeeRoles set empEnable='0' where empID='" & eempID & "' and rolID='" & a1 & "' "
        '        Con.deleteDataValues(Query)
        '        Me.lnkPR.Text = "Enable"
        '    ElseIf a1 = "PR" And a2 = False Then
        '        Query = "Update boEmployeeRoles set empEnable='1' where empID='" & eempID & "' and rolID='" & a1 & "' "
        '        Con.deleteDataValues(Query)
        '        Me.lnkPR.Text = "Disable"
        '    End If
        'End While

        Dim ds As DataSet
        ds = Con.getDataSet("Select * From boEmployeeRoles WHERE empID='" & eempID & "'")
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim a1 As String = dr("rolID")
            Dim a2 As Boolean = dr("empEnable")
            If a1 = "PR" And a2 = True Then
                Query = "Update boEmployeeRoles set empEnable='0' where empID='" & eempID & "' and rolID='" & a1 & "' "
                Con.deleteDataValues(Query)
                Me.lnkPR.Text = "Enable"
            ElseIf a1 = "PR" And a2 = False Then
                Query = "Update boEmployeeRoles set empEnable='1' where empID='" & eempID & "' and rolID='" & a1 & "' "
                Con.deleteDataValues(Query)
                Me.lnkPR.Text = "Disable"
            End If
        Next
        ds.dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing

        Response.Redirect("rightassign.aspx?empID=" & eempID & "")
    End Sub
    Protected Sub lnkMT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMT.Click
        Dim Con As New DBTaskBO
        'Dim dr As SqlDataReader
        'dr = Con.getDataReader("Select * From boEmployeeRoles WHERE empID='" & eempID & "'")
        Dim Query As String
        'While dr.Read
        '    Dim a1 As String = dr("rolID")
        '    Dim a2 As Boolean = dr("empEnable")
        '    If a1 = "MT" And a2 = True Then
        '        Query = "Update boEmployeeRoles set empEnable='0' where empID='" & eempID & "' and rolID='" & a1 & "' "
        '        Con.deleteDataValues(Query)
        '        Me.lnkMT.Text = "Enable"
        '    ElseIf a1 = "MT" And a2 = False Then
        '        Query = "Update boEmployeeRoles set empEnable='1' where empID='" & eempID & "' and rolID='" & a1 & "' "
        '        Con.deleteDataValues(Query)
        '        Me.lnkMT.Text = "Disable"
        '    End If
        'End While

        Dim ds As DataSet
        ds = Con.getDataSet("Select * From boEmployeeRoles WHERE empID='" & eempID & "'")
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim a1 As String = dr("rolID")
            Dim a2 As Boolean = dr("empEnable")
            If a1 = "MT" And a2 = True Then
                Query = "Update boEmployeeRoles set empEnable='0' where empID='" & eempID & "' and rolID='" & a1 & "' "
                Con.deleteDataValues(Query)
                Me.lnkMT.Text = "Enable"
            ElseIf a1 = "MT" And a2 = False Then
                Query = "Update boEmployeeRoles set empEnable='1' where empID='" & eempID & "' and rolID='" & a1 & "' "
                Con.deleteDataValues(Query)
                Me.lnkMT.Text = "Disable"
            End If
        Next
        ds.dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing

        Response.Redirect("rightassign.aspx?empID=" & eempID & "")
    End Sub

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Response.Redirect("employeemain.aspx")
    End Sub

End Class

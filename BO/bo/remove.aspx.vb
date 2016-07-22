Imports MTBMS.DAL
Partial Class BO_removeMT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim objRemove As New RemoveRoll()
            objRemove.Remove(Request.QueryString("rolID"), Request.QueryString("team"), Request.QueryString("empID"))
            objRemove = Nothing
            Response.Redirect("teamedit.aspx")
        End If
    End Sub
End Class

Public Class RemoveRoll
    Private text_MT As String = "DELETE boTeamPlayers WHERE rolID='MT'"
    Private text_QC As String = "DELETE boTeamPlayers WHERE rolID='QC'"

    Public Function Remove(ByVal rolID As String, ByVal team As String, ByVal empID As String)
        Dim objDb As New DBTaskBO()
        If rolID.ToLower = "mt" Then
            Try
                text_MT += " AND team='" & team & "' AND empID='" & empID & "'"
                objDb.update(text_MT)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Else
            Try
                text_MT &= " AND team='" & team & "' AND teamParent='" & empID & "';"
                text_MT &= " " & text_QC & " AND team='" & team & "' AND empID='" & empID & "'"
                objDb.update(text_MT)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If
    End Function
End Class

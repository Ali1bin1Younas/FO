
Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Imports System.Web.Services
Imports Microsoft.Web.Script.Services

Partial Class dictatormain
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        Try
            Session("cint") = 0
            If Not Page.IsPostBack Then
                LoadGrid()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadGrid()
        Try
            Dim con As New DBTaskBO
            Dim ds As DataSet

            ds = con.getDataSet("Select drID,foID,drFirstName,drLastName,drMiddleName,drSpecialty,IsNull(drDifficulty, '') as drDifficulty From boDictator order by foID,drID")
            grdDictator.DataSource = ds.Tables(0)
            grdDictator.DataBind()

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub grdDictator_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dif As String = Me.grdDictator.DataKeys(e.Row.RowIndex).Values.Item(0).ToString().Trim()

            'dicIDs being assign to the checkboxes of Roles (MT,QC,PR,FR), can not change this
            Dim chkD As HtmlInputCheckBox = CType(e.Row.FindControl("chkD"), HtmlInputCheckBox)
            Dim chkM As HtmlInputCheckBox = CType(e.Row.FindControl("chkM"), HtmlInputCheckBox)
            Dim chkE As HtmlInputCheckBox = CType(e.Row.FindControl("chkE"), HtmlInputCheckBox)

            If dif = "D" Then
                chkM.Disabled = True
                chkE.Disabled = True
                chkD.Checked = True
            ElseIf dif = "M" Then
                chkM.Checked = True
                chkE.Disabled = True
                chkD.Disabled = True
            ElseIf dif = "E" Then
                chkM.Disabled = True
                chkE.Checked = True
                chkD.Disabled = True
            End If
        End If
    End Sub

    Protected Function getCounter() As String
        Dim intCount As Integer = Session("cint")
        intCount += 1
        Session("cint") = intCount
        Return intCount.ToString
    End Function

    <WebMethod> _
    <ScriptMethod> _
    Public Shared Function set_difficulty(ByVal dif As String, ByVal is_chk As Boolean, ByVal drID As String) As String
        Dim Qry As String
        Dim Con As New MTBMS.DAL.DBTaskBO

        Try
            Qry = "UPDATE boDictator SET drDifficulty = '" & dif & "' WHERE drID = " & drID
            Con.getScalar(Qry)
            Return "1"
        Catch ex As Exception
            Return ex.Message.ToString()
        Finally
            Qry = Nothing
            Con = Nothing
        End Try

    End Function
End Class

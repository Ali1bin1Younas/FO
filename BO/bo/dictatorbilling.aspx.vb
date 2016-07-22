Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class FO_dictatorbilling
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        ViewState("cintDaily") = 0
        If Not Page.IsPostBack Then
            loadcombo()
            loadgrid()
        End If
    End Sub

    Private Sub loadcombo()
        Dim query As String
        Dim con As New DBTaskBO
        query = "select foID,foID +' - '+ isnull(foName,'') as foName from boFo where foEnable=1"
        Dim ds As DataSet
        ds = con.getDataSet(query)
        Me.cmbFoLoad.DataSource = ds
        Me.cmbFoLoad.DataBind()
    End Sub
    Private Sub loadgrid()

        Dim query As String
        Dim con As New DBTaskBO
        Dim ds As DataSet
        query = "select * from boDictator where foID='" + Me.cmbFoLoad.SelectedValue + "' "
        ds = con.getDataSet(query)
        gridbilling.DataSource = ds
        gridbilling.DataBind()

    End Sub
    Protected Function getcounter() As String

        Dim intCountDaily As Integer = ViewState("cintDaily")
        intCountDaily += 1
        ViewState("cintDaily") = intCountDaily
        Return intCountDaily.ToString
    End Function

    Protected Sub gridbilling_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridbilling.RowCommand


        Dim row As GridViewRow = Me.gridbilling.Rows(e.CommandArgument.ToString)

        If e.CommandName = "Submit" Then

            Dim query As String
            Dim con As New DBTaskBO
            Dim textboxclient As TextBox = row.FindControl("Rate")

            query = "update boDictator set drRate='" & textboxclient.Text & "' "

            textboxclient = row.FindControl("Line")
            query = query + " , drCharacterPerLine='" + textboxclient.Text + "' "

            Dim checkboxclient As CheckBox

            checkboxclient = row.FindControl("Bold")
            query = query + " , drCountBold='" + checkboxclient.Checked.ToString + "' "

            checkboxclient = row.FindControl("Space")
            query = query + " , drCountSpace='" + checkboxclient.Checked.ToString + "' "

            checkboxclient = row.FindControl("Italic")
            query = query + " , drCountItalic='" + checkboxclient.Checked.ToString + "' "

            checkboxclient = row.FindControl("Underline")
            query = query + " , drCountUnderLine='" + checkboxclient.Checked.ToString + "'  where drID='" + row.Cells(1).Text + "' and foID='" + Me.cmbFoLoad.SelectedValue + "'"

            query = query.Replace("True", "1")
            query = query.Replace("False", "0")

            con.update(query)


        End If

    End Sub




    Protected Sub gridbilling_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridbilling.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then


            'Dim addButton As Button = e.Row.FindControl("Submit")
            'addButton.CommandArgument = e.Row.RowIndex.ToString()

            Dim addButton As ImageButton = e.Row.FindControl("Submit")
            addButton.CommandArgument = e.Row.RowIndex.ToString()
        End If
    End Sub

    Protected Sub cmbFoLoad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFoLoad.SelectedIndexChanged
        loadgrid()
    End Sub
End Class

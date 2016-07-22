Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Class templatemain
    Inherits System.Web.UI.Page
    Protected iCounter As Int16
    Protected index As Integer
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        iCounter = 0
        
        If Not Page.IsPostBack Then
            loadDictator()
            loadGrid()
        End If

    End Sub

    Private Sub loadDictator()
        Dim Con As New DBTaskBO
        Dim Query As String = "Select * From boDictator ORDER BY drID"

        Dim ds As DataSet
        ds = Con.getDataSet(Query)
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim str As String = dr("drID").ToString + "-" + dr("foID").ToString + " - " + dr("drLastName").ToString + ", " + dr("drFirstName").ToString

            Me.cmbDictator.Items.Add(str)
        Next

        ds.Dispose()
        ds = Nothing

    End Sub

    Private Sub loadGrid()

        Dim Con As New DBTaskBO
        Dim strWholeName As String = Me.cmbDictator.Text.ToString

        Dim strdrID As String = strWholeName.Substring(0, 4)
        Dim strfoID As String = strWholeName.Substring(5, 4)

        Dim Query As String = "Select * From boTemplates where drID='" & strdrID & "' and foID='" & strfoID & "' "
        Dim ds As DataSet
        ds = Con.getDataSet(Query)
        Me.grdTemplates.DataSource = ds
        Me.grdTemplates.DataBind()
        ds.Dispose()
        ds = Nothing
        iCounter = 0
    End Sub

    Private Function GetDictatorID(ByVal did As String) As String
        Dim Con As New DBTaskBO
        Dim strdrID As String = Nothing
        Dim Query As String = "Select drID From boDictator Where drFirstName='" & did & "'"
        Dim ds As DataSet
        ds = Con.getDataSet(Query)

        If ds.Tables(0).Rows.Count > 0 Then
            strdrID = ds.Tables(0).Rows(0).Item("drID")
        End If

        ds.Dispose()
        ds = Nothing

        Return strdrID
    End Function

    Protected Sub btnAddTemplate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddTemplate.Click
        If upTemplate.HasFile Then
            Dim strWholeName As String = Me.cmbDictator.Text.ToString

            Dim drID As String = strWholeName.Substring(0, 4)
            Dim foID As String = strWholeName.Substring(5, 4)
            Dim temActualName As String = upTemplate.FileName
            Dim temTempName As String = foID & drID & "_" & Left(temActualName, Len(temActualName) - 4) & "_" & Format(Now.Date, "MMddyy") & "-" & Format(Now, "mmss") & "." & Right(temActualName, 3)

            System.IO.Directory.CreateDirectory(Server.MapPath("../") & "/data/" & foID & drID & "/templates/")

            upTemplate.SaveAs(Server.MapPath("../") & "/data/" & foID & drID & "/templates/" & temTempName)

            Dim Con As New DBTaskBO
            Dim sSQL As String = "SELECT MAX(temID) FROM boTemplates"
            Dim temID As Long = Con.getScalar(sSQL) + 1

            sSQL = "INSERT INTO boTemplates (temID,drID,foID,temActualName,temTempName,temDate,temStatus,temEnable) VALUES(" & temID & ",'" & drID & "','" & foID & "','" & temActualName & "','" & temTempName & "','" & Format(Date.Today().Date, "MM/dd/yy") & "',0,1)"
            Con.saveData(sSQL)
            loadGrid()
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        iCounter = 0
        Call loadGrid()
    End Sub

    Protected Function getEnableDisable(ByVal ED As Boolean) As String

        If ED Then
            Return "../Icon/Ngood.gif".Trim
        Else
            Return "../Icon/cancel.gif".Trim
        End If

    End Function

    Protected Function getCU(ByVal ED As String) As String

        If ED.ToString = "True" Then
            Return "../Icon/checked.gif".Trim
        Else
            Return "../Icon/UnChecked.gif".Trim
        End If

    End Function

    Protected Sub grdTemplates_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdTemplates.RowCreated
        If e.Row.RowIndex > 0 Then
            iCounter += 1
        End If

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim ImageDefault As ImageButton = e.Row.FindControl("ImageButtonDefault")
            ImageDefault.CommandArgument = e.Row.RowIndex
            ImageDefault.CommandName = "Default"

            Dim ImgaeED As ImageButton = e.Row.FindControl("ButtonED")
            ImgaeED.CommandArgument = e.Row.RowIndex
            ImgaeED.CommandName = "ButtonED"

        End If
    End Sub

    Protected Sub grdTemplates_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdTemplates.RowCommand

        'If e.CommandName = "Default" Then

        '    ' Convert the row index stored in the CommandArgument
        '    ' property to an Integer.
        '    Dim strWholeName As String = Me.cmbDictator.Text.ToString

        '    Dim strdrID As String = strWholeName.Substring(0, 4)
        '    Dim strfoID As String = strWholeName.Substring(5, 4)

        '    Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        '    ' Retrieve the row that contains the button clicked 
        '    ' by the user from the Rows collection.
        '    Dim row As GridViewRow = grdTemplates.Rows(index)
        '    Dim temID As Integer = Server.HtmlDecode(row.Cells(4).Text)

        '    Dim Con As New DBTaskBO
        '    Dim temID1 As String = 1
        '    Dim isD1 As Integer = 1
        '    Dim isD0 As Integer = 0

        '    Dim sSQL0 As String = "UPDATE boTemplates SET temDefault='" & isD0 & "' WHERE drID='" & strdrID & "' AND foID='" & strfoID & "'"
        '    Con.saveData(sSQL0)

        '    Dim sSQL1 As String = "UPDATE boTemplates SET temDefault='" & isD1 & "' WHERE temID ='" & temID & "'"
        '    Con.saveData(sSQL1)
        '    Call loadGrid()

        'End If

    End Sub

    Protected Sub setDefault_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim btn As ImageButton = CType(sender, ImageButton)

        Dim index As Integer = Convert.ToInt32(btn.CommandArgument)
        ' Retrieve the row that contains the button clicked 
        ' by the user from the Rows collection.
        Dim row As GridViewRow = grdTemplates.Rows(index)
        Dim temID As Integer = CType(Me.grdTemplates.DataKeys(index).Values.Item("temID"), Integer)

        Dim strWholeName As String = Me.cmbDictator.Text.ToString

        Dim strdrID As String = strWholeName.Substring(0, 4)
        Dim strfoID As String = strWholeName.Substring(5, 4)

        Dim Qry As String
        Dim Con As New DBTaskBO
        Dim zero As Integer = 0
        Dim one As Integer = 1

        Dim sSQL0 As String = "UPDATE boTemplates SET temDefault='" & zero & "' WHERE drID='" & strdrID & "' AND foID='" & strfoID & "'"
        Con.saveData(sSQL0)

        Dim sSQL1 As String = "UPDATE boTemplates SET temDefault='" & one & "' WHERE temID ='" & temID & "'"
        Con.saveData(sSQL1)
        Call loadGrid()

        loadGrid()

    End Sub

    Protected Sub setEnableDisable_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim btn As ImageButton = CType(sender, ImageButton)

        Dim index As Integer = Convert.ToInt32(btn.CommandArgument)
        ' Retrieve the row that contains the button clicked 
        ' by the user from the Rows collection.
        Dim row As GridViewRow = grdTemplates.Rows(index)
        Dim temID As Integer = CType(Me.grdTemplates.DataKeys(index).Values.Item("temID"), Integer)
        Dim ED As Boolean = CType(Me.grdTemplates.DataKeys(index).Values.Item("temEnable"), Boolean)

        Dim Qry As String
        Dim Con As New DBTaskBO
        Dim zero As Integer = 0
        Dim one As Integer = 1

        If ED Then
            Qry = "Update boTemplates SET temEnable='0' WHERE temID=" & temID

        Else
            Qry = "Update boTemplates SET temEnable='1' WHERE temID=" & temID
        End If

        Con.saveData(Qry)
        loadGrid()
        
    End Sub
End Class
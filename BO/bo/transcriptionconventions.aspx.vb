Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class BO_transcriptionconventions
    Inherits System.Web.UI.Page
    Dim con As New DBTaskBO
    Dim ds As DataSet
    Dim Qry As String
    Dim check As Boolean
    Dim NcfoID, NcCliID, NcActualName, NcPatientFirstName, NcPatientLastName, NcDate, NcTime
    Protected Sub bntSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bntSubmit.Click

        
        Try
            If txtPath.Text = "" Then
                Me.lblErrorMsg.Text = "Select the Directory Path"
                Exit Sub
            Else
                If IO.Directory.Exists(Me.txtPath.Text) = False Then
                    Me.lblErrorMsg.Text = "Invalid Directory Path"
                    Exit Sub
                Else
                    Me.lblErrorMsg.Text = " "
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Qry = "SELECT * from boNamingConvention where foId='" & Me.ddlFo.SelectedValue & "' AND isTranscription='" & Me.ddlTrans.SelectedValue & "'"
        ds = con.getDataSet(Qry)

        If ds.Tables(0).Rows.Count = 0 Then
            check = True
        Else
            check = False
        End If

        If cbxFoID.Checked Then
            NcfoID = 1
        Else
            NcfoID = 0
        End If
        If Me.CbxDrId.Checked Then
            NcCliID = 1
        Else
            NcCliID = 0
        End If

        If Me.CbxAdNAme.Checked Then
            NcActualName = 1
        Else
            NcActualName = 0
        End If

        If Me.cbxPLastName.Checked And Me.ddlTrans.SelectedValue = 1 Then
            NcPatientLastName = 1
        Else
            NcPatientLastName = 0
        End If

        If Me.cbxPFirstName.Checked And Me.ddlTrans.SelectedValue = 1 Then
            NcPatientFirstName = 1
        Else
            NcPatientFirstName = 0
        End If

        If Me.cbxDate.Checked Then
            NcDate = 1
        Else
            NcDate = 0
        End If
        If Me.cbxTimeStamp.Checked Then
            NcTime = 1
        Else
            NcTime = 0
        End If
        Try
            If check Then
                Qry = "Insert INTO boNamingConvention(foID,isTranscription,NcfoId, "
                Qry += "NcCliID, NcActualName, NcPatientFirstName, "
                Qry += " NcPatientLastName, NcDate, NcTime,ncPath) Values('"
                Qry += Me.ddlFo.SelectedValue & "','" & Me.ddlTrans.SelectedValue & "','" & NcfoID & "', '" & NcCliID & "', '" & NcActualName & "', '" & NcPatientFirstName & "', '" & NcPatientLastName & "', '" & NcDate & "', '" & NcTime & "','" & Me.txtPath.Text & "')"
                con.saveData(Qry)
            Else
                Qry = "UPDATE boNamingConvention SET NcfoId= '" & NcfoID & "',NcCliID='" & NcCliID & "',NcActualName='" & NcActualName & "',NcPatientFirstName='" & NcPatientFirstName & "',NcPatientLastName='" & NcPatientLastName & "',NcDate='" & NcDate & "',NcTime='" & NcTime & "',ncPath='" & Me.txtPath.Text & "' where foId = '" & Me.ddlFo.SelectedValue & "' AND isTranscription= '" & Me.ddlTrans.SelectedValue & "' "
                con.saveData(Qry)
            End If
        Catch ex As SyntaxErrorException
            lblErrorMsg.Text = "Sorry Enable To Proces....... Try Again with Correct Information"
            Exit Sub
        End Try
        Me.Show_Fo_Record(Me.ddlTrans.SelectedValue, Me.ddlFo.SelectedValue)
        Trans()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        If Not Me.IsPostBack Then

            Qry = "SELECT foId, FOID + '-' + foName As FullName FROM bofo where foEnable=1 order by foId"
            ds = con.getDataSet(Qry)
            Me.ddlFo.DataSource = ds
            Me.ddlFo.DataBind()
            If Me.ddlTrans.SelectedValue = 0 Then
                Me.cbxPFirstName.Visible = False
                Me.cbxPLastName.Visible = False
            Else
                Me.cbxPFirstName.Visible = True
                Me.cbxPLastName.Visible = True
            End If
            Me.Show_Fo_Record(Me.ddlTrans.SelectedValue, Me.ddlFo.SelectedValue)

        End If
        Trans()
    End Sub
    Protected Sub Trans()
        cbxFoID.Attributes.Add("onclick", "CheckBoxConvention()")
        CbxDrId.Attributes.Add("onclick", "CheckBoxConvention()")
        CbxAdNAme.Attributes.Add("onclick", "CheckBoxConvention()")
        cbxPLastName.Attributes.Add("onclick", "CheckBoxConvention()")
        cbxPFirstName.Attributes.Add("onclick", "CheckBoxConvention()")
        cbxDate.Attributes.Add("onclick", "CheckBoxConvention()")
        cbxTimeStamp.Attributes.Add("onclick", "CheckBoxConvention()")

    End Sub

    Protected Sub Show_Fo_Record(ByVal IsTrans As String, ByVal foid As Integer)
        Me.txtTrans.Text = ""
        Qry = "SELECT * from boNamingConvention where isTranscription='" & IsTrans & "' and foId='" & foid & "'"
        ds = con.getDataSet(Qry)
        If Me.ddlTrans.SelectedValue = 0 Then
            Me.cbxPFirstName.Visible = False
            Me.cbxPLastName.Visible = False
        Else
            Me.cbxPFirstName.Visible = True
            Me.cbxPLastName.Visible = True
        End If
        If ds.Tables(0).Rows.Count = 0 Then
            Me.cbxFoID.Checked = False
            Me.CbxAdNAme.Checked = False
            Me.CbxDrId.Checked = False
            Me.cbxPFirstName.Checked = False
            Me.cbxPLastName.Checked = False
            Me.cbxDate.Checked = False
            Me.cbxTimeStamp.Checked = False
            Me.txtTrans.Text = ""
            Exit Sub
        End If

        If ds.Tables(0).Rows(0).Item("NcfoID") = "1" Then
            Me.cbxFoID.Checked = True
            Me.txtTrans.Text = "1111"
        Else
            Me.cbxFoID.Checked = False
        End If

        If ds.Tables(0).Rows(0).Item("NcCliID") = "1" Then
            Me.CbxDrId.Checked = True
            Me.txtTrans.Text += "3333"
        Else
            Me.CbxDrId.Checked = False
        End If

        If ds.Tables(0).Rows(0).Item("NcActualName") = "1" Then
            Me.CbxAdNAme.Checked = True
            If Me.cbxFoID.Checked Or Me.CbxDrId.Checked Then
                Me.txtTrans.Text += "_12345678"
            Else
                Me.txtTrans.Text += "12345678"
            End If
        Else
            Me.CbxAdNAme.Checked = False
        End If


        If ds.Tables(0).Rows(0).Item("NcPatientLastName") = "1" Then
            Me.cbxPLastName.Checked = True
            If Me.cbxFoID.Checked Or Me.CbxDrId.Checked Or Me.CbxAdNAme.Checked Then
                Me.txtTrans.Text += "_LastName"
            Else
                Me.txtTrans.Text += "LastName"
            End If
        Else
            Me.cbxPLastName.Checked = False
        End If

        If ds.Tables(0).Rows(0).Item("NcPatientFirstName") = "1" Then
            Me.cbxPFirstName.Checked = True
            If Me.cbxPLastName.Checked Then
                Me.txtTrans.Text += "-FirstName"
            ElseIf Me.cbxFoID.Checked Or Me.CbxDrId.Checked Or Me.CbxAdNAme.Checked Then
                Me.txtTrans.Text += "_FirstName"
            Else
                Me.txtTrans.Text += "FirstName"
            End If
        Else
            Me.cbxPFirstName.Checked = False
        End If

        If ds.Tables(0).Rows(0).Item("NcDate") = "1" Then
            Me.cbxDate.Checked = True
            If Me.cbxFoID.Checked Or Me.CbxDrId.Checked Or Me.CbxAdNAme.Checked Or Me.cbxPLastName.Checked Or Me.cbxPFirstName.Checked Then
                Me.txtTrans.Text += "_MMDDYY"
            Else
                Me.txtTrans.Text = "MMDDYY"
            End If
        Else
            Me.cbxDate.Checked = False
        End If

        If ds.Tables(0).Rows(0).Item("NcTime") = "1" Then
            Me.cbxTimeStamp.Checked = True
            If Me.cbxDate.Checked Then
                Me.txtTrans.Text += "-MMSS"
            ElseIf Me.cbxFoID.Checked Or Me.CbxDrId.Checked Or Me.CbxAdNAme.Checked Or Me.cbxPLastName.Checked Or Me.cbxPFirstName.Checked Then
                Me.txtTrans.Text += "_MMSS"
            Else
                Me.txtTrans.Text += "MMSS"
            End If
        Else
            Me.cbxTimeStamp.Checked = False
        End If
        Me.txtPath.Text = ds.Tables(0).Rows(0).Item("ncPath").ToString
    End Sub

    Protected Sub btnCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheck.Click
        Me.txtPath.Text = ""
        Me.lblErrorMsg.Text = ""
        Me.Show_Fo_Record(Me.ddlTrans.SelectedValue, Me.ddlFo.SelectedValue)
    End Sub
End Class

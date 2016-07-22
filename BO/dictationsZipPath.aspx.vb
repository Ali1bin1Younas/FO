
Partial Class dictationsZipPath
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim isRecordFound As Boolean = True
        If Not String.IsNullOrEmpty(Request.QueryString("fileName")) Then

            Dim TempFileName As String = Request.QueryString("fileName")
            If TempFileName = "" OrElse TempFileName Is Nothing Then
                Response.Write("http://www.ais.com")
            Else
                Try
                    Dim objDb As New MTBMS.DAL.DBTaskBO()

                    Dim dicPath As String = Server.MapPath("Data/dictationsZips/") & TempFileName
                    Dim fStream As New IO.FileStream(dicPath, IO.FileMode.Open)
                    Dim fLength As Double = fStream.Length
                    Dim fSize(fStream.Length) As Byte
                    Try
                        fStream.Read(fSize, 0, fStream.Length)
                        fStream.Close()
                        HttpContext.Current.Response.Buffer = False
                        HttpContext.Current.Response.ClearContent()
                        HttpContext.Current.Response.ClearHeaders()
                        HttpContext.Current.Response.AddHeader("Content-disposition", "attachment; filename=" & TempFileName)
                        HttpContext.Current.Response.AddHeader("Content-Length", fLength)
                        HttpContext.Current.Response.ContentType = "audio/mpeg3"
                        HttpContext.Current.Response.AddHeader("Content-Transfer-Encoding", "binary")
                        HttpContext.Current.Response.TransmitFile(dicPath)
                    Catch ex As Exception
                        isRecordFound = False
                    Finally
                        Response.Clear()
                        Dim sc As String = "<script>window.opener=self;window.close();</script>"
                        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "window.close()", sc)
                    End Try
                Catch ex As Exception
                    If Not isRecordFound Then
                        Response.Write("<p style='font: normal 9pt Verdana; color:red'>Sorry dictation record not found.</p>")
                    Else
                        Response.Write("<p style='font: normal 9pt Verdana; color:red'>Sorry dictation file not found.</p>")
                    End If
                End Try

            End If

        Else
            Response.Clear()
            Dim sc As String = "<script>window.opener=self;window.close();</script>"
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "window.close()", sc)
        End If


    End Sub
End Class

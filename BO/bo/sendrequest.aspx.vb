Imports System.net
Partial Class MMO_sendrequest
    Inherits System.Web.UI.Page
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim request As HttpWebRequest = Nothing
        Dim response As HttpWebResponse = Nothing

        'declaration
        request = WebRequest.Create("http://localhost:2294/FO/FO/action.aspx")
        request.Method = "POST"
        request.Timeout = 100000
        'request.ContentType = "application/x-www-form-urlencoded"
        'request.Accept = "text/xml"
        'Write data on stream
        Dim DataStream As New IO.StreamWriter(request.GetRequestStream)
        DataStream.WriteLine("insert into tbl_FrontOffice(foID) Values('2397')")
        'DataStream.WriteLine("345436")
        DataStream.Flush()
        DataStream.Close()

        'get data from stream
        response = request.GetResponse

        Dim sr As New IO.StreamReader(response.GetResponseStream)
        Dim strFoIDsAndTranscriptions As String = sr.ReadToEnd
        MsgBox(strFoIDsAndTranscriptions)

        'Dim objfo As New FrontOfficeDO("2312", "Shabbir")

        'Dim ws As New serviceupdatefodb
        'ws.InsertFOData(objfo)

    End Sub






    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
    End Sub
End Class

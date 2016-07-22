
Partial Class ws
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim rsWS As New wsMathes.Service
        TextBox1.Text = rsWS.Add(2, 3)

    End Sub
End Class

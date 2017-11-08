Public Class Form_Login1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        Dim obj As New ClsUsuario
        Dim dt As New DataTable
        dt = obj.Logueo(txtUsuario.Text, txtContrasena.Text).Tables(0)
        If dt.Rows(0)(0).ToString = "1" Then
            Session("usuario") = txtUsuario.Text

            Response.Redirect("Default.aspx")
        Else
            Response.Redirect("Form_Login.aspx")
        End If

    End Sub

    Sub login()
       
    End Sub

End Class
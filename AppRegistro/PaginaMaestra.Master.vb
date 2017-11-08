Public Class PaginaMaestra
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim VarUSUARIO As String
        VarUSUARIO = CType(Session.Item("usuario"), String)
        txtCuentaUsuario.Text = VarUSUARIO
    End Sub

End Class
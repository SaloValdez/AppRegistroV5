Public Class Form_Usuario
    Inherits System.Web.UI.Page
    Dim obj As New ClsUsuario

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call listar()
        txtCorrecto.Visible = False
        txtError.Visible = False

    End Sub
    Sub listar()
        gwUsuario.DataSource = obj.Listar_Usuario.Tables(0)
        gwUsuario.DataBind()
    End Sub

    Sub Listar_Semestre_Modificar()
        Dim dt As New DataTable
        dt = obj.Listar_Usuario_Buscar(txtId.Text).Tables(0)
        txtUsuario.Text = dt.Rows(0)(1).ToString
        txtContrasena.Text = dt.Rows(0)(2).ToString
    End Sub

    Sub limpiar()
        txtId.Text = ""
        txtUsuario.Text = ""
        txtContrasena.Text = ""
        txtCorrecto.Visible = False
        txtError.Visible = False

    End Sub

    Protected Sub gwUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gwUsuario.SelectedIndexChanged
        Dim row As GridViewRow = gwUsuario.SelectedRow
        Dim id As Integer = Convert.ToInt32(gwUsuario.DataKeys(row.RowIndex).Value)
        txtId.Text = id
        Call Listar_Semestre_Modificar()
    End Sub
    Private Sub gwUsuario_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gwUsuario.PageIndexChanging
        gwUsuario.PageIndex = e.NewPageIndex
        Call listar()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If Not (txtUsuario.Text = "" Or txtContrasena.Text = "") Then
                obj.Insertar_Usuario(txtUsuario.Text, txtContrasena.Text)
                Call listar()
                Call limpiar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro guardado exitosamente."
            Else
                txtError.Visible = True
                txtError.Text = "Por favor llene los campos vacios."
            End If

        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR. Por favor comuniquese con el admistrador."
        End Try


    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Not (txtId.Text = "") Then
                obj.Actualizar_Usuario(txtUsuario.Text, txtContrasena.Text, txtId.Text)
                Call listar()
                Call limpiar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro Actializado."
            Else
                txtError.Visible = True
                txtError.Text = "Por favor seleccione un registro"
            End If
        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR. Por favor comuniquese ocn el administrador"
        End Try

    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If Not (txtId.Text = "") Then
                obj.Eliminar_Usuario(txtId.Text)
                Call listar()
                Call limpiar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro Eliminado."
            Else
                txtError.Visible = True
                txtError.Text = "Por favor seleccione un registro"
            End If
        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR. Por favor comuniquese ocn el administrador"
        End Try


    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Call limpiar()
    End Sub

End Class
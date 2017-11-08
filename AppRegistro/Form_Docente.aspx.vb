Public Class Form_Docente
    Inherits System.Web.UI.Page
    Dim obj As New ClsDocente

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call listar()
        txtCorrecto.Visible = False
        txtError.Visible = False

    End Sub

    Sub listar()
        gwDocente.DataSource = obj.Listar_Docente.Tables(0)
        gwDocente.DataBind()
    End Sub
    Sub Listar_Docente_Modificar()
        Dim dt As New DataTable
        dt = obj.Listar_Docente_Buscar(txtId.Text).Tables(0)
        txtNombres.Text = dt.Rows(0)(1).ToString
    End Sub
    Sub limpiar()
        txtId.Text = ""
        txtNombres.Text = ""
    End Sub

    Protected Sub gwDocente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gwDocente.SelectedIndexChanged
        Dim row As GridViewRow = gwDocente.SelectedRow
        Dim id As Integer = Convert.ToInt32(gwDocente.DataKeys(row.RowIndex).Value)
        txtId.Text = id
        Call Listar_Docente_Modificar()
    End Sub

    Private Sub gwDocente_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gwDocente.PageIndexChanging
        gwDocente.PageIndex = e.NewPageIndex
        Call listar()
    End Sub


    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If Not (txtNombres.Text = "") Then
                obj.Insertar_Docente(txtNombres.Text)
                Call limpiar()
                listar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro guardado exitosamente"
            Else
                txtError.Visible = True
                txtError.Text = "Por favor llene los campos vacios"

            End If
        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR Comunoquese con el administrador"
        End Try
    End Sub


    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Not (txtId.Text = "") Then
                obj.Modificar_Docente(txtNombres.Text, txtId.Text)
                Call limpiar()
                listar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro actualizado correctamente"
            Else
                txtError.Visible = True
                txtError.Text = "Por favor seleccone un registro"
            End If

        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR Comuniquese con eladmistrador"
        End Try
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Try
            If Not (txtId.Text = "") Then
                obj.Eliminar_Docente(txtId.Text)
                Call limpiar()
                listar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro eliminado exitosamente"

            Else
                txtError.Visible = True
                txtError.Text = "Por favor seleccione un registro"

            End If
        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR Comuniquese con el adminstrador"
        End Try

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Call limpiar()


    End Sub
End Class
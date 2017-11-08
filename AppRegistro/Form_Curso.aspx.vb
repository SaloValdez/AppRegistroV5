Public Class Form_Curso
    Inherits System.Web.UI.Page
    Dim obj As New ClsCurso


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call listar()
        txtCorrecto.Visible = False
        txtError.Visible = False

    End Sub

    Sub listar()
        gwCurso.DataSource = obj.Listar_Curso()
        gwCurso.DataBind()
    End Sub
    Sub listar_Curso_Modificar()
        '--Mostrar datos en caja de texto
        Dim dt As New DataTable
        dt = obj.Listar_Curso_Buscar(txtId.Text).Tables(0)
        txtNombre.Text = dt.Rows(0)(1).ToString
    End Sub

    Sub limpiar()
        txtId.Text = ""
        txtNombre.Text = ""
        txtCorrecto.Visible = False
        txtError.Visible = False

    End Sub




    Protected Sub gwCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gwCurso.SelectedIndexChanged
        Dim row As GridViewRow = gwCurso.SelectedRow
        Dim id As Integer = Convert.ToInt32(gwCurso.DataKeys(row.RowIndex).Value)
        txtId.Text = id
        Call listar_Curso_Modificar()
    End Sub
    Private Sub gwCurso_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gwCurso.PageIndexChanging
        gwCurso.PageIndex = e.NewPageIndex
        Call listar()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If Not (txtNombre.Text = "") Then
                obj.Insertar_Curso(txtNombre.Text)
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
                obj.Actualizar_Curso(txtNombre.Text, txtId.Text)
                Call limpiar()
                listar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro actualizado exitosamente"
            Else
                txtError.Visible = True
                txtError.Text = "Por favor seleccione un registro"

            End If
        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR Comunoquese con el administrador"
        End Try
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If Not (txtId.Text = "") Then
                obj.Insertar_Curso(txtNombre.Text)
                Call limpiar()
                listar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro elimnado exitosamente"
            Else
                txtError.Visible = True
                txtError.Text = "Por favor seleccione un registro"

            End If
        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR Comunoquese con el administrador"
        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Call limpiar()

    End Sub
End Class
Public Class Form_Carrera
    Inherits System.Web.UI.Page

    Dim obj As New ClsCarrera

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call listar()
        txtCorrecto.Visible = False
        txtError.Visible = False
   
    End Sub

    Sub listar()
        gwCarrera.DataSource = obj.Listar_Carrera.Tables(0)
        gwCarrera.DataBind()
    End Sub

    Sub limpiar()
        txtId.Text = ""
        txtDescripcion.Text = ""
        txtError.Visible = False
        txtCorrecto.Visible = False
    End Sub

    Protected Sub gwCarrera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gwCarrera.SelectedIndexChanged
        Dim row As GridViewRow = gwCarrera.SelectedRow
        Dim id As Integer = Convert.ToInt32(gwCarrera.DataKeys(row.RowIndex).Value)
        txtId.Text = id
        ' Call Listar_Alumno_Modificar()
    End Sub

    Private Sub gwCarrera_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gwCarrera.PageIndexChanging
        gwCarrera.PageIndex = e.NewPageIndex
        Call listar()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If Not (txtDescripcion.Text = "") Then

                Dim iret As String
                iret = obj.Insertar_Carrera(Me.txtDescripcion.Text)
                Call listar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro guardado exitosamente"
            Else
                txtError.Visible = True
                txtError.Text = "Por favor llene los campos vacios"
            End If

        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR Comuniquese con el adminstrador"
        End Try




    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Not (txtId.Text = "") Then
                Dim iret As String
                iret = obj.Actualizar_Carrera(Me.txtDescripcion.Text, Me.txtId.Text)
                Call listar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro actualizado exitosamente."
            Else
                txtError.Visible = True
                txtError.Text = "por favor seleccione un registros"

            End If

        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR Comuniquese con el administrador"
        End Try
    
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Try
            If Not (txtId.Text = "") Then
                Dim iret As String
                iret = obj.Eliminar_carrera(Me.txtId.Text)
                Call listar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro eliminado exitoisamente"
            Else
                txtError.Visible = True
                txtError.Text = "Por favor seleccione un registros"
            End If
        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "Por favor comuniquese con el adminisrtador"

        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Call limpiar()

    End Sub
End Class
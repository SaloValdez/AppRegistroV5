Public Class Form_Semestre
    Inherits System.Web.UI.Page
    Dim obj As New ClsSemestre

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call listar()
        txtCorrecto.Visible = False
        txtError.Visible = False
    End Sub

    Sub listar()
        gwSemestre.DataSource = obj.Listar_Semestre.Tables(0)
        gwSemestre.DataBind()
    End Sub

    Sub Listar_Semestre_Modificar()
        Dim dt As New DataTable
        dt = obj.Listar_Semestre_Buscar(txtId.Text).Tables(0)
        txtDescripcion.Text = dt.Rows(0)(1).ToString
    End Sub

    Sub limpiar()
        txtId.Text = ""
        txtDescripcion.Text = ""
        txtCorrecto.Visible = False
        txtError.Visible = False

    End Sub

    Protected Sub gwSemestre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gwSemestre.SelectedIndexChanged
        Dim row As GridViewRow = gwSemestre.SelectedRow
        Dim id As Integer = Convert.ToInt32(gwSemestre.DataKeys(row.RowIndex).Value)
        txtId.Text = id
        Call Listar_Semestre_Modificar()
    End Sub
    Private Sub gwSemestre_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gwSemestre.PageIndexChanging
        gwSemestre.PageIndex = e.NewPageIndex
        Call listar()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If Not (txtDescripcion.Text = "") Then
                obj.Insertar_Semestre(txtDescripcion.Text)
                Call listar()
                Call limpiar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro guardado."
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
                obj.Actualizar_Semestre(txtDescripcion.Text, txtId.Text)
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
                obj.Eliminar_Semestre(txtId.Text)
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
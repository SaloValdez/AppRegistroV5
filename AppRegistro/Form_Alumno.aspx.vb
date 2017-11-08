Public Class Form_Alumno
    Inherits System.Web.UI.Page

    Dim obj As New ClsAlumno

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CargarComboSemestre()
            Call CargarComboCarrera()
        End If


        Call listar()



        txtCorrecto.Visible = False
        txtError.Visible = False
    End Sub

    Sub listar()
        gwAlumno.DataSource = obj.Listar_Alumno.Tables(0)
        gwAlumno.DataBind()
    End Sub
    Sub Listar_Alumno_Modificar()
        '--Mostrar datos en caja de texto
        Dim dt As New DataTable
        dt = obj.Listar_Alumno_Buscar(txtId.Text).Tables(0)
        txtNombre.Text = dt.Rows(0)(1).ToString
        txtApellido.Text = dt.Rows(0)(2).ToString
        txtDireccion.Text = dt.Rows(0)(3).ToString
        DroCarrera.SelectedValue = dt.Rows(0)(4).ToString
        DroSemestre.SelectedValue = dt.Rows(0)(5).ToString
    End Sub

    Sub CargarComboCarrera()
        Dim dtcombo As New DataTable
        dtcombo = obj.Listar_Carrera_Combo.Tables(0)
        Me.DroCarrera.DataSource = dtcombo
        Me.DroCarrera.DataValueField = "idcarrera"
        Me.DroCarrera.DataTextField = "descripcion"
        Me.DroCarrera.DataBind()
    End Sub
    Sub CargarComboSemestre()
        Dim dtcombo As New DataTable
        dtcombo = obj.Listar_Semestre_Combo.Tables(0)
        Me.droSemestre.DataSource = dtcombo
        Me.droSemestre.DataValueField = "idsemestre"
        Me.droSemestre.DataTextField = "descripcion"
        Me.droSemestre.DataBind()
    End Sub
    Sub limpiar()
        txtId.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtDireccion.Text = ""
        txtCorrecto.Visible = False
        txtError.Visible = False
    End Sub
    Protected Sub gwAlumno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gwAlumno.SelectedIndexChanged
        Dim row As GridViewRow = gwAlumno.SelectedRow
        Dim id As Integer = Convert.ToInt32(gwAlumno.DataKeys(row.RowIndex).Value)
        txtId.Text = id
        Call Listar_Alumno_Modificar()
    End Sub

    Private Sub gwDocente_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gwAlumno.PageIndexChanging
        gwAlumno.PageIndex = e.NewPageIndex
        Call listar()
    End Sub
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If Not (txtNombre.Text = "" Or txtApellido.Text = "" Or txtDireccion.Text = "") Then
                obj.Insertar_Alumno(txtNombre.Text, txtApellido.Text, txtDireccion.Text, droCarrera.SelectedValue, droSemestre.SelectedValue)
                Call limpiar()
                Call listar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro guadado exitosamente."
            Else
                txtError.Visible = True
                txtError.Text = "Por favor llene los campos vacios."

            End If

        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR. Por favor comuniquese con el administrador."
        End Try
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Not (txtId.Text = "") Then
                obj.Actualizar_Alumno(txtNombre.Text, txtApellido.Text, txtDireccion.Text, droCarrera.SelectedValue, droSemestre.SelectedValue, txtId.Text)
                Call listar()
                Call limpiar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro actualizado exitosamente."
            Else
                txtError.Visible = True
                txtError.Text = "Por favor  seleccione un registro."
            End If

        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR. Por favor comuniquese con el administrador"
        End Try
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If Not (txtId.Text = "") Then

                obj.Eliminar_Alumno(txtId.Text)
                Call listar()
                Call limpiar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro eliminado exitosamente."
            Else
                txtError.Visible = True
                txtError.Text = "Por favor  seleccione un registro."
            End If
        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR. Por favor comuniquese con el administrador"
        End Try
    
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Call limpiar()
    End Sub
End Class
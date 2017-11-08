Public Class Form_Registro
    Inherits System.Web.UI.Page
    Dim obj As New ClsRegistro

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call Listar()
        If Not IsPostBack Then
            Call Cargar_Combo_Alumno()
            Call Cargar_Combo_Curso()
            Call Cargar_Combo_Docente()
        End If
        txtCorrecto.Visible = False
        txtError.Visible = False
    End Sub
    Sub Listar()
        Dim dtcombo As New DataTable
        Me.gwRegistro.DataSource = obj.Listar_Registro.Tables(0)
        Me.gwRegistro.DataBind()
    End Sub

    Sub listar_Registro_Modificar()
        Dim dt As New DataTable
        dt = obj.Listar_Registro_Buscar(txtId.Text).Tables(0)
        DroAlumno.SelectedValue = dt.Rows(0)(1).ToString
        DroCurso.SelectedValue = dt.Rows(0)(2).ToString
        DroDocente.SelectedValue = dt.Rows(0)(3).ToString
        txtNota1.Text = dt.Rows(0)(4).ToString
        txtNota2.Text = dt.Rows(0)(5).ToString
        txtNota3.Text = dt.Rows(0)(6).ToString
    End Sub

    Sub Cargar_Combo_Alumno()
        Dim dtcombo As New DataTable
        dtcombo = obj.Listar_Alumno_Combo.Tables(0)
        Me.DroAlumno.DataSource = dtcombo
        Me.DroAlumno.DataValueField = "idalumno"
        Me.DroAlumno.DataTextField = "nombre"
        Me.DroAlumno.DataBind()
    End Sub

    Sub Cargar_Combo_Curso()
        Dim dtcombo As New DataTable
        dtcombo = obj.Listar_Curso_Combo.Tables(0)
        Me.DroCurso.DataSource = dtcombo
        Me.DroCurso.DataValueField = "idcurso"
        Me.DroCurso.DataTextField = "nombre"
        Me.DroCurso.DataBind()
    End Sub
    Sub Cargar_Combo_Docente()
        Dim dtcombo As New DataTable
        dtcombo = obj.Listar_Docente_Combo.Tables(0)
        Me.DroDocente.DataSource = dtcombo
        Me.DroDocente.DataValueField = "iddocente"
        Me.DroDocente.DataTextField = "nombre"
        Me.DroDocente.DataBind()
    End Sub

    Sub limpiar()
        txtId.Text = ""
        txtNota1.Text = ""
        txtNota2.Text = ""
        txtNota3.Text = ""
        txtCorrecto.Visible = False
        txtError.Visible = False
    End Sub

    Protected Sub gwRegistro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gwRegistro.SelectedIndexChanged
        Dim row As GridViewRow = gwRegistro.SelectedRow
        Dim id As Integer = Convert.ToInt32(gwRegistro.DataKeys(row.RowIndex).Value)
        txtId.Text = id
        Call listar_Registro_Modificar()
    End Sub

    Private Sub gwRegistro_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gwRegistro.PageIndexChanging
        gwRegistro.PageIndex = e.NewPageIndex
        Call Listar()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If Not (txtNota1.Text = "" Or txtNota2.Text = "" Or txtNota3.Text = "") Then
                obj.Insertar_Registro(droAlumno.SelectedValue, droCurso.SelectedValue, droDocente.SelectedValue, txtNota1.Text, txtNota2.Text, txtNota3.Text)
                Call Listar()
                Call limpiar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro guardado..."
            Else
                txtError.Visible = True
                txtError.Text = "Por favor llene los campos vacios"
            End If
        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR. Por favor comuniquese con el administrador."
        End Try
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Not (txtId.Text = "") Then

                obj.Modificar_Registro(droAlumno.SelectedValue, droCurso.SelectedValue, droDocente.SelectedValue, txtNota1.Text, txtNota2.Text, txtNota3.Text, txtId.Text)
                Call limpiar()
                Call Listar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro actualizado exitosamente"
            Else
                txtError.Visible = True
                txtId.Text = "Por favor seleccione un registro."
            End If

        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR. por favor comuniquese con el administrador."

        End Try


    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If Not (txtId.Text = "") Then

                obj.Eliminar_Registro(txtId.Text)
                Call Listar()
                limpiar()
                txtCorrecto.Visible = True
                txtCorrecto.Text = "Registro Eliminado"
            Else
                txtError.Visible = True
                txtId.Text = "Por favor seleccione un registro."
            End If
        Catch ex As Exception
            txtError.Visible = True
            txtError.Text = "ERROR. por favor comuniquese con el administrador."
        End Try
        

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Call limpiar()
    End Sub
End Class
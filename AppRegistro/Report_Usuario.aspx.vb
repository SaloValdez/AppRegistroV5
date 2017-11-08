Public Class Report_Usuario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call listar_Reporte_Usuario()

        End If
    End Sub
    Sub listar_Reporte_Usuario()
        Dim rds As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim dtsdatos As New DataTable
        Dim obj As New ClsUsuario
        Try
            rds.Name = "DataUsuario" 'Conjunto de datos
            dtsdatos = obj.Listar_Usuario_rep.Tables(0)
            If dtsdatos.Rows.Count > 0 Then
                rds.Value = dtsdatos
                repUsuario.LocalReport.DataSources.Clear()
                repUsuario.LocalReport.DataSources.Add(rds)
                'RepRegistro.LocalReport.ReportPath = "C:\Users\SaloNet\Documents\Visual Studio 2015\Projects\prueba\prueba\Rep_Registros2.rdlc"
                repUsuario.LocalReport.ReportPath = "C:\inetpub\AppRegistro\InforUsuario.rdlc"
                repUsuario.DataBind()
            Else
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
End Class
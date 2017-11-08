Public Class Report_Docente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call listar_Reporte_Docente()

        End If
    End Sub
    Sub listar_Reporte_Docente()
        Dim rds As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim dtsdatos As New DataTable
        Dim obj As New ClsDocente
        Try
            rds.Name = "DataDocente" 'Conjunto de datos
            dtsdatos = obj.Listar_Docente_rep.Tables(0)
            If dtsdatos.Rows.Count > 0 Then
                rds.Value = dtsdatos
                repDocente.LocalReport.DataSources.Clear()
                repDocente.LocalReport.DataSources.Add(rds)
                'RepRegistro.LocalReport.ReportPath = "C:\Users\SaloNet\Documents\Visual Studio 2015\Projects\prueba\prueba\Rep_Registros2.rdlc"
                repDocente.LocalReport.ReportPath = "C:\inetpub\AppRegistro\InforDocente.rdlc"
                repDocente.DataBind()
            Else
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
End Class
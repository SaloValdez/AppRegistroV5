Public Class Report_Registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call listar_Reporte_Registro()

        End If
    End Sub

    Sub listar_Reporte_Registro()
        Dim rds As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim dtsdatos As New DataTable
        Dim obj As New ClsRegistro
        Try
            rds.Name = "DataRegistro" 'Conjunto de 

            dtsdatos = obj.Listar_Registro_Dos.Tables(0)
            If dtsdatos.Rows.Count > 0 Then
                rds.Value = dtsdatos
                repRegistro.LocalReport.DataSources.Clear()
                repRegistro.LocalReport.DataSources.Add(rds)
                'RepRegistro.LocalReport.ReportPath = "C:\Users\SaloNet\Documents\Visual Studio 2015\Projects\prueba\prueba\Rep_Registros2.rdlc"
                repRegistro.LocalReport.ReportPath = "\\SALONET\Users\Public\MIERCOLES\AppRegistro\AppRegistro\RepRegistro.rdlc"
                repRegistro.DataBind()
            Else
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

End Class
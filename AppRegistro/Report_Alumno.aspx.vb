Public Class Report_Alumno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call listar_Reporte_Registro()

        End If
    End Sub

    Sub listar_Reporte_Registro()
        Dim rds As New Microsoft.Reporting.WebForms.ReportDataSource
        
        Dim dtsdatos As New DataTable
        Dim obj As New ClsAlumno
        Try
            rds.Name = "DataAlumno" 'Conjunto de 
            
            dtsdatos = obj.Listar_Alumno_inf.Tables(0)
            If dtsdatos.Rows.Count > 0 Then
                rds.Value = dtsdatos
                repAlumno.LocalReport.DataSources.Clear()
                repAlumno.LocalReport.DataSources.Add(rds)
                'RepRegistro.LocalReport.ReportPath = "C:\Users\SaloNet\Documents\Visual Studio 2015\Projects\prueba\prueba\Rep_Registros2.rdlc"
                repAlumno.LocalReport.ReportPath = "C:\inetpub\AppRegistro\Infor_Alumno.rdlc"
                repAlumno.DataBind()
            Else
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

End Class
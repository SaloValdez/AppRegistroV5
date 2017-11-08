Imports System.Data.SqlClient

Public Class ClsCurso

    Public Function conexion() As String
        Dim cn As String = "Data Source=SALONET;Initial Catalog=DBNOTAS;Persist Security Info=True;User ID=acuario;Password=tresmastres6"
        Return cn
    End Function
    '-----------------------Listar Curso
    Function Listar_Curso() As DataSet
        Dim ds As New DataSet
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.Text
                    ocmd.CommandText = "SELECT [idcurso] as ID,[nombre] FROM [dbo].[curso]"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function

    '-----------------------Insertar Curso
    Public Function Insertar_Curso(ByVal NombreCurso As String) As String
        Dim iRet As Integer
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "INSERT INTO CURSO (nombre)values('" & NombreCurso & "')"
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '-----------------------Actualizar Curso
    Public Function Actualizar_Curso(ByVal NombreCurso As String,
                                       ByVal IdCurso As Integer) As String
        'Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.Text
                        oCmd.CommandText = "UPDATE curso SET nombre ='" & NombreCurso & "' WHERE idcurso ='" & IdCurso & "'"
                        oCn.Open()
                        oCmd.ExecuteNonQuery()
                        oCn.Close()
                        Actualizar_Curso = 1
                    End Using
                End Using
            End Using
        Catch
            Actualizar_Curso = 0
        Finally
            'lobjExecute = Nothing
        End Try
    End Function
    '-----------------------Eliminar Alumno
    Public Function Eliminar_Curso(ByVal id As Integer) As Integer
        Dim iRet As Integer
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "DELETE FROM curso WHERE idcurso='" & id & "'"
                    oCn.Open()
                    iRet = oCmd.ExecuteNonQuery
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function

    ' ===================   LISTAR SEMESTRE SELECCIONAR ( BUSCAR ) =========================================================
    Function Listar_Curso_Buscar(ByVal id As Integer) As DataSet
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "Select * from curso where idcurso='" & id & "'"
                    oDa.SelectCommand = oCmd
                    oCn.Open()
                    oDa.Fill(Ds)
                    oCn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function
End Class

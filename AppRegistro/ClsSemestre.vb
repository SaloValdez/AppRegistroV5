Imports System.Data.SqlClient

Public Class ClsSemestre
    Public Function conexion() As String
        Dim cn As String = "Data Source=SALONET;Initial Catalog=DBNOTAS;Persist Security Info=True;User ID=acuario;Password=tresmastres6"
        Return cn
    End Function
    '-----------------------Listar Alumno
    Function Listar_Semestre() As DataSet
        Dim ds As New DataSet
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.Text
                    ocmd.CommandText = "SELECT [idsemestre] as ID,[descripcion] FROM [dbo].[SEMESTRE]"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function

    '-----------------------Insertar Alumno
    Public Function Insertar_Semestre(ByVal DescripcionSemestre As String) As String
        Dim iRet As Integer
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "INSERT INTO SEMESTRE (descripcion)values('" & DescripcionSemestre & "')"
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '-----------------------Actualizar Alumno
    Public Function Actualizar_Semestre(ByVal DescripcionSemestre As String,
                                       ByVal IdSemestre As Integer) As String
        'Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.Text
                        oCmd.CommandText = "UPDATE semestre SET descripcion ='" & DescripcionSemestre & "' WHERE idsemestre ='" & IdSemestre & "'"
                        oCn.Open()
                        oCmd.ExecuteNonQuery()
                        oCn.Close()
                        Actualizar_Semestre = 1
                    End Using
                End Using
            End Using
        Catch
            Actualizar_Semestre = 0
        Finally
            'lobjExecute = Nothing
        End Try
    End Function
    '-----------------------Eliminar Alumno
    Public Function Eliminar_Semestre(ByVal id As Integer) As Integer
        Dim iRet As Integer
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "DELETE FROM semestre WHERE idsemestre='" & id & "'"
                    oCn.Open()
                    iRet = oCmd.ExecuteNonQuery
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function

    ' ===================   LISTAR SEMESTRE SELECCIONAR ( BUSCAR ) =========================================================
    Function Listar_Semestre_Buscar(ByVal id As Integer) As DataSet
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "Select * from semestre where idsemestre='" & id & "'"
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

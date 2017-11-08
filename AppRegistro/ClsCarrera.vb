Imports System.Data.SqlClient

Public Class ClsCarrera
    Public Function conexion() As String
        Dim cn As String = "Data Source=SALONET;Initial Catalog=DBNOTAS;Persist Security Info=True;User ID=acuario;Password=tresmastres6"
        Return cn
    End Function
    '-----------------------Listar Alumno
    Function Listar_Carrera() As DataSet
        Dim ds As New DataSet
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.Text
                    ocmd.CommandText = "SELECT idcarrera as ID,descripcion as NOMBRE from carrera"
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
    Public Function Insertar_Carrera(ByVal NombreCarrera As String) As String
        Dim iRet As Integer
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "INSERT INTO CARRERA (descripcion) values('" & NombreCarrera & "')"
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '-----------------------Actualizar Alumno
    Public Function Actualizar_Carrera(ByVal NombreCarrera As String,
                                       ByVal IdCarrera As Integer) As String
        'Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.Text
                        oCmd.CommandText = "UPDATE carrera SET descripcion ='" & NombreCarrera & "' WHERE idcarrera ='" & IdCarrera & "'"
                        oCn.Open()
                        oCmd.ExecuteNonQuery()
                        oCn.Close()
                        Actualizar_Carrera = 1
                    End Using
                End Using
            End Using
        Catch
            Actualizar_Carrera = 0
        Finally
            'lobjExecute = Nothing
        End Try
    End Function
    '-----------------------Eliminar CaRRERA
    Public Function Eliminar_carrera(ByVal id As Integer) As Integer
        Dim iRet As Integer
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "DELETE FROM carrera WHERE idcarrera='" & id & "'"
                    oCn.Open()
                    iRet = oCmd.ExecuteNonQuery
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
End Class






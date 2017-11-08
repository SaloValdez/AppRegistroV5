Imports System.Data.SqlClient

Public Class ClsUsuario
    Public Function conexion() As String
        Dim cn As String = "Data Source=SALONET;Initial Catalog=DBNOTAS;Persist Security Info=True;User ID=acuario;Password=tresmastres6"
        Return cn
    End Function
    '-----------------------Listar Curso
    Function Listar_Usuario() As DataSet
        Dim ds As New DataSet
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.Text
                    ocmd.CommandText = "SELECT [idusuario] as ID,[usuario],[contrasena]  FROM [dbo].[usuario]"
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
    Public Function Insertar_Usuario(ByVal Usuario As String, ByVal Contrasena As String) As String
        Dim iRet As Integer
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "INSERT INTO USUARIO (usuario,contrasena)values('" & Usuario & "','" & Contrasena & "')"
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '-----------------------Actualizar Curso
    Public Function Actualizar_Usuario(ByVal usuario As String, ByVal contrasena As String,
                                       ByVal idUsuario As Integer) As String
        'Dim lobjExecute As New BCventas.ClsConexion
        Try
            Using oCn As New SqlConnection
                Using oDa As New SqlDataAdapter
                    Using oCmd As New SqlCommand
                        oCn.ConnectionString = conexion()
                        oCmd.Connection = oCn
                        oCmd.CommandType = CommandType.Text
                        oCmd.CommandText = "UPDATE usuario SET usuario ='" & usuario & "', contrasena ='" & contrasena & "' WHERE idusuario ='" & idUsuario & "'"
                        oCn.Open()
                        oCmd.ExecuteNonQuery()
                        oCn.Close()
                        Actualizar_Usuario = 1
                    End Using
                End Using
            End Using
        Catch
            Actualizar_Usuario = 0
        Finally
            'lobjExecute = Nothing
        End Try
    End Function
    '-----------------------Eliminar Alumno
    Public Function Eliminar_Usuario(ByVal id As Integer) As Integer
        Dim iRet As Integer
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "DELETE FROM usuario WHERE idusuario='" & id & "'"
                    oCn.Open()
                    iRet = oCmd.ExecuteNonQuery
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function

    ' ===================   LISTAR SEMESTRE SELECCIONAR ( BUSCAR ) =========================================================
    Function Listar_Usuario_Buscar(ByVal id As Integer) As DataSet
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "Select * from usuario where idusuario='" & id & "'"
                    oDa.SelectCommand = oCmd
                    oCn.Open()
                    oDa.Fill(Ds)
                    oCn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function



    '-------LOGEO----------------------------------------------
    Function Logueo(ByVal usuario As String, ByVal password As String) As DataSet
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = CONEXION()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "Select count(*) from Usuario where usuario='" & usuario & "' and contrasena='" & password & "'"
                    oDa.SelectCommand = oCmd
                    oCn.Open()
                    oDa.Fill(Ds)
                    oCn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function
    '-----------------------Listar Curso
    Function Listar_Usuario_rep() As DataSet
        Dim ds As New DataSet
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.Text
                    ocmd.CommandText = "SELECT * FROM [dbo].[usuario]"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function
End Class

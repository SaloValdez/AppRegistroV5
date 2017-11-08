Imports System.Data.SqlClient

Public Class ClsAlumno
    Public Function conexion() As String
        Dim cn As String = "Data Source=SALONET;Initial Catalog=DBNOTAS;Persist Security Info=True;User ID=acuario;Password=tresmastres6"
        Return cn
    End Function
    '-----------------------Listar Alumno
    Function Listar_Alumno() As DataSet
        Dim ds As New DataSet
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.Text
                    ocmd.CommandText = "select [idalumno] as ID ,[nombre] AS NOMBRE ,[apellido] AS APELLIDO ,[direccion] AS DIRECCION ,[idcarrera] AS CARRERA ,[idsemestre] AS SEMESTRE from  ALUMNO"
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
    Public Function Insertar_Alumno(ByVal NombreAlumno As String,
                                    ByVal ApellidoAlumno As String,
                                    ByVal DireccionAlumno As String,
                                    ByVal IdCarrera As Integer,
                                    ByVal IdSemestre As Integer) As String
        Dim iRet As Integer
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "INSERT INTO ALUMNO(nombre,apellido,direccion,idcarrera,idsemestre)values('" & NombreAlumno & "','" & ApellidoAlumno & "','" & DireccionAlumno & "','" & IdCarrera & "','" & IdSemestre & "')"
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    ' ===================   LISTAR ALUMNO SELECCIONAR ( BUSCAR ) =========================================================
    Function Listar_Alumno_Buscar(ByVal id As Integer) As DataSet
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "Select * from alumno where idalumno='" & id & "'"
                    oDa.SelectCommand = oCmd
                    oCn.Open()
                    oDa.Fill(Ds)
                    oCn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function
    Public Function Actualizar_Alumno(ByVal NombreAlumno As String,
                                            ByVal ApellidoAlumno As String,
                                            ByVal DireccionAlumno As String,
                                            ByVal IdCarrera As Integer,
                                            ByVal IdSemestre As Integer,
                                            ByVal IdAlumno As Integer) As String
        'Dim lobjExecute As New BCventas.ClsConexion
        Dim iRet As Integer
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "UPDATE alumno SET nombre='" & NombreAlumno & "',apellido='" & ApellidoAlumno & "',direccion='" & DireccionAlumno & "',idcarrera='" & IdCarrera & "',idsemestre='" & IdSemestre & "' WHERE idalumno ='" & IdAlumno & "'"
                    oCn.Open()
                    iRet = oCmd.ExecuteNonQuery
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function


    '-----------------------Eliminar Alumno
    Public Function Eliminar_Alumno(ByVal IdAlumno As Integer) As Integer
        Dim iRet As Integer
        Dim Ds As New DataSet
        Using oCn As New SqlClient.SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "DELETE FROM alumno WHERE idalumno='" & IdAlumno & "'"
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function

    '-----------------------Listar combo carrera
    Function Listar_Carrera_Combo() As DataSet
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "Select idcarrera ,descripcion from carrera"
                    oDa.SelectCommand = oCmd
                    oCn.Open()
                    oDa.Fill(Ds)
                    oCn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function
    '-----------------------Listar combo semestre
    Function Listar_Semestre_Combo() As DataSet
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "Select idsemestre,descripcion from semestre"
                    oDa.SelectCommand = oCmd
                    oCn.Open()
                    oDa.Fill(Ds)
                    oCn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function

    '-----------------------Listar Alumno INFORME
    Function Listar_Alumno_inf() As DataSet
        Dim ds As New DataSet
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.Text
                    ocmd.CommandText = "select * from alumno"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function



    '-----------------------Listar Alumno INFORME
    Function Listar_Alumno_inf2() As DataSet
        Dim ds As New DataSet
        Using ocn As New SqlConnection
            Using oda As New SqlDataAdapter
                Using ocmd As New SqlCommand
                    ocn.ConnectionString = conexion()
                    ocmd.Connection = ocn
                    ocmd.CommandType = CommandType.Text
                    ocmd.CommandText = "select * from alumno"
                    oda.SelectCommand = ocmd
                    ocn.Open()
                    oda.Fill(ds)
                    ocn.Close()
                End Using
            End Using
        End Using
        Return ds
    End Function

    '==========================Listar Registro ==================================
    Function Listar_alumno_rep() As DataSet
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "select alumno.idalumno,alumno.nombre,alumno.apellido,alumno.direccion,semestre.descripcion,carrera.descripcion from alumno inner join semestre on alumno.idsemestre=semestre.idsemestre inner join carrera on alumno.idcarrera=carrera.idcarrera"
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

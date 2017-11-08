Imports System.Data.SqlClient

Public Class ClsRegistro
    Public Function conexion() As String
        Dim cn As String = "Data Source=SALONET;Initial Catalog=DBNOTAS;Persist Security Info=True;User ID=acuario;Password=tresmastres6"
        Return cn
    End Function
    '==========================Listar Registro ==================================
    Function Listar_Registro2() As DataSet
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "select [idregistro] as ID ,[idalumno] AS ALUMNO ,[idcurso] AS CURSO,[iddocente] AS DOCENTE ,[Nota1] AS NOTA1 ,[Nota2] AS NOTA2, [Nota3] AS NOTA3, [promedio],  AS PROMEDIO  from  REGISTRO"
                    oDa.SelectCommand = oCmd
                    oCn.Open()
                    oDa.Fill(Ds)
                    oCn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function
    '_______________ INSERTAR REGISTRO______________________
    Public Function Insertar_Registro(ByVal idAlumno As Integer,
                                      ByVal idCurso As Integer,
                                      ByVal idDocente As Integer,
                                      ByVal Nota1 As Integer,
                                      ByVal Nota2 As Integer,
                                      ByVal Nota3 As Integer) As String
        Dim iRet As Integer
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "INSERT INTO REGISTRO(idalumno,idcurso,iddocente,Nota1,Nota2,Nota3)values('" & idAlumno & "','" & idCurso & "','" & idDocente & "','" & Nota1 & "','" & Nota2 & "','" & Nota3 & "')"
                    oCn.Open()
                    iRet = oCmd.ExecuteScalar()
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function
    '_______________ LISTAR REGISTRO______________________
    Function Listar_Registro() As DataSet
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "SELECT idregistro AS ID, (AL.nombre + '  ' + AL.apellido) AS 'NOMBRES Y APELLIDOS', CUR.nombre AS CURSO, DOC.nombre AS DOCENTE, REG.nota1 AS 'NOTA 1',REG.nota2 AS 'NOTA 2',REG.nota3 AS 'NOTA 3', REG.promedio AS PROMEDIO, REG.observacion AS OBSERVACION FROM registro REG inner join alumno AL on REG.idalumno=AL.idalumno inner join CURSO CUR on REG.idcurso = CUR.idcurso inner join docente DOC on REG.iddocente = DOC.iddocente"
                    oDa.SelectCommand = oCmd
                    oCn.Open()
                    oDa.Fill(Ds)
                    oCn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function
    Function Listar_Registro_Buscar(ByVal id As Integer) As DataSet
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "Select * from registro where idregistro='" & id & "'"
                    oDa.SelectCommand = oCmd
                    oCn.Open()
                    oDa.Fill(Ds)
                    oCn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function

    '_______________ LISTAR REGISTRO______________________
    Function Listar_Registro_Dos() As DataSet
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "SELECT [idregistro],[idalumno],[idcurso],[iddocente],[Nota1],[Nota2],[Nota3] FROM [dbo].[REGISTRO]"
                    oDa.SelectCommand = oCmd
                    oCn.Open()
                    oDa.Fill(Ds)
                    oCn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function


    '_______________ LENAR COMBO ALUMNO______________________
    Function Listar_Alumno_Combo() As DataSet
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "SELECT idalumno,nombre FROM ALUMNO"
                    oDa.SelectCommand = oCmd
                    oCn.Open()
                    oDa.Fill(Ds)
                    oCn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function
    '_______________ LENAR COMBO CURSO______________________
    Function Listar_Curso_Combo() As DataSet
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "SELECT idcurso,nombre FROM CURSO"
                    oDa.SelectCommand = oCmd
                    oCn.Open()
                    oDa.Fill(Ds)
                    oCn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function
    '_______________ LENAR COMBO DOCENTE______________________
    Function Listar_Docente_Combo() As DataSet
        Dim Ds As New DataSet
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "SELECT IDDOCENTE,NOMBRE FROM DOCENTE"
                    oDa.SelectCommand = oCmd
                    oCn.Open()
                    oDa.Fill(Ds)
                    oCn.Close()
                End Using
            End Using
        End Using
        Return Ds
    End Function

    Public Function Modificar_Registro(ByVal idAlumno As Integer, ByVal idCurso As Integer, ByVal idDocente As Integer, ByVal nota1 As Integer, ByVal nota2 As Integer, ByVal nota3 As Integer, ByVal id As Integer) As Integer
        Dim iRet As Integer
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "UPDATE registro SET idalumno='" & idAlumno & "',idcurso='" & idCurso & "',iddocente='" & idDocente & "',nota1='" & nota1 & "',nota2='" & nota2 & "',nota3='" & nota3 & "' WHERE idregistro='" & id & "'"
                    oCn.Open()
                    iRet = oCmd.ExecuteNonQuery
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function

    Public Function Eliminar_Registro(ByVal id As Integer) As Integer
        Dim iRet As Integer
        Using oCn As New SqlConnection
            Using oDa As New SqlDataAdapter
                Using oCmd As New SqlCommand
                    oCn.ConnectionString = conexion()
                    oCmd.Connection = oCn
                    oCmd.CommandType = CommandType.Text
                    oCmd.CommandText = "DELETE FROM registro WHERE idregistro='" & id & "'"
                    oCn.Open()
                    iRet = oCmd.ExecuteNonQuery
                    oCn.Close()
                End Using
            End Using
        End Using
        Return iRet
    End Function


End Class

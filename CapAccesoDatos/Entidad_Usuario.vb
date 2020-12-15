Public Class Entidad_Usuario

    Private idEmpleados As Integer
    Private cedulaEmpleados As Integer
    Private nombreEmpleados As String
    Private usuarioEmpleados As String
    Private contrasenaEmpleados As String
    Private fk_idDepartamento As Integer

    Public Property _idEmpleados
        Get
            Return idEmpleados
        End Get
        Set(value)
            idEmpleados = value
        End Set
    End Property

    Public Property _cedulaEmpleados
        Get
            Return cedulaEmpleados
        End Get
        Set(value)
            cedulaEmpleados = value
        End Set
    End Property


    Public Property _nombreEmpleados
        Get
            Return nombreEmpleados
        End Get
        Set(value)
            nombreEmpleados = value
        End Set
    End Property

    Public Property _users
        Get
            Return usuarioEmpleados
        End Get
        Set(value)
            usuarioEmpleados = value
        End Set
    End Property

    Public Property _passwords
        Get
            Return contrasenaEmpleados
        End Get
        Set(value)
            contrasenaEmpleados = value
        End Set
    End Property

    Public Property _fk_idDepartamento
        Get
            Return fk_idDepartamento
        End Get
        Set(value)
            fk_idDepartamento = value
        End Set
    End Property


    Public Sub New()

    End Sub


End Class

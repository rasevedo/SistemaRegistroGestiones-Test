Public Class Entidad_Informe

    Private idInforme As Integer
    Private tituloInforme As String
    Private idEmpleados As Integer
    Private tipoInforme As String
    Private numeroOficio As String
    Private fechaAprobacion As DateTime
    Private fechaCulminacion As DateTime
    Private fechaTraslado As DateTime
    Private avanceInforme As String


    Public Property _idInforme
        Get
            Return idInforme
        End Get
        Set(value)
            idInforme = value
        End Set
    End Property

    Public Property _tituloInforme
        Get
            Return tituloInforme
        End Get
        Set(value)
            tituloInforme = value
        End Set
    End Property

    Public Property _idEmpleados
        Get
            Return idEmpleados
        End Get
        Set(value)
            idEmpleados = value
        End Set
    End Property

    Public Property _tipoInforme
        Get
            Return tipoInforme
        End Get
        Set(value)
            tipoInforme = value
        End Set
    End Property

    Public Property _numeroOficio
        Get
            Return numeroOficio
        End Get
        Set(value)
            numeroOficio = value
        End Set
    End Property

    Public Property _fechaAprobacion
        Get
            Return fechaAprobacion
        End Get
        Set(value)
            fechaAprobacion = value
        End Set
    End Property

    Public Property _fechaCulminacion
        Get
            Return fechaCulminacion
        End Get
        Set(value)
            fechaCulminacion = value
        End Set
    End Property

    Public Property _fechaTraslado
        Get
            Return fechaTraslado
        End Get
        Set(value)
            fechaTraslado = value
        End Set
    End Property

    Public Property _avanceInforme
        Get
            Return avanceInforme
        End Get
        Set(value)
            avanceInforme = value
        End Set
    End Property

    Public Sub New()

    End Sub

End Class


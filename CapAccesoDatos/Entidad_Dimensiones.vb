Public Class Entidad_Dimensiones

    Private idDimension As Integer
    Private tipoDimension As String
    Private descripcionTipoDimension As String
    Private letraDimension As String
    Private descripcionLetraDimension As String

    Public Property _idDimension
        Get
            Return idDimension
        End Get
        Set(value)
            idDimension = value
        End Set
    End Property

    Public Property _tipoDimension
        Get
            Return tipoDimension
        End Get
        Set(value)
            tipoDimension = value
        End Set
    End Property

    Public Property _descripcionTipoDimension
        Get
            Return descripcionTipoDimension
        End Get
        Set(value)
            descripcionTipoDimension = value
        End Set
    End Property

    Public Property _letraDimension
        Get
            Return letraDimension
        End Get
        Set(value)
            letraDimension = value
        End Set
    End Property

    Public Property _descripcionLetraDimension
        Get
            Return descripcionLetraDimension
        End Get
        Set(value)
            descripcionLetraDimension = value
        End Set
    End Property

    Public Sub New()

    End Sub

End Class

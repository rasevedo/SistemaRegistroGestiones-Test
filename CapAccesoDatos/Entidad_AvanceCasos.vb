Public Class Entidad_AvanceCasos

    Private idAvanceCasos As Integer
    Private idCasos As Integer
    Private detalleAvance As String
    Private fechaAvance As DateTime

    Public Property _idAvanceCasos
        Get
            Return idAvanceCasos
        End Get
        Set(value)
            idAvanceCasos = value
        End Set
    End Property

    Public Property _idCasos
        Get
            Return idCasos
        End Get
        Set(value)
            idCasos = value
        End Set
    End Property

    Public Property _detalleAvance
        Get
            Return detalleAvance
        End Get
        Set(value)
            detalleAvance = value
        End Set
    End Property

    Public Property _fechaAvance
        Get
            Return fechaAvance
        End Get
        Set(value)
            fechaAvance = value
        End Set
    End Property

    Public Sub New()

    End Sub

End Class

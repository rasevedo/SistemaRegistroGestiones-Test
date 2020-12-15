Public Class Entidad_Departamentos

    Private idDepartamento As Integer
    Private nombreDepartamento As String
    Private telefonoDepartamento As String

    Public Property _idDepartamento
        Get
            Return idDepartamento
        End Get
        Set(value)
            idDepartamento = value
        End Set
    End Property

    Public Property _nombreDepartamento
        Get
            Return nombreDepartamento
        End Get
        Set(value)
            nombreDepartamento = value
        End Set
    End Property

    Public Property _telefonoDepartamento
        Get
            Return telefonoDepartamento
        End Get
        Set(value)
            telefonoDepartamento = value
        End Set
    End Property

    Public Sub New()

    End Sub

End Class


Imports System.IO
Imports System.Xml.Serialization

Public Class Serializer

    Public Function Deserialize(Of T As Class)(ByVal input As String) As T
        Dim ser As XmlSerializer = New XmlSerializer(GetType(T))

        Using sr As StringReader = New StringReader(input)
            Return CType(ser.Deserialize(sr), T)
        End Using
    End Function

    Public Function Serialize(Of T)(ByVal ObjectToSerialize As T) As String
        Dim xmlSerializer As XmlSerializer = New XmlSerializer(ObjectToSerialize.[GetType]())

        Using textWriter As StringWriter = New StringWriter()
            xmlSerializer.Serialize(textWriter, ObjectToSerialize)
            Return textWriter.ToString()
        End Using
    End Function

End Class
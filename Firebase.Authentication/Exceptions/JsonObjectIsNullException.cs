namespace Firebase.Authentication.Exceptions;

public class JsonObjectIsNullException : Exception
{
    /// <summary>
    /// Deserialized JSON Object is null
    /// </summary>
    public JsonObjectIsNullException() : base("JSON_OBJECT_NULL", new("Deserialized JSON Object is null")) { }
}
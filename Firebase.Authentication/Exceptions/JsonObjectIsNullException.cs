namespace Firebase.Authentication.Exceptions;

public class JsonObjectIsNullException : Exception
{
    /// <summary>
    /// Deserialized JSON Object is null
    /// </summary>
    public JsonObjectIsNullException() : base("Deserialized JSON Object is null") { }
}
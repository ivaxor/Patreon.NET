using System;
using System.Net.Http;
using System.Runtime.Serialization;

namespace IVAXOR.PatreonNET.Exceptions;

[Serializable]
public class PatreonAPIException : Exception
{
    public int StatusCode { get; }
    public string Response { get; }

    public override string Message => $"Patreon API responded with {StatusCode} status code. Raw response: \"{Response}\"";

    public PatreonAPIException() { }

    public PatreonAPIException(HttpResponseMessage httpResponseMessage)
    {
        StatusCode = (int)httpResponseMessage.StatusCode;
        Response = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    }

    protected PatreonAPIException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

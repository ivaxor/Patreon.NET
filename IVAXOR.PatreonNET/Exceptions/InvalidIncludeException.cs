using System;
using System.Runtime.Serialization;

namespace IVAXOR.PatreonNET.Exceptions;

[Serializable]
public class InvalidIncludeException : Exception
{
    public InvalidIncludeException() { }
    protected InvalidIncludeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

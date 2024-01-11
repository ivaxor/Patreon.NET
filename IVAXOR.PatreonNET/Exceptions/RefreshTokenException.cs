using System;
using System.Runtime.Serialization;

namespace IVAXOR.PatreonNET.Exceptions;

[Serializable]
public class RefreshTokenException : Exception
{
    public RefreshTokenException() { }
    protected RefreshTokenException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

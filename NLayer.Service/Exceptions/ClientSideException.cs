﻿namespace NLayer.Service.Exceptions
{
    public class ClientSideException : Exception
    {
        public ClientSideException(string exceptionMessage):base(exceptionMessage)
        {
        }
    }
}

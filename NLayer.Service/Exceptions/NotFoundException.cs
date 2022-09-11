namespace NLayer.Service.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string exceptionMessage):base(exceptionMessage)
        {
        }
    }
}
